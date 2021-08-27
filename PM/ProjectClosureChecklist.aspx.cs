using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text.xml.simpleparser;
using iTextSharp.text;
using Microsoft.VisualBasic;

public partial class ProjectClosureChecklist : System.Web.UI.Page
{
    DataRow row = null;
    DataRow rowA = null;
    DataRow rowB = null;

    string queryString = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    int count;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

        //Select from database 
        queryString = "";
        queryString = queryString + " SELECT        * ";
        queryString = queryString + " FROM          vwProjectClosureChecklist ";
        queryString = queryString + " WHERE         DescriptionId = '" + Request.QueryString["ID"] + "' ";
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }
        cmd = new SqlCommand(queryString, con);
        cmd.CommandTimeout = 0;
        SqlDataAdapter daA = new SqlDataAdapter(cmd);
        DataTable dtA = new DataTable();
        daA.Fill(dtA);
        con.Close();
        rowA = null;
        rowA = dtA.Rows[0];
        
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Project_Closure_Checklist.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.Page.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        TextReader xmlString = sr;

        Document pdfDoc = new Document(PageSize.A4, 38f, 38f, 90f, 50f); //left, right, top, bottom

        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        iTextSharp.text.Image imgKKM = iTextSharp.text.Image.GetInstance(Server.MapPath("Img/edgenta.jpg"));

        iTextSharp.text.Image imgCheck = iTextSharp.text.Image.GetInstance(Server.MapPath("Img/chkbox.png"));
        imgCheck.WidthPercentage = 40;
        imgCheck.Alignment = Element.ALIGN_MIDDLE;

        itsEvents ev = new itsEvents();
        ev.getVal(ref imgKKM);
        writer.PageEvent = ev;
        pdfDoc.Open();

        HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
        htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
        htmlContext.SetImageProvider(new ImageProvider());

        dynamic fontHeader = FontFactory.GetFont("Verdana", 8, Font.NORMAL, BaseColor.BLACK);
        dynamic fontHeaderB = FontFactory.GetFont("Verdana", 8, Font.BOLD, BaseColor.BLACK);
        dynamic fontHeaderU = FontFactory.GetFont("Verdana", 8, Font.UNDERLINE, BaseColor.BLACK);

        PdfPTable headerTbl = new PdfPTable(6);
        headerTbl.WidthPercentage = 100;
        float[] cfWidths = new float[] {
            35f,
            10f,
            40,
            35f,
            10f,
            30f,
        };

        headerTbl.SetWidths(cfWidths);

        //USER INFORMATION
        PdfPCell cell = new PdfPCell(new Phrase("USER INFORMATION" + Environment.NewLine + " ", fontHeaderB));
        cell.Colspan = 6;
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.BorderWidth = 1;
        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        headerTbl.AddCell(cell);

        //ROW 1
        cell = new PdfPCell(new Phrase("Project Title", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["Description"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 5;
        headerTbl.AddCell(cell);

        //ROW 2
        cell = new PdfPCell(new Phrase("Project Code " + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["ProjectCode"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 5;
        headerTbl.AddCell(cell);

        //ROW 3
        cell = new PdfPCell(new Phrase("Client " + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 1;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(rowA["ClientName"].ToString() + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 5;
        headerTbl.AddCell(cell);

        ////ROW X
        //cell = new PdfPCell(new Phrase("Location " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["Location"].ToString() != "")
        //{

        //    cell = new PdfPCell(new Phrase(rowA["Location"].ToString() + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 5;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 5;
        //    headerTbl.AddCell(cell);
        //}

        ////HARDWARE DETAILS
        //cell = new PdfPCell(new Phrase("HARDWARE DETAILS" + Environment.NewLine + " ", fontHeaderB));
        //cell.Colspan = 6;
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        //headerTbl.AddCell(cell);

        ////ROW 4
        //cell = new PdfPCell(new Phrase("Asset Brand / Model " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase(rowA["Description"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 2;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Asset Category " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase(rowA["AssetDesc"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 2;
        //headerTbl.AddCell(cell);

        ////ROW 5
        //cell = new PdfPCell(new Phrase("Serial No. " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase(rowA["SerialNo"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 2;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Asset No. " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase(rowA["AssetId"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 2;
        //headerTbl.AddCell(cell);

        ////ROW 6
        //cell = new PdfPCell(new Phrase("Purchased Date " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["PurchaseDt"].ToString() != "")
        //{
        //    DateTime varDt = Convert.ToDateTime(rowA["PurchaseDt"].ToString());
        //    cell = new PdfPCell(new Phrase(varDt.ToString("dd-MMM-yyyy") + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}

        //cell = new PdfPCell(new Phrase("Assigned Date " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["AssignedDt"].ToString() != "")
        //{
        //    DateTime varDt = Convert.ToDateTime(rowA["AssignedDt"].ToString());
        //    cell = new PdfPCell(new Phrase(varDt.ToString("dd-MMM-yyyy") + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}

        ////ROW 8
        //cell = new PdfPCell(new Phrase("Processor " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["PC_Processor"].ToString() != "")
        //{
        //    cell = new PdfPCell(new Phrase(rowA["PC_Processor"].ToString() + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}

        //cell = new PdfPCell(new Phrase("Monitor Size / Serial No. " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["Monitor"].ToString() != "")
        //{
        //    cell = new PdfPCell(new Phrase(rowA["Monitor"].ToString() + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}

        ////ROW 9
        //cell = new PdfPCell(new Phrase("Hard Disk Size " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["HD_Size"].ToString() != "")
        //{
        //    cell = new PdfPCell(new Phrase(rowA["HD_Size"].ToString() + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}

        //cell = new PdfPCell(new Phrase("Memory Size (MB) " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["PC_RAM"].ToString() != "")
        //{
        //    cell = new PdfPCell(new Phrase(rowA["PC_RAM"].ToString() + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        //else
        //{
        //    cell = new PdfPCell(new Phrase(" -" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 2;
        //    headerTbl.AddCell(cell);
        //}
        
        ////ROW ACCESSORIES
        //cell = new PdfPCell(new Phrase("Accessories " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //if (rowA["Accessory_Bag"].ToString() == "1")
        //{
        //    if (rowA["Returned_Bag"].ToString() == "1")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Bag" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_MouseWired"].ToString() != "")
        //{
        //    if (rowA["Returned_MouseWired"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else if (rowA["Returned_MouseWired"].ToString() == "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Mouse Wired" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_MouseWless"].ToString() != "")
        //{
        //    if (rowA["Returned_MouseWless"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Mouse Wireless" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_MouseBtooth"].ToString() == "1")
        //{
        //    if (rowA["Returned_MouseBtooth"].ToString() == "1")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Mouse Bluetooth" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_Kboard"].ToString() != "")
        //{
        //    if (rowA["Returned_Kboard"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Keyboard" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_KboardBtooth"].ToString() != "")
        //{
        //    if (rowA["Returned_KboardBtooth"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Keyboard Bluetooth" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_Charger"].ToString() != "")
        //{
        //    if (rowA["Returned_Charger"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Power Charger Adapter" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_SurfaceDock"].ToString() != "")
        //{
        //    if (rowA["Returned_SurfaceDock"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Surface Docking" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_Monitor"].ToString() != "")
        //{
        //    if (rowA["Returned_Monitor"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Monitor" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_DVDDrive"].ToString() != "")
        //{
        //    if (rowA["Returned_DVDDrive"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("External DVD Drive" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_HDMICable"].ToString() != "")
        //{
        //    if (rowA["Returned_HDMICable"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("HDMI Cable" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        //if (rowA["Accessory_DisplayConvert"].ToString() != "")
        //{
        //    if (rowA["Returned_DisplayConvert"].ToString() != "")
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        cell.AddElement(imgCheck);
        //        headerTbl.AddCell(cell);
        //    }
        //    else
        //    {
        //        cell = new PdfPCell(new Phrase("", fontHeaderB));
        //        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //        cell.Colspan = 1;
        //        headerTbl.AddCell(cell);
        //    }

        //    cell = new PdfPCell(new Phrase("Display Converter" + Environment.NewLine + " ", fontHeader));
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    cell.Colspan = 4;
        //    headerTbl.AddCell(cell);
        //}

        ////RETURN DETAILS
        //cell = new PdfPCell(new Phrase("RETURN DETAILS" + Environment.NewLine + " ", fontHeaderB));
        //cell.Colspan = 6;
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        //headerTbl.AddCell(cell);

        ////ROW 10
        //cell = new PdfPCell(new Phrase("Condition " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase(rowA["Returned_Condition"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 2;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Returned Date " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //DateTime varDt1 = Convert.ToDateTime(rowA["Returned_Date"].ToString());
        //cell = new PdfPCell(new Phrase(varDt1.ToString("dd-MMM-yyyy") + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 2;
        //headerTbl.AddCell(cell);

        ////ROW 11
        //cell = new PdfPCell(new Phrase("Remarks " + Environment.NewLine + " ", fontHeaderB));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 1;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase(rowA["Returned_Remarks"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 5;
        //headerTbl.AddCell(cell);

        //ROW 1

        //SOFTWARE DETAILS
        PdfPCell cell4 = new PdfPCell(new Phrase("ACKNOWLEDGEMENT" + Environment.NewLine + " ", fontHeaderB));
        cell4.Colspan = 6;
        cell4.HorizontalAlignment = Element.ALIGN_LEFT;
        cell4.BackgroundColor = BaseColor.LIGHT_GRAY;
        headerTbl.AddCell(cell4);

        cell4 = new PdfPCell(new Phrase("Received By :" + Environment.NewLine + " ", fontHeaderB));
        cell4.Colspan = 3;
        cell4.HorizontalAlignment = Element.ALIGN_LEFT;
        cell4.BorderWidth = 1;
        headerTbl.AddCell(cell4);

        cell4 = new PdfPCell(new Phrase("Returned By :" + Environment.NewLine + " ", fontHeaderB));
        cell4.HorizontalAlignment = Element.ALIGN_LEFT;
        cell4.Colspan = 3;
        headerTbl.AddCell(cell4);

        //ROW 2
        cell = new PdfPCell(new Phrase(Environment.NewLine + " " + Environment.NewLine + " " + Environment.NewLine + " " + Environment.NewLine + " ", fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("I hereby acknowledged return of the stated items in good order." + Environment.NewLine + " " + Environment.NewLine + " " + Environment.NewLine + " " + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        ////ROW 3
        //cell = new PdfPCell(new Phrase("Name : " + rowA["ReceivedByName"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 3;
        //headerTbl.AddCell(cell);

        //cell = new PdfPCell(new Phrase("Name : " + rowA["ReturnedByName"].ToString() + Environment.NewLine + " ", fontHeader));
        //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //cell.Colspan = 3;
        //headerTbl.AddCell(cell);

        //ROW 4
        cell = new PdfPCell(new Phrase("Date :" + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase("Date :" + Environment.NewLine + " ", fontHeader));
        cell.HorizontalAlignment = Element.ALIGN_LEFT;
        cell.Colspan = 3;
        headerTbl.AddCell(cell);

        pdfDoc.Add(headerTbl);

        pdfDoc.Close();
        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        Response.Write(pdfDoc);
        Response.End();
    }
}
//public class ImageProvider : AbstractImageProvider
//{
//    public ImageProvider()
//    {
//    }
//    public override string GetImageRootPath()
//    {
//        return "/";
//    }
//}
public class itsEvents : PdfPageEventHelper
{
    string hdrStr = "INFORMATION TECHNOLOGY";
    string hdrSubStr = "PROJECT CLOSURE CHECKLIST";
    iTextSharp.text.Image logoKKM;

    public void getVal(ref iTextSharp.text.Image KKMlogo)
    {
        logoKKM = KKMlogo;
    }

    public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    {
        dynamic fontHeader = FontFactory.GetFont("Verdana", 10, Font.NORMAL, BaseColor.BLACK);
        dynamic fontHeaderB = FontFactory.GetFont("Verdana", 10, Font.BOLD, BaseColor.BLACK);
        dynamic fontHeaderU = FontFactory.GetFont("Verdana", 10, Font.UNDERLINE, BaseColor.BLACK);

        logoKKM.ScaleToFit(75.0F, 80.0F);

        PdfPTable headerTbl = new PdfPTable(3);
        headerTbl.TotalWidth = 550f;
        float[] cfWidths = new float[] {
            50f,
            50f,
            50f
        };
        headerTbl.SetWidths(cfWidths);

        PdfPCell cell = new PdfPCell(logoKKM);
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Border = PdfPCell.NO_BORDER;
        headerTbl.AddCell(cell);

        cell = new PdfPCell(new Phrase(hdrStr + Environment.NewLine + Environment.NewLine + hdrSubStr, fontHeaderB));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2; // 3;
        cell.BorderWidth = 0;
        headerTbl.AddCell(cell);

        headerTbl.WriteSelectedRows(0, -1, 20, (document.PageSize.Height - 40), writer.DirectContent);
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {

    }
}
