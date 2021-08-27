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
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Security.Principal;

public partial class ClientCSS : System.Web.UI.Page
{
    string queryString = "";
    DataRow row = null;
    DataRow row1 = null;
    String qs = "";
    String qs1 = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            bindDetails();

            dvDateCompleted.Visible = false;
        }
    }
   
    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblMain.Id, tblMain.Description, tblMain.ClientId, tblClient.ClientName, tblAuditCSS.Id AS CSSId, tblAuditCSS.ClientName AS RespondentName, tblAuditCSS.Email AS RespondentEmail ";
        qs = qs + " FROM          tblMain ";
        qs = qs + " INNER JOIN    tblClient ON tblMain.ClientId = tblClient.Id ";
        qs = qs + " INNER JOIN    tblAuditCSS ON tblMain.Id = tblAuditCSS.DescriptionId ";
        qs = qs + " WHERE         tblMain.Id = '" + Request.QueryString["Id"] + "' ";
        qs = qs + " AND           tblAuditCSS.Id = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(qs, con);
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count == 0)
        {
            //Check for empty record.            
        }
        else
        {
            DataRow row = dt.Rows[0];

            //Project Name
            lblClientName.Text = row["ClientName"].ToString();
            
            //Company Name
            lblDescription.Text = row["Description"].ToString();

            //Respondent Name & Email
            lblRespondentName.Text = row["RespondentName"].ToString();
            lblRespondentEmail.Text = row["RespondentEmail"].ToString();

        }

        qs1 = "";
        qs1 = qs1 + " SELECT        * ";
        qs1 = qs1 + " FROM          tblClientCSS ";
        qs1 = qs1 + " WHERE         DescriptionId = '" + Request.QueryString["Id"] + "' ";
        qs1 = qs1 + " AND           AuditId = '" + Request.QueryString["Id1"] + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd1 = new SqlCommand(qs1, con);
        cmd1.CommandTimeout = 0;

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count == 0)
        {
            //Check for empty record.   
            dvDateCompleted.Visible = false;
        }
        else
        {
            DataRow row1 = dt1.Rows[0];

            dvDateCompleted.Visible = true;

            //Date Completed
            lblCompletedDt.Text = Convert.ToDateTime(row1["SubmittedDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");

            //Period
            object dtStart = row1["StartDate"];
            if (dtStart == DBNull.Value)
            { fldStartDate.Text = "-"; }
            else
            { fldStartDate.Text = Convert.ToDateTime(row1["StartDate"].ToString()).ToString("dd-MMM-yyyy"); }

            object dtEnd = row1["EndDate"];
            if (dtEnd == DBNull.Value)
            { fldEndDate.Text = "-"; }
            else
            { fldEndDate.Text = Convert.ToDateTime(row1["EndDate"].ToString()).ToString("dd-MMM-yyyy"); }

            //Performance Area
            //No. 1
            rbPAa1.Enabled = false;
            rbPAa2.Enabled = false;
            rbPAa3.Enabled = false;
            rbPAa4.Enabled = false;
            rbPAa5.Enabled = false;
            rbPAa6.Enabled = false;
            rbPAa7.Enabled = false;
            rbPAa8.Enabled = false;
            rbPAa9.Enabled = false;
            rbPAa10.Enabled = false;
            rbPAa11.Enabled = false;

            if (row1["PA_1"].ToString() == "1")
                rbPAa1.Checked = true;
            else if (row1["PA_1"].ToString() == "2")
                rbPAa2.Checked = true;
            else if (row1["PA_1"].ToString() == "3")
                rbPAa3.Checked = true;
            else if (row1["PA_1"].ToString() == "4")
                rbPAa4.Checked = true;
            else if (row1["PA_1"].ToString() == "5")
                rbPAa5.Checked = true;
            else if (row1["PA_1"].ToString() == "6")
                rbPAa6.Checked = true;
            else if (row1["PA_1"].ToString() == "7")
                rbPAa7.Checked = true;
            else if (row1["PA_1"].ToString() == "8")
                rbPAa8.Checked = true;
            else if (row1["PA_1"].ToString() == "9")
                rbPAa9.Checked = true;
            else if (row1["PA_1"].ToString() == "10")
                rbPAa10.Checked = true;
            else if (row1["PA_1"].ToString() == "0")
                rbPAa11.Checked = true;

            //No. 2
            rbPAb1.Enabled = false;
            rbPAb2.Enabled = false;
            rbPAb3.Enabled = false;
            rbPAb4.Enabled = false;
            rbPAb5.Enabled = false;
            rbPAb6.Enabled = false;
            rbPAb7.Enabled = false;
            rbPAb8.Enabled = false;
            rbPAb9.Enabled = false;
            rbPAb10.Enabled = false;
            rbPAb11.Enabled = false;

            if (row1["PA_2"].ToString() == "1")
                rbPAb1.Checked = true;
            else if (row1["PA_2"].ToString() == "2")
                rbPAb2.Checked = true;
            else if (row1["PA_2"].ToString() == "3")
                rbPAb3.Checked = true;
            else if (row1["PA_2"].ToString() == "4")
                rbPAb4.Checked = true;
            else if (row1["PA_2"].ToString() == "5")
                rbPAb5.Checked = true;
            else if (row1["PA_2"].ToString() == "6")
                rbPAb6.Checked = true;
            else if (row1["PA_2"].ToString() == "7")
                rbPAb7.Checked = true;
            else if (row1["PA_2"].ToString() == "8")
                rbPAb8.Checked = true;
            else if (row1["PA_2"].ToString() == "9")
                rbPAb9.Checked = true;
            else if (row1["PA_2"].ToString() == "10")
                rbPAb10.Checked = true;
            else if (row1["PA_2"].ToString() == "0")
                rbPAb11.Checked = true;

            //No. 3
            rbPAc1.Enabled = false;
            rbPAc2.Enabled = false;
            rbPAc3.Enabled = false;
            rbPAc4.Enabled = false;
            rbPAc5.Enabled = false;
            rbPAc6.Enabled = false;
            rbPAc7.Enabled = false;
            rbPAc8.Enabled = false;
            rbPAc9.Enabled = false;
            rbPAc10.Enabled = false;
            rbPAc11.Enabled = false;

            if (row1["PA_3"].ToString() == "1")
                rbPAc1.Checked = true;
            else if (row1["PA_3"].ToString() == "2")
                rbPAc2.Checked = true;
            else if (row1["PA_3"].ToString() == "3")
                rbPAc3.Checked = true;
            else if (row1["PA_3"].ToString() == "4")
                rbPAc4.Checked = true;
            else if (row1["PA_3"].ToString() == "5")
                rbPAc5.Checked = true;
            else if (row1["PA_3"].ToString() == "6")
                rbPAc6.Checked = true;
            else if (row1["PA_3"].ToString() == "7")
                rbPAc7.Checked = true;
            else if (row1["PA_3"].ToString() == "8")
                rbPAc8.Checked = true;
            else if (row1["PA_3"].ToString() == "9")
                rbPAc9.Checked = true;
            else if (row1["PA_3"].ToString() == "10")
                rbPAc10.Checked = true;
            else if (row1["PA_3"].ToString() == "0")
                rbPAc11.Checked = true;

            //No. 4
            rbPAd1.Enabled = false;
            rbPAd2.Enabled = false;
            rbPAd3.Enabled = false;
            rbPAd4.Enabled = false;
            rbPAd5.Enabled = false;
            rbPAd6.Enabled = false;
            rbPAd7.Enabled = false;
            rbPAd8.Enabled = false;
            rbPAd9.Enabled = false;
            rbPAd10.Enabled = false;
            rbPAd11.Enabled = false;

            if (row1["PA_4"].ToString() == "1")
                rbPAd1.Checked = true;
            else if (row1["PA_4"].ToString() == "2")
                rbPAd2.Checked = true;
            else if (row1["PA_4"].ToString() == "3")
                rbPAd3.Checked = true;
            else if (row1["PA_4"].ToString() == "4")
                rbPAd4.Checked = true;
            else if (row1["PA_4"].ToString() == "5")
                rbPAd5.Checked = true;
            else if (row1["PA_4"].ToString() == "6")
                rbPAd6.Checked = true;
            else if (row1["PA_4"].ToString() == "7")
                rbPAd7.Checked = true;
            else if (row1["PA_4"].ToString() == "8")
                rbPAd8.Checked = true;
            else if (row1["PA_4"].ToString() == "9")
                rbPAd9.Checked = true;
            else if (row1["PA_4"].ToString() == "10")
                rbPAd10.Checked = true;
            else if (row1["PA_4"].ToString() == "0")
                rbPAd11.Checked = true;

            //No. 5
            rbPAe1.Enabled = false;
            rbPAe2.Enabled = false;
            rbPAe3.Enabled = false;
            rbPAe4.Enabled = false;
            rbPAe5.Enabled = false;
            rbPAe6.Enabled = false;
            rbPAe7.Enabled = false;
            rbPAe8.Enabled = false;
            rbPAe9.Enabled = false;
            rbPAe10.Enabled = false;
            rbPAe11.Enabled = false;

            if (row1["PA_5"].ToString() == "1")
                rbPAe1.Checked = true;
            else if (row1["PA_5"].ToString() == "2")
                rbPAe2.Checked = true;
            else if (row1["PA_5"].ToString() == "3")
                rbPAe3.Checked = true;
            else if (row1["PA_5"].ToString() == "4")
                rbPAe4.Checked = true;
            else if (row1["PA_5"].ToString() == "5")
                rbPAe5.Checked = true;
            else if (row1["PA_5"].ToString() == "6")
                rbPAe6.Checked = true;
            else if (row1["PA_5"].ToString() == "7")
                rbPAe7.Checked = true;
            else if (row1["PA_5"].ToString() == "8")
                rbPAe8.Checked = true;
            else if (row1["PA_5"].ToString() == "9")
                rbPAe9.Checked = true;
            else if (row1["PA_5"].ToString() == "10")
                rbPAe10.Checked = true;
            else if (row1["PA_5"].ToString() == "0")
                rbPAe11.Checked = true;

            //No. 6
            rbPAf1.Enabled = false;
            rbPAf2.Enabled = false;
            rbPAf3.Enabled = false;
            rbPAf4.Enabled = false;
            rbPAf5.Enabled = false;
            rbPAf6.Enabled = false;
            rbPAf7.Enabled = false;
            rbPAf8.Enabled = false;
            rbPAf9.Enabled = false;
            rbPAf10.Enabled = false;
            rbPAf11.Enabled = false;

            if (row1["PA_6"].ToString() == "1")
                rbPAf1.Checked = true;
            else if (row1["PA_6"].ToString() == "2")
                rbPAf2.Checked = true;
            else if (row1["PA_6"].ToString() == "3")
                rbPAf3.Checked = true;
            else if (row1["PA_6"].ToString() == "4")
                rbPAf4.Checked = true;
            else if (row1["PA_6"].ToString() == "5")
                rbPAf5.Checked = true;
            else if (row1["PA_6"].ToString() == "6")
                rbPAf6.Checked = true;
            else if (row1["PA_6"].ToString() == "7")
                rbPAf7.Checked = true;
            else if (row1["PA_6"].ToString() == "8")
                rbPAf8.Checked = true;
            else if (row1["PA_6"].ToString() == "9")
                rbPAf9.Checked = true;
            else if (row1["PA_6"].ToString() == "10")
                rbPAf10.Checked = true;
            else if (row1["PA_6"].ToString() == "0")
                rbPAf11.Checked = true;

            //No. 7
            rbPAg1.Enabled = false;
            rbPAg2.Enabled = false;
            rbPAg3.Enabled = false;
            rbPAg4.Enabled = false;
            rbPAg5.Enabled = false;
            rbPAg6.Enabled = false;
            rbPAg7.Enabled = false;
            rbPAg8.Enabled = false;
            rbPAg9.Enabled = false;
            rbPAg10.Enabled = false;
            rbPAg11.Enabled = false;

            if (row1["PA_7"].ToString() == "1")
                rbPAg1.Checked = true;
            else if (row1["PA_7"].ToString() == "2")
                rbPAg2.Checked = true;
            else if (row1["PA_7"].ToString() == "3")
                rbPAg3.Checked = true;
            else if (row1["PA_7"].ToString() == "4")
                rbPAg4.Checked = true;
            else if (row1["PA_7"].ToString() == "5")
                rbPAg5.Checked = true;
            else if (row1["PA_7"].ToString() == "6")
                rbPAg6.Checked = true;
            else if (row1["PA_7"].ToString() == "7")
                rbPAg7.Checked = true;
            else if (row1["PA_7"].ToString() == "8")
                rbPAg8.Checked = true;
            else if (row1["PA_7"].ToString() == "9")
                rbPAg9.Checked = true;
            else if (row1["PA_7"].ToString() == "10")
                rbPAg10.Checked = true;
            else if (row1["PA_7"].ToString() == "0")
                rbPAg11.Checked = true;

            //No. 8
            rbPAh1.Enabled = false;
            rbPAh2.Enabled = false;
            rbPAh3.Enabled = false;
            rbPAh4.Enabled = false;
            rbPAh5.Enabled = false;
            rbPAh6.Enabled = false;
            rbPAh7.Enabled = false;
            rbPAh8.Enabled = false;
            rbPAh9.Enabled = false;
            rbPAh10.Enabled = false;
            rbPAh11.Enabled = false;

            if (row1["PA_8"].ToString() == "1")
                rbPAh1.Checked = true;
            else if (row1["PA_8"].ToString() == "2")
                rbPAh2.Checked = true;
            else if (row1["PA_8"].ToString() == "3")
                rbPAh3.Checked = true;
            else if (row1["PA_8"].ToString() == "4")
                rbPAh4.Checked = true;
            else if (row1["PA_8"].ToString() == "5")
                rbPAh5.Checked = true;
            else if (row1["PA_8"].ToString() == "6")
                rbPAh6.Checked = true;
            else if (row1["PA_8"].ToString() == "7")
                rbPAh7.Checked = true;
            else if (row1["PA_8"].ToString() == "8")
                rbPAh8.Checked = true;
            else if (row1["PA_8"].ToString() == "9")
                rbPAh9.Checked = true;
            else if (row1["PA_8"].ToString() == "10")
                rbPAh10.Checked = true;
            else if (row1["PA_8"].ToString() == "0")
                rbPAh11.Checked = true;

            //No. 9
            rbPAi1.Enabled = false;
            rbPAi2.Enabled = false;
            rbPAi3.Enabled = false;
            rbPAi4.Enabled = false;
            rbPAi5.Enabled = false;
            rbPAi6.Enabled = false;
            rbPAi7.Enabled = false;
            rbPAi8.Enabled = false;
            rbPAi9.Enabled = false;
            rbPAi10.Enabled = false;
            rbPAi11.Enabled = false;

            if (row1["PA_9"].ToString() == "1")
                rbPAi1.Checked = true;
            else if (row1["PA_9"].ToString() == "2")
                rbPAi2.Checked = true;
            else if (row1["PA_9"].ToString() == "3")
                rbPAi3.Checked = true;
            else if (row1["PA_9"].ToString() == "4")
                rbPAi4.Checked = true;
            else if (row1["PA_9"].ToString() == "5")
                rbPAi5.Checked = true;
            else if (row1["PA_9"].ToString() == "6")
                rbPAi6.Checked = true;
            else if (row1["PA_9"].ToString() == "7")
                rbPAi7.Checked = true;
            else if (row1["PA_9"].ToString() == "8")
                rbPAi8.Checked = true;
            else if (row1["PA_9"].ToString() == "9")
                rbPAi9.Checked = true;
            else if (row1["PA_9"].ToString() == "10")
                rbPAi10.Checked = true;
            else if (row1["PA_9"].ToString() == "0")
                rbPAi11.Checked = true;

            //No. 10
            rbPAj1.Enabled = false;
            rbPAj2.Enabled = false;
            rbPAj3.Enabled = false;
            rbPAj4.Enabled = false;
            rbPAj5.Enabled = false;
            rbPAj6.Enabled = false;
            rbPAj7.Enabled = false;
            rbPAj8.Enabled = false;
            rbPAj9.Enabled = false;
            rbPAj10.Enabled = false;
            rbPAj11.Enabled = false;

            if (row1["PA_10"].ToString() == "1")
                rbPAj1.Checked = true;
            else if (row1["PA_10"].ToString() == "2")
                rbPAj2.Checked = true;
            else if (row1["PA_10"].ToString() == "3")
                rbPAj3.Checked = true;
            else if (row1["PA_10"].ToString() == "4")
                rbPAj4.Checked = true;
            else if (row1["PA_10"].ToString() == "5")
                rbPAj5.Checked = true;
            else if (row1["PA_10"].ToString() == "6")
                rbPAj6.Checked = true;
            else if (row1["PA_10"].ToString() == "7")
                rbPAj7.Checked = true;
            else if (row1["PA_10"].ToString() == "8")
                rbPAj8.Checked = true;
            else if (row1["PA_10"].ToString() == "9")
                rbPAj9.Checked = true;
            else if (row1["PA_10"].ToString() == "10")
                rbPAj10.Checked = true;
            else if (row1["PA_10"].ToString() == "0")
                rbPAj11.Checked = true;

            //Future Engagement / Recommendation
            //No. 11
            rbPERa1.Enabled = false;
            rbPERa2.Enabled = false;
            rbPERa3.Enabled = false;
            rbPERa4.Enabled = false;
            rbPERa5.Enabled = false;
            rbPERa6.Enabled = false;
            rbPERa7.Enabled = false;
            rbPERa8.Enabled = false;
            rbPERa9.Enabled = false;
            rbPERa10.Enabled = false;
            rbPERa11.Enabled = false;

            if (row1["FER_11"].ToString() == "1")
                rbPERa1.Checked = true;
            else if (row1["FER_11"].ToString() == "2")
                rbPERa2.Checked = true;
            else if (row1["FER_11"].ToString() == "3")
                rbPERa3.Checked = true;
            else if (row1["FER_11"].ToString() == "4")
                rbPERa4.Checked = true;
            else if (row1["FER_11"].ToString() == "5")
                rbPERa5.Checked = true;
            else if (row1["FER_11"].ToString() == "6")
                rbPERa6.Checked = true;
            else if (row1["FER_11"].ToString() == "7")
                rbPERa7.Checked = true;
            else if (row1["FER_11"].ToString() == "8")
                rbPERa8.Checked = true;
            else if (row1["FER_11"].ToString() == "9")
                rbPERa9.Checked = true;
            else if (row1["FER_11"].ToString() == "10")
                rbPERa10.Checked = true;
            else if (row1["FER_11"].ToString() == "11")
                rbPERa11.Checked = true;

            //No. 12
            rbPERb1.Enabled = false;
            rbPERb2.Enabled = false;
            rbPERb3.Enabled = false;
            rbPERb4.Enabled = false;
            rbPERb5.Enabled = false;
            rbPERb6.Enabled = false;
            rbPERb7.Enabled = false;
            rbPERb8.Enabled = false;
            rbPERb9.Enabled = false;
            rbPERb10.Enabled = false;
            rbPERb11.Enabled = false;

            if (row1["FER_12"].ToString() == "1")
                rbPERb1.Checked = true;
            else if (row1["FER_12"].ToString() == "2")
                rbPERb2.Checked = true;
            else if (row1["FER_12"].ToString() == "3")
                rbPERb3.Checked = true;
            else if (row1["FER_12"].ToString() == "4")
                rbPERb4.Checked = true;
            else if (row1["FER_12"].ToString() == "5")
                rbPERb5.Checked = true;
            else if (row1["FER_12"].ToString() == "6")
                rbPERb6.Checked = true;
            else if (row1["FER_12"].ToString() == "7")
                rbPERb7.Checked = true;
            else if (row1["FER_12"].ToString() == "8")
                rbPERb8.Checked = true;
            else if (row1["FER_12"].ToString() == "9")
                rbPERb9.Checked = true;
            else if (row1["FER_12"].ToString() == "10")
                rbPERb10.Checked = true;
            else if (row1["FER_12"].ToString() == "11")
                rbPERb11.Checked = true;

            //Remarks
            fldRemarks.Text = row1["Remarks"].ToString();

            //btnSubmit
            object dtSubmit = row1["BtnSubmit"];
            if (dtSubmit == DBNull.Value)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Close window
        Response.Write("<script language='javascript'> { self.close() }</script>");
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

    public static bool IsValidEmailId(string InputEmail)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(InputEmail);
        if (match.Success)
            return true;
        else
            return false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Assigned checker
        Boolean chckDate = false;
        Boolean chckPA = false;
        Boolean chckFER = false;

        //Reset error
        tblHeader.Visible = false;

        errDvDate.Visible = false;

        //----Performance Area
        errDvA01.Visible = false;
        errDvA02.Visible = false;
        errDvA03.Visible = false;
        errDvA04.Visible = false;
        errDvA05.Visible = false;
        errDvA06.Visible = false;
        errDvA07.Visible = false;
        errDvA08.Visible = false;
        errDvA09.Visible = false;
        errDvA10.Visible = false;

        //----Future Engagement / Recommendation
        errDvB01.Visible = false;
        errDvB02.Visible = false;

        //errDvRemarks.Visible = false;

        if (fldStartDate.Text == "" && fldEndDate.Text == "")
        {
            tblHeader.Visible = true;
            errDvDate.Visible = true;
        }
        else
        {
            chckDate = true;
        }
                
        //Performance Area
        if (!rbPAa1.Checked && !rbPAa2.Checked && !rbPAa3.Checked && !rbPAa4.Checked && !rbPAa5.Checked && !rbPAa6.Checked && !rbPAa7.Checked && !rbPAa8.Checked && !rbPAa9.Checked && !rbPAa10.Checked && !rbPAa11.Checked)
        {
            tblHeader.Visible = true;
            errDvA01.Visible = true;
        }
        if (!rbPAb1.Checked && !rbPAb2.Checked && !rbPAb3.Checked && !rbPAb4.Checked && !rbPAb5.Checked && !rbPAb6.Checked && !rbPAb7.Checked && !rbPAb8.Checked && !rbPAb9.Checked && !rbPAb10.Checked && !rbPAb11.Checked)
        {
            tblHeader.Visible = true;
            errDvA02.Visible = true;
        }
        if (!rbPAc1.Checked && !rbPAc2.Checked && !rbPAc3.Checked && !rbPAc4.Checked && !rbPAc5.Checked && !rbPAc6.Checked && !rbPAc7.Checked && !rbPAc8.Checked && !rbPAc9.Checked && !rbPAc10.Checked && !rbPAc11.Checked)
        {
            tblHeader.Visible = true;
            errDvA03.Visible = true;
        }
        if (!rbPAd1.Checked && !rbPAd2.Checked && !rbPAd3.Checked && !rbPAd4.Checked && !rbPAd5.Checked && !rbPAd6.Checked && !rbPAd7.Checked && !rbPAd8.Checked && !rbPAd9.Checked && !rbPAd10.Checked && !rbPAd11.Checked)
        {
            tblHeader.Visible = true;
            errDvA04.Visible = true;

        }
        if (!rbPAe1.Checked && !rbPAe2.Checked && !rbPAe3.Checked && !rbPAe4.Checked && !rbPAe5.Checked && !rbPAe6.Checked && !rbPAe7.Checked && !rbPAe8.Checked && !rbPAe9.Checked && !rbPAe10.Checked && !rbPAe11.Checked)
        {
            tblHeader.Visible = true;
            errDvA05.Visible = true;
        }
        if (!rbPAf1.Checked && !rbPAf2.Checked && !rbPAf3.Checked && !rbPAf4.Checked && !rbPAf5.Checked && !rbPAf6.Checked && !rbPAf7.Checked && !rbPAf8.Checked && !rbPAf9.Checked && !rbPAf10.Checked && !rbPAf11.Checked)
        {
            tblHeader.Visible = true;
            errDvA06.Visible = true;
        }
        if (!rbPAg1.Checked && !rbPAg2.Checked && !rbPAg3.Checked && !rbPAg4.Checked && !rbPAg5.Checked && !rbPAg6.Checked && !rbPAg7.Checked && !rbPAg8.Checked && !rbPAg9.Checked && !rbPAg10.Checked && !rbPAg11.Checked)
        {
            tblHeader.Visible = true;
            errDvA07.Visible = true;
        }
        if (!rbPAh1.Checked && !rbPAh2.Checked && !rbPAh3.Checked && !rbPAh4.Checked && !rbPAh5.Checked && !rbPAh6.Checked && !rbPAh7.Checked && !rbPAh8.Checked && !rbPAh9.Checked && !rbPAh10.Checked && !rbPAh11.Checked)
        {
            tblHeader.Visible = true;
            errDvA08.Visible = true;
        }
        if (!rbPAi1.Checked && !rbPAi2.Checked && !rbPAi3.Checked && !rbPAi4.Checked && !rbPAi5.Checked && !rbPAi6.Checked && !rbPAi7.Checked && !rbPAi8.Checked && !rbPAi9.Checked && !rbPAi10.Checked && !rbPAi11.Checked)
        {
            tblHeader.Visible = true;
            errDvA09.Visible = true;
        }
        if (!rbPAj1.Checked && !rbPAj2.Checked && !rbPAj3.Checked && !rbPAj4.Checked && !rbPAj5.Checked && !rbPAj6.Checked && !rbPAj7.Checked && !rbPAj8.Checked && !rbPAj9.Checked && !rbPAj10.Checked && !rbPAj11.Checked)
        {
            tblHeader.Visible = true;
            errDvA10.Visible = true;
        }
        else
        {
            chckPA = true;
        }
        
        //Future Engagement / Recommendation
        if (!rbPERa1.Checked && !rbPERa2.Checked && !rbPERa3.Checked && !rbPERa4.Checked && !rbPERa5.Checked && !rbPERa6.Checked && !rbPERa7.Checked && !rbPERa8.Checked && !rbPERa9.Checked && !rbPERa10.Checked && !rbPERa11.Checked)
        {
            tblHeader.Visible = true;
            errDvB01.Visible = true;
        }
        if (!rbPERb1.Checked && !rbPERb2.Checked && !rbPERb3.Checked && !rbPERb4.Checked && !rbPERb5.Checked && !rbPERb6.Checked && !rbPERb7.Checked && !rbPERb8.Checked && !rbPERb9.Checked && !rbPERb10.Checked && !rbPERb11.Checked)
        {
            tblHeader.Visible = true;
            errDvB02.Visible = true;
        }
        else
        {
            chckFER = true;
        }
        
        if (chckDate == true && chckPA == true && chckFER == true)
        {
            ////prompt user to enter email if they put Remarks
            //if (fldRemarks.Text != "" && fldEmail.Text == "")
            //{
            //    tblHeader.Visible = true;
            //    errDvRemarks.Visible = true;
            //}
            //else if (fldRemarks.Text != "" && fldEmail.Text != "")
            //{

            //    //validate email
            //    string email = fldEmail.Text;
            //    //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            //    Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
            //    Match match = regex.Match(email);
            //    if (match.Success)
            //    {
            //        insertRecord();
            //    }
            //    else
            //    {
            //        tblHeader.Visible = true;
            //        errDvEmail.Visible = true;
            //    }
            //}
            //else
            //{
                insertRecord();
            //}
        }
    }

    protected void insertRecord()
    {
        DateTime now = DateTime.Now;
        String PAa, PAb, PAc, PAd, PAe, PAf, PAg, PAh, PAi, PAj;
        String PERa, PERb;

        //Performance Area
        if (rbPAa10.Checked)
            PAa = "10";
        else if (rbPAa9.Checked)
            PAa = "9";
        else if (rbPAa8.Checked)
            PAa = "8";
        else if (rbPAa7.Checked)
            PAa = "7";
        else if (rbPAa6.Checked)
            PAa = "6";
        else if (rbPAa5.Checked)
            PAa = "5";
        else if (rbPAa4.Checked)
            PAa = "4";
        else if (rbPAa3.Checked)
            PAa = "3";
        else if (rbPAa2.Checked)
            PAa = "2";
        else if (rbPAa1.Checked)
            PAa = "1";
        else
            PAa = "0";

        if (rbPAb10.Checked)
            PAb = "10";
        else if (rbPAb9.Checked)
            PAb = "9";
        else if (rbPAb8.Checked)
            PAb = "8";
        else if (rbPAb7.Checked)
            PAb = "7";
        else if (rbPAb6.Checked)
            PAb = "6";
        else if (rbPAb5.Checked)
            PAb = "5";
        else if (rbPAb4.Checked)
            PAb = "4";
        else if (rbPAb3.Checked)
            PAb = "3";
        else if (rbPAb2.Checked)
            PAb = "2";
        else if (rbPAb1.Checked)
            PAb = "1";
        else
            PAb = "0";

        if (rbPAc10.Checked)
            PAc = "10";
        else if (rbPAc9.Checked)
            PAc = "9";
        else if (rbPAc8.Checked)
            PAc = "8";
        else if (rbPAc7.Checked)
            PAc = "7";
        else if (rbPAc6.Checked)
            PAc = "6";
        else if (rbPAc5.Checked)
            PAc = "5";
        else if (rbPAc4.Checked)
            PAc = "4";
        else if (rbPAc3.Checked)
            PAc = "3";
        else if (rbPAc2.Checked)
            PAc = "2";
        else if (rbPAc1.Checked)
            PAc = "1";
        else
            PAc = "0";

        if (rbPAd10.Checked)
            PAd = "10";
        else if (rbPAd9.Checked)
            PAd = "9";
        else if (rbPAd8.Checked)
            PAd = "8";
        else if (rbPAd7.Checked)
            PAd = "7";
        else if (rbPAd6.Checked)
            PAd = "6";
        else if (rbPAd5.Checked)
            PAd = "5";
        else if (rbPAd4.Checked)
            PAd = "4";
        else if (rbPAd3.Checked)
            PAd = "3";
        else if (rbPAd2.Checked)
            PAd = "2";
        else if (rbPAd1.Checked)
            PAd = "1";
        else
            PAd = "0";

        if (rbPAe10.Checked)
            PAe = "10";
        else if (rbPAe9.Checked)
            PAe = "9";
        else if (rbPAe8.Checked)
            PAe = "8";
        else if (rbPAe7.Checked)
            PAe = "7";
        else if (rbPAe6.Checked)
            PAe = "6";
        else if (rbPAe5.Checked)
            PAe = "5";
        else if (rbPAe4.Checked)
            PAe = "4";
        else if (rbPAe3.Checked)
            PAe = "3";
        else if (rbPAe2.Checked)
            PAe = "2";
        else if (rbPAe1.Checked)
            PAe = "1";
        else
            PAe = "0";

        if (rbPAf10.Checked)
            PAf = "10";
        else if (rbPAf9.Checked)
            PAf = "9";
        else if (rbPAf8.Checked)
            PAf = "8";
        else if (rbPAf7.Checked)
            PAf = "7";
        else if (rbPAf6.Checked)
            PAf = "6";
        else if (rbPAf5.Checked)
            PAf = "5";
        else if (rbPAf4.Checked)
            PAf = "4";
        else if (rbPAf3.Checked)
            PAf = "3";
        else if (rbPAf2.Checked)
            PAf = "2";
        else if (rbPAf1.Checked)
            PAf = "1";
        else
            PAf = "0";

        if (rbPAg10.Checked)
            PAg = "10";
        else if (rbPAg9.Checked)
            PAg = "9";
        else if (rbPAg8.Checked)
            PAg = "8";
        else if (rbPAg7.Checked)
            PAg = "7";
        else if (rbPAg6.Checked)
            PAg = "6";
        else if (rbPAg5.Checked)
            PAg = "5";
        else if (rbPAg4.Checked)
            PAg = "4";
        else if (rbPAg3.Checked)
            PAg = "3";
        else if (rbPAg2.Checked)
            PAg = "2";
        else if (rbPAg1.Checked)
            PAg = "1";
        else
            PAg = "0";

        if (rbPAh10.Checked)
            PAh = "10";
        else if (rbPAh9.Checked)
            PAh = "9";
        else if (rbPAh8.Checked)
            PAh = "8";
        else if (rbPAh7.Checked)
            PAh = "7";
        else if (rbPAh6.Checked)
            PAh = "6";
        else if (rbPAh5.Checked)
            PAh = "5";
        else if (rbPAh4.Checked)
            PAh = "4";
        else if (rbPAh3.Checked)
            PAh = "3";
        else if (rbPAh2.Checked)
            PAh = "2";
        else if (rbPAh1.Checked)
            PAh = "1";
        else
            PAh = "0";

        if (rbPAi10.Checked)
            PAi = "10";
        else if (rbPAi9.Checked)
            PAi = "9";
        else if (rbPAi8.Checked)
            PAi = "8";
        else if (rbPAi7.Checked)
            PAi = "7";
        else if (rbPAi6.Checked)
            PAi = "6";
        else if (rbPAi5.Checked)
            PAi = "5";
        else if (rbPAi4.Checked)
            PAi = "4";
        else if (rbPAi3.Checked)
            PAi = "3";
        else if (rbPAi2.Checked)
            PAi = "2";
        else if (rbPAi1.Checked)
            PAi = "1";
        else
            PAi = "0";

        if (rbPAj10.Checked)
            PAj = "10";
        else if (rbPAj9.Checked)
            PAj = "9";
        else if (rbPAj8.Checked)
            PAj = "8";
        else if (rbPAj7.Checked)
            PAj = "7";
        else if (rbPAj6.Checked)
            PAj = "6";
        else if (rbPAj5.Checked)
            PAj = "5";
        else if (rbPAj4.Checked)
            PAj = "4";
        else if (rbPAj3.Checked)
            PAj = "3";
        else if (rbPAj2.Checked)
            PAj = "2";
        else if (rbPAj1.Checked)
            PAj = "1";
        else
            PAj = "0";

        //Future Engagement / Recommendation
        if (rbPERa10.Checked)
            PERa = "10";
        else if (rbPERa9.Checked)
            PERa = "9";
        else if (rbPERa8.Checked)
            PERa = "8";
        else if (rbPERa7.Checked)
            PERa = "7";
        else if (rbPERa6.Checked)
            PERa = "6";
        else if (rbPERa5.Checked)
            PERa = "5";
        else if (rbPERa4.Checked)
            PERa = "4";
        else if (rbPERa3.Checked)
            PERa = "3";
        else if (rbPERa2.Checked)
            PERa = "2";
        else if (rbPERa1.Checked)
            PERa = "1";
        else
            PERa = "0";

        if (rbPERb10.Checked)
            PERb = "10";
        else if (rbPERb9.Checked)
            PERb = "9";
        else if (rbPERb8.Checked)
            PERb = "8";
        else if (rbPERb7.Checked)
            PERb = "7";
        else if (rbPERb6.Checked)
            PERb = "6";
        else if (rbPERb5.Checked)
            PERb = "5";
        else if (rbPERb4.Checked)
            PERb = "4";
        else if (rbPERb3.Checked)
            PERb = "3";
        else if (rbPERb2.Checked)
            PERb = "2";
        else if (rbPERb1.Checked)
            PERb = "1";
        else
            PERb = "0";

        queryString = " INSERT INTO     tblClientCSS ";
        queryString += " (AuditId, DescriptionId, StartDate, EndDate, PA_1, PA_2, PA_3, PA_4, PA_5, PA_6, PA_7, PA_8, PA_9, PA_10, FER_11, FER_12, Remarks, SubmittedDate) ";
        queryString += " VALUES ";
        queryString += " (@pAuditId, @pDescriptionId, @pStartDate, @pEndDate, @pPA_1, @pPA_2, @pPA_3, @pPA_4, @pPA_5, @pPA_6, @pPA_7, @pPA_8, @pPA_9, @pPA_10, @pFER_11, @pFER_12, @pRemarks, '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "') ";

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@pDescriptionId", Request.QueryString["Id"]);
        cmd.Parameters.AddWithValue("@pAuditId", Request.QueryString["Id1"]);

        cmd.Parameters.AddWithValue("@pStartDate", fldStartDate.Text);
        cmd.Parameters.AddWithValue("@pEndDate", fldEndDate.Text);

        cmd.Parameters.AddWithValue("@pPA_1", PAa);
        cmd.Parameters.AddWithValue("@pPA_2", PAb);
        cmd.Parameters.AddWithValue("@pPA_3", PAc);
        cmd.Parameters.AddWithValue("@pPA_4", PAd);
        cmd.Parameters.AddWithValue("@pPA_5", PAe);
        cmd.Parameters.AddWithValue("@pPA_6", PAf);
        cmd.Parameters.AddWithValue("@pPA_7", PAg);
        cmd.Parameters.AddWithValue("@pPA_8", PAh);
        cmd.Parameters.AddWithValue("@pPA_9", PAi);
        cmd.Parameters.AddWithValue("@pPA_10", PAj);

        cmd.Parameters.AddWithValue("@pFER_11", PERa);
        cmd.Parameters.AddWithValue("@pFER_12", PERb);

        cmd.Parameters.AddWithValue("@pRemarks", fldRemarks.Text.Trim());
        cmd.ExecuteNonQuery();
        con.Close();

        //Disable btnSubmit in page
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdMain = new SqlCommand("UPDATE tblClientCSS SET "
                + "BtnSubmit = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE AuditId = '" + Request.QueryString["Id1"] + "' ", con);

        cmdMain.ExecuteNonQuery();

        con.Close();

        btnSubmit.Enabled = false;

        //Change Status from Pending to Submitted
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand cmdStatus = new SqlCommand("UPDATE tblAuditCSS SET "
                + "Status = 'Submitted' "
                + "WHERE Id = '" + Request.QueryString["Id1"] + "' ", con);

        cmdStatus.ExecuteNonQuery();

        con.Close();

        Response.Redirect("ClientCSS.aspx?Id=" + Request.QueryString["Id"] + "&Id1=" + Request.QueryString["Id1"]);
    }

    
}