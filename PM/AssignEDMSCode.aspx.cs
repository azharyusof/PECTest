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

public partial class AssignEDMSCode : System.Web.UI.Page
{
    DataRow row = null;
    DataRow row1 = null;
    String qs = "";
    String qs1 = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fldNewClientName.Visible = false;

            //Hide all upload
            bindCompany();
            bindUnit();
            bindClientName();

            bindProjectManager();
            bindProjectDirector();
            bindPIC1();
            bindPIC2();
            //bindHSERep();
            bindEDMSCode();
            bindEDMSCode1();

            bindDetails();

            qs = "";
            qs = qs + " SELECT        DESCRIPTION ";
            qs = qs + " FROM          vwEDMSMain ";
            qs = qs + " WHERE         PROJECT_CODE = '" + fldEDMSCode.SelectedValue + "' ";

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

                fldEDMSName.Text = row["DESCRIPTION"].ToString();
            }

            qs1 = "";
            qs1 = qs1 + " SELECT        DESCRIPTION ";
            qs1 = qs1 + " FROM          vwEDMSMain ";
            qs1 = qs1 + " WHERE         PROJECT_CODE = '" + fldEDMSCode1.SelectedValue + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs1, con);
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
                DataRow row1 = dt1.Rows[0];

                fldEDMSName1.Text = row1["DESCRIPTION"].ToString();
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

    //protected void bindHSERep()
    //{
    //    // Bind data to the dropdownlist control.
    //    qs = "";
    //    qs = qs + " SELECT        StaffNo, StaffName ";
    //    qs = qs + " FROM          StaffLogin ";
    //    qs = qs + " WHERE         Role = 'HSE' ";
    //    qs = qs + " ORDER BY      StaffName ";

    //    fldHSERep.DataSource = GetData(qs);
    //    fldHSERep.DataTextField = "StaffName";
    //    fldHSERep.DataValueField = "StaffNo";
    //    fldHSERep.DataBind();
    //    fldHSERep.Items.Insert(0, new ListItem("-- Please select one --", ""));
    //}

    protected void bindEDMSCode()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        PROJECT_CODE ";
        qs = qs + " FROM          vwEDMSMain ";
        qs = qs + " ORDER BY      PROJECT_CODE ";

        fldEDMSCode.DataSource = GetData(qs);
        fldEDMSCode.DataTextField = "PROJECT_CODE";
        fldEDMSCode.DataValueField = "PROJECT_CODE";
        fldEDMSCode.DataBind();
        fldEDMSCode.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void fldEDMSCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        qs = "";
        qs = qs + " SELECT        DESCRIPTION ";
        qs = qs + " FROM          vwEDMSMain ";
        qs = qs + " WHERE         PROJECT_CODE = '" + fldEDMSCode.SelectedValue + "' ";

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

            fldEDMSName.Text = row["DESCRIPTION"].ToString();            
        }
    }

    protected void bindEDMSCode1()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        PROJECT_CODE ";
        qs = qs + " FROM          vwEDMSMain ";
        qs = qs + " ORDER BY      PROJECT_CODE ";

        fldEDMSCode1.DataSource = GetData(qs);
        fldEDMSCode1.DataTextField = "PROJECT_CODE";
        fldEDMSCode1.DataValueField = "PROJECT_CODE";
        fldEDMSCode1.DataBind();
        fldEDMSCode1.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void fldEDMSCode1_SelectedIndexChanged(object sender, EventArgs e)
    {
        qs = "";
        qs = qs + " SELECT        DESCRIPTION ";
        qs = qs + " FROM          vwEDMSMain ";
        qs = qs + " WHERE         PROJECT_CODE = '" + fldEDMSCode1.SelectedValue + "' ";

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

            fldEDMSName1.Text = row["DESCRIPTION"].ToString();
        }
    }


    protected void bindDetails()
    {
        //Display project details 
        qs = "";
        qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code, tblMain.PreProjectCode, tblMain.ProjectCode, tblMain.OldCode, tblMain.EDMSDateCreated, tblMain.EDMSCode, tblMain.EDMSCode1, ";
        qs = qs + "                     tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "                     tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM                tblProjectRecord ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblCREATEBY ON tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN dbo.StaffLogin AS tblUPDATEBY ON tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = dbo.tblProjectRecord.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblProjectRecord.DescriptionId = dbo.tblMain.Id ";
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

            //Regular Code
            fldProjectCode.Text = row["ProjectCode"].ToString();

            //Regular Code (Old)
            fldOldCode.Text = row["OldCode"].ToString();

            if (fldOldCode.Text == "")
            {
                dvOldCode.Visible = false;
            }

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

            ////HSE Liaison Representative
            //fldHSERep.Text = row["HSERep"].ToString();

            //EDMS Code
            fldEDMSCode.Text = row["EDMSCode"].ToString();
            fldEDMSCode1.Text = row["EDMSCode1"].ToString();

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

            //EDMS Code
            //...................................EDMS Code ...................................
            ////Date Created
            //object dt8 = row["EDMSDateCreated"];
            //if (dt8 == DBNull.Value)
            //{
            //    lblDtEDMSCreated.Text = "Pending";
            //    lblDtEDMSCreated.ForeColor = System.Drawing.Color.FromName("Red");
            //}
            //else
            //{ 
            //    lblDtEDMSCreated.Text = Convert.ToDateTime(row["EDMSDateCreated"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); 
            //}
            //...................................end of EDMS Code...................................

            if (row["EDMSCode"] == DBNull.Value)
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
        dvEDMSCode.Attributes.Add("class", null);

        if (fldEDMSCode.SelectedIndex == 0)
        {
            chckErr = false;
            dvEDMSCode.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Update in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            DateTime now = DateTime.Now;

            SqlCommand cmdR = new SqlCommand("UPDATE tblMain SET "
                        + "EDMSCode = @pEDMSCode, "
                        + "EDMSCode1 = @pEDMSCode1, "
                        + "EDMSCreatedBy = 'KMDC', "
                        + "EDMSDateCreated = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                        + "WHERE Id = '" + Request.QueryString["Id"] + "'", con);

            //EDMS Code
            cmdR.Parameters.AddWithValue("@pEDMSCode", fldEDMSCode.Text);
            cmdR.Parameters.AddWithValue("@pEDMSCode1", fldEDMSCode1.Text);

            cmdR.ExecuteNonQuery();

            con.Close();

            bindDetails();

            emailPM();
        }

        //Redirect to update page
        Response.Redirect("AssignEDMSCode.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void emailPM()
    {
        string edms_code = "";

        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.ProjectCode, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.EDMSCode, tblMain.EDMSCode1, vwEDMSMain.Description AS EDMSDesc, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN vwEDMSMain ON tblMain.EDMSCode = vwEDMSMain.Project_Code COLLATE Latin1_General_CI_AI ";
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

        if (row["EDMSCode1"].ToString() != "")
        {
            edms_code = row["EDMSCode"].ToString() + " & " + row["EDMSCode1"].ToString();
        }        
        else
        {
            edms_code = row["EDMSCode"].ToString();
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.CC.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Approved  : Request EDMS Link For PEC";

        string htmlText = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Your request for the following project has been approved. <BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Project Code : </B>" + row["ProjectCode"].ToString() + "<BR><BR>"
                            + "<B>EDMS Code : </B>" + edms_code + "<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
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
