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

public partial class NewOpportunityRecord : System.Web.UI.Page
{
    DataRow row = null;
    DataRow rowId = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();
    SqlCommand cmdClientId = new SqlCommand();

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
            fldNewClientName.Visible = false;

            //Bind dropdownlist
            bindCompany();
            bindUnit();
            bindClientName();            
            bindProjectManager();
            bindPIC1();
            bindPIC2();
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
        fldClientName.Items.Insert(1, new ListItem("+ Add new client +", "addNewClient"));
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

    protected void btnUpdate_Click(object sender, EventArgs e)
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
            insertOpportunity();

            DateTime now = DateTime.Now;

            //Capture latest Id from tblMain
            queryString = "";
            queryString = queryString + " SELECT        Id  ";
            queryString = queryString + " FROM          tblMain ";
            queryString = queryString + " ORDER BY      Id DESC ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;
            SqlDataAdapter daChck = new SqlDataAdapter(cmd);
            DataTable dtChck = new DataTable();
            daChck.Fill(dtChck);
            con.Close();

            row = null;
            row = dtChck.Rows[0];

            //Insert into table tblOpportunityGoNoGo
            queryString = "";
            queryString = queryString + " INSERT INTO   tblOpportunityGoNoGo ";
            queryString = queryString + "               (DescriptionId, ProjectValue, ProjectFees, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pProjectValue, @pProjectFee, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", row["Id"]);

            //Estimated Project Value
            cmd.Parameters.AddWithValue("@pProjectValue", fldProjectValue.Text);

            //Estimated Project Fees
            cmd.Parameters.AddWithValue("@pProjectFee", fldProjectFee.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //Insert into table tblAssessment
            queryString = "";
            queryString = queryString + " INSERT INTO   tblAssessment ";
            queryString = queryString + "               (DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", row["Id"]);

            cmd.ExecuteNonQuery();
            con.Close();


            Response.Redirect("ProjectListing.aspx");
        }
    }

    protected void insertOpportunity()
    {        
        DateTime now = DateTime.Now;

        //Insert into table tblMain
        qs = "";
        qs = qs + " INSERT INTO   tblMain ";
        qs = qs + "               (OperatingCompany, OperatingUnit, ClientId, Description, ProjectManager, Phase, Status, Category, CreatedBy, DateCreated) ";
        qs = qs + " VALUES        (@pCompany, @pUnit, @pClientName, @pDescription, @pPM, 'Opportunity Record', 'Active', 'Opportunity', @pCreatedBy, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

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
            cmdClientId = new SqlCommand("SELECT TOP 1 Id FROM tblClient ORDER BY Id DESC", con);
            cmdClientId.CommandTimeout = 0;
            SqlDataAdapter daChck1 = new SqlDataAdapter(cmdClientId);
            DataTable dtChck1 = new DataTable();
            daChck1.Fill(dtChck1);

            rowId = null;
            rowId = dtChck1.Rows[0];

            cmd.Parameters.AddWithValue("@pClientName", rowId["Id"].ToString());
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
        
        //Created By
        cmd.Parameters.AddWithValue("@pCreatedBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        //Capture latest Description Id from database.
        qsId = "";
        qsId = qsId + " SELECT        TOP 1 Id  ";
        qsId = qsId + " FROM          tblMain ";
        qsId = qsId + " ORDER BY      Id DESC ";
        
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmdId = new SqlCommand(qsId, con);
        cmdId.CommandTimeout = 0;
        SqlDataAdapter daId = new SqlDataAdapter(cmdId);
        DataTable dtId = new DataTable();
        daId.Fill(dtId);
        con.Close();

        row = null;
        row = dtId.Rows[0];
        
        //Insert into table tblOpportunityRecord
        qs1 = "";
        qs1 = qs1 + " INSERT INTO   tblOpportunityRecord ";
        qs1 = qs1 + "               (DescriptionId, ClientAddress, ScopeWork, DecisionMaker, Role, PIC1, PIC2, EstProjectValue, EstProjectFee, EstStartDate, EstEndDate, MaterializingPercent, MaterializingComment, CreatedBy, DateCreated) ";
        qs1 = qs1 + " VALUES        (@pDescriptionId, @pClientAdd, @pSOW, @pDecisionMaker, @pRole, @pPIC1, @pPIC2, @pProjectValue, @pProjectFee, @pStartDate, @pEndDate, @pPercent, @pComment, @pCreatedBy, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd1 = new SqlCommand(qs1, con);
        cmd1.CommandTimeout = 0;

        //Latest Description Id - from tblMain
        cmd1.Parameters.AddWithValue("@pDescriptionId", row["Id"].ToString());

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

        //Created By
        cmd1.Parameters.AddWithValue("@pCreatedBy", Session["UserID"].ToString());

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