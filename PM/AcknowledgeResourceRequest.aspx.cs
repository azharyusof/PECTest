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

public partial class AcknowledgeResourceRequest : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            //Hide all upload
            dvUpA1Sec.Visible = true;
            dvVwA1Sec.Visible = false;

            dvUpA2Sec.Visible = true;
            dvVwA2Sec.Visible = false;

            dvUpA3Sec.Visible = true;
            dvVwA3Sec.Visible = false;

            dvUpA4Sec.Visible = true;
            dvVwA4Sec.Visible = false;

            dvUpA5Sec.Visible = true;
            dvVwA5Sec.Visible = false;

            dvUpA6Sec.Visible = true;
            dvVwA6Sec.Visible = false;

            dvUpA7Sec.Visible = true;
            dvVwA7Sec.Visible = false;

            bindDetails();
            bindRisk();

            bindProjectDoc();

            //Check acknowlegdement details 
            qs = "";
            qs = qs + " SELECT        HRAcknowledgeDate ";
            qs = qs + " FROM          tblProjectInitiation ";
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

                object dtA = row["HRAcknowledgeDate"];

                if (dtA == DBNull.Value)
                {                    
                }
                else if (dtA != DBNull.Value)
                {
                    btnAcknowledge.Enabled = false;
                }
            }
        }

    }


    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProjectInitiation.*, tblMain.Code, tblMain.Description, ";
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
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Project Name
            lblDescription.Text = row["Description"].ToString();

            //Project Code
            lblCode.Text = row["Code"].ToString();

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
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ServiceAgreement/" + row["ServiceAgreement"].ToString() + "";
            }

            //--------------------------------------- Project Execution Plan (PEP) ---------------------------------------
            object fn1 = row["ExecutionPlan"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["ExecutionPlan"].ToString();
                hidURLA2.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ExecutionPlan/" + row["ExecutionPlan"].ToString() + "";
            }

            //--------------------------------------- HSE Plan ---------------------------------------
            //HSE Plan
            object fn2 = row["HSEPlan"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                dvUpA3Sec.Visible = true;
                dvVwA3Sec.Visible = false;
            }
            else
            {
                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;

                lblURLA3.Text = row["HSEPlan"].ToString();
                hidURLA3.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/HSEPlan/" + row["HSEPlan"].ToString() + "";
            }

            //If None, Justification
            fldHSEPlanComment.Text = row["HSEPlanComment"].ToString();

            //--------------------------------------- Legal Register ---------------------------------------
            //Legal Register
            object fn3 = row["LegalRegister"];
            if (fn3 == DBNull.Value || fn3 == "")
            {
                dvUpA4Sec.Visible = true;
                dvVwA4Sec.Visible = false;
            }
            else
            {
                dvUpA4Sec.Visible = false;
                dvVwA4Sec.Visible = true;

                lblURLA4.Text = row["LegalRegister"].ToString();
                hidURLA4.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/LegalRegister/" + row["LegalRegister"].ToString() + "";
            }

            //If None, Justification
            fldLegalRegisterComment.Text = row["LegalRegisterComment"].ToString();

            //--------------------------------------- HIRARC ---------------------------------------
            //HIRARC
            object fn4 = row["HIRARC"];
            if (fn4 == DBNull.Value || fn4 == "")
            {
                dvUpA5Sec.Visible = true;
                dvVwA5Sec.Visible = false;
            }
            else
            {
                dvUpA5Sec.Visible = false;
                dvVwA5Sec.Visible = true;

                lblURLA5.Text = row["HIRARC"].ToString();
                hidURLA5.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/HIRARC/" + row["HIRARC"].ToString() + "";
            }

            //If None, Justification
            fldHIRARCComment.Text = row["HIRARCComment"].ToString();

            //--------------------------------------- Environmental Aspect & Impact ---------------------------------------
            //Environmental Aspect & Impact
            object fn5 = row["EnvAspectImpact"];
            if (fn5 == DBNull.Value || fn5 == "")
            {
                dvUpA6Sec.Visible = true;
                dvVwA6Sec.Visible = false;
            }
            else
            {
                dvUpA6Sec.Visible = false;
                dvVwA6Sec.Visible = true;

                lblURLA6.Text = row["EnvAspectImpact"].ToString();
                hidURLA6.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/OPUSEAI/" + row["EnvAspectImpact"].ToString() + "";
            }

            //If None, Justification
            fldHIRARCComment.Text = row["EnvAspectImpactComment"].ToString();

            //Request Finance to Approve Financial Planning 
            if (row["FinancialPlanning"].ToString() == "Yes")
            {
                cbFinancialPlanning.Checked = true;
            }

            //Resource Request 
            if (row["ResourceRequest"].ToString() == "Yes")
            {
                cbResourceRequest.Checked = true;
            }

            //--------------------------------------- Organization Chart ---------------------------------------
            //Organization Chart
            object fn6 = row["OrgChart"];
            if (fn6 == DBNull.Value || fn6 == "")
            {
                dvUpA7Sec.Visible = true;
                dvVwA7Sec.Visible = false;
            }
            else
            {
                dvUpA7Sec.Visible = false;
                dvVwA7Sec.Visible = true;

                lblURLA7.Text = row["OrgChart"].ToString();
                hidURLA7.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/OrgChart/" + row["OrgChart"].ToString() + "";
            }

            //HR Acknowledgement
            //...................................HR Acknowledgement ...................................
            //Approver 
            dvApprover.Visible = true;
            dvApprove.Visible = true;

            //Date Acknowledged
            object dt8 = row["HRAcknowledgeDate"];
            if (dt8 == DBNull.Value)
            {
                lblDtApproved.Text = "Pending";
                lblDtApproved.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtApproved.Text = Convert.ToDateTime(row["HRAcknowledgeDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //...................................end of HR Acknowledgement...................................

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



    private void bindProjectDoc()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
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
                //row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
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
            }
        }
    }

    protected void gvRiskAssessment_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvRiskAssessment.PageIndex = e.NewPageIndex;
        this.bindRisk();

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
        //Service Agreement
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA2_Click(object sender, EventArgs e)
    {
        //Project Execution Plan
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA3_Click(object sender, EventArgs e)
    {
        //HSE Plan
        Response.Write("<script> window.open( '" + hidURLA3.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA4_Click(object sender, EventArgs e)
    {
        //Legal Register
        Response.Write("<script> window.open( '" + hidURLA4.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA5_Click(object sender, EventArgs e)
    {
        //HIRARC
        Response.Write("<script> window.open( '" + hidURLA5.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA6_Click(object sender, EventArgs e)
    {
        //Environmental Aspect & Impact
        Response.Write("<script> window.open( '" + hidURLA6.Value.ToString() + "','_blank' ); </script>");
    }


    protected void btnViewA7_Click(object sender, EventArgs e)
    {
        //Organization Chart
        Response.Write("<script> window.open( '" + hidURLA7.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnAcknowledge_Click(object sender, EventArgs e)
    {
        //Update in table tblProjectInitiation
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        DateTime now = DateTime.Now;

        SqlCommand cmdR = new SqlCommand("UPDATE tblProjectInitiation SET "
                    + "HRAcknowledgeDate = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        cmdR.ExecuteNonQuery();

        con.Close();

        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, ";
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

        //objeto_mail.CC.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Acknowledged  : Request for Resource Request for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Your request for the following project has been <B>ACKNOWLEDGED BY HR</B>. <BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Project Director : </B>" + row["PDName"].ToString() + "<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
        
        //Redirect to update page
        Response.Redirect("AcknowledgeResourceRequest.aspx?Id=" + Request.QueryString["Id"]);
    }

    
    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
    }
}
