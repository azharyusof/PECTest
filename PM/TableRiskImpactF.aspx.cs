using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


public partial class TableRiskImpactF : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
    DataRow row = null;
    String qs = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Label15.Text = "*Source: UEM Edgenta Berhad AOP " + +DateTime.Now.Year;
            GridViewBind();
        }
    }

    public void GridViewBind()
    {
        String str;

        str = "SELECT     * "
                  + "FROM           tblRiskImpactFinance ";
                 
        

        SqlCommand xp = new SqlCommand(str, con);

        
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        xp.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = xp;
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvProjectListing.DataSource = ds;
        gvProjectListing.DataBind();
        con.Close();

        for (int i = 0; i < gvProjectListing.Rows.Count; i++)
        {
            GridViewRow row = gvProjectListing.Rows[i];

            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#FFECEC");
                row.Cells[1].Style.Add("background-color", "#FFECEC");
                row.Cells[2].Style.Add("background-color", "#FFECEC");
                row.Cells[3].Style.Add("background-color", "#FFECEC");
                row.Cells[4].Style.Add("background-color", "#FFECEC");
                row.Cells[5].Style.Add("background-color", "#FFECEC");
            }
        }
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
            HeaderCell.Text = "Factory";
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            
            //HeaderCell = new TableCell();
            //HeaderCell.ColumnSpan = 1;
            //HeaderCell.RowSpan = 2;
            //HeaderCell.Text = "Factory";
            //HeaderCell.VerticalAlign = VerticalAlign.Top;
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            //HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            //HeaderCell.Font.Bold = true;
            //HeaderGridRow.Cells.Add(HeaderCell);
                        
            HeaderCell = new TableCell();
            HeaderCell.Text = "Impact";
            HeaderCell.ColumnSpan = 5;
            HeaderCell.VerticalAlign = VerticalAlign.Top;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BackColor = System.Drawing.Color.FromName("#808080");
            HeaderCell.ForeColor = System.Drawing.Color.FromName("White");
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            gvProjectListing.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }


    protected void gvRiskAssessment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
           e.Row.Cells[0].Visible = false;
            //e.Row.Cells[1].Visible = false;
            //e.Row.Cells[2].Visible = false;
            //e.Row.Cells[3].Visible = false;
            //e.Row.Cells[4].Visible = false;
            //e.Row.Cells[5].Visible = false;
            
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
}