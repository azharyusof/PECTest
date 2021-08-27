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

public partial class ProjectDbInfo : System.Web.UI.Page
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
            //Bind dropdownlist
            bindCompany();
            bindSector();
            bindService();
            bindDept();
            bindLOI();
            bindType();
            bindPM();
            bindYear();
            bindBM();
            bindPhase();
            bindDetails();
            bindGeneric();

            if (fldPhase.Text == "GENERIC")
            {
                gvGeneric.Visible = true;
                tblSpecific.Visible = false;
            }
            else if (fldPhase.Text == "SPECIFIC")
            {
                gvGeneric.Visible = false;
                tblSpecific.Visible = true;
            }

            if (fldType.Text == "PROMOTIONAL")
            {
                btnMigrate.Visible = false;
            }
            else
            {
                if (fldDateMigrate.Text == "")
                {
                    btnMigrate.Enabled = true;
                }
                else
                {
                    btnMigrate.Enabled = false;
                }
            }
        }
    }

    public void bindGeneric()
    {
        String str;

        str = "SELECT * FROM tblTypeServices WHERE TypeServices='" + fldService.Text + "' and PHASE <> '- Others -' and projecttype='PROMOTIONAL' order by phasecode,task ";

        SqlCommand xp = new SqlCommand(str, con);


        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvGeneric.DataSource = ds;
        gvGeneric.DataBind();
        con.Close();

        for (int i = 0; i < gvGeneric.Rows.Count; i++)
        {
            GridViewRow row = gvGeneric.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
               
            }
        }
    }
        

    protected void bindPhase()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct upper(Phase) as Phase";
        qs = qs + " FROM          vwProjectDatabase ";
        //qs = qs + " ORDER BY      Phase ";

        fldPhase.DataSource = GetData(qs);
        fldPhase.DataTextField = "Phase";
        fldPhase.DataValueField = "Phase";
        fldPhase.DataBind();
        fldPhase.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindCompany()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct Company ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      Company ";

        fldCompany.DataSource = GetData(qs);
        fldCompany.DataTextField = "Company";
        fldCompany.DataValueField = "Company";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindSector()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct SectorType ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      SectorType ";

        fldSector.DataSource = GetData(qs);
        fldSector.DataTextField = "SectorType";
        fldSector.DataValueField = "SectorType";
        fldSector.DataBind();
        fldSector.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindService()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct TypeServices ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      TypeServices ";

        fldService.DataSource = GetData(qs);
        fldService.DataTextField = "TypeServices";
        fldService.DataValueField = "TypeServices";
        fldService.DataBind();
        fldService.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindDept()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct Department ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      Department ";

        fldDept.DataSource = GetData(qs);
        fldDept.DataTextField = "Department";
        fldDept.DataValueField = "Department";
        fldDept.DataBind();
        fldDept.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindPM()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct PMName, ProjectManager ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      PMName ";

        fldPM.DataSource = GetData(qs);
        fldPM.DataTextField = "PMName";
        fldPM.DataValueField = "ProjectManager";
        fldPM.DataBind();
        fldPM.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindBM()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct BMName, VerifyBy ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      BMName ";

        fldBM.DataSource = GetData(qs);
        fldBM.DataTextField = "BMName";
        fldBM.DataValueField = "VerifyBy";
        fldBM.DataBind();
        fldBM.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindYear()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct Year ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      Year ";

        fldYear.DataSource = GetData(qs);
        fldYear.DataTextField = "Year";
        fldYear.DataValueField = "Year";
        fldYear.DataBind();
        fldYear.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindLOI()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct LOIStatus ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      LOIStatus ";

        fldLOI.DataSource = GetData(qs);
        fldLOI.DataTextField = "LOIStatus";
        fldLOI.DataValueField = "LOIStatus";
        fldLOI.DataBind();
        fldLOI.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindType()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        distinct ProjectType ";
        qs = qs + " FROM          vwProjectDatabase ";
        qs = qs + " ORDER BY      ProjectType ";

        fldType.DataSource = GetData(qs);
        fldType.DataTextField = "ProjectType";
        fldType.DataValueField = "ProjectType";
        fldType.DataBind();
        fldType.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectDatabase.aspx");
    }

    protected void btnMigrate_Click(object sender, EventArgs e)
    {
        //Insert data into Register New Project phase 
        //Step 1: Insert data into tblMain table       

        con.Open();
        SqlCommand cmd = new SqlCommand("spProjectDbMigrateMain", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ProjectName", fldProjectName.Text);
        cmd.Parameters.AddWithValue("@Company", fldCompany.Text);
        cmd.Parameters.AddWithValue("@PM", fldPMNo.Text);
        cmd.Parameters.AddWithValue("@Status", fldStatus.Text);
        cmd.Parameters.AddWithValue("@Code", fldCode.Text);
        cmd.Parameters.AddWithValue("@CodeDt", fldCodeDt.Text);
        cmd.Parameters.AddWithValue("@PM1", fldPMNo.Text);
        cmd.Parameters.AddWithValue("@LoggedDt", fldLoggedDt.Text);
        cmd.Parameters.AddWithValue("@ID", fldID.Text);
        cmd.Parameters.AddWithValue("@Year", fldYear.SelectedValue);
        cmd.Parameters.AddWithValue("@MigrateBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();
        con.Close();

        //Capture latest Id from tblMain table
        con.Open();
        qs = "";
        qs = qs + " SELECT        TOP 1 Id  ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " ORDER BY      Id DESC ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daId = new SqlDataAdapter(cmd);
        DataTable dtId = new DataTable();
        daId.Fill(dtId);
        con.Close();

        row = null;
        row = dtId.Rows[0];

        //Step 2: Insert data into tblProjectRecord table

        con.Open();
        SqlCommand cmd1 = new SqlCommand("spProjectDbMigrateDetail", con);
        cmd1.CommandType = CommandType.StoredProcedure;

        cmd1.Parameters.AddWithValue("@PECId", row["Id"].ToString());
        cmd1.Parameters.AddWithValue("@Company", fldCompany.Text);
        cmd1.Parameters.AddWithValue("@ClientAdd", fldClientAdd.Text);
        cmd1.Parameters.AddWithValue("@ScopeWork", fldScope.Text);
        cmd1.Parameters.AddWithValue("@PM", fldPMNo.Text);
        cmd1.Parameters.AddWithValue("@StartDate", fldStartDate.Text);
        cmd1.Parameters.AddWithValue("@EndDate", fldEndDate.Text);
        cmd1.Parameters.AddWithValue("@BM", fldBMNo.Text);
        cmd1.Parameters.AddWithValue("@BMName", fldBMName.Text.Trim());
        cmd1.Parameters.AddWithValue("@BMApprovalDt", fldBMApprovalDt.Text);
        cmd1.Parameters.AddWithValue("@COOName", "CHIEF OPERATING OFFICER");
        cmd1.Parameters.AddWithValue("@COOApprovalDt", fldCOOApprovalDt.Text);
        cmd1.Parameters.AddWithValue("@PM1", fldPMNo.Text);
        cmd1.Parameters.AddWithValue("@LoggedDt", fldLoggedDt.Text);            

        cmd1.ExecuteNonQuery();
        con.Close();

        ////Update Operating Company in table tblMain
        //if (con.State == System.Data.ConnectionState.Closed)
        //{ con.Open(); }

        //SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
        //        + "OperatingCompany = ProperCase(OperatingCompany) "
        //        + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        //cmdMain.ExecuteNonQuery();

        Response.Redirect("UpdateProjectDb.aspx?Id=" + row["Id"].ToString());
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

            //Company
            fldCompany.Text = row["Company"].ToString();

            //Type Of Sector
            fldSector.Text = row["SectorType"].ToString();

            //Type Of Service
            fldService .Text = row["TypeServices"].ToString();

            //Project Assigned To Department
            fldDept.Text = row["Department"].ToString();

            //Project Name
            fldProjectName.Text = row["Package_Ref_BDU"].ToString().ToUpper();

            //PM
            fldPM.Text = row["PROJECTMANAGER"].ToString();
            fldPMNo.Text = row["PROJECTMANAGER"].ToString();

            //Client Name
            fldClientName.Text = row["ClientName"].ToString().ToUpper();

            //Client Address
            fldClientAdd.Text = row["ClientAdd"].ToString().ToUpper();

            //LOI/LOA/PMA Status
            fldLOI.Text = row["LOIStatus"].ToString();

            //Project Type
            fldType.Text = row["ProjectType"].ToString();

            //Estimated Project Value
            fldValue.Text = row["CostEstimated"].ToString();

            //Estimated Project Fee Including Reimbursable (excluding GST)
            fldFees.Text = row["Fees"].ToString();

            //Scope of Services/Works
            fldScope.Text = row["Scope_Work"].ToString().ToUpper(); 

            //Estimated Project Start & End Date
            object dt1 = row["ProjectStart"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldStartDate.Text = Convert.ToDateTime(row["ProjectStart"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt2 = row["TargetCompletion"];
            if (dt2 == DBNull.Value)
            { }
            else
            { fldEndDate.Text = Convert.ToDateTime(row["TargetCompletion"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt3 = row["Dt_Approval_BDU"];
            if (dt3 == DBNull.Value)
            { }
            else
            { fldBMApprovalDt.Text = Convert.ToDateTime(row["Dt_Approval_BDU"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt4 = row["Dt_Approval_COO"];
            if (dt4 == DBNull.Value)
            { }
            else
            { fldCOOApprovalDt.Text = Convert.ToDateTime(row["Dt_Approval_COO"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt5 = row["DateMigrate"];
            if (dt5 == DBNull.Value)
            { }
            else
            { fldDateMigrate.Text = Convert.ToDateTime(row["DateMigrate"].ToString()).ToString("dd-MMM-yyyy"); }


            //Confidential
            if (row["Confidential"].ToString() == "1")
            { rbCon1.Checked = true; }
            else if (row["Confidential"].ToString() == "2")
            { rbCon2.Checked = true; }
                        
            //Project To Be Included In QMS
            if (row["QMS"].ToString() == "1")
            { rbQMS1.Checked = true; }
            else if (row["QMS"].ToString() == "2")
            { rbQMS2.Checked = true; }

            //External Support Requirement
            if (row["ExtSupport"].ToString() == "1")
            { rbExt1.Checked = true; }
            else if (row["ExtSupport"].ToString() == "2")
            { rbExt2.Checked = true; }

            //BM
            fldBM.Text = row["VerifyBy"].ToString();
            fldBMName.Text = row["VerifyBy"].ToString();
            fldBMNo.Text = row["VerifyBy"].ToString();

            //Year
            fldYear.Text = row["Year"].ToString();

            //Project Phases & Tasks
            fldPhase.Text = row["Phase"].ToString().ToUpper();

            //Project Code
            fldCode.Text = row["Fin_Code"].ToString().ToUpper();
            fldCodeDt.Text = row["Dt_Fin_Code"].ToString();
            fldLoggedDt.Text = row["PMLoggedDate"].ToString();
            fldID.Text = row["ID"].ToString();
            fldStatus.Text = row["Status"].ToString();

            DateTime varDt;

            //Created By
            if (row["CreatedBy"].ToString() != "")
            {
                lblCreatedBy.Text = row["CREATEBYName"].ToString();
            }
            else
                lblCreatedBy.Text = "-";

            //Created Date
            object dt6 = row["DtCreated"];
            if (dt6 == DBNull.Value)
            { lblCreatedDt.Text = "-"; }
            else
            { lblCreatedDt.Text = Convert.ToDateTime(row["DtCreated"].ToString()).ToString("dd-MMM-yyyy"); }

            //Modified By 
            if (row["PMLoggedBy"].ToString() != "")
            {
                lblLastUpdate.Text = row["UPDATEBYName"].ToString();
            }
            else
                lblLastUpdate.Text = "-";

            //Modified Date
            object dt7 = row["PMLoggedDate"];
            if (dt7 == DBNull.Value)
            { lblLastUpdateDt.Text = "-"; }
            else
            { lblLastUpdateDt.Text = Convert.ToDateTime(row["PMLoggedDate"].ToString()).ToString("dd-MMM-yyyy"); }

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