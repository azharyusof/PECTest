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

public partial class SiteVisitHSELegalDetailView : System.Web.UI.Page
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

    private void bindOPUS()
    {
        String str;

        //str = "SELECT         * "
        //    + "FROM           tblLegalRegister "
        //    + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
        //    + "ORDER BY       Id DESC ";

        str = "SELECT         tblLegalRegister.*, "
            + "               tblCREATEBY.StaffName As CREATEBYName  "
            + "FROM           tblLegalRegister "
            + "LEFT JOIN      StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblLegalRegister.CreatedBy COLLATE DATABASE_DEFAULT "
            + "WHERE          tblLegalRegister.DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       tblLegalRegister.Id DESC ";

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

    protected void btnSaveF_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvFileName.Attributes.Add("class", null);
        dvReason.Attributes.Add("class", null);

        if (fldFileName.FileName == "")
        {
            chckErr = false;
            dvFileName.Attributes.Add("class", "has-error");
        }

        if (fldReason.Text.Trim() == "")
        {
            chckErr = false;
            dvReason.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblLegalRegister
            queryString = "";
            queryString = queryString + " INSERT INTO   tblLegalRegister ";
            queryString = queryString + "               (DescriptionId, ReasonRevision, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pReasonRevision, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pReasonRevision", fldReason.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();

            //Legal Register Document
            uploadLegal();

            Response.Redirect("SiteVisitHSELegalDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadLegal()
    {
        //if (fldFileName.FileName != "")
        //{
        //Update Legal Register Document
        SqlCommand cmdFile = new SqlCommand("UPDATE tblLegalRegister SET "
                + "FileName = @pFileName "
                + "WHERE FileName IS NULL "
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
                string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/LegalRegister/";

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