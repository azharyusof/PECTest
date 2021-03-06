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

public partial class ProposalEvaluationDetailView : System.Web.UI.Page
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

            checkRole();

            if (lblRole.Text == "QHSE")
            {
                dvInactive.Visible = true;
                dvActive.Visible = false;
            }
            else
            {

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

                if (row["PreSubmitStatus"].ToString() == "Approved")
                {
                    fldA1Upload.Enabled = true;
                }
                else
                {
                    fldA1Upload.Enabled = false;
                }
            }
            else if (dt8 == DBNull.Value && dt9 != DBNull.Value)
            {
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
            }
        }
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