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

public partial class Admin_EDMS : System.Web.UI.Page
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
            bindEDMS();
        }            
    }

    public void bindEDMS()
    {
        String str;
                    
            str = "";
            str = str + " SELECT        * ";
            str = str + " FROM          vwProjectEDMS ";
            str = str + " ORDER BY      Description ";
                    
            SqlCommand xp = new SqlCommand(str, con);

            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvEDMS.DataSource = ds;
            gvEDMS.DataBind();
            con.Close();

            for (int i = 0; i < gvEDMS.Rows.Count; i++)
            {
                GridViewRow row = gvEDMS.Rows[i];

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