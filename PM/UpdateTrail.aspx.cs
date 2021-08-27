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

public partial class UpdateTrail : System.Web.UI.Page
{
    DataRow row = null;
    DataRow row1 = null;
    DataRow rowCSS = null;
    String qs = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            //Hide all upload
            dvUpA1Sec.Visible = true;
            dvVwA1Sec.Visible = false;

            dvUpA2Sec.Visible = true;
            dvVwA2Sec.Visible = false;

            dvUpA3Sec.Visible = true;
            dvVwA3Sec.Visible = false;

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");

            bindAuditType();
            //bindAuditor();
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

    //protected void bindAuditor()
    //{
    //    // Bind data to the dropdownlist control.
    //    qs = "";
    //    qs = qs + " SELECT        StaffNo, StaffName ";
    //    qs = qs + " FROM          StaffLogin ";
    //    qs = qs + " WHERE         Role = 'Auditor' ";
    //    qs = qs + " ORDER BY      StaffName ";

    //    fldAuditor.DataSource = GetData(qs);
    //    fldAuditor.DataTextField = "StaffName";
    //    fldAuditor.DataValueField = "StaffNo";
    //    fldAuditor.DataBind();
    //    fldAuditor.Items.Insert(0, new ListItem("-- Please select one --", ""));
    //}

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
        fldStatusClosure.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldStatusClosure.Items.Insert(1, new ListItem("Open", "Open"));
        fldStatusClosure.Items.Insert(2, new ListItem("Closed", "Closed"));
    }

    protected void bindDetails()
    {
        DateTime now = DateTime.Now;

        qs = "";
        qs = qs + " SELECT        tblMain.ProjectCode, tblAuditTrail.*, tblCREATEBY.StaffName As AuditorName  ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " INNER JOIN          tblAuditTrail ON tblMain.Id = tblAuditTrail.DescriptionId ";
        qs = qs + " LEFT JOIN      AllStaffDetails As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblAuditTrail.Auditor COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";
        qs = qs + " AND           tblAuditTrail.Id = '" + Request.QueryString["Id1"] + "' ";


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

            //Audit Type
            fldAuditType.Text = row["AuditType"].ToString();

            //Auditor
            fldAuditor.Text = row["AuditorName"].ToString();
            
            //Audit Date
            object dt2 = row["AuditDate"];
            if (dt2 == DBNull.Value)
            { fldAuditDate.Text = "-"; }
            else
            { fldAuditDate.Text = Convert.ToDateTime(row["AuditDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Audit No 
            fldAuditNo.Text = row["AuditNo"].ToString();

            //--------------------------------------- Audit Memo ---------------------------------------
            //Audit Memo
            object fn = row["AuditMemo"];
            if (fn == DBNull.Value || fn == "")
            {
                dvUpA1Sec.Visible = true;
                dvVwA1Sec.Visible = false;
            }
            else
            {
                dvUpA1Sec.Visible = false;
                dvVwA1Sec.Visible = true;

                lblURLA1.Text = row["AuditMemo"].ToString();
                hidURLA1.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/AuditMemo/" + row["AuditMemo"].ToString() + "";
            }

            //Findings
            fldFindings.Text = row["Findings"].ToString();

            //--------------------------------------- Findings Attachment ---------------------------------------
            //Findings Attachment
            object fn1 = row["FindingsAttachment"];
            if (fn1 == DBNull.Value || fn1 == "")
            {
                dvUpA2Sec.Visible = true;
                dvVwA2Sec.Visible = false;
            }
            else
            {
                dvUpA2Sec.Visible = false;
                dvVwA2Sec.Visible = true;

                lblURLA2.Text = row["FindingsAttachment"].ToString();
                hidURLA2.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/FindingsAttachment/" + row["FindingsAttachment"].ToString() + "";
            }

            //Description of Findings
            fldFindingsDescription.Text = row["FindingsDescription"].ToString();

            //--------------------------------------- Audit Report ---------------------------------------
            //Audit Report
            object fn2 = row["AuditReport"];
            if (fn2 == DBNull.Value || fn2 == "")
            {
                dvUpA3Sec.Visible = true;
                dvVwA3Sec.Visible = false;
            }
            else
            {
                dvUpA3Sec.Visible = false;
                dvVwA3Sec.Visible = true;

                lblURLA3.Text = row["AuditReport"].ToString();
                hidURLA3.Value = "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/AuditReport/" + row["AuditReport"].ToString() + "";
            }

            //Corrective Action Completion Date
            object dt3 = row["CompletionDateReq"];
            if (dt3 == DBNull.Value)
            { fldCompletionDateReq.Text = "-"; }
            else
            { fldCompletionDateReq.Text = Convert.ToDateTime(row["CompletionDateReq"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Status Closure
            fldStatusClosure.Text = row["StatusClosure"].ToString();

            //Remarks
            fldRemarks.Text = row["Remarks"].ToString();

            //Remarks Date
            object dt4 = row["RemarksDate"];
            if (dt4 == DBNull.Value)
            { fldRemarksDate.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt"); }
            else
            { fldRemarksDate.Text = Convert.ToDateTime(row["RemarksDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            if (row["AuditMemo"].ToString() != "")
            {
                fldA1Upload.Enabled = false;
                btnCancelA1.Enabled = false;
                btnUpA1.Enabled = false;
                btnDeleteA1.Visible = false;
            }

            if (row["FindingsAttachment"].ToString() != "")
            {
                fldA2Upload.Enabled = false;
                btnCancelA2.Enabled = false;
                btnUpA2.Enabled = false;
                btnDeleteA2.Visible = false;
            }

            if (row["AuditReport"].ToString() != "")
            {
                fldA3Upload.Enabled = false;
                btnCancelA3.Enabled = false;
                btnUpA3.Enabled = false;
                btnDeleteA3.Visible = false;
            }            

            //DateTime varDt;

            ////Created By
            //if (row["CreatedBy"].ToString() != "")
            //{
            //    lblCreatedBy.Text = row["CREATEBYName"].ToString();
            //}
            //else
            //    lblCreatedBy.Text = "-";

            ////Created Date
            //object dt6 = row["DateCreated"];
            //if (dt6 == DBNull.Value)
            //{ lblCreatedDt.Text = "-"; }
            //else
            //{ lblCreatedDt.Text = Convert.ToDateTime(row["DateCreated"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            ////Modified By 
            //if (row["ModifyBy"].ToString() != "")
            //{
            //    lblLastUpdate.Text = row["UPDATEBYName"].ToString();
            //}
            //else
            //    lblLastUpdate.Text = "-";

            ////Modified Date
            //object dt7 = row["DateModify"];
            //if (dt7 == DBNull.Value)
            //{ lblLastUpdateDt.Text = "-"; }
            //else
            //{ lblLastUpdateDt.Text = Convert.ToDateTime(row["DateModify"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

        }
    }

    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateTrail();

        Response.Redirect("AuditTrail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuditTrail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void updateTrail()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
                
        SqlCommand cmd = new SqlCommand("UPDATE tblAuditTrail SET "
            + "AuditType = @pAuditType,"
            + "AuditDate = @pAuditDate,"
            + "AuditNo = @pAuditNo,"
            + "Findings = @pFindings,"
            + "FindingsDescription = @pFindingsDescription,"
            + "CompletionDateReq = @pCompletionDateReq,"
            + "StatusClosure = @pStatusClosure,"
            + "Remarks = @pRemarks,"
            + "RemarksDate = @pRemarksDate,"
            + "ModifyBy = @pModifyBy, "
            + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
            + "WHERE Id = '" + Request.QueryString["Id1"] + "'", con);

        //Audit Type
        cmd.Parameters.AddWithValue("@pAuditType", fldAuditType.SelectedValue);

        //Auditor
        //cmd.Parameters.AddWithValue("@pAuditor", fldAuditor.SelectedValue);

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

        //Remarks
        cmd.Parameters.AddWithValue("@pRemarks", fldRemarks.Text.Trim());

        //Remarks Date 
        cmd.Parameters.AddWithValue("@pRemarksDate", fldRemarksDate.Text);

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void btnUpA1_Click(object sender, EventArgs e)
    {
        //Audit Memo
        String pathfolder = "Upload/";
        String filenameStr = fldA1Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["ID1"] + "/AuditMemo";

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
                qs = qs + "UPDATE tblAuditTrail SET AuditMemo = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "' AND Id = '" + Request.QueryString["ID1"] + "'";

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
        //Audit Memo
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblAuditTrail SET AuditMemo = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "' AND Id = '" + Request.QueryString["ID1"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A1");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/AuditMemo/" + lblURLA1.Text + "";

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
        //Audit Memo
        Response.Write("<script> window.open( '" + hidURLA1.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA2_Click(object sender, EventArgs e)
    {
        //Findings Attachment
        String pathfolder = "Upload/";
        String filenameStr = fldA2Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["ID1"] + "/FindingsAttachment";

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
                qs = qs + "UPDATE tblAuditTrail SET FindingsAttachment = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "' AND Id = '" + Request.QueryString["ID1"] + "'";

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
        //Findings Attachment
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblAuditTrail SET FindingsAttachment = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "' AND Id = '" + Request.QueryString["ID1"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A2");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/FindingsAttachment/" + lblURLA2.Text + "";

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
        //Findings Attachment
        Response.Write("<script> window.open( '" + hidURLA2.Value.ToString() + "','_blank' ); </script>");
    }

    protected void btnUpA3_Click(object sender, EventArgs e)
    {
        //Audit Report
        String pathfolder = "Upload/";
        String filenameStr = fldA3Upload.FileName;

        //Check path folder
        pathfolder = "Upload/" + Request.QueryString["Id"] + "/" + Request.QueryString["ID1"] + "/AuditReport";

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
                qs = qs + "UPDATE tblAuditTrail SET AuditReport = @patt_filename WHERE DescriptionId = '" + Request.QueryString["ID"] + "' AND Id = '" + Request.QueryString["ID1"] + "'";

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
        //Audit Report
        //Update table
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        SqlCommand cmd = new SqlCommand("", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.DeleteCommand = new SqlCommand("UPDATE tblAuditTrail SET AuditReport = NULL WHERE DescriptionId = '" + Request.QueryString["ID"] + "' AND Id = '" + Request.QueryString["ID1"] + "'", con);
        da.DeleteCommand.Parameters.AddWithValue("@patt_filetype", "A3");
        da.DeleteCommand.ExecuteNonQuery();
        con.Close();

        //Delete file
        string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/AuditReport/" + lblURLA3.Text + "";

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
        //Audit Report
        Response.Write("<script> window.open( '" + hidURLA3.Value.ToString() + "','_blank' ); </script>");
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