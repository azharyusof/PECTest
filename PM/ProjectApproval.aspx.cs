using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class ProjectApproval : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
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
            countDAL3_2();
            countDAL3_3();
            countDAL3_2a();
            countDAL3_4();

        }
    }

    protected void countDAL3_2()
    {
        qs = "";
        qs = qs + " SELECT        COUNT(Id) AS Total  ";
        qs = qs + " FROM          vwPendingApproval ";
        qs = qs + " WHERE         Phase = 'Opportunity Go / No-Go' ";
        qs = qs + " AND           OpportunityDAL = '" + Session["UserID"].ToString() + "' ";
        qs = qs + " AND           ApprovalStatus IN ('Pending DAL 3.2 Approval', 'Pending Approval') ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
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

            lblTotalOppGoNoGo1.Text = row["Total"].ToString();

            if (row["Total"].ToString() == "0")
            {
                btnApprove3_2.Visible = false;
            }
            else
            {
                btnApprove3_2.Visible = true;
            }
        }
    }

    protected void countDAL3_3()
    {
        qs = "";
        qs = qs + " SELECT        COUNT(Id) AS Total  ";
        qs = qs + " FROM          vwPendingApproval ";
        qs = qs + " WHERE         Phase = 'Opportunity Go / No-Go' ";
        qs = qs + " AND           OpportunityDALCost = '" + Session["UserID"].ToString() + "' ";
        qs = qs + " AND           ApprovalStatus IN ('Pending DAL 3.3 Approval', 'Pending Approval') ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
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

            lblTotalOppGoNoGo2.Text = row["Total"].ToString();

            if (row["Total"].ToString() == "0")
            {
                btnApprove3_3.Visible = false;
            }
            else
            {
                btnApprove3_3.Visible = true;
            }
        }
    }

    protected void countDAL3_2a()
    {
        qs = "";
        qs = qs + " SELECT        COUNT(Id) AS Total  ";
        qs = qs + " FROM          vwPendingApproval ";
        qs = qs + " WHERE         Phase = 'Proposal Evaluation / Submission' ";
        qs = qs + " AND           ProposalDAL = '" + Session["UserID"].ToString() + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
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

            lblTotEvaluate.Text = row["Total"].ToString();

            if (row["Total"].ToString() == "0")
            {
                btnApprove3_2a.Visible = false;
            }
            else
            {
                btnApprove3_2a.Visible = true;
            }
        }
    }

    protected void countDAL3_4()
    {
        qs = "";
        qs = qs + " SELECT        COUNT(Id) AS Total  ";
        qs = qs + " FROM          vwPendingApproval ";
        qs = qs + " WHERE         Phase = 'Register New Project' ";
        qs = qs + " AND           (ProjectDAL = '" + Session["UserID"].ToString() + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
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

            lblTotRegProject.Text = row["Total"].ToString();

            if (row["Total"].ToString() == "0")
            {
                btnApprove3_4.Visible = false;
            }
            else
            {
                btnApprove3_4.Visible = true;
            }
        }
    }

    protected void btnApprove3_2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectApprovalList.aspx?DAL=3_2");
    }

    protected void btnApprove3_3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectApprovalList.aspx?DAL=3_3");
    }

    protected void btnApprove3_4_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectApprovalList.aspx?DAL=3_4");
    }

    protected void btnApprove3_2a_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectApprovalList.aspx?DAL=3_2a");
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