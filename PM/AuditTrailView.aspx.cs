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

public partial class AuditTrailView : System.Web.UI.Page
{
    DataRow row = null;
    DataRow row1 = null;
    String qs = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            bindAuditTrail();
            bindDetails();

            btnTrail.Enabled = false;
        }
    }
    
    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblAuditTrail.*, tblMain.ProjectCode ";
        qs = qs + " FROM          tblAuditTrail ";
        qs = qs + " INNER JOIN          tblMain ON tblAuditTrail.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblAuditTrail.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

    protected void btnTrail_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateAuditTrail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    private void bindAuditTrail()
    {
        String str;

        str = "SELECT         tblAuditTrail.*, "
            + "               tblCREATEBY.StaffName As AuditorName "
            + "FROM           tblAuditTrail "            
            + "LEFT JOIN      StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblAuditTrail.Auditor COLLATE DATABASE_DEFAULT "
            + "WHERE          tblAuditTrail.DescriptionId = '" + Request.QueryString["ID"] + "' AND (tblCREATEBY.Role IN ('Auditor')) "
            + "ORDER BY       tblAuditTrail.Id DESC ";

        gvAuditTrail.DataSource = GetData(str);
        gvAuditTrail.DataBind();

        for (int i = 0; i < gvAuditTrail.Rows.Count; i++)
        {
            GridViewRow row = gvAuditTrail.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                row.Cells[6].Style.Add("background-color", "#FFECEC");
                row.Cells[7].Style.Add("background-color", "#FFECEC");
                row.Cells[8].Style.Add("background-color", "#FFECEC");
                row.Cells[9].Style.Add("background-color", "#FFECEC");
                row.Cells[10].Style.Add("background-color", "#FFECEC");
                row.Cells[11].Style.Add("background-color", "#FFECEC");
                row.Cells[12].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void gvAuditTrail_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvAuditTrail.PageIndex = e.NewPageIndex;
        this.bindAuditTrail();

    }

    protected void gvAuditTrail_RowDataBound(object sender, GridViewRowEventArgs e)
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