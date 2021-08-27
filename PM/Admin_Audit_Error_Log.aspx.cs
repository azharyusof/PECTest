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

public partial class PM_Admin_Audit_Error_Log : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Default.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            bindAuditLog();
            bindErrorLog();

            DateTime now = DateTime.Now;

            TabName.Value = Request.Form[TabName.UniqueID];

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
    #region bindAuditLog
    protected void bindAuditLog()
    {
        string user = Session["UserID"].ToString();
        string absolutepath = HttpContext.Current.Request.Url.AbsolutePath;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);

        try
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand();

                if (fldAuditSearch.Text.Trim() != "")
                {

                    cmd = new SqlCommand("spAuditLogListbySearch", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = cmd;
                    da.SelectCommand.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "%" + fldAuditSearch.Text.Trim() + "%";

                    con.Open();
                    cmd.ExecuteNonQuery();

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    gvAuditLog.DataSource = ds;
                    gvAuditLog.DataBind();
                }
                else
                {
                    cmd = new SqlCommand("spAuditLogList", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = con;

                    con.Open();
                    gvAuditLog.DataSource = cmd.ExecuteReader();
                    gvAuditLog.DataBind();
                }
            }

            for (int i = 0; i < gvAuditLog.Rows.Count; i++)
            {
                GridViewRow row = gvAuditLog.Rows[i];

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
        catch (Exception ex)
        {
            ErrorLog.WriteToEventLog(ex, absolutepath, user);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    #endregion

    #region bindErrorLog
    protected void bindErrorLog()
    {
        string user = Session["UserID"].ToString();
        string absolutepath = HttpContext.Current.Request.Url.AbsolutePath;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);

        try
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                SqlCommand cmd = new SqlCommand();

                if(fldErrorSearch.Text.Trim() != "")
                {
                    cmd = new SqlCommand("spErrorLogListbySearch", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = cmd;
                    da.SelectCommand.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "%" + fldErrorSearch.Text.Trim() + "%";

                    con.Open();
                    cmd.ExecuteNonQuery();

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    gvErrorLog.DataSource = ds;
                    gvErrorLog.DataBind();
                }
                else
                {
                    SqlCommand xp = new SqlCommand("spErrorLogList", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    xp.Connection = con;

                    con.Open();
                    gvErrorLog.DataSource = xp.ExecuteReader();
                    gvErrorLog.DataBind();
                }
            }

            for (int i = 0; i < gvErrorLog.Rows.Count; i++)
            {
                GridViewRow row = gvErrorLog.Rows[i];

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
        catch (Exception ex)
        {
            ErrorLog.WriteToEventLog(ex, absolutepath, user);
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    #endregion
    #endregion

    #region Search & Clear 
    private bool buttonWasClicked = false;

    protected void btnAuditClear_Click(object sender, EventArgs e)
    {
        fldAuditSearch.Text = string.Empty;
        bindAuditLog();
    }

    protected void btnAuditSearch_Click(object sender, EventArgs e)
    {
        btnAuditClear.Visible = true;
        bindAuditLog();
    }

    protected void btnErrorClear_Click(object sender, EventArgs e)
    {
        fldErrorSearch.Text = string.Empty;
        bindErrorLog();
    }

    protected void btnErrorSearch_Click(object sender, EventArgs e)
    {
        btnErrorClear.Visible = true;
        bindErrorLog();
    }
    #endregion
}