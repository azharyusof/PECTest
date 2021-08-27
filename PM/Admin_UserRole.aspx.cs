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

public partial class Admin_UserRole : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlConnection conUM = new SqlConnection(ConfigurationManager.ConnectionStrings["UMatrixDbConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            bindStaff();
            bindRole();
            bindUserRole();

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }
    }
    #endregion

    #region BindData
    protected void bindStaff()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          tblStaff ";
        //qs = qs + " WHERE Company IN ('OPUS CONSULTANTS(M) SDN BHD', 'OPUS CONSULTANTS (M) SDN BHD', 'OPUS INTERNATIONAL(M) BERHAD', 'OPUS MANAGEMENT SDN BHD') ";
        qs = qs + " ORDER BY      StaffName ";

        fldStaff.DataSource = GetData(qs);
        fldStaff.DataTextField = "StaffName";
        fldStaff.DataValueField = "StaffNo";
        fldStaff.DataBind();
        fldStaff.Items.Insert(0, new ListItem("-- Select Staff Name --", ""));
    }

    protected void bindRole()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        Code, Role ";
        qs = qs + " FROM          tblRole ";
        qs = qs + " ORDER BY      Role ";

        fldRole.DataSource = GetData(qs);
        fldRole.DataTextField = "Role";
        fldRole.DataValueField = "Code";
        fldRole.DataBind();
        fldRole.Items.Insert(0, new ListItem("-- Select Role --", ""));
    }

    public void bindUserRole()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);

        SqlCommand xp = new SqlCommand("spUserRoleList", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        xp.Connection = con;

        try
        {
            con.Open();
            gvUserRole.DataSource = xp.ExecuteReader();
            gvUserRole.DataBind();
        }
        catch (Exception ex)
        {
           // throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }

        for (int i = 0; i < gvUserRole.Rows.Count; i++)
        {
            GridViewRow row = gvUserRole.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                row.Cells[6].Style.Add("background-color", "#FFECEC");
            }
        }
    }
    #endregion

    public void bindEmailUser()
    {
        //Email notification to new user
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        StaffNo, EmailId ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         StaffNo = '" + fldStaff.SelectedValue + "' ";

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
        
        //Send email notification
        MailMessage objeto_mail = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        objeto_mail.To.Add(new MailAddress(row["EmailId"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));
        objeto_mail.Bcc.Add(new MailAddress("shafiqhafiz@opusbhd.com"));

        objeto_mail.Subject = "New User Registration For PEC";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi,<BR><BR><BR>"

                            + "Your user id has been successfully registered in PEC. Please refer below:<BR><BR><BR>"

                            + "<B>User ID : </B>" + row["StaffNo"].ToString() + "<BR><BR>"
                            + "<B>Password : </B>" + row["StaffNo"].ToString() + "<BR><BR>"
                            + "<B>URL : </B> <a href='http://pec.uemedgenta.com'>http://pec.uemedgenta.com</a> <BR><BR>"


                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------

    }

    #region GetData
    public DataSet GetData(string qs)
    {
        // Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
        DataSet ds = new DataSet();

        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(qs, connection);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }
    #endregion

    protected void DeleteRow(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmd = new SqlCommand("DELETE tblUserRole WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();

        con.Close();

        bindUserRole();
    }


    #region UserRole
    protected void gvUserRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Bind data to the dropdownlist control.
            DropDownList txtRole = (e.Row.FindControl("txtRole") as DropDownList);
            txtRole.DataSource = GetData("SELECT Code, Role FROM tblRole ORDER BY Role");
            txtRole.DataTextField = "Role";
            txtRole.DataValueField = "Code";
            txtRole.DataBind();

            string RoleCode = (e.Row.FindControl("txtRoleCode") as TextBox).Text;
            txtRole.Items.FindByValue(RoleCode).Selected = true;

            //generate data for Secretary DDL
            DropDownList ddlSecretary = (e.Row.FindControl("ddlSecretary") as DropDownList);
            ddlSecretary.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            ddlSecretary.DataTextField = "StaffName";
            ddlSecretary.DataValueField = "StaffName";
            ddlSecretary.DataBind();
            ddlSecretary.Items.Insert(0, new ListItem("-- Please select one --", ""));

            //generate data for PA DDL
            DropDownList ddlPA = (e.Row.FindControl("ddlPA") as DropDownList);
            ddlPA.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            ddlPA.DataTextField = "StaffName";
            ddlPA.DataValueField = "StaffName";
            ddlPA.DataBind();
            ddlPA.Items.Insert(0, new ListItem("-- Please select one --", ""));

            string ddlSecretaryCode = (e.Row.FindControl("ddlSecretaryCode") as TextBox).Text;
            ddlSecretary.Items.FindByValue(ddlSecretaryCode).Selected = true;

            string ddlPACode = (e.Row.FindControl("ddlPACode") as TextBox).Text;
            ddlPA.Items.FindByValue(ddlPACode).Selected = true;
        }
    }

    protected void EditUserRole(object sender, GridViewEditEventArgs e)
    {
        gvUserRole.EditIndex = e.NewEditIndex;
        bindUserRole();
    }

    protected void CancelUserRoleEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvUserRole.EditIndex = -1;
        bindUserRole();
    }

    protected void UpdateUserRole(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvUserRole.Rows[e.RowIndex].FindControl("lblID")).Text;
        string StaffNo = ((Label)gvUserRole.Rows[e.RowIndex].FindControl("lblStaffNo")).Text;
        string Role = ((DropDownList)gvUserRole.Rows[e.RowIndex].FindControl("txtRole")).Text;
        string Email = ((TextBox)gvUserRole.Rows[e.RowIndex].FindControl("txtEmail")).Text;

        string ddlSecretary = ((DropDownList)gvUserRole.Rows[e.RowIndex].FindControl("ddlSecretary")).Text; //Secretary - nvarchar
        string ddlPA = ((DropDownList)gvUserRole.Rows[e.RowIndex].FindControl("ddlPA")).Text; //PA - nvarchar

        SqlCommand cmd2 = new SqlCommand("spUpdateUserRole", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd2.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = ID;
        cmd2.Parameters.AddWithValue("@pRole", SqlDbType.NVarChar).Value = Role;
        cmd2.Parameters.AddWithValue("@pStaffNo", SqlDbType.VarChar).Value = StaffNo;
        cmd2.Parameters.AddWithValue("@pEmail", SqlDbType.VarChar).Value = Email;

        cmd2.Parameters.AddWithValue("pSecretaryName", SqlDbType.VarChar).Value = ddlSecretary;
        cmd2.Parameters.AddWithValue("@pPAName", SqlDbType.VarChar).Value = ddlPA;

        cmd2.Parameters.AddWithValue("@pUser", SqlDbType.NVarChar).Value = Session["UserID"].ToString();

        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();


        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();

        gvUserRole.EditIndex = -1;

        this.bindUserRole();
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Check tblLogin
        qs1 = "";
        qs1 = qs1 + " SELECT        StaffNo ";
        qs1 = qs1 + " FROM          tblLogin ";
        qs1 = qs1 + " WHERE         StaffNo = '" + fldStaff.SelectedValue + "' ";

        cmd1 = new SqlCommand(qs1, con);
        cmd1.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);

        if (dt1.Rows.Count == 0)
        {
            //Update role in tblLogin
            SqlCommand cmdLogin = new SqlCommand("UPDATE tblLogin SET PECRole='1' WHERE StaffNo = '" + fldStaff.SelectedValue + "'", con);

            cmdLogin.ExecuteNonQuery();
        }

        //Insert details in tblUserRole
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblUserRole (StaffNo, Role) VALUES ('" + fldStaff.SelectedValue + "', '" + fldRole.SelectedValue + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        if (conUM.State == System.Data.ConnectionState.Closed)
        { conUM.Open(); }

        //Check tbl_apps_access 
        qs = "";
        qs = qs + " SELECT        staff_no ";
        qs = qs + " FROM          tbl_apps_access ";
        qs = qs + " WHERE         staff_no = '" + fldStaff.SelectedValue + "' AND access_system = 'PEC' ";

        cmd = new SqlCommand(qs, conUM);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //Insert details in tbl_apps_access
            SqlCommand cmdUM = new SqlCommand("INSERT INTO tbl_apps_access (staff_no, access_system, status, create_by, create_datetime) VALUES ('" + fldStaff.SelectedValue + "', 'PEC', '1', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')", conUM);

            cmdUM.ExecuteNonQuery();
        }

        conUM.Close();

        bindUserRole();
        bindEmailUser();

        fldStaff.Text = "";
        fldRole.Text = "";
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {

    }
}