﻿using System;
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
using System.Text.RegularExpressions;

public static class Extensions
{
    /// <summary>
    /// Wraps matched strings in HTML span elements styled with a background-color
    /// </summary>
    /// <param name="text"></param>
    /// <param name="keywords">Comma-separated list of strings to be highlighted</param>
    /// <param name="cssClass">The Css color to apply</param>
    /// <param name="fullMatch">false for returning all matches, true for whole word matches only</param>
    /// <returns>string</returns>
    public static string HighlightKeyWords(this string text, string keywords, string cssClass, bool fullMatch)
    {
        if (text == String.Empty || keywords == String.Empty || cssClass == String.Empty)
            return text;
        var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (!fullMatch)
            return words.Select(word => word.Trim()).Aggregate(text,
                         (current, pattern) =>
                         Regex.Replace(current,
                                         pattern,
                                           string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                           cssClass,
                                           "$0"),
                                           RegexOptions.IgnoreCase));
        return words.Select(word => "\\b" + word.Trim() + "\\b")
                    .Aggregate(text, (current, pattern) =>
                              Regex.Replace(current,
                              pattern,
                                string.Format("<span style=\"background-color:{0}\">{1}</span>",
                                cssClass,
                                "$0"),
                                RegexOptions.IgnoreCase));
    }
}

