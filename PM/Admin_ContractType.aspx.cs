using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PM_Admin_ContractType : System.Web.UI.Page
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
        str = str + " FROM          tblContractType ";
        str = str + " ORDER BY      ContractType ";

        SqlCommand xp = new SqlCommand(str, con);

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvContract.DataSource = ds;
        gvContract.DataBind();
        con.Close();

        for (int i = 0; i < gvContract.Rows.Count; i++)
        {
            GridViewRow row = gvContract.Rows[i];

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
        string ContractType = ((TextBox)gvContract.FooterRow.FindControl("fldContractType")).Text;


        if (!String.IsNullOrEmpty(ContractType))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO tblContractType (ContractType) VALUES (@pContractType)", con);

            cmd.Parameters.AddWithValue("@pContractType", SqlDbType.VarChar).Value = ContractType.Trim();

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
        SqlCommand cmd = new SqlCommand("DELETE FROM tblContractType WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = imgDelete.CommandArgument;
        cmd.ExecuteNonQuery();
        con.Close();

        bindClient();
    }

    protected void EditContractType(object sender, GridViewEditEventArgs e)
    {
        gvContract.EditIndex = e.NewEditIndex;
        bindClient();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvContract.EditIndex = -1;
        bindClient();
    }

    protected void UpdateContractType(object sender, GridViewUpdateEventArgs e)
    {
        string ID = ((Label)gvContract.Rows[e.RowIndex].FindControl("lblID")).Text;
        string ContractType = ((TextBox)gvContract.Rows[e.RowIndex].FindControl("fldContractType")).Text;


        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE tblContractType SET ContractType=@pContractType WHERE ID=@ID", con);

        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
        cmd.Parameters.Add("@pContractType", SqlDbType.VarChar).Value = ContractType;


        cmd.ExecuteNonQuery();

        gvContract.EditIndex = -1;

        bindClient();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }


        //Insert details in tblContractType
        SqlCommand cmdRole = new SqlCommand("INSERT INTO tblContractType (ContractType) VALUES ('" + fldContractType.Text + "')", con);

        cmdRole.ExecuteNonQuery();

        con.Close();

        bindClient();

        fldContractType.Text = "";


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