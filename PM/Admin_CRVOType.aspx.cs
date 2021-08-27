using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PM_Admin_CRVOType : System.Web.UI.Page
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
        str = str + " FROM          tblChangeRequestVOType ";
        str = str + " ORDER BY      ChangeRequestVOType ";

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvCRVO.DataSource = ds;
        gvCRVO.DataBind();
        con.Close();

        for (int i = 0; i < gvCRVO.Rows.Count; i++)
        {
            GridViewRow row = gvCRVO.Rows[i];

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
        string CRVO = ((TextBox)gvCRVO.FooterRow.FindControl("fldChangeRequestVariationOrder")).Text;


        if (!String.IsNullOrEmpty(CRVO))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO tblChangeRequestVOType (ChangeRequestVOType) VALUES (@pCRVO)", con);

            cmd.Parameters.AddWithValue("@pCRVO", SqlDbType.VarChar).Value = CRVO.Trim();

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
        //LinkButton lnkRemove = (LinkButton)sender;
        ImageButton imgDelete = (ImageButton)sender;

        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM tblChangeRequestVOType WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();
        con.Close();

        bindClient();
    }

    protected void EditChangeRequestVariationOrder(object sender, GridViewEditEventArgs e)
    {
        gvCRVO.EditIndex = e.NewEditIndex;
        bindClient();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCRVO.EditIndex = -1;
        bindClient();
    }

    protected void UpdateChangeRequestVariationOrder(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvCRVO.Rows[e.RowIndex].FindControl("lblID")).Text;
        string ChangeRequestVariationOrder = ((TextBox)gvCRVO.Rows[e.RowIndex].FindControl("fldChangeRequestVariationOrder")).Text;


        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblChangeRequestVOType SET ChangeRequestVOType=@pCRVO WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pCRVO", SqlDbType.VarChar).Value = ChangeRequestVariationOrder;


        cmd.ExecuteNonQuery();

        gvCRVO.EditIndex = -1;

        bindClient();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }


        //Insert details in tblChangeRequestVOType
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblChangeRequestVOType (ChangeRequestVOType) VALUES ('" + fldChangeRequestVariationOrder.Text + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        bindClient();

        fldChangeRequestVariationOrder.Text = "";

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