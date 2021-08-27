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

public partial class CreateOpportunityCode : System.Web.UI.Page
{
    string queryString = "";
    string startdt, enddt;
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
            //Display opportunity details 
            qs = "";
            qs = qs + " SELECT        tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.ClientId, StaffLogin.StaffName AS PMName, tblClient.ClientName, tblOpportunityRecord.ClientAddress, tblOpportunityRecord.EstStartDate, tblOpportunityRecord.EstEndDate ";
            qs = qs + " FROM          tblMain ";
            qs = qs + " INNER JOIN    tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + " INNER JOIN    tblOpportunityRecord ON tblMain.Id = tblOpportunityRecord.DescriptionId ";
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

                //Estimated Project Start & End Date
                startdt = Convert.ToDateTime(row["EstStartDate"].ToString()).ToString("dd-MMM-yyyy");
                enddt = Convert.ToDateTime(row["EstEndDate"].ToString()).ToString("dd-MMM-yyyy");
                lblProjectStartEnd.Text = startdt + " until " + enddt;

                //Client Address
                lblClientAddress.Text = row["ClientAddress"].ToString().ToUpper();
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
        fldDecision.Items.Insert(0, new ListItem("-- Select Go / No-Go Decision --", ""));
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

    protected void bindDetails()
    {
        //qs = "";
        //qs = qs + " SELECT        tblOpportunityGoNoGo.*, tblMain.Code, ";
        //qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        //qs = qs + " FROM          tblOpportunityGoNoGo ";
        //qs = qs + " INNER JOIN    tblMain ON tblOpportunityGoNoGo.DescriptionId = tblMain.Id ";
        //qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " WHERE         tblOpportunityGoNoGo.DescriptionId = '" + Request.QueryString["Id"] + "' ";

        qs = "";
        qs = qs + " SELECT        tblOpportunityGoNoGo.*, tblMain.Code, tblMain.OldCode, vwOpportunityGoNoGoApproval.AppBy, vwOpportunityGoNoGoApprovalCost.AppBy, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "               tblCOO.StaffName AS COOApproverName, ";
        qs = qs + "               tblDAL.StaffName AS DALApproverName, ";
        qs = qs + "               tblDALCost.StaffName AS DALApproverNameCost ";
        qs = qs + " FROM          tblOpportunityGoNoGo ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCOO ON tblCOO.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ApprovedByCOO COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.tblMain.Id ";
        qs = qs + " LEFT OUTER JOIN dbo.vwOpportunityGoNoGoApproval ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.vwOpportunityGoNoGoApproval.DescriptionId ";
        qs = qs + " LEFT OUTER JOIN  dbo.StaffLogin AS tblDAL ON dbo.vwOpportunityGoNoGoApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
        qs = qs + " LEFT OUTER JOIN dbo.vwOpportunityGoNoGoApprovalCost ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.vwOpportunityGoNoGoApprovalCost.DescriptionId ";
        qs = qs + " LEFT OUTER JOIN  dbo.StaffLogin AS tblDALCost ON dbo.vwOpportunityGoNoGoApprovalCost.AppBy COLLATE Latin1_General_CI_AI = tblDALCost.StaffNo ";
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

            lblErrorRemarks.Text = row["ErrorRemarks"].ToString();

            if (row["ErrorRemarks"].ToString() == "")
            {
                lblErrorRemarks.Visible = false;
            }
            else
            {
                lblErrorRemarks.Visible = true;
            }

            lblOldDALRemarks.Text = row["OldDALRemarks"].ToString();

            if (row["OldDALRemarks"].ToString() == "")
            {
                lblOldDALRemarks.Visible = false;
            }
            else
            {
                lblOldDALRemarks.Visible = true;
            }

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
            //...................................DAL Approval...................................  
            //...................................[1.3: Submission of Tender Bids / Proposals]...................................
            //.................................................Approver.................................................
            //Approver - Name
            lblDALApprover.Text = row["DALApproverName"].ToString();

            //Approver - Date Approved 
            object dtDA = row["DALAppDate"];
            object dtDNA = row["DALNotAppDate"];
            if (dtDA != DBNull.Value)
            {
                lblDAL_ApprovedDate.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNA != DBNull.Value)
            {
                lblDAL_ApprovedDate.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblDAL_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblDAL_ApprovedStatus.Text = row["DALAppStatus"].ToString(); }
            else
            { lblDAL_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["DALAppComment"].ToString() != "")
            { lblDAL_ApprovedComment.Text = row["DALAppComment"].ToString(); }
            else
            { lblDAL_ApprovedComment.Text = "-"; }

            //...................................[1.4: Cost of Preparing Proposal / Tender]...................................
            //.................................................Approver.................................................
            //Approver - Name
            lblDALApproverCost.Text = row["DALApproverNameCost"].ToString();

            //Approver - Date Approved 
            object dtDACost = row["DALAppDateCost"];
            object dtDNACost = row["DALNotAppDateCost"];
            if (dtDACost != DBNull.Value)
            {
                lblDAL_ApprovedDateCost.Text = Convert.ToDateTime(row["DALAppDateCost"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNACost != DBNull.Value)
            {
                lblDAL_ApprovedDateCost.Text = Convert.ToDateTime(row["DALNotAppDateCost"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblDAL_ApprovedDateCost.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatusCost"].ToString() != "")
            { lblDAL_ApprovedStatusCost.Text = row["DALAppStatusCost"].ToString(); }
            else
            { lblDAL_ApprovedStatusCost.Text = "-"; }

            //Approver - Comment
            if (row["DALAppCommentCost"].ToString() != "")
            { lblDAL_ApprovedCommentCost.Text = row["DALAppCommentCost"].ToString(); }
            else
            { lblDAL_ApprovedCommentCost.Text = "-"; }

            //Go / No-Go Decision 
            fldDecision.Text = row["Decision"].ToString();
            
            //Promotional Code
            fldCode.Text = row["Code"].ToString();

            if (row["Code"] == DBNull.Value)
            {
                btnSubmit.Enabled = true;
            }
            else 
            {
                btnSubmit.Enabled = false;
            }
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvCode.Attributes.Add("class", null);

        if (fldCode.Text.Trim() == "")
        {
            chckErr = false;
            dvCode.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Update in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            DateTime now = DateTime.Now;

            SqlCommand cmd = new SqlCommand("UPDATE tblMain SET "
                    + "Code = @pCode, "
                    + "CodeCreatedBy = 'FIN', "
                    + "CodeDateCreated = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "'", con);

            //Promotional Code
            cmd.Parameters.AddWithValue("@pCode", fldCode.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            bindDetails();
        }

        emailPM();

        Response.Redirect("CreateOpportunityCode.aspx?Id=" + Request.QueryString["Id"]);
    }
    

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
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

       
    protected void emailPM()
    {
        System.Collections.ArrayList emailPMArray = new System.Collections.ArrayList();

        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT DISTINCT             tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.Code, vwOpportunityGoNoGoApproval.AppBy, ";
        qs = qs + "                             tblClient.ClientName AS ClientName, ";
        qs = qs + "                             StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
        qs = qs + "                             StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail, ";
        qs = qs + "                             StaffLogin_Committee.EmailId AS CommitteeEmail ";
        qs = qs + " FROM                        tblMain ";
        qs = qs + " INNER JOIN                  tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + " INNER JOIN                  StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " INNER JOIN                  vwOpportunityGoNoGoApproval ON tblMain.Id = vwOpportunityGoNoGoApproval.DescriptionId ";
        qs = qs + " INNER JOIN                  tblEvaluationCommittee ON tblMain.Id = tblEvaluationCommittee.DescriptionId ";
        qs = qs + " INNER JOIN                  StaffLogin AS StaffLogin_1 ON vwOpportunityGoNoGoApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " INNER JOIN                  StaffLogin AS StaffLogin_Committee ON tblEvaluationCommittee.CommitteeMember = StaffLogin_Committee.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE                       tblMain.Id = '" + Request.QueryString["Id"] + "' ";

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

        //get emailCC
        foreach (DataRow rowCC in dt.Rows)
        {
            emailPMArray.Add(rowCC["CommitteeEmail"]);
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));
        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));

        foreach (string emailCC in emailPMArray)
        {
            objeto_mail.CC.Add(emailCC);
        }

        //objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "New Promotional Code Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + " & " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "Please be informed that the <B>PROMOTIONAL CODE</B> has been created in the Project Execution Control.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Promotional Code : </B>" + row["Code"].ToString() + "<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
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