public partial class ProjectMonthlyUpdateDetail : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
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
            //Bind dropdownlist
            bindPackage();
            bindWP(); 
            
            bindMonthlyUpdate();

            bindDetails();

            bindProjectDoc();

            //Check Work Package 
            queryString = "";
            queryString = queryString + " SELECT        WorkPackage ";
            queryString = queryString + " FROM          tblWorkPackage ";
            queryString = queryString + " WHERE         DescriptionId = '" + Request.QueryString["ID"] + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                //Check for empty record.   
                dvWPCode.Visible = false;
                dvWP.Visible = false;
                gvMonthlyUpdate.HeaderRow.Cells[1].Visible = false;
                gvMonthlyUpdate.Columns[1].Visible = false;
            }
            else
            {
                DataRow row = dt.Rows[0];

                dvWPCode.Visible = true;
                dvWP.Visible = true;
                gvMonthlyUpdate.HeaderRow.Cells[1].Visible = true;
                gvMonthlyUpdate.Columns[1].Visible = true;
            }

            con.Close();

        }
    }

    protected void bindPackage()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        WorkPackageCode ";
        qs = qs + " FROM          tblWorkPackage ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["ID"] + "' ";
        qs = qs + " ORDER BY      SortBy ";

        fldPkg.DataSource = GetData(qs);
        fldPkg.DataTextField = "WorkPackageCode";
        fldPkg.DataValueField = "WorkPackageCode";
        fldPkg.DataBind();
        fldPkg.Items.Insert(0, new ListItem("-- Please select one --", ""));
    }

    protected void bindWP()
    {
        // Bind data to the dropdownlist control.
        qs = "";
        qs = qs + " SELECT        WorkPackageCode ";
        qs = qs + " FROM          tblWorkPackage ";
        qs = qs + " WHERE         DescriptionId = '" + Request.QueryString["ID"] + "' "; 
        qs = qs + " ORDER BY      SortBy ";

        fldWP.DataSource = GetData(qs);
        fldWP.DataTextField = "WorkPackageCode";
        fldWP.DataValueField = "WorkPackageCode";
        fldWP.DataBind();
        fldWP.Items.Insert(0, new ListItem("-- All Work Packages --", ""));
    }

    protected void fldWP_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Display Work Package 
        queryString = "";
        queryString = queryString + " SELECT        WorkPackage ";
        queryString = queryString + " FROM          tblWorkPackage ";
        queryString = queryString + " WHERE         DescriptionId = '" + Request.QueryString["ID"] + "' ";
        queryString = queryString + " AND           WorkPackageCode = '" + fldWP.SelectedValue + "'";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            //Check for empty record.       
            lblWP.Text = "";
        }
        else
        {
            DataRow row = dt.Rows[0];

            lblWP.Text = row["WorkPackage"].ToString();
        }
        con.Close(); 
        
        bindMonthlyUpdate();
    }


    protected void bindDetails()
    {
        
        qs = "";
        qs = qs + " SELECT        tblProjectMonthlyUpdate.*, tblMain.ProjectCode ";
        qs = qs + " FROM          tblProjectMonthlyUpdate ";
        qs = qs + " INNER JOIN          tblMain ON tblProjectMonthlyUpdate.DescriptionId = tblMain.Id ";
        qs = qs + " WHERE         tblProjectMonthlyUpdate.DescriptionId = '" + Request.QueryString["Id"] + "' ";
        

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

            //Project Code
            lblCode.Text = row["ProjectCode"].ToString();
        }
    }
               

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    private void bindProjectDoc()
    {
        String str;

        if (fldSearch.Text.Trim() != "")
        {
            str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' AND Phase = 'Project Status' "
            + "AND           (FileName LIKE '%' + @search + '%' OR DocumentType LIKE '%' + @search + '%') "
            + "ORDER BY       Id DESC ";
        }
        else
        {
            str = "SELECT         * "
            + "FROM           tblProjectDocument "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' AND Phase = 'Project Status' "
            + "ORDER BY       Id DESC ";
        }

        SqlCommand xp = new SqlCommand(str, con);

        xp.Parameters.AddWithValue("@search", ((object)fldSearch.Text.Trim()) ?? DBNull.Value);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvProjectDoc.DataSource = ds;
        gvProjectDoc.DataBind();
        con.Close();

        for (int i = 0; i < gvProjectDoc.Rows.Count; i++)
        {
            GridViewRow row = gvProjectDoc.Rows[i];

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
            }
        }

    }

    protected void btnManageWP_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageWorkPackage.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        fldSearch.Text = "";

        bindProjectDoc();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_Word = fldSearch.Text.Trim();

        btnClear.Visible = true;

        bindProjectDoc();
    }

    protected void DeleteProjectDoc(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectDocument WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindProjectDoc();
    }

    private void bindMonthlyUpdate()
    {
        String str;
        String sql_wp;

        if (fldWP.SelectedValue != "")
        {
            sql_wp = "AND (tblProjectMonthlyUpdate.WorkPackage = '" + fldWP.SelectedValue + "') ";
        }
        else
        { sql_wp = "AND 1=1 "; }

        str = "SELECT         * "
            + "FROM           tblProjectMonthlyUpdate "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' AND Date IS NOT NULL "
            + "" + sql_wp + " "
            + "ORDER BY       Date DESC ";

       
        gvMonthlyUpdate.DataSource = GetData(str);
        gvMonthlyUpdate.DataBind();

        for (int i = 0; i < gvMonthlyUpdate.Rows.Count; i++)
        {
            GridViewRow row = gvMonthlyUpdate.Rows[i];

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

    protected void gvMonthlyUpdate_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvMonthlyUpdate.PageIndex = e.NewPageIndex;
        this.bindMonthlyUpdate();

    }
    
    protected void EditMonthlyUpdate(object sender, GridViewEditEventArgs e)
    {
        gvMonthlyUpdate.EditIndex = e.NewEditIndex;
        bindMonthlyUpdate();
    }

    protected void CancelMonthlyUpdateEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvMonthlyUpdate.EditIndex = -1;
        bindMonthlyUpdate();
    }

    protected void gvMonthlyUpdate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            // Bind data to the dropdownlist control.
            DropDownList ddlPkg = (e.Row.FindControl("ddlPkg") as DropDownList);
            ddlPkg.DataSource = GetData("SELECT WorkPackageCode FROM tblWorkPackage ORDER BY WorkPackageCode");
            ddlPkg.DataTextField = "WorkPackageCode";
            ddlPkg.DataValueField = "WorkPackageCode";
            ddlPkg.DataBind();
            ddlPkg.Items.Insert(0, new ListItem("-- Please select --", ""));

            string ddlPkgCode = (e.Row.FindControl("ddlPkgCode") as TextBox).Text;
            ddlPkg.Items.FindByValue(ddlPkgCode).Selected = true;
        }
    }


    protected void UpdateMonthlyUpdate(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Dt = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtDate")).Text;
        string Issues = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtIssues")).Text;
        string ActivityPlannedForMonth = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtActivityPlannedForMonth")).Text;
        string ProjectSchedule = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtProjectSchedule")).Text;
        string Planned = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtPlanned")).Text;
        string Actual = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtActual")).Text;
        string Impact = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtImpact")).Text;
        string ActionToBeTaken = ((TextBox)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("txtActionToBeTaken")).Text;
        string ddlPkg = ((DropDownList)gvMonthlyUpdate.Rows[e.RowIndex].FindControl("ddlPkg")).Text; 

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectMonthlyUpdate SET " +
            "WorkPackage=@pPkg, " +
            "Date=@pDt, " +
            "Issues=@pIssues, " +
            "ActivityPlannedForMonth=@pActivityPlannedForMonth, " +
            "ProjectSchedule=@pProjectSchedule, " +
            "Planned=@pPlanned, " +
            "Actual=@pActual, " +
            "Impact=@pImpact, " +
            "ActionToBeTaken=@pActionToBeTaken, " +
            "ModifyBy='" + Session["UserID"].ToString() + "', " +
            "DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' " +
            "WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pDt", SqlDbType.VarChar).Value = Dt;
        cmd.Parameters.Add("@pIssues", SqlDbType.VarChar).Value = Issues;
        cmd.Parameters.Add("@pActivityPlannedForMonth", SqlDbType.VarChar).Value = ActivityPlannedForMonth;
        cmd.Parameters.Add("@pProjectSchedule", SqlDbType.VarChar).Value = ProjectSchedule;
        cmd.Parameters.Add("@pPlanned", SqlDbType.VarChar).Value = Planned;
        cmd.Parameters.Add("@pActual", SqlDbType.VarChar).Value = Actual;
        cmd.Parameters.Add("@pImpact", SqlDbType.VarChar).Value = Impact;
        cmd.Parameters.Add("@pActionToBeTaken", SqlDbType.VarChar).Value = ActionToBeTaken;
        cmd.Parameters.Add("@pPkg", SqlDbType.VarChar).Value = ddlPkg;

        cmd.ExecuteNonQuery();

        gvMonthlyUpdate.EditIndex = -1;
        bindMonthlyUpdate();
    }

    protected void DeleteMonthlyUpdate(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectMonthlyUpdate WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

        cmd.ExecuteNonQuery();

        bindMonthlyUpdate();
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
            queryString = queryString + " INSERT INTO   tblProjectDocument ";
            queryString = queryString + "               (DescriptionId, Description, ReceivedFrom, DateReceived, SubmitTo, DateSubmitted, Phase, CreatedBy, DateCreated) ";
            queryString = queryString + " VALUES        (@pDescriptionId, @pDescription, @pReceivedFrom, @pDateReceived, @pSubmitTo, @pDateSubmitted, 'Project Status', '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";
            
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(queryString, con);
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@pDescription", fldDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@pReceivedFrom", fldReceivedFrom.Text.Trim());
            
            if (fldDateReceived.Text != "")
            { cmd.Parameters.AddWithValue("@pDateReceived", Convert.ToDateTime(fldDateReceived.Text)); }
            else
            { cmd.Parameters.AddWithValue("@pDateReceived", DBNull.Value); }

            cmd.Parameters.AddWithValue("@pSubmitTo", fldSubmitTo.Text.Trim());
            
            if (fldDateSubmitted.Text != "")
            { cmd.Parameters.AddWithValue("@pDateSubmitted", Convert.ToDateTime(fldDateSubmitted.Text)); }
            else
            { cmd.Parameters.AddWithValue("@pDateSubmitted", DBNull.Value); }

            cmd.ExecuteNonQuery();
            con.Close();

            //Project Document
            uploadProjectDoc();

            Response.Redirect("ProjectMonthlyUpdateDetail.aspx?ID=" + Request.QueryString["ID"]);
        }
    }

    protected void uploadProjectDoc()
    {
        if (fldFileName.FileName != "")
        {
            //Update Project Document
            SqlCommand cmdFile = new SqlCommand("UPDATE TOP (1) tblProjectDocument SET "
                    + "FileName = @pFileName "
                    + "WHERE FileName IS NULL "
                    + "AND Phase = 'Project Status' "
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
                    string pathString = @"e:/webapps/PECTest/PM/Upload/" + Request.QueryString["Id"] + "/MonthlyProjectDocument/";

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
    
    protected void EditProjectDoc(object sender, GridViewEditEventArgs e)
    {
        gvProjectDoc.EditIndex = e.NewEditIndex;
        bindProjectDoc();
    }

    protected void CancelProjectDocEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvProjectDoc.EditIndex = -1;
        bindProjectDoc();
    }

    protected void UpdateProjectDoc(object sender, GridViewUpdateEventArgs e)
    {
        DateTime now = DateTime.Now;

        string ID = ((Label)gvProjectDoc.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Description = ((TextBox)gvProjectDoc.Rows[e.RowIndex].FindControl("txtDescription")).Text;
        string ReceivedFrom = ((TextBox)gvProjectDoc.Rows[e.RowIndex].FindControl("txtReceivedFrom")).Text;
        string SubmitTo = ((TextBox)gvProjectDoc.Rows[e.RowIndex].FindControl("txtSubmitTo")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectDocument SET " +
            "Description=@pDescription, " +
            "ReceivedFrom=@pReceivedFrom, " +
            "SubmitTo=@pSubmitTo, " +
            "ModifyBy='" + Session["UserID"].ToString() + "', " +
            "DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' " +
            "WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pDescription", SqlDbType.VarChar).Value = Description;
        cmd.Parameters.Add("@pReceivedFrom", SqlDbType.VarChar).Value = ReceivedFrom;        
        cmd.Parameters.Add("@pSubmitTo", SqlDbType.VarChar).Value = SubmitTo;

        cmd.ExecuteNonQuery();

        gvProjectDoc.EditIndex = -1;
        bindProjectDoc();
    }

    

    protected void btnSaveC_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        
        //Insert into table tblProjectMonthlyUpdate
        queryString = "";
        queryString = queryString + " INSERT INTO   tblProjectMonthlyUpdate ";
        queryString = queryString + "               (DescriptionId, WorkPackage, Date, Issues, ActivityPlannedForMonth, ProjectSchedule, Planned, Actual, Impact, ActionToBeTaken, CreatedBy, DateCreated) ";
        queryString = queryString + " VALUES        (@pDescriptionId, @pWorkPackage, @pDate, @pIssues, @pActivityPlannedForMonth, @pProjectSchedule, @pPlanned, @pActual, @pImpact, @pActionToBeTaken, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";
                
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
        cmd.Parameters.AddWithValue("@pWorkPackage", fldPkg.SelectedValue);
        cmd.Parameters.AddWithValue("@pDate", fldDate.Text);
        cmd.Parameters.AddWithValue("@pIssues", fldIssues.Text.Trim());
        cmd.Parameters.AddWithValue("@pActivityPlannedForMonth", fldActivityPlannedForMonth.Text.Trim());
        cmd.Parameters.AddWithValue("@pProjectSchedule", fldProjectSchedule.Text.Trim());
        cmd.Parameters.AddWithValue("@pPlanned", fldPlanned.Text.Trim());
        cmd.Parameters.AddWithValue("@pActual", fldActual.Text.Trim());
        cmd.Parameters.AddWithValue("@pImpact", fldImpact.Text.Trim());
        cmd.Parameters.AddWithValue("@pActionToBeTaken", fldActionToBeTaken.Text.Trim());

        cmd.ExecuteNonQuery();
        con.Close();

        bindMonthlyUpdate();
        Response.Redirect("ProjectMonthlyUpdateDetail.aspx?ID=" + Request.QueryString["ID"]);
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