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

public partial class ProjectClosingDetailInactive : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
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

        bindDuration();
        bindFinancialPlanning();
        bindSubConFinalClaim();

        if (!Page.IsPostBack)
        {
            checkRole();
            checkStatus(); 

            bindDetails();            
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
            }
            else
            {
                btnUpdate.Visible = true;
            }
        }
    }

    protected void checkStatus()
    {
        qs = "";
        qs = qs + " SELECT        BtnSubmit ";
        qs = qs + " FROM          tblProjectClose ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            if (row["BtnSubmit"].ToString() == "NULL")
            {
                btnUpdate.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }
    }

    protected void bindDuration()
    {
        // Bind data to the dropdownlist control.
        fldDuration.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldDuration.Items.Insert(1, new ListItem("day(s)", "day(s)"));
        fldDuration.Items.Insert(2, new ListItem("week(s)", "week(s)"));
        fldDuration.Items.Insert(3, new ListItem("month(s)", "month(s)"));
        fldDuration.Items.Insert(4, new ListItem("year(s)", "year(s)"));
    }

    protected void bindFinancialPlanning()
    {
        // Bind data to the dropdownlist control.
        fldUpdateFinancialPlanning.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldUpdateFinancialPlanning.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldUpdateFinancialPlanning.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindSubConFinalClaim()
    {
        // Bind data to the dropdownlist control.
        fldSubConFinalClaim.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldSubConFinalClaim.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldSubConFinalClaim.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProjectInactive.*, tblMain.ProjectCode, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblProjectInactive ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectInactive.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectInactive.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN          tblMain ON tblProjectInactive.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblProjectInactive.DescriptionId = '" + Request.QueryString["Id"] + "' ";
        
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

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();

            //Request System to Be Inactive
            if (row["RequestInactive"].ToString() == "Yes")
            {
                cbRequestInactive.Checked = true;
            }

            //Reason
            fldReason.Text = row["Reason"].ToString();

            //Duration
            fldDurationNo.Text = row["DurationNo"].ToString();
            fldDuration.Text = row["Duration"].ToString();

            //Notify Finance to Freeze Timesheet?
            if (row["NotifyFinance"].ToString() == "Yes")
            {
                cbNotifyFinance.Checked = true;
            }

            //Retention Sum Claimed?
            fldRetentionSumClaimed.Text = row["RetentionSumClaimed"].ToString();

            //Update Financial Planning?
            fldUpdateFinancialPlanning.Text = row["UpdateFinancialPlanning"].ToString();

            //Outstanding Amount to Bill?
            fldOutAmountToBill.Text = row["OutAmountToBill"].ToString();

            //Outstanding Amount Uncollected?
            fldOutAmountUncollected.Text = row["OutAmountUncollected"].ToString();

            //Have Sub Consultant's Submitted Final Claim
            fldSubConFinalClaim.Text = row["SubConFinalClaim"].ToString();

            //Have Sub Consultant's Submitted Final Claim Remarks
            fldSubConFinalClaimRemarks.Text = row["SubConFinalClaimRemarks"].ToString();

            //Remarks
            fldRemarks.Text = row["Remarks"].ToString();

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

        }
    }

   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateInactive();

        Response.Redirect("ProjectClosingDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvRequestInactive.Attributes.Add("class", null);
        dvReason.Attributes.Add("class", null);

        if (!cbRequestInactive.Checked)
        {
            chckErr = false;
            dvRequestInactive.Attributes.Add("class", "has-error");
        }

        if (fldReason.Text.Trim() == "")
        {
            chckErr = false;
            dvReason.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateInactive();
            emailPM();
            emailFinance();
            emailKMDC();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblProjectInactive SET "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            Response.Redirect("ProjectClosingDetail.aspx?Id=" + Request.QueryString["Id"]);                        
        }
    }

    protected void updateInactive()
    {
        DateTime now = DateTime.Now;
        string cb1 = string.Empty;
        string cb2 = string.Empty;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblProjectInactive
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectInactive SET "
                + "RequestInactive = @pRequestInactive, "
                + "Reason = @pReason, "
                + "DurationNo = @pDurationNo, "
                + "Duration = @pDuration, "
                + "NotifyFinance = @pNotifyFinance, "
                + "RetentionSumClaimed = @pRetentionSumClaimed, "
                + "UpdateFinancialPlanning = @pUpdateFinancialPlanning, "
                + "OutAmountToBill = @pOutAmountToBill, "
                + "OutAmountUncollected = @pOutAmountUncollected, "
                + "SubConFinalClaim = @pSubConFinalClaim, "
                + "SubConFinalClaimRemarks = @pSubConFinalClaimRemarks, "
                + "Remarks = @pRemarks, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //Request System to Be Inactive
        if (cbRequestInactive.Checked)
        { cb1 = "Yes"; }
        else
        { cb1 = "No"; }

        cmd.Parameters.AddWithValue("@pRequestInactive", cb1);

        //Reason
        cmd.Parameters.AddWithValue("@pReason", fldReason.Text.Trim());

        //Duration
        cmd.Parameters.AddWithValue("@pDurationNo", fldDurationNo.Text);
        cmd.Parameters.AddWithValue("@pDuration", fldDuration.SelectedValue);

        //Notify Finance to Freeze Timesheet?
        if (cbNotifyFinance.Checked)
        { cb2 = "Yes"; }
        else
        { cb2 = "No"; }

        cmd.Parameters.AddWithValue("@pNotifyFinance", cb2);

        //Retention Sum Claimed?
        cmd.Parameters.AddWithValue("@pRetentionSumClaimed", fldRetentionSumClaimed.Text);

        //Update Financial Planning?
        cmd.Parameters.AddWithValue("@pUpdateFinancialPlanning", fldUpdateFinancialPlanning.SelectedValue);

        //Outstanding Amount to Bill?
        cmd.Parameters.AddWithValue("@pOutAmountToBill", fldOutAmountToBill.Text);

        //Outstanding Amount Uncollected?
        cmd.Parameters.AddWithValue("@pOutAmountUncollected", fldOutAmountUncollected.Text);

        //Have Sub Consultant's Submitted Final Claim?
        cmd.Parameters.AddWithValue("@pSubConFinalClaim", fldSubConFinalClaim.SelectedValue);

        //Have Sub Consultant's Submitted Final Claim Remarks
        cmd.Parameters.AddWithValue("@pSubConFinalClaimRemarks", fldSubConFinalClaimRemarks.Text.Trim());

        //Remarks
        cmd.Parameters.AddWithValue("@pRemarks", fldRemarks.Text.Trim());
                
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
        client.Host = "smtp.uemedgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Project Inactive Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Status for the following project has been changed to <U>INACTIVE</U> :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Status : </B>Inactive<BR><BR><BR>"

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
        client.Host = "smtp.uemedgenta.com";
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

                            + "Please freeze the <U>Project Code</U> in Deltek Vision system. No time input is allowed.<BR><BR>"

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
        client.Host = "smtp.uemedgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Project Inactive Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi KMDC,<BR><BR><BR>"

                            + "Status for the following project has been changed to <U>INACTIVE</U> :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Status : </B>Inactive<BR><BR><BR>"

                            + "Please follow-up with PM for the hardcopy submission of all project related documents.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }
}