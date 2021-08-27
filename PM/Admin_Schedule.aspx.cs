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

public partial class Admin_Schedule : System.Web.UI.Page
{
    DataRow row = null;
    String qs = "";
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
            bindSchedule();
        }
    }

    public void bindSchedule()
    {
        String str;

        str = "";
        str = str + " SELECT        * ";
        str = str + " FROM          tblProjectSchedule ";
        str = str + " ORDER BY      ProjectSchedule ";

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvSchedule.DataSource = ds;
        gvSchedule.DataBind();
        con.Close();

        for (int i = 0; i < gvSchedule.Rows.Count; i++)
        {
            GridViewRow row = gvSchedule.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
            }
        }
    }


    protected void AddNewRow(object sender, EventArgs e)
    {
        string Schedule = ((TextBox)gvSchedule.FooterRow.FindControl("fldSchedule")).Text;

        if (!String.IsNullOrEmpty(Schedule))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO tblProjectSchedule (ProjectSchedule) VALUES (@pSchedule)", con);

            cmd.Parameters.AddWithValue("@pSchedule", SqlDbType.VarChar).Value = Schedule.Trim();

            cmd.ExecuteNonQuery();

            con.Close();

            bindSchedule();
        }

        else
        {
            lblMsg.Visible = true;
            lblNote.Visible = false;
        }
    }


    protected void DeleteRow(object sender, EventArgs e)
    {
        //LinkButton lnkRemove = (LinkButton)sender;
        ImageButton imgDelete = (ImageButton)sender;

        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblProjectSchedule WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();
        con.Close();

        bindSchedule();
    }

    protected void EditSchedule(object sender, GridViewEditEventArgs e)
    {
        gvSchedule.EditIndex = e.NewEditIndex;
        bindSchedule();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSchedule.EditIndex = -1;
        bindSchedule();
    }

    protected void UpdateSchedule(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvSchedule.Rows[e.RowIndex].FindControl("lblID")).Text;
        string Schedule = ((TextBox)gvSchedule.Rows[e.RowIndex].FindControl("fldSchedule")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblProjectSchedule SET ProjectSchedule=@pSchedule WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pSchedule", SqlDbType.VarChar).Value = Schedule;

        cmd.ExecuteNonQuery();

        gvSchedule.EditIndex = -1;

        bindSchedule();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }


        //Insert details in tblSchedule
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblProjectSchedule (ProjectSchedule) VALUES ('" + fldSchedule.Text + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        bindSchedule();

        fldSchedule.Text = "";
    }

    protected void btnClose_Click(object sender, EventArgs e)
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