using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class Report_Viewer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BEMSConn"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //ReportViewer1.Width = 800;
            //ReportViewer1.Height = 800;
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;

            //IReportServerCredentials irsc = new CustomReportCredentials("ssrsuser", "Edg3nt@!", "10.249.5.56");
            IReportServerCredentials irsc = new CustomReportCredentials("ssrsuser", "Edg3nt@!", "10.249.116.34");

            ReportViewer1.ServerReport.ReportServerCredentials = irsc;

            //ReportViewer1.ServerReport.ReportServerUrl = new
            //    Uri("http://10.249.5.56/ReportServer");

            ReportViewer1.ServerReport.ReportServerUrl = new
                Uri("http://waisreport.uemedgenta.com/ReportServer");

            ReportParameter rp1 = new ReportParameter("YEAR", Request.QueryString["year"]);
            ReportParameter rp2 = new ReportParameter("MONTH", Request.QueryString["month"]);
            ReportParameter rp3 = new ReportParameter("Type", Request.QueryString["type"]);

            //Mapping Report (Deduction Generation screen)
            if (Request.QueryString["vcm"] == "pre")
            {
                if (Request.QueryString["rpt"] == "Deduction Summary")
                {
                    if (Request.QueryString["type"] == "Edgenta")
                    {
                        ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000014";

                        ReportViewer1.ShowParameterPrompts = false;

                        ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2 });
                        //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                        ReportViewer1.ServerReport.Refresh();
                    }
                    else if (Request.QueryString["type"] == "ProHawk")
                    {
                        ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000015";

                        ReportViewer1.ShowParameterPrompts = false;

                        ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2 });
                        //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                        ReportViewer1.ServerReport.Refresh();
                    }
                }
                else if (Request.QueryString["rpt"] == "Indicator B1B2")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000003";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
                else if (Request.QueryString["rpt"] == "Indicator B3")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000001";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
                else if (Request.QueryString["rpt"] == "Indicator B4")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000002";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
                else if (Request.QueryString["rpt"] == "Indicator B5")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000004";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
            }


            //Assessment Report (Monthly Deduction Adjustment screen)
            else if (Request.QueryString["vcm"] == "post")
            {
                if (Request.QueryString["rpt"] == "Deduction Summary")
                {
                    if (Request.QueryString["type"] == "Edgenta")
                    {
                        ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000021";

                        ReportViewer1.ShowParameterPrompts = false;

                        ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2 });
                        //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                        ReportViewer1.ServerReport.Refresh();
                    }
                    else if (Request.QueryString["type"] == "ProHawk")
                    {
                        ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000022";

                        ReportViewer1.ShowParameterPrompts = false;

                        ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2 });
                        //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                        ReportViewer1.ServerReport.Refresh();
                    }
                }
                else if (Request.QueryString["rpt"] == "Indicator B1B2")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000017";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
                else if (Request.QueryString["rpt"] == "Indicator B3")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000018";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
                else if (Request.QueryString["rpt"] == "Indicator B4")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000019";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
                else if (Request.QueryString["rpt"] == "Indicator B5")
                {
                    ReportViewer1.ServerReport.ReportPath = "/Deduction/RPT_000020";

                    ReportViewer1.ShowParameterPrompts = false;

                    ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                    //ReportViewer1.ShowToolBar = false; //This hide the toolbar

                    ReportViewer1.ServerReport.Refresh();
                }
            }
        }
    }

    
}

public class CustomReportCredentials : IReportServerCredentials
{
    private string _UserName;
    private string _PassWord;
    private string _DomainName;

    public CustomReportCredentials(string UserName, string PassWord, string DomainName)
    {
        _UserName = UserName;
        _PassWord = PassWord;
        _DomainName = DomainName;
    }

    public System.Security.Principal.WindowsIdentity ImpersonationUser
    {
        get { return null; }
    }

    public ICredentials NetworkCredentials
    {
        get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
    }

    public bool GetFormsCredentials(out Cookie authCookie, out string user,
     out string password, out string authority)
    {
        authCookie = null;
        user = password = authority = null;
        return false;
    }
}