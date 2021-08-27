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

public partial class EDMSOutgoing : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
    DataRow row = null;
    String qs = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlConnection conEDMS = new SqlConnection(ConfigurationManager.ConnectionStrings["EDMSConn"].ConnectionString);
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
            bindDetails();

            //Bind dropdownlist
            bindRegion();
            bindYear();
            bindCompany();
            bindOriginator();

            bindProjectDoc();

            if (lblCode1.Text != "")
            {
                fldRegion.Visible = true;
                fldCompany.Visible = true;
                fldOriginator.Visible = false;
            }
            else
            {
                fldRegion.Visible = false;
                fldCompany.Visible = false;
                fldOriginator.Visible = true;
            }
        }
    }

    protected void bindRegion()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT PROJECT_CODE ";
        qs = qs + " FROM          vwEDMSOutgoing ";
        qs = qs + " WHERE PROJECT_CODE = '" + lblCode.Text + "' ";
        qs = qs + " OR PROJECT_CODE = '" + lblCode1.Text + "' ";
        qs = qs + " ORDER BY      PROJECT_CODE DESC";

        fldRegion.DataSource = GetData(qs);
        fldRegion.DataTextField = "PROJECT_CODE";
        fldRegion.DataValueField = "PROJECT_CODE";
        fldRegion.DataBind();
        fldRegion.Items.Insert(0, new ListItem("-- ALL Regions --", ""));
    }

    protected void bindYear()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT YR ";
        qs = qs + " FROM          vwEDMSOutgoing ";
        qs = qs + " WHERE PROJECT_CODE = '" + lblCode.Text + "' ";
        qs = qs + " OR PROJECT_CODE = '" + lblCode1.Text + "' ";
        qs = qs + " ORDER BY      YR DESC";

        fldYear.DataSource = GetData(qs);
        fldYear.DataTextField = "YR";
        fldYear.DataValueField = "YR";
        fldYear.DataBind();
        fldYear.Items.Insert(0, new ListItem("-- ALL Years --", ""));
    }

    protected void bindCompany()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT UPPER(FLD_COMPANY) AS FLD_COMPANY ";
        qs = qs + " FROM          vwEDMSOutgoing ";
        qs = qs + " WHERE PROJECT_CODE = '" + lblCode.Text + "' ";
        qs = qs + " OR PROJECT_CODE = '" + lblCode1.Text + "' ";
        qs = qs + " ORDER BY      UPPER(FLD_COMPANY) ASC";

        fldCompany.DataSource = GetData(qs);
        fldCompany.DataTextField = "FLD_COMPANY";
        fldCompany.DataValueField = "FLD_COMPANY";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new ListItem("-- ALL Companies --", ""));
    }

    protected void bindOriginator()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT UPPER(ORIGINATOR) AS ORIGINATOR ";
        qs = qs + " FROM          vwEDMSOutgoing ";
        qs = qs + " WHERE PROJECT_CODE = '" + lblCode.Text + "' ";
        qs = qs + " OR PROJECT_CODE = '" + lblCode1.Text + "' ";
        qs = qs + " ORDER BY      UPPER(ORIGINATOR) ASC";

        fldOriginator.DataSource = GetData(qs);
        fldOriginator.DataTextField = "ORIGINATOR";
        fldOriginator.DataValueField = "ORIGINATOR";
        fldOriginator.DataBind();
        fldOriginator.Items.Insert(0, new ListItem("-- ALL Originator --", ""));
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        vwEDMSOutgoing.PROJECT_CODE, tblMain.EDMSCode, tblMain.EDMSCode1, tblMain.Description ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " INNER JOIN    vwEDMSOutgoing ON tblMain.EDMSCode collate SQL_Latin1_General_CP1_CI_AS = vwEDMSOutgoing.PROJECT_CODE collate SQL_Latin1_General_CP1_CI_AS ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

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

            //Project Name
            lblDescription.Text = row["Description"].ToString();
            lblCode.Text = row["EDMSCode"].ToString();
            lblCode1.Text = row["EDMSCode1"].ToString();
        }
    }



    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    private void bindProjectDoc()
    {
        String str;
        String sql_region;
        String sql_year;
        String sql_company;
        String sql_originator;

        if (fldRegion.SelectedIndex != 0)
        { sql_region = "AND (PROJECT_CODE = '" + fldRegion.SelectedValue + "') "; }
        else
        { sql_region = "AND 1=1 "; }

        if (fldYear.SelectedIndex != 0)
        { sql_year = "AND (YR = '" + fldYear.SelectedValue + "') "; }
        else
        { sql_year = "AND 1=1 "; }

        if (fldCompany.SelectedIndex != 0)
        { sql_company = "AND (FLD_COMPANY = '" + fldCompany.SelectedValue + "') "; }
        else
        { sql_company = "AND 1=1 "; }

        if (fldOriginator.SelectedIndex != 0)
        { sql_originator = "AND (ORIGINATOR = '" + fldOriginator.SelectedValue + "') "; }
        else
        { sql_originator = "AND 1=1 "; }

        if (fldSearch.Text.Trim() != "")
        {
            str = "SELECT     TOP 35 * "
            + "FROM           vwEDMSOutgoing "
            + "WHERE          (PROJECT_CODE = '" + lblCode.Text + "' OR PROJECT_CODE = '" + lblCode1.Text + "') "
            + "AND           (FLD_REFERENCE LIKE '%' + @search + '%' OR FLD_TITLE1 LIKE '%' + @search + '%' OR ORIGINATOR LIKE '%' + @search + '%') "
            + "" + sql_region + " "
            + "" + sql_year + " "
            + "" + sql_company + " " 
            + "" + sql_originator + " "
            + "ORDER BY       RIGHT(FLD_OUT_SERIAL,2) DESC, FLD_OUT_TRACK_NO DESC ";
        }
        else
        {
            str = "SELECT     TOP 35 * "
            + "FROM           vwEDMSOutgoing "
            + "WHERE          (PROJECT_CODE = '" + lblCode.Text + "' OR PROJECT_CODE = '" + lblCode1.Text + "') "
            + "" + sql_region + " "
            + "" + sql_year + " "
            + "" + sql_company + " "
            + "" + sql_originator + " "
            + "ORDER BY       RIGHT(FLD_OUT_SERIAL,2) DESC, FLD_OUT_TRACK_NO DESC ";
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
        gvProjectDoc.DataSource = ds;
        gvProjectDoc.DataBind();
        con.Close();

        for (int i = 0; i < gvProjectDoc.Rows.Count; i++)
        {
            GridViewRow row = gvProjectDoc.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "Beige");
                row.Cells[1].Style.Add("background-color", "Beige");
                row.Cells[2].Style.Add("background-color", "Beige");
                row.Cells[3].Style.Add("background-color", "Beige");
                row.Cells[4].Style.Add("background-color", "Beige");
                row.Cells[5].Style.Add("background-color", "Beige");
                row.Cells[6].Style.Add("background-color", "Beige");
                row.Cells[7].Style.Add("background-color", "Beige");
                row.Cells[8].Style.Add("background-color", "Beige");
            }
        }

    }

    protected void fldRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindProjectDoc();
    }

    protected void fldYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindProjectDoc();
    }

    protected void fldCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindProjectDoc();
    }

    protected void fldOriginator_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindProjectDoc();
    }

    protected void gvProjectDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (lblCode1.Text != "")
            {
                e.Row.Cells[2].Visible = true;

                if (lblCode1.Text.Substring(3) == "STR")
                {
                    e.Row.Cells[6].Visible = true;
                }
                else
                {
                    e.Row.Cells[6].Visible = false;
                }                
            }
            else
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[6].Visible = false;
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (lblCode1.Text != "")
            {
                e.Row.Cells[2].Visible = true;

                if (lblCode1.Text.Substring(3) == "STR")
                {
                    e.Row.Cells[6].Visible = true;
                }
                else
                {
                    e.Row.Cells[6].Visible = false;
                }
            }
            else
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[6].Visible = false;
            }

        }

    }

    protected void gvMonthlyUpdate_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvProjectDoc.PageIndex = e.NewPageIndex;
        this.bindProjectDoc();

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        fldSearch.Text = "";

        bindProjectDoc();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_Word = fldSearch.Text.Trim();

        btnClear.Visible = true;

        bindProjectDoc();
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