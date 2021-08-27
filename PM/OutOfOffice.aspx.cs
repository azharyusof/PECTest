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

public partial class OutOfOffice : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {
            
        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }
       
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvHSEInduction.Attributes.Add("class", null);
        dvEOSP.Attributes.Add("class", null);
        dvKTM038.Attributes.Add("class", null);
        dvCIDB.Attributes.Add("class", null);
        dvPPE.Attributes.Add("class", null);
        dvLegalRegister.Attributes.Add("class", null);
        dvHIRARC.Attributes.Add("class", null);
        dvEnvAI.Attributes.Add("class", null);
        dvProjectName.Attributes.Add("class", null);
        dvPM.Attributes.Add("class", null);
        dvHSSE.Attributes.Add("class", null);
        dvDateTime.Attributes.Add("class", null);
        dvLocation.Attributes.Add("class", null);
        dvReason.Attributes.Add("class", null);
        dvAck.Attributes.Add("class", null);

        if (!cbHSEInduction.Checked && !cbEOSP.Checked && !cbKTM038.Checked && !cbCIDB.Checked && !cbPPE.Checked && !cbLegalRegister.Checked && !cbHIRARC.Checked && !cbEnvAI.Checked)
        {
            chckErr = false;
            dvHSEInduction.Attributes.Add("class", "has-error");            
            dvEOSP.Attributes.Add("class", "has-error");
            dvKTM038.Attributes.Add("class", "has-error");
            dvCIDB.Attributes.Add("class", "has-error");
            dvPPE.Attributes.Add("class", "has-error");
            dvLegalRegister.Attributes.Add("class", "has-error");
            dvHIRARC.Attributes.Add("class", "has-error");
            dvEnvAI.Attributes.Add("class", "has-error");
        }

        if (fldProjectName.Text.Trim() == "")
        {
            chckErr = false;
            dvProjectName.Attributes.Add("class", "has-error");
        }

        if (fldPMEmail.Text.Trim() == "")
        {
            chckErr = false;
            dvPM.Attributes.Add("class", "has-error");
        }

        if (fldHSSEEmail.Text.Trim() == "")
        {
            chckErr = false;
            dvHSSE.Attributes.Add("class", "has-error");
        }

        if (fldDateTime.Text.Trim() == "")
        {
            chckErr = false;
            dvDateTime.Attributes.Add("class", "has-error");
        }

        if (fldLocation.Text.Trim() == "")
        {
            chckErr = false;
            dvLocation.Attributes.Add("class", "has-error");
        }

        if (fldReasonForVisit.Text.Trim() == "")
        {
            chckErr = false;
            dvReason.Attributes.Add("class", "has-error");
        }

        if (!cbAck.Checked)
        {
            chckErr = false;
            dvAck.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            insertOutOfOffice();
            emailPM();

            Response.Redirect("OutOfOffice.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void insertOutOfOffice()
    {
        DateTime now = DateTime.Now;
        string cb1 = string.Empty;
        string cb2 = string.Empty;
        string cb3 = string.Empty;
        string cb4 = string.Empty;
        string cb5 = string.Empty;
        string cb6 = string.Empty;
        string cb7 = string.Empty;
        string cb8 = string.Empty;
        string cb9 = string.Empty;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Insert into table tblHSEOutOffice
        SqlCommand cmd = new SqlCommand("INSERT INTO tblHSEOutOffice (DescriptionId, HSEInduction, EOSP, KTM038, CIDB, PPE, LegalRegister, HIRARC, EnvAI, ProjectName, PMEmail, HSSEEmail, DateTime, Location, ReasonForVisit, Acknowledgement, CreatedBy, DateCreated) VALUES "
                + " ('" + Request.QueryString["Id"] + "', @pHSEInduction, @pEOSP, @pKTM038, @pCIDB, @pPPE, @pLegalRegister, @pHIRARC, @pEnvAI, @pProjectName, @pPMEmail, @pHSSEEmail, @pDateTime, @pLocation, @pReasonForVisit, @pAck, @pCreatedBy, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')", con);
        
        //HSE Induction Training Awareness
        if (cbHSEInduction.Checked)
        { cb1 = "Yes"; }
        else
        { cb1 = "No"; }

        cmd.Parameters.AddWithValue("@pHSEInduction", cb1);

        //EOSP (If Perform Work At Expressway)
        if (cbEOSP.Checked)
        { cb2 = "Yes"; }
        else
        { cb2 = "No"; }

        cmd.Parameters.AddWithValue("@pEOSP", cb2);

        //KTM038 (If Perform Work At KTMB Project)
        if (cbKTM038.Checked)
        { cb3 = "Yes"; }
        else
        { cb3 = "No"; }

        cmd.Parameters.AddWithValue("@pKTM038", cb3);

        //CIDB (For Any Construction Site Include Site Visit For Inspection)
        if (cbCIDB.Checked)
        { cb4 = "Yes"; }
        else
        { cb4 = "No"; }

        cmd.Parameters.AddWithValue("@pCIDB", cb4);

        //PPE (To Suit According To Nature Of Work)
        if (cbPPE.Checked)
        { cb5 = "Yes"; }
        else
        { cb5 = "No"; }

        cmd.Parameters.AddWithValue("@pPPE", cb5);

        //Legal Register
        if (cbLegalRegister.Checked)
        { cb6 = "Yes"; }
        else
        { cb6 = "No"; }

        cmd.Parameters.AddWithValue("@pLegalRegister", cb6);

        //HIRARC (Hazard Identification, Risk Assessment and Risk Control)
        if (cbHIRARC.Checked)
        { cb7 = "Yes"; }
        else
        { cb7 = "No"; }

        cmd.Parameters.AddWithValue("@pHIRARC", cb7);

        //Environmental Aspect & Impact
        if (cbEnvAI.Checked)
        { cb8 = "Yes"; }
        else
        { cb8 = "No"; }

        cmd.Parameters.AddWithValue("@pEnvAI", cb8);

        //Project Name
        cmd.Parameters.AddWithValue("@pProjectName", fldProjectName.Text.Trim());

        //PM's Email
        cmd.Parameters.AddWithValue("@pPMEmail", fldPMEmail.Text.Trim());

        //HSSE's Email
        cmd.Parameters.AddWithValue("@pHSSEEmail", fldHSSEEmail.Text.Trim());

        //Date / Time
        cmd.Parameters.AddWithValue("@pDateTime", fldDateTime.Text.Trim());

        //Location
        cmd.Parameters.AddWithValue("@pLocation", fldLocation.Text.Trim());

        //Reason For Visit
        cmd.Parameters.AddWithValue("@pReasonForVisit", fldReasonForVisit.Text.Trim());
        
        //Avknowledgement
        if (cbAck.Checked)
        { cb9 = "Yes"; }
        else
        { cb9 = "No"; }

        cmd.Parameters.AddWithValue("@pAck", cb9);

        //Created By
        cmd.Parameters.AddWithValue("@pCreatedBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();
    }

    protected void emailPM()
    {
        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        TOP 1 * ";
        qs = qs + " FROM          tblHSEOutOffice ";
        qs = qs + " ORDER BY      Id DESC ";

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
        //objeto_mail.To.Add(new MailAddress(row["HSSEEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Out of Office Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "<B>Project Name : </B>" + row["ProjectName"].ToString() + "<BR><BR>"
                            + "<B>Date / Time : </B>" + Convert.ToDateTime(row["DateTime"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                            + "<B>Location : </B>" + row["Location"].ToString() + "<BR><BR>"
                            + "<B>Reason For Visit : </B>" + row["ReasonForVisit"].ToString() + "<BR><BR>"
                            
                            + "<B>HSE Induction Training Awareness : </B>" + row["HSEInduction"].ToString() + "<BR><BR>"
                            + "<B>EOSP : </B>" + row["EOSP"].ToString() + "<BR><BR>"
                            + "<B>KTM038 : </B>" + row["KTM038"].ToString() + "<BR><BR>"
                            + "<B>CIDB Green Card : </B>" + row["CIDB"].ToString() + "<BR><BR>"
                            + "<B>Do You Have Proper PPE? : </B>" + row["PPE"].ToString() + "<BR><BR>"
                            + "<B>Legal Register : </B>" + row["LegalRegister"].ToString() + "<BR><BR>"
                            + "<B>HIRARC : </B>" + row["HIRARC"].ToString() + "<BR><BR>"
                            + "<B>Environmental Aspect & Impact : </B>" + row["EnvAI"].ToString() + "<BR><BR><BR>"
                            
                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }
}