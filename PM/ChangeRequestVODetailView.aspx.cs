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

public partial class ChangeRequestVODetailView : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();

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
            bindChangeRequest();

            bindDetails();

            btnChange.Enabled = false;
        }
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblChangeRequestVO.*, tblMain.ProjectCode ";
        qs = qs + " FROM          tblChangeRequestVO ";
        qs = qs + " INNER JOIN          tblMain ON tblChangeRequestVO.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblChangeRequestVO.DescriptionId = '" + Request.QueryString["Id"] + "' ";
        
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

    public void bindChangeRequest()
    {
        String str;

        str = "";
        str = str + " SELECT        * ";
        str = str + " FROM          tblChangeRequestVO ";
        str = str + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' AND VariationType IS NOT NULL ";
        str = str + " ORDER BY      VariationType ";

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvChangeRequestVO.DataSource = ds;
        gvChangeRequestVO.DataBind();
        con.Close();

        for (int i = 0; i < gvChangeRequestVO.Rows.Count; i++)
        {
            GridViewRow row = gvChangeRequestVO.Rows[i];

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
            }
        }
    }

    protected void gvChangeRequestVO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            //Supporting Documents
            string OutId = gvChangeRequestVO.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView GridViewAttachment = e.Row.FindControl("GridViewAttachment") as GridView;

            Label attachment = e.Row.FindControl("lblAttachment") as Label;
            var dataSource1 = GetData(string.Format("select * from tblChangeRequestDocument where DescriptionId='" + Request.QueryString["Id"] + "' and ChangeRequestId='{0}'", OutId));

            int count1 = dataSource1.Rows.Count;
            if (count1 > 0)
            {
                GridViewAttachment.DataSource = GetData(string.Format("select * from tblChangeRequestDocument where DescriptionId='" + Request.QueryString["Id"] + "' and ChangeRequestId='{0}'", OutId));
                GridViewAttachment.DataBind();
                attachment.Visible = false;
            }
            else
            {
                attachment.Visible = true;
                attachment.Text = "-";
            }
        }
    }

    protected void gvChangeRequestVO_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChangeRequestVO.PageIndex = e.NewPageIndex;
        this.bindChangeRequest();
    }
    
    protected void btnChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateChangeRequestVO.aspx?Id=" + Request.QueryString["Id"]);
    }
        
    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    public DataTable GetData(string queryString)
    {
        // Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
        DataTable ds = new DataTable();

        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }

}