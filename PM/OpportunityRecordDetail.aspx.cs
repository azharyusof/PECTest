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

public partial class OpportunityRecordDetail : System.Web.UI.Page
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
            checkRole();

            fldNewClientName.Visible = false;

            //Bind dropdownlist
            bindCompany();
            bindUnit();
            bindClientName();
            bindProjectManager();
            bindPIC1();
            bindPIC2();
            bindDetails();
        }
    }

    protected void checkRole()
    {
        qs = "";
        qs = qs + " SELECT        Role  ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         StaffNo = '" + Session["UserID"].ToString() + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open();
        }
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

            if (row["Role"].ToString() == "Auditor" || row["Role"].ToString() == "HSE")
            {
                btnUpdate.Visible = false;
                btnSubmit.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnSubmit.Visible = true;
            }
        }
    }

    protected void bindCompany()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        OperatingCompany ";
        qs = qs + " FROM          tblOperatingCompany ";
        qs = qs + " ORDER BY      OperatingCompany ";

        fldCompany.DataSource = GetData(qs);
        fldCompany.DataTextField = "OperatingCompany";
        fldCompany.DataValueField = "OperatingCompany";
        fldCompany.DataBind();
        fldCompany.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindUnit()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        OperatingUnit ";
        qs = qs + " FROM          tblOperatingUnit ";
        qs = qs + " ORDER BY      OperatingUnit ";

        fldUnit.DataSource = GetData(qs);
        fldUnit.DataTextField = "OperatingUnit";
        fldUnit.DataValueField = "OperatingUnit";
        fldUnit.DataBind();
        fldUnit.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindClientName()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        Id, ClientName ";
        qs = qs + " FROM          tblClient ";
        qs = qs + " ORDER BY      ClientName ";

        fldClientName.DataSource = GetData(qs);
        fldClientName.DataTextField = "ClientName";
        fldClientName.DataValueField = "Id";
        fldClientName.DataBind();
        fldClientName.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void fldClientName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldClientName.SelectedIndex == 1)
        {
            fldNewClientName.Text = "";
            fldNewClientName.Visible = true;
        }
        else
        {
            fldNewClientName.Visible = false;
        }
    }

    protected void bindProjectManager()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPM.DataSource = GetData(qs);
        fldPM.DataTextField = "StaffName";
        fldPM.DataValueField = "StaffNo";
        fldPM.DataBind();
        fldPM.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindPIC1()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldPIC1.DataSource = GetData(qs);
        fldPIC1.DataTextField = "StaffName";
        fldPIC1.DataValueField = "StaffNo";
        fldPIC1.DataBind();
        fldPIC1.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindPIC2()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldPIC2.DataSource = GetData(qs);
        fldPIC2.DataTextField = "StaffName";
        fldPIC2.DataValueField = "StaffNo";
        fldPIC2.DataBind();
        fldPIC2.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        vwMain.*,  ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          vwMain ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = vwMain.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = vwMain.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         vwMain.Id = '" + Request.QueryString["Id"] + "' ";

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

            //Operating Company
            fldCompany.Text = row["OperatingCompany"].ToString();

            //Operating Unit
            fldUnit.Text = row["OperatingUnit"].ToString();

            //Client Name
            fldClientName.Text = row["ClientId"].ToString();

            //Client Address
            fldClientAdd.Text = row["ClientAddress"].ToString();

            //Opportunity Name
            fldDescription.Text = row["Description"].ToString();

            //Scope of Work
            fldSOW.Text = row["ScopeWork"].ToString();

            //Decision Maker
            fldDecisionMaker.Text = row["DecisionMaker"].ToString();

            //Role
            fldRole.Text = row["Role"].ToString();

            //Project Manager
            fldPM.Text = row["ProjectManager"].ToString();

            //Person In Charge [1]
            fldPIC1.Text = row["PIC1"].ToString();

            //Person In Charge [2]
            fldPIC2.Text = row["PIC2"].ToString();

            //Estimated Project Value
            object dta = row["EstProjectValue"];
            if (dta == DBNull.Value)
            { }
            else
            { fldProjectValue.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["EstProjectValue"].ToString())); }

            //Estimated Project Fees
            object dtb = row["EstProjectFee"];
            if (dtb == DBNull.Value)
            { }
            else
            { fldProjectFee.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["EstProjectFee"].ToString())); }

            //Estimated Project Start & End Date
            object dt1 = row["EstStartDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldStartDate.Text = Convert.ToDateTime(row["EstStartDate"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt2 = row["EstEndDate"];
            if (dt2 == DBNull.Value)
            { }
            else
            { fldEndDate.Text = Convert.ToDateTime(row["EstEndDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Chances Project Materializing
            fldPercent.Text = row["MaterializingPercent"].ToString();

            fldComment.Text = row["MaterializingComment"].ToString();
                        
            DateTime varDt;

            //Created By
            if (row["CreatedBy"].ToString() != "")
            {
                lblCreatedBy.Text = row["CREATEBYName"].ToString();
            }
            else
                lblCreatedBy.Text = "-";

            //Created Date
            object dt6 = row["DateCreated"];
            if (dt6 == DBNull.Value)
            { lblCreatedDt.Text = "-"; }
            else
            { lblCreatedDt.Text = Convert.ToDateTime(row["DateCreated"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Modified By 
            if (row["ModifyBy"].ToString() != "")
            {
                lblLastUpdate.Text = row["UPDATEBYName"].ToString();
            }
            else
                lblLastUpdate.Text = "-";

            //Modified Date
            object dt7 = row["DateModify"];
            if (dt7 == DBNull.Value)
            { lblLastUpdateDt.Text = "-"; }
            else
            { lblLastUpdateDt.Text = Convert.ToDateTime(row["DateModify"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //btnUpdate & btnSubmit
            object dt8 = row["BtnSubmit"];
            if (dt8 == DBNull.Value)
            {
                btnUpdate.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateOpportunity();
        
        Response.Redirect("OpportunityRecordDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvCompany.Attributes.Add("class", null);
        dvUnit.Attributes.Add("class", null);
        dvClientName.Attributes.Add("class", null);
        dvClientAdd.Attributes.Add("class", null);
        dvOpportunity.Attributes.Add("class", null);
        dvSOW.Attributes.Add("class", null);
        dvPM.Attributes.Add("class", null);
        dvProjectValue.Attributes.Add("class", null);
        dvProjectFee.Attributes.Add("class", null);
        dvProjectDate.Attributes.Add("class", null);

        if (fldCompany.SelectedIndex == 0)
        {
            chckErr = false;
            dvCompany.Attributes.Add("class", "has-error");
        }

        if (fldUnit.SelectedIndex == 0)
        {
            chckErr = false;
            dvUnit.Attributes.Add("class", "has-error");
        }

        if (fldClientName.SelectedIndex == 0)
        {
            chckErr = false;
            dvClientName.Attributes.Add("class", "has-error");
        }

        if (fldClientAdd.Text.Trim() == "")
        {
            chckErr = false;
            dvClientAdd.Attributes.Add("class", "has-error");
        }

        if (fldDescription.Text.Trim() == "")
        {
            chckErr = false;
            dvOpportunity.Attributes.Add("class", "has-error");
        }

        if (fldSOW.Text.Trim() == "")
        {
            chckErr = false;
            dvSOW.Attributes.Add("class", "has-error");
        }

        if (fldPM.SelectedIndex == 0)
        {
            chckErr = false;
            dvPM.Attributes.Add("class", "has-error");
        }

        if (fldProjectValue.Text.Trim() == "")
        {
            chckErr = false;
            dvProjectValue.Attributes.Add("class", "has-error");
        }

        if (fldProjectFee.Text.Trim() == "")
        {
            chckErr = false;
            dvProjectFee.Attributes.Add("class", "has-error");
        }

        if (fldStartDate.Text.Trim() == "" || fldEndDate.Text.Trim() == "")
        {
            chckErr = false;
            dvProjectDate.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateOpportunity();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblOpportunityRecord SET "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            //Insert data into Opportunity Go/No-Go phase if page has been submitted
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdInsertProject = new SqlCommand("INSERT INTO tblOpportunityGoNoGo (DescriptionId, ProjectValue, ProjectFees) "
                    + "VALUES ('" + Request.QueryString["Id"] + "', @pfldProjectValue, @pfldProjectFee)", con);

            //Estimated Project Value 
            cmdInsertProject.Parameters.AddWithValue("@pfldProjectValue", fldProjectValue.Text);

            //Estimated Project Fees 
            cmdInsertProject.Parameters.AddWithValue("@pfldProjectFee", fldProjectFee.Text);

            cmdInsertProject.ExecuteNonQuery();

            SqlCommand cmdInsertAssessment = new SqlCommand("INSERT INTO tblAssessment (DescriptionId) "
                    + "VALUES ('" + Request.QueryString["Id"] + "')", con);

            cmdInsertAssessment.ExecuteNonQuery();

            //Add Mohammad Farish Mohd Noor (Commercial / Finance)
            SqlCommand cmdInsertCommittee1 = new SqlCommand("INSERT INTO tblEvaluationCommittee (DescriptionId, CommitteeMember, Role, CreatedBy, DateCreated) "
                    + "VALUES ('" + Request.QueryString["Id"] + "', 'UEB1052', 'Head of Commercial / Opus Client Solutions', '" + Session["UserID"] + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')", con);

            cmdInsertCommittee1.ExecuteNonQuery();

            //Add Choo Tze Wei (BE)
            SqlCommand cmdInsertCommittee2 = new SqlCommand("INSERT INTO tblEvaluationCommittee (DescriptionId, CommitteeMember, Role, CreatedBy, DateCreated) "
                    + "VALUES ('" + Request.QueryString["Id"] + "', '22523', 'Head of Business Excellence', '" + Session["UserID"] + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')", con);

            cmdInsertCommittee2.ExecuteNonQuery();

            con.Close();


            Response.Redirect("OpportunityRecordDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }
    

    protected void updateOpportunity()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblMain
        SqlCommand cmd = new SqlCommand("UPDATE tblMain SET "
                + "OperatingCompany = @pCompany, "
                + "OperatingUnit = @pUnit, "
                + "ClientId = @pClientName, "
                + "Description = @pDescription, "
                + "ProjectManager = @pPM, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE Id = '" + Request.QueryString["Id"] + "'", con);

        //Operating Company
        if (fldCompany.Text != "")
            cmd.Parameters.AddWithValue("@pCompany", fldCompany.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pCompany", DBNull.Value);

        //Operating Unit
        if (fldUnit.Text != "")
            cmd.Parameters.AddWithValue("@pUnit", fldUnit.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pUnit", DBNull.Value);

        //Client Name
        if (fldClientName.SelectedIndex == 1)
        {
            SqlCommand cmdClient = new SqlCommand("INSERT INTO tblClient "
            + "(ClientName) "
            + "VALUES "
            + "(@pNewClientName)", con);

            cmdClient.Parameters.AddWithValue("@pNewClientName", fldNewClientName.Text.Trim());

            cmdClient.ExecuteNonQuery();

            //Latest Client Id
            cmd = new SqlCommand("SELECT TOP 1 Id FROM tblClient ORDER BY Id DESC", con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter daChck1 = new SqlDataAdapter(cmd);
            DataTable dtChck1 = new DataTable();
            daChck1.Fill(dtChck1);

            row = null;
            row = dtChck1.Rows[0];

            cmd.Parameters.AddWithValue("@pClientName", row["Id"].ToString());
        }
        else
        {
            if (fldClientName.Text != "")
                cmd.Parameters.AddWithValue("@pClientName", fldClientName.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@pClientName", DBNull.Value);
        }

        //Opportunity Name
        cmd.Parameters.AddWithValue("@pDescription", fldDescription.Text.Trim());

        //Project Manager
        if (fldPM.Text != "")
            cmd.Parameters.AddWithValue("@pPM", fldPM.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPM", DBNull.Value);
        
        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        //Update into table tblOpportunityRecord
        SqlCommand cmd1 = new SqlCommand("UPDATE tblOpportunityRecord SET "
                + "ClientAddress = @pClientAdd, "
                + "ScopeWork = @pSOW, "
                + "DecisionMaker = @pDecisionMaker, "
                + "Role = @pRole, "
                + "PIC1 = @pPIC1, "
                + "PIC2 = @pPIC2, "
                + "EstProjectValue = @pProjectValue, "
                + "EstProjectFee = @pProjectFee, "
                + "EstStartDate = @pStartDate, "
                + "EstEndDate = @pEndDate, "
                + "MaterializingPercent = @pPercent, "
                + "MaterializingComment = @pComment, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //Client Address
        cmd1.Parameters.AddWithValue("@pClientAdd", fldClientAdd.Text.Trim());

        //Scope of Work
        cmd1.Parameters.AddWithValue("@pSOW", fldSOW.Text.Trim());

        //Decision Maker
        cmd1.Parameters.AddWithValue("@pDecisionMaker", fldDecisionMaker.Text.Trim());

        //Role
        cmd1.Parameters.AddWithValue("@pRole", fldRole.Text.Trim());

        //Person In Charge [1]
        if (fldPIC1.Text != "")
            cmd1.Parameters.AddWithValue("@pPIC1", fldPIC1.SelectedValue);
        else
            cmd1.Parameters.AddWithValue("@pPIC1", DBNull.Value);

        //Person In Charge [2]
        if (fldPIC2.Text != "")
            cmd1.Parameters.AddWithValue("@pPIC2", fldPIC2.SelectedValue);
        else
            cmd1.Parameters.AddWithValue("@pPIC2", DBNull.Value);

        //Estimated Project Value
        cmd1.Parameters.AddWithValue("@pProjectValue", fldProjectValue.Text);

        //Estimated Project Fees
        cmd1.Parameters.AddWithValue("@pProjectFee", fldProjectFee.Text);

        //Estimated Project Start & End Date
        if (fldStartDate.Text != "")
        { cmd1.Parameters.AddWithValue("@pStartDate", Convert.ToDateTime(fldStartDate.Text)); }
        else
        { cmd1.Parameters.AddWithValue("@pStartDate", DBNull.Value); }

        if (fldEndDate.Text != "")
        { cmd1.Parameters.AddWithValue("@pEndDate", Convert.ToDateTime(fldEndDate.Text)); }
        else
        { cmd1.Parameters.AddWithValue("@pEndDate", DBNull.Value); }

        //Chances Project Materializing
        cmd1.Parameters.AddWithValue("@pPercent", fldPercent.Text);

        cmd1.Parameters.AddWithValue("@pComment", fldComment.Text.Trim());

        //Modified By
        cmd1.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd1.ExecuteNonQuery();

        con.Close();
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