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
public partial class ProjectInitiationDetail : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String queryString = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

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

            dvUpA11Sec.Visible = true;
            dvVwA11Sec.Visible = false;

            bindBoardRequired();
            bindDetails();
            bindRisk();
            bindGrossRating();
            bindRiskCategory();
            bindLikelihood();
            bindImpact();

            bindAgreement();
            bindPEP();
            bindPQP();
            bindPSP();
            bindLegalRegister();
            bindHIRARC();
            bindEAI();
            bindHSEPlan();
            bindProjectDoc();
            bindOrgChart();
            bindManningSchedule();

            qs = "";
            qs = qs + " SELECT        ProjectDirector,  ";
            qs = qs + "               tblPD.StaffName As PDName  ";
            qs = qs + " FROM          tblProjectRecord ";
            qs = qs + " LEFT OUTER JOIN     StaffLogin As tblPD on tblPD.StaffNo COLLATE DATABASE_DEFAULT = tblProjectRecord.ProjectDirector COLLATE DATABASE_DEFAULT ";
            qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";
            
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open();
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
                
                //Project Director
                lblPDApprover.Text = row["PDName"].ToString();
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

    protected void bindBoardRequired()
    {
        // Bind data to the dropdownlist control.
        fldBoardRequired.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldBoardRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldBoardRequired.Items.Insert(2, new ListItem("No", "No"));
    }
    
    protected void bindGrossRating()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        * ";
        qs = qs + " FROM          tblGrossRating ";
        qs = qs + " ORDER BY      Id ";

        fldGrossRating.DataSource = GetData(qs);
        fldGrossRating.DataTextField = "GrossRating";
        fldGrossRating.DataValueField = "GrossRating";
        fldGrossRating.DataBind();
        fldGrossRating.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    
    protected void bindRiskCategory()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        * ";
        qs = qs + " FROM          tblRiskCategory ";
        qs = qs + " ORDER BY      RiskCategory ";

        fldRiskCategory.DataSource = GetData(qs);
        fldRiskCategory.DataTextField = "RiskCategory";
        fldRiskCategory.DataValueField = "RiskCategory";
        fldRiskCategory.DataBind();
        fldRiskCategory.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindLikelihood()
    {
        // Bind data to the dropdownlist control.
        fldLikelihood.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldLikelihood.Items.Insert(1, new ListItem("Certain", "Certain"));
        fldLikelihood.Items.Insert(2, new ListItem("Likely", "Likely"));
        fldLikelihood.Items.Insert(3, new ListItem("Possible", "Possible"));
        fldLikelihood.Items.Insert(4, new ListItem("Unlikely", "Unlikely"));
        fldLikelihood.Items.Insert(5, new ListItem("Remote", "Remote"));
    }

    protected void bindImpact()
    {
        // Bind data to the dropdownlist control.
        fldImpact.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldImpact.Items.Insert(1, new ListItem("Insignificant", "Insignificant"));
        fldImpact.Items.Insert(2, new ListItem("Minor", "Minor"));
        fldImpact.Items.Insert(3, new ListItem("Moderate", "Moderate"));
        fldImpact.Items.Insert(4, new ListItem("Major", "Major"));
        fldImpact.Items.Insert(5, new ListItem("Catastrophic", "Catastrophic"));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }


    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProjectInitiation.*, tblMain.ProjectCode, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblProjectInitiation ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectInitiation.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT OUTER JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProjectInitiation.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN          tblMain ON tblProjectInitiation.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblProjectInitiation.DescriptionId = '" + Request.QueryString["Id"] + "' ";
        
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

            //--------------------------------------- Board / Management Approval ---------------------------------------
            //Board / Management Approval Required?
            fldBoardRequired.Text = row["BoardRequired"].ToString();

            //--------------------------------------- Board / Management Paper ---------------------------------------
            object fn10 = row["BoardPaper"];
            if (fn10 == DBNull.Value || fn10 == "")
            {
                dvUpA11Sec.Visible = true;
                dvVwA11Sec.Visible = false;
            }
            else
            {
                dvUpA11Sec.Visible = false;
                dvVwA11Sec.Visible = true;

                lblURLA11.Text = row["BoardPaper"].ToString();
                hidURLA11.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/BoardPaper/" + row["BoardPaper"].ToString() + "";
            }

            //Project Code
            object fnCode = row["ProjectCode"];
            if (fnCode == DBNull.Value || fnCode == "")
            {
                lblCode.Text = "Pending at Finance";
                lblCode.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblCode.Text = row["ProjectCode"].ToString();
            }

            //Contract Kick-Off Meeting Performed? 
            if (row["KickOffMeeting"].ToString() == "Yes")
            {
                cbKickOffMeeting.Checked = true;
            }

            //--------------------------------------- Service Agreement ---------------------------------------
            object fn = row["ServiceAgreement"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["ServiceAgreement"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/"+ Request.QueryString["ID"] + "/ServiceAgreement/" + row["ServiceAgreement"].ToString() + "";                
            }
             
            //...................................PD Approval...................................  
            //.................................................Approver.................................................
            //Approver - Date Approved 
            object dtDA = row["AppDate"];
            object dtDNA = row["NotAppDate"];
            if (dtDA != DBNull.Value)
            {
                lblPD_ApprovedDate.Text = Convert.ToDateTime(row["AppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNA != DBNull.Value)
            {
                lblPD_ApprovedDate.Text = Convert.ToDateTime(row["NotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblPD_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["AppStatus"].ToString() != "")
            { lblPD_ApprovedStatus.Text = row["AppStatus"].ToString(); }
            else
            { lblPD_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["AppComment"].ToString() != "")
            { lblPD_ApprovedComment.Text = row["AppComment"].ToString(); }
            else
            { lblPD_ApprovedComment.Text = "-"; }
                        
            //...................................end of PD Approval...................................
                        
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateInitiation();

        Response.Redirect("ProjectInitiationDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvUpA11Sec.Attributes.Add("class", null);

        
        //Board / Management Paper
        if (fldBoardRequired.SelectedIndex == 1)
        {
            if (fldA11Upload.FileName == "" && lblURLA11.Text == "")
            {
                chckErr = false;
                dvUpA11Sec.Attributes.Add("class", "has-error");
            }
        }
                  
        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateInitiation();
            emailPD();

            //Update in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
                    + "Phase = 'Project Initiation' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdUpdate = new SqlCommand("UPDATE tblProjectInitiation SET "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdUpdate.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;
            
            Response.Redirect("ProjectInitiationDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void updateInitiation()
    {
        DateTime now = DateTime.Now;
        string cb1 = string.Empty;
        string cb2 = string.Empty;
        string cb3 = string.Empty;
        
        //Update into table tblProjectInitiation
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectInitiation SET "
                + "KickOffMeeting = @pKickOffMeeting, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //Contract Kick-Off Meeting Performed? 
        if (cbKickOffMeeting.Checked)
        { cb1 = "Yes"; }
        else 
        { cb1 = "No"; }

        cmd.Parameters.AddWithValue("@pKickOffMeeting", cb1);
                        
        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        cmd.ExecuteNonQuery();

        con.Close();
    }

    protected void emailPD()
    {
        //Email notification to Project Director
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblProjectRecord.ProjectDirector, tblMain.OperatingCompany, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS PDName, StaffLogin_1.EmailId AS PDEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
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

        //objeto_mail.To.Add(new MailAddress(row["PDEmail"].ToString()));
        
        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Project Initiation Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PDName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to approve initiation for the following project :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Code : </B>" + row["Code"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalProjectInitiation.aspx?ID=" + row["Id"].ToString() + ">link</A> to approve the request.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    private void bindPEP()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Project Execution Plan' "
            + "ORDER BY       Id DESC ";

        gvPEP.DataSource = GetData(str);
        gvPEP.DataBind();

        for (int i = 0; i < gvPEP.Rows.Count; i++)
        {
            GridViewRow row = gvPEP.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeletePEP(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindPEP();
    }

    protected void btnSaveE1_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName1.Attributes.Add("class", null);

        if (fldFileName1.FileName == "")
        {
            chckErr = false;
            dvFileName1.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Project Execution Plan', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Project Execution Plan
            uploadPEP();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadPEP()
    {
        if (fldFileName1.FileName != "")
        {
            //Update Project Execution Plan
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Project Execution Plan' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/PEP/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName1.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName1.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName1.PostedFiles)
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

    protected void btnCloseE1_Click(object sender, EventArgs e)
    {
    }

    private void bindPQP()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'PQP' "
            + "ORDER BY       Id DESC ";

        gvPQP.DataSource = GetData(str);
        gvPQP.DataBind();

        for (int i = 0; i < gvPQP.Rows.Count; i++)
        {
            GridViewRow row = gvPQP.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeletePQP(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindPQP();
    }

    protected void btnSaveE2_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName2.Attributes.Add("class", null);

        if (fldFileName2.FileName == "")
        {
            chckErr = false;
            dvFileName2.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('PQP', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //PQP
            uploadPQP();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadPQP()
    {
        if (fldFileName2.FileName != "")
        {
            //Update PQP
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'PQP' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/PQP/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName2.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName2.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName2.PostedFiles)
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

    protected void btnCloseE2_Click(object sender, EventArgs e)
    {
    }

    private void bindLegalRegister()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Legal Register' "
            + "ORDER BY       Id DESC ";

        gvLegalRegister.DataSource = GetData(str);
        gvLegalRegister.DataBind();

        for (int i = 0; i < gvLegalRegister.Rows.Count; i++)
        {
            GridViewRow row = gvLegalRegister.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteLegalRegister(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindLegalRegister();
    }

    protected void btnSaveE3_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName3.Attributes.Add("class", null);

        if (fldFileName3.FileName == "")
        {
            chckErr = false;
            dvFileName3.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Legal Register', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Legal Register
            uploadLegalRegister();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadLegalRegister()
    {
        if (fldFileName3.FileName != "")
        {
            //Update Legal Register
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Legal Register' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/LegalRegister/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName3.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName3.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName3.PostedFiles)
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

    protected void btnCloseE3_Click(object sender, EventArgs e)
    {
    }

    private void bindHIRARC()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'HIRARC' "
            + "ORDER BY       Id DESC ";

        gvHIRARC.DataSource = GetData(str);
        gvHIRARC.DataBind();

        for (int i = 0; i < gvHIRARC.Rows.Count; i++)
        {
            GridViewRow row = gvHIRARC.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteHIRARC(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindHIRARC();
    }

    protected void btnSaveE4_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName4.Attributes.Add("class", null);

        if (fldFileName4.FileName == "")
        {
            chckErr = false;
            dvFileName4.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('HIRARC', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //HIRARC
            uploadHIRARC();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadHIRARC()
    {
        if (fldFileName4.FileName != "")
        {
            //Update HIRARC
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'HIRARC' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/HIRARC/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName4.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName4.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName4.PostedFiles)
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

    protected void btnCloseE4_Click(object sender, EventArgs e)
    {
    }

    private void bindEAI()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'EAI' "
            + "ORDER BY       Id DESC ";

        gvEAI.DataSource = GetData(str);
        gvEAI.DataBind();

        for (int i = 0; i < gvEAI.Rows.Count; i++)
        {
            GridViewRow row = gvEAI.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteEAI(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindEAI();
    }

    protected void btnSaveE5_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName5.Attributes.Add("class", null);

        if (fldFileName5.FileName == "")
        {
            chckErr = false;
            dvFileName5.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('EAI', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //EAI
            uploadEAI();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadEAI()
    {
        if (fldFileName5.FileName != "")
        {
            //Update EAI
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'EAI' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/EAI/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName5.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName5.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName5.PostedFiles)
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

    protected void btnCloseE5_Click(object sender, EventArgs e)
    {
    }

    private void bindHSEPlan()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'HSE Plan' "
            + "ORDER BY       Id DESC ";

        gvHSEPlan.DataSource = GetData(str);
        gvHSEPlan.DataBind();

        for (int i = 0; i < gvHSEPlan.Rows.Count; i++)
        {
            GridViewRow row = gvHSEPlan.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteHSEPlan(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindHSEPlan();
    }

    protected void btnSaveE6_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName6.Attributes.Add("class", null);

        if (fldFileName6.FileName == "")
        {
            chckErr = false;
            dvFileName6.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('HSE Plan', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //HSE Plan
            uploadHSEPlan();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadHSEPlan()
    {
        if (fldFileName6.FileName != "")
        {
            //Update HSE Plan
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'HSE Plan' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/HSEPlan/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName6.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName6.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName6.PostedFiles)
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

    protected void btnCloseE6_Click(object sender, EventArgs e)
    {
    }

    private void bindOrgChart()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Organization Chart' "
            + "ORDER BY       Id DESC ";

        gvOrgChart.DataSource = GetData(str);
        gvOrgChart.DataBind();

        for (int i = 0; i < gvOrgChart.Rows.Count; i++)
        {
            GridViewRow row = gvOrgChart.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteOrgChart(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindOrgChart();
    }

    protected void btnSaveE7_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName7.Attributes.Add("class", null);

        if (fldFileName7.FileName == "")
        {
            chckErr = false;
            dvFileName7.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Organization Chart', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Organization Chart
            uploadOrgChart();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadOrgChart()
    {
        if (fldFileName7.FileName != "")
        {
            //Update Organization Chart
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Organization Chart' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/OrgChart/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName7.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName7.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName7.PostedFiles)
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

    protected void btnCloseE7_Click(object sender, EventArgs e)
    {
    }

    private void bindManningSchedule()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Manning Schedule' "
            + "ORDER BY       Id DESC ";

        gvManningSchedule.DataSource = GetData(str);
        gvManningSchedule.DataBind();

        for (int i = 0; i < gvManningSchedule.Rows.Count; i++)
        {
            GridViewRow row = gvManningSchedule.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteManningSchedule(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindManningSchedule();
    }

    protected void btnSaveE8_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName8.Attributes.Add("class", null);

        if (fldFileName8.FileName == "")
        {
            chckErr = false;
            dvFileName8.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Manning Schedule', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Manning Schedule
            uploadManningSchedule();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadManningSchedule()
    {
        if (fldFileName8.FileName != "")
        {
            //Update Manning Schedule
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Manning Schedule' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/ManningSchedule/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName8.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName8.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName8.PostedFiles)
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

    protected void btnCloseE8_Click(object sender, EventArgs e)
    {
    }

    private void bindPSP()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'PSP' "
            + "ORDER BY       Id DESC ";

        gvPSP.DataSource = GetData(str);
        gvPSP.DataBind();

        for (int i = 0; i < gvPSP.Rows.Count; i++)
        {
            GridViewRow row = gvPSP.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeletePSP(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindPSP();
    }

    protected void btnSaveE9_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName9.Attributes.Add("class", null);

        if (fldFileName9.FileName == "")
        {
            chckErr = false;
            dvFileName9.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('PSP', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //PSP
            uploadPSP();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadPSP()
    {
        if (fldFileName9.FileName != "")
        {
            //Update PSP
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'PSP' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/PSP/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName9.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileName9.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileName9.PostedFiles)
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

    protected void btnCloseE9_Click(object sender, EventArgs e)
    {
    }

    private void bindProjectDoc()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Project Document' "
            + "ORDER BY       Id DESC ";

        gvProjectDoc.DataSource = GetData(str);
        gvProjectDoc.DataBind();

        for (int i = 0; i < gvProjectDoc.Rows.Count; i++)
        {
            GridViewRow row = gvProjectDoc.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }
    
    protected void DeleteProjectDoc(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindProjectDoc();
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
            queryString = queryString + " VALUES        ('Project Document', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Project Document
            uploadProjectDoc();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadProjectDoc()
    {
        if (fldFileName.FileName != "")
        {
            //Update Project Document
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Project Document' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/ProjectDocument/";

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

    private void bindAgreement()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblSupplementAgreement "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvAgreement.DataSource = GetData(str);
        gvAgreement.DataBind();

        for (int i = 0; i < gvAgreement.Rows.Count; i++)
        {
            GridViewRow row = gvAgreement.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void DeleteAgreement(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblSupplementAgreement WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindAgreement();
    }

    protected void btnSaveF_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileNameA.Attributes.Add("class", null);

        if (fldFileNameA.FileName == "")
        {
            chckErr = false;
            dvFileNameA.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblSupplementAgreement 
            queryString = "";
            queryString = queryString + " INSERT INTO   tblSupplementAgreement ";
            queryString = queryString + "               (DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            //cmd.Parameters.AddWithValue("@pFileName", fldFileName.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //Supplement Agreement
            uploadAgreement();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadAgreement()
    {
        if (fldFileNameA.FileName != "")
        {
            //Update Supplement Agreement
            SqlCommand cmdFile = new SqlCommand("UPDATE tblSupplementAgreement SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/Agreement/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileNameA.PostedFile.FileName) == ".exe")
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
                        if (System.IO.Path.GetExtension(fldFileNameA.PostedFile.FileName) == ".exe")
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
            foreach (HttpPostedFile postedFile in fldFileNameA.PostedFiles)
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

    protected void btnCloseF_Click(object sender, EventArgs e)
    {
    }

    private void bindRisk()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblRiskAssessment "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvRiskAssessment.DataSource = GetData(str);
        gvRiskAssessment.DataBind();

        for (int i = 0; i < gvRiskAssessment.Rows.Count; i++)
        {
            GridViewRow row = gvRiskAssessment.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                row.Cells[6].Style.Add("background-color", "#FFECEC");
                row.Cells[7].Style.Add("background-color", "#FFECEC");
                row.Cells[8].Style.Add("background-color", "#FFECEC");
                row.Cells[9].Style.Add("background-color", "#FFECEC");
                row.Cells[10].Style.Add("background-color", "#FFECEC");
                row.Cells[11].Style.Add("background-color", "#FFECEC");
                row.Cells[12].Style.Add("background-color", "#FFECEC");
                row.Cells[13].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void gvRiskAssessment_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvRiskAssessment.PageIndex = e.NewPageIndex;
        this.bindRisk();

    }

    protected void gvRiskAssessment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "#";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Date";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Category";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Title";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Description <br>(Include Cost & Impact of Risk)";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Gross Rating";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Existing Control";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Net Risk Rating";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            
            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Mitigation";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Status";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderGridRow.Cells.Add(HeaderCell);

            gvRiskAssessment.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }


    protected void gvRiskAssessment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Bind data to the dropdownlist control.
            DropDownList GrossRating = (e.Row.FindControl("txtGrossRating") as DropDownList);
            GrossRating.DataSource = GetData("SELECT Id, GrossRating FROM tblGrossRating ORDER BY Id");
            GrossRating.DataTextField = "GrossRating";
            GrossRating.DataValueField = "GrossRating";
            GrossRating.DataBind();

            string GrossRatingId = (e.Row.FindControl("txtGrossRatingId") as TextBox).Text;
            GrossRating.Items.FindByValue(GrossRatingId).Selected = true;
        }
    }


    protected void EditRisk(object sender, GridViewEditEventArgs e)
    {
        gvRiskAssessment.EditIndex = e.NewEditIndex;
        bindRisk();
    }

    protected void CancelRiskEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRiskAssessment.EditIndex = -1;
        bindRisk();
    }
       
    protected void UpdateRisk(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvRiskAssessment.Rows[e.RowIndex].FindControl("lblID")).Text;        
        string GrossRating = ((DropDownList)gvRiskAssessment.Rows[e.RowIndex].FindControl("txtGrossRating")).Text;
        string ExistingControl = ((TextBox)gvRiskAssessment.Rows[e.RowIndex].FindControl("txtExistingControl")).Text;        
        string Likelihood = ((DropDownList)gvRiskAssessment.Rows[e.RowIndex].FindControl("txtLikelihood")).Text;
        string Impact = ((DropDownList)gvRiskAssessment.Rows[e.RowIndex].FindControl("txtImpact")).Text;
        string Mitigation = ((TextBox)gvRiskAssessment.Rows[e.RowIndex].FindControl("txtMitigation")).Text;
        string Status = ((DropDownList)gvRiskAssessment.Rows[e.RowIndex].FindControl("txtStatus")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblRiskAssessment SET " +
            "GrossRating = @pGrossRating, " +
            "ExistingControl = @pExistingControl, " +
            "Likelihood = @pLikelihood, " +
            "Impact = @pImpact, " +
            "Mitigation = @pMitigation, " +
            "Status = @pStatus, " +
            "ModifyBy = '" + Session["UserID"].ToString() + "', " +
            "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' " +
            "WHERE ID = @ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;        
        cmd.Parameters.Add("@pGrossRating", SqlDbType.VarChar).Value = GrossRating;
        cmd.Parameters.Add("@pExistingControl", SqlDbType.VarChar).Value = ExistingControl;
        cmd.Parameters.Add("@pLikelihood", SqlDbType.VarChar).Value = Likelihood;
        cmd.Parameters.Add("@pImpact", SqlDbType.VarChar).Value = Impact;
        cmd.Parameters.Add("@pMitigation", SqlDbType.VarChar).Value = Mitigation;
        cmd.Parameters.Add("@pStatus", SqlDbType.VarChar).Value = Status;

        cmd.ExecuteNonQuery();

        gvRiskAssessment.EditIndex = -1;

        //Update Risk Rating in table tblRiskAssessment
        SqlCommand cmdRating = new SqlCommand("UPDATE tblRiskAssessment SET tblRiskAssessment.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblRiskAssessment WHERE tblRiskImpact.Likelihood = tblRiskAssessment.Likelihood AND tblRiskImpact.Impact = tblRiskAssessment.Impact", con);

        cmdRating.ExecuteNonQuery();

        bindRisk();
    }

    protected void DeleteRisk(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblRiskAssessment WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindRisk();
    }


    protected void btnSaveC_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvRiskTitle.Attributes.Add("class", null);
        dvGrossRating.Attributes.Add("class", null);
        dvExistingControl.Attributes.Add("class", null);
        dvLikelihood.Attributes.Add("class", null);
        dvImpact.Attributes.Add("class", null);

        if (fldRiskTitle.Text.Trim() == "")
        {
            chckErr = false;
            dvRiskTitle.Attributes.Add("class", "has-error");
        }

        if (fldGrossRating.SelectedIndex == 0)
        {
            chckErr = false;
            dvGrossRating.Attributes.Add("class", "has-error");
        }

        if (fldExistingControl.Text.Trim() == "")
        {
            chckErr = false;
            dvExistingControl.Attributes.Add("class", "has-error");
        }

        if (fldLikelihood.SelectedIndex == 0)
        {
            chckErr = false;
            dvLikelihood.Attributes.Add("class", "has-error");
        }

        if (fldImpact.SelectedIndex == 0)
        {
            chckErr = false;
            dvImpact.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblRiskAssessment
            queryString = "";
            queryString = queryString + " INSERT INTO   tblRiskAssessment ";
            queryString = queryString + "               (DescriptionId, AssessDate, RiskCategory, RiskTitle, RiskDescription, GrossRating, ExistingControl, Likelihood, Impact, Status, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pAssessDate, @pRiskCategory, @pRiskTitle, @pRiskDescription, @pGrossRating, @pExistingControl, @pLikelihood, @pImpact, 'Open', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pAssessDate", fldAssessDate.Text);
            cmd.Parameters.AddWithValue("@pRiskCategory", fldRiskCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@pRiskTitle", fldRiskTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@pRiskDescription", fldRiskDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@pGrossRating", fldGrossRating.SelectedValue);
            cmd.Parameters.AddWithValue("@pExistingControl", fldExistingControl.Text.Trim());
            cmd.Parameters.AddWithValue("@pLikelihood", fldLikelihood.SelectedValue);
            cmd.Parameters.AddWithValue("@pImpact", fldImpact.SelectedValue);

            cmd.ExecuteNonQuery();

            //Update Risk Rating in table tblRiskAssessment
            SqlCommand cmdRating = new SqlCommand("UPDATE tblRiskAssessment SET tblRiskAssessment.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblRiskAssessment WHERE tblRiskImpact.Likelihood = tblRiskAssessment.Likelihood AND tblRiskImpact.Impact = tblRiskAssessment.Impact", con);

            cmdRating.ExecuteNonQuery();

            con.Close();

            bindRisk();

            Response.Redirect("ProjectInitiationDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void btnCloseC_Click(object sender, EventArgs e)
    {
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
        //Service Agreement
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ServiceAgreement";

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
                qs = qs + "UPDATE  tblProjectInitiation SET ServiceAgreement = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
        //Service Agreement
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectInitiation SET ServiceAgreement = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/ServiceAgreement/" + lblURLA1.Text + "";

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
        //Service Agreement
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }
          
    protected void btnUpA11_Click(object sender, EventArgs e)
    {
        //Board / Management Paper 
        String pathfolder = "Upload/";
        String filenameStr = fldA11Upload.FileName;

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
            fldA11Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProjectInitiation SET BoardPaper = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA11Sec.Visible = false;
                dvVwA11Sec.Visible = true;
                UpA11.Update();
                hidURLA11.Value = pathfolder + filenameStr;
                lblURLA11.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA11_Click(object sender, EventArgs e)
    {
        //Board / Management Paper 
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectInitiation SET BoardPaper = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/BoardPaper/" + lblURLA11.Text + "";

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

        hidURLA11.Value = "";
        dvUpA11Sec.Visible = true;
        dvVwA11Sec.Visible = false;
        UpA11.Update();
    }

    protected void btnViewA11_Click(object sender, EventArgs e)
    {
        //Board / Management Paper 
        Response.Write("<script> window.open( '" + hidURLA11.Value.ToString() + "','_blank' ); </script>");
    }

}