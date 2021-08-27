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

public partial class ApprovalOpportunityGoNoGo_DAL : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    String qs = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["mode"] == "int")
            {
                btnClose.Visible = false;
                btnListing.Visible = true;
            }
            else
            {
                btnClose.Visible = true;
                btnListing.Visible = false;
            }

            //Hide all upload
            dvUpA1Sec.Visible = true;
            dvVwA1Sec.Visible = false;

            //Display opportunity details 
            qs = "";
            qs = qs + " SELECT        tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.ClientId, StaffLogin.StaffName AS PMName, tblClient.ClientName ";
            qs = qs + " FROM          tblMain ";
            qs = qs + " INNER JOIN    tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + " INNER JOIN    StaffLogin ON tblMain.ProjectManager COLLATE SQL_Latin1_General_CP1_CI_AS = StaffLogin.StaffNo ";
            qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";
            
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();

            if (dt1.Rows.Count == 0)
            {
                //Check for empty record.
            }
            else
            {
                DataRow row = dt1.Rows[0];

                //Opportunity Name
                lblDescription.Text = row["Description"].ToString().ToUpper();

                //Operating Company
                lblCompany.Text = row["OperatingCompany"].ToString().ToUpper();

                //Project Manager
                lblPM.Text = row["PMName"].ToString().ToUpper();

                //Client Name
                lblClientName.Text = row["ClientName"].ToString().ToUpper();
            }

            //Bind dropdownlist
            bindStrategicClient();
            bindStatusRel();
            bindPymntHistory();
            bindCanCompete();
            bindOurCapability();
            bindTrackRecord();
            bindPartnerReq();
            bindDesicion();
            bindContractType();
            bindProjectRisk();
            bindContractRisk();
            bindEvaluationCommittee();

            bindDetails();
        }
    }

    protected void bindStrategicClient()
    {
        // Bind data to the dropdownlist control.
        fldStrategicClient.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldStrategicClient.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldStrategicClient.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindCanCompete()
    {
        // Bind data to the dropdownlist control.
        fldCanCompete.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldCanCompete.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldCanCompete.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindStatusRel()
    {
        // Bind data to the dropdownlist control.
        fldStatusRel.Items.Insert(0, new ListItem("-- Select Status of Relationship --", ""));
        fldStatusRel.Items.Insert(1, new ListItem("First Time", "First Time"));
        fldStatusRel.Items.Insert(2, new ListItem("Transactional", "Transactional"));
        fldStatusRel.Items.Insert(3, new ListItem("Key Client", "Key Client"));
    }

    protected void bindPymntHistory()
    {
        // Bind data to the dropdownlist control.
        fldPymntHistory.Items.Insert(0, new ListItem("-- Select Payment History --", ""));
        fldPymntHistory.Items.Insert(1, new ListItem("30 Days", "30 Days"));
        fldPymntHistory.Items.Insert(2, new ListItem("60 Days", "60 Days"));
        fldPymntHistory.Items.Insert(3, new ListItem("90 Days", "90 Days"));
        fldPymntHistory.Items.Insert(4, new ListItem("Beyond 90 Days", "Beyond 90 Days"));
        fldPymntHistory.Items.Insert(5, new ListItem("N/A", "N/A"));
    }

    protected void bindOurCapability()
    {
        // Bind data to the dropdownlist control.
        fldOurCapability.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldOurCapability.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldOurCapability.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindTrackRecord()
    {
        // Bind data to the dropdownlist control.
        fldTrackRecord.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldTrackRecord.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldTrackRecord.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindPartnerReq()
    {
        // Bind data to the dropdownlist control.
        fldPartnerReq.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldPartnerReq.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldPartnerReq.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindDesicion()
    {
        // Bind data to the dropdownlist control.
        fldDecision.Items.Insert(0, new ListItem("", ""));
        fldDecision.Items.Insert(1, new ListItem("Go", "Go"));
        fldDecision.Items.Insert(2, new ListItem("No-Go", "No-Go"));
    }

    protected void bindContractType()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        ContractType ";
        qs = qs + " FROM          tblContractType ";
        qs = qs + " ORDER BY      ContractType ";

        fldContractType.DataSource = GetData(qs);
        fldContractType.DataTextField = "ContractType";
        fldContractType.DataValueField = "ContractType";
        fldContractType.DataBind();
        fldContractType.Items.Insert(0, new ListItem("-- Select Contract Type --", ""));
        fldContractType.Items.Insert(1, new ListItem("+ Add New Contract Type +", "addNewContractType"));
    }
    
    protected void checkApprovalStatus()
    {
        //Check approval details 
        qs = "";
        qs = qs + " SELECT        DALAppDate, DALNotAppDate, DALAppStatus, DALAppComment ";
        qs = qs + " FROM          tblOpportunityGoNoGo ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        con.Close();

        if (dt2.Rows.Count == 0)
        {
            //Check for empty record.
            dvReject.Visible = false;
        }
        else
        {
            DataRow row = dt2.Rows[0];

            object dtA = row["DALAppDate"];
            object dtNA = row["DALNotAppDate"];

            if (dtA == DBNull.Value && dtNA == DBNull.Value)
            {
                dvReject.Visible = false;
            }
            else if (dtA != DBNull.Value && dtNA == DBNull.Value)
            {
                dvReject.Visible = false;
                btnApprove.Enabled = false;
                btnNotApprove.Enabled = false;

            }
            else if (dtA == DBNull.Value && dtNA != DBNull.Value)
            {
                dvApprove.Visible = false;
                dvReview.Visible = false;
                dvReject.Visible = true;
                btnApprove.Enabled = false;
                btnNotApprove.Enabled = false;
                fldJustification.Enabled = false;
            }
        }
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblOpportunityGoNoGo.*, vwOpportunityGoNoGoApproval.AppBy, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblOpportunityGoNoGo ";
        qs = qs + " INNER JOIN    vwOpportunityGoNoGoApproval ON tblOpportunityGoNoGo.DescriptionId = vwOpportunityGoNoGoApproval.DescriptionId ";
        qs = qs + " INNER JOIN    StaffLogin AS StaffLogin_1 ON  vwOpportunityGoNoGoApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         tblOpportunityGoNoGo.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            lblDALApproverLevel.Text = row["DALApproverLevel"].ToString();

            //--------------------------------------- Client ---------------------------------------
            //Nature of Client
            fldClientNature.Text = row["ClientNature"].ToString();

            //Strategic Client?
            fldStrategicClient.Text = row["StrategicClient"].ToString();
            fldStrategicClientComment.Text = row["StrategicClientComment"].ToString();

            //Status of Relationship
            fldStatusRel.Text = row["StatusRel"].ToString();

            //Payment History
            fldPymntHistory.Text = row["PymntHistory"].ToString();

            //--------------------------------------- Competition ---------------------------------------
            //How Many?
            fldCompetitorNo.Text = row["CompetitorNo"].ToString();

            //Who Are The Competitors?
            fldCompetitorList.Text = row["CompetitorList"].ToString();

            //Can We Compete?
            fldCanCompete.Text = row["CanCompete"].ToString();
            fldCanCompeteComment.Text = row["CanCompeteComment"].ToString();

            //Chances of Project Materializing
            fldMaterializingPercent.Text = row["MaterializingPercent"].ToString();
            fldMaterializingComment.Text = row["MaterializingComment"].ToString();

            //Chances of Winning
            fldWinningPercent.Text = row["WinningPercent"].ToString();
            fldWinningComment.Text = row["WinningComment"].ToString();

            //--------------------------------------- Finances ---------------------------------------
            //Potential Project Value 
            object dta = row["ProjectValue"];
            if (dta == DBNull.Value)
            { }
            else
            { fldProjectValue.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectValue"].ToString())); }

            //Potential Project Fees
            object dtb = row["ProjectFees"];
            if (dtb == DBNull.Value)
            { }
            else
            { fldProjectFees.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFees"].ToString())); }

            //Potential Margin 
            object dtc = row["PotentialMargin"];
            if (dtc == DBNull.Value)
            { }
            else
            { fldPotentialMargin.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["PotentialMargin"].ToString())); }

            //Potential Pursuit Budget 
            object dtd = row["PotentialBudget"];
            if (dtd == DBNull.Value)
            { }
            else
            { fldPotentialBudget.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["PotentialBudget"].ToString())); }

            //Potential Pursuit Budget / Margin 
            object dte = row["BudgetMargin"];
            if (dte == DBNull.Value)
            { }
            else
            { fldBudgetMargin.Text = row["BudgetMargin"].ToString(); }

            //--------------------------------------- Project Specific ---------------------------------------
            //Contract Type 
            fldContractType.Text = row["ContractType"].ToString();

            //Contract Duration  
            fldContractDuration.Text = row["ContractDuration"].ToString();

            //Detailed Scope of Work
            fldDetailedScopeWork.Text = row["DetailedScopeWork"].ToString();

            //Our Capability to Execute 
            fldOurCapability.Text = row["OurCapability"].ToString();
            fldOurCapabilityComment.Text = row["OurCapabilityComment"].ToString();

            //Our Differentiation 
            fldOurDifferentiation.Text = row["OurDifferentiation"].ToString();

            //Do We Have Track Record / Experience? 
            fldTrackRecord.Text = row["TrackRecord"].ToString();

            //Partner Required?  
            fldPartnerReq.Text = row["PartnerReq"].ToString();
            fldPartnerReqComment.Text = row["PartnerReqComment"].ToString();

            //--------------------------------------- Evaluation ---------------------------------------
            //Evaluation Comment / Justification 
            fldEvaluationComment.Text = row["EvaluationComment"].ToString();

            DateTime varDt;

            //Created By
            if (row["CreatedBy"].ToString() != "")
            {
                lblCreatedBy.Text = row["CREATEBYName"].ToString();
            }
            else
                lblCreatedBy.Text = "-";

            //Created Date
            object dt6 = row["DateCreated"];
            if (dt6 == DBNull.Value)
            { lblCreatedDt.Text = "-"; }
            else
            { lblCreatedDt.Text = Convert.ToDateTime(row["DateCreated"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Modified By 
            if (row["ModifyBy"].ToString() != "")
            {
                lblLastUpdate.Text = row["UPDATEBYName"].ToString();
            }
            else
                lblLastUpdate.Text = "-";

            //Modified Date
            object dt7 = row["DateModify"];
            if (dt7 == DBNull.Value)
            { lblLastUpdateDt.Text = "-"; }
            else
            { lblLastUpdateDt.Text = Convert.ToDateTime(row["DateModify"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //--------------------------------------- Approval Status ---------------------------------------
            //Go / No-Go Decision 
            fldDecision.Text = row["Decision"].ToString();

            //DAL Approver
            //...................................DAL Approval...................................
            object dtR = row["ReviewedBy"];
            if (dtR == DBNull.Value)
            {
                dvReviewer.Visible = false;
                dvReview.Visible = false;
                lblDALApprover.Text = row["DALName"].ToString();
            }
            else
            {
                dvApprover.Visible = false;
                dvApprove.Visible = false;
                lblDALReviewer.Text = row["DALName"].ToString();
            }

            //Date Approved
            object dt8 = row["DALAppDate"];
            if (dt8 == DBNull.Value)
            {
                lblDtApproved.Text = "Pending";
                lblDtApproved.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtApproved.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }
                        
            //Date Rejected
            object dt9 = row["DALNotAppDate"];
            if (dt9 == DBNull.Value)
            {
                lblDtReject.Text = "Pending";
                lblDtReject.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else if (dt9 != DBNull.Value)
            {
                lblDtReject.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");

                //Justification
                fldJustification.Text = row["DALAppComment"].ToString();
            }

            //...................................end of DAL Approval...................................

            checkApprovalStatus();
        }
    }
       

    private void bindProjectRisk()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectRisk "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvProjectRisk.DataSource = GetData(str);
        gvProjectRisk.DataBind();

        for (int i = 0; i < gvProjectRisk.Rows.Count; i++)
        {
            GridViewRow row = gvProjectRisk.Rows[i];

            //Apply style to individual cells of alternating row.
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

    protected void gvProjectRisk_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "#";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Description <br>(Include Cost & Impact of Risk)";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Net Risk Rating";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Mitigation";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            gvProjectRisk.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void gvProjectRisk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
    }

    private void bindContractRisk()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblContractRisk "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvContractRisk.DataSource = GetData(str);
        gvContractRisk.DataBind();

        for (int i = 0; i < gvContractRisk.Rows.Count; i++)
        {
            GridViewRow row = gvContractRisk.Rows[i];

            //Apply style to individual cells of alternating row.
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

    protected void gvContractRisk_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "#";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Description <br>(Include Cost & Impact of Risk)";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Net Risk Rating";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Mitigation";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            gvContractRisk.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void gvContractRisk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
        }
    }

    private void bindEvaluationCommittee()
    {
        String str;

        str = "SELECT         tblEvaluationCommittee.*, StaffLogin.StaffName AS CommitteeName "
            + "FROM           tblEvaluationCommittee "
            + "INNER JOIN     StaffLogin ON tblEvaluationCommittee.CommitteeMember COLLATE SQL_Latin1_General_CP1_CI_AS = StaffLogin.StaffNo "
            + "WHERE          tblEvaluationCommittee.DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       tblEvaluationCommittee.Id DESC ";

        gvEvaluationPerson.DataSource = GetData(str);
        gvEvaluationPerson.DataBind();

        for (int i = 0; i < gvEvaluationPerson.Rows.Count; i++)
        {
            GridViewRow row = gvEvaluationPerson.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void gvEvaluationPerson_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();

            //HeaderCell.RowSpan = 1;
            HeaderCell.ColumnSpan = 1;
            HeaderCell.Text = "#";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.RowSpan = 1;
            HeaderCell.ColumnSpan = 1;
            HeaderCell.Text = "Evaluation Person / Committee";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Role";
            //HeaderCell.RowSpan = 1;
            HeaderCell.ColumnSpan = 1;
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            gvEvaluationPerson.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void gvEvaluationPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;

        }
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string approval_type = "";
        
        //Update in table tblOpportunityGoNoGo
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        DateTime now = DateTime.Now;

        if (lblDALApprover.Text != "")
        {            
             SqlCommand cmdR = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                     + "DALAppStatus = 'Approved', "
                     + "DALAppDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                     + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

             cmdR.ExecuteNonQuery();                        
        }

        con.Close();
                           
        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblOpportunityGoNoGo.DALAppComment, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd2 = new SqlCommand(qs, con);
        cmd2.CommandTimeout = 0;
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        con.Close();

        row = null;
        row = dt2.Rows[0];

        MailMessage objeto_mail1 = new MailMessage();
        SmtpClient client1 = new SmtpClient();
        client1.Port = 25;
        client1.Host = "smtp2.edgenta.com";
        client1.DeliveryMethod = SmtpDeliveryMethod.Network;
        client1.UseDefaultCredentials = false;
        client1.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (lblDALApproverLevel.Text == "BOD" || lblDALApproverLevel.Text == "BOD Comm" || lblDALApproverLevel.Text == "MD/CEO")
        {
            approval_type = "CONDITIONALLY APPROVED";
        }
        else
        {
            approval_type = "APPROVED";
        }

        objeto_mail1.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail1.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail1.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail1.Subject = "Approved : Request for Opportunity Go / No-Go for '" + row["Description"].ToString() + "'";

        string htmlText1 = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Your request for the following opportunity has been <B>" + approval_type + "</B> by DAL person.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"

                            + "<B><U>Note : </U></B><BR>If your request is <B>CONDITIONALLY APPROVED</B>, kindly prepare a Board Paper to seek for approval. The approved Board Paper needs to be uploaded in the system during the <B>Proposal Evaluation / Submission</B> stage.<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail1.Body = htmlText1;
        
        objeto_mail1.IsBodyHtml = true;

        client1.Send(objeto_mail1);
        //---------------------------------- end of send email ----------------------------------------
        
        //Insert into table tblProposalEvaluation
        queryString = "";
        queryString = queryString + " INSERT INTO   tblProposalEvaluation ";
        queryString = queryString + "               (DescriptionId, ProjectFees, BoardRequired) ";
        queryString = queryString + " VALUES        (@pDescriptionId, @pProjectFees, @pBoardRequired) ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["Id"]);
        cmd.Parameters.AddWithValue("@pProjectFees", fldProjectFees.Text);

        if (lblDALApproverLevel.Text == "BOD" || lblDALApproverLevel.Text == "BOD Comm" || lblDALApproverLevel.Text == "MD/CEO")
        {
            cmd.Parameters.AddWithValue("@pBoardRequired", "Yes");
        }
        else
        {
            cmd.Parameters.AddWithValue("@pBoardRequired", "No");
        }

        cmd.ExecuteNonQuery();
        con.Close();

        //Send email notification to Finance if DAL 3.3 already approved
        //Display opportunity details 
        qs = "";
        qs = qs + " SELECT        DALAppStatusCost ";
        qs = qs + " FROM          tblOpportunityGoNoGo ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' AND DALAppStatusCost = 'Approved' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        {
            //Check for empty record.
        }
        else
        {
            emailFinance();
        }
        
        if (Request.QueryString["mode"] == "int")
        {
            //Redirect to previous page
            Response.Redirect("ProjectApprovalList.aspx?DAL=" + Request.QueryString["DAL"]);
        }
        else
        {
            //Redirect to update page
            Response.Redirect("ApprovalOpportunityGoNoGo_DAL.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void emailFinance()
    {
        string approval_type = "";
        
        //Email notification to Finance team
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();

        row = null;
        row = dt.Rows[0];

        MailMessage objeto_mail = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (lblDALApproverLevel.Text == "BOD" || lblDALApproverLevel.Text == "BOD Comm" || lblDALApproverLevel.Text == "MD/CEO")
        {
            approval_type = "CONDITIONALLY APPROVED";
        }
        else
        {
            approval_type = "APPROVED";
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //Finance Team
        qsCommittee = "";
        qsCommittee = qsCommittee + " SELECT        StaffName, EmailId As FinanceEmail ";
        qsCommittee = qsCommittee + " FROM          StaffLogin ";
        qsCommittee = qsCommittee + " WHERE         Role = 'FINANCE' ";
        qsCommittee = qsCommittee + " ORDER BY      StaffName ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd1 = new SqlCommand(qsCommittee, con);
        cmd1.CommandTimeout = 0;
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        { }
        else
        {
            foreach (DataRow row1 in dt1.Rows)
            {
                //objeto_mail.CC.Add(new MailAddress(row1["FinanceEmail"].ToString()));
            }
        }

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "New Promotional Code Request Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi Finance,<BR><BR><BR>"

                            + "FYI, request for the following opportunity has been <B>" + approval_type + "</B> by DAL person.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/CreateOpportunityCode.aspx?ID=" + row["Id"].ToString() + ">link</A> to create the promotional code.<BR><BR><BR>"

                            + "<B>Kindly limit time input cost to RM" + fldPotentialBudget.Text + "</B>.<BR><BR><BR>"

                            + "<B><U>Note : </U></B><BR>If the <B>Potential Pursuit Budget</B> is utilized during promotional phase, freeze the promotional code (no one can charge time).<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void btnNotApprove_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvJustification.Attributes.Add("class", null);

        if (fldJustification.Text.Trim() == "")
        {
            chckErr = false;
            dvJustification.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Update in table tblOpportunityGoNoGo
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            DateTime now = DateTime.Now;

            if (lblDALApprover.Text != "")
            {
                SqlCommand cmdNR = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                    + "DALAppStatus = 'Rejected', "
                    + "DALNotAppDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "DALAppComment = @pJustification "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

                //Justification
                cmdNR.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

                cmdNR.ExecuteNonQuery();
            }
            else if (lblDALReviewer.Text != "")
            {
                SqlCommand cmdNR = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                    + "RevStatus = 'Rejected', "
                    + "DateNotRev = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "RevComment = @pJustification "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

                //Justification
                cmdNR.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

                cmdNR.ExecuteNonQuery();
            }

            con.Close();

            //Email notification to Project Manager
            //---------------------------------------- send email -----------------------------------------        
            qs = "";
            qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, ";
            qs = qs + "               tblOpportunityGoNoGo.DALAppComment, ";
            qs = qs + "               tblClient.ClientName AS ClientName, ";
            qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
            qs = qs + " FROM          tblMain ";
            qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + "               INNER JOIN tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId ";
            qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            row = null;
            row = dt.Rows[0];

            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp2.edgenta.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("user", "Password");

            objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

            //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

            objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

            objeto_mail.Subject = "Rejected : Request for Opportunity Go / No-Go for '" + row["Description"].ToString() + "'";

            string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:TAHOMA,8PT;>"
                                + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                                + "Your request for the following opportunity is <B>REJECTED</B>. Please read the remarks by DAL person below.<BR><BR><BR>"

                                + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                                + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                                + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                                + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                                + "<B>DAL Remarks : </B>" + row["DALAppComment"].ToString() + "<BR><BR><BR>"

                                + "<B><U>Note : </U></B><BR>If your request is <B>REJECTED</B>, the opportunity is closed in the system.<BR><BR><BR>"

                                + "<BR><BR><BR>Thank you.<BR><BR>"
                                + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

            objeto_mail.Body = htmlText;
            objeto_mail.IsBodyHtml = true;

            client.Send(objeto_mail);
            //---------------------------------- end of send email ----------------------------------------
            
            if (Request.QueryString["mode"] == "int")
            {
                //Redirect to previous page
                Response.Redirect("ProjectApprovalList.aspx?DAL=" + Request.QueryString["DAL"]);
            }
            else
            {
                //Redirect to update page
                Response.Redirect("ApprovalOpportunityGoNoGo_DAL.aspx?Id=" + Request.QueryString["Id"]);
            }
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectApprovalList.aspx?DAL=" + Request.QueryString["DAL"]);
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

    protected void btnUpA1_Click(object sender, EventArgs e)
    {
        //RFP (If Available)
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/RFP";

        //Check year folder created
        if (Directory.Exists(Server.MapPath(pathfolder)) == false)
        {
            Directory.CreateDirectory(Server.MapPath(pathfolder));
        }

        //Update path to folder assigned
        pathfolder = pathfolder + "/";

        //Upload file
        try
        {
            fldA1Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblOpportunityGoNoGo SET RFP = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;
                UpA1.Update();
                hidURLA1.Value = pathfolder + filenameStr;
                lblURLA1.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA1_Click(object sender, EventArgs e)
    {
        //RFP (If Available)
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblOpportunityGoNoGo SET RFP = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/RFP/" + lblURLA1.Text + "";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        hidURLA1.Value = "";
        dvUpA1Sec.Visible = true;
        dvVwA1Sec.Visible = false;
        UpA1.Update();
    }

    protected void btnViewA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }
}