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

public partial class ApprovalSignedProposal_DALCOO : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmdId = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Bind dropdownlist
            bindBoardRequired();
            bindTechnicalRequired();
            bindTechnicalReviewer();
            bindTechnicalApprover();

            bindCommercialRequired();
            bindCommercialReviewer();
            bindCommercialApprover();

            bindLegalRequired();
            bindLegalReviewer();
            bindLegalApprover();

            bindDetails();

            //Display opportunity details 
            qs = "";
            qs = qs + " SELECT        Description, Code";
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

                lblDescription.Text = row["Description"].ToString().ToUpper();
                lblCode.Text = row["Code"].ToString().ToUpper();
            }

            //Check approval details 
            qs = "";
            qs = qs + " SELECT        DALAppDate1, DALNotAppDate1, DALAppStatus1, DALAppComment1 ";
            qs = qs + " FROM          tblProposalEvaluation ";
            qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();

            if (dt2.Rows.Count == 0)
            {
                //Check for empty record.
                dvReject.Visible = false;
            }
            else
            {
                DataRow row = dt2.Rows[0];

                object dtA = row["DALAppDate1"];
                object dtNA = row["DALNotAppDate1"];

                if (dtA == DBNull.Value && dtNA == DBNull.Value)
                {
                    dvReject.Visible = false;
                }
                else if (dtA != DBNull.Value && dtNA == DBNull.Value)
                {
                    dvReject.Visible = false;
                    btnApprove.Enabled = false;
                    btnNotApprove.Enabled = false;

                }
                else if (dtA == DBNull.Value && dtNA != DBNull.Value)
                {
                    dvApprove.Visible = false;
                    dvReject.Visible = true;
                    btnApprove.Enabled = false;
                    btnNotApprove.Enabled = false;
                    fldJustification.Enabled = false;
                }
            }
        }
    }

    protected void bindBoardRequired()
    {
        // Bind data to the dropdownlist control.
        fldBoardRequired.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldBoardRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldBoardRequired.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void fldBoardRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fldBoardRequired.SelectedIndex == 1)
        {
            dvBoardPaper.Visible = true;
        }
        else
        {
            dvBoardPaper.Visible = false;
        }
    }


    protected void bindTechnicalRequired()
    {
        // Bind data to the dropdownlist control.
        fldTechnicalRequired.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldTechnicalRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldTechnicalRequired.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindTechnicalReviewer()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldTechnicalReviewer.DataSource = GetData(qs);
        fldTechnicalReviewer.DataTextField = "StaffName";
        fldTechnicalReviewer.DataValueField = "StaffNo";
        fldTechnicalReviewer.DataBind();
        fldTechnicalReviewer.Items.Insert(0, new ListItem("-- Select Reviewer --", ""));
    }

    protected void bindTechnicalApprover()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldTechnicalApprover.DataSource = GetData(qs);
        fldTechnicalApprover.DataTextField = "StaffName";
        fldTechnicalApprover.DataValueField = "StaffNo";
        fldTechnicalApprover.DataBind();
        fldTechnicalApprover.Items.Insert(0, new ListItem("-- Select Approver --", ""));
    }

    protected void bindCommercialRequired()
    {
        // Bind data to the dropdownlist control.
        fldCommercialRequired.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldCommercialRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldCommercialRequired.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindCommercialReviewer()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldCommercialReviewer.DataSource = GetData(qs);
        fldCommercialReviewer.DataTextField = "StaffName";
        fldCommercialReviewer.DataValueField = "StaffNo";
        fldCommercialReviewer.DataBind();
        fldCommercialReviewer.Items.Insert(0, new ListItem("-- Select Reviewer --", ""));
    }

    protected void bindCommercialApprover()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldCommercialApprover.DataSource = GetData(qs);
        fldCommercialApprover.DataTextField = "StaffName";
        fldCommercialApprover.DataValueField = "StaffNo";
        fldCommercialApprover.DataBind();
        fldCommercialApprover.Items.Insert(0, new ListItem("-- Select Approver --", ""));
    }


    protected void bindLegalRequired()
    {
        // Bind data to the dropdownlist control.
        fldLegalRequired.Items.Insert(0, new ListItem("-- Select Yes / No --", ""));
        fldLegalRequired.Items.Insert(1, new ListItem("Yes", "Yes"));
        fldLegalRequired.Items.Insert(2, new ListItem("No", "No"));
    }

    protected void bindLegalReviewer()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldLegalReviewer.DataSource = GetData(qs);
        fldLegalReviewer.DataTextField = "StaffName";
        fldLegalReviewer.DataValueField = "StaffNo";
        fldLegalReviewer.DataBind();
        fldLegalReviewer.Items.Insert(0, new ListItem("-- Select Reviewer --", ""));
    }

    protected void bindLegalApprover()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        StaffNo, StaffName ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " ORDER BY      StaffName ";

        fldLegalApprover.DataSource = GetData(qs);
        fldLegalApprover.DataTextField = "StaffName";
        fldLegalApprover.DataValueField = "StaffNo";
        fldLegalApprover.DataBind();
        fldLegalApprover.Items.Insert(0, new ListItem("-- Select Approver --", ""));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProposalEvaluation.*, ";
        qs = qs + "               StaffLogin_1.StaffName AS DALName, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblProposalEvaluation ";
        qs = qs + " INNER JOIN    StaffLogin AS StaffLogin_1 ON  tblProposalEvaluation.DALApprovedBy_COO = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalEvaluation.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalEvaluation.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         tblProposalEvaluation.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //--------------------------------------- Board / Management Approval ---------------------------------------
            //Board / Management Approval Required?
            fldBoardRequired.Text = row["BoardRequired"].ToString();

            //Comment
            fldBoardComment.Text = row["BoardComment"].ToString();

            //Board / Management Paper
            object fn = row["BoardPaper"];
            if (fn == DBNull.Value || fn == "")
            {
                lblFileNameBP_Empty.Visible = true;
            }
            else
            {
                lblFileNameBP.Visible = true;
                lblFileNameBP.Text = row["BoardPaper"].ToString();
            }

            //--------------------------------------- Final Proposal & Review ---------------------------------------
            //Proposal Closing Date
            object dt1 = row["ClosingDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldClosingDate.Text = Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Tentative Award Date
            object dt2 = row["AwardDate"];
            if (dt2 == DBNull.Value)
            { }
            else
            { fldAwardDate.Text = Convert.ToDateTime(row["AwardDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Proposal For Review
            object fn1 = row["ProposalForReview"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                lblFileNameP_Empty.Visible = false;
            }
            else
            {
                lblFileNameP.Visible = true;
                lblFileNameP.Text = row["ProposalForReview"].ToString();
            }

            //Proposal To Be Reviewed By
            object dt3 = row["ReviewedByDate"];
            if (dt3 == DBNull.Value)
            { }
            else
            { fldReviewedByDate.Text = Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Technical Approval Required? 
            fldTechnicalRequired.Text = row["TechnicalRequired"].ToString();

            if (row["TechnicalRequired"].ToString() == "Yes")
            {
                tblTechnicalApproval.Visible = true;
                lblTechnicalApp.Visible = false;
            }
            else
            {
                tblTechnicalApproval.Visible = false;
                lblTechnicalApp.Visible = true;
            }

            //Justification
            fldTechnicalJustification.Text = row["TechnicalJustification"].ToString();

            //...................................Technical Approval...................................
            //Reviewer - Name
            fldTechnicalReviewer.Text = row["TechnicalReviewer"].ToString();

            //Reviewer - Date Reviewed 
            object dtTR = row["TechnicalRevDate"];
            object dtTNR = row["TechnicalNotRevDate"];
            if (dtTR != DBNull.Value)
            {
                lblTechnical_ReviewedDate.Text = Convert.ToDateTime(row["TechnicalRevDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtTNR != DBNull.Value)
            {
                lblTechnical_ReviewedDate.Text = Convert.ToDateTime(row["TechnicalNotRevDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblTechnical_ReviewedDate.Text = "-";
            }

            //Reviewer - Status 
            if (row["TechnicalRevStatus"].ToString() != "")
            { lblTechnical_ReviewedStatus.Text = row["TechnicalRevStatus"].ToString(); }
            else
            { lblTechnical_ReviewedStatus.Text = "-"; }

            //Reviewer - Comment
            if (row["TechnicalRevComment"].ToString() != "")
            { lblTechnical_ReviewedComment.Text = row["TechnicalRevComment"].ToString(); }
            else
            { lblTechnical_ReviewedComment.Text = "-"; }

            //Approver - Name
            fldTechnicalApprover.Text = row["TechnicalApprover"].ToString();

            //Approver - Date Approved 
            object dtTA = row["TechnicalAppDate"];
            object dtTNA = row["TechnicalNotAppDate"];
            if (dtTA != DBNull.Value)
            {
                lblTechnical_ApprovedDate.Text = Convert.ToDateTime(row["TechnicalAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtTNA != DBNull.Value)
            {
                lblTechnical_ApprovedDate.Text = Convert.ToDateTime(row["TechnicalNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblTechnical_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["TechnicalAppStatus"].ToString() != "")
            { lblTechnical_ApprovedStatus.Text = row["TechnicalAppStatus"].ToString(); }
            else
            { lblTechnical_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["TechnicalAppComment"].ToString() != "")
            { lblTechnical_ApprovedComment.Text = row["TechnicalAppComment"].ToString(); }
            else
            { lblTechnical_ApprovedComment.Text = "-"; }
            //...................................end of Technical Approval...................................

            //Commercial Approval Required?
            fldCommercialRequired.Text = row["CommercialRequired"].ToString();

            if (row["CommercialRequired"].ToString() == "Yes")
            {
                tblCommercialApproval.Visible = true;
                lblCommercialApp.Visible = false;
            }
            else
            {
                tblCommercialApproval.Visible = false;
                lblCommercialApp.Visible = true;
            }

            //Justification
            fldCommercialJustification.Text = row["CommercialJustification"].ToString();

            //...................................Commercial Approval...................................
            //Reviewer - Name
            fldCommercialReviewer.Text = row["CommercialReviewer"].ToString();

            //Reviewer - Date Reviewed 
            object dtCR = row["CommercialRevDate"];
            object dtCNR = row["CommercialNotRevDate"];
            if (dtCR != DBNull.Value)
            {
                lblCommercial_ReviewedDate.Text = Convert.ToDateTime(row["CommercialRevDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtCNR != DBNull.Value)
            {
                lblCommercial_ReviewedDate.Text = Convert.ToDateTime(row["CommercialNotRevDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblCommercial_ReviewedDate.Text = "-";
            }

            //Reviewer - Status 
            if (row["CommercialRevStatus"].ToString() != "")
            { lblCommercial_ReviewedStatus.Text = row["CommercialRevStatus"].ToString(); }
            else
            { lblCommercial_ReviewedStatus.Text = "-"; }

            //Reviewer - Comment
            if (row["CommercialRevComment"].ToString() != "")
            { lblCommercial_ReviewedComment.Text = row["CommercialRevComment"].ToString(); }
            else
            { lblCommercial_ReviewedComment.Text = "-"; }

            //Approver - Name
            fldCommercialApprover.Text = row["CommercialApprover"].ToString();

            //Approver - Date Approved 
            object dtCA = row["CommercialAppDate"];
            object dtCNA = row["CommercialNotAppDate"];
            if (dtCA != DBNull.Value)
            {
                lblCommercial_ApprovedDate.Text = Convert.ToDateTime(row["CommercialAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtCNA != DBNull.Value)
            {
                lblCommercial_ApprovedDate.Text = Convert.ToDateTime(row["CommercialNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblCommercial_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["CommercialAppStatus"].ToString() != "")
            { lblCommercial_ApprovedStatus.Text = row["CommercialAppStatus"].ToString(); }
            else
            { lblCommercial_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["CommercialAppComment"].ToString() != "")
            { lblCommercial_ApprovedComment.Text = row["CommercialAppComment"].ToString(); }
            else
            { lblCommercial_ApprovedComment.Text = "-"; }
            //...................................end of Commercial Approval...................................

            //Legal / Risk Approval Required?
            fldLegalRequired.Text = row["LegalRequired"].ToString();

            if (row["LegalRequired"].ToString() == "Yes")
            {
                tblLegalApproval.Visible = true;
                lblLegalApp.Visible = false;
            }
            else
            {
                tblLegalApproval.Visible = false;
                lblLegalApp.Visible = true;
            }

            //Legal / Risk
            fldLegalJustification.Text = row["LegalJustification"].ToString();

            //...................................Legal / Risk Approval...................................
            //Reviewer - Name
            fldLegalReviewer.Text = row["LegalReviewer"].ToString();

            //Reviewer - Date Reviewed 
            object dtLR = row["LegalRevDate"];
            object dtLNR = row["LegalNotRevDate"];
            if (dtLR != DBNull.Value)
            {
                lblLegal_ReviewedDate.Text = Convert.ToDateTime(row["LegalRevDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtLNR != DBNull.Value)
            {
                lblLegal_ReviewedDate.Text = Convert.ToDateTime(row["LegalNotRevDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblLegal_ReviewedDate.Text = "-";
            }

            //Reviewer - Status 
            if (row["LegalRevStatus"].ToString() != "")
            { lblLegal_ReviewedStatus.Text = row["LegalRevStatus"].ToString(); }
            else
            { lblLegal_ReviewedStatus.Text = "-"; }

            //Reviewer - Comment
            if (row["LegalRevComment"].ToString() != "")
            { lblLegal_ReviewedComment.Text = row["LegalRevComment"].ToString(); }
            else
            { lblLegal_ReviewedComment.Text = "-"; }

            //Approver - Name
            fldLegalApprover.Text = row["LegalApprover"].ToString();

            //Approver - Date Approved 
            object dtLA = row["LegalAppDate"];
            object dtLNA = row["LegalNotAppDate"];
            if (dtLA != DBNull.Value)
            {
                lblLegal_ApprovedDate.Text = Convert.ToDateTime(row["LegalAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else if (dtLNA != DBNull.Value)
            {
                lblLegal_ApprovedDate.Text = Convert.ToDateTime(row["LegalNotAppDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
            }
            else
            {
                lblLegal_ApprovedDate.Text = "-";
            }

            //Approver - Status 
            if (row["LegalAppStatus"].ToString() != "")
            { lblLegal_ApprovedStatus.Text = row["LegalAppStatus"].ToString(); }
            else
            { lblLegal_ApprovedStatus.Text = "-"; }

            //Approver - Comment
            if (row["LegalAppComment"].ToString() != "")
            { lblLegal_ApprovedComment.Text = row["LegalAppComment"].ToString(); }
            else
            { lblLegal_ApprovedComment.Text = "-"; }
            //...................................end of Legal / Risk Approval...................................

            //Signed Proposal
            object fn2 = row["SignedProposal"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                lblFileNameSP_Empty.Visible = false;
            }
            else
            {
                lblFileNameSP.Visible = true;
                lblFileNameSP.Text = row["SignedProposal"].ToString();
            }

            //DAL Approver
            //...................................DAL Approval...................................
            lblDALApprover.Text = row["DALName"].ToString();

            //Date Approved
            object dt8 = row["DALAppDate1"];
            if (dt8 == DBNull.Value)
            {
                lblDtApproved.Text = "Pending";
                lblDtApproved.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else
            { lblDtApproved.Text = Convert.ToDateTime(row["DALAppDate1"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Date Rejected
            object dt9 = row["DALNotAppDate1"];
            if (dt9 == DBNull.Value)
            {
                lblDtReject.Text = "Pending";
                lblDtReject.ForeColor = System.Drawing.Color.FromName("Red");
            }
            else if (dt9 != DBNull.Value)
            {
                lblDtReject.Text = Convert.ToDateTime(row["DALNotAppDate1"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");

                //Justification
                fldJustification.Text = row["DALAppComment1"].ToString();
            }

            //...................................end of DAL Approval...................................

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

        }
    }


    protected void btnApprove_Click(object sender, EventArgs e)
    {
        //Update in table tblProposalEvaluation
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        DateTime now = DateTime.Now;

        if (lblDALApprover.Text != "")
        {
            SqlCommand cmdR = new SqlCommand("UPDATE tblProposalEvaluation SET "
                    + "DALAppStatus1 = 'Approved', "
                    + "DALAppDate1 = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

            cmdR.ExecuteNonQuery();
        }

        con.Close();

        //Email notification to Project Manager
        //---------------------------------------- send email -----------------------------------------        
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
        qs = qs + "               tblProposalEvaluation.ProposalForReview, tblProposalEvaluation.ClosingDate, tblProposalEvaluation.ReviewedByDate, ";
        qs = qs + "               tblClient.ClientName AS ClientName, ";
        qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
        qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
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
        client.Host = "smtp.uemedgenta.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user", "Password");

        objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

        //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

        objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

        objeto_mail.Subject = "Approved : Request for DAL Approval for '" + row["Description"].ToString() + "'";

        string htmlText = "<HTML><BODY BGCOLOR=#FFFFE6 STYLE=FONT:TAHOMA,8PT;>"
                            + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                            + "Your signed proposal for the following opportunity has been approved by DAL person (COO).<BR><BR><BR>"

                            + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                            + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                            + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                            + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                            + "<B>Proposal Closing Date : </B>" + Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                            + "<B>Proposal To Be Reviewed By : </B>" + Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR><BR>"

                            + "<BR><BR><BR>Thank you.<BR><BR>"
                            + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

        objeto_mail.Body = htmlText;
        objeto_mail.IsBodyHtml = true;

        client.Send(objeto_mail);
        //---------------------------------- end of send email ----------------------------------------

        //Update in table tblMain
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
        //        + "Phase = 'Proposal Close', "
        //        + "ModifyBy = '" + Session["UserID"].ToString() + "', "
        //        + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
        //        + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        SqlCommand cmdMain = new SqlCommand("UPDATE tblMain SET "
                + "Phase = 'Proposal Close' "
                + "WHERE Id = '" + Request.QueryString["Id"] + "' ", con);

        cmdMain.ExecuteNonQuery();
        
        //Check if this project already exist in tblProposalClose
        qs = "";
        qs = qs + " SELECT        DescriptionId ";
        qs = qs + " FROM          tblProposalClose ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";

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
            //Insert into table tblProposalClose
            qs1 = "";
            qs1 = qs1 + " INSERT INTO   tblProposalClose ";
            qs1 = qs1 + "               (DescriptionId, DateCreated) ";
            qs1 = qs1 + " VALUES        (@pDescriptionId, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs1, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["Id"]);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        //Redirect to update page
        Response.Redirect("ApprovalSignedProposal_DALCOO.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnNotApprove_Click(object sender, EventArgs e)
    {
        Boolean chckErr = true;

        //Reset error
        dvJustification.Attributes.Add("class", null);

        if (fldJustification.Text.Trim() == "")
        {
            chckErr = false;
            dvJustification.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Update in table tblProposalEvaluation
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            DateTime now = DateTime.Now;

            if (lblDALApprover.Text != "")
            {
                SqlCommand cmdNR = new SqlCommand("UPDATE tblProposalEvaluation SET "
                    + "DALAppStatus1 = 'Rejected', "
                    + "DALNotAppDate1 = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', "
                    + "DALAppComment1 = @pJustification "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

                //Justification
                cmdNR.Parameters.AddWithValue("@pJustification", fldJustification.Text.Trim());

                cmdNR.ExecuteNonQuery();
            }

            con.Close();

            //Email notification to Project Manager
            //---------------------------------------- send email -----------------------------------------        
            qs = "";
            qs = qs + " SELECT        tblMain.Id, tblMain.ClientId, tblMain.Description, tblMain.Code, tblMain.ProjectManager, tblMain.OperatingCompany, tblMain.OperatingUnit, tblMain.CreatedBy, ";
            qs = qs + "               tblProposalEvaluation.ProposalForReview, tblProposalEvaluation.ClosingDate, tblProposalEvaluation.ReviewedByDate, tblProposalEvaluation.DALApprovedBy_COO, tblProposalEvaluation.DALAppComment, ";
            qs = qs + "               tblClient.ClientName AS ClientName, ";
            qs = qs + "               StaffLogin.StaffName AS PMName, StaffLogin.EmailId AS PMEmail, ";
            qs = qs + "               StaffLogin_1.StaffName AS DALName ";
            qs = qs + " FROM          tblMain ";
            qs = qs + "               INNER JOIN tblClient ON tblMain.ClientId = tblClient.Id ";
            qs = qs + "               INNER JOIN tblProposalEvaluation ON tblMain.Id = tblProposalEvaluation.DescriptionId ";
            qs = qs + "               INNER JOIN StaffLogin AS StaffLogin_1 ON  tblProposalEvaluation.DALApprovedBy_COO = StaffLogin_1.StaffNo COLLATE Latin1_General_CI_AI ";
            qs = qs + "               INNER JOIN StaffLogin ON tblMain.ProjectManager = StaffLogin.StaffNo COLLATE Latin1_General_CI_AI ";
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
            client.Host = "smtp.uemedgenta.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("user", "Password");

            objeto_mail.From = new MailAddress("noreply@pec.uemedgenta.com", "UEM Edgenta Berhad - Project Execution Control");

            //objeto_mail.To.Add(new MailAddress(row["PMEmail"].ToString()));

            objeto_mail.Bcc.Add(new MailAddress("aida.nazri@edgenta.com"));

            objeto_mail.Subject = "Rejected : Request for DAL Approval for '" + row["Description"].ToString() + "'";

            string htmlText = "<HTML><BODY BGCOLOR=#FFECEC STYLE=FONT:TAHOMA,8PT;>"
                                + "Hi " + row["PMName"].ToString() + ",<BR><BR><BR>"

                                + "Your request for the following opportunity is rejected. Please read the justification by DAL Approver below.<BR><BR><BR>"

                                + "<B>Operating Company : </B>" + row["OperatingCompany"].ToString() + "<BR><BR>"
                                + "<B>Opportunity Name : </B>" + row["Description"].ToString() + "<BR><BR>"
                                + "<B>Client Name : </B>" + row["ClientName"].ToString() + "<BR><BR>"
                                + "<B>Project Manager : </B>" + row["PMName"].ToString() + "<BR><BR>"
                                + "<B>Proposal Closing Date : </B>" + Convert.ToDateTime(row["ClosingDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                                + "<B>Proposal To Be Reviewed By : </B>" + Convert.ToDateTime(row["ReviewedByDate"].ToString()).ToString("dd-MMM-yyyy") + "<BR><BR>"
                                + "<B>DAL Approver : </B>" + row["DALName"].ToString() + "<BR><BR>"
                                + "<B>Justification : </B>" + row["DALAppComment1"].ToString() + "<BR><BR><BR>"

                                + "<BR><BR><BR>Thank you.<BR><BR>"
                                + "This is a Project Execution Control system-generated message. Please do not reply.</BODY></HTML>";

            objeto_mail.Body = htmlText;
            objeto_mail.IsBodyHtml = true;

            client.Send(objeto_mail);
            //---------------------------------- end of send email ----------------------------------------

            //Redirect to update page
            Response.Redirect("ApprovalSignedProposal_DALCOO.aspx?Id=" + Request.QueryString["Id"]);
        }
    }


    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
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