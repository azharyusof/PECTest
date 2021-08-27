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

public partial class Admin_PIC_Opportunity : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
    String qs1 = "";
    String qs2 = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlConnection conUM = new SqlConnection(ConfigurationManager.ConnectionStrings["UMatrixDbConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            bindOpportunity();
            bindProject();

            TabName.Value = Request.Form[TabName.UniqueID];

            DateTime now = DateTime.Now;

            lblUser.Text = Session["UserName"].ToString();
            lblCurrDateTime.Text = now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }
    }
    #endregion

    #region GetData
    public DataSet GetData(string qs)
    {
        // Retrieve the connection string stored in the Web.config file.
        string connectionString = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;
        DataSet ds = new DataSet();

        try
        {
            // Connect to the database and run the query.
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(qs, connection);

            // Fill the DataSet.
            adapter.Fill(ds);
            connection.Close();
        }
        catch (SqlException SqlEx)
        {
            Debug.WriteLine("Errors Count:" + SqlEx.Errors.Count);
        }
        return ds;
    }
    #endregion

    #region BindData
    protected void bindOpportunity()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);

        SqlCommand xp = new SqlCommand("spOpportunityList", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        xp.Connection = con;

        try
        {
            con.Open();
            gvPICOpportunity.DataSource = xp.ExecuteReader();
            gvPICOpportunity.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }

        for (int i = 0; i < gvPICOpportunity.Rows.Count; i++)
        {
            GridViewRow row = gvPICOpportunity.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
                row.Cells[6].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    protected void bindProject()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);

        SqlCommand xp1 = new SqlCommand("spProjectList", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        xp1.Connection = con;

        try
        {
            con.Open();
            gvPICProject.DataSource = xp1.ExecuteReader();
            gvPICProject.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }

        for (int i = 0; i < gvPICProject.Rows.Count; i++)
        {
            GridViewRow row = gvPICProject.Rows[i];

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
            }
        }
    }
    #endregion

    #region Opportunity
    protected void gvPICOpportunity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            DropDownList ddlProjectManager = (e.Row.FindControl("ddlProjectManager") as DropDownList);
            DropDownList ddlOpportunityPIC1 = (e.Row.FindControl("ddlOpportunityPIC1") as DropDownList);
            DropDownList ddlOpportunityPIC2 = (e.Row.FindControl("ddlOpportunityPIC2") as DropDownList);

            ddlProjectManager.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin WHERE Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' ORDER BY StaffName");
            ddlProjectManager.DataTextField = "StaffName";
            ddlProjectManager.DataValueField = "StaffName";
            ddlProjectManager.DataBind();
            ddlProjectManager.Items.Insert(0, new ListItem("-- Please select one --", ""));

            ddlOpportunityPIC1.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            ddlOpportunityPIC1.DataTextField = "StaffName";
            ddlOpportunityPIC1.DataValueField = "StaffName";
            ddlOpportunityPIC1.DataBind();
            ddlOpportunityPIC1.Items.Insert(0, new ListItem("-- Please select one --", ""));

            ddlOpportunityPIC2.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            ddlOpportunityPIC2.DataTextField = "StaffName";
            ddlOpportunityPIC2.DataValueField = "StaffName";
            ddlOpportunityPIC2.DataBind();
            ddlOpportunityPIC2.Items.Insert(0, new ListItem("-- Please select one --", ""));

            string ddlProjectManagerCode = (e.Row.FindControl("ddlProjectManagerCode") as TextBox).Text;
            ddlProjectManager.Items.FindByValue(ddlProjectManagerCode).Selected = true;

            string ddlOpportunityPIC1Code = (e.Row.FindControl("ddlOpportunityPIC1Code") as TextBox).Text;
            ddlOpportunityPIC1.Items.FindByValue(ddlOpportunityPIC1Code).Selected = true;

            string ddlOpportunityPIC2Code = (e.Row.FindControl("ddlOpportunityPIC2Code") as TextBox).Text;
            ddlOpportunityPIC2.Items.FindByValue(ddlOpportunityPIC2Code).Selected = true;
        }
    }

    protected void EditPICOpportunity(object sender, GridViewEditEventArgs e)
    {
        gvPICOpportunity.EditIndex = e.NewEditIndex;
        this.bindOpportunity();
    }

    protected void CancelPICOpportunityEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPICOpportunity.EditIndex = -1;
        this.bindOpportunity();
    }

    protected void UpdatePICOpportunity(object sender, GridViewUpdateEventArgs e)
    {
        string lblOppName = ((Label)gvPICOpportunity.Rows[e.RowIndex].FindControl("lblOppName")).Text;
        string lblOppNameNewLine = lblOppName.Replace(System.Environment.NewLine, string.Empty).ToUpper();

        string lblOppCode = ((Label)gvPICOpportunity.Rows[e.RowIndex].FindControl("lblOppCode")).Text; //New code - nvarchar
        string ddlProjectManager = ((DropDownList)gvPICOpportunity.Rows[e.RowIndex].FindControl("ddlProjectManager")).Text; //pm name - nvarchar
        string ddlOpportunityPIC1 = ((DropDownList)gvPICOpportunity.Rows[e.RowIndex].FindControl("ddlOpportunityPIC1")).Text; //pic1 - nvarchar
        string ddlOpportunityPIC2 = ((DropDownList)gvPICOpportunity.Rows[e.RowIndex].FindControl("ddlOpportunityPIC2")).Text; //pic2 - nvarchar

        SqlCommand cmd2 = new SqlCommand("spUpdatePIC", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd2.Parameters.AddWithValue("@action", "UPDATEOPPORTUNITY");
        cmd2.Parameters.AddWithValue("@Desc", SqlDbType.NVarChar).Value = lblOppNameNewLine;
        cmd2.Parameters.AddWithValue("@Code", SqlDbType.NVarChar).Value = lblOppCode;
        cmd2.Parameters.AddWithValue("@pm", SqlDbType.NVarChar).Value = ddlProjectManager;
        cmd2.Parameters.AddWithValue("@pd", "");
        cmd2.Parameters.AddWithValue("@pic1", SqlDbType.NVarChar).Value = ddlOpportunityPIC1;
        cmd2.Parameters.AddWithValue("@pic2", SqlDbType.NVarChar).Value = ddlOpportunityPIC2;
        cmd2.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = Session["UserID"].ToString();

        con.Open();
        cmd2.ExecuteNonQuery();
        con.Close();

        gvPICOpportunity.EditIndex = -1;
        this.bindOpportunity();
    }
    #endregion

    #region Project
    protected void gvPICProject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            DropDownList ddlProProjectManager = (e.Row.FindControl("ddlProProjectManager") as DropDownList);
            DropDownList ddlProProjectDirector = (e.Row.FindControl("ddlProProjectDirector") as DropDownList);
            DropDownList ddlProjectPIC1 = (e.Row.FindControl("ddlProjectPIC1") as DropDownList);
            DropDownList ddlProjectPIC2 = (e.Row.FindControl("ddlProjectPIC2") as DropDownList);

            string user = Session["UserID"].ToString();

            ddlProProjectManager.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin WHERE Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' ORDER BY StaffName");
            ddlProProjectManager.DataTextField = "StaffName";
            ddlProProjectManager.DataValueField = "StaffName";
            ddlProProjectManager.DataBind();
            ddlProProjectManager.Items.Insert(0, new ListItem("-- Please select one --", ""));

            qs2 = "";
            qs2 = qs2 + " SELECT        DISTINCT StaffNo, StaffName ";
            qs2 = qs2 + " FROM          StaffLogin ";
            qs2 = qs2 + " WHERE         Role = 'HeadUnit' or Role = 'ProjectDirector' or Role = 'ProjectManager' or Role = 'HeadDivision' ";
            qs2 = qs2 + " ORDER BY      StaffName ";

            ddlProProjectDirector.DataSource = GetData(qs2);
            ddlProProjectDirector.DataTextField = "StaffName";
            ddlProProjectDirector.DataValueField = "StaffName";
            ddlProProjectDirector.DataBind();
            ddlProProjectDirector.Items.Insert(0, new ListItem("-- Please select one --", ""));

            ddlProjectPIC1.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            ddlProjectPIC1.DataTextField = "StaffName";
            ddlProjectPIC1.DataValueField = "StaffName";
            ddlProjectPIC1.DataBind();
            ddlProjectPIC1.Items.Insert(0, new ListItem("-- Please select one --", ""));

            ddlProjectPIC2.DataSource = GetData("SELECT DISTINCT StaffNo, StaffName FROM StaffLogin ORDER BY StaffName");
            ddlProjectPIC2.DataTextField = "StaffName";
            ddlProjectPIC2.DataValueField = "StaffName";
            ddlProjectPIC2.DataBind();
            ddlProjectPIC2.Items.Insert(0, new ListItem("-- Please select one --", ""));

            string ddlProProjectManagerCode = (e.Row.FindControl("ddlProProjectManagerCode") as TextBox).Text;
            ddlProProjectManager.Items.FindByValue(ddlProProjectManagerCode).Selected = true;

            string ddlProProjectDirectorCode = (e.Row.FindControl("ddlProProjectDirectorCode") as TextBox).Text;
            ddlProProjectDirector.Items.FindByValue(ddlProProjectDirectorCode).Selected = true;

            string ddlProjectPIC1Code = (e.Row.FindControl("ddlProjectPIC1Code") as TextBox).Text;
            ddlProjectPIC1.Items.FindByValue(ddlProjectPIC1Code).Selected = true;

            string ddlProjectPIC2Code = (e.Row.FindControl("ddlProjectPIC2Code") as TextBox).Text;
            ddlProjectPIC2.Items.FindByValue(ddlProjectPIC2Code).Selected = true;
        }
    }

    protected void EditPICProject(object sender, GridViewEditEventArgs e)
    {
        gvPICProject.EditIndex = e.NewEditIndex;
        this.bindProject();
    }

    protected void CancelPICProjectEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPICProject.EditIndex = -1;
        this.bindProject();
    }

    protected void UpdatePICProject(object sender, GridViewUpdateEventArgs e)
    {
        string lblProName = ((Label)gvPICProject.Rows[e.RowIndex].FindControl("lblProName")).Text;
        string lblProNameNewLine = lblProName.Replace(System.Environment.NewLine, string.Empty).ToUpper();

        string lblProCode = ((Label)gvPICProject.Rows[e.RowIndex].FindControl("lblProCode")).Text; //New code - nvarchar
        string ddlProProjectManager = ((DropDownList)gvPICProject.Rows[e.RowIndex].FindControl("ddlProProjectManager")).Text; //pm name - nvarchar
        string ddlProProjectDirector = ((DropDownList)gvPICProject.Rows[e.RowIndex].FindControl("ddlProProjectDirector")).Text;
        string ddlProjectPIC1 = ((DropDownList)gvPICProject.Rows[e.RowIndex].FindControl("ddlProjectPIC1")).Text; //pic1 - nvarchar
        string ddlProjectPIC2 = ((DropDownList)gvPICProject.Rows[e.RowIndex].FindControl("ddlProjectPIC2")).Text; //pic2 - nvarchar

        SqlCommand cmd3 = new SqlCommand("spUpdatePIC", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd3.Parameters.AddWithValue("@action", "UPDATEPROJECT");
        cmd3.Parameters.AddWithValue("@Desc", SqlDbType.NVarChar).Value = lblProNameNewLine;
        cmd3.Parameters.AddWithValue("@Code", SqlDbType.NVarChar).Value = lblProCode;
        cmd3.Parameters.AddWithValue("@pm", SqlDbType.NVarChar).Value = ddlProProjectManager;
        cmd3.Parameters.AddWithValue("@pd", SqlDbType.NVarChar).Value = ddlProProjectDirector;
        cmd3.Parameters.AddWithValue("@pic1", SqlDbType.NVarChar).Value = ddlProjectPIC1;
        cmd3.Parameters.AddWithValue("@pic2", SqlDbType.NVarChar).Value = ddlProjectPIC2;
        cmd3.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = Session["UserID"].ToString();

        con.Open();
        cmd3.ExecuteNonQuery();
        con.Close();

        gvPICProject.EditIndex = -1;
        this.bindProject();
    }
    #endregion
}