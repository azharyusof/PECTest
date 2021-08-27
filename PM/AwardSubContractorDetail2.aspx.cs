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

public partial class AwardSubContractorDetail2 : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String queryString = "";
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
            qs = "";
            qs = qs + " SELECT        tblMain.Code ";
            qs = qs + " FROM          tblMain ";
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
            }
            else
            {
                DataRow row = dt.Rows[0];

                //Project Code
                lblCode.Text = row["Code"].ToString();
            }

            bindTest();
            bindCerts();
            bind1();
        }
    }

    protected void bindTest()
    {
        // Bind data to the dropdownlist control.
        fldTest.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
    }

    private void bindCerts()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblCertificate "
            + "WHERE          DescriptionId = '70' "
            + "ORDER BY       Id DESC ";

        gvCerts.DataSource = GetData(str);
        gvCerts.DataBind();

        for (int i = 0; i < gvCerts.Rows.Count; i++)
        {
            GridViewRow row = gvCerts.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    private void bind1()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblCertificate "
            + "WHERE          DescriptionId = '70' "
            + "ORDER BY       Id DESC ";

        GridView1.DataSource = GetData(str);
        GridView1.DataBind();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
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