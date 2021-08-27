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

public partial class ProposalCloseDetailView : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qsId = "";
    String qsCommittee = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
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
            //Hide all upload
            dvUpA1Sec.Visible = true;
            dvVwA1Sec.Visible = false;

            dvUpA2Sec.Visible = true;
            dvVwA2Sec.Visible = false;

            //Bind dropdownlist
            bindResult();
            bindMargin();

            checkRole();

            if (lblRole.Text == "QHSE")
            {
                dvInactive.Visible = true;
                dvActive.Visible = false;
            }
            else
            {

                bindDetails();

                //Display opportunity details 
                qs = "";
                qs = qs + " SELECT        Description, Code ";
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

                //Display signed proposal 
                qs = "";
                qs = qs + " SELECT        SignedProposal ";
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
                }
                else
                {
                    DataRow row = dt2.Rows[0];

                    object fn = row["SignedProposal"];
                    if (fn == DBNull.Value || fn == "")
                    {
                        lblFileNameSP.Visible = false;
                    }
                    else
                    {
                        lblFileNameSP.Visible = true;
                        lblFileNameSP.Text = row["SignedProposal"].ToString();
                    }
                }
            }
        }
    }

    public void checkRole()
    {
        qs = "";
        qs = qs + " SELECT          StaffNo, Role ";
        qs = qs + " FROM            StaffLogin ";
        qs = qs + " WHERE           StaffNo = '" + Session["UserID"] + "' ";
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
            //No record
        }
        else
        {
            row = null;
            row = dt.Rows[0];

            lblRole.Text = row["Role"].ToString();

        }
    }


    protected void bindResult()
    {
        // Bind data to the dropdownlist control.
        fldResult.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldResult.Items.Insert(1, new ListItem("Win", "Win"));
        fldResult.Items.Insert(2, new ListItem("Lose", "Lose"));
    }

    protected void bindMargin()
    {
        // Bind data to the dropdownlist control.
        fldMargin.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldMargin.Items.Insert(1, new ListItem("Over", "Over"));
        fldMargin.Items.Insert(2, new ListItem("Below", "Below"));
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }


    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblProposalClose.*,  ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblProposalClose ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalClose.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblProposalClose.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         tblProposalClose.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //Result
            fldResult.Text = row["Result"].ToString();

            //Proposal Status
            if (row["Status"].ToString() == "" || row["Status"].ToString() == null)
            {
                lblStatus.Text = "Open";
            }
            else
            {
                lblStatus.Text = row["Status"].ToString();
            }

            //--------------------------------------- Post Mortem ---------------------------------------
            //Client Feedback
            fldClientFeedback.Text = row["ClientFeedback"].ToString();

            //Reason Win / Lose
            fldReasonResult.Text = row["ReasonResult"].ToString();

            //--------------------------------------- Client Feedback Form ---------------------------------------
            object fn = row["FeedbackForm"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["FeedbackForm"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/FeedbackForm/" + row["FeedbackForm"].ToString() + "";
            }

            //Win / Lose Margin
            object dta = row["ResultMargin"];
            if (dta == DBNull.Value)
            { }
            else
            { fldResultMargin.Text = row["ResultMargin"].ToString(); }

            fldMargin.Text = row["Margin"].ToString();

            //Lesson Learnt
            fldLessonLearnt.Text = row["LessonLearnt"].ToString();

            //--------------------------------------- Contract / LOA ---------------------------------------
            object fn1 = row["ContractLOA"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["ContractLOA"].ToString();
                hidURLA2.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/LOA/" + row["ContractLOA"].ToString() + "";
            }

            //If None, Justification
            fldJustification.Text = row["Justification"].ToString();

            //Expected Contract / LOA To Be Obtained
            object dt1 = row["ContractLOAExpDate"];
            if (dt1 == DBNull.Value)
            { }
            else
            { fldContractLOAExpDate.Text = Convert.ToDateTime(row["ContractLOAExpDate"].ToString()).ToString("dd-MMM-yyyy"); }
                                    
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
                fldA1Upload.Enabled = true;
                btnCancelA1.Enabled = true;
                btnUpA1.Enabled = true;
                btnDeleteA1.Visible = true;

                fldA2Upload.Enabled = true;
                btnCancelA2.Enabled = true;
                btnUpA2.Enabled = true;
                btnDeleteA2.Visible = true;
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
            }
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

    protected void btnUpA1_Click(object sender, EventArgs e)
    {
        //Client Feedback Form
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/FeedbackForm";

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
                qs = qs + "UPDATE  tblProposalClose SET FeedbackForm = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
        //Client Feedback Form
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalClose SET FeedbackForm = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/FeedbackForm/" + lblURLA1.Text + "";

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
        //Client Feedback Form
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA2_Click(object sender, EventArgs e)
    {
        //Contract / LOA
        String pathfolder = "Upload/";
        String filenameStr = fldA2Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/LOA";

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
                qs = qs + "UPDATE  tblProposalClose SET ContractLOA = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "'";

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
        //Contract / LOA
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblProposalClose SET ContractLOA = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A2");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/LOA/" + lblURLA2.Text + "";

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
        //Contract / LOA
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }

}