using System;
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

public partial class PM_Masterpage : System.Web.UI.MasterPage
{
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        qs = "";
        qs = qs + " SELECT          * ";
        qs = qs + " FROM            StaffLogin ";
        qs = qs + " WHERE           StaffNo = '" + Session["UserID"] + "' ";
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
            //Error no user id
        }
        else
        {
            row = null;
            row = dt.Rows[0];

            if (row["Role"].ToString() == "Admin")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = true;
                vwAdmin3.Visible = true;
                vwAdmin4.Visible = true;
                vwAdmin5.Visible = true;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = true;
            }
            else if (row["Role"].ToString() == "ProjectCoordinator" || row["Role"].ToString() == "ProjectFacilitator")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = true;
                vwAdmin5.Visible = true;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "ProjectManager")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = true;
                vwAdmin5.Visible = false;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "NormalUser")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = false;
                vwAdmin5.Visible = true;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "Risk" || row["Role"].ToString() == "HSE" || row["Role"].ToString() == "Auditor" || row["Role"].ToString() == "QHSE")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = false;
                vwAdmin5.Visible = false;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "Finance")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = false;
                vwAdmin5.Visible = false;
                vwAdmin6.Visible = true;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "BD")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = true;
                vwAdmin5.Visible = false;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "ProjectFinance")
            {
                vwAdmin1.Visible = false;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = false;
                vwAdmin5.Visible = false;
                vwAdmin6.Visible = true;
                vwAdmin7.Visible = false;
            }
            else if (row["Role"].ToString() == "COO" || row["Role"].ToString() == "MDCEO" || row["Role"].ToString() == "HeadUnit" || row["Role"].ToString() == "HeadDivision")
            {
                vwAdmin1.Visible = true;
                vwAdmin2.Visible = false;
                vwAdmin3.Visible = false;
                vwAdmin4.Visible = true;
                vwAdmin5.Visible = false;
                vwAdmin6.Visible = false;
                vwAdmin7.Visible = true;
            }

        }
    }
}
