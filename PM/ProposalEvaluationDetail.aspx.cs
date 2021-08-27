﻿using System;
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

public partial class ProposalEvaluationDetail : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String qsHR = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();

    public SqlConnection conn;

    public void connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["PECConn"].ToString();
        conn = new SqlConnection(constr);
        conn.Open();
    }

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

            dvUpA2Sec.Visible = true;
            dvVwA2Sec.Visible = false;

            dvUpA3Sec.Visible = true;
            dvVwA3Sec.Visible = false;

            dvUpA4Sec.Visible = true;
            dvVwA4Sec.Visible = false;

            dvUpA5Sec.Visible = true;
            dvVwA5Sec.Visible = false;

            dvUpA7Sec.Visible = true;
            dvVwA7Sec.Visible = false;

            dvUpA10Sec.Visible = true;
            dvVwA10Sec.Visible = false;

            //Bind dropdownlist
            bindBoardRequired();
            bindTechnicalApprover();

            bindCommercialApprover();

            bindLegalRequired();
            bindLegalApprover();
            
            bindDetails();

            //Display opportunity details 
            qs = "";
            qs = qs + " SELECT        Description, Code ";
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
                lblCode.Text = row["Code"].ToString().ToUpper();
            }

            //Retrieve Potential Project Fees from tblOpportunityGoNoGo
            qs = "";
            qs = qs + " SELECT        ProjectFees ";
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
            }
            else
            {
                DataRow row1 = dt2.Rows[0];

                lblProjectFees.Text = row1["ProjectFees"].ToString();
            }

            updateDALPerson();

            EnableViewButonCommercialApproval();
        }
    }

    #region EnableViewButonCommercialApproval
    protected void EnableViewButonCommercialApproval()
    {
        //called connection properties
        this.connection();

        //called SP
        SqlCommand com = new SqlCommand("spEnableViewFile", con);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@DescID", Request.QueryString["Id"]);
        com.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if(dt.Rows.Count == 0)
        {
            btnViewA4.Enabled = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            btnViewA4.Enabled = false;

            String btnSubmit = row["btnSubmit"].ToString();

            if (string.IsNullOrEmpty(btnSubmit))
            {
                btnViewA4.Enabled = false;
            }
            else
            {
                btnViewA4.Enabled = true;
            }
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
                btnPreSubmit.Visible = false;
                btnSubmit.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnPreSubmit.Visible = true;
                btnSubmit.Visible = true;
            }
        }
    }

    protected void bindBoardRequired()
    {
        // Bind data to the dropdownlist control.
        fldBoardRequired.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldBoardRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldBoardRequired.Items.Insert(2, new ListItem("No", "No"));
    }
       
    
    protected void bindTechnicalApprover()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldTechnicalApprover.DataSource = GetData(qs);
        fldTechnicalApprover.DataTextField = "StaffName";
        fldTechnicalApprover.DataValueField = "StaffNo";
        fldTechnicalApprover.DataBind();
        fldTechnicalApprover.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }
        

    protected void bindCommercialApprover()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldCommercialApprover.DataSource = GetData(qs);
        fldCommercialApprover.DataTextField = "StaffName";
        fldCommercialApprover.DataValueField = "StaffNo";
        fldCommercialApprover.DataBind();
        fldCommercialApprover.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }


    protected void bindLegalRequired()
    {
        // Bind data to the dropdownlist control.
        fldLegalRequired.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldLegalRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldLegalRequired.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void fldLegalRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldLegalRequired.SelectedIndex == 1)
        {
            tblLegalApproval.Visible = true;
            lblLegalApp.Visible = false;
        }
        else
        {
            tblLegalApproval.Visible = false;
            lblLegalApp.Visible = true;
        }
    }

    
    protected void bindLegalApprover()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldLegalApprover.DataSource = GetData(qs);
        fldLegalApprover.DataTextField = "StaffName";
        fldLegalApprover.DataValueField = "StaffNo";
        fldLegalApprover.DataBind();
        fldLegalApprover.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProposalEvaluation.*, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "               StaffLogin.StaffName AS ApproverName ";
        qs = qs + " FROM          tblProposalEvaluation ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalEvaluation.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalEvaluation.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN    StaffLogin ON tblProposalEvaluation.DALApprovedBy = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblProposalEvaluation.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //////BtnPreSubmit
            ////lblBtnPreSubmit.Text = row["BtnPreSubmit"].ToString();

            //////BtnSubmit
            ////lblBtnSubmit.Text = row["BtnSubmit"].ToString();

            //--------------------------------------- Board / Management Approval ---------------------------------------
            //Board / Management Approval Required?
            fldBoardRequired.Text = row["BoardRequired"].ToString();
                        
            //--------------------------------------- Board / Management Paper ---------------------------------------
            object fn = row["BoardPaper"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["BoardPaper"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/BoardPaper/" + row["BoardPaper"].ToString() + "";
            }

            //--------------------------------------- Final Proposal & Review ---------------------------------------
            //Proposal Closing Date
            object dt1 = row["ClosingDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldClosingDate.Text = Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Tentative Award Date
            object dt2 = row["AwardDate"];
            if (dt2 == DBNull.Value)
            { }
            else
            { fldAwardDate.Text = Convert.ToDateTime(row["AwardDate"].ToString()).ToString("dd-MMM-yyyy"); }
                      
            
            //Proposal To Be Approved By
            object dt3 = row["ReviewedByDate"];
            if (dt3 == DBNull.Value)
            { }
            else
            { fldReviewedByDate.Text = Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //--------------------------------------- Project Organization Chart ---------------------------------------
            object fn3 = row["OrgChart"];
            if (fn3 == DBNull.Value || fn3 == "")
            {
                dvUpA7Sec.Visible = true;
                dvVwA7Sec.Visible = false;
            }
            else
            {
                dvUpA7Sec.Visible = false;
                dvVwA7Sec.Visible = true;

                lblURLA7.Text = row["OrgChart"].ToString();
                hidURLA7.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/OrgChart/" + row["OrgChart"].ToString() + "";
            }

            //--------------------------------------- Manning Schedule ---------------------------------------
            object fn4 = row["ManningSchedule"];
            if (fn4 == DBNull.Value || fn4 == "")
            {
                dvUpA10Sec.Visible = true;
                dvVwA10Sec.Visible = false;
            }
            else
            {
                dvUpA10Sec.Visible = false;
                dvVwA10Sec.Visible = true;

                lblURLA10.Text = row["ManningSchedule"].ToString();
                hidURLA10.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ManSchedule/" + row["ManningSchedule"].ToString() + "";
            }


            //--------------------------------------- Technical Proposal ---------------------------------------
            object fn1 = row["TechnicalProposal"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["TechnicalProposal"].ToString();
                hidURLA2.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/TechnicalProposal/" + row["TechnicalProposal"].ToString() + "";
            }

            //--------------------------------------- Commercial Proposal ---------------------------------------
            object fn2 = row["CommercialProposal"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                dvUpA4Sec.Visible = true;
                dvVwA4Sec.Visible = false;
            }
            else
            {
                dvUpA4Sec.Visible = false;
                dvVwA4Sec.Visible = true;

                lblURLA4.Text = row["CommercialProposal"].ToString();
                hidURLA4.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/CommercialProposal/" + row["CommercialProposal"].ToString() + "";
            }

            //--------------------------------------- Legal / Risk Proposal ---------------------------------------
            object fn5 = row["LegalProposal"];
            if (fn5 == DBNull.Value || fn5 == "")
            {
                dvUpA5Sec.Visible = true;
                dvVwA5Sec.Visible = false;
            }
            else
            {
                dvUpA5Sec.Visible = false;
                dvVwA5Sec.Visible = true;

                lblURLA5.Text = row["LegalProposal"].ToString();
                hidURLA5.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/LegalProposal/" + row["LegalProposal"].ToString() + "";
            }

            //...................................Technical Approval...................................
                      
            //Approver - Name
            fldTechnicalApprover.Text = row["TechnicalApprover"].ToString();

            //Approver - Date Approved 
            object dtTA = row["TechnicalAppDate"];
            object dtTNA = row["TechnicalNotAppDate"];
            if (dtTA != DBNull.Value)
            {
                lblTechnical_ApprovedDate.Text = Convert.ToDateTime(row["TechnicalAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtTNA != DBNull.Value)
            {
                lblTechnical_ApprovedDate.Text = Convert.ToDateTime(row["TechnicalNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblTechnical_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["TechnicalAppStatus"].ToString() != "")
            { lblTechnical_ApprovedStatus.Text = row["TechnicalAppStatus"].ToString(); }
            else
            { lblTechnical_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["TechnicalAppComment"].ToString() != "")
            { lblTechnical_ApprovedComment.Text = row["TechnicalAppComment"].ToString(); }
            else
            { lblTechnical_ApprovedComment.Text = "-"; }
            //...................................end of Technical Approval...................................
            
            //...................................Commercial Approval...................................
            
            //Approver - Name
            fldCommercialApprover.Text = row["CommercialApprover"].ToString();

            //Approver - Date Approved 
            object dtCA = row["CommercialAppDate"];
            object dtCNA = row["CommercialNotAppDate"];
            if (dtCA != DBNull.Value)
            {
                lblCommercial_ApprovedDate.Text = Convert.ToDateTime(row["CommercialAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtCNA != DBNull.Value)
            {
                lblCommercial_ApprovedDate.Text = Convert.ToDateTime(row["CommercialNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblCommercial_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["CommercialAppStatus"].ToString() != "")
            { lblCommercial_ApprovedStatus.Text = row["CommercialAppStatus"].ToString(); }
            else
            { lblCommercial_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["CommercialAppComment"].ToString() != "")
            { lblCommercial_ApprovedComment.Text = row["CommercialAppComment"].ToString(); }
            else
            { lblCommercial_ApprovedComment.Text = "-"; }
            //...................................end of Commercial Approval...................................

            //Legal / Risk Approval Required?
            fldLegalRequired.Text = row["LegalRequired"].ToString();

            if (row["LegalRequired"].ToString() == "Yes")
            {
                tblLegalApproval.Visible = true;
                lblLegalApp.Visible = false;
            }
            else
            {
                tblLegalApproval.Visible = false;
                lblLegalApp.Visible = true;
            }

            //Legal / Risk
            fldLegalJustification.Text = row["LegalJustification"].ToString();

            //...................................Legal / Risk Approval...................................
            
            //Approver - Name
            fldLegalApprover.Text = row["LegalApprover"].ToString();

            //Approver - Date Approved 
            object dtLA = row["LegalAppDate"];
            object dtLNA = row["LegalNotAppDate"];
            if (dtLA != DBNull.Value)
            {
                lblLegal_ApprovedDate.Text = Convert.ToDateTime(row["LegalAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtLNA != DBNull.Value)
            {
                lblLegal_ApprovedDate.Text = Convert.ToDateTime(row["LegalNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblLegal_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["LegalAppStatus"].ToString() != "")
            { lblLegal_ApprovedStatus.Text = row["LegalAppStatus"].ToString(); }
            else
            { lblLegal_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["LegalAppComment"].ToString() != "")
            { lblLegal_ApprovedComment.Text = row["LegalAppComment"].ToString(); }
            else
            { lblLegal_ApprovedComment.Text = "-"; }
            //...................................end of Legal / Risk Approval...................................

            //--------------------------------------- Signed Proposal ---------------------------------------
            object fn12 = row["SignedProposal"];
            if (fn12 == DBNull.Value || fn12 == "")
            {
                dvUpA3Sec.Visible = true;
                dvVwA3Sec.Visible = false;
            }
            else
            {
                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;

                lblURLA3.Text = row["SignedProposal"].ToString();
                hidURLA3.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/SignedProposal/" + row["SignedProposal"].ToString() + "";
            }

            //...................................DAL Approval...................................  
            //.................................................Approver.................................................
            //Approver - Date Approved 
            object dtDA = row["DALAppDate"];
            if (dtDA != DBNull.Value)
            {
                lblDAL_ApprovedDate.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblDAL_ApprovedDate.Text = "-";
            }

            //Approver - Name
            lblDAL_Approver.Text = row["ApproverName"].ToString();

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblDAL_ApprovedStatus.Text = row["DALAppStatus"].ToString(); }
            else
            { lblDAL_ApprovedStatus.Text = "-"; }                     

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

            //btnUpdate, btnPreSubmit & btnSubmit
            object dt8 = row["BtnPreSubmit"];
            object dt9 = row["BtnSubmit"];

            if (dt8 == DBNull.Value && dt9 == DBNull.Value)
            {
                fldA1Upload.Enabled = true;
                btnCancelA1.Enabled = true;
                btnUpA1.Enabled = true;
                btnDeleteA1.Visible = true;

                fldA2Upload.Enabled = true;
                btnCancelA2.Enabled = true;
                btnUpA2.Enabled = true;
                btnDeleteA2.Visible = true;

                fldA3Upload.Enabled = false;
                btnCancelA3.Enabled = false;
                btnUpA3.Enabled = false;
                btnDeleteA3.Visible = false;

                fldA4Upload.Enabled = true;
                btnCancelA4.Enabled = true;
                btnUpA4.Enabled = true;
                btnDeleteA4.Visible = true;

                fldA5Upload.Enabled = true;
                btnCancelA5.Enabled = true;
                btnUpA5.Enabled = true;
                btnDeleteA5.Visible = true;

                fldA7Upload.Enabled = true;
                btnCancelA7.Enabled = true;
                btnUpA7.Enabled = true;
                btnDeleteA7.Visible = true;

                fldA10Upload.Enabled = true;
                btnCancelA10.Enabled = true;
                btnUpA10.Enabled = true;
                btnDeleteA10.Visible = true;

                btnUpdate.Enabled = true;
                btnPreSubmit.Enabled = true;
                btnSubmit.Enabled = false;
            }
            else if (dt8 != DBNull.Value && dt9 == DBNull.Value)
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;
                btnDeleteA1.Visible = false;

                fldA2Upload.Enabled = false;
                btnCancelA2.Enabled = false;
                btnUpA2.Enabled = false;
                btnDeleteA2.Visible = false;

                fldA3Upload.Enabled = true;
                btnCancelA3.Enabled = true;
                btnUpA3.Enabled = true;
                btnDeleteA3.Visible = true;

                fldA4Upload.Enabled = false;
                btnCancelA4.Enabled = false;
                btnUpA4.Enabled = false;
                btnDeleteA4.Visible = false;

                fldA5Upload.Enabled = false;
                btnCancelA5.Enabled = false;
                btnUpA5.Enabled = false;
                btnDeleteA5.Visible = false;

                fldA7Upload.Enabled = false;
                btnCancelA7.Enabled = false;
                btnUpA7.Enabled = false;
                btnDeleteA7.Visible = false;

                fldA10Upload.Enabled = false;
                btnCancelA10.Enabled = false;
                btnUpA10.Enabled = false;
                btnDeleteA10.Visible = false;

                btnPreSubmit.Enabled = false;

                if (row["PreSubmitStatus"].ToString() == "Approved")
                {
                    fldA1Upload.Enabled = true;
                    btnSubmit.Enabled = true;
                }
                else
                {
                    fldA1Upload.Enabled = false;
                    btnSubmit.Enabled = false;
                }
            }
            else if (dt8 == DBNull.Value && dt9 != DBNull.Value)
            {
                btnUpdate.Enabled = true;
                btnPreSubmit.Enabled = false;
                btnSubmit.Enabled = true;
                fldA1Upload.Enabled = true;
            }
            else if (dt8 != DBNull.Value && dt9 != DBNull.Value)
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;
                btnDeleteA1.Visible = false;

                fldA2Upload.Enabled = false;
                btnCancelA2.Enabled = false;
                btnUpA2.Enabled = false;
                btnDeleteA2.Visible = false;

                fldA3Upload.Enabled = false;
                btnCancelA3.Enabled = false;
                btnUpA3.Enabled = false;
                btnDeleteA3.Visible = false;

                fldA4Upload.Enabled = false;
                btnCancelA4.Enabled = false;
                btnUpA4.Enabled = false;
                btnDeleteA4.Visible = false;

                fldA5Upload.Enabled = false;
                btnCancelA5.Enabled = false;
                btnUpA5.Enabled = false;
                btnDeleteA5.Visible = false;

                fldA7Upload.Enabled = false;
                btnCancelA7.Enabled = false;
                btnUpA7.Enabled = false;
                btnDeleteA7.Visible = false;

                fldA10Upload.Enabled = false;
                btnCancelA10.Enabled = false;
                btnUpA10.Enabled = false;
                btnDeleteA10.Visible = false;

                btnUpdate.Enabled = false;
                btnPreSubmit.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }
    }

    protected void updateDALPerson()
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Check DAL Person
        qs = "";
        qs = qs + " SELECT        DALApproverLevel ";
        qs = qs + " FROM          tblProposalEvaluation ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' AND DALApproverLevel IS NOT NULL ";

        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //Update DALApproverLevel, DALApprovedBy in tblProposalEvaluation

            SqlCommand cmdUpdate = new SqlCommand("UPDATE tblProposalEvaluation SET tblProposalEvaluation.DALApproverLevel = tblOpportunityGoNoGo.DALApproverLevel FROM tblOpportunityGoNoGo, tblProposalEvaluation WHERE tblOpportunityGoNoGo.DescriptionId = tblProposalEvaluation.DescriptionId AND tblProposalEvaluation.DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            cmdUpdate.ExecuteNonQuery();

            SqlCommand cmdUpdate1 = new SqlCommand("UPDATE tblProposalEvaluation SET tblProposalEvaluation.DALApprovedBy = vwOpportunityGoNoGoApproval.AppBy FROM vwOpportunityGoNoGoApproval, tblProposalEvaluation WHERE vwOpportunityGoNoGoApproval.DescriptionId = tblProposalEvaluation.DescriptionId AND tblProposalEvaluation.DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            cmdUpdate1.ExecuteNonQuery();
        }

        con.Close();
    }

    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateEvaluation();

        Response.Redirect("ProposalEvaluationDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnPreSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvUpA1Sec.Attributes.Add("class", null);
        dvClosingDate.Attributes.Add("class", null);
        dvUpA2Sec.Attributes.Add("class", null);
        dvReviewedByDate.Attributes.Add("class", null);
        dvAwardDate.Attributes.Add("class", null);
        dvLegalRequired.Attributes.Add("class", null);

        //Board / Management Paper
        if (fldBoardRequired.SelectedIndex == 1)
        {
            if (fldA1Upload.FileName == "" && lblURLA1.Text == "")
            {
                chckErr = false;
                dvUpA1Sec.Attributes.Add("class", "has-error");
            }
        }

        if (fldClosingDate.Text.Trim() == "")
        {
            chckErr = false;
            dvClosingDate.Attributes.Add("class", "has-error");
        }

        //Proposal for Review
        if (fldA2Upload.FileName == "" && lblURLA2.Text == "")
        {
            chckErr = false;
            dvUpA2Sec.Attributes.Add("class", "has-error");
        }

        if (fldReviewedByDate.Text.Trim() == "")
        {
            chckErr = false;
            dvReviewedByDate.Attributes.Add("class", "has-error");
        }
        
        //if (fldTechnicalRequired.SelectedIndex == 0)
        //{
        //    chckErr = false;
        //    dvTechnicalRequired.Attributes.Add("class", "has-error");
        //}
        //else
        //{
        //    if (fldTechnicalRequired.SelectedIndex == 1)
        //    {
        //        if (fldTechnicalApprover.SelectedIndex == 0)
        //        {
        //            chckErr = false;
        //            dvTechnicalApproval.Attributes.Add("class", "has-error");
        //        }
        //    }
        //    else if (fldTechnicalRequired.SelectedIndex == 2)
        //    {
        //        if (fldTechnicalJustification.Text.Trim() == "")
        //        {
        //            chckErr = false;
        //            dvTechnicalJustification.Attributes.Add("class", "has-error");
        //        }
        //    }
        //}

        //if (fldCommercialRequired.SelectedIndex == 0)
        //{
        //    chckErr = false;
        //    dvCommercialRequired.Attributes.Add("class", "has-error");
        //}
        //else
        //{
        //    if (fldCommercialRequired.SelectedIndex == 1)
        //    {
        //        if (fldCommercialApprover.SelectedIndex == 0)
        //        {
        //            chckErr = false;
        //            dvCommercialApproval.Attributes.Add("class", "has-error");
        //        }
        //    }
        //    else if (fldCommercialRequired.SelectedIndex == 2)
        //    {
        //        if (fldCommercialJustification.Text.Trim() == "")
        //        {
        //            chckErr = false;
        //            dvCommercialJustification.Attributes.Add("class", "has-error");
        //        }
        //    }
        //}

        if (fldLegalRequired.SelectedIndex == 0)
        {
            chckErr = false;
            dvLegalRequired.Attributes.Add("class", "has-error");
        }
        else
        {
            if (fldLegalRequired.SelectedIndex == 1)
            {
                if (fldLegalApprover.SelectedIndex == 0)
                {
                    chckErr = false;
                    dvLegalApproval.Attributes.Add("class", "has-error");
                }
            }
            else if (fldLegalRequired.SelectedIndex == 2)
            {
                if (fldLegalJustification.Text.Trim() == "")
                {
                    chckErr = false;
                    dvLegalJustification.Attributes.Add("class", "has-error");
                }
            }
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateEvaluation();

            //Disable btnPreSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblProposalEvaluation SET "
                    + "BtnPreSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnPreSubmit.Enabled = false;

            //if (fldTechnicalRequired.SelectedIndex == 1)
            //{
                emailTechnicalApprover();
            //}

            //if (fldCommercialRequired.SelectedIndex == 1)
            //{
                emailCommercialApprover();
            //}

            if (fldLegalRequired.SelectedIndex == 1)
            {
                emailLegalApprover();
            }

            if (lblURLA7.Text != "" || lblURLA10.Text != "")
            { emailHR(); }

            Response.Redirect("ProposalEvaluationDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvUpA3Sec.Attributes.Add("class", null);
        dvDALApproval.Attributes.Add("class", null);

        //if (!FileUpload1.HasFile)
        if (fldA3Upload.FileName == "" && lblURLA3.Text == "")
        {
            chckErr = false;
            dvUpA3Sec.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateEvaluation();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblProposalEvaluation SET "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            emailDAL();
            
            Response.Redirect("ProposalEvaluationDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void updateEvaluation()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblProposalEvaluation
        SqlCommand cmd = new SqlCommand("UPDATE tblProposalEvaluation SET "
                + "BoardRequired = @pBoardRequired, "
                + "ClosingDate = @pClosingDate, "
                + "AwardDate = @pAwardDate, "
                + "ReviewedByDate = @pReviewedByDate, "
                + "TechnicalApprover = @pTechnicalApprover, "
                + "CommercialApprover = @pCommercialApprover, "
                + "LegalRequired = @pLegalRequired, "
                + "LegalJustification = @pLegalJustification, "
                + "LegalApprover = @pLegalApprover, "
                + "ProjectFees = @pProjectFees, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //Board / Management Approval Required? 
        if (fldBoardRequired.Text != "")
            cmd.Parameters.AddWithValue("@pBoardRequired", fldBoardRequired.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pBoardRequired", DBNull.Value);

        //Proposal Closing Date
        if (fldClosingDate.Text != "")
            cmd.Parameters.AddWithValue("@pClosingDate", Convert.ToDateTime(fldClosingDate.Text));
        else
            cmd.Parameters.AddWithValue("@pClosingDate", DBNull.Value);

        //Tentative Award Date
        if (fldAwardDate.Text != "")
            cmd.Parameters.AddWithValue("@pAwardDate", Convert.ToDateTime(fldAwardDate.Text));
        else
            cmd.Parameters.AddWithValue("@pAwardDate", DBNull.Value);

        //Proposal To Be Approved By
        if (fldReviewedByDate.Text != "")
            cmd.Parameters.AddWithValue("@pReviewedByDate", Convert.ToDateTime(fldReviewedByDate.Text));
        else
            cmd.Parameters.AddWithValue("@pReviewedByDate", DBNull.Value);
           
        //Technical Approver
        if (fldTechnicalApprover.Text != "")
            cmd.Parameters.AddWithValue("@pTechnicalApprover", fldTechnicalApprover.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pTechnicalApprover", DBNull.Value);
        
        //Commercial Approver
        if (fldCommercialApprover.Text != "")
            cmd.Parameters.AddWithValue("@pCommercialApprover", fldCommercialApprover.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pCommercialApprover", DBNull.Value);

        //Legal / Risk Approval Required?
        if (fldLegalRequired.Text != "")
            cmd.Parameters.AddWithValue("@pLegalRequired", fldLegalRequired.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pLegalRequired", DBNull.Value);

        //Justification
        cmd.Parameters.AddWithValue("@pLegalJustification", fldLegalJustification.Text.Trim());
        
        //Legal / Risk Approver
        if (fldLegalApprover.Text != "")
            cmd.Parameters.AddWithValue("@pLegalApprover", fldLegalApprover.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pLegalApprover", DBNull.Value);

        //Potential Project Fees
        cmd.Parameters.AddWithValue("@pProjectFees", lblProjectFees.Text);

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();

        //Update in table tblMain
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
                + "Phase = 'Proposal Evaluation / Submission', "
                + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        cmdMain.ExecuteNonQuery();

        con.Close();
    }
        
    
    protected void emailTechnicalApprover()
    {
        //Email notification to Approver of Technical
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblProposalEvaluation.TechnicalProposal, tblProposalEvaluation.ClosingDate, tblProposalEvaluation.ReviewedByDate, tblProposalEvaluation.TechnicalApprover, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS ApproverName, StaffLogin_1.EmailId AS ApproverEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProposalEvaluation.TechnicalApprover = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["ApproverEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Technical Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["ApproverName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to approve a final proposal for the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Proposal Closing Date : </B>" + Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                            + "<B>Proposal To Be Reviewed By : </B>" + Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalReviewProposal_TechnicalApprover.aspx?ID=" + row["Id"].ToString() + ">link</A> to approve a final proposal.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }
       
    protected void emailCommercialApprover()
    {
        //Email notification to Approver of Commercial
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblProposalEvaluation.CommercialProposal, tblProposalEvaluation.ClosingDate, tblProposalEvaluation.ReviewedByDate, tblProposalEvaluation.CommercialApprover, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS ApproverName, StaffLogin_1.EmailId AS ApproverEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProposalEvaluation.CommercialApprover = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["ApproverEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Commercial Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["ApproverName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to approve a final proposal for the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Proposal Closing Date : </B>" + Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                            + "<B>Proposal To Be Reviewed By : </B>" + Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalReviewProposal_CommercialApprover.aspx?ID=" + row["Id"].ToString() + ">link</A> to approve a final proposal.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    
    protected void emailLegalApprover()
    {
        //Email notification to Approver of Legal / Risk
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblProposalEvaluation.LegalProposal, tblProposalEvaluation.ClosingDate, tblProposalEvaluation.ReviewedByDate, tblProposalEvaluation.LegalApprover, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS ApproverName, StaffLogin_1.EmailId AS ApproverEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProposalEvaluation.LegalApprover = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["ApproverEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Legal / Risk Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["ApproverName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to approve a final proposal for the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Proposal Closing Date : </B>" + Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                            + "<B>Proposal To Be Reviewed By : </B>" + Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalReviewProposal_LegalApprover.aspx?ID=" + row["Id"].ToString() + ">link</A> to approve a final proposal.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailDAL()
    {
        //Email notification to DAL person
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblOpportunityGoNoGo.ProjectFees, tblProposalEvaluation.ClosingDate, tblProposalEvaluation.ReviewedByDate, tblProposalEvaluation.DALApprovedBy, tblProposalEvaluation.BoardPaper, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblOpportunityGoNoGo ON tblMain.Id = tblOpportunityGoNoGo.DescriptionId ";
        qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProposalEvaluation.DALApprovedBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        if (row["BoardPaper"].ToString() != "")
        {
            objeto_mail.Attachments.Add(new Attachment("E:\\webapps\\PECTest\\PM\\Upload\\" + Request.QueryString["ID"] + "\\BoardPaper\\" + row["BoardPaper"].ToString() + ""));
        }

        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Signed Proposal Acknowledgement for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to acknowledge a signed proposal for the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Potential Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFees"].ToString())) + "<BR><BR>"
                            + "<B>Proposal Closing Date : </B>" + Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                            + "<B>Proposal To Be Reviewed By : </B>" + Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalSignedProposal_DAL.aspx?ID=" + row["Id"].ToString() + ">link</A> to acknowledge a signed proposal.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    
    protected void emailHR()
    {
        string award_dt="";

        //Email notification to HR
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblProposalEvaluation.AwardDate, tblProposalEvaluation.OrgChart, tblProposalEvaluation.ManningSchedule, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
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
        client.Host = "smtp.uemedgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        object dtDA = row["AwardDate"];
        if (dtDA != DBNull.Value)
        {
            award_dt = Convert.ToDateTime(row["AwardDate"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            award_dt = "TBD";
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //HR Team
        qsHR = "";
        qsHR = qsHR + " SELECT        StaffName, EmailId As HREmail ";
        qsHR = qsHR + " FROM          StaffLogin ";
        qsHR = qsHR + " WHERE         Role = 'HR' ";
        qsHR = qsHR + " ORDER BY      StaffName ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd1 = new SqlCommand(qsHR, con);
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
                //objeto_mail.CC.Add(new MailAddress(row1["HREmail"].ToString()));
            }
        }

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));
                
        if (row["OrgChart"].ToString() != "")
        {
            objeto_mail.Attachments.Add(new Attachment("E:\\webapps\\PEC\\PM\\Upload\\" + Request.QueryString["ID"] + "\\OrgChart\\" + row["OrgChart"].ToString() + ""));
        }

        if (row["ManningSchedule"].ToString() != "")
        {
            objeto_mail.Attachments.Add(new Attachment("E:\\webapps\\PEC\\PM\\Upload\\" + Request.QueryString["ID"] + "\\ManSchedule\\" + row["ManningSchedule"].ToString() + ""));
        }
        
        objeto_mail.Subject = "Proposal Evaluation / Submission Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi HR,<BR><BR><BR>"

                            + "FYI, below are details of the proposal evaluation / submission for the following opportunity :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Proposal Tentative Award Date : </B>" + award_dt + "<BR><BR>"

                            + "<BR>Attached is the Project Organization Chart and/or Manning Schedule for your action.<BR><BR>"

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
        //Board / Management Paper 
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/BoardPaper";

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
                qs = qs + "UPDATE  tblProposalEvaluation SET BoardPaper = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
        //Board / Management Paper 
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET BoardPaper = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/BoardPaper/" + lblURLA1.Text + "";

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
        //Board / Management Paper 
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA2_Click(object sender, EventArgs e)
    {
        //Technical Proposal
        String pathfolder = "Upload/";
        String filenameStr = fldA2Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/TechnicalProposal";

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
            fldA2Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProposalEvaluation SET TechnicalProposal = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;
                UpA2.Update();
                hidURLA2.Value = pathfolder + filenameStr;
                lblURLA2.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA2_Click(object sender, EventArgs e)
    {
        //Technical Proposal 
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET TechnicalProposal = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A2");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/TechnicalProposal/" + lblURLA2.Text + "";

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

        hidURLA2.Value = "";
        dvUpA2Sec.Visible = true;
        dvVwA2Sec.Visible = false;
        UpA2.Update();
    }

    protected void btnViewA2_Click(object sender, EventArgs e)
    {
        //Technical Proposal 
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnUpA3_Click(object sender, EventArgs e)
    {
        //Signed Proposal 
        String pathfolder = "Upload/";
        String filenameStr = fldA3Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/SignedProposal";

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
            fldA3Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProposalEvaluation SET SignedProposal = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }
                                
                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;
                UpA3.Update();
                hidURLA3.Value = pathfolder + filenameStr;
                lblURLA3.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA3_Click(object sender, EventArgs e)
    {
        //Signed Proposal 
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET SignedProposal = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A3");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/SignedProposal/" + lblURLA3.Text + "";

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

        hidURLA3.Value = "";
        dvUpA3Sec.Visible = true;
        dvVwA3Sec.Visible = false;
        UpA3.Update();
    }

    protected void btnViewA3_Click(object sender, EventArgs e)
    {
        //Signed Proposal 
        Response.Write("<script> window.open( '" + hidURLA3.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnUpA7_Click(object sender, EventArgs e)
    {
        //Project Organization Chart
        String pathfolder = "Upload/";
        String filenameStr = fldA7Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/OrgChart";

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
            fldA7Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProposalEvaluation SET OrgChart = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA7Sec.Visible = false;
                dvVwA7Sec.Visible = true;
                UpA7.Update();
                hidURLA7.Value = pathfolder + filenameStr;
                lblURLA7.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA7_Click(object sender, EventArgs e)
    {
        //Project Organization Chart
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET OrgChart = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A7");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/OrgChart/" + lblURLA7.Text + "";

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

        hidURLA7.Value = "";
        dvUpA7Sec.Visible = true;
        dvVwA7Sec.Visible = false;
        UpA7.Update();
    }

    protected void btnViewA7_Click(object sender, EventArgs e)
    {
        //Project Organization Chart
        Response.Write("<script> window.open( '" + hidURLA7.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA10_Click(object sender, EventArgs e)
    {
        //Manning Schedule
        String pathfolder = "Upload/";
        String filenameStr = fldA10Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ManSchedule";

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
            fldA10Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProposalEvaluation SET ManningSchedule = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA10Sec.Visible = false;
                dvVwA10Sec.Visible = true;
                UpA10.Update();
                hidURLA10.Value = pathfolder + filenameStr;
                lblURLA10.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA10_Click(object sender, EventArgs e)
    {
        //Manning Schedule
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET ManningSchedule = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A10");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/ManSchedule/" + lblURLA10.Text + "";

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

        hidURLA10.Value = "";
        dvUpA10Sec.Visible = true;
        dvVwA10Sec.Visible = false;
        UpA10.Update();
    }

    protected void btnViewA10_Click(object sender, EventArgs e)
    {
        //Manning Schedule
        Response.Write("<script> window.open( '" + hidURLA10.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnUpA4_Click(object sender, EventArgs e)
    {
        //Commercial Proposal
        String pathfolder = "Upload/";
        String filenameStr = fldA4Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/CommercialProposal";

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
            fldA4Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProposalEvaluation SET CommercialProposal = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA4Sec.Visible = false;
                dvVwA4Sec.Visible = true;
                UpA4.Update();
                hidURLA4.Value = pathfolder + filenameStr;
                lblURLA4.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA4_Click(object sender, EventArgs e)
    {
        //Commercial Proposal 
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET CommercialProposal = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A4");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/CommercialProposal/" + lblURLA4.Text + "";

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

        hidURLA4.Value = "";
        dvUpA4Sec.Visible = true;
        dvVwA4Sec.Visible = false;
        UpA4.Update();
    }

    protected void btnViewA4_Click(object sender, EventArgs e)
    {
        //Commercial Proposal 
        Response.Write("<script> window.open( '" + hidURLA4.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA5_Click(object sender, EventArgs e)
    {
        //Legal Proposal
        String pathfolder = "Upload/";
        String filenameStr = fldA5Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/LegalProposal";

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
            fldA5Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProposalEvaluation SET LegalProposal = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA5Sec.Visible = false;
                dvVwA5Sec.Visible = true;
                UpA5.Update();
                hidURLA5.Value = pathfolder + filenameStr;
                lblURLA5.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA5_Click(object sender, EventArgs e)
    {
        //Legal Proposal 
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalEvaluation SET LegalProposal = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A5");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/LegalProposal/" + lblURLA5.Text + "";

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

        hidURLA5.Value = "";
        dvUpA5Sec.Visible = true;
        dvVwA5Sec.Visible = false;
        UpA5.Update();
    }

    protected void btnViewA5_Click(object sender, EventArgs e)
    {
        //Legal /Risk Proposal 
        Response.Write("<script> window.open( '" + hidURLA5.Value.ToString() + "','_blank' ); </script>");
    }

}