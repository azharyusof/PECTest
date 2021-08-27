using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
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

public partial class ProjectApprovalList : System.Web.UI.Page
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
            GridViewBind();

            if (Request.QueryString["DAL"] == "3_2")
            {
                lblPhaseName.Text = "OPPORTUNITY GO / NO-GO";
                lblDAL.Text = "DAL 3.2 &nbsp; <i>[Submission of Tender Bids / Proposals / Quotations]</i>";
            }
            else if (Request.QueryString["DAL"] == "3_3")
            {
                lblPhaseName.Text = "OPPORTUNITY GO / NO-GO";
                lblDAL.Text = "DAL 3.3 &nbsp; <i>[Cost of Preparing Proposal / Tender]</i>";
            }
            else if (Request.QueryString["DAL"] == "3_2a")
            {
                lblPhaseName.Text = "PROPOSAL EVALUATION / SUBMISSION";
                lblDAL.Text = "DAL 3.2 &nbsp; <i>[Submission of Tender Bids / Proposals / Quotations]</i>";
            }
            else if (Request.QueryString["DAL"] == "3_4")
            {
                lblPhaseName.Text = "REGISTER NEW PROJECT";
                lblDAL.Text = "DAL 3.4 &nbsp; <i>[Acceptance of Award Contract]</i>";
            }

        }
    }
        

    public void GridViewBind()
    {
        String str;
        
        if (Request.QueryString["DAL"] == "3_2")
        {
            str = "SELECT           * "
                  + "FROM           vwPendingApproval "
                  + "WHERE          OpportunityDAL = '" + Session["UserID"].ToString() + "' "
                  + "AND            Phase = 'Opportunity Go / No-Go' "
                  + "AND            ApprovalStatus IN ('Pending DAL 3.2 Approval','Pending Approval') ";
        }
        else if (Request.QueryString["DAL"] == "3_3")
        {
            str = "SELECT           * "
                  + "FROM           vwPendingApproval "
                  + "WHERE          OpportunityDALCost = '" + Session["UserID"].ToString() + "' "
                  + "AND            Phase = 'Opportunity Go / No-Go' "
                  + "AND            ApprovalStatus IN ('Pending DAL 3.3 Approval','Pending Approval') ";
        }
        else if (Request.QueryString["DAL"] == "3_2a")
        {
            str = "SELECT           * "
                  + "FROM           vwPendingApproval "
                  + "WHERE          ProposalDAL = '" + Session["UserID"].ToString() + "' "
                  + "AND            Phase = 'Proposal Evaluation / Submission' ";
        }
        else if (Request.QueryString["DAL"] == "3_4")
        {
            str = "SELECT           * "
                  + "FROM           vwPendingApproval "
                  + "WHERE          ProjectDAL = '" + Session["UserID"].ToString() + "' "
                  + "AND            Phase = 'Register New Project' ";
        }
        else
        {
            str = "SELECT           * "
                  + "FROM           vwPendingApproval ";
        }

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvProjectListing.DataSource = ds;
        gvProjectListing.DataBind();
        con.Close();

        for (int i = 0; i < gvProjectListing.Rows.Count; i++)
        {
            GridViewRow row = gvProjectListing.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFFFE0");
                row.Cells[1].Style.Add("background-color", "#FFFFE0");
                row.Cells[2].Style.Add("background-color", "#FFFFE0");
                row.Cells[3].Style.Add("background-color", "#FFFFE0");
                row.Cells[4].Style.Add("background-color", "#FFFFE0");
                row.Cells[5].Style.Add("background-color", "#FFFFE0");
                row.Cells[6].Style.Add("background-color", "#FFFFE0");
                row.Cells[7].Style.Add("background-color", "#FFFFE0");
            }
        }
    }

      
    protected void gvProjectListing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var Link = (HyperLink)e.Row.FindControl("hlDescription");
            
            Label Id = e.Row.FindControl("lblId") as Label;
            Label Phase = e.Row.FindControl("lblPhase") as Label;
            Label AppStatus = e.Row.FindControl("lblAppStatus") as Label;

            if (Request.QueryString["DAL"] == "3_2")
            {
                Link.NavigateUrl = "ApprovalOpportunityGoNoGo_DAL.aspx?Id=" + Id.Text + "&mode=int&DAL=" + Request.QueryString["DAL"];
            }
            else if (Request.QueryString["DAL"] == "3_3")
            {
                Link.NavigateUrl = "ApprovalOpportunityGoNoGo_DALCost.aspx?Id=" + Id.Text + "&mode=int&DAL=" + Request.QueryString["DAL"];
            }
            else if (Request.QueryString["DAL"] == "3_2a")
            {
                Link.NavigateUrl = "ApprovalSignedProposal_DAL.aspx?Id=" + Id.Text + "&mode=int&DAL=" + Request.QueryString["DAL"];
            }
            else if (Request.QueryString["DAL"] == "3_4")
            {
                Link.NavigateUrl = "ApprovalRegisterProject_DAL.aspx?Id=" + Id.Text + "&mode=int&DAL=" + Request.QueryString["DAL"];
            }

            string OutId = gvProjectListing.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView gvApprovalStatus = e.Row.FindControl("gvApprovalStatus") as GridView;

            var dataSource1 = GetData(string.Format("select ApprovalStatus from vwApprovalStatus where Phase = '" + Phase.Text + "' and DescriptionId='{0}'", OutId));

            int count1 = dataSource1.Rows.Count;
            if (count1 > 0)
            {
                gvApprovalStatus.DataSource = GetData(string.Format("select ApprovalStatus from vwApprovalStatus where Phase = '" + Phase.Text + "' and DescriptionId='{0}'", OutId));
                gvApprovalStatus.DataBind();
                AppStatus.Visible = false;
            }
            else
            {
                AppStatus.Visible = true;
                AppStatus.Text = "N/A";
            }

        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectApproval.aspx");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
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