using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PM_Admin_Unit : System.Web.UI.Page
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
        str = str + " FROM          tblOperatingUnit ";
        str = str + " ORDER BY      OperatingUnit ";

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvOperatingUnit.DataSource = ds;
        gvOperatingUnit.DataBind();
        con.Close();

        for (int i = 0; i < gvOperatingUnit.Rows.Count; i++)
        {
            GridViewRow row = gvOperatingUnit.Rows[i];

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
        string OperatingUnit = ((TextBox)gvOperatingUnit.FooterRow.FindControl("fldOperatingUnit")).Text;


        if (!String.IsNullOrEmpty(OperatingUnit))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO tblOperatingUnit (OperatingUnit) VALUES (@pOperatingUnit)", con);

            cmd.Parameters.AddWithValue("@pOperatingUnit", SqlDbType.VarChar).Value = OperatingUnit.Trim();

            cmd.ExecuteNonQuery();

            con.Close();

            bindClient();
        }

        //else
        //{
        //    lblMsg.Visible = true;
        //    lblNote.Visible = false;
        //}
    }

    protected void DeleteRow(object sender, EventArgs e)
    {
        ImageButton imgDelete = (ImageButton)sender;

        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblOperatingUnit WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();
        con.Close();

        bindClient();
    }

    protected void EditOperatingUnit(object sender, GridViewEditEventArgs e)
    {
        gvOperatingUnit.EditIndex = e.NewEditIndex;
        bindClient();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOperatingUnit.EditIndex = -1;
        bindClient();
    }

    protected void UpdateOperatingUnit(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvOperatingUnit.Rows[e.RowIndex].FindControl("lblID")).Text;
        string OperatingUnit = ((TextBox)gvOperatingUnit.Rows[e.RowIndex].FindControl("fldOperatingUnit")).Text;


        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblOperatingUnit SET OperatingUnit=@pOperatingUnit WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pOperatingUnit", SqlDbType.VarChar).Value = OperatingUnit;


        cmd.ExecuteNonQuery();

        gvOperatingUnit.EditIndex = -1;

        bindClient();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }


        //Insert details in tblOperatingUnit
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblOperatingUnit (OperatingUnit) VALUES ('" + fldOperatingUnit.Text + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        bindClient();

        fldOperatingUnit.Text = "";

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