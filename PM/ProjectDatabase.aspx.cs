using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
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

public partial class ProjectDatabase : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
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

        btnClear.Visible = false;

        if (!Page.IsPostBack)
        {
            GridViewBind();
            lblPM.Text = Session["UserID"].ToString();
        }
    }
       

    public void GridViewBind()
    {
        String str;
        
        if (fldSearch.Text.Trim() != "")
        {
            str = "SELECT           vwProjectDatabase.Id, vwProjectDatabase.Company, vwProjectDatabase.Year, vwProjectDatabase.Package_Ref_BDU, vwProjectDatabase.Fin_Code, vwProjectDatabase.ClientName, vwProjectDatabase.ProjectManager, vwProjectDatabase.Status, vwProjectDatabase.ProjectType, vwProjectDatabase.PMName, vwProjectDatabase.ProjectDbMigrateStatus "
                  + "FROM           vwProjectDatabase "
                  + "WHERE          (vwProjectDatabase.Company LIKE '%' + @search + '%' OR vwProjectDatabase.Package_Ref_BDU LIKE '%' + @search + '%' OR vwProjectDatabase.ClientName LIKE '%' + @search + '%' OR vwProjectDatabase.PMName LIKE '%' + @search + '%' OR vwProjectDatabase.Status LIKE '%' + @search + '%' OR vwProjectDatabase.ProjectType LIKE '%' + @search + '%' OR vwProjectDatabase.Year LIKE '%' + @search + '%') "
                  + "ORDER BY       vwProjectDatabase.Id DESC ";
        }
        else
        {
            str = "SELECT           vwProjectDatabase.Id, vwProjectDatabase.Company, vwProjectDatabase.Year, vwProjectDatabase.Package_Ref_BDU, vwProjectDatabase.Fin_Code, vwProjectDatabase.ClientName, vwProjectDatabase.ProjectManager, vwProjectDatabase.Status, vwProjectDatabase.ProjectType, vwProjectDatabase.PMName, vwProjectDatabase.ProjectDbMigrateStatus "
                  + "FROM           vwProjectDatabase "
                  + "ORDER BY       vwProjectDatabase.Id DESC ";
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
                row.Cells[6].Style.Add("background-color", "#FFECEC");
                row.Cells[7].Style.Add("background-color", "#FFECEC");
                row.Cells[8].Style.Add("background-color", "#FFECEC");
                row.Cells[9].Style.Add("background-color", "#FFECEC");
            }
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        fldSearch.Text = "";
        
        GridViewBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search_Word = fldSearch.Text.Trim();

        btnClear.Visible = true;
        
        GridViewBind();
    }
    
    protected void gvProjectListing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var Link = (HyperLink)e.Row.FindControl("hlDescription");

            Label Id = e.Row.FindControl("lblId") as Label;
            

            Label Description = e.Row.FindControl("lblDescription") as Label;
            Label ProjectManager = e.Row.FindControl("lblProjectManager") as Label;
            Label ProjectType = e.Row.FindControl("lblProjectType") as Label;

            Link.NavigateUrl = "ProjectDbInfo.aspx?Id=" + Id.Text;

            if (lblAdmin.Text == Session["UserID"].ToString() || lblAdmin1.Text == Session["UserID"].ToString() || lblAdmin2.Text == Session["UserID"].ToString() || lblAdmin3.Text == Session["UserID"].ToString())
            {
                Description.Visible = false;
                Link.Visible = true;
            }
            else
            {
                Description.Visible = false;
                Link.Visible = true;
            }
                                    
        }
    }

    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
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