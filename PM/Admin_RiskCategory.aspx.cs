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

public partial class Admin_RiskCategory : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

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
            bindRiskCategory();
        }
    }

    public void bindRiskCategory()
    {
        String str;

        str = "";
        str = str + " SELECT        * ";
        str = str + " FROM          tblRiskCategory ";
        str = str + " ORDER BY      RiskCategory ";

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvRiskCategory.DataSource = ds;
        gvRiskCategory.DataBind();
        con.Close();

        for (int i = 0; i < gvRiskCategory.Rows.Count; i++)
        {
            GridViewRow row = gvRiskCategory.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
            }
        }
    }


    protected void AddNewRow(object sender, EventArgs e)
    {
        string RiskCategory = ((TextBox)gvRiskCategory.FooterRow.FindControl("fldRiskCategory")).Text;

        if (!String.IsNullOrEmpty(RiskCategory))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO tblRiskCategory (RiskCategory) VALUES (@pRiskCategory)", con);

            cmd.Parameters.AddWithValue("@pRiskCategory", SqlDbType.VarChar).Value = RiskCategory.Trim();

            cmd.ExecuteNonQuery();

            con.Close();

            bindRiskCategory();
        }

        else
        {
            lblMsg.Visible = true;
            lblNote.Visible = false;
        }
    }


    protected void DeleteRow(object sender, EventArgs e)
    {
        //LinkButton lnkRemove = (LinkButton)sender;
        ImageButton imgDelete = (ImageButton)sender;

        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblRiskCategory WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();
        con.Close();

        bindRiskCategory();
    }

    protected void EditRiskCategory(object sender, GridViewEditEventArgs e)
    {
        gvRiskCategory.EditIndex = e.NewEditIndex;
        bindRiskCategory();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRiskCategory.EditIndex = -1;
        bindRiskCategory();
    }

    protected void UpdateRiskCategory(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvRiskCategory.Rows[e.RowIndex].FindControl("lblID")).Text;
        string RiskCategory = ((TextBox)gvRiskCategory.Rows[e.RowIndex].FindControl("fldRiskCategory")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblRiskCategory SET RiskCategory=@pRiskCategory WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pRiskCategory", SqlDbType.VarChar).Value = RiskCategory;

        cmd.ExecuteNonQuery();

        gvRiskCategory.EditIndex = -1;

        bindRiskCategory();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }


        //Insert details in tblRiskCategory
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblRiskCategory (RiskCategory) VALUES ('" + fldRiskCategory.Text + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        bindRiskCategory();

        fldRiskCategory.Text = "";
    }

    protected void btnClose_Click(object sender, EventArgs e)
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