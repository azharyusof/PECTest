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

public partial class SiteVisitHSEEAIDetailViewHSE : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String queryString = "";
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
            bindEIA();
            bindDOE();
            bindEMP();
            bindCAI();
            bindOPUS();

            bindDetails();
        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
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

    private void bindEIA()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblEnvAspectImpact "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'EIA' "
            + "ORDER BY       Id DESC ";

        gvEIA.DataSource = GetData(str);
        gvEIA.DataBind();

        for (int i = 0; i < gvEIA.Rows.Count; i++)
        {
            GridViewRow row = gvEIA.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    private void bindDOE()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblEnvAspectImpact "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'DOE' "
            + "ORDER BY       Id DESC ";

        gvDOE.DataSource = GetData(str);
        gvDOE.DataBind();

        for (int i = 0; i < gvDOE.Rows.Count; i++)
        {
            GridViewRow row = gvDOE.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    private void bindEMP()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblEnvAspectImpact "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'EMP' "
            + "ORDER BY       Id DESC ";

        gvEMP.DataSource = GetData(str);
        gvEMP.DataBind();

        for (int i = 0; i < gvEMP.Rows.Count; i++)
        {
            GridViewRow row = gvEMP.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    private void bindCAI()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblEnvAspectImpact "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'CAI' "
            + "ORDER BY       Id DESC ";

        gvCAI.DataSource = GetData(str);
        gvCAI.DataBind();

        for (int i = 0; i < gvCAI.Rows.Count; i++)
        {
            GridViewRow row = gvCAI.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    private void bindOPUS()
    {
        String str;

        //str = "SELECT         * "
        //    + "FROM           tblEnvAspectImpact "
        //    + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
        //    + "AND            Category = 'OPUS' "
        //    + "ORDER BY       Id DESC ";

        str = "SELECT         tblEnvAspectImpact.*, "
            + "               tblCREATEBY.StaffName As CREATEBYName  "
            + "FROM           tblEnvAspectImpact "
            + "LEFT JOIN      StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblEnvAspectImpact.CreatedBy COLLATE DATABASE_DEFAULT "
            + "WHERE          tblEnvAspectImpact.DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            tblEnvAspectImpact.Category = 'OPUS' "
            + "ORDER BY       tblEnvAspectImpact.Id DESC ";

        gvOPUS.DataSource = GetData(str);
        gvOPUS.DataBind();

        for (int i = 0; i < gvOPUS.Rows.Count; i++)
        {
            GridViewRow row = gvOPUS.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
            }
        }
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
            //Insert into table tblEnvAspectImpact
            queryString = "";
            queryString = queryString + " INSERT INTO   tblEnvAspectImpact ";
            queryString = queryString + "               (DescriptionId, Category, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, 'EIA', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            //cmd.Parameters.AddWithValue("@pFileName", fldFileName.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //EIA Report
            uploadEIA();

            //bindEIA();
            Response.Redirect("SiteVisitHSEEAIDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadEIA()
    {
        //if (fldFileName.FileName != "")
        //{
        //Update EIA Report
        SqlCommand cmdFile = new SqlCommand("UPDATE tblEnvAspectImpact SET "
                + "FileName = @pFileName "
                + "WHERE FileName IS NULL "
                + "AND Category = 'EIA' "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/EIA/";

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
        //}
    }

    protected void btnCloseE_Click(object sender, EventArgs e)
    {
    }
    
    protected void btnSaveF_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileNameDOE.Attributes.Add("class", null);

        if (fldFileNameDOE.FileName == "")
        {
            chckErr = false;
            dvFileNameDOE.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblEnvAspectImpact
            queryString = "";
            queryString = queryString + " INSERT INTO   tblEnvAspectImpact ";
            queryString = queryString + "               (DescriptionId, Category, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, 'DOE', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            //cmd.Parameters.AddWithValue("@pFileName", fldFileName.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //Conditional Approval From DOE 
            uploadDOE();

            //bindDOE();
            Response.Redirect("SiteVisitHSEEAIDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadDOE()
    {
        //if (fldFileNameDOE.FileName != "")
        //{
        //Update Conditional Approval From DOE 
        SqlCommand cmdFile = new SqlCommand("UPDATE tblEnvAspectImpact SET "
                + "FileName = @pFileName "
                + "WHERE FileName IS NULL "
                + "AND Category = 'DOE' "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/DOE/";

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    if (System.IO.Path.GetExtension(fldFileNameDOE.PostedFile.FileName) == ".exe")
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
                    if (System.IO.Path.GetExtension(fldFileNameDOE.PostedFile.FileName) == ".exe")
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
        foreach (HttpPostedFile postedFile in fldFileNameDOE.PostedFiles)
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
        //}
    }

    protected void btnCloseF_Click(object sender, EventArgs e)
    {
    }


    protected void btnSaveG_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileNameEMP.Attributes.Add("class", null);

        if (fldFileNameEMP.FileName == "")
        {
            chckErr = false;
            dvFileNameEMP.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblEnvAspectImpact
            queryString = "";
            queryString = queryString + " INSERT INTO   tblEnvAspectImpact ";
            queryString = queryString + "               (DescriptionId, Category, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, 'EMP', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            //cmd.Parameters.AddWithValue("@pFileName", fldFileName.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //EMP (Environmental Management Plan) 
            uploadEMP();

            //bindEMP();
            Response.Redirect("SiteVisitHSEEAIDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadEMP()
    {
        //if (fldFileNameEMP.FileName != "")
        //{
        //Update EMP (Environmental Management Plan) 
        SqlCommand cmdFile = new SqlCommand("UPDATE tblEnvAspectImpact SET "
                + "FileName = @pFileName "
                + "WHERE FileName IS NULL "
                + "AND Category = 'EMP' "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/EMP/";

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    if (System.IO.Path.GetExtension(fldFileNameEMP.PostedFile.FileName) == ".exe")
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
                    if (System.IO.Path.GetExtension(fldFileNameEMP.PostedFile.FileName) == ".exe")
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
        foreach (HttpPostedFile postedFile in fldFileNameEMP.PostedFiles)
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
        //}
    }

    protected void btnCloseG_Click(object sender, EventArgs e)
    {
    }


    protected void btnSaveH_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileNameCAI.Attributes.Add("class", null);

        if (fldFileNameCAI.FileName == "")
        {
            chckErr = false;
            dvFileNameCAI.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblEnvAspectImpact
            queryString = "";
            queryString = queryString + " INSERT INTO   tblEnvAspectImpact ";
            queryString = queryString + "               (DescriptionId, Category, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, 'CAI', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            //cmd.Parameters.AddWithValue("@pFileName", fldFileName.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //Contractor's Aspect & Impact Assessment 
            uploadCAI();

            //bindCAI();
            Response.Redirect("SiteVisitHSEEAIDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadCAI()
    {
        //if (fldFileNameCAI.FileName != "")
        //{
        //Update Contractor's Aspect & Impact Assessment 
        SqlCommand cmdFile = new SqlCommand("UPDATE tblEnvAspectImpact SET "
                + "FileName = @pFileName "
                + "WHERE FileName IS NULL "
                + "AND Category = 'CAI' "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/CAI/";

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    if (System.IO.Path.GetExtension(fldFileNameCAI.PostedFile.FileName) == ".exe")
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
                    if (System.IO.Path.GetExtension(fldFileNameCAI.PostedFile.FileName) == ".exe")
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
        foreach (HttpPostedFile postedFile in fldFileNameCAI.PostedFiles)
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
        //}
    }

    protected void btnCloseH_Click(object sender, EventArgs e)
    {
    }


    protected void btnSaveI_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileNameAIA.Attributes.Add("class", null);
        dvReason.Attributes.Add("class", null);

        if (fldFileNameAIA.FileName == "")
        {
            chckErr = false;
            dvFileNameAIA.Attributes.Add("class", "has-error");
        }

        if (fldReason.Text.Trim() == "")
        {
            chckErr = false;
            dvReason.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblEnvAspectImpact
            queryString = "";
            queryString = queryString + " INSERT INTO   tblEnvAspectImpact ";
            queryString = queryString + "               (DescriptionId, Category, ReasonRevision, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, 'OPUS', @pReasonRevision, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pReasonRevision", fldReason.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();

            //Aspect / Impact Assessment 
            uploadOPUS();

            Response.Redirect("SiteVisitHSEEAIDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadOPUS()
    {
        //if (fldFileNameAIA.FileName != "")
        //{
        //Update Aspect / Impact Assessment 
        SqlCommand cmdFile = new SqlCommand("UPDATE tblEnvAspectImpact SET "
                + "FileName = @pFileName "
                + "WHERE FileName IS NULL "
                + "AND Category = 'OPUS' "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/OPUSEAI/";

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    if (System.IO.Path.GetExtension(fldFileNameAIA.PostedFile.FileName) == ".exe")
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
                    if (System.IO.Path.GetExtension(fldFileNameAIA.PostedFile.FileName) == ".exe")
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
        foreach (HttpPostedFile postedFile in fldFileNameAIA.PostedFiles)
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
        //}
    }

    protected void btnCloseI_Click(object sender, EventArgs e)
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