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


public partial class ApprovalChangeRequestClient_DALEOT : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {        
        
        if (!Page.IsPostBack)
        {
            bindCRToFrom();
            bindVariationType();
            bindClientApproval();
            bindGrantingVO();
            bindGrantingEOT();
            bindEOTFromClient();

            bindIncreaseFee();
            bindContractAddendum();

            bindVOLetter();
            bindDetails();

            //Check approval details 
            qs = "";
            qs = qs + " SELECT        DALAppDate, DALNotAppDate, DALAppStatus, DALAppComment ";
            qs = qs + " FROM          tblChangeRequestVO ";
            qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";
            qs = qs + " AND         Id = '" + Request.QueryString["Id1"] + "' ";

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

    protected void bindCRToFrom()
    {
        fldChangeRequestToFrom.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldChangeRequestToFrom.Items.Insert(1, new ListItem("Client", "Client"));
        fldChangeRequestToFrom.Items.Insert(2, new ListItem("Internal", "Internal"));
        fldChangeRequestToFrom.Items.Insert(2, new ListItem("Sub-Contractor", "Sub-Contractor"));
    }

    protected void bindVariationType()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        ChangeRequestVOType ";
        qs = qs + " FROM          tblChangeRequestVOType ";
        qs = qs + " ORDER BY      ChangeRequestVOType ";

        fldVariationType.DataSource = GetData(qs);
        fldVariationType.DataTextField = "ChangeRequestVOType";
        fldVariationType.DataValueField = "ChangeRequestVOType";
        fldVariationType.DataBind();
        fldVariationType.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindClientApproval()
    {
        fldClientApproval.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldClientApproval.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldClientApproval.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindGrantingVO()
    {
        fldGrantingVO.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldGrantingVO.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldGrantingVO.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindGrantingEOT()
    {
        fldGrantingEOT.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldGrantingEOT.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldGrantingEOT.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindEOTFromClient()
    {
        fldEOTFromClient.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldEOTFromClient.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldEOTFromClient.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindIncreaseFee()
    {
        fldIncreaseFee.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldIncreaseFee.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldIncreaseFee.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindContractAddendum()
    {
        fldContractAddendum.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldContractAddendum.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldContractAddendum.Items.Insert(2, new ListItem("No", "No"));
    }


    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        ProjectCode ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " WHERE         Id = '" + Request.QueryString["Id"] + "' ";

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

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();
        }

        qs = "";
        qs = qs + " SELECT        tblChangeRequestVO.*, vwChangeRequestVOApproval.AppBy,  ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName,  ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName ";
        qs = qs + " FROM          tblChangeRequestVO ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblChangeRequestVO.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblChangeRequestVO.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN          vwChangeRequestVOApproval ON tblChangeRequestVO.Id = vwChangeRequestVOApproval.Id ";
        qs = qs + " INNER JOIN          StaffLogin AS StaffLogin_1 ON  vwChangeRequestVOApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

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

            //Change Request To / From
            fldChangeRequestToFrom.Text = row["ChangeRequestToFrom"].ToString();
            if (fldChangeRequestToFrom.Text == "Client")
            {
                dvContractNo.Visible = false;
                dvEOTFromClient.Visible = false;
                dvLADImpact.Visible = false;
                lblfldCostImpact.InnerText = "Cost Impact Due To Changes To Client";
            }
            else if (fldChangeRequestToFrom.Text == "Sub-Contractor")
            {
                lblfldCostImpact.InnerText = "Cost Impact Due To Changes ";
            }
            else if (fldChangeRequestToFrom.Text == "Internal")
            {
                dvContractNo.Visible = false;
                dvEOTFromClient.Visible = false;
                dvGrantingVO.Visible = false;
                dvGrantingEOT.Visible = false;

                lblfldCostImpact.Visible = false;
                lblRM.Visible = false;
                fldCostImpact.Visible = false;

                dvLADImpact.Visible = false;
            }

            //Title
            fldTitle.Text = row["Title"].ToString();

            //Contract No.
            fldContractNo.Text = row["ContractNo"].ToString();

            //Type Of Changes 
            fldVariationType.Text = row["VariationType"].ToString();

            //Has Client Approved The Changes?
            fldClientApproval.Text = row["ClientApproval"].ToString();

            //Reason For Changes 
            fldReason.Text = row["Reason"].ToString();

            //Cost Impact Due To Changes 
            object dta = row["CostImpact"];
            if (dta == DBNull.Value)
            { }
            else
            { fldCostImpact.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())); }

            //Schedule Impact Due To Changes 
            fldScheduleImpact.Text = row["ScheduleImpact"].ToString();

            //Cumulative LAD Impact
            object dta1 = row["LADImpact"];
            if (dta1 == DBNull.Value)
            { }
            else
            { fldLADImpact.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["LADImpact"].ToString())); }

            //Granting VO?
            fldGrantingVO.Text = row["GrantingVO"].ToString();
            if (fldGrantingVO.Text == "Yes")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Client")
                {
                    dvIncreaseFee.Visible = true;
                    dvContractAddendum.Visible = true;
                    dvVOLetter.Visible = true;
                    dvVOFee.Visible = true;

                }
            }

