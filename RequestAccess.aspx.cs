using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestAccess : System.Web.UI.Page
{
    DataRow row = null;
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Reset error
            errDvfldUserID.Visible = false;
            errDvfldPass.Visible = false;
            errfldMain.Text = "";
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        errDvfldUserID.Visible = false;
        errDvfldPass.Visible = false;
        errfldMain.Text = "";
        dvUserID.Attributes.Add("class", "row");
        dvPass.Attributes.Add("class", "row");

        if (fldUserID.Text == "")
        {
            chckErr = false;
            errDvfldUserID.Visible = true;
            dvUserID.Attributes.Add("class", "row has-error");
        }

        if (fldPass.Text == "")
        {
            chckErr = false;
            errDvfldPass.Visible = true;
            dvPass.Attributes.Add("class", "row has-error");
        }

        if (chckErr == true)
        {
            //Send email notification
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp2.edgenta.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("user", "Password");

            objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

            objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));
            objeto_mail.Bcc.Add(new MailAddress("shafiqhafiz@opusbhd.com"));

            objeto_mail.Subject = "Request Access To PEC";

            string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                                + "Hi Team,<BR><BR><BR>"

                                + "This user has requested an access to the PEC :<BR><BR><BR>"

                                + "<B>Staff ID : </B>" + fldUserID.Text + "<BR><BR>"
                                + "<B>Email Address : </B>" + fldPass.Text + "<BR><BR>"
                                
                                + "Login to the PEC and go to Administrator Module -> User Role.<BR><BR>"
                                
                                + "<BR><BR><BR>Thank you.<BR><BR>"
                                + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

            objeto_mail.Body = htmlText;
            objeto_mail.IsBodyHtml = true;

            client.Send(objeto_mail);
            //---------------------------------- end of send email ----------------------------------------

            ////Check user id existing
            //queryString = "";
            //queryString = queryString + " SELECT        * ";
            //queryString = queryString + " FROM          StaffLogin ";
            //queryString = queryString + " WHERE         StaffNo = '" + fldUserID.Text.Trim() + "' ";
            //queryString = queryString + " AND           Role IS NOT NULL ";
            //if (con.State == System.Data.ConnectionState.Closed)
            //{ con.Open(); }
            //cmd = new SqlCommand(queryString, con);
            //cmd.CommandTimeout = 0;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();

            //if (dt.Rows.Count == 0)
            //{
            //    //Error no user id
            //    errfldMain.Text = "You do not have permission to access this system!";
            //}
            //else
            //{
            //    row = null;
            //    row = dt.Rows[0];

            //    //using (MD5 md5Hash = MD5.Create())
            //    //{
            //    //    string md5pass = GetMd5Hash(md5Hash, fldPass.Text);

            //    //    //Check for password
            //    //    //if (row["Pwd"].ToString() == fldPass.Text || row["Pwd"].ToString() == md5pass)
            //    //    //{
            //    //    //    Session["UserID"] = row["StaffNo"].ToString();
            //    //    //    Session["UserName"] = row["StaffName"].ToString();
            //    //    //    //Session["StaffNo"] = fldUserID.Text;
            //    //    //    //Response.Redirect("PM/ProjectListing.aspx?ID=" + fldUserID.Text);

            //    //    //    if (row["Role"].ToString() == "HSE")
            //    //    //    {
            //    //    //        Response.Redirect("PM/ProjectListingHSE.aspx");
            //    //    //    }
            //    //    //    else
            //    //    //    {
            //    //    //        Response.Redirect("PM/ProjectListing.aspx");
            //    //    //    }

            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //    //Error wrong password
            //    //    //    errfldMain.Text = "Password invalid";
            //    //    //}
            //    //}
            //}

            errfldMain.Text = "Your request has been submitted.";
        }
    }

    protected void btnRequestAccess_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

}