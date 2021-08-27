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


public partial class PM_UpdateChangeRequestVO : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qs2 = "";
    String qs3 = "";
    String qsId = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();

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
            bindCRToFrom();
            bindVariationType();
            bindClientApproval();
            bindGrantingVO();
            bindGrantingEOT();
            bindEOTFromClient();

            bindIncreaseFee();
            bindContractAddendum();

            bindVOLetter();
            bindSupportingDoc();

            bindDetails();

            //DAL Approval - 3.8 (Client)
            bindDALApprover();
            bindDALApprover_HOD();
            bindDALApprover_COO();

            //DAL Approval - 3.9 (SubCon - VO)
            bindDALApprover_VO();
            bindDALApprover_HOD_VO();
            bindDALApprover_COO_VO();

            //DAL Approval - 3.13 (SubCon - EOT)
            bindDALApprover_HOD_EOT();
            bindDALApprover_COO_EOT();

            if (fldChangeRequestToFrom.Text == "Client")
            {
                dvDALApproval.Visible = true;
                dvDALApproval_EOT.Visible = false;
                dvDALApproval_VO.Visible = false;
            }
            else if (fldChangeRequestToFrom.Text == "Sub-Contractor")
            {
                if (fldVariationType.Text == "Extension of Time (EOT)")
                {
                    dvDALApproval.Visible = false;
                    dvDALApproval_EOT.Visible = true;
                    dvDALApproval_VO.Visible = false;
                }
                else if (fldVariationType.Text == "Variation Order (VO)")
                {
                    dvDALApproval.Visible = false;
                    dvDALApproval_EOT.Visible = false;
                    dvDALApproval_VO.Visible = true;
                }
            }
        }
    }


    protected void bindDALApprover()
    {
        // Bind data to the dropdownlist control.                
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'MDCEO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover.DataSource = GetData(qs);
        fldDALApprover.DataTextField = "StaffName";
        fldDALApprover.DataValueField = "StaffNo";
        fldDALApprover.DataBind();
    }

    protected void bindDALApprover_HOD()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadDivision' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_HOD.DataSource = GetData(qs);
        fldDALApprover_HOD.DataTextField = "StaffName";
        fldDALApprover_HOD.DataValueField = "StaffNo";
        fldDALApprover_HOD.DataBind();
    }

    protected void bindDALApprover_COO()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'COO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_COO.DataSource = GetData(qs);
        fldDALApprover_COO.DataTextField = "StaffName";
        fldDALApprover_COO.DataValueField = "StaffNo";
        fldDALApprover_COO.DataBind();
    }

    protected void bindDALApprover_VO()
    {
        // Bind data to the dropdownlist control.                
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'MDCEO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_VO.DataSource = GetData(qs);
        fldDALApprover_VO.DataTextField = "StaffName";
        fldDALApprover_VO.DataValueField = "StaffNo";
        fldDALApprover_VO.DataBind();
    }

    protected void bindDALApprover_HOD_VO()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadDivision' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_HOD_VO.DataSource = GetData(qs);
        fldDALApprover_HOD_VO.DataTextField = "StaffName";
        fldDALApprover_HOD_VO.DataValueField = "StaffNo";
        fldDALApprover_HOD_VO.DataBind();
    }

    protected void bindDALApprover_COO_VO()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'COO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_COO_VO.DataSource = GetData(qs);
        fldDALApprover_COO_VO.DataTextField = "StaffName";
        fldDALApprover_COO_VO.DataValueField = "StaffNo";
        fldDALApprover_COO_VO.DataBind();
    }

    protected void bindDALApprover_HOD_EOT()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'HeadDivision' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_HOD_EOT.DataSource = GetData(qs);
        fldDALApprover_HOD_EOT.DataTextField = "StaffName";
        fldDALApprover_HOD_EOT.DataValueField = "StaffNo";
        fldDALApprover_HOD_EOT.DataBind();
    }

    protected void bindDALApprover_COO_EOT()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'COO' ";
        qs = qs + " ORDER BY      StaffName ";

        fldDALApprover_COO_EOT.DataSource = GetData(qs);
        fldDALApprover_COO_EOT.DataTextField = "StaffName";
        fldDALApprover_COO_EOT.DataValueField = "StaffNo";
        fldDALApprover_COO_EOT.DataBind();
    }

    protected void bindCRToFrom()
    {
        fldChangeRequestToFrom.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldChangeRequestToFrom.Items.Insert(1, new ListItem("Client", "Client"));
        fldChangeRequestToFrom.Items.Insert(2, new ListItem("Internal", "Internal"));
        fldChangeRequestToFrom.Items.Insert(2, new ListItem("Sub-Contractor", "Sub-Contractor"));
    }

    protected void bindVariationType()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        ChangeRequestVOType ";
        qs = qs + " FROM          tblChangeRequestVOType ";
        qs = qs + " ORDER BY      ChangeRequestVOType ";

        fldVariationType.DataSource = GetData(qs);
        fldVariationType.DataTextField = "ChangeRequestVOType";
        fldVariationType.DataValueField = "ChangeRequestVOType";
        fldVariationType.DataBind();
        fldVariationType.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindClientApproval()
    {
        fldClientApproval.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldClientApproval.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldClientApproval.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindGrantingVO()
    {
        fldGrantingVO.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldGrantingVO.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldGrantingVO.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindGrantingEOT()
    {
        fldGrantingEOT.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldGrantingEOT.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldGrantingEOT.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindEOTFromClient()
    {
        fldEOTFromClient.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldEOTFromClient.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldEOTFromClient.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindIncreaseFee()
    {
        fldIncreaseFee.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldIncreaseFee.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldIncreaseFee.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindContractAddendum()
    {
        fldContractAddendum.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldContractAddendum.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldContractAddendum.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblChangeRequestVO.*, tblMain.Code, tblMain.ProjectCode, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblChangeRequestVO ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblChangeRequestVO.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblChangeRequestVO.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " INNER JOIN          tblMain ON tblChangeRequestVO.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row = dt1.Rows[0];

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();

            //Change Request To / From
            fldChangeRequestToFrom.Text = row["ChangeRequestToFrom"].ToString();
            if (fldChangeRequestToFrom.Text == "Client")
            {
                dvContractNo.Visible = false;
                dvEOTFromClient.Visible = false;
                dvLADImpact.Visible = false;
                lblfldCostImpact.InnerText = "Cost Impact Due To Changes To Client";
                lblSupportingDoc.Text = "(e.g. Management Paper, Board Paper, Letter of Intent, Acceptance Letter, any documentation related to the changes, etc.)";
            }
            else if (fldChangeRequestToFrom.Text == "Sub-Contractor")
            {
                lblfldCostImpact.InnerText = "Cost Impact Due To Changes ";
                lblSupportingDoc.Text = "(e.g. Management Paper, Board Paper, Letter of Intent, Acceptance Letter, any documentation related to the changes, etc.)";
            }
            else if (fldChangeRequestToFrom.Text == "Internal")
            {
                dvContractNo.Visible = false;
                dvEOTFromClient.Visible = false;
                dvGrantingVO.Visible = false;
                dvGrantingEOT.Visible = false;

                lblfldCostImpact.Visible = false;
                lblRM.Visible = false;
                fldCostImpact.Visible = false;

                dvLADImpact.Visible = false;
                lblSupportingDoc.Text = "(e.g. Management Paper, Board Paper, Letter of Intent, Acceptance Letter, any documentation related to the changes, etc.)";
            }

            //Title
            fldTitle.Text = row["Title"].ToString();

            //Contract No.
            fldContractNo.Text = row["ContractNo"].ToString();

            //Type Of Changes 
            fldVariationType.Text = row["VariationType"].ToString();

            //Has Client Approved The Changes?
            fldClientApproval.Text = row["ClientApproval"].ToString();

            //Reason For Changes 
            fldReason.Text = row["Reason"].ToString();

            //Cost Impact Due To Changes 
            object dta = row["CostImpact"];
            if (dta == DBNull.Value)
            { }
            else
            { fldCostImpact.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())); }

            //Schedule Impact Due To Changes 
            fldScheduleImpact.Text = row["ScheduleImpact"].ToString();

            //Cumulative LAD Impact
            object dta1 = row["LADImpact"];
            if (dta1 == DBNull.Value)
            { }
            else
            { fldLADImpact.Text = String.Format("{0:0,0.00}", Convert.ToDouble(row["LADImpact"].ToString())); }

            //Granting VO?
            fldGrantingVO.Text = row["GrantingVO"].ToString();
            if (fldGrantingVO.Text == "Yes")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Client")
                {
                    dvIncreaseFee.Visible = true;
                    dvContractAddendum.Visible = true;
                    dvVOLetter.Visible = true;
                    dvVOFee.Visible = true;
                    
                }
            }

            fldIncreaseFee.Text = row["IncreaseFee"].ToString();
            fldContractAddendum.Text = row["ContractAddendum"].ToString();
            fldVOFee.Text = row["VOFee"].ToString();

            //Granting EOT?
            fldGrantingEOT.Text = row["GrantingEOT"].ToString();

            //Is This A Back-To-Back Changes From Client?
            fldEOTFromClient.Text = row["EOTFromClient"].ToString();

            if (row["VariationType"].ToString() == "Variation Order (VO)")
            {
                fldGrantingVO.Visible = true;
                lblNA.Visible = false;

                fldGrantingEOT.Visible = false;
                lblNA1.Visible = true;

                fldEOTFromClient.Visible = true;
                lblNA2.Visible = false;
            }
            else if (row["VariationType"].ToString() == "Extension of Time (EOT)")
            {
                fldGrantingVO.Visible = false;
                lblNA.Visible = true;

                fldGrantingEOT.Visible = true;
                lblNA1.Visible = false;

                fldEOTFromClient.Visible = true;
                lblNA2.Visible = false;
            }
            else if (row["VariationType"].ToString() == "Others")
            {
                fldGrantingVO.Visible = false;
                lblNA.Visible = true;

                fldGrantingEOT.Visible = false;
                lblNA1.Visible = true;

                fldEOTFromClient.Visible = false;
                lblNA2.Visible = true;
            }

            if (fldVariationType.SelectedValue == "Extension of Time (EOT)")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
                {
                    dvGrantingEOT.Visible = true;
                    dvEOTFromClient.Visible = true;
                }
            }
            else if (fldVariationType.SelectedValue == "Variation Order (VO)")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
                {
                    dvGrantingEOT.Visible = false;
                    dvEOTFromClient.Visible = true;
                }
            }
            else if (fldVariationType.SelectedValue == "Others")
            {
                if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
                {
                    dvGrantingEOT.Visible = false;
                    dvEOTFromClient.Visible = false;
                }
            }

            if (fldChangeRequestToFrom.SelectedValue == "Client")
            {
                dvDALApproval.Visible = true;
            }
            else
            {
                dvDALApproval.Visible = false;
            }

            //...................................DAL Approval 3.8...................................  
            //.................................................Approver.................................................
            //Approver - Date Approved 
            object dtDA1 = row["DALAppDate"];
            object dtDNA1 = row["DALNotAppDate"];
            if (dtDA1 != DBNull.Value)
            {
                lblDAL_ApprovedDate.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNA1 != DBNull.Value)
            {
                lblDAL_ApprovedDate.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblDAL_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblDAL_ApprovedStatus.Text = row["DALAppStatus"].ToString(); }
            else
            { lblDAL_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["DALAppComment"].ToString() != "")
            { lblDAL_ApprovedComment.Text = row["DALAppComment"].ToString(); }
            else
            { lblDAL_ApprovedComment.Text = "-"; }

            //...................................end of DAL Approval 3.8...................................

            //...................................DAL Approval 3.9...................................  
            //.................................................Approver.................................................
            //Approver - Date Approved 
            object dtDA1_VO = row["DALAppDate"];
            object dtDNA1_VO = row["DALNotAppDate"];
            if (dtDA1_VO != DBNull.Value)
            {
                lblDAL_ApprovedDate_VO.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNA1_VO != DBNull.Value)
            {
                lblDAL_ApprovedDate_VO.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblDAL_ApprovedDate_VO.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblDAL_ApprovedStatus_VO.Text = row["DALAppStatus"].ToString(); }
            else
            { lblDAL_ApprovedStatus_VO.Text = "-"; }

            //Approver - Comment
            if (row["DALAppComment"].ToString() != "")
            { lblDAL_ApprovedComment_VO.Text = row["DALAppComment"].ToString(); }
            else
            { lblDAL_ApprovedComment_VO.Text = "-"; }

            //...................................end of DAL Approval 3.9...................................

            //...................................DAL Approval 3.13...................................  
            //.................................................Approver.................................................
            //Approver - Date Approved 
            object dtDA1_EOT = row["DALAppDate"];
            object dtDNA1_EOT = row["DALNotAppDate"];
            if (dtDA1_EOT != DBNull.Value)
            {
                lblDAL_ApprovedDate_EOT.Text = Convert.ToDateTime(row["DALAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtDNA1_EOT != DBNull.Value)
            {
                lblDAL_ApprovedDate_EOT.Text = Convert.ToDateTime(row["DALNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblDAL_ApprovedDate_EOT.Text = "-";
            }

            //Approver - Status 
            if (row["DALAppStatus"].ToString() != "")
            { lblDAL_ApprovedStatus_EOT.Text = row["DALAppStatus"].ToString(); }
            else
            { lblDAL_ApprovedStatus_EOT.Text = "-"; }

            //Approver - Comment
            if (row["DALAppComment"].ToString() != "")
            { lblDAL_ApprovedComment_EOT.Text = row["DALAppComment"].ToString(); }
            else
            { lblDAL_ApprovedComment_EOT.Text = "-"; }

            //...................................end of DAL Approval 3.13...................................

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

                DALApprover();
                DALApprover_VO();
                DALApprover_EOT();
            }
            else if (dt8 != DBNull.Value)
            {
                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;

                DALApprover();
                DALApprover_VO();
                DALApprover_EOT();
            }

        }
    }

    protected void DALApprover()
    {
        qs1 = "";
        qs1 = qs1 + " SELECT        tblChangeRequestVO.* ";
        qs1 = qs1 + " FROM          tblChangeRequestVO ";
        qs1 = qs1 + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd1 = new SqlCommand(qs1, con);
        cmd1.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row1 = dt1.Rows[0];

            //DAL (Discretionary Authority Limits) Approval 
            decimal CostImpact_Value;
            CostImpact_Value = Convert.ToDecimal(row1["CostImpact"].ToString());

            //Approver - Name
            fldDALApprover.Text = row1["DALApprovedBy"].ToString();
            fldDALApprover_HOD.Text = row1["DALApprovedBy_HOD"].ToString();
            fldDALApprover_COO.Text = row1["DALApprovedBy_COO"].ToString();

            if (CostImpact_Value == 5000000 || CostImpact_Value <= 5000000)
            {
                //Approved by Head of Division
                //Cost Impact Due To Changes - Equal or below 5m

                fldDALApprover.Visible = false;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = true;
                fldDALApprover_HOD.Enabled = true;

            }
            else if (CostImpact_Value == 50000000 || CostImpact_Value <= 50000000)
            {
                //Approved by COO
                //Cost Impact Due To Changes - Equal or below 50m

                fldDALApprover.Visible = false;
                fldDALApprover_COO.Visible = true;
                fldDALApprover_COO.Enabled = true;
                fldDALApprover_HOD.Visible = false;

            }
            else if (CostImpact_Value > 50000000)
            {
                //Approved by MD/CEO
                //Cost Impact Due To Changes - Above 50m

                fldDALApprover.Visible = true;
                fldDALApprover.Enabled = true;
                fldDALApprover_COO.Visible = false;
                fldDALApprover_HOD.Visible = false;

            }
        }
    }

    protected void DALApprover_VO()
    {
        qs3 = "";
        qs3 = qs3 + " SELECT        tblChangeRequestVO.* ";
        qs3 = qs3 + " FROM          tblChangeRequestVO ";
        qs3 = qs3 + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd3 = new SqlCommand(qs3, con);
        cmd3.CommandTimeout = 0;

        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        da3.Fill(dt3);
        con.Close();

        if (dt3.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row3 = dt3.Rows[0];

            //DAL (Discretionary Authority Limits) Approval 
            decimal CostImpact_Value2;
            CostImpact_Value2 = Convert.ToDecimal(row3["CostImpact"].ToString());

            //Approver - Name
            fldDALApprover_VO.Text = row3["DALApprovedBy"].ToString();
            fldDALApprover_HOD_VO.Text = row3["DALApprovedBy_HOD"].ToString();
            fldDALApprover_COO_VO.Text = row3["DALApprovedBy_COO"].ToString();

            if (CostImpact_Value2 == 100000 || CostImpact_Value2 <= 100000)
            {
                //Approved by Head of Division
                //Cost Impact Due To Changes - Equal or below 100k

                fldDALApprover_VO.Visible = false;
                fldDALApprover_COO_VO.Visible = false;
                fldDALApprover_HOD_VO.Visible = true;
                fldDALApprover_HOD_VO.Enabled = true;

            }
            else if (CostImpact_Value2 == 500000 || CostImpact_Value2 <= 500000)
            {
                //Approved by COO
                //Cost Impact Due To Changes - Equal or below 500k

                fldDALApprover_VO.Visible = false;
                fldDALApprover_COO_VO.Visible = true;
                fldDALApprover_COO_VO.Enabled = true;
                fldDALApprover_HOD_VO.Visible = false;

            }
            else if (CostImpact_Value2 == 4000000 || CostImpact_Value2 <= 4000000)
            {
                //Approved by MD/CEO
                //Cost Impact Due To Changes - Equal or below 4m

                fldDALApprover_VO.Visible = true;
                fldDALApprover_VO.Enabled = true;
                fldDALApprover_COO_VO.Visible = false;
                fldDALApprover_HOD_VO.Visible = false;

            }
            else if (CostImpact_Value2 == 10000000 || CostImpact_Value2 <= 10000000)
            {
                //Approved by xx
                //Cost Impact Due To Changes - Equal or below 10m

                //fldDALApprover_VO.Visible = true;
                //fldDALApprover_VO.Enabled = true;
                //fldDALApprover_COO_VO.Visible = false;
                //fldDALApprover_HOD_VO.Visible = false;

            }
            else if (CostImpact_Value2 > 10000000)
            {
                //Approved by xx
                //Cost Impact Due To Changes - Above 10m

                //fldDALApprover_VO.Visible = true;
                //fldDALApprover_VO.Enabled = true;
                //fldDALApprover_COO_VO.Visible = false;
                //fldDALApprover_HOD_VO.Visible = false;

            }
        }
    }

    protected void DALApprover_EOT()
    {
        qs2 = "";
        qs2 = qs2 + " SELECT        tblChangeRequestVO.* ";
        qs2 = qs2 + " FROM          tblChangeRequestVO ";
        qs2 = qs2 + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd2 = new SqlCommand(qs2, con);
        cmd2.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        con.Close();

        if (dt2.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row2 = dt2.Rows[0];

            //DAL (Discretionary Authority Limits) Approval 
            decimal CostImpact_Value1;
            CostImpact_Value1 = Convert.ToDecimal(row2["CostImpact"].ToString());

            //Approver - Name
            fldDALApprover_HOD_EOT.Text = row2["DALApprovedBy_HOD"].ToString();
            fldDALApprover_COO_EOT.Text = row2["DALApprovedBy_COO"].ToString();

            if (CostImpact_Value1 == 500000 || CostImpact_Value1 <= 500000)
            {
                //Approved by Head of Division
                //Cost Impact Due To Changes - Equal or below 500k

                fldDALApprover_COO_EOT.Visible = false;
                fldDALApprover_HOD_EOT.Visible = true;
                fldDALApprover_HOD_EOT.Enabled = true;

            }
            else if (CostImpact_Value1 > 500000)
            {
                //Approved by COO
                //Cost Impact Due To Changes - Above 500k

                fldDALApprover_COO_EOT.Visible = true;
                fldDALApprover_COO_EOT.Enabled = true;
                fldDALApprover_HOD_EOT.Visible = false;

            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateChangeRequest();

        Response.Redirect("ChangeRequestVODetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        if (fldChangeRequestToFrom.Text == "Client")
        {
            //Reset error
            dvDALApproval.Attributes.Add("class", null);

            if (fldDALApprover.SelectedIndex == 0 && fldDALApprover_COO.SelectedIndex == 0 && fldDALApprover_HOD.SelectedIndex == 0)
            {
                chckErr = false;
                dvDALApproval.Attributes.Add("class", "has-error");
            }

            if (chckErr == true)
            {
                DateTime now = DateTime.Now;

                updateChangeRequest();
                updateDAL();

                //Disable btnUpdate & btnSubmit in page
                if (con.State == System.Data.ConnectionState.Closed)
                { con.Open(); }

                SqlCommand cmdMain = new SqlCommand("UPDATE tblChangeRequestVO SET "
                        + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                        + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

                cmdMain.ExecuteNonQuery();

                con.Close();

                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;

                //DAL 3.8
                emailDAL();

                Response.Redirect("UpdateChangeRequestVO.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
            }
        }
        else if (fldChangeRequestToFrom.Text == "Sub-Contractor")
        {
            if (fldVariationType.Text == "Extension of Time (EOT)")
            {
                //Reset error
                dvDALApproval_EOT.Attributes.Add("class", null);

                if (fldDALApprover_COO_EOT.SelectedIndex == 0 && fldDALApprover_HOD_EOT.SelectedIndex == 0)
                {
                    chckErr = false;
                    dvDALApproval_EOT.Attributes.Add("class", "has-error");
                }

                if (chckErr == true)
                {
                    DateTime now = DateTime.Now;

                    updateChangeRequest();
                    updateDAL_EOT();

                    //Disable btnUpdate & btnSubmit in page
                    if (con.State == System.Data.ConnectionState.Closed)
                    { con.Open(); }

                    SqlCommand cmdMain = new SqlCommand("UPDATE tblChangeRequestVO SET "
                            + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                            + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

                    cmdMain.ExecuteNonQuery();

                    con.Close();

                    btnUpdate.Enabled = false;
                    btnSubmit.Enabled = false;

                    //DAL 3.13
                    emailDAL_EOT();

                    Response.Redirect("UpdateChangeRequestVO.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
                }
            }
            else if (fldVariationType.Text == "Variation Order (VO)")
            {
                //Reset error
                dvDALApproval_VO.Attributes.Add("class", null);

                if (fldDALApprover_VO.SelectedIndex == 0 && fldDALApprover_COO_VO.SelectedIndex == 0 && fldDALApprover_HOD_VO.SelectedIndex == 0)
                {
                    chckErr = false;
                    dvDALApproval_VO.Attributes.Add("class", "has-error");
                }

                if (chckErr == true)
                {
                    DateTime now = DateTime.Now;

                    updateChangeRequest();
                    updateDAL_VO();

                    //Disable btnUpdate & btnSubmit in page
                    if (con.State == System.Data.ConnectionState.Closed)
                    { con.Open(); }

                    SqlCommand cmdMain = new SqlCommand("UPDATE tblChangeRequestVO SET "
                            + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                            + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

                    cmdMain.ExecuteNonQuery();

                    con.Close();

                    btnUpdate.Enabled = false;
                    btnSubmit.Enabled = false;

                    //DAL 3.9
                    emailDAL_VO();

                    Response.Redirect("UpdateChangeRequestVO.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
                }
            }
        }
        else if (fldChangeRequestToFrom.Text == "Internal")
        {
            DateTime now = DateTime.Now;

            updateChangeRequest();

            //Disable btnUpdate & btnSubmit in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblChangeRequestVO SET "
                    + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnSubmit.Enabled = false;

            Response.Redirect("UpdateChangeRequestVO.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
        }

    }

    protected void updateChangeRequest()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmd = new SqlCommand("UPDATE tblChangeRequestVO SET "
            + "Title = @pTitle,"
            + "ContractNo = @pContractNo,"
            + "VariationType = @pVariationType,"
            + "ClientApproval = @pClientApproval,"
            + "Reason = @pReason,"
            + "CostImpact = @pCostImpact,"
            + "ScheduleImpact = @pScheduleImpact,"
            + "LADImpact = @pLADImpact,"
            + "GrantingEOT = @pGrantingEOT,"
            + "EOTFromClient = @pEOTFromClient,"
            + "ModifyBy = @pModifyBy, "
            + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
            + "WHERE Id = '" + Request.QueryString["Id1"] + "'", con);

        //Title
        cmd.Parameters.AddWithValue("@pTitle", fldTitle.Text.Trim());

        //Contract No.
        cmd.Parameters.AddWithValue("@pContractNo", fldContractNo.Text.Trim());

        //Type Of Variation
        cmd.Parameters.AddWithValue("@pVariationType", fldVariationType.SelectedValue);

        //Has Client Approved The Changes?
        cmd.Parameters.AddWithValue("@pClientApproval", fldClientApproval.SelectedValue);

        //Reason For Variation / EOT
        cmd.Parameters.AddWithValue("@pReason", fldReason.Text.Trim());

        //Cost Impact Due To Variation / EOT
        cmd.Parameters.AddWithValue("@pCostImpact", fldCostImpact.Text.Trim());

        //Schedule Impact Due To Variation / EOT
        cmd.Parameters.AddWithValue("@pScheduleImpact", fldScheduleImpact.Text.Trim());

        //LAD Impact
        cmd.Parameters.AddWithValue("@pLADImpact", fldLADImpact.Text.Trim());

        //Granting EOT?
        cmd.Parameters.AddWithValue("@pGrantingEOT", fldGrantingEOT.SelectedValue);

        //Is This A Back-To-Back EOT From Client?
        cmd.Parameters.AddWithValue("@pEOTFromClient", fldEOTFromClient.SelectedValue);

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void updateDAL()
    {
        //Check DAL Approval based on Cost Impact Due To Changes
        qs = "";
        qs = qs + " SELECT        CostImpact ";
        qs = qs + " FROM          tblChangeRequestVO ";
        qs = qs + " WHERE         Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd1 = new SqlCommand(qs, con);
        cmd1.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count != 0)
        {
            DataRow row1 = dt1.Rows[0];

            //Update in table tblChangeRequestVO
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdApproval = new SqlCommand("UPDATE tblChangeRequestVO SET "
                    + "DALApproverLevel = @pApproverLevel, "
                    + "DALApprovedBy_HOD = @pApprovedBy_HOD, "
                    + "DALApprovedBy_COO = @pApprovedBy_COO, "
                    + "DALApprovedBy = @pApprovedBy "
                    + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

            //Refer to DAL (Discretionary Authority Limits) table 
            decimal CostImpact_Value;
            CostImpact_Value = Convert.ToDecimal(row1["CostImpact"].ToString());

            if (CostImpact_Value == 5000000 || CostImpact_Value <= 5000000)
            {
                //Approved by Head of Division
                //Cost Impact Due To Changes - Equal or below 5m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "Head of Division");

                //Approved By - Head of Division
                if (fldDALApprover_HOD.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", fldDALApprover_HOD.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

                //Approved By - MD/CEO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

            }
            else if (CostImpact_Value == 50000000 || CostImpact_Value <= 50000000)
            {
                //Approved by COO
                //Cost Impact Due To Changes - Equal or below 50m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "COO");

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                if (fldDALApprover_COO.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", fldDALApprover_COO.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

                //Approved By - MD/CEO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

            }
            else if (CostImpact_Value > 50000000)
            {
                //Approved by MD/CEO
                //Cost Impact Due To Changes - Above 50m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "MD/CEO");

                //Approved By - MD/CEO
                if (fldDALApprover.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }

            cmdApproval.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void updateDAL_VO()
    {
        //Check DAL Approval based on Cost Impact Due To Changes
        qs = "";
        qs = qs + " SELECT        CostImpact ";
        qs = qs + " FROM          tblChangeRequestVO ";
        qs = qs + " WHERE         Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd3 = new SqlCommand(qs, con);
        cmd3.CommandTimeout = 0;

        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        da3.Fill(dt3);
        con.Close();

        if (dt3.Rows.Count != 0)
        {
            DataRow row3 = dt3.Rows[0];

            //Update in table tblChangeRequestVO
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdApproval = new SqlCommand("UPDATE tblChangeRequestVO SET "
                    + "DALApproverLevel = @pApproverLevel, "
                    + "DALApprovedBy_HOD = @pApprovedBy_HOD, "
                    + "DALApprovedBy_COO = @pApprovedBy_COO, "
                    + "DALApprovedBy = @pApprovedBy "
                    + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

            //Refer to DAL (Discretionary Authority Limits) table 
            decimal CostImpact_Value;
            CostImpact_Value = Convert.ToDecimal(row3["CostImpact"].ToString());

            if (CostImpact_Value == 100000 || CostImpact_Value <= 100000)
            {
                //Approved by Head of Division
                //Cost Impact Due To Changes - Equal or below 100k

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "Head of Division");

                //Approved By - Head of Division
                if (fldDALApprover_HOD_VO.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", fldDALApprover_HOD_VO.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

                //Approved By - MD/CEO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

            }
            else if (CostImpact_Value == 500000 || CostImpact_Value <= 500000)
            {
                //Approved by COO
                //Cost Impact Due To Changes - Equal or below 500k

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "COO");

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                if (fldDALApprover_COO_VO.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", fldDALApprover_COO_VO.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

                //Approved By - MD/CEO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

            }
            else if (CostImpact_Value == 4000000 || CostImpact_Value <= 4000000)
            {
                //Approved by MD/CEO
                //Cost Impact Due To Changes - Equal or below 4m

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "MD/CEO");

                //Approved By - MD/CEO
                if (fldDALApprover_VO.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover_VO.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }
            else if (CostImpact_Value == 10000000 || CostImpact_Value <= 10000000)
            {
                //Approved by 
                //Cost Impact Due To Changes - Equal or below 10m

                ////DAL Approver Level
                //cmdApproval.Parameters.AddWithValue("@pApproverLevel", "");

                ////Approved By - 
                //if (fldDALApprover_VO.Text != "")
                //    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover_VO.SelectedValue);
                //else
                //    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                ////Approved By - Head of Division
                //cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                ////Approved By - COO
                //cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }
            else if (CostImpact_Value > 10000000)
            {
                //Approved by 
                //Cost Impact Due To Changes - Above 10m

                ////DAL Approver Level
                //cmdApproval.Parameters.AddWithValue("@pApproverLevel", "");

                ////Approved By - 
                //if (fldDALApprover_VO.Text != "")
                //    cmdApproval.Parameters.AddWithValue("@pApprovedBy", fldDALApprover_VO.SelectedValue);
                //else
                //    cmdApproval.Parameters.AddWithValue("@pApprovedBy", DBNull.Value);

                ////Approved By - Head of Division
                //cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                ////Approved By - COO
                //cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }

            cmdApproval.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void updateDAL_EOT()
    {
        //Check DAL Approval based on Cost Impact Due To Changes
        qs = "";
        qs = qs + " SELECT        CostImpact ";
        qs = qs + " FROM          tblChangeRequestVO ";
        qs = qs + " WHERE         Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd2 = new SqlCommand(qs, con);
        cmd2.CommandTimeout = 0;

        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);
        con.Close();

        if (dt2.Rows.Count != 0)
        {
            DataRow row2 = dt2.Rows[0];

            //Update in table tblChangeRequestVO
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdApproval = new SqlCommand("UPDATE tblChangeRequestVO SET "
                    + "DALApproverLevel = @pApproverLevel, "
                    + "DALApprovedBy_HOD = @pApprovedBy_HOD, "
                    + "DALApprovedBy_COO = @pApprovedBy_COO "
                    + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

            //Refer to DAL (Discretionary Authority Limits) table 
            decimal CostImpact_Value;
            CostImpact_Value = Convert.ToDecimal(row2["CostImpact"].ToString());

            if (CostImpact_Value == 500000 || CostImpact_Value <= 500000)
            {
                //Approved by Head of Division
                //Cost Impact Due To Changes - Equal or below 500k

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "Head of Division");

                //Approved By - Head of Division
                if (fldDALApprover_HOD_EOT.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", fldDALApprover_HOD_EOT.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }
            else if (CostImpact_Value > 50000000)
            {
                //Approved by COO
                //Cost Impact Due To Changes - Above 500k

                //DAL Approver Level
                cmdApproval.Parameters.AddWithValue("@pApproverLevel", "COO");

                //Approved By - Head of Division
                cmdApproval.Parameters.AddWithValue("@pApprovedBy_HOD", DBNull.Value);

                //Approved By - COO
                if (fldDALApprover_COO_EOT.Text != "")
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", fldDALApprover_COO_EOT.SelectedValue);
                else
                    cmdApproval.Parameters.AddWithValue("@pApprovedBy_COO", DBNull.Value);

            }

            cmdApproval.ExecuteNonQuery();

            con.Close();
        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangeRequestVODetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void emailDAL()
    {
        string approval_type = "";

        //Email notification to DAL person
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblChangeRequestVO.Id, tblChangeRequestVO.VariationType, tblChangeRequestVO.Reason, tblChangeRequestVO.CostImpact, tblChangeRequestVO.DALApproverLevel, vwChangeRequestVOApproval.AppBy, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblChangeRequestVO ON tblMain.Id = tblChangeRequestVO.DescriptionId ";
        qs = qs + "               INNER JOIN vwChangeRequestVOApproval ON tblMain.Id = vwChangeRequestVOApproval.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON vwChangeRequestVOApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

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
        //client.Host = "smtp.uemedgenta.com";
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (row["DALApproverLevel"].ToString() == "MD/CEO")
        {
            approval_type = "conditionally approve on behalf MD/CEO";
        }
        else
        {
            approval_type = "approve";
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Approval on Submission / Acceptance of VO / Claims / RW / EOT to / from Client for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to " + approval_type + " the following VO / EOT :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Type Of Changes : </B>" + row["VariationType"].ToString() + "<BR><BR>"
                            + "<B>Reason For Changes : </B>" + row["Reason"].ToString() + "<BR><BR>"
                            + "<B>Cost Impact Due To Changes To Client : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())) + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalChangeRequestClient_DAL.aspx?ID=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"] + ">link</A> to approve the VO / EOT.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailDAL_VO()
    {
        string approval_type = "";

        //Email notification to DAL person
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblChangeRequestVO.Id, tblChangeRequestVO.VariationType, tblChangeRequestVO.Reason, tblChangeRequestVO.CostImpact, tblChangeRequestVO.DALApproverLevel, vwChangeRequestVOApproval.AppBy, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblChangeRequestVO ON tblMain.Id = tblChangeRequestVO.DescriptionId ";
        qs = qs + "               INNER JOIN vwChangeRequestVOApproval ON tblMain.Id = vwChangeRequestVOApproval.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON vwChangeRequestVOApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

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
        //client.Host = "smtp.uemedgenta.com";
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        if (row["DALApproverLevel"].ToString() == "MD/CEO")
        {
            approval_type = "conditionally approve on behalf MD/CEO";
        }
        else
        {
            approval_type = "approve";
        }

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Approval on Award of Variation Order (“VO”)/ Claims, and Reimbursable Work (“RW”) to Sub-contractors for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to " + approval_type + " the following VO :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Type Of Changes : </B>" + row["VariationType"].ToString() + "<BR><BR>"
                            + "<B>Reason For Changes : </B>" + row["Reason"].ToString() + "<BR><BR>"
                            + "<B>Cost Impact Due To Changes : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())) + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalChangeRequestClient_DALVO.aspx?ID=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"] + ">link</A> to approve the VO.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    protected void emailDAL_EOT()
    {
        //Email notification to DAL person
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblChangeRequestVO.Id, tblChangeRequestVO.VariationType, tblChangeRequestVO.Reason, tblChangeRequestVO.CostImpact, tblChangeRequestVO.DALApproverLevel, vwChangeRequestVOApproval.AppBy, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, StaffLogin_1.EmailId AS DALEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblChangeRequestVO ON tblMain.Id = tblChangeRequestVO.DescriptionId ";
        qs = qs + "               INNER JOIN vwChangeRequestVOApproval ON tblMain.Id = vwChangeRequestVOApproval.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON vwChangeRequestVOApproval.AppBy = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " WHERE         tblChangeRequestVO.Id = '" + Request.QueryString["Id1"] + "' ";

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
        //client.Host = "smtp.uemedgenta.com";
        client.Host = "smtp2.edgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["DALEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Request for Approval on Granting of Extension of Time (“EOT”) to Contractors / Sub-contractors for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["DALName"].ToString() + ",<BR><BR><BR>"

                            + "You are required to approve the following EOT :<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Project Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Type Of Changes : </B>" + row["VariationType"].ToString() + "<BR><BR>"
                            + "<B>Reason For Changes : </B>" + row["Reason"].ToString() + "<BR><BR>"
                            + "<B>Cost Impact Due To Changes : </B>RM" + String.Format("{0:0,0.00}", Convert.ToDouble(row["CostImpact"].ToString())) + "<BR><BR><BR>"

                            + "Click on this <A HREF=http://pectest.uemedgenta.com/PM/ApprovalChangeRequestClient_DALEOT.aspx?ID=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"] + ">link</A> to approve the EOT.<BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------
    }

    #region VOLetter
    private void bindVOLetter()
    {
        string constr = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string str;

                str = "SELECT         FileName "
                    + "FROM           tblChangeRequestDocument "
                    + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
                    + "AND            ChangeRequestId = '" + Request.QueryString["ID1"] + "' "
                    + "AND            Category = 'VO Letter' ";

                cmd.CommandText = str;
                cmd.Connection = con;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (!dr.HasRows)
                    {
                        lblVOLetter.Visible = false;
                        btnSaveVOLetter.Text = "Save";
                    }
                    else
                    {
                        lblVOLetter.Visible = true;
                        btnSaveVOLetter.Text = "View";
                        fldVOLetter.Enabled = false;
                        lblVOLetter.Text = dr[0].ToString();
                    }
                }

                con.Close();
            }
        }
    }

    protected void btnSaveVOLetter_Click(object sender, EventArgs e)
    {
        if (btnSaveVOLetter.Text == "Save")
        {
            if (fldVOLetter.HasFile)
            {
                DateTime now = DateTime.Now;

                Boolean chckErr = true;

                //Reset error
                dvVOLetter.Attributes.Add("class", null);

                if (fldVOLetter.FileName == "")
                {
                    chckErr = false;
                    dvVOLetter.Attributes.Add("class", "has-error");
                }

                if(chckErr == true)
                {
                    //Upload file to folder
                    HttpFileCollection hfc = Request.Files;
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/";
                            //string pathString = @"C:/Users/azhar.yusof/Documents/Visual Studio 2019/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/";

                            if (!System.IO.File.Exists(pathString))
                            {
                                System.IO.Directory.CreateDirectory(pathString);
                                if (System.IO.Path.GetExtension(fldVOLetter.PostedFile.FileName) == ".exe")
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
                                if (System.IO.Path.GetExtension(fldVOLetter.PostedFile.FileName) == ".exe")
                                {
                                    //lblError.Text = "No .exe files are allowed.";
                                }
                                else
                                {
                                    hpf.SaveAs(pathString + "/" + System.IO.Path.GetFileName(hpf.FileName) + "");
                                }
                            }
                        }

                        foreach (HttpPostedFile postedFile in fldVOLetter.PostedFiles)
                        {
                            string filename = Path.GetFileName(postedFile.FileName);

                            using (Stream fs = postedFile.InputStream)
                            {
                                using (BinaryReader br = new BinaryReader(fs))
                                {
                                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                    //Insert into table tblProjectDocument
                                    queryString = "";
                                    queryString = queryString + " INSERT INTO   tblChangeRequestDocument ";
                                    queryString = queryString + "               (Category, DescriptionId, ChangeRequestId, FileName, Folder, CreatedBy, DateCreated) ";
                                    queryString = queryString + " VALUES        ('VO Letter', @pDescriptionId, @pChangeRequestId, @pFileName, 'VOLetter', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

                                    if (con.State == System.Data.ConnectionState.Closed)
                                    {
                                        con.Open();
                                    }

                                    cmd = new SqlCommand(queryString, con);
                                    cmd.CommandTimeout = 0;

                                    cmd.Parameters.AddWithValue("@pFileName", filename);
                                    cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
                                    cmd.Parameters.AddWithValue("@pChangeRequestId", Request.QueryString["ID1"]);

                                    cmd.ExecuteNonQuery();

                                    con.Close();
                                }
                            }
                        }
                    }

                    Response.Redirect("UpdateChangeRequestVO.aspx?ID=" + Request.QueryString["ID"] + "&Id1=" + Request.QueryString["ID1"]);
                }
            }
        }
        else if (btnSaveVOLetter.Text == "View")
        {
            string filePath = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/" + lblVOLetter.Text;
            //string filePath = @"C:/Users/azhar.yusof/Documents/Visual Studio 2019/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/VOLetter/" + lblVOLetter.Text;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
    }
    #endregion

    private void bindSupportingDoc()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblChangeRequestDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            ChangeRequestId = '" + Request.QueryString["ID1"] + "' "
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

        SqlCommand cmd = new SqlCommand("DELETE FROM tblChangeRequestDocument WHERE ID=@ID", con);

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
            queryString = queryString + " INSERT INTO   tblChangeRequestDocument ";
            queryString = queryString + "               (Category, DescriptionId, ChangeRequestId, Folder, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        ('Supporting Document', @pDescriptionId, @pChangeRequestId, 'CRSupportingDoc', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pChangeRequestId", Request.QueryString["ID1"]);

            cmd.ExecuteNonQuery();
            con.Close();

            //Supporting Document
            uploadSupportingDoc();

            Response.Redirect("UpdateChangeRequestVO.aspx?ID=" + Request.QueryString["ID"] + "&Id1=" + Request.QueryString["ID1"]);
        }
    }

    protected void uploadSupportingDoc()
    {
        if (fldFileName.FileName != "")
        {
            //Update Supporting Document
            SqlCommand cmdFile = new SqlCommand("UPDATE tblChangeRequestDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Supporting Document' "
                    + "AND DescriptionId = '" + Request.QueryString["Id"] + "' "
                    + "AND ChangeRequestId = '" + Request.QueryString["Id1"] + "'", con);

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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["Id1"] + "/CRSupportingDoc/";

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