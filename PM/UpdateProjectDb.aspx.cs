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

public partial class UpdateProjectDb: System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String queryString = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();
    SqlCommand cmdAdd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (Request.QueryString["Id"] == null)
        {
            dvCode.Visible = false;
        }

        DateTime now = DateTime.Now;

        lblUser.Text = Session["UserName"].ToString();
        lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

        if (!Page.IsPostBack)
        {
            checkRole();
             
            //Hide all upload
            dvUpA1Sec.Visible = true;
            dvVwA1Sec.Visible = false;

            dvUpA2Sec.Visible = true;
            dvVwA2Sec.Visible = false;

            dvUpA3Sec.Visible = true;
            dvVwA3Sec.Visible = false;

            fldNewClientName.Visible = false;

            //Bind dropdownlist
            bindCompany();
            bindUnit();
            bindClientName();

            bindProjectManager();
            bindProjectDirector();
            bindPIC1();
            bindPIC2();
            bindHSERep();

            bindSupportingDoc();

            bindDetails();

            if (fldOldCode.Text == "")
            {
                dvOldCode.Visible = false;
            }

            if (Request.QueryString["mode"] == "1")
            {
                btnListing.Visible = true;
            }
            else
            {
                btnListing.Visible = false;
            }
            
        }
    }

    protected void checkRole()
    {
        qs = "";
        qs = qs + " SELECT        Role  ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         StaffNo = '" + Session["UserID"].ToString() + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
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
        fldClientName.Items.Insert(1, new ListItem("+ Add New Client +", "addNewClient"));
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
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectManager' or Role = 'HeadDivision' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPM.DataSource = GetData(qs);
        fldPM.DataTextField = "StaffName";
        fldPM.DataValueField = "StaffNo";
        fldPM.DataBind();
        fldPM.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindProjectDirector()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        DISTINCT StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadUnit' or Role = 'ProjectManager' or Role = 'HeadDivision' ";
        qs = qs + " ORDER BY      StaffName ";

        fldPD.DataSource = GetData(qs);
        fldPD.DataTextField = "StaffName";
        fldPD.DataValueField = "StaffNo";
        fldPD.DataBind();
        fldPD.Items.Insert(0, new ListItem("-- Please select one --", ""));
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

    protected void bindHSERep()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HSE' ";
        qs = qs + " ORDER BY      StaffName ";

        fldHSERep.DataSource = GetData(qs);
        fldHSERep.DataTextField = "StaffName";
        fldHSERep.DataValueField = "StaffNo";
        fldHSERep.DataBind();
        fldHSERep.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }
    
    
    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnChangeManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangeRequestVODetail.aspx?Id=" + Request.QueryString["Id"]);
    }
    
    protected void bindDetails()
    {
        //Display project details 
        //qs = "";
        //qs = qs + " SELECT              tblProjectRecord.*, tblMain.Code, tblMain.PreProjectCode, tblMain.ProjectCode, tblMain.OldCode ";
        //qs = qs + " FROM                tblProjectRecord ";
        //qs = qs + " INNER JOIN dbo.tblMain ON dbo.tblProjectRecord.DescriptionId = dbo.tblMain.Id ";
        //qs = qs + " WHERE               tblProjectRecord.DescriptionId = '" + Request.QueryString["Id"] + "' ";

        qs = "";
        qs = qs + " SELECT              * ";
        qs = qs + " FROM                vwProjectDBMain ";
        qs = qs + " WHERE               DescriptionId = '" + Request.QueryString["Id"] + "' ";
        

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
            dvInactive.Visible = true;
            dvActive.Visible = false;
        }
        else
        {
            DataRow row = dt.Rows[0];

            dvInactive.Visible = false;
            dvActive.Visible = true;

            //BtnSubmit
            lblBtnSubmit.Text = row["BtnSubmit"].ToString();

            //Promotional Code
            if (row["Code"].ToString() == "")
            {
                dvCode.Visible = false;
            }
            else
            {
                lblCode.Text = row["Code"].ToString();
            }

            //Operating Company
            fldCompany.Text = row["OperatingCompany"].ToString();
            lblCompany.Text = row["OperatingCompany"].ToString();

            //Operating Unit
            fldUnit.Text = row["OperatingUnit"].ToString();

            //Client Name
            fldClientName.Text = row["ClientId"].ToString();
            lblClientName.Text = row["ClientName"].ToString();

            //Client Address
            fldClientAdd.Text = row["ClientAddress"].ToString();

            //Opportunity Name
            fldDescription.Text = row["Description"].ToString();

            //Scope of Work
            fldSOW.Text = row["ScopeWork"].ToString();

            //Project Manager
            fldPM.Text = row["ProjectManager"].ToString();

            //Project Director
            fldPD.Text = row["ProjectDirector"].ToString();

            //Person In Charge [1]
            fldPIC1.Text = row["PIC1"].ToString();

            //Person In Charge [2]
            fldPIC2.Text = row["PIC2"].ToString();

            //HSE Liaison Representative
            fldHSERep.Text = row["HSERep"].ToString();

            //Estimated Project Value
            object dta = row["ProjectValue"];
            if (dta == DBNull.Value)
            { }
            else
            { fldProjectValue.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectValue"].ToString())); }

            lblProjectValue.Text = row["CostEstimated"].ToString();

            //Estimated Project Fees
            object dtb = row["ProjectFee"];
            if (dtb == DBNull.Value)
            { }
            else
            { fldProjectFee.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())); }

            lblProjectFee.Text = row["Fees"].ToString();

            //Estimated Project Start & End Date
            object dt1 = row["StartDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldStartDate.Text = Convert.ToDateTime(row["StartDate"].ToString()).ToString("dd-MMM-yyyy"); }

            object dt2 = row["EndDate"];
            if (dt2 == DBNull.Value)
            { }
            else
            { fldEndDate.Text = Convert.ToDateTime(row["EndDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Project Margin
            fldPercent.Text = row["ProjectMargin"].ToString();

            //Contract Period
            fldContractPeriod.Text = row["ContractPeriod"].ToString();
            
            //--------------------------------------- LOI ---------------------------------------
            //LOI
            object fn2 = row["LOI"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                dvUpA3Sec.Visible = true;
                dvVwA3Sec.Visible = false;
            }
            else
            {
                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;

                lblURLA3.Text = row["LOI"].ToString();
                hidURLA3.Value = "http://pec.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOI/" + row["LOI"].ToString() + "";
            }

            //--------------------------------------- Contract / LOA ---------------------------------------
            //Contract / LOA
            object fn = row["ContractLOA"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["ContractLOA"].ToString();
                hidURLA1.Value = "http://pec.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOA/" + row["ContractLOA"].ToString() + "";
            }

            //--------------------------------------- Letter of Acceptance ---------------------------------------
            //Letter of Acceptance
            object fn1 = row["LetterAcceptance"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["LetterAcceptance"].ToString();
                hidURLA2.Value = "http://pec.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectAcceptance/" + row["LetterAcceptance"].ToString() + "";
            }

            //...................................Project DB Approval...................................  
            //.................................................Approver.................................................
            //Approver - Name
            lblProjDBApprover.Text = row["BMApprovalName"].ToString() + "  &  " + row["COOApprovalName"].ToString();

            //Approver - Date Approved 
            object dtDA = row["BMApprovalDt"];
            object dtDB = row["COOApprovalDt"];
            if (dtDA != DBNull.Value && dtDB != DBNull.Value)
            {
                lblProjDB_ApprovedDate.Text = Convert.ToDateTime(row["BMApprovalDt"].ToString()).ToString("dd-MMM-yyyy") + "  &  " + Convert.ToDateTime(row["COOApprovalDt"].ToString()).ToString("dd-MMM-yyyy");
            }
            else
            {
                lblProjDB_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblProjDB_ApprovedStatus.Text = row["DALAppStatus"].ToString(); }
            else
            { lblProjDB_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            lblProjDB_ApprovedComment.Text = "-";

            //Approver - Remarks
            lblOldProjDBRemarks.Text = row["OldDALRemarks"].ToString();

            //...................................end of Project DB Approval...................................

            //Regular Code
            fldProjectCode.Text = row["ProjectCode"].ToString();

            //Regular Code (Old)
            fldOldCode.Text = row["OldCode"].ToString();
                        
            //btnUpdate & btnSubmit
            object dt8 = row["BtnSubmit"];
            if (dt8 == DBNull.Value)
            {
                fldA1Upload.Enabled = true;
                btnCancelA1.Enabled = true;
                btnUpA1.Enabled = true;
                btnDeleteA1.Visible = true;

                fldA2Upload.Enabled = true;
                btnCancelA2.Enabled = true;
                btnUpA2.Enabled = true;
                btnDeleteA2.Visible = true;

                fldA3Upload.Enabled = true;
                btnCancelA3.Enabled = true;
                btnUpA3.Enabled = true;
                btnDeleteA3.Visible = true;

                btnSupportingDoc.Visible = true;

                if (gvSupportingDoc.Rows.Count != 0)
                {
                    gvSupportingDoc.HeaderRow.Cells[2].Visible = true;

                    foreach (GridViewRow r in gvSupportingDoc.Rows)
                    {
                        r.Cells[2].Visible = true;
                    }
                }
                
                btnUpdate.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;
                btnDeleteA1.Visible = false;

                fldA2Upload.Enabled = false;
                btnCancelA2.Enabled = false;
                btnUpA2.Enabled = false;
                btnDeleteA2.Visible = false;

                fldA3Upload.Enabled = false;
                btnCancelA3.Enabled = false;
                btnUpA3.Enabled = false;
                btnDeleteA3.Visible = false;

                btnSupportingDoc.Visible = false;

                if (gvSupportingDoc.Rows.Count != 0)
                {
                    gvSupportingDoc.HeaderRow.Cells[2].Visible = false;

                    foreach (GridViewRow r in gvSupportingDoc.Rows)
                    {
                        r.Cells[2].Visible = false;
                    }
                }

                if (gvSupportingDoc.Rows.Count == 0)
                {
                    lblNone.Visible = true;
                }

                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;

            }
        }

    }

       
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvCompany.Attributes.Add("class", null);
        dvClientName.Attributes.Add("class", null);
        dvPM.Attributes.Add("class", null);

        if (fldCompany.SelectedIndex == 0)
        {
            chckErr = false;
            dvCompany.Attributes.Add("class", "has-error");
        }

        if (fldClientName.SelectedIndex == 0)
        {
            chckErr = false;
            dvClientName.Attributes.Add("class", "has-error");
        }

        if (fldPM.SelectedIndex == 0)
        {
            chckErr = false;
            dvPM.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateProject();

            //Update phase in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain1 = new SqlCommand("UPDATE tblMain SET "
                    + "Phase = 'Migration In Progress', "
                    + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                    + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain1.ExecuteNonQuery();

            //Response.Redirect("RegisterProjectDetail.aspx?Id=" + Request.QueryString["Id"]);
            Response.Redirect("ProjectListing.aspx");
        }
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
        dvPD.Attributes.Add("class", null);
        dvProjectValue.Attributes.Add("class", null);
        dvProjectFee.Attributes.Add("class", null);
        dvProjectDate.Attributes.Add("class", null);
        dvUpA1Sec.Attributes.Add("class", null);

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

        if (fldPD.SelectedIndex == 0)
        {
            chckErr = false;
            dvPD.Attributes.Add("class", "has-error");
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

        //LOA
        if (fldA1Upload.FileName == "" && lblURLA1.Text == "")
        {
            chckErr = false;
            dvUpA1Sec.Attributes.Add("class", "has-error");
        }
        

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            updateProject();

            //Update phase in table tblMain
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain1 = new SqlCommand("UPDATE tblMain SET "
                    + "Phase = 'Register New Project', "
                    + "ModifyBy = '" + Session["UserID"].ToString() + "', "
                    + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain1.ExecuteNonQuery();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain2 = new SqlCommand("UPDATE tblProjectRecord SET "
                    + "SubmissionStatus = 'Project', "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain2.ExecuteNonQuery();

            con.Close();

            emailPM();

            qs1 = "";
            qs1 = qs1 + " SELECT        enddate, getdate(), case when enddate > getdate() then 'notify finance' when enddate<getdate() then 'no notify' end as comparedt ";
            qs1 = qs1 + " FROM          vwProjectDBMain ";
            qs1 = qs1 + " WHERE         DescriptionId = '" + Request.QueryString["ID"] + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(qs1, con);
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
                DataRow row1 = dt.Rows[0];

                lblCompareDate.Text = row1["comparedt"].ToString();
                
                if (lblCompareDate.Text == "notify finance")
                {
                    emailFinance();
                }
            }



            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            //Response.Redirect("RegisterProjectDetail.aspx?Id=" + Request.QueryString["Id"]);
            Response.Redirect("ProjectListing.aspx");
        }
    }
        

    protected void updateProject()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblProjectRecord
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectRecord SET "
                + "OperatingCompany = @pCompany, "
                + "OperatingUnit = @pUnit, "
                + "ClientId = @pClientName, "
                + "ClientAddress = @pClientAdd, "
                + "Description = @pDescription, "
                + "ScopeWork = @pSOW, "
                + "ProjectManager = @pPM, "
                + "ProjectDirector = @pPD, "
                + "PIC1 = @pPIC1, "
                + "PIC2 = @pPIC2, "
                + "HSERep = @pHSERep, "
                + "ProjectValue = @pProjectValue, "
                + "ProjectFee = @pProjectFee, "
                + "StartDate = @pStartDate, "
                + "EndDate = @pEndDate, "
                + "ProjectMargin = @pPercent, "
                + "ContractPeriod = @pContractPeriod, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

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
            cmdAdd = new SqlCommand("SELECT TOP 1 Id FROM tblClient ORDER BY Id DESC", con);
            cmdAdd.CommandTimeout = 0;
            SqlDataAdapter daChck1 = new SqlDataAdapter(cmdAdd);
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

        //Client Address
        cmd.Parameters.AddWithValue("@pClientAdd", fldClientAdd.Text.Trim());

        //Project Name
        cmd.Parameters.AddWithValue("@pDescription", fldDescription.Text.Trim());

        //Scope of Work
        cmd.Parameters.AddWithValue("@pSOW", fldSOW.Text.Trim());

        //Project Manager
        if (fldPM.Text != "")
            cmd.Parameters.AddWithValue("@pPM", fldPM.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPM", DBNull.Value);

        //Project Director
        if (fldPD.Text != "")
            cmd.Parameters.AddWithValue("@pPD", fldPD.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPD", DBNull.Value);

        //Person In Charge [1]
        if (fldPIC1.Text != "")
            cmd.Parameters.AddWithValue("@pPIC1", fldPIC1.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPIC1", DBNull.Value);

        //Person In Charge [2]
        if (fldPIC2.Text != "")
            cmd.Parameters.AddWithValue("@pPIC2", fldPIC2.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pPIC2", DBNull.Value);

        //HSE Liaison Representative
        if (fldHSERep.Text != "")
            cmd.Parameters.AddWithValue("@pHSERep", fldHSERep.SelectedValue);
        else
            cmd.Parameters.AddWithValue("@pHSERep", DBNull.Value);

        //Project Value
        cmd.Parameters.AddWithValue("@pProjectValue", fldProjectValue.Text);

        //Project Fees
        cmd.Parameters.AddWithValue("@pProjectFee", fldProjectFee.Text);

        //Project Start & End Date
        if (fldStartDate.Text != "")
        { cmd.Parameters.AddWithValue("@pStartDate", Convert.ToDateTime(fldStartDate.Text)); }
        else
        { cmd.Parameters.AddWithValue("@pStartDate", DBNull.Value); }

        if (fldEndDate.Text != "")
        { cmd.Parameters.AddWithValue("@pEndDate", Convert.ToDateTime(fldEndDate.Text)); }
        else
        { cmd.Parameters.AddWithValue("@pEndDate", DBNull.Value); }

        //Project Margin
        cmd.Parameters.AddWithValue("@pPercent", fldPercent.Text);

        //Contract Period
        cmd.Parameters.AddWithValue("@pContractPeriod", fldContractPeriod.Text);

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();       

        //Update client in table tblMain
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
                + "tblMain.ClientId = tblProjectRecord.ClientId, "
                + "tblMain.ProjectManager = tblProjectRecord.ProjectManager "
                + "FROM tblProjectRecord, tblMain "
                + "WHERE tblProjectRecord.DescriptionId = tblMain.Id ", con);

        cmdMain.ExecuteNonQuery();

    }

    protected void emailPM()
    {
        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, tblProjectRecord.PIC1, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
        qs = qs + "               StaffLogin_1.StaffName AS PICName, StaffLogin_1.EmailId AS PICEmail, ";
        qs = qs + "               StaffLogin_2.StaffName AS PDName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.PIC1 = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_2 ON tblProjectRecord.ProjectDirector = StaffLogin_2.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

        //Response.Write(qs);

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

        MailMessage objeto_mail = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));
        //objeto_mail.To.Cc(new MailAddress(row["PICEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));
        //objeto_mail.Bcc.Add(new MailAddress("shafiqhafiz@opusbhd.com"));

        objeto_mail.Subject = "Project Database Migration Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#E1EBF4 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "This project has been successfully migrated from Project Database to PEC.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Project Director : </B>" + row["PDName"].ToString() + "<BR><BR>"
                            + "<B>Project Value : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectValue"].ToString())) + "<BR><BR>"
                            + "<B>Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())) + "<BR><BR><BR>"


                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailFinance()
    {
                
        //Email notification to Finance Team & cc PM
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblProjectRecord.ProjectDirector, tblProjectRecord.ProjectValue, tblProjectRecord.ProjectFee, tblProjectRecord.DALApproverLevel, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
        qs = qs + "               StaffLogin_1.StaffName AS PDName ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblProjectRecord ON tblMain.Id = tblProjectRecord.DescriptionId ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               LEFT OUTER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               LEFT OUTER JOIN StaffLogin AS StaffLogin_1 ON tblProjectRecord.ProjectDirector = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

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

        MailMessage objeto_mail = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        //client.Host = "smtp2.edgenta.com";
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //Finance Team
        qsCommittee = "";
        qsCommittee = qsCommittee + " SELECT        StaffName, EmailId As FinanceEmail ";
        qsCommittee = qsCommittee + " FROM          StaffLogin ";
        qsCommittee = qsCommittee + " WHERE         Role = 'FINANCE' ";
        qsCommittee = qsCommittee + " ORDER BY      StaffName ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd1 = new SqlCommand(qsCommittee, con);
        cmd1.CommandTimeout = 0;
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        { }
        else
        {
            foreach (DataRow row1 in dt1.Rows)
            {
                //objeto_mail.To.Add(new MailAddress(row1["FinanceEmail"].ToString()));
            }
        }

        //objeto_mail.CC.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));
        //objeto_mail.Bcc.Add(new MailAddress("shafiqhafiz@opusbhd.com"));

        objeto_mail.Subject = "New Project Code Request Notification";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi Finance,<BR><BR><BR>"

                            + "FYI, request for the following project has been approved.<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Project Director : </B>" + row["PDName"].ToString() + "<BR><BR>"
                            + "<B>Project Fees : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["ProjectFee"].ToString())) + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/CreateProjectDbCode.aspx?ID=" + row["Id"].ToString() + ">link</A> to create the project code.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------

        //Insert data into Project Initiation phase if request is approved
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdInsertProject = new SqlCommand("INSERT INTO tblProjectInitiation (DescriptionId, BoardRequired) "
                + "VALUES ('" + Request.QueryString["Id"] + "', 'No')", con);
                
        cmdInsertProject.ExecuteNonQuery();

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

    protected void btnUpA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ProjectLOA";

        //Check year folder created
        if (Directory.Exists(Server.MapPath(pathfolder)) == false)
        {
            Directory.CreateDirectory(Server.MapPath(pathfolder));
        }

        //Update path to folder assigned
        pathfolder = pathfolder + "/";

        //Upload file
        try
        {
            fldA1Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProjectRecord SET ContractLOA = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;
                UpA1.Update();
                hidURLA1.Value = pathfolder + filenameStr;
                lblURLA1.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectRecord SET ContractLOA = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOA/" + lblURLA1.Text + "";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        hidURLA1.Value = "";
        dvUpA1Sec.Visible = true;
        dvVwA1Sec.Visible = false;
        UpA1.Update();
    }

    protected void btnViewA1_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        String pathfolder = "Upload/";
        String filenameStr = fldA2Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ProjectAcceptance";

        //Check year folder created
        if (Directory.Exists(Server.MapPath(pathfolder)) == false)
        {
            Directory.CreateDirectory(Server.MapPath(pathfolder));
        }

        //Update path to folder assigned
        pathfolder = pathfolder + "/";

        //Upload file
        try
        {
            fldA2Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProjectRecord SET LetterAcceptance = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;
                UpA2.Update();
                hidURLA2.Value = pathfolder + filenameStr;
                lblURLA2.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectRecord SET LetterAcceptance = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A2");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/ProjectAcceptance/" + lblURLA2.Text + "";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        hidURLA2.Value = "";
        dvUpA2Sec.Visible = true;
        dvVwA2Sec.Visible = false;
        UpA2.Update();
    }

    protected void btnViewA2_Click(object sender, EventArgs e)
    {
        //Letter of Acceptance
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA3_Click(object sender, EventArgs e)
    {
        //LOI
        String pathfolder = "Upload/";
        String filenameStr = fldA3Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/ProjectLOI";

        //Check year folder created
        if (Directory.Exists(Server.MapPath(pathfolder)) == false)
        {
            Directory.CreateDirectory(Server.MapPath(pathfolder));
        }

        //Update path to folder assigned
        pathfolder = pathfolder + "/";

        //Upload file
        try
        {
            fldA3Upload.PostedFile.SaveAs(Server.MapPath(pathfolder) + filenameStr);

            //Insert into table
            using (SqlConnection conn_a = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString))
            {
                //Update table
                qs = "";
                qs = qs + "UPDATE  tblProjectRecord SET LOI = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

                using (SqlCommand cmda = new SqlCommand(qs, conn_a))
                {
                    cmda.Parameters.AddWithValue("@patt_filename", filenameStr);

                    conn_a.Open();
                    cmda.ExecuteNonQuery();
                    conn_a.Close();
                }

                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;
                UpA3.Update();
                hidURLA3.Value = pathfolder + filenameStr;
                lblURLA3.Text = filenameStr;
            }
        }
        catch (Exception ex)
        {
            //Error cannot upload
        }
    }

    protected void btnDeleteA3_Click(object sender, EventArgs e)
    {
        //LOI
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProjectRecord SET LOI = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A3");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["ID"] + "/ProjectLOI/" + lblURLA3.Text + "";

        if (System.IO.File.Exists(pathString))
        {
            // Use a try block to catch IOExceptions, to
            // handle the case of the file already being
            // opened by another process.
            //try
            //{
            System.IO.File.Delete(pathString);

            //}
            //catch (System.IO.IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        hidURLA3.Value = "";
        dvUpA3Sec.Visible = true;
        dvVwA3Sec.Visible = false;
        UpA3.Update();
    }

    protected void btnViewA3_Click(object sender, EventArgs e)
    {
        //LOI
        Response.Write("<script> window.open( '" + hidURLA3.Value.ToString() + "','_blank' ); </script>");
    }

    private void bindSupportingDoc()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Supporting Document' "
            + "ORDER BY       Id DESC ";

        gvSupportingDoc.DataSource = GetData(str);
        gvSupportingDoc.DataBind();

        for (int i = 0; i < gvSupportingDoc.Rows.Count; i++)
        {
            GridViewRow row = gvSupportingDoc.Rows[i];
            
            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }

    }
    
    protected void DeleteSupportingDoc(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindSupportingDoc();
    }

    protected void btnSaveE_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName.Attributes.Add("class", null);

        if (fldFileName.FileName == "")
        {
            chckErr = false;
            dvFileName.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblProjectDocument
            queryString = "";
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (Category, DescriptionId, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Supporting Document', @pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Supporting Document
            uploadSupportingDoc();

            Response.Redirect("RegisterProjectDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadSupportingDoc()
    {
        if (fldFileName.FileName != "")
        {
            //Update Supporting Document
            SqlCommand cmdFile = new SqlCommand("UPDATE tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Supporting Document' "
                    + "AND DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;

            //---------------------- upload file & save file name ------------------------------------------------------
            //Upload file into directory
            HttpFileCollection hfc = Request.Files;
            string Msg = null;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    string pathString = @"d:/PEC/PM/Upload/" + Request.QueryString["Id"] + "/SupportingDoc/";

                    if (!System.IO.File.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                        if (System.IO.Path.GetExtension(fldFileName.PostedFile.FileName) == ".exe")
                        {
                            //lblError.Text = "No .exe files are allowed.";
                        }
                        else
                        {
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }
                    }
                    else
                    {
                        if (System.IO.Path.GetExtension(fldFileName.PostedFile.FileName) == ".exe")
                        {
                            //lblError.Text = "No .exe files are allowed.";
                        }
                        else
                        {
                            hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                        }
                    }
                }
            }

            //Insert into table
            foreach (HttpPostedFile postedFile in fldFileName.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);

                using (Stream fs = postedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        //File Name
                        cmdFile.Parameters.AddWithValue("@pFileName", filename);
                    }
                }
            }
            //---------------------- end of upload file & save file name -----------------------------------------------

            cmdFile.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void btnCloseE_Click(object sender, EventArgs e)
    {
    }
}