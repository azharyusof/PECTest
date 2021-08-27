using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataRow row = null;
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDbConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            errDvfldUserID.Visible = false;
            errDvfldPass.Visible = false;
        }
    }

    public void updateAuditLog()
    {
        
        SqlCommand cmd = new SqlCommand("spAuditLog", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@Command", SqlDbType.VarChar).Value = "LOGIN";
        cmd.Parameters.AddWithValue("@SPName", SqlDbType.NVarChar).Value = "";
        cmd.Parameters.AddWithValue("@ScreenPath", SqlDbType.VarChar).Value = "Default.aspx";
        cmd.Parameters.AddWithValue("@OldValue", SqlDbType.VarChar).Value = "";
        cmd.Parameters.AddWithValue("@NewValue", SqlDbType.VarChar).Value = "";
        cmd.Parameters.AddWithValue("@PerformBY", SqlDbType.NVarChar).Value = Session["UserID"].ToString();

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
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
            //Check user id existing
            queryString = "";
            queryString = queryString + " SELECT        * ";
            queryString = queryString + " FROM          StaffLogin ";
            queryString = queryString + " WHERE         StaffNo = '" + fldUserID.Text.Trim() + "' ";
            queryString = queryString + " AND           Role IS NOT NULL ";

            if (con.State == System.Data.ConnectionState.Closed)
            { 
                con.Open(); 
            }

            //Response.Write(queryString);

            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 0)
            {
                //Error no user id
                errfldMain.Text = "You do not have permission to access this system!";
            }
            else
            {
                row = null;
                row = dt.Rows[0];

                using (MD5 md5Hash = MD5.Create())
                {
                    string md5pass = GetMd5Hash(md5Hash, fldPass.Text);

                    Session["UserID"] = row["StaffNo"].ToString();
                    Session["UserName"] = row["StaffName"].ToString();
                    //Session["StaffNo"] = fldUserID.Text;
                    //Response.Redirect("PM/ProjectListing.aspx?ID=" + fldUserID.Text);

                    //Check for password
                    if (row["Pwd"].ToString() == fldPass.Text.Trim() || row["Pwd"].ToString() == md5pass)
                    {
                        if(fldUserID.Text.Trim() == fldPass.Text.Trim())
                        {
                            Response.Redirect("ChangePassword.aspx");
                        }
                        else
                        {
                            updateAuditLog();

                            if (row["Role"].ToString() == "ProjectFinance")
                            {
                                Response.Write("1");
                                Response.Redirect("PM/ProjectListingFin.aspx");
                            }
                            else
                            {
                                Response.Write("2");
                                Response.Redirect("PM/ProjectListing.aspx");
                            }
                        }
                    }
                    else
                    {
                        //Error wrong password
                        Response.Write("3");
                        errfldMain.Text = "Password invalid";
                    }
                }
            }
        }
    }

    protected void btnRequestAccess_Click(object sender, EventArgs e)
    {
        Response.Redirect("RequestAccess.aspx");
    }


    public static string GetMd5Hash(MD5 md5Hash, string input)
    {
        // Convert the input string to a byte array and compute the hash. 
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes and create a string. 
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data and format each one as a hexadecimal string. 
        int i = 0;
        for (i = 0; i <= data.Length - 1; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string. 
        return sBuilder.ToString();
    }
}