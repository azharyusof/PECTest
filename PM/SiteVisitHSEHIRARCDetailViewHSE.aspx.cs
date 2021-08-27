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

public partial class SiteVisitHSEHIRARCDetailViewHSE : System.Web.UI.Page
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
            bindHIRARC();
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

    private void bindHIRARC()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblHIRARC "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            Category = 'Contractor' "
            + "ORDER BY       Id DESC ";

        gvHIRARC.DataSource = GetData(str);
        gvHIRARC.DataBind();

        for (int i = 0; i < gvHIRARC.Rows.Count; i++)
        {
            GridViewRow row = gvHIRARC.Rows[i];

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
        //    + "FROM           tblHIRARC "
        //    + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
        //    + "AND            Category = 'OPUS' "
        //    + "ORDER BY       Id DESC ";

        str = "SELECT         tblHIRARC.*, "
            + "               tblCREATEBY.StaffName As CREATEBYName  "
            + "FROM           tblHIRARC "
            + "LEFT JOIN      StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblHIRARC.CreatedBy COLLATE DATABASE_DEFAULT "
            + "WHERE          tblHIRARC.DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "AND            tblHIRARC.Category = 'OPUS' "
            + "ORDER BY       tblHIRARC.Id DESC ";
                
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
            //Insert into table tblHIRARC
            queryString = "";
            queryString = queryString + " INSERT INTO   tblHIRARC ";
            queryString = queryString + "               (DescriptionId, Category, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, 'Contractor', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            //cmd.Parameters.AddWithValue("@pFileName", fldFileName.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            //HIRARC
            uploadHIRARC();

            Response.Redirect("SiteVisitHSEHIRARCDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadHIRARC()
    {
        //if (fldFileName.FileName != "")
        //{
            //Update HIRARC
            SqlCommand cmdFile = new SqlCommand("UPDATE tblHIRARC SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Category = 'Contractor' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/HIRARC/";

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
        dvFileName1.Attributes.Add("class", null);
        dvReason.Attributes.Add("class", null);

        if (fldFileName1.FileName == "")
        {
            chckErr = false;
            dvFileName1.Attributes.Add("class", "has-error");
        }

        if (fldReason.Text.Trim() == "")
        {
            chckErr = false;
            dvReason.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblHIRARC
            queryString = "";
            queryString = queryString + " INSERT INTO   tblHIRARC ";
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

            //HIRARC (OPUS)
            uploadOPUS();

            Response.Redirect("SiteVisitHSEHIRARCDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadOPUS()
    {
        //if (fldFileName1.FileName != "")
        //{
        //Update HIRARC (OPUS)
        SqlCommand cmdFile = new SqlCommand("UPDATE tblHIRARC SET "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/HIRARC_OPUS/";

                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                    if (System.IO.Path.GetExtension(fldFileName1.PostedFile.FileName) == ".exe")
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
                    if (System.IO.Path.GetExtension(fldFileName1.PostedFile.FileName) == ".exe")
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
        foreach (HttpPostedFile postedFile in fldFileName1.PostedFiles)
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