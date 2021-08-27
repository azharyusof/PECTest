﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableHeatMap.aspx.cs" Inherits="TableHeatMap" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Heat Map</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <b><asp:Label ID="lbl1" runat="server" CssClass="input-xxs"><b>Risk Heat Map</b></asp:Label></b> | <a href="TableLikelihood.aspx"><b><asp:Label ID="lbl2" runat="server" CssClass="input-xxs"><b>Likelihood Table</b></asp:Label></b></a> | <a href="TableRiskImpactF.aspx"><asp:Label ID="lbl3" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Financial)</b></asp:Label></a> | <a href="TableRiskImpactNF.aspx"><asp:Label ID="lbl4" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Non-Financial)</b></asp:Label></a>
        <br /><br />
        <div>

                    <asp:Table runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#0033cc">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" RowSpan="2" ColumnSpan="2"><asp:Label ID="lblRequested" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Risk Likelihood</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="5"><asp:Label ID="Label1" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Risk Impact</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#0033cc">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label7" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Insignificant</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label8" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Minor</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label10" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Moderate</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label11" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Major</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label12" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Catastrophic</b></asp:Label></asp:TableCell>
                        </asp:TableRow>              
                 
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc" Wrap="false"><asp:Label ID="Label3" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>>= 80%</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc"><asp:Label ID="Label4" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Certain</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label5" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label6" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label9" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ff0000"><asp:Label ID="Label13" runat="server" CssClass="input-xxs">High</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ff0000"><asp:Label ID="Label14" runat="server" CssClass="input-xxs">High</asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc" Wrap="false"><asp:Label ID="Label2" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>50% <= 80%</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc"><asp:Label ID="Label15" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Likely</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label16" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label17" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label18" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label19" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ff0000"><asp:Label ID="Label20" runat="server" CssClass="input-xxs">High</asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc" Wrap="false"><asp:Label ID="Label21" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>30% <= 50%</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc"><asp:Label ID="Label22" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Possible</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label23" runat="server" CssClass="input-xxs">Low</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label24" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label25" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label26" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ff0000"><asp:Label ID="Label27" runat="server" CssClass="input-xxs">High</asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc" Wrap="false"><asp:Label ID="Label28" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>10% <= 30%</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc"><asp:Label ID="Label29" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Unlikely</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label30" runat="server" CssClass="input-xxs">Low</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label31" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label32" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label33" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label34" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc" Wrap="false"><asp:Label ID="Label35" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><= 10%</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#0033cc"><asp:Label ID="Label36" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Remote</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label37" runat="server" CssClass="input-xxs">Low</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label38" runat="server" CssClass="input-xxs">Low</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label39" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#00cc00"><asp:Label ID="Label40" runat="server" CssClass="input-xxs">Medium</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffff00"><asp:Label ID="Label41" runat="server" CssClass="input-xxs">Significant</asp:Label></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
        </div>
    </form>
</body>
</html>
