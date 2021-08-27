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

public partial class CreateAuditTrail : System.Web.UI.Page
{
    DataRow row = null;
    DataRow row1 = null;
    DataRow rowCSS = null;
    String qs = "";
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

        if (!Page.IsPostBack)
        {
            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            bindAuditType();
            bindAuditor();
            bindFindings();
            bindStatusClosure();
            bindDetails();
        }
    }


    protected void bindAuditType()
    {
        // Bind data to the dropdownlist control.
        fldAuditType.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldAuditType.Items.Insert(1, new ListItem("Internal", "Internal"));
        fldAuditType.Items.Insert(2, new ListItem("External", "External"));
    }

    protected void bindAuditor()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         Role = 'Auditor' ";
        qs = qs + " ORDER BY      StaffName ";

        fldAuditor.DataSource = GetData(qs);
        fldAuditor.DataTextField = "StaffName";
        fldAuditor.DataValueField = "StaffNo";
        fldAuditor.DataBind();
        fldAuditor.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindFindings()
    {
        // Bind data to the dropdownlist control.
        fldFindings.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldFindings.Items.Insert(1, new ListItem("NCR", "NCR"));
        fldFindings.Items.Insert(2, new ListItem("OFI", "OFI"));
        fldFindings.Items.Insert(3, new ListItem("NCR & OFI", "NCR & OFI"));
    }
    
    protected void bindStatusClosure()
    {
        // Bind data to the dropdownlist control.
        //fldStatusClosure.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldStatusClosure.Items.Insert(0, new ListItem("Open", "Open"));
        fldStatusClosure.Items.Insert(1, new ListItem("Close", "Close"));
    }

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

        }
    }
        
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;
                
        //Reset Error
        dvAuditType.Attributes.Add("class", null);
        dvAuditor.Attributes.Add("class", null);
        dvAuditDate.Attributes.Add("class", null);
        dvFindings.Attributes.Add("class", null);
        dvFindingsDescription.Attributes.Add("class", null);
        dvCompletionDateReq.Attributes.Add("class", null);

        if (fldAuditType.SelectedIndex == 0)
        {
            chckErr = false;
            dvAuditType.Attributes.Add("class", "has-error");
        }

        if (fldAuditor.SelectedIndex == 0)
        {
            chckErr = false;
            dvAuditor.Attributes.Add("class", "has-error");
        }

        if (fldAuditDate.Text == "")
        {
            chckErr = false;
            dvAuditDate.Attributes.Add("class", "has-error");
        }

        if (fldFindings.SelectedIndex == 0)
        {
            chckErr = false;
            dvFindings.Attributes.Add("class", "has-error");
        }
        
        if (fldFindingsDescription.Text.Trim() == "")
        {
            chckErr = false;
            dvFindingsDescription.Attributes.Add("class", "has-error");
        }
        
        if (fldCompletionDateReq.Text == "")
        {
            chckErr = false;
            dvCompletionDateReq.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            DateTime now = DateTime.Now;

            insertAuditTrail();

            //Capture latest Description Id from database.
            qsId = "";
            qsId = qsId + " SELECT        TOP 1 Id  ";
            qsId = qsId + " FROM          tblAuditTrail ";
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

            Response.Redirect("UpdateTrail.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + row["Id"].ToString());
        }        
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuditTrail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void insertAuditTrail()
    {
        DateTime now = DateTime.Now;

        //Insert into table tblAuditTrail
        qs = "";
        qs = qs + " INSERT INTO   tblAuditTrail ";
        qs = qs + "               (DescriptionId, AuditType, Auditor, AuditDate, AuditNo, Findings, FindingsDescription, CompletionDateReq, StatusClosure, CreatedBy, DateCreated) ";
        qs = qs + " VALUES        (@pDescriptionId, @pAuditType, @pAuditor, @pAuditDate, @pAuditNo, @pFindings, @pFindingsDescription, @pCompletionDateReq, @pStatusClosure, @pCreatedBy, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "')";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        //Description Id
        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["Id"]);

        //Audit Type
        cmd.Parameters.AddWithValue("@pAuditType", fldAuditType.SelectedValue);

        //Auditor
        cmd.Parameters.AddWithValue("@pAuditor", fldAuditor.SelectedValue);

        //Audit Date
        cmd.Parameters.AddWithValue("@pAuditDate", fldAuditDate.Text);

        //Audit No.
        cmd.Parameters.AddWithValue("@pAuditNo", fldAuditDate.Text.Trim());

        //Findings
        cmd.Parameters.AddWithValue("@pFindings", fldFindings.SelectedValue);

        //Description of Findings
        cmd.Parameters.AddWithValue("@pFindingsDescription", fldFindingsDescription.Text.Trim());

        //Corrective Action Completion Date 
        cmd.Parameters.AddWithValue("@pCompletionDateReq", fldCompletionDateReq.Text);

        //Status Closure
        cmd.Parameters.AddWithValue("@pStatusClosure", fldStatusClosure.SelectedValue);
        
        //Created by
        cmd.Parameters.AddWithValue("@pCreatedBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

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