            fldIncreaseFee.Text = row["IncreaseFee"].ToString();
            fldContractAddendum.Text = row["ContractAddendum"].ToString();
            fldVOFee.Text = row["VOFee"].ToString();

            //Granting EOT?
            fldGrantingEOT.Text = row["GrantingEOT"].ToString();

            //Is This A Back-To-Back Changes From Client?
            fldEOTFromClient.Text = row["EOTFromClient"].ToString();

            if (row["VariationType"].ToString() == "Variation Order (VO)")
            {
                fldGrantingVO.Visible = true;
                lblNA.Visible = false;

                fldGrantingEOT.Visible = false;
                lblNA1.Visible = true;

                fldEOTFromClient.Visible = true;
                lblNA2.Visible = false;
            }
            else if (row["VariationType"].ToString() == "Extension of Time (EOT)")
            {
                fldGrantingVO.Visible = false;
                lblNA.Visible = true;

                fldGrantingEOT.Visible = true;
                lblNA1.Visible = false;

                fldEOTFromClient.Visible = true;
                lblNA2.Visible = false;
            }
            else if (row["VariationType"].ToString() == "Others")
            {
                fldGrantingVO.Visible = false;
                lblNA.Visible = true;

                fldGrantingEOT.Visible = false;
                lblNA1.Visible = true;

                fldEOTFromClient.Visible = false;
                lblNA2.Visible = true;
            }

