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

public partial class EDMSFile : System.Web.UI.Page
{
    String code = "";
    String company = "";
    String yr = "";
    String trackno = "";
    String fulltrackno = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        code = Request.QueryString["C"];
        company = Request.QueryString["CC"];
        yr = Request.QueryString["Y"];
        trackno = Request.QueryString["TN"].Substring(Request.QueryString["TN"].Length - 8);
        fulltrackno = Request.QueryString["TN"];

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["C"].Substring(0, 3) == "STR")
            {
                if (Request.QueryString["M"] == "Out")
                {                    
                    In.Visible = false;
                    Out.Visible = false;

                    STRIn.Visible = false;

                    STROut.Attributes["src"] = "https://edms-str.opusbhd.com/document/" + code + "/" + company + "/outgoing/" + yr + "/" + fulltrackno + ".pdf";
                }
                else if (Request.QueryString["M"] == "In")
                {
                    In.Visible = false;
                    Out.Visible = false;

                    STRIn.Attributes["src"] = "https://edms-str.opusbhd.com/document/" + code + "/" + company + "/incoming/" + yr + "/" + fulltrackno + ".pdf";
                                  
                    STROut.Visible = false;
                }
            }
            else
            {
                if (Request.QueryString["M"] == "Out")
                {
                    In.Visible = false;   
                    
                    Out.Attributes["src"] = "http://dc.opusbhd.com/gdc/" + code + "/outgoing/" + yr + "/" + trackno + ".pdf";

                    STRIn.Visible = false;
                    STROut.Visible = false;
                }
                else if (Request.QueryString["M"] == "In")
                {
                    In.Attributes["src"] = "http://dc.opusbhd.com/gdc/" + code + "/incoming/" + yr + "/" + trackno + ".pdf";
                    
                    Out.Visible = false;
                    
                    STRIn.Visible = false;
                    STROut.Visible = false;
                }
            }
        }

    }


}
