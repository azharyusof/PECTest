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

public partial class Admin_Client : System.Web.UI.Page
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
            bindClient();
        }            
    }

    public void bindClient()
    {
        String str;
                    
            str = "";
            str = str + " SELECT        * ";
            str = str + " FROM          tblClient ";
            str = str + " ORDER BY      ClientName ";
                    
            SqlCommand xp = new SqlCommand(str, con);

            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvClient.DataSource = ds;
            gvClient.DataBind();
            con.Close();

            for (int i = 0; i < gvClient.Rows.Count; i++)
            {
                GridViewRow row = gvClient.Rows[i];

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
        string Code = ((TextBox)gvClient.FooterRow.FindControl("fldCode")).Text;
        string ClientName = ((TextBox)gvClient.FooterRow.FindControl("fldClientName")).Text;

        if (!String.IsNullOrEmpty(Code))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO tblClient (ClientName) VALUES (@pClientName)", con);

            cmd.Parameters.AddWithValue("@pClientName", SqlDbType.VarChar).Value = ClientName.Trim();

            cmd.ExecuteNonQuery();

            con.Close();

            bindClient();
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
        SqlCommand cmd = new SqlCommand("DELETE FROM tblClient WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();
        con.Close();

        bindClient();
    }

    protected void EditClient(object sender, GridViewEditEventArgs e)
    {
        gvClient.EditIndex = e.NewEditIndex;
        bindClient();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvClient.EditIndex = -1;
        bindClient();
    }

    protected void UpdateClient(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvClient.Rows[e.RowIndex].FindControl("lblID")).Text;
        string ClientName = ((TextBox)gvClient.Rows[e.RowIndex].FindControl("fldClientName")).Text;

        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblClient SET ClientName=@pClientName WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pClientName", SqlDbType.VarChar).Value = ClientName;

        cmd.ExecuteNonQuery();

        gvClient.EditIndex = -1;

        bindClient();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

 
        //Insert details in tblClient
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblClient (ClientName) VALUES ('" + fldClientName.Text + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        bindClient();

        fldClientName.Text = "";
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