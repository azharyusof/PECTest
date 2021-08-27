using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Text.RegularExpressions;

public static class Extensions
{
    /// <summary>
    /// Wraps matched strings in HTML span elements styled with a background-color
    /// </summary>
    /// <param name="text"></param>
    /// <param name="keywords">Comma-separated list of strings to be highlighted</param>
    /// <param name="cssClass">The Css color to apply</param>
    /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
    /// <returns>string</returns>
    public static string HighlightKeyWords(this string text, string keywords, string cssClass, bool fullMatch)
    {
        if (text == String.Empty || keywords == String.Empty || cssClass == String.Empty)
            return text;
        var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (!fullMatch)
            return words.Select(word => word.Trim()).Aggregate(text,
                         (current, pattern) =>
                         Regex.Replace(current,
                                         pattern,
                                           string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                           cssClass,
                                           "$0"),
                                           RegexOptions.IgnoreCase));
        return words.Select(word => "\\b" + word.Trim() + "\\b")
                    .Aggregate(text, (current, pattern) =>
                              Regex.Replace(current,
                              pattern,
                                string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                cssClass,
                                "$0"),
                                RegexOptions.IgnoreCase));
    }
}

public partial class ManageWorkPackage : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
    DataRow row = null;
    String qs = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        DateTime now = DateTime.Now;

        lblUser.Text = Session["UserName"].ToString();
        lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

        if (!Page.IsPostBack)
        {
            //Bind dropdownlist
            bindDetails();

            bindWorkPkg();           
        }
    }

   
    protected void bindDetails()
    {
        
        qs = "";
        qs = qs + " SELECT        tblProjectMonthlyUpdate.DescriptionId, tblMain.ProjectCode ";
        qs = qs + " FROM          tblProjectMonthlyUpdate ";
        qs = qs + " INNER JOIN          tblMain ON tblProjectMonthlyUpdate.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblProjectMonthlyUpdate.DescriptionId = '" + Request.QueryString["Id"] + "' ";
        

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count == 0)
        {
            //Check for empty record.   
            dvInactive.Visible = true;
            dvActive.Visible = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            dvInactive.Visible = false;
            dvActive.Visible = true;

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();
        }
    }
               

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectMonthlyUpdateDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    private void bindWorkPkg()
    {
        String str;

        if (fldSearch.Text.Trim() != "")
        {
            str = "SELECT         * "
            + "FROM           tblWorkPackage "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND           (WorkPackageCode LIKE '%' + @search + '%' OR WorkPackage LIKE '%' + @search + '%') "
            + "ORDER BY       SortBy ";
        }
        else
        {
            str = "SELECT         * "
            + "FROM           tblWorkPackage "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       SortBy ";
        }

        SqlCommand xp = new SqlCommand(str, con);

        xp.Parameters.AddWithValue("@search", ((object)fldSearch.Text.Trim()) ?? DBNull.Value);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvWorkPkg.DataSource = ds;
        gvWorkPkg.DataBind();
        con.Close();

        for (int i = 0; i < gvWorkPkg.Rows.Count; i++)
        {
            GridViewRow row = gvWorkPkg.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
            }
        }

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        fldSearch.Text = "";

        bindWorkPkg();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_Word = fldSearch.Text.Trim();

        btnClear.Visible = true;

        bindWorkPkg();
    }

    protected void DeleteProjectDoc(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblWorkPackage WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindWorkPkg();
    }

    protected void EditProjectDoc(object sender, GridViewEditEventArgs e)
    {
        gvWorkPkg.EditIndex = e.NewEditIndex;
        bindWorkPkg();
    }

    protected void CancelProjectDocEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvWorkPkg.EditIndex = -1;
        bindWorkPkg();
    }

    protected void UpdateProjectDoc(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvWorkPkg.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Code = ((TextBox)gvWorkPkg.Rows[e.RowIndex].FindControl("txtCode")).Text;
        string WorkPackage = ((TextBox)gvWorkPkg.Rows[e.RowIndex].FindControl("txtWorkPackage")).Text;
        string SortBy = ((TextBox)gvWorkPkg.Rows[e.RowIndex].FindControl("txtSortBy")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblWorkPackage SET " +
            "WorkPackageCode=@pCode, " +
            "WorkPackage=@pWorkPackage, " +
            "SortBy=@pSortBy, " +
            "ModifyBy='" + Session["UserID"].ToString() + "', " +
            "DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' " +
            "WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pCode", SqlDbType.VarChar).Value = Code;
        cmd.Parameters.Add("@pWorkPackage", SqlDbType.VarChar).Value = WorkPackage;        
        cmd.Parameters.Add("@pSortBy", SqlDbType.VarChar).Value = SortBy;

        cmd.ExecuteNonQuery();

        gvWorkPkg.EditIndex = -1;
        bindWorkPkg();
    }

    protected void btnSaveD_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        //Insert into table tblWorkPackage
        queryString = "";
        queryString = queryString + " INSERT INTO   tblWorkPackage ";
        queryString = queryString + "               (DescriptionId, WorkPackageCode, WorkPackage, SortBy, CreatedBy, DateCreated) ";
        queryString = queryString + " VALUES        ('" + Request.QueryString["ID"] + "', @pCode, @pWorkPackage, @pSortBy, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pCode", fldCode.Text.Trim());
        cmd.Parameters.AddWithValue("@pWorkPackage", fldPackage.Text.Trim());
        cmd.Parameters.AddWithValue("@pSortBy", fldSortBy.Text.Trim());

        cmd.ExecuteNonQuery();
        con.Close();

        bindWorkPkg();
        Response.Redirect("ManageWorkPackage.aspx?ID=" + Request.QueryString["ID"]);
    }

    protected void btnCloseD_Click(object sender, EventArgs e)
    {
    }


    private static DataTable GetData(string query)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

}