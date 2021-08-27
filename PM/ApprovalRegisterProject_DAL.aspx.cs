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

public partial class ApprovalRegisterProject_DAL : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();

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

            bindDetails();

            //Check approval details 
            qs = "";
            qs = qs + " SELECT        DALAppDate, DALNotAppDate, DALAppStatus, DALAppComment ";
            qs = qs + " FROM          tblProjectRecord ";
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
                dvReject.Visible = false;
            }
            else
            {
                DataRow row = dt1.Rows[0];

                object dtA = row["DALAppDate"];
                object dtNA = row["DALNotAppDate"];
                //object dtR = row["DateRev"];
                //object dtNR = row["DateNotRev"];

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
                //else if (dtR != DBNull.Value && dtNR == DBNull.Value)
                //{
                //    dvReject.Visible = false;
                //    btnApprove.Enabled = false;
                //    btnNotApprove.Enabled = false;

                //}
                else if (dtA == DBNull.Value && dtNA != DBNull.Value)
                {
                    dvApprove.Visible = false;
                    //dvReview.Visible = false;
                    dvReject.Visible = true;
                    btnApprove.Enabled = false;
                    btnNotApprove.Enabled = false;
                    fldJustification.Enabled = false;
                }
                //else if (dtR == DBNull.Value && dtNR != DBNull.Value)
                //{
                //    dvApprove.Visible = false;
                //    dvReview.Visible = false;
                //    dvReject.Visible = true;
                //    btnApprove.Enabled = false;
                //    btnNotApprove.Enabled = false;
                //    fldJustification.Enabled = false;
                //}
            }
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

    
    protected void bindDetails()
    {
        //qs = "";
        //qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code, tblMain.PreProjectCode, tblMain.ProjectCode, tblMain.OldCode, vwProjectRecordApproval.AppBy, ";
        //qs = qs + "                     tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "                     tblUPDATEBY.StaffName As UPDATEBYName,  ";
        //qs = qs + "                     tblCOO.StaffName AS COOApproverName, ";
        //qs = qs + "                     tblDAL.StaffName AS DALApproverName ";
        //qs = qs + " FROM                tblProjectRecord ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCOO ON tblCOO.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.ApprovedByCOO COLLATE DATABASE_DEFAULT ";
        //qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblProjectRecord.DescriptionId = dbo.tblMain.Id ";
        //qs = qs + " LEFT OUTER JOIN dbo.vwProjectRecordApproval ON dbo.tblProjectRecord.DescriptionId = dbo.vwProjectRecordApproval.DescriptionId ";
        //qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblDAL ON dbo.vwProjectRecordApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
        //qs = qs + " WHERE               tblProjectRecord.DescriptionId = '" + Request.QueryString["Id"] + "' ";

        qs = "";
        qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code, vwProjectRecordApproval.AppBy, ";
        qs = qs + "                     tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "                     tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "                     StaffLogin_1.StaffName AS DALName ";
        qs = qs + " FROM                tblProjectRecord ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN          vwProjectRecordApproval ON tblProjectRecord.DescriptionId = vwProjectRecordApproval.DescriptionId ";
        qs = qs + " INNER JOIN          StaffLogin AS StaffLogin_1 ON  vwProjectRecordApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " INNER JOIN          tblMain ON tblProjectRecord.DescriptionId = tblMain.Id ";
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
        }
        else
        {
            DataRow row = dt.Rows[0];

            lblDALApproverLevel.Text = row["DALApproverLevel"].ToString();

            //BtnSubmit
            lblBtnSubmit.Text = row["BtnSubmit"].ToString();
                        
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
                //btnRequestConversion.Visible = false;
            }
            else if (row["SubmissionStatus"].ToString() == "Project")
            {
                dvReasonDeviation.Visible = false;
                //btnRequestConversion.Visible = false;
            }
            else if (row["SubmissionStatus"].ToString() == "Deviation")
            {
                if (row["PreProjectCode"].ToString() == "" || row["PreProjectCode"].ToString() == null)
                {
                    //btnRequestConversion.Visible = false;
                }
                else
                {
                    //btnRequestConversion.Visible = true;
                }
            }
            else if (row["SubmissionStatus"].ToString() == "Deviation Project")
            {
                //btnRequestConversion.Enabled = false;
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

            //DAL Approver
            //...................................DAL Approval...................................
            lblDALApprover.Text = row["DALName"].ToString();
            
            //Date Approved
            object dt8a = row["DALAppDate"];
            if (dt8a == DBNull.Value)
            {
                lblDtApproved.Text = "Pending";
                lblDtApproved.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtApproved.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }
                        
            //Date Rejected
            object dt9a = row["DALNotAppDate"];
            if (dt9a == DBNull.Value)
            {
                lblDtReject.Text = "Pending";
                lblDtReject.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else if (dt9a != DBNull.Value)
            {
                lblDtReject.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");

                //Justification
                fldJustification.Text = row["DALAppComment"].ToString();
            }
            
            //...................................end of DAL Approval...................................

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

                fldA2Upload.Enabled = true;
                btnCancelA2.Enabled = true;
                btnUpA2.Enabled = true;
                btnDeleteA2.Visible = true;

                fldA3Upload.Enabled = true;
                btnCancelA3.Enabled = true;
                btnUpA3.Enabled = true;
                btnDeleteA3.Visible = true;

                btnSupportingDoc.Visible = true;

                if (gvSupportingDoc.Rows.Count != 0)
                {
                    gvSupportingDoc.HeaderRow.Cells[2].Visible = true;

                    foreach (GridViewRow r in gvSupportingDoc.Rows)
                    {
                        r.Cells[2].Visible = true;
                    }
                }

            }
            else
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
            }
        }

    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string approval_type = "";

        //Update in table tblProjectRecord
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        DateTime now = DateTime.Now;

        if (lblDALApprover.Text != "")
        {
            SqlCommand cmdR = new SqlCommand("UPDATE tblProjectRecord SET "
                    + "DALAppStatus = 'Approved', "
                    + "DALAppDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            cmdR.ExecuteNonQuery();
        }

        con.Close();

        //Email notification to Finance Team & cc PM
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, tblProjectRecord.DALApproverLevel, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
        qs = qs + "               StaffLogin_1.StaffName AS PDName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               LEFT OUTER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               LEFT OUTER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.ProjectDirector = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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
        //client.Host = "smtp2.edgenta.com";
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (row["DALApproverLevel"].ToString() == "BOD" || row["DALApproverLevel"].ToString() == "BOD Comm" || row["DALApproverLevel"].ToString() == "MD/CEO")
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
                //objeto_mail.To.Add(new MailAddress(row1["FinanceEmail"].ToString()));
            }
        }

        //objeto_mail.CC.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "New Project Code Request Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi Finance,<BR><BR><BR>"

                            + "FYI, request for the following project has been <B>" + approval_type + "</B> by DAL person.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Project Director : </B>" + row["PDName"].ToString() + "<BR><BR>"
                            + "<B>Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())) + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/CreateProjectCode.aspx?ID=" + row["Id"].ToString() + ">link</A> to create the project code.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------

        //Insert data into Project Initiation phase if request is approved
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdInsertProject = new SqlCommand("INSERT INTO tblProjectInitiation (DescriptionId, BoardRequired) "
                + "VALUES ('" + Request.QueryString["Id"] + "', @pBoardRequired)", con);

        if (lblDALApproverLevel.Text == "BOD")
        {
            cmdInsertProject.Parameters.AddWithValue("@pBoardRequired", "Yes");
        }
        else
        {
            cmdInsertProject.Parameters.AddWithValue("@pBoardRequired", "No");
        }

        cmdInsertProject.ExecuteNonQuery();

        con.Close();

        if (Request.QueryString["mode"] == "int")
        {
            //Redirect to previous page
            Response.Redirect("ProjectApprovalList.aspx?DAL=" + Request.QueryString["DAL"]);
        }
        else
        {
            //Redirect to update page
            Response.Redirect("ApprovalRegisterProject_DAL.aspx?Id=" + Request.QueryString["Id"]);
        }

    }

    protected void btnNotApprove_Click(object sender, EventArgs e)
    {
        string comment = "";
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
            //Update in table tblProjectRecord
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            DateTime now = DateTime.Now;

            if (lblDALApprover.Text != "")
            {
                SqlCommand cmdNR = new SqlCommand("UPDATE tblProjectRecord SET "
                    + "DALAppStatus = 'Rejected', "
                    + "DALNotAppDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "DALAppComment = @pJustification "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

                //Justification
                cmdNR.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

                cmdNR.ExecuteNonQuery();
            }

            con.Close();

            //Email notification to Project Manager
            //---------------------------------------- send email -----------------------------------------  
            qs = "";
            qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, ";
            qs = qs + "               vwProjectRecordApproval.AppBy, tblProjectRecord.DALAppComment, ";
            qs = qs + "               tblClient.ClientName AS ClientName, ";
            qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
            qs = qs + "               StaffLogin_1.StaffName AS PDName, ";
            qs = qs + "               StaffLogin_2.StaffName AS DALName ";
            qs = qs + " FROM          tblMain ";
            qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
            qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + "               INNER JOIN vwProjectRecordApproval ON tblProjectRecord.DescriptionId = vwProjectRecordApproval.DescriptionId ";
            qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.ProjectDirector = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_2 ON  vwProjectRecordApproval.AppBy = StaffLogin_2.StaffNo COLLATE Latin1_General_CI_AI ";
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
            //client.Host = "smtp2.edgenta.com";
            client.Host = "smtp2.edgenta.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("user", "Password");

            if (row["DALAppComment"].ToString() != "")
            {
                comment = row["DALAppComment"].ToString();
            }
            else if (row["RevComment"].ToString() != "")
            {
                comment = row["RevComment"].ToString();
            }

            objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

            //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

            objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

            //objeto_mail.Subject = "Rejected : New Project Registration Approval for '" + row["Description"].ToString() + "'";
            objeto_mail.Subject = "Rejected : New Project Registration Approval";

            string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:TAHOMA,8PT;>"
                                + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                                + "Your request for the following project is <B>REJECTED</B>. Please read the remarks by DAL person below.<BR><BR><BR>"

                                + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                                + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                                + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                                + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                                + "<B>Project Director : </B>" + row["PDName"].ToString() + "<BR><BR>"
                                + "<B>Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())) + "<BR><BR>"
                                + "<B>DAL Person : </B>" + row["DALName"].ToString() + "<BR><BR>"
                                + "<B>DAL Remarks : </B>" + comment + "<BR><BR><BR>"

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
                Response.Redirect("ApprovalRegisterProject_DAL.aspx?Id=" + Request.QueryString["Id"]);
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

    protected void btnDeleteA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectRecord SET ContractLOA = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOA/" + lblURLA1.Text + "";

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

    protected void btnDeleteA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectRecord SET LetterAcceptance = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A2");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/ProjectAcceptance/" + lblURLA2.Text + "";

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

    protected void btnDeleteA3_Click(object sender, EventArgs e)
    {
        //LOI
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectRecord SET LOI = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A3");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOI/" + lblURLA3.Text + "";

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

    protected void DeleteSupportingDoc(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindSupportingDoc();
    }
        
}