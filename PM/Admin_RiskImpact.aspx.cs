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
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Security;

public partial class Admin_RiskImpact : System.Web.UI.Page
{ 
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlConnection conUM = new SqlConnection(ConfigurationManager.ConnectionStrings["UMatrixDbConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            bindUserRole();            

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");            
        }            
    }


    public void bindUserRole()
    {
        String str;

        str = "";
        str = str + " SELECT        *  ";
        str = str + " FROM          tblRiskImpactFinance ";

        SqlCommand xp = new SqlCommand(str, con);

            if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds);
        gvRiskImpact.DataSource = ds;
        gvRiskImpact.DataBind();
            con.Close();

            for (int i = 0; i < gvRiskImpact.Rows.Count; i++)
            {
                GridViewRow row = gvRiskImpact.Rows[i];

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
                }
            }
    }
            
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
       
    

    protected void EditRiskImpact(object sender, GridViewEditEventArgs e)
    {
        gvRiskImpact.EditIndex = e.NewEditIndex;
        bindUserRole();
    }

    protected void CancelRiskImpactEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRiskImpact.EditIndex = -1;
        bindUserRole();
    }

    protected void UpdateRiskImpact(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvRiskImpact.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Factor = ((TextBox)gvRiskImpact.Rows[e.RowIndex].FindControl("txtFactor")).Text;
        string Impact_Insignificant = ((TextBox)gvRiskImpact.Rows[e.RowIndex].FindControl("txtImpact_Insignificant")).Text;
        string Impact_Minor = ((TextBox)gvRiskImpact.Rows[e.RowIndex].FindControl("txtImpact_Minor")).Text;
        string Impact_Moderate = ((TextBox)gvRiskImpact.Rows[e.RowIndex].FindControl("txtImpact_Moderate")).Text;
        string Impact_Major = ((TextBox)gvRiskImpact.Rows[e.RowIndex].FindControl("txtImpact_Major")).Text;
        string Impact_Catastrophic = ((TextBox)gvRiskImpact.Rows[e.RowIndex].FindControl("txtImpact_Catastrophic")).Text;
               
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmd = new SqlCommand("UPDATE tblRiskImpactFinance SET Factor = @pFactor, " +
            " Impact_Insignificant = @pImpact_Insignificant, " +
            " Impact_Minor = @pImpact_Minor, " +
            " Impact_Moderate = @pImpact_Moderate, " +
            " Impact_Major = @pImpact_Major, " +
            " Impact_Catastrophic = @pImpact_Catastrophic " +
            " WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pFactor", SqlDbType.VarChar).Value = Factor;
        cmd.Parameters.Add("@pImpact_Insignificant", SqlDbType.VarChar).Value = Impact_Insignificant;
        cmd.Parameters.Add("@pImpact_Minor", SqlDbType.VarChar).Value = Impact_Minor;
        cmd.Parameters.Add("@pImpact_Moderate", SqlDbType.VarChar).Value = Impact_Moderate;
        cmd.Parameters.Add("@pImpact_Major", SqlDbType.VarChar).Value = Impact_Major;
        cmd.Parameters.Add("@pImpact_Catastrophic", SqlDbType.VarChar).Value = Impact_Catastrophic;

        cmd.ExecuteNonQuery();
        
        gvRiskImpact.EditIndex = -1;

        con.Close();

        bindUserRole();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //DateTime now = DateTime.Now;

        //if (con.State == System.Data.ConnectionState.Closed)
        //{ con.Open(); }

        ////Check tblLogin
        //qs1 = "";
        //qs1 = qs1 + " SELECT        StaffNo ";
        //qs1 = qs1 + " FROM          tblLogin ";
        //qs1 = qs1 + " WHERE         StaffNo = '" + fldStaff.SelectedValue + "' ";

        //cmd1 = new SqlCommand(qs1, con);
        //cmd1.CommandTimeout = 0;

        //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        //DataTable dt1 = new DataTable();
        //da1.Fill(dt1);

        //if (dt1.Rows.Count == 0)
        //{
        //    //Update role in tblLogin
        //    SqlCommand cmdLogin = new SqlCommand("UPDATE tblLogin SET PECRole='1' WHERE StaffNo = '" + fldStaff.SelectedValue + "'", con);

        //    cmdLogin.ExecuteNonQuery();
        //}

        ////Insert details in tblUserRole
        //SqlCommand cmdRole = new SqlCommand("INSERT INTO tblUserRole (StaffNo, Role) VALUES ('" + fldStaff.SelectedValue + "', '" + fldRole.SelectedValue + "')", con);

        //cmdRole.ExecuteNonQuery();

        //con.Close();

        //if (conUM.State == System.Data.ConnectionState.Closed)
        //{ conUM.Open(); }

        ////Check tbl_apps_access 
        //qs = "";
        //qs = qs + " SELECT        staff_no ";
        //qs = qs + " FROM          tbl_apps_access ";
        //qs = qs + " WHERE         staff_no = '" + fldStaff.SelectedValue + "' AND access_system = 'PEC' ";

        //cmd = new SqlCommand(qs, conUM);
        //cmd.CommandTimeout = 0;

        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //da.Fill(dt);

        //if (dt.Rows.Count == 0)
        //{
        //    //Insert details in tbl_apps_access
        //    SqlCommand cmdUM = new SqlCommand("INSERT INTO tbl_apps_access (staff_no, access_system, status, create_by, create_datetime) VALUES ('" + fldStaff.SelectedValue + "', 'PEC', '1', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')", conUM);

        //    cmdUM.ExecuteNonQuery();
        //}

        //conUM.Close();

        //bindUserRole();

        //fldStaff.Text = "";
        //fldRole.Text = "";
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
    }
}