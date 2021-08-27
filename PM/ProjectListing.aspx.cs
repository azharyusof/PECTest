using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;

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

public partial class ProjectListing : System.Web.UI.Page
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

        btnClear.Visible = false;

        if (!Page.IsPostBack)
        {
            checkRole();
            //Bind dropdownlist
            bindStatus();
            GridViewBind();
            lblPM.Text = Session["UserID"].ToString();

        }
    }

    protected void bindStatus()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT UPPER(Status) AS Status ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " ORDER BY      Status ";

        fldStatus.DataSource = GetData(qs);
        fldStatus.DataTextField = "Status";
        fldStatus.DataValueField = "Status";
        fldStatus.DataBind();
        if (Request.QueryString["Mode"] != "O")
        {
            fldStatus.Items.Insert(2, new ListItem("MIGRATED PROJECT", "MIGRATED PROJECT"));
        }
            
    }

    protected void fldStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewBind();
    }

    protected void btnOpportunity_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewOpportunityRecord.aspx");
    }

    protected void btnProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewRegisterProject.aspx");
    }

    public void checkRole()
    {
        qs = "";
        qs = qs + " SELECT          StaffNo, Role ";
        qs = qs + " FROM            StaffLogin ";
        qs = qs + " WHERE           StaffNo = '" + Session["UserID"] + "' ";
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
            //No record
        }
        else
        {
            row = null;
            row = dt.Rows[0];

            //Session["UserID"] = row["StaffNo"].ToString();
            //Session["UserName"] = row["StaffName"].ToString();
            lblRole.Text = row["Role"].ToString();

            if (row["Role"].ToString() == "NormalUser")
            {
                btnProject.Visible = false;
                //gvProjectListing.Visible = false;
            }      
            else if (row["Role"].ToString() == "Risk" || row["Role"].ToString() == "Finance" || row["Role"].ToString() == "HSE" || row["Role"].ToString() == "Auditor" || row["Role"].ToString() == "QHSE" || row["Role"].ToString() == "ProjectFinance")
            {
                tblSearch.Visible = false;
                //btnOpportunity.Visible = false;
                //btnProject.Visible = false;
            }
            else
            {
                btnOpportunity.Visible = true;
                btnProject.Visible = true;
            }
           
        }
    }

    public void GridViewBind()
    {
        String str;
        String filter;
        String category;
        String sql_status;
                
        if (fldStatus.SelectedValue != "")
        {
            if (fldStatus.SelectedValue == "MIGRATED PROJECT")
            {
                sql_status = "AND (tblMain.ProjectDbMigrateStatus = 'Yes') ";
            }
            else
            {
                sql_status = "AND (tblMain.Status = '" + fldStatus.SelectedValue + "') ";
            }
        }
        else
        { sql_status = "AND 1=1 "; }

        if (lblRole.Text == "HSE" || lblRole.Text == "Auditor" || lblRole.Text == "QHSE" || lblRole.Text == "ProjectFacilitator")
        { filter = "(Category = 'Project') "; }
        else if (lblRole.Text == "BD")
        { filter = "(Category = 'Opportunity') "; }
        else if (lblRole.Text == "ProjectManager" || lblRole.Text == "HeadUnit" || lblRole.Text == "NormalUser")
        {
            filter = "(tblMain.ProjectManager = '" + Session["UserID"] + "'" +
                "OR tblProjectRecord.PIC1 = '" + Session["UserID"] + "'" +
                "OR tblProjectRecord.PIC2 = '" + Session["UserID"] + "'" +
                "OR tblOpportunityRecord.PIC1 = '" + Session["UserID"] + "'" +
                "OR tblOpportunityRecord.PIC2 = '" + Session["UserID"] + "'" +
                ") ";
        }        
        else
        { filter = "1=1 "; }

        if (Request.QueryString["Mode"] == "O")
        {
            category = "(Category = 'Opportunity' AND tblMain.Status = '" + fldStatus.SelectedValue + "') ";
        }
        else
        {
            category = "(Category = 'Project') ";
        }

        if (fldSearch.Text.Trim() != "")
        {
            str = "SELECT           DISTINCT tblMain.Id, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.Description, tblMain.Category, tblMain.ClientId, tblMain.ProjectManager, tblMain.Status, tblMain.StatusRemarks, tblMain.Phase, tblMain.CreatedBy, tblMain.DateCreated, tblMain.ModifyBy, StaffLogin.StaffName AS PMName, tblClient.ClientName, tblProjectRecord.PIC1 AS ProjectPIC1, tblProjectRecord.PIC2 AS ProjectPIC2, tblOpportunityRecord.PIC1 AS OpportunityPIC1, tblOpportunityRecord.PIC2 AS OpportunityPIC2, tblOpportunityGoNoGo.Decision, tblMain.ProjectCode, tblMain.Code, tblMain.OldCode, tblMain.ProjectDbMigrateStatus, tblProjectRecord.BtnSubmit "
                  + "FROM           tblMain "
                  + "INNER JOIN     tblClient ON tblMain.ClientId = tblClient.Id "
                  + "LEFT OUTER JOIN     tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId "
                  + "LEFT OUTER JOIN     tblOpportunityRecord ON tblMain.Id = tblOpportunityRecord.DescriptionId "
                  + "LEFT OUTER JOIN     tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId "
                  + "LEFT OUTER JOIN     StaffLogin ON tblMain.ProjectManager COLLATE SQL_Latin1_General_CP1_CI_AS = StaffLogin.StaffNo "
                  + "WHERE          (tblMain.OperatingCompany LIKE '%' + @search + '%' OR tblMain.Description LIKE '%' + @search + '%' OR tblClient.ClientName LIKE '%' + @search + '%' OR StaffLogin.StaffName LIKE '%' + @search + '%' OR tblMain.Status LIKE '%' + @search + '%' OR tblMain.Phase LIKE '%' + @search + '%' OR tblMain.StatusRemarks LIKE '%' + @search + '%') "
                  + "AND " + filter + ""
                  + "AND " + category + ""
                  + "" + sql_status + " "
                  + "ORDER BY       tblMain.DateCreated DESC ";
        }
        else
        {
            str = "SELECT           DISTINCT tblMain.Id, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.Description, tblMain.Category, tblMain.ClientId, tblMain.ProjectManager, tblMain.Status, tblMain.StatusRemarks, tblMain.Phase, tblMain.CreatedBy, tblMain.DateCreated, tblMain.ModifyBy, StaffLogin.StaffName AS PMName, tblClient.ClientName, tblProjectRecord.PIC1 AS ProjectPIC1, tblProjectRecord.PIC2 AS ProjectPIC2, tblOpportunityRecord.PIC1 AS OpportunityPIC1, tblOpportunityRecord.PIC2 AS OpportunityPIC2, tblOpportunityGoNoGo.Decision, tblMain.ProjectCode, tblMain.Code, tblMain.OldCode, tblMain.ProjectDbMigrateStatus, tblProjectRecord.BtnSubmit "
                  + "FROM           tblMain "
                  + "INNER JOIN     tblClient ON tblMain.ClientId = tblClient.Id "
                  + "LEFT OUTER JOIN     tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId "
                  + "LEFT OUTER JOIN     tblOpportunityRecord ON tblMain.Id = tblOpportunityRecord.DescriptionId "
                  + "LEFT OUTER JOIN     tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId "
                  + "LEFT OUTER JOIN     StaffLogin ON tblMain.ProjectManager COLLATE SQL_Latin1_General_CP1_CI_AS = StaffLogin.StaffNo "
                  + "WHERE " + filter + ""
                  + "AND " + category + ""
                  + "" + sql_status + " "
                  + "ORDER BY       tblMain.DateCreated DESC ";
        }
        
        SqlCommand xp = new SqlCommand(str, con);

        xp.Parameters.AddWithValue("@search", ((object)fldSearch.Text.Trim()) ?? DBNull.Value);

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


    protected void btnClear_Click(object sender, EventArgs e)
    {
        fldSearch.Text = "";
        
        GridViewBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_Word = fldSearch.Text.Trim();

        btnClear.Visible = true;
        
        GridViewBind();
    }
    
    protected void gvProjectListing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var Link = (HyperLink)e.Row.FindControl("hlDescription");
            var LinkRO = (HyperLink)e.Row.FindControl("hlDescriptionRO"); //Read Only
            var LinkHSE = (HyperLink)e.Row.FindControl("hlDescriptionHSE"); //HSE
            var LinkAuditor = (HyperLink)e.Row.FindControl("hlDescriptionAuditor"); //Auditor
            var LinkPC = (HyperLink)e.Row.FindControl("hlDescriptionPC"); //PC
            var LinkProjectDB = (HyperLink)e.Row.FindControl("hlDescriptionProjectDB"); //PC

            Label Id = e.Row.FindControl("lblId") as Label;
            Label Phase = e.Row.FindControl("lblPhase") as Label;

            Label Description = e.Row.FindControl("lblDescription") as Label;
            Label ProjectManager = e.Row.FindControl("lblProjectManager") as Label;
            Label CreatedBy = e.Row.FindControl("lblCreatedBy") as Label;
            Label ProjectPIC1 = e.Row.FindControl("lblProjectPIC1") as Label;
            Label ProjectPIC2 = e.Row.FindControl("lblProjectPIC2") as Label;
            Label OpportunityPIC1 = e.Row.FindControl("lblOpportunityPIC1") as Label;
            Label OpportunityPIC2 = e.Row.FindControl("lblOpportunityPIC2") as Label;
            Label Category = e.Row.FindControl("lblCategory") as Label;

            Label RCode = e.Row.FindControl("lblRCode") as Label;
            Label PCode = e.Row.FindControl("lblPCode") as Label;
            Label Code = e.Row.FindControl("lblCode") as Label;
            Label DeltekCode = e.Row.FindControl("lblDeltekCode") as Label;
            Label Decision = e.Row.FindControl("lblDecision") as Label;
            Label Migration = e.Row.FindControl("lblMigration") as Label;
            Label SubmitStatus = e.Row.FindControl("lblSubmitStatus") as Label;
                        
                if (lblRole.Text == "Risk" || lblRole.Text == "Finance" || lblRole.Text == "QHSE" || lblRole.Text == "ProjectFinance")
                {
                    LinkPC.Visible = false;
                    LinkHSE.Visible = false;
                    LinkAuditor.Visible = false;
                    LinkProjectDB.Visible = false;

                    //Read Only Link
                    if (Phase.Text == "OPPORTUNITY RECORD")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "OpportunityRecordDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "OPPORTUNITY GO / NO-GO")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "OpportunityGoNoGoDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROPOSAL EVALUATION / SUBMISSION")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "ProposalEvaluationDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROPOSAL CLOSE")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "ProposalCloseDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "REGISTER NEW PROJECT")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "RegisterProjectDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROJECT INITIATION")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "ProjectInitiationDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROJECT EXECUTION")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "ProjectMonthlyUpdateDetailView.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROJECT CLOSE")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = true;
                        LinkRO.NavigateUrl = "ProjectClosingDetailView.aspx?Id=" + Id.Text;
                    }
                }
                else if (lblRole.Text == "ProjectCoordinator" || lblRole.Text == "HeadDivision" || lblRole.Text == "ProjectFacilitator")
                {
                    LinkRO.Visible = false;
                    LinkHSE.Visible = false;
                    LinkAuditor.Visible = false;
                    LinkProjectDB.Visible = false;

                    if (Phase.Text == "OPPORTUNITY RECORD")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "OpportunityRecordDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "OPPORTUNITY GO / NO-GO")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "OpportunityGoNoGoDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROPOSAL EVALUATION / SUBMISSION")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "ProposalEvaluationDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROPOSAL CLOSE")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "ProposalCloseDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "REGISTER NEW PROJECT")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "RegisterProjectDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROJECT INITIATION")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "ProjectInitiationDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROJECT EXECUTION")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "ProjectMonthlyUpdateDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "PROJECT CLOSE")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkPC.Visible = true;
                        LinkPC.NavigateUrl = "ProjectClosingDetail.aspx?Id=" + Id.Text;
                    }
                    else if (Phase.Text == "MIGRATION IN PROGRESS")
                    {
                        Description.Visible = false;
                        Link.Visible = true;
                        LinkPC.Visible = false; 
                        Phase.ForeColor = System.Drawing.Color.Red;
                        Link.NavigateUrl = "UpdateProjectDb.aspx?Id=" + Id.Text + "&mode=1";
                    }
                }
                else if (lblRole.Text == "HSE")
                {
                    LinkRO.Visible = false;
                    LinkPC.Visible = false;
                    LinkAuditor.Visible = false;
                    LinkProjectDB.Visible = false;

                    if (Phase.Text == "REGISTER NEW PROJECT" || Phase.Text == "PROJECT INITIATION" || Phase.Text == "PROJECT EXECUTION" || Phase.Text == "PROJECT CLOSE")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = false;
                        LinkHSE.Visible = true;
                        LinkHSE.NavigateUrl = "SiteVisitHSELegalDetailViewHSE.aspx?Id=" + Id.Text;
                    }
                }
                else if (lblRole.Text == "Auditor")
                {
                    LinkRO.Visible = false;
                    LinkPC.Visible = false;
                    LinkHSE.Visible = false;
                    LinkProjectDB.Visible = false;

                    if (Phase.Text == "REGISTER NEW PROJECT" || Phase.Text == "PROJECT INITIATION" || Phase.Text == "PROJECT EXECUTION" || Phase.Text == "PROJECT CLOSE")
                    {
                        Description.Visible = false;
                        Link.Visible = false;
                        LinkRO.Visible = false;
                        LinkAuditor.Visible = true;
                        LinkAuditor.NavigateUrl = "AuditTrailAuditor.aspx?Id=" + Id.Text;
                    }
                }
                else
                {
                    LinkHSE.Visible = false;
                    LinkAuditor.Visible = false;
                    LinkPC.Visible = false;
                    LinkProjectDB.Visible = false;

                    if (lblAdmin.Text == Session["UserID"].ToString() || lblAdmin1.Text == Session["UserID"].ToString() || lblAdmin2.Text == Session["UserID"].ToString() || lblAdmin3.Text == Session["UserID"].ToString() || lblAdmin4.Text == Session["UserID"].ToString() || lblAdmin5.Text == Session["UserID"].ToString() || lblAdmin6.Text == Session["UserID"].ToString() || lblAdmin7.Text == Session["UserID"].ToString())
                    {
                        Description.Visible = false;
                        Link.Visible = true;
                        LinkRO.Visible = false;
                    }
                    else if (lblBD.Text == Session["UserID"].ToString() || lblBD1.Text == Session["UserID"].ToString() || lblBD2.Text == Session["UserID"].ToString())
                    {
                        if (Category.Text == "OPPORTUNITY")
                        {
                            Description.Visible = false;
                            Link.Visible = true;
                            LinkRO.Visible = false;
                        }
                        else if (Category.Text == "PROJECT")
                        {
                            Description.Visible = true;
                            Link.Visible = false;
                            LinkRO.Visible = false;
                        }
                    }
                    else
                    {
                        if (ProjectManager.Text == Session["UserID"].ToString() || CreatedBy.Text == Session["UserID"].ToString() || ProjectPIC1.Text == Session["UserID"].ToString() || ProjectPIC2.Text == Session["UserID"].ToString() || OpportunityPIC1.Text == Session["UserID"].ToString() || OpportunityPIC2.Text == Session["UserID"].ToString())
                        {
                            Description.Visible = false;
                            Link.Visible = true;
                            LinkRO.Visible = false;
                        }
                        else if (ProjectManager.Text != Session["UserID"].ToString() || CreatedBy.Text != Session["UserID"].ToString() || ProjectPIC1.Text != Session["UserID"].ToString() || ProjectPIC2.Text != Session["UserID"].ToString() || OpportunityPIC1.Text != Session["UserID"].ToString() || OpportunityPIC2.Text != Session["UserID"].ToString())
                        {
                            Description.Visible = true;
                            Link.Visible = false;
                            LinkRO.Visible = false;
                        }
                    }
                }

                //Normal Link
                if (Phase.Text == "OPPORTUNITY RECORD")
                {
                    Link.NavigateUrl = "OpportunityRecordDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "OPPORTUNITY GO / NO-GO")
                {
                    Link.NavigateUrl = "OpportunityGoNoGoDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "PROPOSAL EVALUATION / SUBMISSION")
                {
                    Link.NavigateUrl = "ProposalEvaluationDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "PROPOSAL CLOSE")
                {
                    Link.NavigateUrl = "ProposalCloseDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "REGISTER NEW PROJECT")
                {
                    Link.NavigateUrl = "RegisterProjectDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "PROJECT INITIATION")
                {
                    Link.NavigateUrl = "ProjectInitiationDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "PROJECT EXECUTION")
                {
                    Link.NavigateUrl = "ProjectMonthlyUpdateDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "PROJECT CLOSE")
                {
                    Link.NavigateUrl = "ProjectClosingDetail.aspx?Id=" + Id.Text;
                }
                else if (Phase.Text == "MIGRATION IN PROGRESS")
                {
                    Phase.ForeColor = System.Drawing.Color.Red; 
                    Link.NavigateUrl = "UpdateProjectDb.aspx?Id=" + Id.Text + "&mode=1";
                }

            //}


            if (RCode.Text != "")
            {
                Code.Text = RCode.Text;
            }
            else if (PCode.Text != "")
            {
                Code.Text = PCode.Text;
            }
            else
            {
                Code.Text = "-";
            }

            if (DeltekCode.Text != "")
            {
                DeltekCode.Visible = true;
            }

            Label AppStatus = e.Row.FindControl("lblAppStatus") as Label;
            string OutId = gvProjectListing.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView gvApprovalStatus = e.Row.FindControl("gvApprovalStatus") as GridView;

            var dataSource1 = GetData(string.Format("select ApprovalStatus from vwApprovalStatus where Phase = '"+ Phase.Text + "' and DescriptionId='{0}'", OutId));

            int count1 = dataSource1.Rows.Count;
            if (count1 > 0)
            {
                if (Decision.Text == "NO-GO")
                {
                    AppStatus.Text = "NO-GO";
                    AppStatus.ForeColor = Color.Red;
                }
                else
                {
                    gvApprovalStatus.DataSource = GetData(string.Format("select ApprovalStatus from vwApprovalStatus where Phase = '" + Phase.Text + "' and DescriptionId='{0}'", OutId));
                    gvApprovalStatus.DataBind();
                    AppStatus.Visible = false;
                }
            }
            else
            {
                if (Decision.Text == "NO-GO")
                {
                    AppStatus.Text = "NO-GO";
                    AppStatus.ForeColor = Color.Red;
                }
                else
                {
                    AppStatus.Visible = true;
                    AppStatus.Text = "N/A";
                }
            }
        }
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