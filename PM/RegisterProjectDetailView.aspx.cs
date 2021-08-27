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

public partial class RegisterProjectDetailView : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String queryString = "";
    String qsCommittee = "";
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

        if (Request.QueryString["Id"] == null)
        {
            dvCode.Visible = false;
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

            fldNewClientName.Visible = false;

            //Bind dropdownlist
            bindCompany();
            bindUnit();
            bindClientName();

            bindProjectManager();
            bindProjectDirector();
            bindPIC1();
            bindPIC2();
            bindHSERep();

            bindSupportingDoc();

            //DAL Approval
            bindDALApprover();
            bindDALApprover_HOD();
            bindDALApprover_COO();

            checkRole();

            if (lblRole.Text == "QHSE")
            {
                dvInactive.Visible = true;
                dvActive.Visible = false;
            }   
            else
            {
                bindDetails();

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

            if (fldOldCode.Text == "")
            {
                dvOldCode.Visible = false;
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

    protected void bindCompany()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        OperatingCompany ";
        qs = qs + " FROM          tblOperatingCompany ";
        qs = qs + " ORDER BY      OperatingCompany ";

        fldCompany.DataSource = GetData(qs);
        fldCompany.DataTextField = "OperatingCompany";
        fldCompany.DataValueField = "OperatingCompany";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindUnit()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        OperatingUnit ";
        qs = qs + " FROM          tblOperatingUnit ";
        qs = qs + " ORDER BY      OperatingUnit ";

        fldUnit.DataSource = GetData(qs);
        fldUnit.DataTextField = "OperatingUnit";
        fldUnit.DataValueField = "OperatingUnit";
        fldUnit.DataBind();
        fldUnit.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindClientName()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        Id, ClientName ";
        qs = qs + " FROM          tblClient ";
        qs = qs + " ORDER BY      ClientName ";

        fldClientName.DataSource = GetData(qs);
        fldClientName.DataTextField = "ClientName";
        fldClientName.DataValueField = "Id";
        fldClientName.DataBind();
        fldClientName.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldClientName.Items.Insert(1, new ListItem("+ Add New Client +", "addNewClient"));
    }

    protected void fldClientName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldClientName.SelectedIndex == 1)
        {
            fldNewClientName.Text = "";
            fldNewClientName.Visible = true;
        }
        else
        {
            fldNewClientName.Visible = false;
        }
    }

    protected void bindProjectManager()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPM.DataSource = GetData(qs);
        fldPM.DataTextField = "StaffName";
        fldPM.DataValueField = "StaffNo";
        fldPM.DataBind();
        fldPM.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindProjectDirector()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' or Role = 'HeadDivision' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPD.DataSource = GetData(qs);
        fldPD.DataTextField = "StaffName";
        fldPD.DataValueField = "StaffNo";
        fldPD.DataBind();
        fldPD.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindPIC1()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldPIC1.DataSource = GetData(qs);
        fldPIC1.DataTextField = "StaffName";
        fldPIC1.DataValueField = "StaffNo";
        fldPIC1.DataBind();
        fldPIC1.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindPIC2()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldPIC2.DataSource = GetData(qs);
        fldPIC2.DataTextField = "StaffName";
        fldPIC2.DataValueField = "StaffNo";
        fldPIC2.DataBind();
        fldPIC2.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindHSERep()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HSE' ";
        qs = qs + " ORDER BY      StaffName ";

        fldHSERep.DataSource = GetData(qs);
        fldHSERep.DataTextField = "StaffName";
        fldHSERep.DataValueField = "StaffNo";
        fldHSERep.DataBind();
        fldHSERep.Items.Insert(0, new ListItem("-- Please select one --", ""));
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
        qs = qs + " WHERE         Role = 'HeadDivision' OR Role = 'HeadUnit' ";
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

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnChangeManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangeRequestVODetail.aspx?Id=" + Request.QueryString["Id"]);
    }
    
    protected void bindDetails()
    {
        //Display project details 
        qs = "";
        qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code, tblMain.PreProjectCode, tblMain.ProjectCode, tblMain.OldCode, vwProjectRecordApproval.AppBy, ";
        qs = qs + "                     tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "                     tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "                     tblCOO.StaffName AS COOApproverName, ";
        qs = qs + "                     tblDAL.StaffName AS DALApproverName ";
        qs = qs + " FROM                tblProjectRecord ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCOO ON tblCOO.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.ApprovedByCOO COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblProjectRecord.DescriptionId = dbo.tblMain.Id ";
        qs = qs + " INNER JOIN dbo.vwProjectRecordApproval ON dbo.tblProjectRecord.DescriptionId = dbo.vwProjectRecordApproval.DescriptionId ";
        qs = qs + " INNER JOIN dbo.StaffLogin AS tblDAL ON dbo.vwProjectRecordApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
        qs = qs + " WHERE               tblProjectRecord.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //Promotional Code
            if (row["Code"].ToString() == "")
            {
                dvCode.Visible = false;
            }
            else
            {
                lblCode.Text = row["Code"].ToString();
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

            //Operating Company
            fldCompany.Text = row["OperatingCompany"].ToString();

            //Operating Unit
            fldUnit.Text = row["OperatingUnit"].ToString();

            //Client Name
            fldClientName.Text = row["ClientId"].ToString();

            //Client Address
            fldClientAdd.Text = row["ClientAddress"].ToString();

            //Opportunity Name
            fldDescription.Text = row["Description"].ToString();

            //Scope of Work
            fldSOW.Text = row["ScopeWork"].ToString();

            //Project Manager
            fldPM.Text = row["ProjectManager"].ToString();

            //Project Director
            fldPD.Text = row["ProjectDirector"].ToString();

            //Person In Charge [1]
            fldPIC1.Text = row["PIC1"].ToString();

            //Person In Charge [2]
            fldPIC2.Text = row["PIC2"].ToString();

            //HSE Liaison Representative
            fldHSERep.Text = row["HSERep"].ToString();

            //Estimated Project Value
            object dta = row["ProjectValue"];
            if (dta == DBNull.Value)
            { }
            else
            { fldProjectValue.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectValue"].ToString())); }

            //Estimated Project Fees
            object dtb = row["ProjectFee"];
            if (dtb == DBNull.Value)
            { }
            else
            { fldProjectFee.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())); }

            //Estimated Project Start & End Date
            object dt1 = row["StartDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldStartDate.Text = Convert.ToDateTime(row["StartDate"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt2 = row["EndDate"];
            if (dt2 == DBNull.Value)
            { }
            else
            { fldEndDate.Text = Convert.ToDateTime(row["EndDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Project Margin
            fldPercent.Text = row["ProjectMargin"].ToString();

            //Contract Period
            fldContractPeriod.Text = row["ContractPeriod"].ToString();
            
            //Reason For Deviation
            fldReasonDeviation.Text = row["ReasonDeviation"].ToString();

            if (row["SubmissionStatus"].ToString() == "")
            {
                dvReasonDeviation.Visible = true;
            }
            else if (row["SubmissionStatus"].ToString() == "Project")
            {
                dvReasonDeviation.Visible = false;
            }

            //--------------------------------------- LOI ---------------------------------------
            //LOI
            object fn2 = row["LOI"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                dvUpA3Sec.Visible = true;
                dvVwA3Sec.Visible = false;
            }
            else
            {
                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;

                lblURLA3.Text = row["LOI"].ToString();
                hidURLA3.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOI/" + row["LOI"].ToString() + "";
            }

            //--------------------------------------- Contract / LOA ---------------------------------------
            //Contract / LOA
            object fn = row["ContractLOA"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["ContractLOA"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOA/" + row["ContractLOA"].ToString() + "";
            }

            //--------------------------------------- Letter of Acceptance ---------------------------------------
            //Letter of Acceptance
            object fn1 = row["LetterAcceptance"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["LetterAcceptance"].ToString();
                hidURLA2.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectAcceptance/" + row["LetterAcceptance"].ToString() + "";
            }

            //...................................DAL Approval...................................  
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

            //...................................end of DAL Approval...................................

            //if (row["DALApproverLevel"].ToString() == "COO")
            //{
            //    lblDAL_ApprovedDateCOO.Visible = true;
            //    lblDAL_ApprovedStatusCOO.Visible = true;
            //    lblDAL_ApprovedCommentCOO.Visible = true;
            //    lblDALACOO.Visible = true;
            //}
            //else
            //{
            //    lblDAL_ApprovedDateCOO.Visible = false;
            //    lblDAL_ApprovedStatusCOO.Visible = false;
            //    lblDAL_ApprovedCommentCOO.Visible = false;
            //    lblDALACOO.Visible = false;
            //}

            //...................................COO Approval (Deviation)...................................
            //Approver - Name
            lblCOOApprover.Text = row["COOApproverName"].ToString();

            //Date Approved
            object dtDACOO = row["AppDateCOO"];
            object dtDNACOO = row["NotAppDateCOO"];
            if (dtDACOO != DBNull.Value)
            {
                lblCOO_ApprovedDate.Text = Convert.ToDateTime(row["AppDateCOO"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNACOO != DBNull.Value)
            {
                lblCOO_ApprovedDate.Text = Convert.ToDateTime(row["NotAppDateCOO"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblCOO_ApprovedDate.Text = "-";
            }

            //Status
            lblCOO_ApprovedStatus.Text = row["AppStatusCOO"].ToString();

            //Justification
            lblCOO_ApprovedComment.Text = row["AppCommentCOO"].ToString();

            //...................................end of COO Approval (Deviation)...................................

            if (row["SubmissionStatus"].ToString() == "Project")
            {
                dvDALApproval.Visible = true;
                dvCOOApproval.Visible = false;
                dvPreProjectCode.Visible = false;
                dvProjectCode.Visible = true;
            }
            else if (row["SubmissionStatus"].ToString() == "Deviation")
            {
                dvDALApproval.Visible = false;
                dvCOOApproval.Visible = true;
                dvPreProjectCode.Visible = true;
                dvProjectCode.Visible = false;
            }
            else if (row["SubmissionStatus"].ToString() == "Deviation Project")
            {
                dvDALApproval.Visible = false;
                dvCOOApproval.Visible = true;
                dvPreProjectCode.Visible = true;
                dvProjectCode.Visible = true;
            }

            //Pre-Regular Code
            fldPreProjectCode.Text = row["PreProjectCode"].ToString();

            //Regular Code
            fldProjectCode.Text = row["ProjectCode"].ToString();

            //Regular Code (Old)
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

                fldA2Upload.Enabled = true;
                btnCancelA2.Enabled = true;
                btnUpA2.Enabled = true;

                fldA3Upload.Enabled = true;
                btnCancelA3.Enabled = true;
                btnUpA3.Enabled = true;

                btnSupportingDoc.Visible = true;

                if (gvSupportingDoc.Rows.Count != 0)
                {
                    gvSupportingDoc.HeaderRow.Cells[2].Visible = true;

                    foreach (GridViewRow r in gvSupportingDoc.Rows)
                    {
                        r.Cells[2].Visible = true;
                    }
                }

                dvCOOApproval.Visible = false;

                DALApprover();
            }
            else
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;

                fldA2Upload.Enabled = false;
                btnCancelA2.Enabled = false;
                btnUpA2.Enabled = false;

                fldA3Upload.Enabled = false;
                btnCancelA3.Enabled = false;
                btnUpA3.Enabled = false;

                btnSupportingDoc.Visible = false;

                if (gvSupportingDoc.Rows.Count != 0)
                {
                    gvSupportingDoc.HeaderRow.Cells[2].Visible = false;

                    foreach (GridViewRow r in gvSupportingDoc.Rows)
                    {
                        r.Cells[2].Visible = false;
                    }
                }

                if (gvSupportingDoc.Rows.Count == 0)
                {
                    lblNone.Visible = true;
                }

                DALApprover();
            }
        }

    }

    protected void DALApprover()
    {
        qs1 = "";
        qs1 = qs1 + " SELECT        tblProjectRecord.* ";
        qs1 = qs1 + " FROM          tblProjectRecord ";
        qs1 = qs1 + " WHERE         tblProjectRecord.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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
            ProjectFees_Value = Convert.ToDecimal(row1["ProjectFee"].ToString());

            //Approver - Name
            fldDALApprover.Text = row1["DALApprovedBy"].ToString();
            fldDALApprover_HOD.Text = row1["DALApprovedBy_HOD"].ToString();
            fldDALApprover_COO.Text = row1["DALApprovedBy_COO"].ToString();

            if (ProjectFees_Value == 10000000 || ProjectFees_Value <= 10000000)
            {
                //Approved by Head of Division
                //Project Fees - Equal or below 10m
                
                fldDALApprover.Visible = false;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = true;
                fldDALApprover_HOD.Enabled = true;

            }
            else if (ProjectFees_Value == 50000000 || ProjectFees_Value <= 50000000)
            {
                //Approved by COO
                //Project Fees - Equal or below 50m

                fldDALApprover.Visible = false;
                fldDALApprover_COO.Visible = true;
                fldDALApprover_COO.Enabled = true;
                fldDALApprover_HOD.Visible = false;

            }
            else if (ProjectFees_Value == 100000000 || ProjectFees_Value <= 100000000)
            {
                //Approved by MD/CEO
                //Project Fees - Equal or below 100m

                lvlDALBOD.Visible = true;
                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = false;

            }
            else if (ProjectFees_Value == 200000000 || ProjectFees_Value <= 200000000)
            {
                //Approved by BOD Comm.
                //Project Fees - Equal or below 200m

                lvlDALBOD.Visible = true;
                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = false;

            }
            else if (ProjectFees_Value > 200000000)
            {
                //Approved by BOD
                //Project Fees - Above 200m

                lvlDALBOD.Visible = true;
                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = false;

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
        //Contract / LOA
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ProjectLOA";

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
                qs = qs + "UPDATE  tblProjectRecord SET ContractLOA = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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

    
    protected void btnViewA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        String pathfolder = "Upload/";
        String filenameStr = fldA2Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ProjectAcceptance";

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
                qs = qs + "UPDATE  tblProjectRecord SET LetterAcceptance = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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


    protected void btnViewA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA3_Click(object sender, EventArgs e)
    {
        //LOI
        String pathfolder = "Upload/";
        String filenameStr = fldA3Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ProjectLOI";

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
                qs = qs + "UPDATE  tblProjectRecord SET LOI = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
    
    protected void btnViewA3_Click(object sender, EventArgs e)
    {
        //LOI
        Response.Write("<script> window.open( '" + hidURLA3.Value.ToString() + "','_blank' ); </script>");
    }

    private void bindSupportingDoc()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Supporting Document' "
            + "ORDER BY       Id DESC ";

        gvSupportingDoc.DataSource = GetData(str);
        gvSupportingDoc.DataBind();

        for (int i = 0; i < gvSupportingDoc.Rows.Count; i++)
        {
            GridViewRow row = gvSupportingDoc.Rows[i];
            
            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }

        //if (gvSupportingDoc.Rows.Count == 0)
        //{
        //    lblNone.Visible = true;
        //}
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
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Supporting Document', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Supporting Document
            uploadSupportingDoc();

            Response.Redirect("RegisterProjectDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadSupportingDoc()
    {
        if (fldFileName.FileName != "")
        {
            //Update Supporting Document
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Supporting Document' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/SupportingDoc/";

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
}