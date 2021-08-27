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

public partial class ProjectClosingDetail : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String queryString = "";
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

        bindFinalizeManMonth();
        bindFinalClaimSubCon();
        bindClosedUpSubConAcc();
        bindRetentionSumClaimed();

        if (!Page.IsPostBack)
        {
            checkRole();

            //Hide all upload
            //dvUpA1Sec.Visible = true;
            //dvVwA1Sec.Visible = false;

            bindPQP();

            bindDetails();

            bindCerts();

            //Checklist
            //Issuance of Certificate of Practical Completion (CPC)
            bindChecklist01();

            //Project Proposal
            bindChecklist02();

            //Service Agreement / PQP / PSP
            bindChecklist03();

            //LOA / LOI
            bindChecklist04();

            //Tender / Construction Drawing
            bindChecklist05();

            //Contract Document
            bindChecklist06();
        }
    }

    private void bindPQP()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category in ('PQP','PSP') "
            + "ORDER BY       Id DESC ";

        gvPQP.DataSource = GetData(str);
        gvPQP.DataBind();

        for (int i = 0; i < gvPQP.Rows.Count; i++)
        {
            GridViewRow row = gvPQP.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                //row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void bindFinalizeManMonth()
    {
        // Bind data to the dropdownlist control.
        fldFinalizeManMonth.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldFinalizeManMonth.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldFinalizeManMonth.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindFinalClaimSubCon()
    {
        // Bind data to the dropdownlist control.
        fldFinalClaimSubCon.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldFinalClaimSubCon.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldFinalClaimSubCon.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindClosedUpSubConAcc()
    {
        // Bind data to the dropdownlist control.
        fldClosedUpSubCon.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldClosedUpSubCon.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldClosedUpSubCon.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindRetentionSumClaimed()
    {
        // Bind data to the dropdownlist control.
        fldRetentionSumClaimed.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldRetentionSumClaimed.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldRetentionSumClaimed.Items.Insert(2, new ListItem("No", "No"));
    }

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
                btnClose.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnClose.Visible = true;
            }
        }
    }

    protected void bindChecklist01()
    {
        //Issuance of Certificate of Practical Completion (CPC)
        qs = "";
        qs = qs + " SELECT        FileName  ";
        qs = qs + " FROM          tblProjectDocument ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";
        //qs = qs + " AND           DocumentType = 'Issuance of Certificate of Practical Completion (CPC)' ";

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
            lblChecklist01_Blank.Visible = true;
            lblChecklist01.Visible = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            lblChecklist01_Blank.Visible = false;
            lblChecklist01.Visible = true;
            lblChecklist01.Text = row["FileName"].ToString();
        }
    }

    protected void bindChecklist02()
    {
        //Project Proposal
        qs = "";
        qs = qs + " SELECT        SignedProposal  ";
        qs = qs + " FROM          tblProposalEvaluation ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            object fn = row["SignedProposal"];
            if (fn == DBNull.Value || fn == "")
            {
                lblChecklist02_Blank.Visible = true;
                lblChecklist02.Visible = false;
            }
            else
            {
                lblChecklist02_Blank.Visible = false;
                lblChecklist02.Visible = true;
                lblChecklist02.Text = row["SignedProposal"].ToString();
            }
        }
    }

    protected void bindChecklist03()
    {
        //Service Agreement / PQP / PSP
        qs = "";
        qs = qs + " SELECT        ServiceAgreement, PQP, PSP  ";
        qs = qs + " FROM          tblProjectInitiation ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            object fn = row["ServiceAgreement"];
            if (fn == DBNull.Value || fn == "")
            {
                lblChecklist03_Blank.Visible = true;
                lblChecklist03.Visible = false;
            }
            else
            {
                lblChecklist03_Blank.Visible = false;
                lblChecklist03.Visible = true;
                lblChecklist03.Text = row["ServiceAgreement"].ToString();
            }
            
        }
    }

    protected void bindChecklist04()
    {
        //LOA / LOI
        qs = "";
        qs = qs + " SELECT        ContractLOA, SupportingDoc  ";
        qs = qs + " FROM          tblProjectRecord ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            object fn = row["ContractLOA"];
            object fn1 = row["SupportingDoc"];
            if (fn == DBNull.Value || fn == "" && fn1 == DBNull.Value || fn1 == "")
            {
                lblChecklist04_Blank.Visible = true;
                lblChecklist04.Visible = false;
            }
            else if (fn != DBNull.Value)
            {
                lblChecklist04_Blank.Visible = false;
                lblChecklist04.Visible = true;
                lblChecklist04.Text = row["ContractLOA"].ToString();
            }
            else if (fn1 != DBNull.Value)
            {
                lblChecklist04_Blank.Visible = false;
                lblChecklist04.Visible = true;
                lblChecklist04.Text = row["SupportingDoc"].ToString();
            }
        }
    }

    protected void bindChecklist05()
    {
        //Tender / Construction Drawing
        qs = "";
        qs = qs + " SELECT        FileName  ";
        qs = qs + " FROM          tblProjectDocument ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";
        qs = qs + " AND           Category = 'Tender / Construction Drawing' ";

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
            lblChecklist05_Blank.Visible = true;
            lblChecklist05.Visible = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            lblChecklist05_Blank.Visible = false;
            lblChecklist05.Visible = true;
            lblChecklist05.Text = row["FileName"].ToString();
        }
    }

    protected void bindChecklist06()
    {
        //Contract Document
        qs = "";
        qs = qs + " SELECT        FileName  ";
        qs = qs + " FROM          tblProjectDocument ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";
        qs = qs + " AND           Category = 'Contract Document' ";

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
            lblChecklist06_Blank.Visible = true;
            lblChecklist06.Visible = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            lblChecklist06_Blank.Visible = false;
            lblChecklist06.Visible = true;
            lblChecklist06.Text = row["FileName"].ToString();
        }
    }
 

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateClosed();

        Response.Redirect("ProjectClosingDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnInactive_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        updateClosed();
        emailFinanceInactive();

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdMain = new SqlCommand("UPDATE tblProjectClose SET "
                + "ProjectStatus = 'Inactive', "
                + "BtnInactive = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

        cmdMain.ExecuteNonQuery();

        con.Close();

        //Update in table tblMain
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdUpdateMain = new SqlCommand("UPDATE tblMain SET "
                + "Phase = 'Project Close', "
                + "Status = 'InActive', "
                + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        cmdUpdateMain.ExecuteNonQuery();

        con.Close();

        Response.Redirect("ProjectClosingDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvFinalAccSubCon.Attributes.Add("class", null);
        dvClosedUpSubCon.Attributes.Add("class", null);
        dvFinalizeManMonth.Attributes.Add("class", null);
        dvRetentionSumClaimed.Attributes.Add("class", null);

        if (fldFinalClaimSubCon.SelectedIndex == 0)
        {
            chckErr = false;
            dvFinalAccSubCon.Attributes.Add("class", "has-error");
        }
        
        if (fldClosedUpSubCon.SelectedIndex == 0)
        {
            chckErr = false;
            dvClosedUpSubCon.Attributes.Add("class", "has-error");
        }

        if (fldFinalizeManMonth.SelectedIndex == 0)
        {
            chckErr = false;
            dvFinalizeManMonth.Attributes.Add("class", "has-error");
        }

        if (fldRetentionSumClaimed.SelectedIndex == 0)
        {
            chckErr = false;
            dvRetentionSumClaimed.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateClosed();
            emailPM();
            emailFinance();
            emailKMDC();

            //Disable btnUpdate & btnClose in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblProjectClose SET "
                    + "ProjectStatus = 'Closed', " 
                    + "BtnClose = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            //Update in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdUpdateMain = new SqlCommand("UPDATE tblMain SET "
                    + "Phase = 'Project Close', "
                    + "Status = 'Closed', "
                    + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                    + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

            cmdUpdateMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnClose.Enabled = false;

            Response.Redirect("ProjectClosingDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProjectClose.*, tblMain.ProjectCode, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblProjectClose ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectClose.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectClose.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN          tblMain ON tblProjectClose.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblProjectClose.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();

            //Status
            lblStatus.Text = row["ProjectStatus"].ToString().ToUpper();

            //--------------------------------------- Close Out Report ---------------------------------------
            //object fn = row["CloseOutReport"];
            //if (fn == DBNull.Value || fn == "")
            //{
            //    dvUpA1Sec.Visible = true;
            //    dvVwA1Sec.Visible = false;
            //}
            //else
            //{
            //    dvUpA1Sec.Visible = false;
            //    dvVwA1Sec.Visible = true;

            //    lblURLA1.Text = row["CloseOutReport"].ToString();
            //    hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/CloseOutReport/" + row["CloseOutReport"].ToString() + "";
            //}

            //Have Sub Consultant Submitted Final Claim?
            fldFinalClaimSubCon.Text = row["FinalClaimSubCon"].ToString();

            //Have Sub Consultant Submitted Final Claim Remarks
            fldFinalClaimSubConRemarks.Text = row["FinalClaimSubConRemarks"].ToString();

            //Have You Closed Up Sub Consultant's Final Account?
            fldClosedUpSubCon.Text = row["ClosedUpSubCon"].ToString();

            //Have You Closed Up Sub Consultant's Final Account Remarks
            fldClosedUpSubConRemarks.Text = row["ClosedUpSubConRemarks"].ToString();

            //Have You Finalized Man-Month Input?
            fldFinalizeManMonth.Text = row["FinalizeManMonth"].ToString();

            //Have You Finalized Man-Month Input Remarks
            fldFinalizeManMonthRemarks.Text = row["FinalizeManMonthRemarks"].ToString();

            //Retention Sum Claimed?
            fldRetentionSumClaimed.Text = row["RetentionSumClaimed"].ToString();

            //Retention Sum Claimed Remarks
            fldRetentionSumClaimedRemarks.Text = row["RetentionSumClaimedRemarks"].ToString();

            //Outstanding Amount Uncollected?
            fldOutAmountUncollected.Text = row["OutAmountUncollected"].ToString();

            //Remarks
            fldRemarks.Text = row["Remarks"].ToString();

            //Lesson Learnt
            fldLessonLearnt.Text = row["LessonLearnt"].ToString();

            //What Went Well?
            fldWhatWentWell.Text = row["WhatWentWell"].ToString();

            //What Can We Improve?
            fldWhatCanImprove.Text = row["WhatCanImprove"].ToString();

            //Highlights & Innovation
            fldHighlightInnovation.Text = row["HighlightInnovation"].ToString();

            //Performance Against Client's Expectation
            fldPerformClientExpectation.Text = row["PerformClientExpectation"].ToString();

            //Performance Against Schedule
            fldPerformSchedule.Text = row["PerformSchedule"].ToString();

            //Performance Against Budget
            fldPerformBudget.Text = row["PerformBudget"].ToString();

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

            //btnUpdate & btnClose
            object dt8 = row["btnClose"];
            if (dt8 == DBNull.Value)
            {
                btnUpdate.Enabled = true;
                btnInactive.Enabled = true;
                btnClose.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnInactive.Enabled = false;
                btnClose.Enabled = false;
            }
        }
    }


    protected void updateClosed()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblProjectClose
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectClose SET "
                + "FinalClaimSubCon = @pFinalClaimSubCon, "
                + "FinalClaimSubConRemarks = @pFinalClaimSubConRemarks, "
                + "ClosedUpSubCon = @pClosedUpSubCon, "
                + "ClosedUpSubConRemarks = @pClosedUpSubConRemarks, "
                + "FinalizeManMonth = @pFinalizeManMonth, "
                + "FinalizeManMonthRemarks = @pFinalizeManMonthRemarks, "
                + "RetentionSumClaimed = @pRetentionSumClaimed, "
                + "RetentionSumClaimedRemarks = @pRetentionSumClaimedRemarks, "
                + "OutAmountUncollected = @pOutAmountUncollected, "
                + "Remarks = @pRemarks, "
                + "LessonLearnt = @pLessonLearnt, "
                + "WhatWentWell = @pWhatWentWell, "
                + "WhatCanImprove = @pWhatCanImprove, "
                + "HighlightInnovation = @pHighlightInnovation, "
                + "PerformClientExpectation = @pPerformClientExpectation, "
                + "PerformSchedule = @pPerformSchedule, "
                + "PerformBudget = @pPerformBudget, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //Have Sub Consultant Submitted Final Claim?
        cmd.Parameters.AddWithValue("@pFinalClaimSubCon", fldFinalClaimSubCon.SelectedValue);

        //Have Sub Consultant Submitted Final Claim Remarks
        cmd.Parameters.AddWithValue("@pFinalClaimSubConRemarks", fldFinalClaimSubConRemarks.Text.Trim());

        //Have You Closed Up Sub Consultant's Account?
        cmd.Parameters.AddWithValue("@pClosedUpSubCon", fldClosedUpSubCon.SelectedValue);

        //Have You Closed Up Sub Consultant's Account Remarks
        cmd.Parameters.AddWithValue("@pClosedUpSubConRemarks", fldClosedUpSubConRemarks.Text.Trim());

        //Have You Finalized Man-Month Input?
        cmd.Parameters.AddWithValue("@pFinalizeManMonth", fldFinalizeManMonth.SelectedValue);

        //Have You Finalized Man-Month Input Remarks
        cmd.Parameters.AddWithValue("@pFinalizeManMonthRemarks", fldFinalizeManMonthRemarks.Text.Trim());
        
        //Retention Sum Claimed? 
        cmd.Parameters.AddWithValue("@pRetentionSumClaimed", fldRetentionSumClaimed.SelectedValue);

        //Retention Sum Claimed Remarks
        cmd.Parameters.AddWithValue("@pRetentionSumClaimedRemarks", fldRetentionSumClaimedRemarks.Text.Trim());

        //Outstanding Amount Uncollected?
        cmd.Parameters.AddWithValue("@pOutAmountUncollected", fldOutAmountUncollected.Text.Trim());
                
        //Lesson Learnt  
        cmd.Parameters.AddWithValue("@pLessonLearnt", fldLessonLearnt.Text.Trim());

        //Remarks
        cmd.Parameters.AddWithValue("@pRemarks", fldRemarks.Text.Trim());
        
        //What Went Well?
        cmd.Parameters.AddWithValue("@pWhatWentWell", fldWhatWentWell.Text.Trim());

        //What Can We Improve?
        cmd.Parameters.AddWithValue("@pWhatCanImprove", fldWhatCanImprove.Text.Trim());

        //Highlights & Innovation
        cmd.Parameters.AddWithValue("@pHighlightInnovation", fldHighlightInnovation.Text.Trim());

        //Performance Against Client's Expectation
        cmd.Parameters.AddWithValue("@pPerformClientExpectation", fldPerformClientExpectation.Text.Trim());

        //Performance Against Schedule
        cmd.Parameters.AddWithValue("@pPerformSchedule", fldPerformSchedule.Text.Trim());

        //Performance Against Budget
        cmd.Parameters.AddWithValue("@pPerformBudget", fldPerformBudget.Text.Trim());

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();
    }

    protected void emailPM()
    {
        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Project Close Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Status for the following project has been changed to <U>CLOSED</U> :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"                            
                            + "<B>Status : </B>Closed<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }
    
    protected void emailFinance()
    {
        //Email notification to Finance
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Project Close Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi Finance,<BR><BR><BR>"

                            + "Status for the following project has been changed to <U>CLOSED</U> :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Status : </B>Closed<BR><BR><BR>"

                            + "You are required to close account for this project in Deltek Vision system.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailKMDC()
    {
        //Email notification to KMDC
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Project Close Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi KMDC,<BR><BR><BR>"

                            + "Status for the following project has been changed to <U>CLOSED</U> :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Status : </B>Closed<BR><BR><BR>"

                            + "Please follow-up with PM for the hardcopy submission of all project related documents.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailFinanceInactive()
    {
        //Email notification to Finance
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Project Inactive Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi Finance,<BR><BR><BR>"

                            + "Status for the following project has been changed to <U>INACTIVE</U> :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Status : </B>Inactive<BR><BR><BR>"

                            + "FYI, no more charging timesheet & internal claims but project account still open in Deltek Vision system.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    private void bindCerts()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblCertificate "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvCerts.DataSource = GetData(str);
        gvCerts.DataBind();

        for (int i = 0; i < gvCerts.Rows.Count; i++)
        {
            GridViewRow row = gvCerts.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteCerts(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblCertificate WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindCerts();
    }

    protected void btnSaveE_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName.Attributes.Add("class", null);

        if (fldFileName.FileName == "")
        {
            chckErr = false;
            dvFileName.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblCertificate ";
            queryString = queryString + "               (DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Certs
            uploadCerts();

            Response.Redirect("ProjectClosingDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadCerts()
    {
        if (fldFileName.FileName != "")
        {
            //Update Certs
            SqlCommand cmdFile = new SqlCommand("UPDATE tblCertificate SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;

            //---------------------- upload file & save file name ------------------------------------------------------
            //Upload file into directory
            HttpFileCollection hfc = Request.Files;
            string Msg = null;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/Certs/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName.PostedFile.FileName) == ".exe")
                        {
                            //lblError.Text = "No .exe files are allowed.";
                        }
                        else
                        {
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }
                    }
                    else
                    {
                        if (System.IO.Path.GetExtension(fldFileName.PostedFile.FileName) == ".exe")
                        {
                            //lblError.Text = "No .exe files are allowed.";
                        }
                        else
                        {
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }
                    }
                }
            }

            //Insert into table
            foreach (HttpPostedFile postedFile in fldFileName.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);

                using (Stream fs = postedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        //File Name
                        cmdFile.Parameters.AddWithValue("@pFileName", filename);
                    }
                }
            }
            //---------------------- end of upload file & save file name -----------------------------------------------

            cmdFile.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void btnCloseE_Click(object sender, EventArgs e)
    {
    }

    protected void btnPCC_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectClosureChecklist.aspx?ID=" + Request.QueryString["Id"]);
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

    //protected void btnUpA1_Click(object sender, EventArgs e)
    //{
    //    //Close Out Report
    //    String pathfolder = "Upload/";
    //    String filenameStr = fldA1Upload.FileName;

    //    //Check path folder
    //    pathfolder = "Upload/" + Request.QueryString["Id"] + "/CloseOutReport";

    //    //Check year folder created
    //    if (Directory.Exists(Server.MapPath(pathfolder)) == false)
    //    {
    //        Directory.CreateDirectory(Server.MapPath(pathfolder));
    //    }

    //    //Update path to folder assigned
    //    pathfolder = pathfolder + "/";

    //    //Upload file
    //    try
    //    {
    //        fldA1Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

    //        //Insert into table
    //        using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
    //        {
    //            //Update table
    //            qs = "";
    //            qs = qs + "UPDATE  tblProjectClose SET CloseOutReport = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

    //            using (SqlCommand cmda = new SqlCommand(qs, conn_a))
    //            {
    //                cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

    //                conn_a.Open();
    //                cmda.ExecuteNonQuery();
    //                conn_a.Close();
    //            }

    //            dvUpA1Sec.Visible = false;
    //            dvVwA1Sec.Visible = true;
    //            UpA1.Update();
    //            hidURLA1.Value = pathfolder + filenameStr;
    //            lblURLA1.Text = filenameStr;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //Error cannot upload
    //    }
    //}

    //protected void btnDeleteA1_Click(object sender, EventArgs e)
    //{
    //    //Close Out Report
    //    //Update table
    //    if (con.State == System.Data.ConnectionState.Closed)
    //    { con.Open(); }
    //    SqlCommand cmd = new SqlCommand("", con);
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.DeleteCommand = new SqlCommand("UPDATE tblProjectClose SET CloseOutReport = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
    //    da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
    //    da.DeleteCommand.ExecuteNonQuery();
    //    con.Close();

    //    //Delete file
    //    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/CloseOutReport/" + lblURLA1.Text + "";

    //    if (System.IO.File.Exists(pathString))
    //    {
    //        // Use a try block to catch IOExceptions, to
    //        // handle the case of the file already being
    //        // opened by another process.
    //        //try
    //        //{
    //        System.IO.File.Delete(pathString);

    //        //}
    //        //catch (System.IO.IOException ex)
    //        //{
    //        //    Console.WriteLine(ex.Message);
    //        //    return;
    //        //}
    //    }

    //    hidURLA1.Value = "";
    //    dvUpA1Sec.Visible = true;
    //    dvVwA1Sec.Visible = false;
    //    UpA1.Update();
    //}

    //protected void btnViewA1_Click(object sender, EventArgs e)
    //{
    //    //Close Out Report
    //    Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    //}

}