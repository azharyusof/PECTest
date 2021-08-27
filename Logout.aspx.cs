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

public partial class Logout : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDbConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        updateAuditLog();
        Response.Redirect("Default.aspx");
    }

    public void updateAuditLog()
    {

        SqlCommand cmd = new SqlCommand("spAuditLog", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@Command", SqlDbType.VarChar).Value = "LOGOUT";
        cmd.Parameters.AddWithValue("@SPName", SqlDbType.NVarChar).Value = "";
        cmd.Parameters.AddWithValue("@ScreenPath", SqlDbType.VarChar).Value = "Logout.aspx";
        cmd.Parameters.AddWithValue("@OldValue", SqlDbType.VarChar).Value = "";
        cmd.Parameters.AddWithValue("@NewValue", SqlDbType.VarChar).Value = "";
        cmd.Parameters.AddWithValue("@PerformBY", SqlDbType.NVarChar).Value = Session["UserID"].ToString();

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}