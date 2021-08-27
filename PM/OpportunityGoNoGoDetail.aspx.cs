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
using System.Net;
using System.Collections;

public partial class OpportunityGoNoGoDetail : System.Web.UI.Page
{
    string queryString = "";
    string status = "";
    string statusremarks = "";
    DataRow row = null;
    DataRow row1 = null;
    DataRow row2 = null;
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

            checkRole();

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
                DALApprover();
            }

            if (lblDAL_ApprovedStatusCost.Text == "Approved" || lblDAL_ApprovedStatusCost.Text == "Rejected")
            {
                lblDALApproverCost.Visible = true;
                fldDALApprover_COOCost.Visible = false;
                fldDALApproverCost.Visible = false;
            }
            else
            {
                lblDALApproverCost.Visible = false;
                DALApproverCost();
            }

        }
    }

    #region
    protected void fldDecision_SelectedChanged(object sender, EventArgs e)
    {
        if (fldDecision.SelectedItem.Value == "Go")
        {
            dvRemarks.Visible = false;
        }
        else
        {
            dvRemarks.Visible = true;
        }
    }
    #endregion

    protected void checkRole()
    {
        qs = "";
        qs = qs + " SELECT        Role  ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         StaffNo = '" + Session["UserID"].ToString() + "' ";

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

            if (row["Role"].ToString() == "Auditor" || row["Role"].ToString() == "HSE")
            {
                btnUpdate.Visible = false;
                btnSubmit.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnSubmit.Visible = true;
            }
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

    protected void calculateBudgetMargin()
    {
        //Retrieve value for Potential Pursuit Budget / Potential Gross Profit
        qs = "";
        qs = qs + " SELECT        NewValue ";
        qs = qs + " FROM          vwCalculateBudgetMargin ";
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
            DataRow row1 = dt1.Rows[0];

            float value;

            value = float.Parse(row1["NewValue"].ToString());
            fldBudgetMargin.Text = value.ToString(".00");
            lblBudgetMargin.Text = row1["NewValue"].ToString();

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdUpdate = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                    + "BudgetMargin = " + row1["NewValue"].ToString() + " "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            cmdUpdate.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        updateOpportunity();

        calculateBudgetMargin();

        Response.Redirect("OpportunityGoNoGoDetail.aspx?Id=" + Request.QueryString["Id"]);
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

            //fldScore.Text = row["GrandTotal"].ToString();
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
        //qs = "";
        //qs = qs + " SELECT        tblOpportunityGoNoGo.*, tblMain.Code, tblMain.OldCode, ";
        //qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        //qs = qs + "               StaffLogin.StaffName AS COOApproverName ";
        //qs = qs + " FROM          tblOpportunityGoNoGo ";
        //qs = qs + " INNER JOIN    tblMain ON tblOpportunityGoNoGo.DescriptionId = tblMain.Id ";
        //qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN     StaffLogin ON tblOpportunityGoNoGo.ApprovedByCOO = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        //qs = qs + " WHERE         tblOpportunityGoNoGo.DescriptionId = '" + Request.QueryString["Id"] + "' ";

        //qs = "";
        //qs = qs + " SELECT        tblOpportunityGoNoGo.*, tblMain.Code, tblMain.OldCode, vwOpportunityGoNoGoApproval.AppBy, ";
        //qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        //qs = qs + "               tblCOO.StaffName AS COOApproverName, ";
        //qs = qs + "               tblDAL.StaffName AS DALApproverName ";
        //qs = qs + " FROM          tblOpportunityGoNoGo ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCOO ON tblCOO.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ApprovedByCOO COLLATE DATABASE_DEFAULT ";
        //qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.tblMain.Id ";
        //qs = qs + " INNER JOIN dbo.vwOpportunityGoNoGoApproval ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.vwOpportunityGoNoGoApproval.DescriptionId ";
        //qs = qs + " INNER JOIN dbo.StaffLogin AS tblDAL ON dbo.vwOpportunityGoNoGoApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
        //qs = qs + " WHERE         tblOpportunityGoNoGo.DescriptionId = '" + Request.QueryString["Id"] + "' ";

        //qs = "";
        //qs = qs + " SELECT DISTINCT         tblOpportunityGoNoGo.*, tblMain.Code, tblMain.OldCode, vwOpportunityGoNoGoApproval.AppBy, ";
        //qs = qs + "                         tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "                         tblUPDATEBY.StaffName As UPDATEBYName,  ";
        //qs = qs + "                         tblCOO.StaffName AS COOApproverName, ";
        //qs = qs + "                         tblDAL.StaffName AS DALApproverName ";
        //qs = qs + " FROM                    tblOpportunityGoNoGo ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCOO ON tblCOO.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblOpportunityGoNoGo.ApprovedByCOO COLLATE DATABASE_DEFAULT ";
        //qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.tblMain.Id ";
        //qs = qs + " LEFT OUTER JOIN dbo.vwOpportunityGoNoGoApproval ON dbo.tblOpportunityGoNoGo.DescriptionId = dbo.vwOpportunityGoNoGoApproval.DescriptionId ";
        //qs = qs + " LEFT OUTER JOIN  dbo.StaffLogin AS tblDAL ON dbo.vwOpportunityGoNoGoApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
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
                hidURLA1.Value = "http://pec.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/RFP/" + row["RFP"].ToString() + "";
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

            //Remarks 
            fldRemarks.Text = row["Remarks"].ToString();

            if (row["Decision"].ToString() == "No-Go")
            {
                dvCode.Visible = false;
                dvRemarks.Visible = true;
            }
            else if (row["Decision"].ToString() == "Go")
            {
                dvCode.Visible = true;
                dvRemarks.Visible = false;
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

                btnCalculate.Enabled = true;

                btnProjectRisk.Visible = true;
                btnContractRisk.Visible = true;
                btnEvaluationPerson.Visible = true;

                btnUpdate.Enabled = true;
                btnSubmit.Enabled = true;
                btnDrop.Visible = false;

                DALApprover();
                DALApproverCost();
            }
            else
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;
                btnDeleteA1.Visible = false;

                btnCalculate.Enabled = false;

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

                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;

                if (row["Decision"].ToString() == "No-Go")
                {
                    btnDrop.Visible = false;
                }
                else if (row["Decision"].ToString() == "Go")
                {
                    btnDrop.Visible = true;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateOpportunity();
        updateDAL();
        updateDALCost();

        Response.Redirect("OpportunityGoNoGoDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        Boolean chckErr = true;

        decimal ProjectFees_Value;
        ProjectFees_Value = Convert.ToDecimal(fldProjectFees.Text.Trim());

        //Reset error
        dvClientNature.Attributes.Add("class", null);
        dvStrategicClient.Attributes.Add("class", null);
        dvStatusRel.Attributes.Add("class", null);
        dvPymntHistory.Attributes.Add("class", null);

        dvCompetitorNo.Attributes.Add("class", null);
        dvCompetitorList.Attributes.Add("class", null);
        dvCanCompete.Attributes.Add("class", null);
        dvMaterializingPercent.Attributes.Add("class", null);
        dvWinningPercent.Attributes.Add("class", null);

        dvProjectValue.Attributes.Add("class", null);
        dvProjectFees.Attributes.Add("class", null);
        dvPotentialMargin.Attributes.Add("class", null);
        dvPotentialBudget.Attributes.Add("class", null);

        dvContractType.Attributes.Add("class", null);
        dvContractDuration.Attributes.Add("class", null);
        dvDetailedScopeWork.Attributes.Add("class", null);
        dvOurCapability.Attributes.Add("class", null);
        dvOurDifferentiation.Attributes.Add("class", null);
        dvTrackRecord.Attributes.Add("class", null);
        dvPartnerReq.Attributes.Add("class", null);

        //dvScore.Attributes.Add("class", null);
        dvEvaluationPerson.Attributes.Add("class", null);
        dvEvaluationComment.Attributes.Add("class", null);
        dvDecision.Attributes.Add("class", null);

        dvDALApproval.Attributes.Add("class", null);

        if (fldClientNature.Text.Trim() == "")
        {
            chckErr = false;
            dvClientNature.Attributes.Add("class", "has-error");
        }

        if (fldStrategicClient.SelectedIndex == 0)
        {
            chckErr = false;
            dvStrategicClient.Attributes.Add("class", "has-error");
        }

        if (fldStatusRel.SelectedIndex == 0)
        {
            chckErr = false;
            dvStatusRel.Attributes.Add("class", "has-error");
        }

        if (fldPymntHistory.SelectedIndex == 0)
        {
            chckErr = false;
            dvPymntHistory.Attributes.Add("class", "has-error");
        }

        if (fldCompetitorNo.SelectedIndex == 0)
        {
            chckErr = false;
            dvCompetitorNo.Attributes.Add("class", "has-error");
        }

        if (fldCompetitorList.Text.Trim() == "")
        {
            chckErr = false;
            dvCompetitorList.Attributes.Add("class", "has-error");
        }

        if (fldCanCompete.SelectedIndex == 0)
        {
            chckErr = false;
            dvCanCompete.Attributes.Add("class", "has-error");
        }

        if (fldMaterializingPercent.Text.Trim() == "")
        {
            chckErr = false;
            dvMaterializingPercent.Attributes.Add("class", "has-error");
        }

        if (fldWinningPercent.Text.Trim() == "")
        {
            chckErr = false;
            dvWinningPercent.Attributes.Add("class", "has-error");
        }

        if (fldProjectValue.Text.Trim() == "")
        {
            chckErr = false;
            dvProjectValue.Attributes.Add("class", "has-error");
        }

        if (fldProjectFees.Text.Trim() == "")
        {
            chckErr = false;
            dvProjectFees.Attributes.Add("class", "has-error");
        }

        if (fldPotentialMargin.Text.Trim() == "")
        {
            chckErr = false;
            dvPotentialMargin.Attributes.Add("class", "has-error");
        }

        if (fldPotentialBudget.Text.Trim() == "")
        {
            chckErr = false;
            dvPotentialBudget.Attributes.Add("class", "has-error");
        }

        if (fldContractType.SelectedIndex == 0)
        {
            chckErr = false;
            dvContractType.Attributes.Add("class", "has-error");
        }

        if (fldContractDuration.Text.Trim() == "")
        {
            chckErr = false;
            dvContractDuration.Attributes.Add("class", "has-error");
        }

        if (fldDetailedScopeWork.Text.Trim() == "")
        {
            chckErr = false;
            dvDetailedScopeWork.Attributes.Add("class", "has-error");
        }

        if (fldOurCapability.SelectedIndex == 0)
        {
            chckErr = false;
            dvOurCapability.Attributes.Add("class", "has-error");
        }

        if (fldOurDifferentiation.Text.Trim() == "")
        {
            chckErr = false;
            dvOurDifferentiation.Attributes.Add("class", "has-error");
        }

        if (fldTrackRecord.SelectedIndex == 0)
        {
            chckErr = false;
            dvTrackRecord.Attributes.Add("class", "has-error");
        }

        if (fldPartnerReq.SelectedIndex == 0)
        {
            chckErr = false;
            dvPartnerReq.Attributes.Add("class", "has-error");
        }

        //if (ProjectFees_Value >= 10000000)
        //{
        //    if (fldScore.Text.Trim() == "")
        //    {
        //        chckErr = false;
        //        dvScore.Attributes.Add("class", "has-error");
        //    }
        //}

        if (lblCheckEvaluation.Text.Trim() == "No")
        {
            chckErr = false;
            dvEvaluationPerson.Attributes.Add("class", "has-error");
        }

        if (fldEvaluationComment.Text.Trim() == "")
        {
            chckErr = false;
            dvEvaluationComment.Attributes.Add("class", "has-error");
        }

        if (fldDecision.SelectedIndex == 0)
        {
            chckErr = false;
            dvDecision.Attributes.Add("class", "has-error");
        }

        if (fldDALApprover.SelectedIndex == 0 && fldDALApprover_COO.SelectedIndex == 0 && fldDALApprover_HOD.SelectedIndex == 0)
        {
            chckErr = false;
            dvDALApproval.Attributes.Add("class", "has-error");
        }

        if (fldDALApproverCost.SelectedIndex == 0 && fldDALApprover_COOCost.SelectedIndex == 0)
        {
            chckErr = false;
            dvDALApprovalCost.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            updateOpportunity();
            updateDAL();
            updateDALCost();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            if (fldDecision.SelectedValue == "Go")
            {
                //DAL Approval 1.3
                if (fldDALApprover_COO.SelectedIndex != 0)
                {
                    this.PrepareRemove(gvEvaluationPerson); //remove button
                    emailDAL();
                }
                else
                {
                    this.PrepareRemove(gvEvaluationPerson);
                    emailDAL();
                }

                //DAL Approval 1.4
                if (fldDALApproverCost.SelectedIndex != 0)
                {
                    this.PrepareRemove(gvEvaluationPerson);
                    emailDALCost();
                }
                else
                {
                    this.PrepareRemove(gvEvaluationPerson);
                    emailDALCost();
                }

            }

            Response.Redirect("OpportunityGoNoGoDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }


    protected void updateOpportunity()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblOpportunityGoNoGo
        SqlCommand cmd = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                + "ClientNature = @pClientNature, "
                + "StrategicClient = @pStrategicClient, "
                + "StrategicClientComment = @pStrategicClientComment, "
                + "StatusRel = @pStatusRel, "
                + "PymntHistory = @pPymntHistory, "
                + "CompetitorNo = @pCompetitorNo, "
                + "CompetitorList = @pCompetitorList, "
                + "CanCompete = @pCanCompete, "
                + "CanCompeteComment = @pCanCompeteComment, "
                + "MaterializingPercent = @pMaterializingPercent, "
                + "MaterializingComment = @pMaterializingComment, "
                + "WinningPercent = @pWinningPercent, "
                + "WinningComment = @pWinningComment, "
                + "ProjectValue = @pProjectValue, "
                + "ProjectFees = @pProjectFees, "
                + "PotentialMargin = @pPotentialMargin, "
                + "PotentialBudget = @pPotentialBudget, "
                + "BudgetMargin = @pBudgetMargin, "
                + "ContractType = @pContractType, "
                + "ContractDuration = @pContractDuration, "
                + "DetailedScopeWork = @pDetailedScopeWork, "
                + "OurCapability = @pOurCapability, "
                + "OurCapabilityComment = @pOurCapabilityComment, "
                + "OurDifferentiation = @pOurDifferentiation, "
                + "TrackRecord = @pTrackRecord, "
                + "PartnerReq = @pPartnerReq, "
                + "PartnerReqComment = @pPartnerReqComment, "
                + "EvaluationComment = @pEvaluationComment, "
                + "Decision = @pDecision, "
                + "Remarks = @pRemarks, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //--------------------------------------- Client ---------------------------------------
        //Nature of Client
        cmd.Parameters.AddWithValue("@pClientNature", fldClientNature.Text.Trim());

        //Strategic Client?
        cmd.Parameters.AddWithValue("@pStrategicClient", fldStrategicClient.Text.Trim());
        cmd.Parameters.AddWithValue("@pStrategicClientComment", fldStrategicClientComment.Text.Trim());

        //Status of Relationship
        if (fldStatusRel.Text != "")
            cmd.Parameters.AddWithValue("@pStatusRel", fldStatusRel.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pStatusRel", DBNull.Value);

        //Payment History
        if (fldPymntHistory.Text != "")
            cmd.Parameters.AddWithValue("@pPymntHistory", fldPymntHistory.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPymntHistory", DBNull.Value);

        //--------------------------------------- Competition ---------------------------------------
        //How Many?
        cmd.Parameters.AddWithValue("@pCompetitorNo", fldCompetitorNo.Text.Trim());

        //Who Are The Competitors?
        cmd.Parameters.AddWithValue("@pCompetitorList", fldCompetitorList.Text.Trim());

        //Can We Compete?
        if (fldCanCompete.Text != "")
            cmd.Parameters.AddWithValue("@pCanCompete", fldCanCompete.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pCanCompete", DBNull.Value);
        cmd.Parameters.AddWithValue("@pCanCompeteComment", fldCanCompeteComment.Text.Trim());

        //Chances of Project Materializing
        cmd.Parameters.AddWithValue("@pMaterializingPercent", fldMaterializingPercent.Text.Trim());
        cmd.Parameters.AddWithValue("@pMaterializingComment", fldMaterializingComment.Text.Trim());

        //Chances of Winning
        cmd.Parameters.AddWithValue("@pWinningPercent", fldWinningPercent.Text.Trim());
        cmd.Parameters.AddWithValue("@pWinningComment", fldWinningComment.Text.Trim());

        //--------------------------------------- Finances ---------------------------------------
        //Potential Project Value 
        //cmd.Parameters.AddWithValue("@pProjectValue", fldProjectValue.Text);
        cmd.Parameters.AddWithValue("@pProjectValue", fldProjectValue.Text.Replace(",", ""));

        //Potential Project Fees
        //cmd.Parameters.AddWithValue("@pProjectFees", fldProjectFees.Text);
        cmd.Parameters.AddWithValue("@pProjectFees", fldProjectFees.Text.Replace(",", ""));

        //Potential Margin 
        //cmd.Parameters.AddWithValue("@pPotentialMargin", fldPotentialMargin.Text);
        cmd.Parameters.AddWithValue("@pPotentialMargin", fldPotentialMargin.Text.Replace(",", ""));

        //Potential Pursuit Budget 
        //cmd.Parameters.AddWithValue("@pPotentialBudget", fldPotentialBudget.Text);
        cmd.Parameters.AddWithValue("@pPotentialBudget", fldPotentialBudget.Text.Replace(",", ""));

        //Potential Pursuit Budget / Margin
        cmd.Parameters.AddWithValue("@pBudgetMargin", fldBudgetMargin.Text);

        //--------------------------------------- Project Specific ---------------------------------------
        //Contract Type 
        if (fldContractType.Text != "")
            cmd.Parameters.AddWithValue("@pContractType", fldContractType.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pContractType", DBNull.Value);

        //Contract Duration  
        cmd.Parameters.AddWithValue("@pContractDuration", fldContractDuration.Text.Trim());

        //Detailed Scope of Work
        cmd.Parameters.AddWithValue("@pDetailedScopeWork", fldDetailedScopeWork.Text.Trim());

        //Our Capability to Execute 
        if (fldOurCapability.Text != "")
            cmd.Parameters.AddWithValue("@pOurCapability", fldOurCapability.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pOurCapability", DBNull.Value);
        cmd.Parameters.AddWithValue("@pOurCapabilityComment", fldOurCapabilityComment.Text.Trim());

        //Our Differentiation 
        cmd.Parameters.AddWithValue("@pOurDifferentiation", fldOurDifferentiation.Text.Trim());

        //Do We Have Track Record / Experience? 
        if (fldTrackRecord.Text != "")
            cmd.Parameters.AddWithValue("@pTrackRecord", fldTrackRecord.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pTrackRecord", DBNull.Value);

        //Partner Required?  
        if (fldPartnerReq.Text != "")
            cmd.Parameters.AddWithValue("@pPartnerReq", fldPartnerReq.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPartnerReq", DBNull.Value);
        cmd.Parameters.AddWithValue("@pPartnerReqComment", fldPartnerReqComment.Text.Trim());

        //--------------------------------------- Evaluation ---------------------------------------
        //Evaluation Comment / Justification 
        cmd.Parameters.AddWithValue("@pEvaluationComment", fldEvaluationComment.Text.Trim());

        //Go / No-Go Recommend 
        if (fldDecision.Text != "")
            cmd.Parameters.AddWithValue("@pDecision", fldDecision.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pDecision", DBNull.Value);

        //Remarks 
        cmd.Parameters.AddWithValue("@pRemarks", fldRemarks.Text.Trim());

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();

        //Update in table tblMain
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        if (fldDecision.Text == "No-Go")
        {
            status = "InActive";
            statusremarks = "No-Go";
        }
        else if (fldDecision.Text == "Go")
        {
            status = "Active";
            statusremarks = "";
        }

        SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
                + "Phase = 'Opportunity Go / No-Go', "
                + "Status = '" + status + "', "
                + "StatusRemarks = '" + statusremarks + "', "
                + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        cmdMain.ExecuteNonQuery();

        con.Close();
    }

    protected void updateDAL()
    {
        //Check DAL Approval based on Potential Project Fees
        qs = "";
        qs = qs + " SELECT        ProjectFees ";
        qs = qs + " FROM          tblOpportunityGoNoGo ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd1 = new SqlCommand(qs, con);
        cmd1.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count != 0)
        {
            DataRow row1 = dt1.Rows[0];

            //Update in table tblOpportunityGoNoGo
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdApproval = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                    + "DALApproverLevel = @pApproverLevel, "
                    + "DALApprovedBy_HOD = @pApprovedBy_HOD, "
                    + "DALApprovedBy_COO = @pApprovedBy_COO, "
                    + "DALApprovedBy = @pApprovedBy "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            //Refer to DAL (Discretionary Authority Limits) table 
            decimal ProjectFees_Value;
            ProjectFees_Value = Convert.ToDecimal(row1["ProjectFees"].ToString());

            if (ProjectFees_Value == 10000000 || ProjectFees_Value <= 10000000)
            {
                //Approved by Head of Division
                //Potential Project Fees - Equal or below 10m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "Head of Division");

                //Approved By - Head of Division
                if (fldDALApprover_HOD.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", fldDALApprover_HOD.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

                //Approved By - MD/CEO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

            }
            else if (ProjectFees_Value == 50000000 || ProjectFees_Value <= 50000000)
            {
                //Approved by COO
                //Potential Project Fees - Equal or below 50m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "COO");

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                if (fldDALApprover_COO.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", fldDALApprover_COO.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

                //Approved By - MD/CEO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

            }
            else if (ProjectFees_Value == 100000000 || ProjectFees_Value <= 100000000)
            {
                //Approved by MD/CEO
                //Potential Project Fees - Equal or below 100m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "MD/CEO");

                //Approved By - MD/CEO
                if (fldDALApprover.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }
            else if (ProjectFees_Value == 200000000 || ProjectFees_Value <= 200000000)
            {
                //Approved by BOD Comm.
                //Potential Project Fees - Equal or below 200m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "BOD Comm");

                //Approved By - MD/CEO
                if (fldDALApprover.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }
            else if (ProjectFees_Value > 200000000)
            {
                //Approved by BOD
                //Potential Project Fees - Above 200m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "BOD");

                //Approved By - MD/CEO
                if (fldDALApprover.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }

            cmdApproval.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void updateDALCost()
    {
        //Check DAL Approval based on Potential Pursuit Budget
        qs1 = "";
        qs1 = qs1 + " SELECT        PotentialBudget ";
        qs1 = qs1 + " FROM          tblOpportunityGoNoGo ";
        qs1 = qs1 + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd2 = new SqlCommand(qs1, con);
        cmd2.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        con.Close();

        if (dt2.Rows.Count != 0)
        {
            DataRow row2 = dt2.Rows[0];

            //Update in table tblOpportunityGoNoGo
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdApprovalCost = new SqlCommand("UPDATE tblOpportunityGoNoGo SET "
                    + "DALApproverLevelCost = @pApproverLevelCost, "
                    + "DALApprovedBy_COOCost = @pApprovedBy_COOCost, "
                    + "DALApprovedByCost = @pApprovedByCost "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            //Refer to DAL (Discretionary Authority Limits) table 
            decimal PotentialBudget_Value;
            PotentialBudget_Value = Convert.ToDecimal(row2["PotentialBudget"].ToString());

            if (PotentialBudget_Value == 500000 || PotentialBudget_Value <= 500000)
            {
                //Approved by COO
                //Potential Pursuit Budget - Equal or below 500k

                //DAL Approver Level
                cmdApprovalCost.Parameters.AddWithValue("@pApproverLevelCost", "COO");

                //Approved By - COO
                if (fldDALApprover_COOCost.Text != "")
                    cmdApprovalCost.Parameters.AddWithValue("@pApprovedBy_COOCost", fldDALApprover_COOCost.SelectedValue);
                else
                    cmdApprovalCost.Parameters.AddWithValue("@pApprovedBy_COOCost", DBNull.Value);

                //Approved By - MD/CEO
                cmdApprovalCost.Parameters.AddWithValue("@pApprovedByCost", DBNull.Value);

            }
            else if (PotentialBudget_Value == 2000000 || PotentialBudget_Value <= 2000000)
            {
                //Approved by MD/CEO
                //Potential Pursuit Budget - Equal or below 2m

                //DAL Approver Level
                cmdApprovalCost.Parameters.AddWithValue("@pApproverLevelCost", "MD/CEO");

                //Approved By - COO
                cmdApprovalCost.Parameters.AddWithValue("@pApprovedBy_COOCost", DBNull.Value);

                //Approved By - MD/CEO
                if (fldDALApproverCost.Text != "")
                    cmdApprovalCost.Parameters.AddWithValue("@pApprovedByCost", fldDALApproverCost.SelectedValue);
                else
                    cmdApprovalCost.Parameters.AddWithValue("@pApprovedByCost", DBNull.Value);

            }
            else if (PotentialBudget_Value > 2000000)
            {
                //Approved by BOD
                //Potential Pursuit Budget - Above 2m

                //DAL Approver Level
                cmdApprovalCost.Parameters.AddWithValue("@pApproverLevelCost", "BOD");

                //Approved By - COO
                cmdApprovalCost.Parameters.AddWithValue("@pApprovedBy_COOCost", DBNull.Value);

                //Approved By - MD/CEO
                if (fldDALApproverCost.Text != "")
                    cmdApprovalCost.Parameters.AddWithValue("@pApprovedByCost", fldDALApproverCost.SelectedValue);
                else
                    cmdApprovalCost.Parameters.AddWithValue("@pApprovedByCost", DBNull.Value);

            }

            cmdApprovalCost.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnDrop_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        //Update in table tblMain
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
                + "Phase = 'Proposal Close' "
                + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        cmdMain.ExecuteNonQuery();

        //Check if this project already exist in tblProposalClose
        qs = "";
        qs = qs + " SELECT        DescriptionId ";
        qs = qs + " FROM          tblProposalClose ";
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
            //Insert into table tblProposalClose
            qs1 = "";
            qs1 = qs1 + " INSERT INTO   tblProposalClose ";
            qs1 = qs1 + "               (DescriptionId, Status, DateCreated) ";
            qs1 = qs1 + " VALUES        (@pDescriptionId, 'Proposal Dropped', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs1, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["Id"]);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        Response.Redirect("ProposalCloseDetail.aspx?Id=" + Request.QueryString["Id"]);
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

            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    gvProjectRisk.HeaderRow.Cells[6].Visible = true;
            //    gvProjectRisk.HeaderRow.Cells[7].Visible = true;
            //}
            //else
            //{
            //    gvProjectRisk.HeaderRow.Cells[6].Visible = false;
            //    gvProjectRisk.HeaderRow.Cells[7].Visible = false;
            //}

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

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            //    HeaderGridRow.Cells.Add(HeaderCell);
            //}

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

            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    e.Row.Cells[6].Enabled = true;
            //    e.Row.Cells[7].Enabled = true;
            //}
            //else
            //{
            //    e.Row.Cells[6].Enabled = false;
            //    e.Row.Cells[7].Enabled = false;
            //}
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

            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    gvContractRisk.HeaderRow.Cells[6].Visible = true;
            //    gvContractRisk.HeaderRow.Cells[7].Visible = true;
            //}
            //else
            //{
            //    gvContractRisk.HeaderRow.Cells[6].Visible = false;
            //    gvContractRisk.HeaderRow.Cells[7].Visible = false;
            //}

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

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderCell.ColumnSpan = 1;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            //    HeaderGridRow.Cells.Add(HeaderCell);
            //}

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
            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    e.Row.Cells[6].Enabled = true;
            //    e.Row.Cells[7].Enabled = true;
            //}
            //else
            //{
            //    e.Row.Cells[6].Enabled = false;
            //    e.Row.Cells[7].Enabled = false;
            //}
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

            //if (lblBtnSubmit.Text == null && lblBtnSubmit.Text == "")
            //{
            //    gvEvaluationPerson.HeaderRow.Cells[3].Visible = true;
            //    gvEvaluationPerson.HeaderRow.Cells[4].Visible = true;
            //}
            //else
            //{
            //    gvEvaluationPerson.HeaderRow.Cells[3].Visible = false;
            //    gvEvaluationPerson.HeaderRow.Cells[4].Visible = false;
            //}

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

            HeaderCell = new TableCell();
            //HeaderCell.RowSpan = 1;
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Text = "";
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
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

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
            //if (lblBtnSubmit.Text != "")
            //{
            //    e.Row.Cells[3].Enabled = false;
            //    e.Row.Cells[4].Enabled = false;
            //}
            //else if (lblBtnSubmit.Text != "")
            //{
            //    e.Row.Cells[3].Enabled = true;
            //    e.Row.Cells[4].Enabled = true;
            //}
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

    #region emailDAL
    protected void emailDAL()
    {
        int ID = int.Parse(Request.QueryString["Id"]);
        string approval_type = "";
        ArrayList emailCCArray = new ArrayList();

        //Email notification to DAL person
        //---------------------------------------- send email -----------------------------------------        

        using (con)
        {
            using (SqlCommand cmd = new SqlCommand("spEmailDAL", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = "smtp2.edgenta.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("user", "Password");

                if (dt.Rows[0]["DALApproverLevel"].ToString() == "BOD")
                {
                    approval_type = "conditionally approve on behalf BOD";
                }
                else if (dt.Rows[0]["DALApproverLevel"].ToString() == "BOD Comm")
                {
                    approval_type = "conditionally approve on behalf BOD Comm.";
                }
                else if (dt.Rows[0]["DALApproverLevel"].ToString() == "MD/CEO")
                {
                    approval_type = "conditionally approve on behalf MD/CEO";
                }
                else
                {
                    approval_type = "approve";
                }

                //get emailCC
                foreach (DataRow rowCC in dt.Rows)
                {
                    //emailCCArray.Add(rowCC["CommitteeEmail"]);
                }

                objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

                foreach (string emailCC in emailCCArray)
                {
                    //objeto_mail.CC.Add(emailCC);
                }

                if(string.IsNullOrEmpty(dt.Rows[0]["SecretaryEmail"].ToString()))
                {
                    
                }
                else
                {
                    //objeto_mail.CC.Add(new MailAddress(dt.Rows[0]["SecretaryEmail"].ToString()));
                }

                if (string.IsNullOrEmpty(dt.Rows[0]["PAEmail"].ToString()))
                {
                    
                }
                else
                {
                    //objeto_mail.CC.Add(new MailAddress(dt.Rows[0]["PAEmail"].ToString()));
                }

                //objeto_mail.To.Add(new MailAddress(dt.Rows[0]["DALEmail"].ToString()));
                objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));                   

                objeto_mail.Subject = "Request for Opportunity Go / No-Go Approval for '" + dt.Rows[0]["Description"].ToString() + "'";

                //get evaluate committee (create table)
                string eva_committee = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#828282'><td><b>Evaluation Person / Committee</b></td> <td> <b>Role</b> </td></tr>";

                for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
                {
                    eva_committee += "<tr><td>" + dt.Rows[loopCount]["CommitteeName"] + "</td><td> " + dt.Rows[loopCount]["Role"] + "</td> </tr>";
                }

                eva_committee += "</table>";

                string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                                            + "<U>DAL Approval for Submission of Tender Bids / Proposals</U><BR><BR><BR>"

                                            + "Hi " + dt.Rows[0]["DALName"].ToString() + ",<BR><BR><BR>"

                                            + "You are required to " + approval_type + " the following opportunity :<BR><BR><BR>"

                                            + "<B>Operating Company : </B>" + dt.Rows[0]["OperatingCompany"].ToString() + "<BR><BR>"
                                            + "<B>Opportunity Name : </B>" + dt.Rows[0]["Description"].ToString() + "<BR><BR>"
                                            + "<B>Client Name : </B>" + dt.Rows[0]["ClientName"].ToString() + "<BR><BR>"
                                            + "<B>Project Manager : </B>" + dt.Rows[0]["PMName"].ToString() + "<BR><BR>"
                                            + "<B>Potential Project Value : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(dt.Rows[0]["ProjectValue"].ToString())) + "<BR><BR>"
                                            + "<B>Potential Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(dt.Rows[0]["ProjectFees"].ToString())) + "<BR><BR>"
                                            + "<B>Potential Margin : </B>" + dt.Rows[0]["PotentialMargin"].ToString() + " %<BR><BR>"
                                            + "<B>Potential Pursuit Budget : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(dt.Rows[0]["PotentialBudget"].ToString())) + "<BR><BR>"
                                            + "<B>Potential Pursuit Budget / Margin : </B>" + dt.Rows[0]["BudgetMargin"].ToString() + "<BR><BR>"
                                            + "<B>Contract Type : </B>" + dt.Rows[0]["ContractType"].ToString() + "<BR><BR>"
                                            + "<B>Detailed Scope of Work : </B>" + dt.Rows[0]["DetailedScopeWork"].ToString() + "<BR><BR>"
                                            + "<B>Evaluation Committee : <hr />" + eva_committee + "<BR><BR>"
                                            + "<B>Go / No-Go Recommend : </B>" + dt.Rows[0]["Decision"].ToString() + "<BR><BR><BR>"

                                            + "Click on this <A HREF=http://pec.uemedgenta.com/PM/ApprovalOpportunityGoNoGo_DAL.aspx?ID=" + dt.Rows[0]["Id"].ToString() + ">link</A> to approve the opportunity.<BR><BR>"

                                            + "<BR><BR><BR>Thank you.<BR><BR>"
                                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

                objeto_mail.Body = htmlText;
                objeto_mail.IsBodyHtml = true;

                client.Send(objeto_mail);
            }
        }
        //---------------------------------- end of send email ----------------------------------------
    }
    #endregion 

    #region emailDALCost
    protected void emailDALCost()
    {
        int ID = int.Parse(Request.QueryString["Id"]);
        string approval_type2 = "";
        ArrayList emailCostCCArray = new ArrayList();

        using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
        {
            using (SqlCommand cmd2 = new SqlCommand("spEmailDALCost", con2))
            {
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;

                con2.Open();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con2.Close();

                MailMessage objeto_mailCost = new MailMessage();
                SmtpClient clientCost = new SmtpClient();
                clientCost.Port = 25;
                clientCost.Host = "smtp2.edgenta.com";
                clientCost.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientCost.UseDefaultCredentials = false;
                clientCost.Credentials = new System.Net.NetworkCredential("user", "Password");

                if (dt2.Rows[0]["DALApproverLevelCost"].ToString() == "BOD")
                {
                    approval_type2 = "conditionally approve on behalf BOD";
                }
                else if (dt2.Rows[0]["DALApproverLevelCost"].ToString() == "MD/CEO")
                {
                    approval_type2 = "conditionally approve on behalf MD/CEO";
                }
                else
                {
                    approval_type2 = "approve";
                }

                //get emailCC
                foreach (DataRow rowCostCC in dt2.Rows)
                {
                    //emailCostCCArray.Add(rowCostCC["CommitteeEmail"]);
                }

                objeto_mailCost.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

                foreach (string emailCostCC in emailCostCCArray)
                {
                    //objeto_mailCost.CC.Add(emailCostCC);
                }

                if (string.IsNullOrEmpty(dt2.Rows[0]["SecretaryEmail"].ToString()))
                {

                }
                else
                {
                    //objeto_mailCost.CC.Add(new MailAddress(dt2.Rows[0]["SecretaryEmail"].ToString()));
                }

                if (string.IsNullOrEmpty(dt2.Rows[0]["PAEmail"].ToString()))
                {

                }
                else
                {
                    //objeto_mailCost.CC.Add(new MailAddress(dt2.Rows[0]["PAEmail"].ToString()));
                }

                //objeto_mailCost.To.Add(new MailAddress(dt2.Rows[0]["DALEmail"].ToString()));
                objeto_mailCost.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

                objeto_mailCost.Subject = "Request for Opportunity Go / No-Go Approval for '" + dt2.Rows[0]["Description"].ToString() + "'";

                //get evaluate committee (create table)
                string eva_committeeCost = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#828282'><td><b>Evaluation Person / Committee</b></td> <td> <b>Role</b> </td></tr>";

                for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
                {
                    eva_committeeCost += "<tr><td>" + dt2.Rows[loopCount]["CommitteeName"] + "</td><td> " + dt2.Rows[loopCount]["Role"] + "</td> </tr>";
                }

                eva_committeeCost += "</table>";

                string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                                    + "<U>DAL Approval for Costs of Preparing Proposal / Tender</U><BR><BR><BR>"

                                    + "Hi " + dt2.Rows[0]["DALName"].ToString() + ",<BR><BR><BR>"

                                    + "You are required to " + approval_type2 + " the following opportunity :<BR><BR><BR>"

                                    + "<B>Operating Company : </B>" + dt2.Rows[0]["OperatingCompany"].ToString() + "<BR><BR>"
                                    + "<B>Opportunity Name : </B>" + dt2.Rows[0]["Description"].ToString() + "<BR><BR>"
                                    + "<B>Client Name : </B>" + dt2.Rows[0]["ClientName"].ToString() + "<BR><BR>"
                                    + "<B>Project Manager : </B>" + dt2.Rows[0]["PMName"].ToString() + "<BR><BR>"
                                    + "<B>Potential Project Value : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(dt2.Rows[0]["ProjectValue"].ToString())) + "<BR><BR>"
                                    + "<B>Potential Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(dt2.Rows[0]["ProjectFees"].ToString())) + "<BR><BR>"
                                    + "<B>Potential Margin : </B>" + dt2.Rows[0]["PotentialMargin"].ToString() + " %<BR><BR>"
                                    + "<B>Potential Pursuit Budget : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(dt2.Rows[0]["PotentialBudget"].ToString())) + "<BR><BR>"
                                    + "<B>Potential Pursuit Budget / Margin : </B>" + dt2.Rows[0]["BudgetMargin"].ToString() + "<BR><BR>"
                                    + "<B>Contract Type : </B>" + dt2.Rows[0]["ContractType"].ToString() + "<BR><BR>"
                                    + "<B>Detailed Scope of Work : </B>" + dt2.Rows[0]["DetailedScopeWork"].ToString() + "<BR><BR>"
                                    + "<B>Evaluation Committee : <hr />" + eva_committeeCost + "<BR><BR>"
                                    + "<B>Go / No-Go Recommend : </B>" + dt2.Rows[0]["Decision"].ToString() + "<BR><BR><BR>"

                                    + "Click on this <A HREF=http://pec.uemedgenta.com/PM/ApprovalOpportunityGoNoGo_DALCost.aspx?ID=" + dt2.Rows[0]["Id"].ToString() + ">link</A> to approve the opportunity.<BR><BR>"

                                    + "<BR><BR><BR>Thank you.<BR><BR>"
                                    + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

                objeto_mailCost.Body = htmlText;
                objeto_mailCost.IsBodyHtml = true;

                clientCost.Send(objeto_mailCost);
            }
        }
        
        //---------------------------------- end of send email ----------------------------------------
    }
    #endregion

    #region RemoveButton
    private void PrepareRemove(Control ctrl)
    {
        foreach (Control childControl in ctrl.Controls)
        {
            if (childControl.GetType() == typeof(ImageButton))
            {
                this.gvEvaluationPerson.HeaderRow.Cells[3].Visible = false;
                this.gvEvaluationPerson.HeaderRow.Cells[4].Visible = false;
                this.gvEvaluationPerson.Columns[3].Visible = false;
                this.gvEvaluationPerson.Columns[4].Visible = false;
                ctrl.Controls.Remove(childControl);
            }
            else if (childControl.HasControls())
            {
                PrepareRemove(childControl);
            }
        }
    }
    #endregion

    #region RenderGridview
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    #endregion

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