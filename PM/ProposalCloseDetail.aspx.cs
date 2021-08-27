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

public partial class ProposalCloseDetail : System.Web.UI.Page
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

            //Bind dropdownlist
            bindResult();
            bindMargin();

            bindDetails();

            if (lblStatus.Text == "Proposal Dropped")
            {
                btnUpdate.Visible = false;
                btnSubmit.Visible = false;
                btnDrop.Visible = true;

                //Post Mortem
                dvResult.Visible = false;
                dvClientFeedback.Visible = false;
                dvReasonResult.Visible = false;
                dvFeedbackForm.Visible = false;
                dvResultMargin.Visible = false;
                dvLessonLearnt.Visible = false; 
                dvDropped.Visible = true;

                //Contract / LOA                
                dvContractLOA.Visible = false;
                dvJustification.Visible = false;
                dvContractLOAExpDate.Visible = false;                
            }
            else
            {
                btnUpdate.Visible = true;
                btnSubmit.Visible = true;
                btnDrop.Visible = false;

                //Post Mortem
                dvResult.Visible = true;
                dvClientFeedback.Visible = true;
                dvReasonResult.Visible = true;
                dvFeedbackForm.Visible = true;
                dvResultMargin.Visible = true;
                dvLessonLearnt.Visible = true;
                dvDropped.Visible = false;

                //Contract / LOA                
                dvContractLOA.Visible = true;
                dvJustification.Visible = true;
                dvContractLOAExpDate.Visible = true;
            }

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

                object fn = row["Code"];
                if (fn == DBNull.Value || fn == "")
                {
                    lblCode.Text = "None";
                }
                else
                {
                    lblCode.Text = row["Code"].ToString().ToUpper();
                }                
            }

            //Display signed proposal 
            qs = "";
            qs = qs + " SELECT        SignedProposal ";
            qs = qs + " FROM          tblProposalEvaluation ";
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
                if (lblStatus.Text == "Proposal Dropped")
                {
                    lblFileNameSP.Visible = true;
                    lblFileNameSP.Text = "N/A";
                }
            }
            else
            {
                DataRow row = dt2.Rows[0];

                if (lblStatus.Text == "Proposal Dropped")
                {
                    lblFileNameSP.Visible = true;
                    lblFileNameSP.Text = "N/A";
                }
                else
                {
                    object fn = row["SignedProposal"];
                    if (fn == DBNull.Value || fn == "")
                    {
                        lblFileNameSP.Visible = false;
                    }
                    else
                    {
                        lblFileNameSP.Visible = true;
                        lblFileNameSP.Text = row["SignedProposal"].ToString();
                    }
                }
                
                
            }

        }
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
                btnSubmit.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnSubmit.Visible = true;
            }
        }
    }

    protected void bindResult()
    {
        // Bind data to the dropdownlist control.
        fldResult.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldResult.Items.Insert(1, new ListItem("Win", "Win"));
        fldResult.Items.Insert(2, new ListItem("Lose", "Lose"));
    }

    protected void bindMargin()
    {
        // Bind data to the dropdownlist control.
        fldMargin.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldMargin.Items.Insert(1, new ListItem("Over", "Over"));
        fldMargin.Items.Insert(2, new ListItem("Below", "Below"));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }


    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProposalClose.*,  ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblProposalClose ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalClose.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalClose.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         tblProposalClose.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //Result
            fldResult.Text = row["Result"].ToString();

            //Proposal Status
            if (row["Status"].ToString() == "" || row["Status"].ToString() == null)
            {
                lblStatus.Text = "Open";
            }
            else
            {
                lblStatus.Text = row["Status"].ToString();
            }

            //--------------------------------------- Post Mortem ---------------------------------------
            //Client Feedback
            fldClientFeedback.Text = row["ClientFeedback"].ToString();

            //Reason Win / Lose
            fldReasonResult.Text = row["ReasonResult"].ToString();

            //--------------------------------------- Client Feedback Form ---------------------------------------
            object fn = row["FeedbackForm"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["FeedbackForm"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/FeedbackForm/" + row["FeedbackForm"].ToString() + "";
            }

            //Win / Lose Margin
            object dta = row["ResultMargin"];
            if (dta == DBNull.Value)
            { }
            else
            { fldResultMargin.Text = row["ResultMargin"].ToString(); }

            fldMargin.Text = row["Margin"].ToString();

            //Lesson Learnt
            fldLessonLearnt.Text = row["LessonLearnt"].ToString();

            //Remarks (Proposal Drop)
            fldProposalDropRemarks.Text = row["ProposalDropRemarks"].ToString();

            //--------------------------------------- Contract / LOA ---------------------------------------
            object fn1 = row["ContractLOA"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["ContractLOA"].ToString();
                hidURLA2.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/LOA/" + row["ContractLOA"].ToString() + "";
            }

            //If None, Justification
            fldJustification.Text = row["Justification"].ToString();

            //Expected Contract / LOA To Be Obtained
            object dt1 = row["ContractLOAExpDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldContractLOAExpDate.Text = Convert.ToDateTime(row["ContractLOAExpDate"].ToString()).ToString("dd-MMM-yyyy"); }
                                    
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

                btnUpdate.Enabled = true;
                btnSubmit.Enabled = true;
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

                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;
            }

            //BtnProposalDrop
            object dt9 = row["BtnProposalDrop"];
            if (dt9 == DBNull.Value)
            {
                btnDrop.Enabled = true;
            }
            else
            {
                btnDrop.Enabled = false;
            }

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateClose();

        Response.Redirect("ProposalCloseDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvResult.Attributes.Add("class", null);
        dvClientFeedback.Attributes.Add("class", null);
        dvReasonResult.Attributes.Add("class", null);

        if (fldResult.SelectedIndex == 0)
        {
            chckErr = false;
            dvResult.Attributes.Add("class", "has-error");
        }

        if (fldClientFeedback.Text.Trim() == "")
        {
            chckErr = false;
            dvClientFeedback.Attributes.Add("class", "has-error");
        }

        if (fldReasonResult.Text.Trim() == "")
        {
            chckErr = false;
            dvReasonResult.Attributes.Add("class", "has-error");
        }
        
        //if (!FileUpload1.HasFile)
        //if (fldContractLOA.FileName == "" && fldJustification.Text.Trim() == "")
        //{
        //    chckErr = false;
        //    dvContractLOA.Attributes.Add("class", "has-error");
        //    dvJustification.Attributes.Add("class", "has-error");
        //}

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateClose();

            if (fldResult.Text == "Win")
            {
                emailFinance();
                emailPM();
                emailAll();
            }
            else if (fldResult.Text == "Lose")
            {
                emailAll();
            }                

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblProposalClose SET "
                    + "Status = 'Closed', "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            //Check Result
            qs = "";
            qs = qs + " SELECT        Result ";
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
                //Check for empty record.
            }
            else
            {
                DataRow row = dt1.Rows[0];

                if (row["Result"].ToString() == "Win")
                {
                    //Insert data into Register New Project phase if Result = Win
                    if (con.State == System.Data.ConnectionState.Closed)
                    { con.Open(); }

                    SqlCommand cmdInsertProject = new SqlCommand("INSERT INTO tblProjectRecord (DescriptionId, OperatingCompany, OperatingUnit, ClientId, ClientAddress, Description, ScopeWork, ProjectManager, PIC1, PIC2, ProjectValue, ProjectFee, StartDate, EndDate) "
                            + "SELECT DescriptionId, OperatingCompany, OperatingUnit, ClientId, ClientAddress, Description, ScopeWork, ProjectManager, PIC1, PIC2, EstProjectValue, EstProjectFee, EstStartDate, EstEndDate FROM vwOpportunityRecord "
                            + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

                    cmdInsertProject.ExecuteNonQuery();

                    //Update in table tblMain
                    SqlCommand cmdUpdateStatus = new SqlCommand("UPDATE tblMain SET "
                            + "Category = 'Project', "
                            + "Status = 'Active', "
                            + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                            + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                            + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

                    cmdUpdateStatus.ExecuteNonQuery();

                    con.Close();
                }
                else if (row["Result"].ToString() == "Lose")
                {
                    //Update in table tblMain
                    if (con.State == System.Data.ConnectionState.Closed)
                    { con.Open(); }

                    //Change from InActive to Unsuccessful
                    SqlCommand cmdUpdateStatus = new SqlCommand("UPDATE tblMain SET "
                            + "Status = 'InActive', "
                            + "StatusRemarks = 'Unsuccessful', "
                            + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                            + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                            + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

                    cmdUpdateStatus.ExecuteNonQuery();

                    con.Close();
                }
            }

            Response.Redirect("ProposalCloseDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void btnDrop_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvDropped.Attributes.Add("class", null);

        if (fldProposalDropRemarks.Text.Trim() == "")
        {
            chckErr = false;
            dvDropped.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            //Update into table tblProposalClose
            SqlCommand cmd = new SqlCommand("UPDATE tblProposalClose SET "
                    + "ProposalDropRemarks = @pProposalDropRemarks, "
                    + "BtnProposalDrop = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "ModifyBy = @pModifyBy, "
                    + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            //--------------------------------------- Post Mortem ---------------------------------------
            //Remarks (Proposal Drop)
            cmd.Parameters.AddWithValue("@pProposalDropRemarks", fldProposalDropRemarks.Text.Trim());

            //Modified By
            cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

            cmd.ExecuteNonQuery();

            //Update in table tblMain
            SqlCommand cmdUpdateStatus = new SqlCommand("UPDATE tblMain SET "
                    + "Status = 'InActive', "
                    + "StatusRemarks = 'Proposal Dropped', "
                    + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                    + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

            cmdUpdateStatus.ExecuteNonQuery();

            con.Close();

            Response.Redirect("ProposalCloseDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void updateClose()
    {
        DateTime now = DateTime.Now;
                
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblProposalClose
        SqlCommand cmd = new SqlCommand("UPDATE tblProposalClose SET "
                + "Status = @pStatus, "
                + "Result = @pResult, "
                + "ClientFeedback = @pClientFeedback, "
                + "ReasonResult = @pReasonResult, "
                + "Margin = @pMargin, "
                + "ResultMargin = @pResultMargin, "
                + "LessonLearnt = @pLessonLearnt, "
                + "Justification = @pJustification, "
                + "ContractLOAExpDate = @pContractLOAExpDate, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //Result
        if (fldResult.Text != "")
        {
            cmd.Parameters.AddWithValue("@pResult", fldResult.SelectedValue);

            if (fldResult.Text == "Win")
            {
                //cmd.Parameters.AddWithValue("@pStatus", "Active");
                cmd.Parameters.AddWithValue("@pStatus", "Closed");
            }
            else if (fldResult.Text == "Lose")
            {
                //cmd.Parameters.AddWithValue("@pStatus", "InActive");
                cmd.Parameters.AddWithValue("@pStatus", "Closed");
            }
        }            
        else
            cmd.Parameters.AddWithValue("@pResult", DBNull.Value);

        //--------------------------------------- Post Mortem ---------------------------------------
        //Client Feedback
        cmd.Parameters.AddWithValue("@pClientFeedback", fldClientFeedback.Text.Trim());

        //Reason Win / Lose
        cmd.Parameters.AddWithValue("@pReasonResult", fldReasonResult.Text.Trim());

        //Win / Lose Margin
        cmd.Parameters.AddWithValue("@pResultMargin", fldResultMargin.Text);
        cmd.Parameters.AddWithValue("@pMargin", fldMargin.Text);

        //Lesson Learnt
        cmd.Parameters.AddWithValue("@pLessonLearnt", fldLessonLearnt.Text.Trim());

        //--------------------------------------- Contract / LOA ---------------------------------------
        //If None, Justification
        cmd.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

        //Expected Contract / LOA To Be Obtained
        if (fldContractLOAExpDate.Text != "")
            cmd.Parameters.AddWithValue("@pContractLOAExpDate", Convert.ToDateTime(fldContractLOAExpDate.Text));
        else
            cmd.Parameters.AddWithValue("@pContractLOAExpDate", DBNull.Value);

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();
    }

    protected void emailFinance()
    {
        //Email notification to Finance Team
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProposalClose.Status, tblProposalClose.Result, tblProposalClose.ReasonResult, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProposalClose ON tblMain.Id = tblProposalClose.DescriptionId ";
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

        objeto_mail.Subject = "Proposal Close Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi Finance,<BR><BR><BR>"

                            + "The proposal has been closed for the following project :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Result : </B>" + row["Result"].ToString() + "<BR><BR>"
                            + "<B>Reason Win / Lose : </B>" + row["ReasonResult"].ToString() + "<BR><BR><BR>"

                            + "<B>Please close the Promotional Code : <U>" + row["Code"].ToString() + "</U> in the Finance system.</B><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailPM()
    {
        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProposalClose.Status, tblProposalClose.Result, tblProposalClose.ReasonResult, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProposalClose ON tblMain.Id = tblProposalClose.DescriptionId ";
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

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Proposal Close Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "The proposal has been closed for the following project :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Result : </B>" + row["Result"].ToString() + "<BR><BR>"
                            + "<B>Reason Win / Lose : </B>" + row["ReasonResult"].ToString() + "<BR><BR>"
                            + "<B>Promotional Code : </B>" + row["Code"].ToString() + "<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailAll()
    {
        //Email notification to ALL
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProposalClose.Status, tblProposalClose.Result, tblProposalClose.ReasonResult, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProposalClose ON tblMain.Id = tblProposalClose.DescriptionId ";
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

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Proposal Status Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi ALL,<BR><BR><BR>"

                            + "Please refer below status for the following project :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Result : </B>" + row["Result"].ToString() + "<BR><BR>"
                            + "<B>Reason Win / Lose : </B>" + row["ReasonResult"].ToString() + "<BR><BR><BR>"

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
        //Client Feedback Form
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/FeedbackForm";

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
                qs = qs + "UPDATE  tblProposalClose SET FeedbackForm = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
        //Client Feedback Form
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalClose SET FeedbackForm = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/FeedbackForm/" + lblURLA1.Text + "";

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
        //Client Feedback Form
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA2_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        String pathfolder = "Upload/";
        String filenameStr = fldA2Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/LOA";

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
                qs = qs + "UPDATE  tblProposalClose SET ContractLOA = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
        //Contract / LOA
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalClose SET ContractLOA = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A2");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/LOA/" + lblURLA2.Text + "";

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
        //Contract / LOA
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }

}