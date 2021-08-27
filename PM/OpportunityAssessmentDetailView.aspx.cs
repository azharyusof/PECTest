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

public partial class OpportunityAssessmentDetailView : System.Web.UI.Page
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
            //Display opportunity details 
            qs = "";
            qs = qs + " SELECT        Description ";
            qs = qs + " FROM          tblMain ";
            qs = qs + " WHERE         Id = '" + Request.QueryString["Id"] + "' ";

            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(qs, con);
            cmd.CommandTimeout = 0;

            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();

            if (dt1.Rows.Count == 0)
            {
                //Check for empty record.
            }
            else
            {
                DataRow row = dt1.Rows[0];

                lblDescription.Text = row["Description"].ToString().ToUpper();
            }

            bindDetails();
        }
    }
    
    protected void bindDetails()
    {
        qs = "";
        qs = qs + " SELECT        tblAssessment.*, ";
        qs = qs + "               tblCREATEBY.StaffName As CREATEBYName,  ";
        qs = qs + "               tblUPDATEBY.StaffName As UPDATEBYName  ";
        qs = qs + " FROM          tblAssessment ";
        qs = qs + " LEFT JOIN     StaffLogin As tblCREATEBY on tblCREATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblAssessment.CreatedBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " LEFT JOIN     StaffLogin As tblUPDATEBY on tblUPDATEBY.StaffNo COLLATE DATABASE_DEFAULT = tblAssessment.ModifyBy COLLATE DATABASE_DEFAULT ";
        qs = qs + " WHERE         tblAssessment.DescriptionId = '" + Request.QueryString["Id"] + "' ";

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

            //A. Financial 
            fldA1_Input.Text = row["A1_Input"].ToString();
            fldA1_Rating.Text = row["A1_Rating"].ToString();
            fldA1_Point.Text = row["A1_Point"].ToString();
            fldA1_Comment.Text = row["A1_Comment"].ToString();

            fldA2_Input.Text = row["A2_Input"].ToString();
            fldA2_Rating.Text = row["A2_Rating"].ToString();
            fldA2_Point.Text = row["A2_Point"].ToString();
            fldA2_Comment.Text = row["A2_Comment"].ToString();

            fldA3_Input.Text = row["A3_Input"].ToString();
            fldA3_Rating.Text = row["A3_Rating"].ToString();
            fldA3_Point.Text = row["A3_Point"].ToString();
            fldA3_Comment.Text = row["A3_Comment"].ToString();

            fldA4_Input.Text = row["A4_Input"].ToString();
            fldA4_Rating.Text = row["A4_Rating"].ToString();
            fldA4_Point.Text = row["A4_Point"].ToString();
            fldA4_Comment.Text = row["A4_Comment"].ToString();

            fldA5_Input.Text = row["A5_Input"].ToString();
            fldA5_Rating.Text = row["A5_Rating"].ToString();
            fldA5_Point.Text = row["A5_Point"].ToString();
            fldA5_Comment.Text = row["A5_Comment"].ToString();

            fldA6_Input.Text = row["A6_Input"].ToString();
            fldA6_Rating.Text = row["A6_Rating"].ToString();
            fldA6_Point.Text = row["A6_Point"].ToString();
            fldA6_Comment.Text = row["A6_Comment"].ToString();

            fldA7_Input.Text = row["A7_Input"].ToString();
            fldA7_Rating.Text = row["A7_Rating"].ToString();
            fldA7_Point.Text = row["A7_Point"].ToString();
            fldA7_Comment.Text = row["A7_Comment"].ToString();

            fldA8_Input.Text = row["A8_Input"].ToString();
            fldA8_Rating.Text = row["A8_Rating"].ToString();
            fldA8_Point.Text = row["A8_Point"].ToString();
            fldA8_Comment.Text = row["A8_Comment"].ToString();

            fldASubTotal.Text = row["SubTotalA"].ToString();

            //B. Project
            fldB1_Input.Text = row["B1_Input"].ToString();
            fldB1_Rating.Text = row["B1_Rating"].ToString();
            fldB1_Point.Text = row["B1_Point"].ToString();
            fldB1_Comment.Text = row["B1_Comment"].ToString();

            fldB2_Input.Text = row["B2_Input"].ToString();
            fldB2_Rating.Text = row["B2_Rating"].ToString();
            fldB2_Point.Text = row["B2_Point"].ToString();
            fldB2_Comment.Text = row["B2_Comment"].ToString();

            fldB3_Input.Text = row["B3_Input"].ToString();
            fldB3_Rating.Text = row["B3_Rating"].ToString();
            fldB3_Point.Text = row["B3_Point"].ToString();
            fldB3_Comment.Text = row["B3_Comment"].ToString();

            fldB4_Input.Text = row["B4_Input"].ToString();
            fldB4_Rating.Text = row["B4_Rating"].ToString();
            fldB4_Point.Text = row["B4_Point"].ToString();
            fldB4_Comment.Text = row["B4_Comment"].ToString();

            fldB5_Input.Text = row["B5_Input"].ToString();
            fldB5_Rating.Text = row["B5_Rating"].ToString();
            fldB5_Point.Text = row["B5_Point"].ToString();
            fldB5_Comment.Text = row["B5_Comment"].ToString();

            fldBSubTotal.Text = row["SubTotalB"].ToString();

            //C. Resources / Competition 
            fldC1_Input.Text = row["C1_Input"].ToString();
            fldC1_Rating.Text = row["C1_Rating"].ToString();
            fldC1_Point.Text = row["C1_Point"].ToString();
            fldC1_Comment.Text = row["C1_Comment"].ToString();

            fldC2_Input.Text = row["C2_Input"].ToString();
            fldC2_Rating.Text = row["C2_Rating"].ToString();
            fldC2_Point.Text = row["C2_Point"].ToString();
            fldC2_Comment.Text = row["C2_Comment"].ToString();

            fldC3_Input.Text = row["C3_Input"].ToString();
            fldC3_Rating.Text = row["C3_Rating"].ToString();
            fldC3_Point.Text = row["C3_Point"].ToString();
            fldC3_Comment.Text = row["C3_Comment"].ToString();

            fldC4_Input.Text = row["C4_Input"].ToString();
            fldC4_Rating.Text = row["C4_Rating"].ToString();
            fldC4_Point.Text = row["C4_Point"].ToString();
            fldC4_Comment.Text = row["C4_Comment"].ToString();

            fldCSubTotal.Text = row["SubTotalC"].ToString();

            //D. Cost and Time to Prepare Proposal 
            fldD1_Input.Text = row["D1_Input"].ToString();
            fldD1_Rating.Text = row["D1_Rating"].ToString();
            fldD1_Point.Text = row["D1_Point"].ToString();
            fldD1_Comment.Text = row["D1_Comment"].ToString();

            fldD2_Input.Text = row["D2_Input"].ToString();
            fldD2_Rating.Text = row["D2_Rating"].ToString();
            fldD2_Point.Text = row["D2_Point"].ToString();
            fldD2_Comment.Text = row["D2_Comment"].ToString();

            fldD3_Input.Text = row["D3_Input"].ToString();
            fldD3_Rating.Text = row["D3_Rating"].ToString();
            fldD3_Point.Text = row["D3_Point"].ToString();
            fldD3_Comment.Text = row["D3_Comment"].ToString();

            fldDSubTotal.Text = row["SubTotalD"].ToString();

            fldTotal.Text = row["GrandTotal"].ToString();

            DateTime varDt;

            //Created By
            if (row["CreatedBy"].ToString() != "")
            {
                lblCreatedBy.Text = row["CREATEBYName"].ToString();
            }
            else
                lblCreatedBy.Text = "-";

            //Created Date
            object dt6 = row["DateCreated"];
            if (dt6 == DBNull.Value)
            { lblCreatedDt.Text = "-"; }
            else
            { lblCreatedDt.Text = Convert.ToDateTime(row["DateCreated"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

            //Modified By 
            if (row["ModifyBy"].ToString() != "")
            {
                lblLastUpdate.Text = row["UPDATEBYName"].ToString();
            }
            else
                lblLastUpdate.Text = "-";

            //Modified Date
            object dt7 = row["DateModify"];
            if (dt7 == DBNull.Value)
            { lblLastUpdateDt.Text = "-"; }
            else
            { lblLastUpdateDt.Text = Convert.ToDateTime(row["DateModify"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt"); }

        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }


    

    protected void fldA1_Input_TextChanged(object sender, EventArgs e)
    {
        double A1_Input;
        double A1_Rating;
        double A1_Point;

        A1_Input = float.Parse(fldA1_Input.Text);
        A1_Rating = (A1_Input * 0.1);
        A1_Point = (A1_Rating * 20);

        fldA1_Rating.Text = A1_Rating.ToString();
        fldA1_Point.Text = A1_Point.ToString();

        fldA1_Comment.Focus();
    }

    protected void fldA2_Input_TextChanged(object sender, EventArgs e)
    {
        double A2_Input;
        double A2_Rating;
        double A2_Point;

        A2_Input = float.Parse(fldA2_Input.Text);
        A2_Rating = (A2_Input * 0.05);
        A2_Point = (A2_Rating * 20);

        fldA2_Rating.Text = A2_Rating.ToString();
        fldA2_Point.Text = A2_Point.ToString();

        fldA2_Comment.Focus();
    }

    protected void fldA3_Input_TextChanged(object sender, EventArgs e)
    {
        double A3_Input;
        double A3_Rating;
        double A3_Point;

        A3_Input = float.Parse(fldA3_Input.Text);
        A3_Rating = (A3_Input * 0.05);
        A3_Point = (A3_Rating * 20);

        fldA3_Rating.Text = A3_Rating.ToString();
        fldA3_Point.Text = A3_Point.ToString();

        fldA3_Comment.Focus();
    }

    protected void fldA4_Input_TextChanged(object sender, EventArgs e)
    {
        double A4_Input;
        double A4_Rating;
        double A4_Point;

        A4_Input = float.Parse(fldA4_Input.Text);
        A4_Rating = (A4_Input * 0.05);
        A4_Point = (A4_Rating * 20);

        fldA4_Rating.Text = A4_Rating.ToString();
        fldA4_Point.Text = A4_Point.ToString();

        fldA4_Comment.Focus();
    }

    protected void fldA5_Input_TextChanged(object sender, EventArgs e)
    {
        double A5_Input;
        double A5_Rating;
        double A5_Point;

        A5_Input = float.Parse(fldA5_Input.Text);
        A5_Rating = (A5_Input * 0.05);
        A5_Point = (A5_Rating * 20);

        fldA5_Rating.Text = A5_Rating.ToString();
        fldA5_Point.Text = A5_Point.ToString();

        fldA5_Comment.Focus();
    }

    protected void fldA6_Input_TextChanged(object sender, EventArgs e)
    {
        double A6_Input;
        double A6_Rating;
        double A6_Point;

        A6_Input = float.Parse(fldA6_Input.Text);
        A6_Rating = (A6_Input * 0.05);
        A6_Point = (A6_Rating * 20);

        fldA6_Rating.Text = A6_Rating.ToString();
        fldA6_Point.Text = A6_Point.ToString();

        fldA6_Comment.Focus();
    }

    protected void fldA7_Input_TextChanged(object sender, EventArgs e)
    {
        double A7_Input;
        double A7_Rating;
        double A7_Point;

        A7_Input = float.Parse(fldA7_Input.Text);
        A7_Rating = (A7_Input * 0.05);
        A7_Point = (A7_Rating * 20);

        fldA7_Rating.Text = A7_Rating.ToString();
        fldA7_Point.Text = A7_Point.ToString();

        fldA7_Comment.Focus();
    }

    protected void fldA8_Input_TextChanged(object sender, EventArgs e)
    {
        double A8_Input;
        double A8_Rating;
        double A8_Point;

        A8_Input = float.Parse(fldA8_Input.Text);
        A8_Rating = (A8_Input * 0.05);
        A8_Point = (A8_Rating * 20);

        fldA8_Rating.Text = A8_Rating.ToString();
        fldA8_Point.Text = A8_Point.ToString();

        fldA8_Comment.Focus();

        //Subtotal A. Financial
        //int totalValue;
        //totalValue = int.Parse(fldA1_Point.Text) + int.Parse(fldA2_Point.Text) + int.Parse(fldA3_Point.Text) + int.Parse(fldA4_Point.Text) + int.Parse(fldA5_Point.Text) + int.Parse(fldA6_Point.Text) + int.Parse(fldA7_Point.Text) + int.Parse(fldA8_Point.Text);

        float totalValue;
        totalValue = float.Parse(fldA1_Point.Text) + float.Parse(fldA2_Point.Text) + float.Parse(fldA3_Point.Text) + float.Parse(fldA4_Point.Text) + float.Parse(fldA5_Point.Text) + float.Parse(fldA6_Point.Text) + float.Parse(fldA7_Point.Text) + float.Parse(fldA8_Point.Text);

        fldASubTotal.Text = totalValue.ToString(); 
    }

    protected void fldB1_Input_TextChanged(object sender, EventArgs e)
    {
        double B1_Input;
        double B1_Rating;
        double B1_Point;

        B1_Input = float.Parse(fldB1_Input.Text);
        B1_Rating = (B1_Input * 0.05);
        B1_Point = (B1_Rating * 20);

        fldB1_Rating.Text = B1_Rating.ToString();
        fldB1_Point.Text = B1_Point.ToString();

        fldB1_Comment.Focus();
    }

    protected void fldB2_Input_TextChanged(object sender, EventArgs e)
    {
        double B2_Input;
        double B2_Rating;
        double B2_Point;

        B2_Input = float.Parse(fldB2_Input.Text);
        B2_Rating = (B2_Input * 0.05);
        B2_Point = (B2_Rating * 20);

        fldB2_Rating.Text = B2_Rating.ToString();
        fldB2_Point.Text = B2_Point.ToString();

        fldB2_Comment.Focus();
    }

    protected void fldB3_Input_TextChanged(object sender, EventArgs e)
    {
        double B3_Input;
        double B3_Rating;
        double B3_Point;

        B3_Input = float.Parse(fldB3_Input.Text);
        B3_Rating = (B3_Input * 0.05);
        B3_Point = (B3_Rating * 20);

        fldB3_Rating.Text = B3_Rating.ToString();
        fldB3_Point.Text = B3_Point.ToString();

        fldB3_Comment.Focus();
    }

    protected void fldB4_Input_TextChanged(object sender, EventArgs e)
    {
        double B4_Input;
        double B4_Rating;
        double B4_Point;

        B4_Input = float.Parse(fldB4_Input.Text);
        B4_Rating = (B4_Input * 0.05);
        B4_Point = (B4_Rating * 20);

        fldB4_Rating.Text = B4_Rating.ToString();
        fldB4_Point.Text = B4_Point.ToString();

        fldB4_Comment.Focus();
    }

    protected void fldB5_Input_TextChanged(object sender, EventArgs e)
    {
        double B5_Input;
        double B5_Rating;
        double B5_Point;

        B5_Input = float.Parse(fldB5_Input.Text);
        B5_Rating = (B5_Input * 0.05);
        B5_Point = (B5_Rating * 20);

        fldB5_Rating.Text = B5_Rating.ToString();
        fldB5_Point.Text = B5_Point.ToString();

        fldB5_Comment.Focus();

        //Subtotal B. Project
        //int totalValue;
        //totalValue = int.Parse(fldB1_Point.Text) + int.Parse(fldB2_Point.Text) + int.Parse(fldB3_Point.Text) + int.Parse(fldB4_Point.Text) + int.Parse(fldB5_Point.Text);

        float totalValue;
        totalValue = float.Parse(fldB1_Point.Text) + float.Parse(fldB2_Point.Text) + float.Parse(fldB3_Point.Text) + float.Parse(fldB4_Point.Text) + float.Parse(fldB5_Point.Text);
        
        fldBSubTotal.Text = totalValue.ToString(); 
    }

    protected void fldC1_Input_TextChanged(object sender, EventArgs e)
    {
        double C1_Input;
        double C1_Rating;
        double C1_Point;

        C1_Input = float.Parse(fldC1_Input.Text);
        C1_Rating = (C1_Input * 0.05);
        C1_Point = (C1_Rating * 20);

        fldC1_Rating.Text = C1_Rating.ToString();
        fldC1_Point.Text = C1_Point.ToString();

        fldC1_Comment.Focus();
    }

    protected void fldC2_Input_TextChanged(object sender, EventArgs e)
    {
        double C2_Input;
        double C2_Rating;
        double C2_Point;

        C2_Input = float.Parse(fldC2_Input.Text);
        C2_Rating = (C2_Input * 0.05);
        C2_Point = (C2_Rating * 20);

        fldC2_Rating.Text = C2_Rating.ToString();
        fldC2_Point.Text = C2_Point.ToString();

        fldC2_Comment.Focus();
    }

    protected void fldC3_Input_TextChanged(object sender, EventArgs e)
    {
        double C3_Input;
        double C3_Rating;
        double C3_Point;

        C3_Input = float.Parse(fldC3_Input.Text);
        C3_Rating = (C3_Input * 0.05);
        C3_Point = (C3_Rating * 20);

        fldC3_Rating.Text = C3_Rating.ToString();
        fldC3_Point.Text = C3_Point.ToString();

        fldC3_Comment.Focus();
    }

    protected void fldC4_Input_TextChanged(object sender, EventArgs e)
    {
        double C4_Input;
        double C4_Rating;
        double C4_Point;

        C4_Input = float.Parse(fldC4_Input.Text);
        C4_Rating = (C4_Input * 0.05);
        C4_Point = (C4_Rating * 20);

        fldC4_Rating.Text = C4_Rating.ToString();
        fldC4_Point.Text = C4_Point.ToString();

        fldC4_Comment.Focus();

        //Subtotal C. Resources/Competition 
        //int totalValue;
        //totalValue = int.Parse(fldC1_Point.Text) + int.Parse(fldC2_Point.Text) + int.Parse(fldC3_Point.Text) + int.Parse(fldC4_Point.Text);

        float totalValue;
        totalValue = float.Parse(fldC1_Point.Text) + float.Parse(fldC2_Point.Text) + float.Parse(fldC3_Point.Text) + float.Parse(fldC4_Point.Text);
        
        fldCSubTotal.Text = totalValue.ToString();
    }

    protected void fldD1_Input_TextChanged(object sender, EventArgs e)
    {
        double D1_Input;
        double D1_Rating;
        double D1_Point;

        D1_Input = float.Parse(fldD1_Input.Text);
        D1_Rating = (D1_Input * 0.03);
        D1_Point = (D1_Rating * 20);

        fldD1_Rating.Text = D1_Rating.ToString();
        fldD1_Point.Text = D1_Point.ToString();

        fldD1_Comment.Focus();
    }

    protected void fldD2_Input_TextChanged(object sender, EventArgs e)
    {
        double D2_Input;
        double D2_Rating;
        double D2_Point;

        D2_Input = float.Parse(fldD2_Input.Text);
        D2_Rating = (D2_Input * 0.03);
        D2_Point = (D2_Rating * 20);

        fldD2_Rating.Text = D2_Rating.ToString();
        fldD2_Point.Text = D2_Point.ToString();

        fldD2_Comment.Focus();
    }

    protected void fldD3_Input_TextChanged(object sender, EventArgs e)
    {
        double D3_Input;
        double D3_Rating;
        double D3_Point;

        D3_Input = float.Parse(fldD3_Input.Text);
        D3_Rating = (D3_Input * 0.04);
        D3_Point = (D3_Rating * 20);

        fldD3_Rating.Text = D3_Rating.ToString();
        fldD3_Point.Text = D3_Point.ToString();

        fldD3_Comment.Focus();

        //Subtotal D. Cost and Time to Prepare 
        //int totalValue;
        //totalValue = int.Parse(fldD1_Point.Text) + int.Parse(fldD2_Point.Text) + int.Parse(fldD3_Point.Text);

        float totalValue;
        totalValue = float.Parse(fldD1_Point.Text) + float.Parse(fldD2_Point.Text) + float.Parse(fldD3_Point.Text);

        fldDSubTotal.Text = totalValue.ToString();

        //Total (A + B + C + D)
        //int grandtotalValue;
        //grandtotalValue = int.Parse(fldASubTotal.Text) + int.Parse(fldBSubTotal.Text) + int.Parse(fldCSubTotal.Text) + int.Parse(fldDSubTotal.Text);

        float grandtotalValue;
        grandtotalValue = float.Parse(fldASubTotal.Text) + float.Parse(fldBSubTotal.Text) + float.Parse(fldCSubTotal.Text) + float.Parse(fldDSubTotal.Text);
        
        fldTotal.Text = grandtotalValue.ToString();
    }
}
