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

public partial class CreateProjectDbCode : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    String qs = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

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
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' ";
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
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' or Role = 'HeadDivision' ";
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
        //qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code, tblMain.ProjectCode, ";
        //qs = qs + "                     tblCREATEBY.StaffName As CREATEBYName,  ";
        //qs = qs + "                     tblUPDATEBY.StaffName As UPDATEBYName,  ";
        //qs = qs + "                     StaffLogin.StaffName AS COOApproverName ";
        //qs = qs + " FROM                tblProjectRecord ";
        //qs = qs + " LEFT OUTER JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        //qs = qs + " LEFT OUTER JOIN     StaffLogin ON tblProjectRecord.ApprovedByCOO = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        //qs = qs + " INNER JOIN          tblMain ON tblProjectRecord.DescriptionId = tblMain.Id ";
        //qs = qs + " WHERE               tblProjectRecord.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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
        qs = qs + " LEFT OUTER JOIN dbo.vwProjectRecordApproval ON dbo.tblProjectRecord.DescriptionId = dbo.vwProjectRecordApproval.DescriptionId ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblDAL ON dbo.vwProjectRecordApproval.AppBy COLLATE Latin1_General_CI_AI = tblDAL.StaffNo ";
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

            //Submission Status
            lblSubmissionStatus.Text = row["SubmissionStatus"].ToString();

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

            //...................................Project DB Approval...................................  
            //.................................................Approver.................................................
            //Approver - Name
            lblProjDBApprover.Text = row["BMApprovalName"].ToString() + "  &  " + row["COOApprovalName"].ToString();

            //Approver - Date Approved 
            object dtDA = row["BMApprovalDt"];
            object dtDB = row["COOApprovalDt"];
            if (dtDA != DBNull.Value && dtDB != DBNull.Value)
            {
                lblProjDB_ApprovedDate.Text = Convert.ToDateTime(row["BMApprovalDt"].ToString()).ToString("dd-MMM-yyyy") + "  &  " + Convert.ToDateTime(row["COOApprovalDt"].ToString()).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblProjDB_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblProjDB_ApprovedStatus.Text = row["DALAppStatus"].ToString(); }
            else
            { lblProjDB_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            lblProjDB_ApprovedComment.Text = "-";

            //Approver - Remarks
            lblOldProjDBRemarks.Text = row["OldDALRemarks"].ToString();

            //...................................end of Project DB Approval...................................

            if (row["SubmissionStatus"].ToString() == "Project")
            {
                dvDALApproval.Visible = true;
            }
            else if (row["SubmissionStatus"].ToString() == "Deviation")
            {
                dvDALApproval.Visible = false;
            }
            else if (row["SubmissionStatus"].ToString() == "Deviation Project")
            {
                dvDALApproval.Visible = false;
            }

            //Promotional Code
            lblCode.Text = row["Code"].ToString();

            //Project Code
            fldCode.Text = row["ProjectCode"].ToString();

            if (row["ProjectCode"] == DBNull.Value)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvCode.Attributes.Add("class", null);

        if (fldCode.Text.Trim() == "")
        {
            chckErr = false;
            dvCode.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Update in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            DateTime now = DateTime.Now;

            if (lblSubmissionStatus.Text == "Project")
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblMain SET "
                    + "ProjectCode = @pCode, "
                    + "ProjectCodeCreatedBy = 'FIN', "
                    + "ProjectCodeDateCreated = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "'", con);

                //Project Code
                cmd.Parameters.AddWithValue("@pCode", fldCode.Text);

                cmd.ExecuteNonQuery();
            }
            else if (lblSubmissionStatus.Text == "Deviation")
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblMain SET "
                    + "PreProjectCode = @pCode, "
                    + "PreProjectCodeCreatedBy = 'FIN', "
                    + "PreProjectCodeDateCreated = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "'", con);

                //Pre-Project Code
                cmd.Parameters.AddWithValue("@pCode", fldCode.Text);

                cmd.ExecuteNonQuery();
            }

            SqlCommand cmdInsertCode = new SqlCommand("INSERT INTO tblCodeHistory (DescriptionId, Code, Category, CreatedBy, DateCreated) "
                + "VALUES ('" + Request.QueryString["Id"] + "', @pCode, '" + lblSubmissionStatus.Text + "', 'FIN', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')", con);

            //Project Code
            cmdInsertCode.Parameters.AddWithValue("@pCode", fldCode.Text);

            cmdInsertCode.ExecuteNonQuery();

            con.Close();

            bindDetails();
        }

        emailPM();

        Response.Redirect("CreateProjectDbCode.aspx?Id=" + Request.QueryString["Id"]);
    }
    

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
    }
 

    protected void emailPM()
    {
        string code = "";
        
        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.PreProjectCode, tblMain.ProjectCode, ";
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
        //client.Host = "smtp.uemedgenta.com";
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));
        
        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "New Project Code Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Please be informed that the <B>PROJECT CODE</B> has been created in the Project Execution Control.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Project Code : </B>" + row["ProjectCode"].ToString() + "<BR><BR><BR>"

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

    protected void btnViewA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA3_Click(object sender, EventArgs e)
    {
        //Supporting Document  
        Response.Write("<script> window.open( '" + hidURLA3.Value.ToString() + "','_blank' ); </script>");
    }
}