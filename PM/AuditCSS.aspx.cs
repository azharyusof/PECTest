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

public partial class AuditCSS : System.Web.UI.Page
{
    DataRow row = null;
    DataRow row1 = null;
    DataRow rowCSS = null;
    String qs = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            bindAuditYear();
            bindAuditCSS();
            bindDetails();
        }
    }

    protected void bindAuditYear()
    {
        // Bind data to the dropdownlist control.
        fldYear.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldYear.Items.Insert(1, new ListItem("2017", "2017"));
        fldYear.Items.Insert(2, new ListItem("2018", "2018"));
        fldYear.Items.Insert(3, new ListItem("2019", "2019"));
        fldYear.Items.Insert(4, new ListItem("2020", "2020"));
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
    }


    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }


    private void bindAuditCSS()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblAuditCSS "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' AND Year IS NOT NULL "
            + "ORDER BY       Id DESC ";

        gvAuditCSS.DataSource = GetData(str);
        gvAuditCSS.DataBind();

        for (int i = 0; i < gvAuditCSS.Rows.Count; i++)
        {
            GridViewRow row = gvAuditCSS.Rows[i];

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
            }
        }
    }

    protected void gvAuditCSS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var hyperlink = e.Row.FindControl("lblLink") as HyperLink;
            var hyperlinkForm = e.Row.FindControl("lblLinkForm") as HyperLink;

            //var buttonReminder = e.Row.FindControl("btnReminder") as Button;
            var lnkReminder = e.Row.FindControl("lnkReminder") as LinkButton;

            Label CSSId = e.Row.FindControl("lblId") as Label;
            Label Status = e.Row.FindControl("lblStatus") as Label;
            Label Category = e.Row.FindControl("lblCategory") as Label;
            Label NAForm = e.Row.FindControl("lblNAForm") as Label;
            var updatelink = e.Row.FindControl("lblManualUpdate") as HyperLink;

            var imgDelete = e.Row.FindControl("imgDelete") as ImageButton;

            //if (hyperlink != null)
            if (Category.Text == "Email")
            {
                NAForm.Visible = true;
                updatelink.Visible = false;

                if (Status.Text == "Submitted")
                {
                    hyperlink.NavigateUrl = "ClientCSS.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + CSSId.Text;

                    lnkReminder.Visible = false;

                    imgDelete.Visible = false;
                }
                else
                {
                    hyperlink.Visible = false;

                    imgDelete.Visible = true;
                }
            }
            else
            {
                lnkReminder.Visible = false;
                hyperlink.Visible = false;
                NAForm.Visible = false;
                updatelink.NavigateUrl = "UpdateCSS.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + CSSId.Text;

                if (Status.Text == "Submitted")
                {
                    imgDelete.Visible = false;
                }
                else
                {
                    imgDelete.Visible = true;
                }
            }
        }
    }

    protected void SendReminder(object sender, EventArgs e)
    {
        LinkButton lnkReminder = (LinkButton)sender;
        
        //Email notification to client
        //---------------------------------------- send reminder -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Description, tblAuditCSS.Id AS CSSId, tblAuditCSS.ClientName, tblAuditCSS.Email, tblAuditCSS.DateRequired ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblAuditCSS ON tblMain.Id = tblAuditCSS.DescriptionId ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";
        qs = qs + " AND           tblAuditCSS.Id = @ID ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand(qs, con);
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = lnkReminder.CommandArgument;
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

        //objeto_mail.To.Add(new MailAddress(row["Email"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Reminder: Client Satisfaction Survey for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["ClientName"].ToString() + ",<BR><BR><BR>"

                            + "Your input to this survey would help us identify what the Company is good at and in which areas we can do better.<BR><BR>"
                            + "This survey will only take approximately 5 - 10 minutes to complete.<BR><BR>"
                            + "To access the survey, click on the link below :<BR><BR><BR>"

                            + "<B>URL : </B><A HREF=http://pectest.uemedgenta.com/PM/ClientCSS.aspx?ID=" + Request.QueryString["Id"] + "&Id1=" + row["CSSId"].ToString() + ">Click here</A><BR><BR>"
                            + "<B>Date Required : </B>" + Convert.ToDateTime(row["DateRequired"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "Please note that the link above is intended for you only. As such, please do not share the URL link with others. We thank you in advance and appreciate your time and kind participation.<BR><BR>"

                            + "Note: <br>Please remember not to delete this email until you have completed and submitted the survey online.<BR><BR>"
                            + "<BR><BR><BR>This is a system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send reminder ----------------------------------------

        //BindData();
        Response.Redirect("AuditCSS.aspx?ID=" + Request.QueryString["ID"]);
    }


    protected void gvAuditCSS_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvAuditCSS.PageIndex = e.NewPageIndex;
        this.bindAuditCSS();

    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        //Boolean chckErr = true;

        //Reset error
        //dvYear.Attributes.Add("class", null);
        //dvClientName.Attributes.Add("class", null);
        //dvEmail.Attributes.Add("class", null);
        //dvDateRequired.Attributes.Add("class", null);

        //if (fldYear.SelectedIndex == 0)
        //{
        //    chckErr = false;
        //    dvYear.Attributes.Add("class", "has-error");
        //}

        //if (fldClientName.Text.Trim() == "")
        //{
        //    chckErr = false;
        //    dvClientName.Attributes.Add("class", "has-error");
        //}

        //if (fldEmail.Text.Trim() == "")
        //{
        //    chckErr = false;
        //    dvEmail.Attributes.Add("class", "has-error");
        //}

        //if (fldDateRequired.Text == "")
        //{
        //    chckErr = false;
        //    dvDateRequired.Attributes.Add("class", "has-error");
        //}

        //if (chckErr == true)
        //{
        //Insert into table tblAuditCSS
        queryString = "";
        queryString = queryString + " INSERT INTO   tblAuditCSS ";
        queryString = queryString + "               (DescriptionId, Year, Category, ClientName, Email, DateRequired, Status, CreatedBy, DateCreated) ";
        queryString = queryString + " VALUES        (@pDescriptionId, @pYear, 'Email', @pClientName, @pEmail, @pDateRequired, 'Pending', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

        cmd.Parameters.AddWithValue("@pYear", fldYear.SelectedValue);
        cmd.Parameters.AddWithValue("@pClientName", fldClientName.Text.Trim());
        cmd.Parameters.AddWithValue("@pEmail", fldEmail.Text.Trim());
        cmd.Parameters.AddWithValue("@pDateRequired", fldDateRequired.Text);

        cmd.ExecuteNonQuery();
        con.Close();

        bindAuditCSS();

        emailClient();

        Response.Redirect("AuditCSS.aspx?ID=" + Request.QueryString["ID"]);
        //}
    }

    protected void btnManualInput_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        
        //Insert into table tblAuditCSS
        queryString = "";
        queryString = queryString + " INSERT INTO   tblAuditCSS ";
        queryString = queryString + "               (DescriptionId, Year, Category, ClientName, Email, DateRequired, Status, CreatedBy, DateCreated) ";
        queryString = queryString + " VALUES        (@pDescriptionId, @pYear, 'Manual', @pClientName, @pEmail, @pDateRequired, 'Pending', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

        cmd.Parameters.AddWithValue("@pYear", fldYear.SelectedValue);
        cmd.Parameters.AddWithValue("@pClientName", fldClientName.Text.Trim());
        cmd.Parameters.AddWithValue("@pEmail", fldEmail.Text.Trim());
        cmd.Parameters.AddWithValue("@pDateRequired", fldDateRequired.Text);

        cmd.ExecuteNonQuery();
        con.Close();

        bindAuditCSS();

        Response.Redirect("AuditCSS.aspx?ID=" + Request.QueryString["ID"]);
    }

    protected void btnCloseC_Click(object sender, EventArgs e)
    {
    }

    protected void emailClient()
    {
        //Latest CSS Id
        SqlCommand cmdCSS = new SqlCommand();
        cmdCSS = new SqlCommand("SELECT TOP 1 Id FROM tblAuditCSS ORDER BY Id DESC", con);
        cmdCSS.CommandTimeout = 0;
        SqlDataAdapter daChck1 = new SqlDataAdapter(cmdCSS);
        DataTable dtChck1 = new DataTable();
        daChck1.Fill(dtChck1);

        rowCSS = null;
        rowCSS = dtChck1.Rows[0];


        //Email notification to client
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Description, tblAuditCSS.Id AS CSSId, tblAuditCSS.ClientName, tblAuditCSS.Email, tblAuditCSS.DateRequired ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblAuditCSS ON tblMain.Id = tblAuditCSS.DescriptionId ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";
        qs = qs + " AND           tblAuditCSS.Id = '" + rowCSS["Id"] + "' ";

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

        //objeto_mail.To.Add(new MailAddress(row["Email"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Client Satisfaction Survey for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["ClientName"].ToString() + ",<BR><BR><BR>"

                            + "Your input to this survey would help us identify what the Company is good at and in which areas we can do better.<BR><BR>"
                            + "This survey will only take approximately 5 - 10 minutes to complete.<BR><BR>"
                            + "To access the survey, click on the link below :<BR><BR><BR>"

                            + "<B>URL : </B><A HREF=http://pectest.uemedgenta.com/PM/ClientCSS.aspx?ID=" + Request.QueryString["Id"] + "&Id1=" + row["CSSId"].ToString() +">Click here</A><BR><BR>"
                            + "<B>Date Required : </B>" + Convert.ToDateTime(row["DateRequired"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "Please note that the link above is intended for you only. As such, please do not share the URL link with others. We thank you in advance and appreciate your time and kind participation.<BR><BR>"

                            + "Note: <br>Please remember not to delete this email until you have completed and submitted the survey online.<BR><BR>"
                            + "<BR><BR><BR>This is a system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void DeleteCSS(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblAuditCSS WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindAuditCSS();
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