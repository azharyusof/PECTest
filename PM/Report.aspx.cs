using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Report : System.Web.UI.Page
{
    protected string search_Word = String.Empty;
    DataRow row = null;
    DataRow rowA = null;
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
            GridViewBind();
        }
    }

       
    public void GridViewBind()
    {
        String str;
        String category;

        if (Request.QueryString["Mode"] == "O")
        {
            category = "(Category = 'Opportunity') ";
        }
        else
        {
            category = "(Category = 'Project') ";
        }

        str = "SELECT           * "
                  + "FROM           vwReport "
                  + "WHERE " + category + ""
                  + "ORDER BY       DateCreated DESC ";

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
                row.Cells[6].Style.Add("background-color", "#FFECEC");
                row.Cells[7].Style.Add("background-color", "#FFECEC");
                row.Cells[8].Style.Add("background-color", "#FFECEC");
                row.Cells[9].Style.Add("background-color", "#FFECEC");
            }
        }
    }

    
    protected void gvProjectListing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (Request.QueryString["Mode"] != "O")
            {
                e.Row.Cells[9].Visible = false;
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString["Mode"] != "O")
            {
                e.Row.Cells[9].Visible = false;
            }

            Label Decision = e.Row.FindControl("lblDecision") as Label;

            if (Decision.Text == "NO-GO")
            {
                Decision.ForeColor = Color.Red;
            }
        }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable tableA = new DataTable();

        //Create array A
        tableA.Columns.Add("Ano", typeof(string));
        tableA.Columns.Add("AOperatingCompany", typeof(string));
        tableA.Columns.Add("ADescription", typeof(string));
        tableA.Columns.Add("ACategory", typeof(string));
        tableA.Columns.Add("AFinanceCode", typeof(string));
        tableA.Columns.Add("AClientName", typeof(string));
        tableA.Columns.Add("APMName", typeof(string));
        tableA.Columns.Add("AStatus", typeof(string));
        tableA.Columns.Add("AStartDate", typeof(string));
        tableA.Columns.Add("AEndDate", typeof(string));
        tableA.Columns.Add("ADecision", typeof(string));

        String category;

        if (Request.QueryString["Mode"] == "O")
        {
            category = "(Category = 'Opportunity') ";
        }
        else
        {
            category = "(Category = 'Project') ";
        }

        qs = "SELECT           *, FORMAT(StartDate, 'dd-MMM-yyyy') AS SDate, FORMAT(EndDate, 'dd-MMM-yyyy') AS EDate "
                  + "FROM           vwReport "
                  + "WHERE " + category + ""
                  + "ORDER BY       vwReport.DateCreated DESC ";
       
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        cmd = new SqlCommand(qs, con);

        cmd.CommandTimeout = 0;
        SqlDataAdapter daA = new SqlDataAdapter(cmd);
        DataTable dtA = new DataTable();
        daA.Fill(dtA);
        con.Close();

        if (dtA.Rows.Count != 0)
        {
            for (int i = 0; i < dtA.Rows.Count; i++)
            {
                row = null;
                row = dtA.Rows[i];

                rowA = null;
                rowA = tableA.NewRow();
                rowA["Ano"] = (i + 1).ToString();
                rowA["AOperatingCompany"] = row["OperatingCompany"].ToString();
                rowA["ADescription"] = row["Description"].ToString();
                rowA["ACategory"] = row["Category"].ToString();
                rowA["AFinanceCode"] = row["FinanceCode"].ToString();
                rowA["AClientName"] = row["ClientName"].ToString();
                rowA["APMName"] = row["PMName"].ToString();
                rowA["AStatus"] = row["Status"].ToString();
                rowA["AStartDate"] = row["SDate"].ToString();
                rowA["AEndDate"] = row["EDate"].ToString();
                rowA["ADecision"] = row["Decision"].ToString();

                tableA.Rows.Add(rowA);
            }
        }

        RunExcel(tableA);
    }

    public void RunExcel(DataTable tbA)
    {
        using (var package = new ExcelPackage())
        {
            // Add a new worksheet to the empty workbook
            ExcelWorksheet wsA = package.Workbook.Worksheets.Add("PEC Listing");
                        
            //Add the headers
            wsA.Cells["A1"].Value = "No";
            wsA.Cells["B1"].Value = "Operating Company";
            wsA.Cells["C1"].Value = "Opportunity / Project Name";
            wsA.Cells["D1"].Value = "Category";
            wsA.Cells["E1"].Value = "Code";
            wsA.Cells["F1"].Value = "Client Name";
            wsA.Cells["G1"].Value = "Project Manager";
            wsA.Cells["H1"].Value = "Status";
            wsA.Cells["I1"].Value = "Start Date";
            wsA.Cells["J1"].Value = "End Date";
            wsA.Cells["K1"].Value = "Decision";
            
            wsA.Cells["A1:K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            wsA.Cells["A1:K1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
            wsA.Cells["A1:K1"].Style.Font.Bold = true;

            wsA.Cells["A2"].LoadFromDataTable(tbA, false);
            wsA.Cells["A1:K1"].AutoFilter = true;
            wsA.Cells.AutoFitColumns(0);

            var allCellsA = wsA.Cells[1, 1, wsA.Dimension.End.Row, wsA.Dimension.End.Column];
            var cellFontA = allCellsA.Style.Font;
            cellFontA.SetFromFont(new Font("Tahoma", 8));

            // set some document properties
            package.Workbook.Properties.Title = "PEC_Excel_Extraction";
            package.Workbook.Properties.Author = "Edgenta IT";

            // set some extended property values
            package.Workbook.Properties.Company = "Edgenta";

            // set some custom property values
            package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Edgenta IT Team, SaaS");
            package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "PEC");

            // Save the Excel file
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;  filename=PEC Listing.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();

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