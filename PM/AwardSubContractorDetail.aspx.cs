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

public partial class AwardSubContractorDetail : System.Web.UI.Page
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
            //qs = "";
            //qs = qs + " SELECT        tblMain.Code ";
            //qs = qs + " FROM          tblMain ";
            //qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

            qs = "";
            qs = qs + " SELECT        tblNonConformance.*, tblMain.Code ";
            qs = qs + " FROM          tblNonConformance ";
            qs = qs + " INNER JOIN          tblMain ON tblNonConformance.DescriptionId = tblMain.Id ";
            qs = qs + " WHERE         tblNonConformance.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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
                lblCode.Text = row["Code"].ToString();
            }
        }
    }
}