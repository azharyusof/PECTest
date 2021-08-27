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

public partial class OpportunityGoNoGoDetailView : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    DataRow row1 = null;
    String qs = "";
    String qs1 = "";
    String qs2 = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();

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
            //Hide all upload
            dvUpA1Sec.Visible = true;
            dvVwA1Sec.Visible = false;

            //Display opportunity details 
            qs = "";
            qs = qs + " SELECT        Description ";
            qs = qs + " FROM          tblMain ";
            qs = qs + " WHERE         Id = '" + Request.QueryString["Id"] + "' ";

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

                lblDescription.Text = row["Description"].ToString().ToUpper();
            }


            //Bind dropdownlist
            bindStrategicClient();
            bindStatusRel();
            bindPymntHistory();
            bindCompetitorNo();
            bindCanCompete();
            bindOurCapability();
            bindTrackRecord();
            bindPartnerReq();
            bindDesicion();
            bindContractType();
            bindLikelihood();
            bindLikelihoodC();

            bindImpact();
            bindImpactC();

            bindProjectRisk();
            bindContractRisk();
            bindEvaluationCommittee();
            bindCommittee();

            checkRole();

            if (lblRole.Text == "QHSE")
            {
                dvInactive.Visible = true;
                dvActive.Visible = false;
            }
            else
            {
                bindDetails();

                //DAL approval
                //[1.3: Submission of Tender Bids / Proposals]
                bindDALApprover();
                bindDALApprover_HOD();
                bindDALApprover_COO();

                //[1.4: Cost of Preparing Proposal / Tender
                bindDALApproverCost();
                bindDALApprover_COOCost();

                chkAssessmentScore();
                chkEvaluation();

                if (fldOldCode.Text == "")
                {
                    dvOldCode.Visible = false;
                }

                if (lblDAL_ApprovedStatus.Text == "Approved" || lblDAL_ApprovedStatus.Text == "Rejected")
                {
                    lblDALApprover.Visible = true;
                    fldDALApprover.Visible = false;
                    fldDALApprover_HOD.Visible = false;
                    fldDALApprover_COO.Visible = false;
                }
                else
                {
                    lblDALApprover.Visible = false;
                    fldDALApprover.Visible = true;
                    fldDALApprover_HOD.Visible = true;
                    fldDALApprover_COO.Visible = true;
                }
            }
        }
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

            lblRole.Text = row["Role"].ToString();

        }
    }


    protected void bindDALApprover()
    {
        // Bind data to the dropdownlist control.                
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'MDCEO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover.DataSource = GetData(qs);
        fldDALApprover.DataTextField = "StaffName";
        fldDALApprover.DataValueField = "StaffNo";
        fldDALApprover.DataBind();
    }

    protected void bindDALApprover_HOD()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadDivision' "; // OR Role = 'HeadUnit'
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_HOD.DataSource = GetData(qs);
        fldDALApprover_HOD.DataTextField = "StaffName";
        fldDALApprover_HOD.DataValueField = "StaffNo";
        fldDALApprover_HOD.DataBind();
    }

    protected void bindDALApprover_COO()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'COO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_COO.DataSource = GetData(qs);
        fldDALApprover_COO.DataTextField = "StaffName";
        fldDALApprover_COO.DataValueField = "StaffNo";
        fldDALApprover_COO.DataBind();
    }
    
    protected void bindDALApproverCost()
    {
        // Bind data to the dropdownlist control.                
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'MDCEO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApproverCost.DataSource = GetData(qs);
        fldDALApproverCost.DataTextField = "StaffName";
        fldDALApproverCost.DataValueField = "StaffNo";
        fldDALApproverCost.DataBind();
    }

    protected void bindDALApprover_COOCost()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'COO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_COOCost.DataSource = GetData(qs);
        fldDALApprover_COOCost.DataTextField = "StaffName";
        fldDALApprover_COOCost.DataValueField = "StaffNo";
        fldDALApprover_COOCost.DataBind();
    }

    protected void bindStrategicClient()
    {
        // Bind data to the dropdownlist control.
        fldStrategicClient.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldStrategicClient.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldStrategicClient.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindCanCompete()
    {
        // Bind data to the dropdownlist control.
        fldCanCompete.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldCanCompete.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldCanCompete.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindStatusRel()
    {
        // Bind data to the dropdownlist control.
        fldStatusRel.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldStatusRel.Items.Insert(1, new ListItem("First Time", "First Time"));
        fldStatusRel.Items.Insert(2, new ListItem("Transactional", "Transactional"));
        fldStatusRel.Items.Insert(3, new ListItem("Key Client", "Key Client"));
    }

    protected void bindPymntHistory()
    {
        // Bind data to the dropdownlist control.
        fldPymntHistory.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldPymntHistory.Items.Insert(1, new ListItem("30 Days", "30 Days"));
        fldPymntHistory.Items.Insert(2, new ListItem("60 Days", "60 Days"));
        fldPymntHistory.Items.Insert(3, new ListItem("90 Days", "90 Days"));
        fldPymntHistory.Items.Insert(4, new ListItem("Beyond 90 Days", "Beyond 90 Days"));
        fldPymntHistory.Items.Insert(5, new ListItem("N/A", "N/A"));
    }

    protected void bindCompetitorNo()
    {
        // Bind data to the dropdownlist control.
        fldCompetitorNo.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldCompetitorNo.Items.Insert(1, new ListItem("1", "1"));
        fldCompetitorNo.Items.Insert(2, new ListItem("2", "2"));
        fldCompetitorNo.Items.Insert(3, new ListItem("3", "3"));
        fldCompetitorNo.Items.Insert(4, new ListItem("4", "4"));
        fldCompetitorNo.Items.Insert(5, new ListItem("5", "5"));
        fldCompetitorNo.Items.Insert(6, new ListItem(">5", ">5"));
    }

    protected void bindOurCapability()
    {
        // Bind data to the dropdownlist control.
        fldOurCapability.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldOurCapability.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldOurCapability.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindTrackRecord()
    {
        // Bind data to the dropdownlist control.
        fldTrackRecord.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldTrackRecord.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldTrackRecord.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindPartnerReq()
    {
        // Bind data to the dropdownlist control.
        fldPartnerReq.Items.Insert(0, new ListItem("-- Please select one --", ""));
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
        fldContractType.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }
    
    protected void chkAssessmentScore()
    {
        //Retrieve value for Assessment Scoring  
        qs = "";
        qs = qs + " SELECT        GrandTotal ";
        qs = qs + " FROM          tblAssessment ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            fldScore.Text = row["GrandTotal"].ToString();
        }
    }

    protected void chkEvaluation()
    {
        //Check Evaluation Person / Committee  
        qs = "";
        qs = qs + " SELECT        CommitteeMember ";
        qs = qs + " FROM          tblEvaluationCommittee ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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
            lblCheckEvaluation.Text = "No";
        }
        else
        {
            DataRow row = dt1.Rows[0];

            lblCheckEvaluation.Text = "Yes";
        }
    }

    protected void bindLikelihood()
    {
        // Bind data to the dropdownlist control.
        fldLikelihood.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldLikelihood.Items.Insert(1, new ListItem("Certain", "Certain"));
        fldLikelihood.Items.Insert(2, new ListItem("Likely", "Likely"));
        fldLikelihood.Items.Insert(3, new ListItem("Possible", "Possible"));
        fldLikelihood.Items.Insert(4, new ListItem("Unlikely", "Unlikely"));
        fldLikelihood.Items.Insert(5, new ListItem("Remote", "Remote"));
    }

    protected void bindLikelihoodC()
    {
        // Bind data to the dropdownlist control.
        fldLikelihoodC.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldLikelihoodC.Items.Insert(1, new ListItem("Certain", "Certain"));
        fldLikelihoodC.Items.Insert(2, new ListItem("Likely", "Likely"));
        fldLikelihoodC.Items.Insert(3, new ListItem("Possible", "Possible"));
        fldLikelihoodC.Items.Insert(4, new ListItem("Unlikely", "Unlikely"));
        fldLikelihoodC.Items.Insert(5, new ListItem("Remote", "Remote"));
    }

    protected void bindImpact()
    {
        // Bind data to the dropdownlist control.
        fldImpact.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldImpact.Items.Insert(1, new ListItem("Insignificant", "Insignificant"));
        fldImpact.Items.Insert(2, new ListItem("Minor", "Minor"));
        fldImpact.Items.Insert(3, new ListItem("Moderate", "Moderate"));
        fldImpact.Items.Insert(4, new ListItem("Major", "Major"));
        fldImpact.Items.Insert(5, new ListItem("Catastrophic", "Catastrophic"));
    }

    protected void bindImpactC()
    {
        // Bind data to the dropdownlist control.
        fldImpactC.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldImpactC.Items.Insert(1, new ListItem("Insignificant", "Insignificant"));
        fldImpactC.Items.Insert(2, new ListItem("Minor", "Minor"));
        fldImpactC.Items.Insert(3, new ListItem("Moderate", "Moderate"));
        fldImpactC.Items.Insert(4, new ListItem("Major", "Major"));
        fldImpactC.Items.Insert(5, new ListItem("Catastrophic", "Catastrophic"));
    }

    protected void bindCommittee()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldEvaluationCommittee.DataSource = GetData(qs);
        fldEvaluationCommittee.DataTextField = "StaffName";
        fldEvaluationCommittee.DataValueField = "StaffNo";
        fldEvaluationCommittee.DataBind();
        fldEvaluationCommittee.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblOpportunityGoNoGo.*, tblMain.Code, tblMain.OldCode, vwOpportunityGoNoGoApproval.AppBy, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "               tblCOO.StaffName AS COOApproverName, ";
        qs = qs + "               tblDAL.StaffName AS DALApproverName ";
        qs = qs + " FROM          tblOpportunityGoNoGo ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCOO ON tblCOO.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ApprovedByCOO COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.tblMain.Id ";
        qs = qs + " INNER JOIN dbo.vwOpportunityGoNoGoApproval ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.vwOpportunityGoNoGoApproval.DescriptionId ";
        qs = qs + " INNER JOIN dbo.StaffLogin AS tblDAL ON dbo.vwOpportunityGoNoGoApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
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
            dvInactive.Visible = true;
            dvActive.Visible = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            dvInactive.Visible = false;
            dvActive.Visible = true;

            //BtnSubmit
            lblBtnSubmit.Text = row["BtnSubmit"].ToString();

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
            { fldPotentialMargin.Text = row["PotentialMargin"].ToString(); }

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

            //--------------------------------------- RFP (If Available) ---------------------------------------
            //RFP (If Available)
            object fn = row["RFP"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["RFP"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/RFP/" + row["RFP"].ToString() + "";
            }


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

            //Go / No-Go Decision 
            fldDecision.Text = row["Decision"].ToString();

            if (row["Decision"].ToString() == "No-Go")
            {
                dvCode.Visible = false;
            }
            else if (row["Decision"].ToString() == "Go")
            {
                dvCode.Visible = true;
            }

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
                                    
            //Promotional Code
            fldCode.Text = row["Code"].ToString();

            //Promotional Code (Old)
            fldOldCode.Text = row["OldCode"].ToString();

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

            //btnUpdate & btnSubmit
            object dt8 = row["BtnSubmit"];
            if (dt8 == DBNull.Value)
            {
                fldA1Upload.Enabled = true;
                btnCancelA1.Enabled = true;
                btnUpA1.Enabled = true;
                btnDeleteA1.Visible = true;

                btnProjectRisk.Visible = true;
                btnContractRisk.Visible = true;
                btnEvaluationPerson.Visible = true;

                DALApprover();
                DALApproverCost();
            }
            else 
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;
                btnDeleteA1.Visible = false;

                btnProjectRisk.Visible = false;

                if (gvProjectRisk.Rows.Count == 0)
                {
                    lblNone.Visible = true;
                }

                btnContractRisk.Visible = false;

                if (gvContractRisk.Rows.Count == 0)
                {
                    lblNone1.Visible = true;
                }

                btnEvaluationPerson.Visible = false;

                if (gvEvaluationPerson.Rows.Count == 0)
                {
                    lblNone2.Visible = true;
                }

                DALApprover();
                DALApproverCost();
            }

        }
    }

    protected void DALApprover()
    {
        qs1 = "";
        qs1 = qs1 + " SELECT        ProjectFees, ReviewedBy, DALApprovedBy, DALApprovedBy_HOD, DALApprovedBy_HOU, DALApprovedBy_CFO, DALApprovedBy_COO ";
        qs1 = qs1 + " FROM          tblOpportunityGoNoGo ";
        qs1 = qs1 + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd1 = new SqlCommand(qs1, con);
        cmd1.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row1 = dt1.Rows[0];

            //DAL (Discretionary Authority Limits) Approval 
            decimal ProjectFees_Value;
            ProjectFees_Value = Convert.ToDecimal(row1["ProjectFees"].ToString());

            //Approver - Name
            fldDALApprover.Text = row1["DALApprovedBy"].ToString();
            fldDALApprover_HOD.Text = row1["DALApprovedBy_HOD"].ToString();
            fldDALApprover_COO.Text = row1["DALApprovedBy_COO"].ToString();

            if (ProjectFees_Value == 10000000 || ProjectFees_Value <= 10000000)
            {
                //Approved by Head of Division
                //Potential Project Fees - Equal or below 10m

                fldDALApprover.Visible = false;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = true;
                fldDALApprover_HOD.Enabled = true;                

            }
            else if (ProjectFees_Value == 50000000 || ProjectFees_Value <= 50000000)
            {
                //Approved by COO
                //Potential Project Fees - Equal or below 50m
                
                fldDALApprover.Visible = false;                
                fldDALApprover_COO.Visible = true;
                fldDALApprover_COO.Enabled = true;
                fldDALApprover_HOD.Visible = false;

            }
            else if (ProjectFees_Value == 100000000 || ProjectFees_Value <= 100000000)
            {
                //Approved by MD/CEO
                //Potential Project Fees - Equal or below 100m

                lvlDALBOD.Visible = true;
                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;                
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = false;

            }
            else if (ProjectFees_Value == 200000000 || ProjectFees_Value <= 200000000)
            {
                //Approved by BOD Comm.
                //Potential Project Fees - Equal or below 200m

                lvlDALBOD.Visible = true;
                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;
                fldDALApprover_HOD.Visible = false;
                fldDALApprover_COO.Visible = false;

            }
            else if (ProjectFees_Value > 200000000)
            {
                //Approved by BOD
                //Potential Project Fees - Above 200m

                lvlDALBOD.Visible = true;
                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;
                fldDALApprover_HOD.Visible = false;
                fldDALApprover_COO.Visible = false;

            }
        }
    }

    protected void DALApproverCost()
    {
        qs2 = "";
        qs2 = qs2 + " SELECT        PotentialBudget, ReviewedByCost, ReviewedBy_COOCost, DALApprovedByCost, DALApprovedBy_COOCost ";
        qs2 = qs2 + " FROM          tblOpportunityGoNoGo ";
        qs2 = qs2 + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd2 = new SqlCommand(qs2, con);
        cmd2.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        con.Close();

        if (dt2.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row2 = dt2.Rows[0];

            //DAL (Discretionary Authority Limits) Approval 
            decimal PotentialBudget_Value;
            //PotentialBudget_Value = Convert.ToDecimal(row2["PotentialBudget"].ToString());
            
            object dta = row2["PotentialBudget"];
            if (dta == DBNull.Value)
            { PotentialBudget_Value = 0; }
            else
            { PotentialBudget_Value = Convert.ToDecimal(row2["PotentialBudget"].ToString()); }

            //Reviewer & Approver - Name
            fldDALApproverCost.Text = row2["DALApprovedByCost"].ToString();
            fldDALApprover_COOCost.Text = row2["DALApprovedBy_COOCost"].ToString();

            if (PotentialBudget_Value == 500000 || PotentialBudget_Value <= 500000)
            {
                //Approved by COO
                //Potential Pursuit Budget - Equal or below 500k
                                
                fldDALApproverCost.Visible = false;
                fldDALApprover_COOCost.Visible = true;

            }
            else if (PotentialBudget_Value == 2000000 || PotentialBudget_Value <= 2000000)
            {
                //Approved by MD/CEO
                //Potential Pursuit Budget - Equal or below 2m

                lvlDALBODCost.Visible = true;
                fldDALApproverCost.Visible = true;
                fldDALApprover_COOCost.Visible = false;

            }
            else if (PotentialBudget_Value > 2000000)
            {
                //Approved by BOD
                //Potential Pursuit Budget - Above 2m

                lvlDALBODCost.Visible = true;
                fldDALApproverCost.Visible = true;
                fldDALApprover_COOCost.Visible = false;

            }
        }
    }
    
    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
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

            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                gvProjectRisk.HeaderRow.Cells[6].Visible = true;
                gvProjectRisk.HeaderRow.Cells[7].Visible = true;
            }
            else
            {
                gvProjectRisk.HeaderRow.Cells[6].Visible = false;
                gvProjectRisk.HeaderRow.Cells[7].Visible = false;
            }
            
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

            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
                HeaderGridRow.Cells.Add(HeaderCell);
            }

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
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //ImageButton btn = (e.Row.FindControl("imgDelete") as ImageButton);

            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                //btn.Enabled = true;
                e.Row.Cells[6].Visible = true;
                e.Row.Cells[7].Visible = true;
            }
            else
            {
                //btn.Enabled = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }
    }

    protected void EditProject(object sender, GridViewEditEventArgs e)
    {
        gvProjectRisk.EditIndex = e.NewEditIndex;
        bindProjectRisk();
    }

    protected void CancelProjectEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvProjectRisk.EditIndex = -1;
        bindProjectRisk();
    }

    protected void UpdateProject(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvProjectRisk.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Risk = ((TextBox)gvProjectRisk.Rows[e.RowIndex].FindControl("txtRisk")).Text;
        string Likelihood = ((DropDownList)gvProjectRisk.Rows[e.RowIndex].FindControl("txtLikelihood")).Text;
        string Impact = ((DropDownList)gvProjectRisk.Rows[e.RowIndex].FindControl("txtImpact")).Text;
        string Mitigation = ((TextBox)gvProjectRisk.Rows[e.RowIndex].FindControl("txtMitigation")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectRisk SET ProjectRisk=@pRisk, Likelihood=@pLikelihood, Impact=@pImpact, Mitigation=@pMitigation, ModifyBy='" + Session["UserID"].ToString() + "', DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pRisk", SqlDbType.VarChar).Value = Risk;
        cmd.Parameters.Add("@pLikelihood", SqlDbType.VarChar).Value = Likelihood;
        cmd.Parameters.Add("@pImpact", SqlDbType.VarChar).Value = Impact;
        cmd.Parameters.Add("@pMitigation", SqlDbType.VarChar).Value = Mitigation;
              
        cmd.ExecuteNonQuery();

        //Update Risk Rating in table tblProjectRisk
        SqlCommand cmdRating = new SqlCommand("UPDATE tblProjectRisk SET tblProjectRisk.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblProjectRisk WHERE tblRiskImpact.Likelihood = tblProjectRisk.Likelihood AND tblRiskImpact.Impact = tblProjectRisk.Impact", con);

        cmdRating.ExecuteNonQuery();

        gvProjectRisk.EditIndex = -1;
        bindProjectRisk();
    }

    protected void DeleteProjectRisk(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectRisk WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindProjectRisk();
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

            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                gvContractRisk.HeaderRow.Cells[6].Visible = true;
                gvContractRisk.HeaderRow.Cells[7].Visible = true;
            }
            else
            {
                gvContractRisk.HeaderRow.Cells[6].Visible = false;
                gvContractRisk.HeaderRow.Cells[7].Visible = false;
            }

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

            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
                HeaderGridRow.Cells.Add(HeaderCell);
            }

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
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                e.Row.Cells[6].Visible = true;
                e.Row.Cells[7].Visible = true;
            }
            else
            {
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }
    }

    protected void EditContract(object sender, GridViewEditEventArgs e)
    {
        gvContractRisk.EditIndex = e.NewEditIndex;
        bindContractRisk();
    }

    protected void CancelContractEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvContractRisk.EditIndex = -1;
        bindContractRisk();
    }

    protected void UpdateContract(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvContractRisk.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Risk = ((TextBox)gvContractRisk.Rows[e.RowIndex].FindControl("txtRisk")).Text;
        string Likelihood = ((DropDownList)gvContractRisk.Rows[e.RowIndex].FindControl("txtLikelihood")).Text;
        string Impact = ((DropDownList)gvProjectRisk.Rows[e.RowIndex].FindControl("txtImpact")).Text;
        string Mitigation = ((TextBox)gvProjectRisk.Rows[e.RowIndex].FindControl("txtMitigation")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblContractRisk SET ContractRisk=@pRisk, Likelihood=@pLikelihood, Impact=@pImpact, Mitigation=@pMitigation, ModifyBy='" + Session["UserID"].ToString() + "', DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pRisk", SqlDbType.VarChar).Value = Risk;
        cmd.Parameters.Add("@pLikelihood", SqlDbType.VarChar).Value = Likelihood;
        cmd.Parameters.Add("@pImpact", SqlDbType.VarChar).Value = Impact;
        cmd.Parameters.Add("@pMitigation", SqlDbType.VarChar).Value = Mitigation;
        
        cmd.ExecuteNonQuery();

        //Update Risk Rating in table tblContractRisk
        SqlCommand cmdRating = new SqlCommand("UPDATE tblContractRisk SET tblContractRisk.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblContractRisk WHERE tblRiskImpact.Likelihood = tblContractRisk.Likelihood AND tblRiskImpact.Impact = tblContractRisk.Impact", con);

        cmdRating.ExecuteNonQuery();

        gvContractRisk.EditIndex = -1;
        bindContractRisk();
    }

    protected void DeleteContractRisk(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblContractRisk WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindContractRisk();
    }
        
    private void bindEvaluationCommittee()
    {
        String str;

        str = "SELECT         tblEvaluationCommittee.*, tblStaff.StaffName AS CommitteeName "
            + "FROM           tblEvaluationCommittee "
            + "INNER JOIN     tblStaff ON tblEvaluationCommittee.CommitteeMember COLLATE SQL_Latin1_General_CP1_CI_AS = tblStaff.StaffNo "
            + "WHERE          tblEvaluationCommittee.DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       tblEvaluationCommittee.Id DESC ";

        gvEvaluationPerson.DataSource = GetData(str);
        gvEvaluationPerson.DataBind();

        for (int i = 0; i < gvEvaluationPerson.Rows.Count; i++)
        {
            GridViewRow row = gvEvaluationPerson.Rows[i];
            
            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                gvEvaluationPerson.HeaderRow.Cells[3].Visible = true;
                gvEvaluationPerson.HeaderRow.Cells[4].Visible = true;
            }
            else
            {
                gvEvaluationPerson.HeaderRow.Cells[3].Visible = false;
                gvEvaluationPerson.HeaderRow.Cells[4].Visible = false;
            }
            
            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void gvEvaluationPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Bind data to the dropdownlist control.
            DropDownList txtEvaluationCommittee = (e.Row.FindControl("txtEvaluationCommittee") as DropDownList);
            txtEvaluationCommittee.DataSource = GetData("SELECT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            txtEvaluationCommittee.DataTextField = "StaffName";
            txtEvaluationCommittee.DataValueField = "StaffNo";
            txtEvaluationCommittee.DataBind();

            string CommitteeMember = (e.Row.FindControl("txtCommitteeMember") as TextBox).Text;
            txtEvaluationCommittee.Items.FindByValue(CommitteeMember).Selected = true;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            {
                e.Row.Cells[3].Visible = true;
                e.Row.Cells[4].Visible = true;
            }
            else
            {
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
        }
    }
    
    protected void EditEvaluation(object sender, GridViewEditEventArgs e)
    {
        gvEvaluationPerson.EditIndex = e.NewEditIndex;
        bindEvaluationCommittee();
    }

    protected void CancelEvaluationEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEvaluationPerson.EditIndex = -1;
        bindEvaluationCommittee();
    }

    protected void UpdateEvaluation(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvEvaluationPerson.Rows[e.RowIndex].FindControl("lblID")).Text;
        string CommitteeMember = ((DropDownList)gvEvaluationPerson.Rows[e.RowIndex].FindControl("txtEvaluationCommittee")).Text;
        string Role = ((TextBox)gvEvaluationPerson.Rows[e.RowIndex].FindControl("txtRole")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblEvaluationCommittee SET CommitteeMember=@pCommitteeMember, Role=@pRole, ModifyBy='" + Session["UserID"].ToString() + "', DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pCommitteeMember", SqlDbType.VarChar).Value = CommitteeMember;
        cmd.Parameters.Add("@pRole", SqlDbType.VarChar).Value = Role;

        cmd.ExecuteNonQuery();

        gvEvaluationPerson.EditIndex = -1;
        bindEvaluationCommittee();
    }
        
    protected void DeleteEvaluation(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblEvaluationCommittee WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindEvaluationCommittee();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvRisk.Attributes.Add("class", null);
        dvLikelihood.Attributes.Add("class", null);
        dvImpact.Attributes.Add("class", null);
        dvMitigation.Attributes.Add("class", null);

        if (fldRisk.Text.Trim() == "")
        {
            chckErr = false;
            dvRisk.Attributes.Add("class", "has-error");
        }

        if (fldLikelihood.SelectedIndex == 0)
        {
            chckErr = false;
            dvLikelihood.Attributes.Add("class", "has-error");
        }

        if (fldImpact.SelectedIndex == 0)
        {
            chckErr = false;
            dvImpact.Attributes.Add("class", "has-error");
        }

        if (fldMitigation.Text.Trim() == "")
        {
            chckErr = false;
            dvMitigation.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectRisk
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectRisk ";
            queryString = queryString + "               (DescriptionId, ProjectRisk, Likelihood, Impact, Mitigation, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pRisk, @pLikelihood, @pImpact, @pMitigation, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pRisk", fldRisk.Text.Trim());
            cmd.Parameters.AddWithValue("@pLikelihood", fldLikelihood.Text);
            cmd.Parameters.AddWithValue("@pImpact", fldImpact.Text);
            cmd.Parameters.AddWithValue("@pMitigation", fldMitigation.Text.Trim());

            cmd.ExecuteNonQuery();

            //Update Risk Rating in table tblProjectRisk
            SqlCommand cmdRating = new SqlCommand("UPDATE tblProjectRisk SET tblProjectRisk.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblProjectRisk WHERE tblRiskImpact.Likelihood = tblProjectRisk.Likelihood AND tblRiskImpact.Impact = tblProjectRisk.Impact", con);
            
            cmdRating.ExecuteNonQuery();

            con.Close();

            bindProjectRisk();

            fldRisk.Text = "";
            fldLikelihood.Text = "";
            fldImpact.Text = "";
            fldMitigation.Text = "";
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        fldRisk.Text = "";
        fldLikelihood.Text = "";
        fldImpact.Text = "";
        fldMitigation.Text = "";
    }

    protected void btnSaveC_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvRiskC.Attributes.Add("class", null);
        dvLikelihoodC.Attributes.Add("class", null);
        dvImpactC.Attributes.Add("class", null);
        dvMitigationC.Attributes.Add("class", null);

        if (fldRiskC.Text.Trim() == "")
        {
            chckErr = false;
            dvRiskC.Attributes.Add("class", "has-error");
        }

        if (fldLikelihoodC.SelectedIndex == 0)
        {
            chckErr = false;
            dvLikelihoodC.Attributes.Add("class", "has-error");
        }

        if (fldImpactC.SelectedIndex == 0)
        {
            chckErr = false;
            dvImpactC.Attributes.Add("class", "has-error");
        }

        if (fldMitigationC.Text.Trim() == "")
        {
            chckErr = false;
            dvMitigationC.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblContractRisk
            queryString = "";
            queryString = queryString + " INSERT INTO   tblContractRisk ";
            queryString = queryString + "               (DescriptionId, ContractRisk, Likelihood, Impact, Mitigation, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pRisk, @pLikelihood, @pImpact, @pMitigation, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pRisk", fldRiskC.Text.Trim());
            cmd.Parameters.AddWithValue("@pLikelihood", fldLikelihoodC.Text);
            cmd.Parameters.AddWithValue("@pImpact", fldImpactC.Text);
            cmd.Parameters.AddWithValue("@pMitigation", fldMitigationC.Text.Trim());

            cmd.ExecuteNonQuery();

            //Update Risk Rating in table tblContractRisk
            SqlCommand cmdRating = new SqlCommand("UPDATE tblContractRisk SET tblContractRisk.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblContractRisk WHERE tblRiskImpact.Likelihood = tblContractRisk.Likelihood AND tblRiskImpact.Impact = tblContractRisk.Impact", con);

            cmdRating.ExecuteNonQuery();

            con.Close();

            bindContractRisk();

            fldRiskC.Text = "";
            fldLikelihoodC.Text = "";
            fldImpactC.Text = "";
            fldMitigationC.Text = "";
        }
    }

    protected void btnCloseC_Click(object sender, EventArgs e)
    {
        fldRiskC.Text = "";
        fldLikelihoodC.Text = "";
        fldImpactC.Text = "";
        fldMitigationC.Text = "";
    }

    protected void btnSaveE_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvEvaluationCommittee.Attributes.Add("class", null);
        dvRole.Attributes.Add("class", null);

        if (fldEvaluationCommittee.SelectedIndex == 0)
        {
            chckErr = false;
            dvEvaluationCommittee.Attributes.Add("class", "has-error");
        }

        if (fldRole.Text.Trim() == "")
        {
            chckErr = false;
            dvRole.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblEvaluationCommittee
            queryString = "";
            queryString = queryString + " INSERT INTO   tblEvaluationCommittee ";
            queryString = queryString + "               (DescriptionId, CommitteeMember, Role, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pCommitteeMember, @pRole, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pCommitteeMember", fldEvaluationCommittee.Text);
            cmd.Parameters.AddWithValue("@pRole", fldRole.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();

            bindEvaluationCommittee();

            fldEvaluationCommittee.Text = "";
            fldRole.Text = "";
        }
    }

    protected void btnCloseE_Click(object sender, EventArgs e)
    {
        fldEvaluationCommittee.Text = "";
        fldRole.Text = "";
    }


    protected void emailDAL()
    {
        string approval_type = "";

        //Email notification to DAL person
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblOpportunityGoNoGo.ContractType, tblOpportunityGoNoGo.DetailedScopeWork, tblOpportunityGoNoGo.ProjectValue, tblOpportunityGoNoGo.ProjectFees, tblOpportunityGoNoGo.PotentialMargin, tblOpportunityGoNoGo.PotentialBudget, tblOpportunityGoNoGo.BudgetMargin, tblOpportunityGoNoGo.Decision, vwOpportunityGoNoGoApproval.AppBy, tblOpportunityGoNoGo.ReviewedBy, tblOpportunityGoNoGo.DALApproverLevel, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId ";
        qs = qs + "               INNER JOIN vwOpportunityGoNoGoApproval ON tblMain.Id = vwOpportunityGoNoGoApproval.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON vwOpportunityGoNoGoApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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
        client.Host = "smtp.uemedgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (row["DALApproverLevel"].ToString() == "BOD")
        {
            approval_type = "conditionally approve on behalf BOD";
        }
        else if (row["DALApproverLevel"].ToString() == "BOD Comm")
        {
            approval_type = "conditionally approve on behalf BOD Comm.";
        }
        else if (row["DALApproverLevel"].ToString() == "MD/CEO")
        {
            approval_type = "conditionally approve on behalf MD/CEO";
        }
        else
        {
            approval_type = "approve";
        }
        
        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));
          
        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Opportunity Go / No-Go Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "<U>DAL Approval for Submission of Tender Bids / Proposals</U><BR><BR><BR>"

                            + "Hi " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to " + approval_type + " the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Potential Project Value : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectValue"].ToString())) + "<BR><BR>"
                            + "<B>Potential Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFees"].ToString())) + "<BR><BR>"
                            + "<B>Potential Margin : </B>" + row["PotentialMargin"].ToString() + " %<BR><BR>"
                            + "<B>Potential Pursuit Budget : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["PotentialBudget"].ToString())) + "<BR><BR>"
                            + "<B>Potential Pursuit Budget / Margin : </B>" + row["BudgetMargin"].ToString() + "<BR><BR>"
                            + "<B>Contract Type : </B>" + row["ContractType"].ToString() + "<BR><BR>"
                            + "<B>Detailed Scope of Work : </B>" + row["DetailedScopeWork"].ToString() + "<BR><BR>"
                            + "<B>Go / No-Go Recommend : </B>" + row["Decision"].ToString() + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalOpportunityGoNoGo_DAL.aspx?ID=" + row["Id"].ToString() + ">link</A> to approve the opportunity.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }
        
    protected void emailDALCost()
    {
        string approval_type = "";

        //Email notification to DAL person 
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblOpportunityGoNoGo.ContractType, tblOpportunityGoNoGo.DetailedScopeWork, tblOpportunityGoNoGo.ProjectValue, tblOpportunityGoNoGo.ProjectFees, tblOpportunityGoNoGo.PotentialMargin, tblOpportunityGoNoGo.PotentialBudget, tblOpportunityGoNoGo.BudgetMargin, tblOpportunityGoNoGo.Decision, vwOpportunityGoNoGoApprovalCost.AppBy, tblOpportunityGoNoGo.ReviewedBy, tblOpportunityGoNoGo.DALApproverLevelCost, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId ";
        qs = qs + "               INNER JOIN vwOpportunityGoNoGoApprovalCost ON tblMain.Id = vwOpportunityGoNoGoApprovalCost.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON vwOpportunityGoNoGoApprovalCost.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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
        client.Host = "smtp.uemedgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (row["DALApproverLevelCost"].ToString() == "BOD")
        {
            approval_type = "conditionally approve on behalf BOD";
        }
        else if (row["DALApproverLevelCost"].ToString() == "MD/CEO")
        {
            approval_type = "conditionally approve on behalf MD/CEO";
        }
        else
        {
            approval_type = "approve";
        }
        
        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Opportunity Go / No-Go Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "<U>DAL Approval for Costs of Preparing Proposal / Tender</U><BR><BR><BR>"

                            + "Hi " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to "+ approval_type +" the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Potential Project Value : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectValue"].ToString())) + "<BR><BR>"
                            + "<B>Potential Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFees"].ToString())) + "<BR><BR>"
                            + "<B>Potential Margin : </B>" + row["PotentialMargin"].ToString() + " %<BR><BR>"
                            + "<B>Potential Pursuit Budget : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["PotentialBudget"].ToString())) + "<BR><BR>"
                            + "<B>Potential Pursuit Budget / Margin : </B>" + row["BudgetMargin"].ToString() + "<BR><BR>"
                            + "<B>Contract Type : </B>" + row["ContractType"].ToString() + "<BR><BR>"
                            + "<B>Detailed Scope of Work : </B>" + row["DetailedScopeWork"].ToString() + "<BR><BR>"
                            + "<B>Go / No-Go Recommend : </B>" + row["Decision"].ToString() + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalOpportunityGoNoGo_DALCost.aspx?ID=" + row["Id"].ToString() + ">link</A> to approve the opportunity.<BR><BR>"

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
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/RFP/" + lblURLA1.Text + "";

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