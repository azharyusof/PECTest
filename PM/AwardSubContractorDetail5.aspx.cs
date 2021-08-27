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

public partial class AwardSubContractorDetail5 : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

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
            qs = "";
            qs = qs + " SELECT        tblMain.Code ";
            qs = qs + " FROM          tblMain ";
            qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";

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
                lblCode.Text = row["Code"].ToString();
            }

            bindNCService();
        }
    }

    private void bindNCService()
    {
        String str;

        str = "SELECT         * "
            + "FROM           tblNonConformance "
            + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
            + "ORDER BY       Id DESC ";

        gvNCService.DataSource = GetData(str);
        gvNCService.DataBind();

        for (int i = 0; i < gvNCService.Rows.Count; i++)
        {
            GridViewRow row = gvNCService.Rows[i];

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


    //protected void bindExtSupport()
    //{
    //    // Bind data to the dropdownlist control.
    //    qs = "";
    //    qs = qs + " SELECT        * ";
    //    qs = qs + " FROM          tblExternalSupport ";
    //    qs = qs + " ORDER BY      ExtSupportName ";

    //    fldExtSupport.DataSource = GetData(qs);
    //    fldExtSupport.DataTextField = "ExtSupportName";
    //    fldExtSupport.DataValueField = "ExtSupportName";
    //    fldExtSupport.DataBind();
    //    fldExtSupport.Items.Insert(0, new ListItem("-- Select External Support --", ""));
    //}

    //protected void btnListing_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ProjectListing.aspx");
    //}

    //protected void btnReview_Click(object sender, EventArgs e)
    //{
    //    Boolean chckErr = true;

    //    //Reset error
    //    dvExtSupport.Attributes.Add("class", null);

    //    if (fldExtSupport.SelectedIndex == 0)
    //    {
    //        chckErr = false;
    //        dvExtSupport.Attributes.Add("class", "has-error");
    //    }


    //    if (fldClientAdd.Text.Trim() == "")
    //    {
    //        chckErr = false;
    //        dvClientAdd.Attributes.Add("class", "has-error");
    //    }

    //    if (fldDescription.Text.Trim() == "")
    //    {
    //        chckErr = false;
    //        dvOpportunity.Attributes.Add("class", "has-error");
    //    }

    //    if (fldSOW.Text.Trim() == "")
    //    {
    //        chckErr = false;
    //        dvSOW.Attributes.Add("class", "has-error");
    //    }

    //    if (fldPM.SelectedIndex == 0)
    //    {
    //        chckErr = false;
    //        dvPM.Attributes.Add("class", "has-error");
    //    }

    //    if (fldProjectValue.Text.Trim() == "")
    //    {
    //        chckErr = false;
    //        dvProjectValue.Attributes.Add("class", "has-error");
    //    }

    //    if (fldProjectFee.Text.Trim() == "")
    //    {
    //        chckErr = false;
    //        dvProjectFee.Attributes.Add("class", "has-error");
    //    }

    //    if (fldStartDate.Text.Trim() == "" || fldEndDate.Text.Trim() == "")
    //    {
    //        chckErr = false;
    //        dvProjectDate.Attributes.Add("class", "has-error");
    //    }

    //    if (chckErr == true)
    //    {
    //        insertOpportunity();

    //        DateTime now = DateTime.Now;

    //        //Capture latest Id from tblMain
    //        queryString = "";
    //        queryString = queryString + " SELECT        Id  ";
    //        queryString = queryString + " FROM          tblMain ";
    //        queryString = queryString + " ORDER BY      Id DESC ";

    //        if (con.State == System.Data.ConnectionState.Closed)
    //        { con.Open(); }
    //        cmd = new SqlCommand(queryString, con);
    //        cmd.CommandTimeout = 0;
    //        SqlDataAdapter daChck = new SqlDataAdapter(cmd);
    //        DataTable dtChck = new DataTable();
    //        daChck.Fill(dtChck);
    //        con.Close();

    //        row = null;
    //        row = dtChck.Rows[0];

    //        //Insert into table tblOpportunityGoNoGo
    //        queryString = "";
    //        queryString = queryString + " INSERT INTO   tblOpportunityGoNoGo ";
    //        queryString = queryString + "               (DescriptionId, CreatedBy, DateCreated) ";
    //        queryString = queryString + " VALUES        (@pDescriptionId, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

    //        if (con.State == System.Data.ConnectionState.Closed)
    //        { con.Open(); }
    //        cmd = new SqlCommand(queryString, con);
    //        cmd.CommandTimeout = 0;

    //        cmd.Parameters.AddWithValue("@pDescriptionId", row["Id"]);

    //        cmd.ExecuteNonQuery();
    //        con.Close();


    //        Response.Redirect("ProjectListing.aspx");
    //    }
    //}

    //private void bindNCService()
    //{
    //    String str;

    //    str = "SELECT         * "
    //        + "FROM           tblNonConformance "
    //        + "WHERE          DescriptionId = '" + Request.QueryString["ID"] + "' "
    //        + "ORDER BY       Id DESC ";

    //    gvNCService.DataSource = GetData(str);
    //    gvNCService.DataBind();

    //    for (int i = 0; i < gvNCService.Rows.Count; i++)
    //    {
    //        GridViewRow row = gvNCService.Rows[i];

    //        //Apply style to individual cells of alternating row.
    //        if (i % 2 != 0)
    //        {
    //            row.Cells[0].Style.Add("background-color", "#FFECEC");
    //            row.Cells[1].Style.Add("background-color", "#FFECEC");
    //            row.Cells[2].Style.Add("background-color", "#FFECEC");
    //            row.Cells[3].Style.Add("background-color", "#FFECEC");
    //            row.Cells[4].Style.Add("background-color", "#FFECEC");
    //            row.Cells[5].Style.Add("background-color", "#FFECEC");
    //            row.Cells[6].Style.Add("background-color", "#FFECEC");
    //            row.Cells[7].Style.Add("background-color", "#FFECEC");
    //            row.Cells[8].Style.Add("background-color", "#FFECEC");
    //            row.Cells[9].Style.Add("background-color", "#FFECEC");
    //            row.Cells[10].Style.Add("background-color", "#FFECEC");
    //        }
    //    }
    //}

    //protected void gvNCService_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
    //    {
    //        // Bind data to the dropdownlist control.
    //        DropDownList ExtSupportName = (e.Row.FindControl("txtExtSupportName") as DropDownList);
    //        ExtSupportName.DataSource = GetData("SELECT ExtSupportName FROM tblExternalSupport ORDER BY ExtSupportName");
    //        ExtSupportName.DataTextField = "ExtSupportName";
    //        ExtSupportName.DataValueField = "ExtSupportName";
    //        ExtSupportName.DataBind();
    //    }
    //}


    //protected void EditNCService(object sender, GridViewEditEventArgs e)
    //{
    //    gvNCService.EditIndex = e.NewEditIndex;
    //    bindNCService();
    //}

    //protected void CancelNCServiceEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvNCService.EditIndex = -1;
    //    bindNCService();
    //}

    //protected void UpdateNCService(object sender, GridViewUpdateEventArgs e)
    //{
    //    DateTime now = DateTime.Now;

    //    string ID = ((Label)gvNCService.Rows[e.RowIndex].FindControl("lblID")).Text;
    //    string ExtSupportName = ((DropDownList)gvNCService.Rows[e.RowIndex].FindControl("txtExtSupportName")).Text;
    //    //string DateOccurred = ((TextBox)gvNCService.Rows[e.RowIndex].FindControl("txtDateOccurred")).Text;
    //    string NCServices = ((TextBox)gvNCService.Rows[e.RowIndex].FindControl("txtNCServices")).Text;
    //    string RequiredAction = ((DropDownList)gvNCService.Rows[e.RowIndex].FindControl("txtRequiredAction")).Text;
    //    //string NotificationDate = ((TextBox)gvNCService.Rows[e.RowIndex].FindControl("txtNotificationDate")).Text;
    //    string ProposedAction = ((TextBox)gvNCService.Rows[e.RowIndex].FindControl("txtProposedAction")).Text;
    //    //string TargetDate = ((TextBox)gvNCService.Rows[e.RowIndex].FindControl("txtTargetDate")).Text;
    //    string Status = ((DropDownList)gvNCService.Rows[e.RowIndex].FindControl("txtStatus")).Text;

    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("UPDATE tblNonConformance SET " +
    //        "ExtSupportName=@pExtSupportName, " +
    //        "NCServices=@pNCServices, " +
    //        "RequiredAction=@pRequiredAction, " +
    //        "ProposedAction=@pProposedAction, " +
    //        "Status=@pStatus, " +
    //        "ModifyBy='" + Session["UserID"].ToString() + "', " +
    //        "DateModify='" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' " +
    //        "WHERE ID=@ID", con);

    //    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
    //    cmd.Parameters.Add("@pExtSupportName", SqlDbType.VarChar).Value = ExtSupportName;
    //    //cmd.Parameters.Add("@pDateOccurred", SqlDbType.VarChar).Value = DateOccurred;
    //    cmd.Parameters.Add("@pNCServices", SqlDbType.VarChar).Value = NCServices;
    //    cmd.Parameters.Add("@pRequiredAction", SqlDbType.VarChar).Value = RequiredAction;
    //    //cmd.Parameters.Add("@pNotificationDate", SqlDbType.VarChar).Value = NotificationDate;
    //    cmd.Parameters.Add("@pProposedAction", SqlDbType.VarChar).Value = ProposedAction;
    //    //cmd.Parameters.Add("@pTargetDate", SqlDbType.VarChar).Value = TargetDate;
    //    cmd.Parameters.Add("@pStatus", SqlDbType.VarChar).Value = Status;

    //    cmd.ExecuteNonQuery();

    //    gvNCService.EditIndex = -1;
    //    bindNCService();
    //}

    //protected void DeleteNCService(object sender, EventArgs e)
    //{
    //    ImageButton imgDelete = (ImageButton)sender;
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("DELETE FROM tblNonConformance WHERE ID=@ID", con);

    //    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;

    //    cmd.ExecuteNonQuery();

    //    bindNCService();
    //}


    //protected void btnSaveC_Click(object sender, EventArgs e)
    //{
    //    DateTime now = DateTime.Now;
    //    //Boolean chckErr = true;

    //    //Reset error
    //    //dvRiskTitle.Attributes.Add("class", null);
    //    //dvGrossRating.Attributes.Add("class", null);

    //    //if (fldRiskTitle.Text.Trim() == "")
    //    //{
    //    //    chckErr = false;
    //    //    dvRiskTitle.Attributes.Add("class", "has-error");
    //    //}

    //    //if (fldGrossRating.SelectedIndex == 0)
    //    //{
    //    //    chckErr = false;
    //    //    dvGrossRating.Attributes.Add("class", "has-error");
    //    //}

    //    //if (chckErr == true)
    //    //{
    //    //Insert into table tblProjectMonthlyUpdate
    //    queryString = "";
    //    queryString = queryString + " INSERT INTO   tblNonConformance ";
    //    queryString = queryString + "               (DescriptionId, DateSubmitted, ProjectPhase, Issues, ActivityPlannedForMonth, ProjectSchedule, Planned, Actual, Impact, ActionToBeTaken, CreatedBy, DateCreated) ";
    //    queryString = queryString + " VALUES        (@pDescriptionId, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "', @pProjectPhase, @pIssues, @pActivityPlannedForMonth, @pProjectSchedule, @pPlanned, @pActual, @pImpact, @pActionToBeTaken, '" + Session["UserID"].ToString() + "', '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

    //    if (con.State == System.Data.ConnectionState.Closed)
    //    { con.Open(); }
    //    cmd = new SqlCommand(queryString, con);
    //    cmd.CommandTimeout = 0;

    //    cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["ID"]);
    //    cmd.Parameters.AddWithValue("@pProjectPhase", fldProjectPhase.SelectedValue);
    //    cmd.Parameters.AddWithValue("@pIssues", fldIssues.Text.Trim());

    //    cmd.Parameters.AddWithValue("@pActivityPlannedForMonth", fldActivityPlannedForMonth.Text.Trim());
    //    cmd.Parameters.AddWithValue("@pProjectSchedule", fldProjectSchedule.SelectedValue);
    //    cmd.Parameters.AddWithValue("@pPlanned", fldPlanned.Text.Trim());
    //    cmd.Parameters.AddWithValue("@pActual", fldActual.Text.Trim());
    //    cmd.Parameters.AddWithValue("@pImpact", fldImpact.Text.Trim());
    //    cmd.Parameters.AddWithValue("@pActionToBeTaken", fldActionToBeTaken.Text.Trim());

    //    cmd.ExecuteNonQuery();
    //    con.Close();

    //    bindNCService();
    //    Response.Redirect("AwardSubContractorDetail4.aspx?ID=" + Request.QueryString["ID"]);
    //    //}
    //}

    //protected void btnCloseC_Click(object sender, EventArgs e)
    //{
    //}

    //private static DataTable GetData(string query)
    //{
    //    string strConnString = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(strConnString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.CommandText = query;
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.Connection = con;
    //                sda.SelectCommand = cmd;
    //                using (DataSet ds = new DataSet())
    //                {
    //                    DataTable dt = new DataTable();
    //                    sda.Fill(dt);
    //                    return dt;
    //                }
    //            }
    //        }
    //    }
    //}
}