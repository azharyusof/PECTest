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

public partial class ProjectDbDetail : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        DateTime now = DateTime.Now;

        lblUser.Text = Session["UserName"].ToString();
        lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

        if (!Page.IsPostBack)
        {
            //checkRole();

            //fldNewClientName.Visible = false;

            ////Bind dropdownlist
            
            bindMarket();
            bindStatus();
            bindCountry();
            bindDetails();

        }
    }


    //protected void checkRole()
    //{
    //    qs = "";
    //    qs = qs + " SELECT        Role  ";
    //    qs = qs + " FROM          StaffLogin ";
    //    qs = qs + " WHERE         StaffNo = '" + Session["UserID"].ToString() + "' ";

    //    if (con.State == System.Data.ConnectionState.Closed)
    //    { con.Open();
    //    }
    //    cmd = new SqlCommand(qs, con);
    //    cmd.CommandTimeout = 0;

    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    con.Close();

    //    if (dt.Rows.Count == 0)
    //    {
    //        //Check for empty record.            
    //    }
    //    else
    //    {
    //        DataRow row = dt.Rows[0];

    //        //if (row["Role"].ToString() == "Auditor" || row["Role"].ToString() == "HSE")
    //        //{
    //        //    btnUpdate.Visible = false;
    //        //    btnSubmit.Visible = false;
    //        //}
    //        //else
    //        //{
    //        //    btnUpdate.Visible = true;
    //        //    btnSubmit.Visible = true;
    //        //}
    //    }
    //}

    

    protected void bindMarket()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct SectorType ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      SectorType ";

        fldMarket.DataSource = GetData(qs);
        fldMarket.DataTextField = "SectorType";
        fldMarket.DataValueField = "SectorType";
        fldMarket.DataBind();
        fldMarket.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindStatus()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct Status ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      Status ";

        fldStatus.DataSource = GetData(qs);
        fldStatus.DataTextField = "Status";
        fldStatus.DataValueField = "Status";
        fldStatus.DataBind();
        fldStatus.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindCountry()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct Country ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      Country ";

        fldCountry.DataSource = GetData(qs);
        fldCountry.DataTextField = "Country";
        fldCountry.DataValueField = "Country";
        fldCountry.DataBind();
        fldCountry.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    
    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectDatabase.aspx");
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        vwProjectDatabase.*,  ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = vwProjectDatabase.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = vwProjectDatabase.PMLoggedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         vwProjectDatabase.Id = '" + Request.QueryString["Id"] + "' ";

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

            //No. of Staff
            if (row["No_Staff"].ToString() == null || row["No_Staff"].ToString() == "")
            { fldStaff.Text = "NONE"; }
            else
            { fldStaff.Text = row["No_Staff"].ToString().ToUpper(); }

            //No. of Man-Month
            if (row["No_Man_Month"].ToString() == null || row["No_Man_Month"].ToString() == "")
            { fldManMonth.Text = "NONE"; }
            else
            { fldManMonth.Text = row["No_Man_Month"].ToString().ToUpper(); }

            //Project Description
            if (row["Desc_Ref_FIN"].ToString() == null || row["Desc_Ref_FIN"].ToString() == "")
            { fldDesc.Text = "NONE"; }
            else
            { fldDesc.Text = row["Desc_Ref_FIN"].ToString().ToUpper(); }

            //Scope of Services/Works
            if (row["Scope_Work"].ToString() == null || row["Scope_Work"].ToString() == "")
            { fldScope.Text = "NONE"; }
            else
            { fldScope.Text = row["Scope_Work"].ToString().ToUpper(); }

            //Market Sector
            fldMarket.Text = row["SectorType"].ToString();

            //Status
            fldStatus.Text = row["Status"].ToString();

            //Country
            fldCountry.Text = row["Country"].ToString();

            //Remarks
            if (row["PM_Remarks"].ToString() == null || row["PM_Remarks"].ToString() == "")
            { fldRemarks.Text = "NONE"; }
            else
            { fldRemarks.Text = row["PM_Remarks"].ToString().ToUpper(); }
                        
        }
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