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

public partial class ChangePassword : System.Web.UI.Page
{
    DataRow row = null;
    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDbConn"].ConnectionString);
    //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDbConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fldUserID.Text = Session["UserID"].ToString();
            fldUserID.Enabled = false;

            errDvfldPass.Visible = false;
            errDvfldNewPass.Visible = false;
        }
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        this.Refresh();

        if (fldPass.Text == "")
        {
            chckErr = false;
            errDvfldPass.Visible = true;
            dvPass.Attributes.Add("class", "row has-error");
        }

        if (fldNewPass.Text == "")
        {
            chckErr = false;
            errDvfldNewPass.Visible = true;
            dvNewPass.Attributes.Add("class", "row has-error");
        }

        if (chckErr == true)
        {
            string conString = ConfigurationManager.ConnectionStrings["ProjectDbConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("spChangePasswordCheck", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@StaffNo", SqlDbType.NVarChar).Value = fldUserID.Text.Trim();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //wrong old password inserted
                        if (dr["Pwd"].ToString() != fldPass.Text.Trim())
                        {
                            chckErr = false;
                            errDvfldPass.Visible = true;
                            errDvfldPass.Text = "Wrong old password!";
                            dvPass.Attributes.Add("class", "row has-error");
                        }
                        //user insert new password as same as old password
                        else if (dr["Pwd"].ToString() == fldNewPass.Text.Trim())
                        {
                            chckErr = false;
                            errDvfldNewPass.Visible = true;
                            errDvfldNewPass.Text = "New Password can't be old password!";
                            dvNewPass.Attributes.Add("class", "row has-error");
                        }
                        //user insert correct old password & new password
                        else if (dr["Pwd"].ToString() == fldPass.Text.Trim() && dr["Pwd"].ToString() != fldNewPass.Text.Trim())
                        {
                            using (SqlConnection conn = new SqlConnection(conString))
                            {
                                conn.Open();

                                SqlCommand cmd2 = new SqlCommand("spChangePasswordInsert", conn)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };

                                cmd2.Parameters.AddWithValue("@StaffNo", SqlDbType.NVarChar).Value = fldUserID.Text.Trim();
                                cmd2.Parameters.AddWithValue("@NewPass", SqlDbType.NVarChar).Value = fldNewPass.Text.Trim();

                                cmd2.ExecuteNonQuery();
                                conn.Close();

                                Response.Write("<script language='javascript'>window.alert('New Password successfully created. Try login again!');window.location='Default.aspx';</script>");
                            }
                        }
                    }
                }

                con.Close();
            }
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    private void Refresh()
    {
        errDvfldPass.Visible = false;
        errDvfldNewPass.Visible = false;
        errfldMain.Text = "";

        dvUserID.Attributes.Add("class", "row");
        dvPass.Attributes.Add("class", "row");
        dvNewPass.Attributes.Add("class", "row");
    }
}