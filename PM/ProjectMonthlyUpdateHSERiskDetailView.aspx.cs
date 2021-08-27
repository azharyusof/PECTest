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

public partial class ProjectMonthlyUpdateHSERiskDetailView : System.Web.UI.Page
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

        bindStatus();
        
        if (!Page.IsPostBack)
        {
            bindDetails();
            bindRisk();
            bindGrossRating();
            bindRiskCategory();
            bindLikelihood();
            bindImpact();

            bindBeaconReport();
        }

    }

    protected void bindStatus()
    {
        fldStatus.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldStatus.Items.Insert(1, new ListItem("Open", "Open"));
        fldStatus.Items.Insert(2, new ListItem("Closed", "Closed"));
    }

    protected void bindGrossRating()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        * ";
        qs = qs + " FROM          tblGrossRating ";
        qs = qs + " ORDER BY      Id ";

        fldGrossRating.DataSource = GetData(qs);
        fldGrossRating.DataTextField = "GrossRating";
        fldGrossRating.DataValueField = "GrossRating";
        fldGrossRating.DataBind();
        fldGrossRating.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }


    protected void bindRiskCategory()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        * ";
        qs = qs + " FROM          tblRiskCategory ";
        qs = qs + " ORDER BY      RiskCategory ";

        fldRiskCategory.DataSource = GetData(qs);
        fldRiskCategory.DataTextField = "RiskCategory";
        fldRiskCategory.DataValueField = "RiskCategory";
        fldRiskCategory.DataBind();
        fldRiskCategory.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindLikelihood()
    {
        // Bind data to the dropdownlist control.
        fldLikelihood.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldLikelihood.Items.Insert(1, new ListItem("Certain", "Certain"));
        fldLikelihood.Items.Insert(2, new ListItem("Likely", "Likely"));
        fldLikelihood.Items.Insert(3, new ListItem("Possible", "Possible"));
        fldLikelihood.Items.Insert(4, new ListItem("Unlikely", "Unlikely"));
        fldLikelihood.Items.Insert(5, new ListItem("Remote", "Remote"));
    }

    protected void bindImpact()
    {
        // Bind data to the dropdownlist control.
        fldImpact.Items.Insert(0, new ListItem("-- Please select one --", ""));
        fldImpact.Items.Insert(1, new ListItem("Insignificant", "Insignificant"));
        fldImpact.Items.Insert(2, new ListItem("Minor", "Minor"));
        fldImpact.Items.Insert(3, new ListItem("Moderate", "Moderate"));
        fldImpact.Items.Insert(4, new ListItem("Major", "Major"));
        fldImpact.Items.Insert(5, new ListItem("Catastrophic", "Catastrophic"));
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
       
   
    private void bindBeaconReport()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblBeaconReport "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvBeaconReport.DataSource = GetData(str);
        gvBeaconReport.DataBind();

        for (int i = 0; i < gvBeaconReport.Rows.Count; i++)
        {
            GridViewRow row = gvBeaconReport.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
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
            //Insert into table tblBeaconReport
            queryString = "";
            queryString = queryString + " INSERT INTO   tblBeaconReport ";
            queryString = queryString + "               (DescriptionId, ActionRequired, Status, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pActionRequired, @pStatus, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pActionRequired", fldActionRequired.Text.Trim());
            cmd.Parameters.AddWithValue("@pStatus", fldStatus.SelectedValue);

            cmd.ExecuteNonQuery();
            con.Close();

            //Beacon Report
            uploadBeaconReport();

            Response.Redirect("ProjectMonthlyUpdateHSERiskDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadBeaconReport()
    {
        if (fldFileName.FileName != "")
        {
            //Update Project Document
            SqlCommand cmdFile = new SqlCommand("UPDATE tblBeaconReport SET "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/BeaconReport/";

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

    private void bindRisk()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblRiskAssessment "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvRiskAssessment.DataSource = GetData(str);
        gvRiskAssessment.DataBind();

        for (int i = 0; i < gvRiskAssessment.Rows.Count; i++)
        {
            GridViewRow row = gvRiskAssessment.Rows[i];

            //Apply style to individual cells of alternating row.
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                row.Cells[6].Style.Add("background-color", "#FFECEC");
                row.Cells[7].Style.Add("background-color", "#FFECEC");
                row.Cells[8].Style.Add("background-color", "#FFECEC");
                row.Cells[9].Style.Add("background-color", "#FFECEC");
                row.Cells[10].Style.Add("background-color", "#FFECEC");
                row.Cells[11].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void gvRiskAssessment_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvRiskAssessment.PageIndex = e.NewPageIndex;
        this.bindRisk();

    }

    protected void gvRiskAssessment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "#";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Date";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Category";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Title";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Risk Description <br>(Include Cost & Impact of Risk)";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Gross Rating";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Existing Control";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Net Risk Rating";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Mitigation";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 2;
            HeaderCell.Text = "Status";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            gvRiskAssessment.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }


    protected void gvRiskAssessment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Bind data to the dropdownlist control.
            DropDownList GrossRating = (e.Row.FindControl("txtGrossRating") as DropDownList);
            GrossRating.DataSource = GetData("SELECT Id, GrossRating FROM tblGrossRating ORDER BY Id");
            GrossRating.DataTextField = "GrossRating";
            GrossRating.DataValueField = "GrossRating";
            GrossRating.DataBind();

            string GrossRatingId = (e.Row.FindControl("txtGrossRatingId") as TextBox).Text;
            GrossRating.Items.FindByValue(GrossRatingId).Selected = true;
        }
    }
       
    protected void btnSaveC_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        Boolean chckErr = true;

        //Reset error
        dvRiskTitle.Attributes.Add("class", null);
        dvGrossRating.Attributes.Add("class", null);
        dvExistingControl.Attributes.Add("class", null);
        dvLikelihood.Attributes.Add("class", null);
        dvImpact.Attributes.Add("class", null);

        if (fldRiskTitle.Text.Trim() == "")
        {
            chckErr = false;
            dvRiskTitle.Attributes.Add("class", "has-error");
        }

        if (fldGrossRating.SelectedIndex == 0)
        {
            chckErr = false;
            dvGrossRating.Attributes.Add("class", "has-error");
        }

        if (fldExistingControl.Text.Trim() == "")
        {
            chckErr = false;
            dvExistingControl.Attributes.Add("class", "has-error");
        }

        if (fldLikelihood.SelectedIndex == 0)
        {
            chckErr = false;
            dvLikelihood.Attributes.Add("class", "has-error");
        }

        if (fldImpact.SelectedIndex == 0)
        {
            chckErr = false;
            dvImpact.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            //Insert into table tblRiskAssessment
            queryString = "";
            queryString = queryString + " INSERT INTO   tblRiskAssessment ";
            queryString = queryString + "               (DescriptionId, AssessDate, RiskCategory, RiskTitle, RiskDescription, GrossRating, ExistingControl, Likelihood, Impact, Status, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pAssessDate, @pRiskCategory, @pRiskTitle, @pRiskDescription, @pGrossRating, @pExistingControl, @pLikelihood, @pImpact, 'Open', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pAssessDate", fldAssessDate.Text);
            cmd.Parameters.AddWithValue("@pRiskCategory", fldRiskCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@pRiskTitle", fldRiskTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@pRiskDescription", fldRiskDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@pGrossRating", fldGrossRating.SelectedValue);
            cmd.Parameters.AddWithValue("@pExistingControl", fldExistingControl.Text.Trim());
            cmd.Parameters.AddWithValue("@pLikelihood", fldLikelihood.SelectedValue);
            cmd.Parameters.AddWithValue("@pImpact", fldImpact.SelectedValue);

            cmd.ExecuteNonQuery();

            //Update Risk Rating in table tblRiskAssessment
            SqlCommand cmdRating = new SqlCommand("UPDATE tblRiskAssessment SET tblRiskAssessment.RiskRating = tblRiskImpact.RiskRating FROM tblRiskImpact, tblRiskAssessment WHERE tblRiskImpact.Likelihood = tblRiskAssessment.Likelihood AND tblRiskImpact.Impact = tblRiskAssessment.Impact", con);

            cmdRating.ExecuteNonQuery();

            con.Close();

            bindRisk();

            Response.Redirect("ProjectMonthlyUpdateHSERiskDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void btnCloseC_Click(object sender, EventArgs e)
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