            if (fldVariationType.SelectedValue == "Extension of Time (EOT)")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
                {
                    dvGrantingEOT.Visible = true;
                    dvEOTFromClient.Visible = true;
                }
            }
            else if (fldVariationType.SelectedValue == "Variation Order (VO)")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
                {
                    dvGrantingEOT.Visible = false;
                    dvEOTFromClient.Visible = true;
                }
            }
            else if (fldVariationType.SelectedValue == "Others")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
                {
                    dvGrantingEOT.Visible = false;
                    dvEOTFromClient.Visible = false;
                }
            }

            lblDALApprover.Text = row["DALName"].ToString();

            //Date Approved
            object dt8 = row["DALAppDate"];
            if (dt8 == DBNull.Value)
            {
                lblDtApproved.Text = "Pending";
                lblDtApproved.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtApproved.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            
            //Date Rejected
            object dt9 = row["DALNotAppDate"];
            if (dt9 == DBNull.Value)
            {
                lblDtReject.Text = "Pending";
                lblDtReject.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else if (dt9 != DBNull.Value)
            {
                lblDtReject.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");

                //Justification
                fldJustification.Text = row["DALAppComment"].ToString();
            }
            ////...................................end of DAL Approval...................................

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

    private void bindVOLetter()
    {
        string constr = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string str;

                str = "SELECT         FileName "
                    + "FROM           tblChangeRequestDocument "
                    + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
                    + "AND            ChangeRequestId = '" + Request.QueryString["ID1"] + "' "
                    + "AND            Category = 'VO Letter' ";

                cmd.CommandText = str;
                cmd.Connection = con;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (!dr.HasRows)
                    {
                        lblVOLetter.Visible = false;
                        btnSaveVOLetter.Text = "Save";
                    }
                    else
                    {
                        lblVOLetter.Visible = true;
                        btnSaveVOLetter.Text = "View";
                        fldVOLetter.Enabled = false;
                        lblVOLetter.Text = dr[0].ToString();
                    }
                }

                con.Close();
            }
        }
    }

    protected void btnSaveVOLetter_Click(object sender, EventArgs e)
    {
        if (btnSaveVOLetter.Text == "Save")
        {
            if (fldVOLetter.HasFile)
            {
                DateTime now = DateTime.Now;

                Boolean chckErr = true;

                //Reset error
                dvVOLetter.Attributes.Add("class", null);

                if (fldVOLetter.FileName == "")
                {
                    chckErr = false;
                    dvVOLetter.Attributes.Add("class", "has-error");
                }

                if (chckErr == true)
                {
                    //Upload file to folder
                    HttpFileCollection hfc = Request.Files;
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/";
                            //string pathString = @"C:/Users/azhar.yusof/Documents/Visual Studio 2019/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/";

                            if (!System.IO.File.Exists(pathString))
                            {
                                System.IO.Directory.CreateDirectory(pathString);
                                if (System.IO.Path.GetExtension(fldVOLetter.PostedFile.FileName) == ".exe")
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
                                if (System.IO.Path.GetExtension(fldVOLetter.PostedFile.FileName) == ".exe")
                                {
                                    //lblError.Text = "No .exe files are allowed.";
                                }
                                else
                                {
                                    hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                                }
                            }
                        }

                        foreach (HttpPostedFile postedFile in fldVOLetter.PostedFiles)
                        {
                            string filename = Path.GetFileName(postedFile.FileName);

                            using (Stream fs = postedFile.InputStream)
                            {
                                using (BinaryReader br = new BinaryReader(fs))
                                {
                                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                    //Insert into table tblProjectDocument
                                    queryString = "";
                                    queryString = queryString + " INSERT INTO   tblChangeRequestDocument ";
                                    queryString = queryString + "               (Category, DescriptionId, ChangeRequestId, FileName, CreatedBy, DateCreated) ";
                                    queryString = queryString + " VALUES        ('VO Letter', @pDescriptionId, @pChangeRequestId, @pFileName, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

                                    if (con.State == System.Data.ConnectionState.Closed)
                                    {
                                        con.Open();
                                    }

                                    cmd = new SqlCommand(queryString, con);
                                    cmd.CommandTimeout = 0;

                                    cmd.Parameters.AddWithValue("@pFileName", filename);
                                    cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
                                    cmd.Parameters.AddWithValue("@pChangeRequestId", Request.QueryString["ID1"]);

                                    cmd.ExecuteNonQuery();

                                    con.Close();
                                }
                            }
                        }
                    }

                    Response.Redirect("UpdateChangeRequestVO.aspx?ID=" + Request.QueryString["ID"] + "&Id1=" + Request.QueryString["ID1"]);
                }
            }
        }
        else if (btnSaveVOLetter.Text == "View")
        {
            string filePath = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/" + lblVOLetter.Text;
            //string filePath = @"C:/Users/azhar.yusof/Documents/Visual Studio 2019/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/" + lblVOLetter.Text;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string approval_type = "";
        
        //Update in table tblChangeRequestVO
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        DateTime now = DateTime.Now;

        if (lblDALApprover.Text != "")
        {
            SqlCommand cmdR = new SqlCommand("UPDATE tblChangeRequestVO SET "
                    + "DALAppStatus = 'Approved', "
                    + "DALAppDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' AND Id = '" + Request.QueryString["Id1"] + "'", con);

            cmdR.ExecuteNonQuery();
        }

        con.Close();

        //Email notification to PM
        //---------------------------------------- send email -----------------------------------------                
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblChangeRequestVO.Id, tblChangeRequestVO.VariationType, tblChangeRequestVO.Reason, tblChangeRequestVO.CostImpact, tblChangeRequestVO.DALApproverLevel, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblChangeRequestVO ON tblMain.Id = tblChangeRequestVO.DescriptionId ";
        qs = qs + "               LEFT OUTER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               LEFT OUTER JOIN StaffLogin AS StaffLogin_1 ON tblChangeRequestVO.DALApprovedBy_COO = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' AND tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "'";

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

        if (row["DALApproverLevel"].ToString() == "MD/CEO")
        {
            approval_type = "CONDITIONALLY APPROVED";
        }
        else
        {
            approval_type = "APPROVED";
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");
        
        //objeto_mail.CC.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Approved : Request for Approval on Granting of Extension of Time (“EOT”) to Contractors / Sub-contractors for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "FYI, request for the following EOT has been <B>" + approval_type + "</B> by DAL person.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Type Of Changes : </B>" + row["VariationType"].ToString() + "<BR><BR>"
                            + "<B>Reason For Changes : </B>" + row["Reason"].ToString() + "<BR><BR>"
                            + "<B>Cost Impact Due To Changes : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())) + "<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------

        ////Insert data into Project Initiation phase if request is approved
        //if (con.State == System.Data.ConnectionState.Closed)
        //{ con.Open(); }

        //SqlCommand cmdInsertProject = new SqlCommand("INSERT INTO tblProjectInitiation (DescriptionId) "
        //        + "VALUES ('" + Request.QueryString["Id"] + "')", con);

        //cmdInsertProject.ExecuteNonQuery();

        //con.Close();

        //Redirect to update page
        Response.Redirect("ApprovalChangeRequestClient_DALEOT.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
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
            //Update in table tblChangeRequestVO
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            DateTime now = DateTime.Now;

            if (lblDALApprover.Text != "")
            {
                SqlCommand cmdNR = new SqlCommand("UPDATE tblChangeRequestVO SET "
                    + "DALAppStatus = 'Rejected', "
                    + "DALNotAppDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "DALAppComment = @pJustification "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' AND Id = '" + Request.QueryString["Id1"] + "'", con);

                //Justification
                cmdNR.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

                cmdNR.ExecuteNonQuery();
            }

            con.Close();

            //Email notification to Project Manager
            //---------------------------------------- send email -----------------------------------------  
            //qs = "";
            //qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, ";
            //qs = qs + "               vwProjectRecordApproval.AppBy, tblProjectRecord.DALAppComment, ";
            //qs = qs + "               tblClient.ClientName AS ClientName, ";
            //qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
            //qs = qs + "               StaffLogin_1.StaffName AS PDName, ";
            //qs = qs + "               StaffLogin_2.StaffName AS DALName ";
            //qs = qs + " FROM          tblMain ";
            //qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
            //qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
            //qs = qs + "               INNER JOIN vwProjectRecordApproval ON tblProjectRecord.DescriptionId = vwProjectRecordApproval.DescriptionId ";
            //qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
            //qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.ProjectDirector = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
            //qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_2 ON  vwProjectRecordApproval.AppBy = StaffLogin_2.StaffNo COLLATE Latin1_General_CI_AI ";
            //qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

            qs = "";
            qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
            qs = qs + "               tblChangeRequestVO.Id, tblChangeRequestVO.VariationType, tblChangeRequestVO.Reason, tblChangeRequestVO.CostImpact, vwChangeRequestVOApproval.AppBy, tblChangeRequestVO.DALAppComment, ";
            qs = qs + "               tblClient.ClientName AS ClientName, ";
            qs = qs + "               StaffLogin.StaffName AS PMName, ";
            qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
            qs = qs + " FROM          tblMain ";
            qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + "               INNER JOIN tblChangeRequestVO ON tblMain.Id = tblChangeRequestVO.DescriptionId ";
            qs = qs + "               INNER JOIN vwChangeRequestVOApproval ON tblChangeRequestVO.Id = vwChangeRequestVOApproval.Id ";
            qs = qs + "               LEFT OUTER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + "               LEFT OUTER JOIN StaffLogin AS StaffLogin_1 ON vwChangeRequestVOApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' AND tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "'";



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

            //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

            objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

            objeto_mail.Subject = "Rejected : Request for Approval on Granting of Extension of Time (“EOT”) to Contractors / Sub-contractors for '" + row["Description"].ToString() + "'";

            string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:TAHOMA,8PT;>"
                                + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                                + "Your request for the following EOT is rejected. Please read the justification by DAL Approver below.<BR><BR><BR>"

                                + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                                + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                                + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                                + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                                + "<B>Type Of Changes : </B>" + row["VariationType"].ToString() + "<BR><BR>"
                                + "<B>Reason For Changes : </B>" + row["Reason"].ToString() + "<BR><BR>"
                                + "<B>Cost Impact Due To Changes : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())) + "<BR><BR>"
                                + "<B>DAL Approver : </B>" + row["DALName"].ToString() + "<BR><BR>"
                                + "<B>Justification : </B>" + row["DALAppComment"].ToString() + "<BR><BR><BR>"

                                + "<BR><BR><BR>Thank you.<BR><BR>"
                                + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

            objeto_mail.Body = htmlText;
            objeto_mail.IsBodyHtml = true;

            client.Send(objeto_mail);
            //---------------------------------- end of send email ----------------------------------------

            //Redirect to update page
            Response.Redirect("ApprovalChangeRequestClient_DALEOT.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
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