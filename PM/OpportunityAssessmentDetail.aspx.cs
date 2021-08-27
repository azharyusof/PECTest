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

public partial class OpportunityAssessmentDetail : System.Web.UI.Page
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
            checkRole();

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

    protected void checkRole()
    {
        qs = "";
        qs = qs + " SELECT        Role  ";
        qs = qs + " FROM          StaffLogin ";
        qs = qs + " WHERE         StaffNo = '" + Session["UserID"].ToString() + "' ";

        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
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

            if (row["Role"].ToString() == "Auditor" || row["Role"].ToString() == "HSE")
            {
                btnUpdate.Visible = false;
                btnComplete.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
                btnComplete.Visible = true;
            }
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

            //btnUpdate & btnComplete
            object dt8 = row["BtnComplete"];
            if (dt8 == DBNull.Value)
            {
                btnUpdate.Enabled = true;
                btnComplete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnComplete.Enabled = false;
            }
        }
    }

    protected void btnListing_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectListing.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updateAssessment();
        
        Response.Redirect("OpportunityAssessmentDetail.aspx?Id=" + Request.QueryString["Id"]);
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {

    }

    protected void btnComplete_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;

        Boolean chckErr = true;

        //Reset error
        dvA1.Attributes.Add("class", null);
        dvA2.Attributes.Add("class", null);
        dvA3.Attributes.Add("class", null);
        dvA4.Attributes.Add("class", null);
        dvA5.Attributes.Add("class", null);
        dvA6.Attributes.Add("class", null);
        dvA7.Attributes.Add("class", null);
        dvA8.Attributes.Add("class", null);

        dvB1.Attributes.Add("class", null);
        dvB2.Attributes.Add("class", null);
        dvB3.Attributes.Add("class", null);
        dvB4.Attributes.Add("class", null);
        dvB5.Attributes.Add("class", null);

        dvC1.Attributes.Add("class", null);
        dvC2.Attributes.Add("class", null);
        dvC3.Attributes.Add("class", null);
        dvC4.Attributes.Add("class", null);

        dvD1.Attributes.Add("class", null);
        dvD2.Attributes.Add("class", null);
        dvD3.Attributes.Add("class", null);

        if (fldA1_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA1.Attributes.Add("class", "has-error");
        }

        if (fldA2_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA2.Attributes.Add("class", "has-error");
        }

        if (fldA3_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA3.Attributes.Add("class", "has-error");
        }

        if (fldA4_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA4.Attributes.Add("class", "has-error");
        }

        if (fldA5_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA5.Attributes.Add("class", "has-error");
        }

        if (fldA6_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA6.Attributes.Add("class", "has-error");
        }

        if (fldA7_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA7.Attributes.Add("class", "has-error");
        }

        if (fldA8_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvA8.Attributes.Add("class", "has-error");
        }

        if (fldB1_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvB1.Attributes.Add("class", "has-error");
        }

        if (fldB2_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvB2.Attributes.Add("class", "has-error");
        }

        if (fldB3_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvB3.Attributes.Add("class", "has-error");
        }

        if (fldB4_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvB4.Attributes.Add("class", "has-error");
        }

        if (fldB5_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvB5.Attributes.Add("class", "has-error");
        }

        if (fldC1_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvC1.Attributes.Add("class", "has-error");
        }

        if (fldC2_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvC2.Attributes.Add("class", "has-error");
        }

        if (fldC3_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvC3.Attributes.Add("class", "has-error");
        }

        if (fldC4_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvC4.Attributes.Add("class", "has-error");
        }

        if (fldD1_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvD1.Attributes.Add("class", "has-error");
        }

        if (fldD2_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvD2.Attributes.Add("class", "has-error");
        }

        if (fldD3_Input.Text.Trim() == "")
        {
            chckErr = false;
            dvD3.Attributes.Add("class", "has-error");
        }

        if (chckErr == true)
        {
            updateAssessment();

            //Disable btnUpdate & btnComplete in page
            if (con.State == System.Data.ConnectionState.Closed)
            { con.Open(); }

            SqlCommand cmdMain = new SqlCommand("UPDATE tblAssessment SET "
                    + "BtnComplete = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                    + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "' ", con);

            cmdMain.ExecuteNonQuery();

            con.Close();

            btnUpdate.Enabled = false;
            btnComplete.Enabled = false;

            Response.Redirect("OpportunityAssessmentDetail.aspx?Id=" + Request.QueryString["Id"]);
        }
    }

    protected void updateAssessment()
    {
        DateTime now = DateTime.Now;

        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        //Update into table tblAssessment
        SqlCommand cmd = new SqlCommand("UPDATE tblAssessment SET "
                + "A1_Input = @pA1_Input, "
                + "A1_Rating = @pA1_Rating, "
                + "A1_Point = @pA1_Point, "
                + "A1_Comment = @pA1_Comment, "
                + "A2_Input = @pA2_Input, "
                + "A2_Rating = @pA2_Rating, "
                + "A2_Point = @pA2_Point, "
                + "A2_Comment = @pA2_Comment, "
                + "A3_Input = @pA3_Input, "
                + "A3_Rating = @pA3_Rating, "
                + "A3_Point = @pA3_Point, "
                + "A3_Comment = @pA3_Comment, "
                + "A4_Input = @pA4_Input, "
                + "A4_Rating = @pA4_Rating, "
                + "A4_Point = @pA4_Point, "
                + "A4_Comment = @pA4_Comment, "
                + "A5_Input = @pA5_Input, "
                + "A5_Rating = @pA5_Rating, "
                + "A5_Point = @pA5_Point, "
                + "A5_Comment = @pA5_Comment, "
                + "A6_Input = @pA6_Input, "
                + "A6_Rating = @pA6_Rating, "
                + "A6_Point = @pA6_Point, "
                + "A6_Comment = @pA6_Comment, "
                + "A7_Input = @pA7_Input, "
                + "A7_Rating = @pA7_Rating, "
                + "A7_Point = @pA7_Point, "
                + "A7_Comment = @pA7_Comment, "
                + "A8_Input = @pA8_Input, "
                + "A8_Rating = @pA8_Rating, "
                + "A8_Point = @pA8_Point, "
                + "A8_Comment = @pA8_Comment, "
                + "SubTotalA = @pSubTotalA, "
                + "B1_Input = @pB1_Input, "
                + "B1_Rating = @pB1_Rating, "
                + "B1_Point = @pB1_Point, "
                + "B1_Comment = @pB1_Comment, "
                + "B2_Input = @pB2_Input, "
                + "B2_Rating = @pB2_Rating, "
                + "B2_Point = @pB2_Point, "
                + "B2_Comment = @pB2_Comment, "
                + "B3_Input = @pB3_Input, "
                + "B3_Rating = @pB3_Rating, "
                + "B3_Point = @pB3_Point, "
                + "B3_Comment = @pB3_Comment, "
                + "B4_Input = @pB4_Input, "
                + "B4_Rating = @pB4_Rating, "
                + "B4_Point = @pB4_Point, "
                + "B4_Comment = @pB4_Comment, "
                + "B5_Input = @pB5_Input, "
                + "B5_Rating = @pB5_Rating, "
                + "B5_Point = @pB5_Point, "
                + "B5_Comment = @pB5_Comment, "
                + "SubTotalB = @pSubTotalB, "
                + "C1_Input = @pC1_Input, "
                + "C1_Rating = @pC1_Rating, "
                + "C1_Point = @pC1_Point, "
                + "C1_Comment = @pC1_Comment, "
                + "C2_Input = @pC2_Input, "
                + "C2_Rating = @pC2_Rating, "
                + "C2_Point = @pC2_Point, "
                + "C2_Comment = @pC2_Comment, "
                + "C3_Input = @pC3_Input, "
                + "C3_Rating = @pC3_Rating, "
                + "C3_Point = @pC3_Point, "
                + "C3_Comment = @pC3_Comment, "
                + "C4_Input = @pC4_Input, "
                + "C4_Rating = @pC4_Rating, "
                + "C4_Point = @pC4_Point, "
                + "C4_Comment = @pC4_Comment, "
                + "SubTotalC = @pSubTotalC, "
                + "D1_Input = @pD1_Input, "
                + "D1_Rating = @pD1_Rating, "
                + "D1_Point = @pD1_Point, "
                + "D1_Comment = @pD1_Comment, "
                + "D2_Input = @pD2_Input, "
                + "D2_Rating = @pD2_Rating, "
                + "D2_Point = @pD2_Point, "
                + "D2_Comment = @pD2_Comment, "
                + "D3_Input = @pD3_Input, "
                + "D3_Rating = @pD3_Rating, "
                + "D3_Point = @pD3_Point, "
                + "D3_Comment = @pD3_Comment, "
                + "SubTotalD = @pSubTotalD, "
                + "GrandTotal = @pGrandTotal, "
                + "ModifyBy = @pModifyBy, "
                + "DateModify = '" + now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "' "
                + "WHERE DescriptionId = '" + Request.QueryString["Id"] + "'", con);

        //A. Financial 
        cmd.Parameters.AddWithValue("@pA1_Input", fldA1_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA1_Rating", fldA1_Rating.Text);
        cmd.Parameters.AddWithValue("@pA1_Point", fldA1_Point.Text);
        cmd.Parameters.AddWithValue("@pA1_Comment", fldA1_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA2_Input", fldA2_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA2_Rating", fldA2_Rating.Text);
        cmd.Parameters.AddWithValue("@pA2_Point", fldA2_Point.Text);
        cmd.Parameters.AddWithValue("@pA2_Comment", fldA2_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA3_Input", fldA3_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA3_Rating", fldA3_Rating.Text);
        cmd.Parameters.AddWithValue("@pA3_Point", fldA3_Point.Text);
        cmd.Parameters.AddWithValue("@pA3_Comment", fldA3_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA4_Input", fldA4_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA4_Rating", fldA4_Rating.Text);
        cmd.Parameters.AddWithValue("@pA4_Point", fldA4_Point.Text);
        cmd.Parameters.AddWithValue("@pA4_Comment", fldA4_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA5_Input", fldA5_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA5_Rating", fldA5_Rating.Text);
        cmd.Parameters.AddWithValue("@pA5_Point", fldA5_Point.Text);
        cmd.Parameters.AddWithValue("@pA5_Comment", fldA5_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA6_Input", fldA6_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA6_Rating", fldA6_Rating.Text);
        cmd.Parameters.AddWithValue("@pA6_Point", fldA6_Point.Text);
        cmd.Parameters.AddWithValue("@pA6_Comment", fldA6_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA7_Input", fldA7_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA7_Rating", fldA7_Rating.Text);
        cmd.Parameters.AddWithValue("@pA7_Point", fldA7_Point.Text);
        cmd.Parameters.AddWithValue("@pA7_Comment", fldA7_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pA8_Input", fldA8_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pA8_Rating", fldA8_Rating.Text);
        cmd.Parameters.AddWithValue("@pA8_Point", fldA8_Point.Text);
        cmd.Parameters.AddWithValue("@pA8_Comment", fldA8_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pSubTotalA", fldASubTotal.Text);

        //B. Project
        cmd.Parameters.AddWithValue("@pB1_Input", fldB1_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pB1_Rating", fldB1_Rating.Text);
        cmd.Parameters.AddWithValue("@pB1_Point", fldB1_Point.Text);
        cmd.Parameters.AddWithValue("@pB1_Comment", fldB1_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pB2_Input", fldB2_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pB2_Rating", fldB2_Rating.Text);
        cmd.Parameters.AddWithValue("@pB2_Point", fldB2_Point.Text);
        cmd.Parameters.AddWithValue("@pB2_Comment", fldB2_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pB3_Input", fldB3_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pB3_Rating", fldB3_Rating.Text);
        cmd.Parameters.AddWithValue("@pB3_Point", fldB3_Point.Text);
        cmd.Parameters.AddWithValue("@pB3_Comment", fldB3_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pB4_Input", fldB4_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pB4_Rating", fldB4_Rating.Text);
        cmd.Parameters.AddWithValue("@pB4_Point", fldB4_Point.Text);
        cmd.Parameters.AddWithValue("@pB4_Comment", fldB4_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pB5_Input", fldB5_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pB5_Rating", fldB5_Rating.Text);
        cmd.Parameters.AddWithValue("@pB5_Point", fldB5_Point.Text);
        cmd.Parameters.AddWithValue("@pB5_Comment", fldB5_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pSubTotalB", fldBSubTotal.Text);

        //C. Resources / Competition 
        cmd.Parameters.AddWithValue("@pC1_Input", fldC1_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pC1_Rating", fldC1_Rating.Text);
        cmd.Parameters.AddWithValue("@pC1_Point", fldC1_Point.Text);
        cmd.Parameters.AddWithValue("@pC1_Comment", fldC1_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pC2_Input", fldC2_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pC2_Rating", fldC2_Rating.Text);
        cmd.Parameters.AddWithValue("@pC2_Point", fldC2_Point.Text);
        cmd.Parameters.AddWithValue("@pC2_Comment", fldC2_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pC3_Input", fldC3_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pC3_Rating", fldC3_Rating.Text);
        cmd.Parameters.AddWithValue("@pC3_Point", fldC3_Point.Text);
        cmd.Parameters.AddWithValue("@pC3_Comment", fldC3_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pC4_Input", fldC4_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pC4_Rating", fldC4_Rating.Text);
        cmd.Parameters.AddWithValue("@pC4_Point", fldC4_Point.Text);
        cmd.Parameters.AddWithValue("@pC4_Comment", fldC4_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pSubTotalC", fldCSubTotal.Text);

        //D. Cost and Time to Prepare Proposal 
        cmd.Parameters.AddWithValue("@pD1_Input", fldD1_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pD1_Rating", fldD1_Rating.Text);
        cmd.Parameters.AddWithValue("@pD1_Point", fldD1_Point.Text);
        cmd.Parameters.AddWithValue("@pD1_Comment", fldD1_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pD2_Input", fldD2_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pD2_Rating", fldD2_Rating.Text);
        cmd.Parameters.AddWithValue("@pD2_Point", fldD2_Point.Text);
        cmd.Parameters.AddWithValue("@pD2_Comment", fldD2_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pD3_Input", fldD3_Input.Text.Trim());
        cmd.Parameters.AddWithValue("@pD3_Rating", fldD3_Rating.Text);
        cmd.Parameters.AddWithValue("@pD3_Point", fldD3_Point.Text);
        cmd.Parameters.AddWithValue("@pD3_Comment", fldD3_Comment.Text.Trim());

        cmd.Parameters.AddWithValue("@pSubTotalD", fldDSubTotal.Text);

        cmd.Parameters.AddWithValue("@pGrandTotal", fldTotal.Text);

        //Modified By
        cmd.Parameters.AddWithValue("@pModifyBy", Session["UserID"].ToString());

        cmd.ExecuteNonQuery();

        con.Close();
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
