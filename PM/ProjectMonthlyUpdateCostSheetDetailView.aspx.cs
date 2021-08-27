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

public partial class ProjectMonthlyUpdateCostSheetDetailView : System.Web.UI.Page
{
    DataRow row = null;
    DataRow row1 = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Session["UserID"] == null)
            {
                Response.Redirect("../Default.aspx", true);
            }

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            bindDetails();
        }
    }


    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        ProjectCode ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " WHERE         Id = '" + Request.QueryString["Id"] + "' ";

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
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();
        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
    }
}