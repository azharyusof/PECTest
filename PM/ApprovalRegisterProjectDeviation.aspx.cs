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

public partial class ApprovalRegisterProjectDeviation : System.Web.UI.Page
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
            //Bind dropdownlist
            bindCompany();
            bindUnit();
            bindClientName();
            bindProjectManager();
            bindProjectDirector();
            bindPIC1();
            bindPIC2();
            bindHSERep();

            bindDetails();

            //Check approval details 
            qs = "";
            qs = qs + " SELECT        AppDateCOO, NotAppDateCOO, AppStatusCOO, AppCommentCOO ";
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

                object dtA = row["AppDateCOO"];
                object dtNA = row["NotAppDateCOO"];

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
                else if (dtA == DBNull.Value && dtNA != DBNull.Value)
                {
                    dvApprove.Visible = false;
                    dvReject.Visible = true;
                    btnApprove.Enabled = false;
                    btnNotApprove.Enabled = false;
                    fldJustification.Enabled = false;
                }
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
        fldCompany.Items.Insert(0, new ListItem("-- Select Operating Company --", ""));
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
        fldUnit.Items.Insert(0, new ListItem("-- Select Operating Unit --", ""));
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
        fldClientName.Items.Insert(0, new ListItem("-- Select Client Name --", ""));
        fldClientName.Items.Insert(1, new ListItem("+ Add New Client +", "addNewClient"));
    }
    
    protected void bindProjectManager()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'ProjectManager' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPM.DataSource = GetData(qs);
        fldPM.DataTextField = "StaffName";
        fldPM.DataValueField = "StaffNo";
        fldPM.DataBind();
        fldPM.Items.Insert(0, new ListItem("-- Select Project Manager --", ""));
    }

    protected void bindProjectDirector()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadUnit' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPD.DataSource = GetData(qs);
        fldPD.DataTextField = "StaffName";
        fldPD.DataValueField = "StaffNo";
        fldPD.DataBind();
        fldPD.Items.Insert(0, new ListItem("-- Select Project Director --", ""));
    }

    protected void bindPIC1()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldPIC1.DataSource = GetData(qs);
        fldPIC1.DataTextField = "StaffName";
        fldPIC1.DataValueField = "StaffNo";
        fldPIC1.DataBind();
        fldPIC1.Items.Insert(0, new ListItem("-- Select Person In Charge [1] --", ""));
    }

    protected void bindPIC2()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldPIC2.DataSource = GetData(qs);
        fldPIC2.DataTextField = "StaffName";
        fldPIC2.DataValueField = "StaffNo";
        fldPIC2.DataBind();
        fldPIC2.Items.Insert(0, new ListItem("-- Select Person In Charge [2] --", ""));
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
        fldHSERep.Items.Insert(0, new ListItem("-- Select HSE Liaison Rep. --", ""));
    }

    protected void bindDetails()
    {
        //Display project details 
        //qs = "";
        //qs = qs + " SELECT        tblProjectRecord.*, tblMain.Code,  ";
        //qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        //qs = qs + "               StaffLogin.StaffName AS COOApproverName ";
        //qs = qs + " FROM          tblProjectRecord ";
        //qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " INNER JOIN    StaffLogin ON tblProjectRecord.ApprovedByCOO = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        //qs = qs + " INNER JOIN    tblMain ON tblProjectRecord.DescriptionId = tblMain.Id ";
        //qs = qs + " WHERE         tblProjectRecord.DescriptionId = '" + Request.QueryString["Id"] + "' ";

        qs = "";
        qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code,  ";
        qs = qs + "                     tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "                     tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "                     StaffLogin.StaffName AS COOApproverName ";
        qs = qs + " FROM                tblProjectRecord ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin ON tblProjectRecord.ApprovedByCOO = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
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

            //--------------------------------------- Contract / LOA ---------------------------------------
            //Contract / LOA
            object fn1 = row["ContractLOA"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                lblFileNameCL_Empty.Visible = true;
            }
            else
            {
                lblFileNameCL.Visible = true;
                lblFileNameCL.Text = row["ContractLOA"].ToString();
            }

            //--------------------------------------- Letter of Acceptance ---------------------------------------
            //Letter of Acceptance
            object fn2 = row["LetterAcceptance"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                lblFileNameLOA_Empty.Visible = true;
            }
            else
            {
                lblFileNameLOA.Visible = true;
                lblFileNameLOA.Text = row["LetterAcceptance"].ToString();
            }

            //--------------------------------------- Supporting Doc ---------------------------------------
            //Supporting Doc
            object fn3 = row["SupportingDoc"];
            if (fn3 == DBNull.Value || fn3 == "")
            {
                lblFileNameSD_Empty.Visible = true;
            }
            else
            {
                lblFileNameSD.Visible = true;
                lblFileNameSD.Text = row["SupportingDoc"].ToString();
            }

            //...................................Deviation Approval Status...................................
            //Approver - Name
            lblApprover.Text = row["COOApproverName"].ToString();

            //Date Approved
            object dt8 = row["AppDateCOO"];
            if (dt8 == DBNull.Value)
            {
                lblDtApproved.Text = "Pending";
                lblDtApproved.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtApproved.Text = Convert.ToDateTime(row["AppDateCOO"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Date Rejected
            object dt9 = row["NotAppDateCOO"];
            if (dt9 == DBNull.Value)
            {
                lblDtReject.Text = "Pending";
                lblDtReject.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtReject.Text = Convert.ToDateTime(row["NotAppDateCOO"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Justification
            fldJustification.Text = row["AppCommentCOO"].ToString();

            //...................................end of Deviation Approval Status...................................

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
                        
        }

    }
     
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        //Update in table tblProjectRecord
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        DateTime now = DateTime.Now;

        SqlCommand cmdR = new SqlCommand("UPDATE tblProjectRecord SET "
                + "AppStatusCOO = 'Approved', "
                + "AppDateCOO = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        cmdR.ExecuteNonQuery();

        con.Close();

        //Email notification to Finance Team & cc PM
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS PDName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.ProjectDirector = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
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

                            + "FYI, the deviation request for the following project has been <B>APPROVED</B> by the COO.<BR><BR><BR>"

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
                + "VALUES ('" + Request.QueryString["Id"] + "', 'No')", con);

        cmdInsertProject.ExecuteNonQuery();

        con.Close();

        //Redirect to update page
        Response.Redirect("ApprovalRegisterProjectDeviation.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnNotApprove_Click(object sender, EventArgs e)
    {
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
            //Update in table tblProposalEvaluation
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            DateTime now = DateTime.Now;

            SqlCommand cmdNR = new SqlCommand("UPDATE tblProjectRecord SET "
                    + "AppStatusCOO = 'Rejected', "
                    + "NotAppDateCOO = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "AppCommentCOO = @pJustification "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            //Justification
            cmdNR.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

            cmdNR.ExecuteNonQuery();

            con.Close();

            //Email notification to Project Manager
            //---------------------------------------- send email -----------------------------------------  
            qs = "";
            qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, ";
            qs = qs + "               tblProjectRecord.ApprovedByCOO, tblProjectRecord.AppCommentCOO, ";
            qs = qs + "               tblClient.ClientName AS ClientName, ";
            qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
            qs = qs + "               StaffLogin_1.StaffName AS PDName, ";
            qs = qs + "               StaffLogin_2.StaffName AS ApproverName ";
            qs = qs + " FROM          tblMain ";
            qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
            qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.ProjectDirector = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_2 ON tblProjectRecord.ApprovedByCOO = StaffLogin_2.StaffNo COLLATE Latin1_General_CI_AI ";
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

            objeto_mail.Subject = "Rejected : Request for Deviation Approval for '" + row["Description"].ToString() + "'";

            string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:TAHOMA,8PT;>"
                                + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                                + "Your request for the following project is <B>REJECTED</B>. Please read the remarks by COO below.<BR><BR><BR>"

                                + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                                + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                                + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                                + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                                + "<B>Project Director : </B>" + row["PDName"].ToString() + "<BR><BR>"
                                + "<B>Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())) + "<BR><BR>"
                                + "<B>COO : </B>" + row["ApproverName"].ToString() + "<BR><BR>"
                                + "<B>DAL Remarks : </B>" + row["AppCommentCOO"].ToString() + "<BR><BR><BR>"

                                + "<BR><BR><BR>Thank you.<BR><BR>"
                                + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

            objeto_mail.Body = htmlText;
            objeto_mail.IsBodyHtml = true;

            client.Send(objeto_mail);
            //---------------------------------- end of send email ----------------------------------------

            //Redirect to update page
            Response.Redirect("ApprovalRegisterProjectDeviation.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
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
}