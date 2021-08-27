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
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Security;

public partial class ProjectDbStatus : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    String qs = "";
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
            bindGeneric();

        }
    }

    public void bindGeneric()
    {
        String str;

        str = "SELECT * FROM tblProjectStatus WHERE Id='" + Request.QueryString["Id"] +"' order by SubId desc ";
               
        SqlCommand xp = new SqlCommand(str, con);


        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvGeneric.DataSource = ds;
        gvGeneric.DataBind();
        con.Close();

        for (int i = 0; i < gvGeneric.Rows.Count; i++)
        {
            GridViewRow row = gvGeneric.Rows[i];

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

    protected void gvProjectListing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        //For Each cell As TableCell In e.Row.Cells
    //    //cell.Text = Server.HtmlDecode(cell.Text)
    ////Next

    //    //e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text);
    //    }

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    for (int j = 0; j < e.Row.Cells.Count; j++)
        //    {
        //        string encoded = e.Row.Cells[j].Text;
        //        e.Row.Cells[j].Text = Context.Server.HtmlDecode(encoded);
        //    }

        //}

    }


    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectDatabase.aspx");
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