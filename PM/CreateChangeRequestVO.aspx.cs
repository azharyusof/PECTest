using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateChangeRequestVO : System.Web.UI.Page
{
    DataRow row = null;
    DataRow rowId = null;
    String qs = "";
    String qs1 = "";
    String qs2 = "";
    String qsId = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
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
            //Insert Description Id into tblChangeRequestVO
            qs2 = "";
            qs2 = qs2 + " INSERT INTO tblChangeRequestVO (DescriptionId) ";
            qs2 = qs2 + " VALUES ('" + Request.QueryString["Id"] + "')  ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd2 = new SqlCommand(qs2, con);
            cmd2.CommandTimeout = 0;

            cmd2.ExecuteNonQuery();

            con.Close();

            bindCRToFrom();
            bindVariationType();
            bindClientApproval();
            bindGrantingVO();
            bindGrantingEOT();
            bindEOTFromClient();

            bindIncreaseFee();
            bindContractAddendum();

            bindDetails();
        }
    }

    #region onSelectedIndexChanged
    protected void fldChangeRequestToFrom_changed(object sender, EventArgs e)
    {
        if(fldChangeRequestToFrom.SelectedItem.Value == "Internal")
        {
            dvContractNo.Visible = false;
            dvEOTFromClient.Visible = false;
            dvGrantingVO.Visible = false;
            dvGrantingEOT.Visible = false;
            dvLADImpact.Visible = false;

            lblfldCostImpact.Visible = false;
            lblRM.Visible = false;
            fldCostImpact.Visible = false;

            dvIncreaseFee.Visible = false;
            dvContractAddendum.Visible = false;
            dvVOFee.Visible = false;
        }
        else if(fldChangeRequestToFrom.SelectedItem.Value == "Client")
        {
            dvContractNo.Visible = false;
            dvEOTFromClient.Visible = false;
            dvGrantingVO.Visible = true;
            dvGrantingEOT.Visible = true;
            dvLADImpact.Visible = false;

            lblfldCostImpact.Visible = true;
            lblRM.Visible = true;
            fldCostImpact.Visible = true;

            lblfldCostImpact.InnerText = "Cost Impact Due To Changes to Client";

            if(fldGrantingVO.SelectedItem.Value == "Yes")
            {
                dvIncreaseFee.Visible = true;
                dvContractAddendum.Visible = true;
                dvVOFee.Visible = true;
            }
            else
            {
                dvIncreaseFee.Visible = false;
                dvContractAddendum.Visible = false;
                dvVOFee.Visible = false;
            }
        }
        else if(fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
        {
            dvContractNo.Visible = true;
            dvEOTFromClient.Visible = true;
            dvGrantingVO.Visible = true;
            dvGrantingEOT.Visible = true;
            dvLADImpact.Visible = true;

            lblfldCostImpact.Visible = true;
            lblRM.Visible = true;
            fldCostImpact.Visible = true;

            lblfldCostImpact.InnerText = "Cost Impact Due To Changes";

            dvIncreaseFee.Visible = false;
            dvContractAddendum.Visible = false;
            dvVOFee.Visible = false;
        }
        else //no value selected in ddl
        {
            dvContractNo.Visible = true;
            dvEOTFromClient.Visible = true;
            dvGrantingVO.Visible = true;
            dvGrantingEOT.Visible = true;
            dvLADImpact.Visible = true;

            lblfldCostImpact.Visible = true;
            lblRM.Visible = true;
            fldCostImpact.Visible = true;

            lblfldCostImpact.InnerText = "Cost Impact Due To Changes";

            dvIncreaseFee.Visible = false;
            dvContractAddendum.Visible = false;
            dvVOFee.Visible = false;
        }
    }

    protected void fldGrantingVO_changed(object sender, EventArgs e)
    {
        if(fldGrantingVO.SelectedItem.Value == "Yes" && fldChangeRequestToFrom.SelectedItem.Value == "Client")
        {
            dvIncreaseFee.Visible = true;
            dvContractAddendum.Visible = true;
            dvVOFee.Visible = true;
        }
        else
        {
            dvIncreaseFee.Visible = false;
            dvContractAddendum.Visible = false;
            dvVOFee.Visible = false;
        }
    }
    #endregion

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        ProjectCode ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " WHERE         Id = '" + Request.QueryString["Id"] + "' ";

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

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();
        }
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

    protected void fldVariationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldVariationType.SelectedValue == "Extension of Time (EOT)")
        {
            fldGrantingVO.Visible = false;
            lblNA.Visible = true;

            fldGrantingEOT.Visible = true;
            lblNA1.Visible = false;

            fldEOTFromClient.Visible = true;
            lblNA2.Visible = false;
        }
        else if (fldVariationType.SelectedValue == "Variation Order (VO)")
        {
            fldGrantingVO.Visible = true;
            lblNA.Visible = false;

            fldGrantingEOT.Visible = false;
            lblNA1.Visible = true;

            fldEOTFromClient.Visible = true;
            lblNA2.Visible = false;
        }
        else if (fldVariationType.SelectedValue == "Others")
        {
            fldGrantingVO.Visible = false;
            lblNA.Visible = true;

            fldGrantingEOT.Visible = false;
            lblNA1.Visible = true;

            fldEOTFromClient.Visible = false;
            lblNA2.Visible = true;
        }
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


    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangeRequestVODetail.aspx?Id=" + Request.QueryString["Id"]);
    }
    
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset Error
        dvCRToFrom.Attributes.Add("class", null);
        dvTitle.Attributes.Add("class", null);
        dvContractNo.Attributes.Add("class", null);
        dvVariationType.Attributes.Add("class", null);
        dvReason.Attributes.Add("class", null);
        dvCostImpact.Attributes.Add("class", null);
        dvScheduleImpact.Attributes.Add("class", null);
        dvLADImpact.Attributes.Add("class", null);
        dvGrantingVO.Attributes.Add("class", null);
        dvGrantingEOT.Attributes.Add("class", null);
        dvEOTFromClient.Attributes.Add("class", null);

        dvIncreaseFee.Attributes.Add("Class", null);
        dvContractAddendum.Attributes.Add("Class", null);
        dvVOFee.Attributes.Add("Class", null);

        if (fldChangeRequestToFrom.SelectedIndex == 0)
        {
            chckErr = false;
            dvCRToFrom.Attributes.Add("class", "has-error");
        }

        if (fldTitle.Text.Trim() == "")
        {
            chckErr = false;
            dvTitle.Attributes.Add("class", "has-error");
        }

        if (fldContractNo.Text.Trim() == "")
        {
            if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
            {
                chckErr = false;
                dvContractNo.Attributes.Add("class", "has-error");
            }
        }

        if (fldVariationType.SelectedIndex == 0)
        {
            chckErr = false;
            dvVariationType.Attributes.Add("class", "has-error");
        }

        if (fldReason.Text.Trim() == "")
        {
            chckErr = false;
            dvReason.Attributes.Add("class", "has-error");
        }
        
        if (fldScheduleImpact.Text.Trim() == "")
        {
            chckErr = false;
            dvScheduleImpact.Attributes.Add("class", "has-error");
        }

        if (fldVariationType.SelectedValue == "Variation Order (VO)")
        {
            if (fldChangeRequestToFrom.SelectedItem.Value != "Internal")
            {
                if (fldCostImpact.Text.Trim() == "")
                {
                    chckErr = false;
                    dvCostImpact.Attributes.Add("class", "has-error");
                }
            }

            if (fldChangeRequestToFrom.SelectedItem.Value == "Client" || fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
            {
                if (fldGrantingVO.SelectedIndex == 0)
                {
                    chckErr = false;
                    dvGrantingVO.Attributes.Add("class", "has-error");
                }
            }
        }

        if (fldVariationType.SelectedValue == "Extension of Time (EOT)")
        {
            if (fldChangeRequestToFrom.SelectedItem.Value == "Client" || fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
            {
                if (fldGrantingEOT.SelectedIndex == 0)
                {
                    chckErr = false;
                    dvGrantingEOT.Attributes.Add("class", "has-error");
                }                
            }
            else
            {
                if (fldLADImpact.Text.Trim() == "")
                {
                    chckErr = false;
                    dvLADImpact.Attributes.Add("class", "has-error");
                }
            }
        }

        if (fldVariationType.SelectedValue == "Extension of Time (EOT)" || fldVariationType.SelectedValue == "Variation Order (VO)")
        {
            if (fldChangeRequestToFrom.SelectedItem.Value == "Sub-Contractor")
            {
                if (fldEOTFromClient.SelectedIndex == 0)
                {
                    chckErr = false;
                    dvEOTFromClient.Attributes.Add("class", "has-error");
                }
            }
        }
        
        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            insertChangeRequestVO();

            //Capture latest Id from database.
            captureLatestId();

            Response.Redirect("UpdateChangeRequestVO.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + rowId["Id"].ToString());            
        }
    }

    protected void insertChangeRequestVO()
    {
        DateTime now = DateTime.Now;
        
        //Insert into table tblChangeRequestVO
        qs = "";
        qs = qs + " INSERT INTO   tblChangeRequestVO ";
        qs = qs + "               (DescriptionId, ChangeRequestToFrom, Title, ContractNo, VariationType, ClientApproval, Reason, CostImpact, ScheduleImpact, LADImpact, GrantingVO, GrantingEOT, EOTFromClient, CreatedBy, DateCreated, IncreaseFee, ContractAddendum, VOFee) ";
        qs = qs + " VALUES        (@pDescriptionId, @pChangeRequestToFrom, @pTitle, @pContractNo, @pVariationType, @pClientApproval, @pReason, @pCostImpact, @pScheduleImpact, @pLADImpact, @pGrantingVO, @pGrantingEOT, @pEOTFromClient, @pCreatedBy, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', @pIncreaseFee, @pContractAddendum, @pVOFee)";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        //Description Id
        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["Id"]);

        //Change Request To / From
        cmd.Parameters.AddWithValue("@pChangeRequestToFrom", fldChangeRequestToFrom.SelectedValue);        

        //Title
        cmd.Parameters.AddWithValue("@pTitle", fldTitle.Text.Trim());

        //Contract No.
        cmd.Parameters.AddWithValue("@pContractNo", fldContractNo.Text.Trim());

        //Type Of Changes
        cmd.Parameters.AddWithValue("@pVariationType", fldVariationType.SelectedValue);

        //Has Client Approved The Changes?
        cmd.Parameters.AddWithValue("@pClientApproval", fldClientApproval.SelectedValue);

        //Reason For Changes
        cmd.Parameters.AddWithValue("@pReason", fldReason.Text.Trim());

        //Cost Impact Due To Changes
        cmd.Parameters.AddWithValue("@pCostImpact", fldCostImpact.Text.Trim());

        //Schedule Impact Due To Changes
        cmd.Parameters.AddWithValue("@pScheduleImpact", fldScheduleImpact.Text.Trim());

        //Cumulative LAD Impact
        cmd.Parameters.AddWithValue("@pLADImpact", fldLADImpact.Text.Trim());

        //Granting VO?
        cmd.Parameters.AddWithValue("@pGrantingVO", fldGrantingVO.SelectedValue);

        //Granting EOT?
        cmd.Parameters.AddWithValue("@pGrantingEOT", fldGrantingEOT.SelectedValue);

        //Is This A Back-To-Back EOT From Client?
        cmd.Parameters.AddWithValue("@pEOTFromClient", fldEOTFromClient.SelectedValue);

        //Created by
        cmd.Parameters.AddWithValue("@pCreatedBy", Session["UserID"].ToString());

        //IncreaseFee
        cmd.Parameters.AddWithValue("@pIncreaseFee", fldIncreaseFee.SelectedValue);

        //ContractAddendum
        cmd.Parameters.AddWithValue("@pContractAddendum", fldContractAddendum.SelectedValue);

        //VOFee
        cmd.Parameters.AddWithValue("@pVOFee", fldVOFee.Text.Trim());

        cmd.ExecuteNonQuery();

        con.Close();
    }

    protected void captureLatestId()
    {
        //Capture latest Id from database.
        qsId = "";
        qsId = qsId + " SELECT        TOP 1 Id  ";
        qsId = qsId + " FROM          tblChangeRequestVO ";
        qsId = qsId + " ORDER BY      Id DESC ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmdId = new SqlCommand(qsId, con);
        cmdId.CommandTimeout = 0;
        SqlDataAdapter daId = new SqlDataAdapter(cmdId);
        DataTable dtId = new DataTable();
        daId.Fill(dtId);
        con.Close();

        rowId = null;
        rowId = dtId.Rows[0];
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
