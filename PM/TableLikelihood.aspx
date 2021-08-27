<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableLikelihood.aspx.cs" Inherits="TableLikelihood" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Likelihood Table</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <a href="TableHeatMap.aspx"><asp:Label ID="lbl1" runat="server" CssClass="input-xxs"><b>Risk Heat Map</b></asp:Label></a> | <asp:Label ID="lbl2" runat="server" CssClass="input-xxs"><b>Likelihood Table</b></asp:Label> | <a href="TableRiskImpactF.aspx"><asp:Label ID="lbl3" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Financial)</b></asp:Label></a> | <a href="TableRiskImpactNF.aspx"><asp:Label ID="lbl4" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Non-Financial)</b></asp:Label></a>
        <br /><br />
        <div>

                    <asp:Table runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#0033cc">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="lblRequested" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Likelihood</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label1" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Description</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label5" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Probability Guidance</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>            
                 
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label2" runat="server" CssClass="input-xxs">Certain</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label3" runat="server" CssClass="input-xxs">The risk is expected to occur in most circumstances.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label4" runat="server" CssClass="input-xxs">>= 80%</asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#eeeeee">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label6" runat="server" CssClass="input-xxs">Likely</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label7" runat="server" CssClass="input-xxs">The risk will probably occur in most circumstances.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label8" runat="server" CssClass="input-xxs">50% <= 80%</asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label9" runat="server" CssClass="input-xxs">Possible</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label10" runat="server" CssClass="input-xxs">The risk might / should occur at some time in the future.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label11" runat="server" CssClass="input-xxs">30% <= 50%</asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#eeeeee">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label12" runat="server" CssClass="input-xxs">Unlikely</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label13" runat="server" CssClass="input-xxs">The risk could occur at some time but doubtful.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label14" runat="server" CssClass="input-xxs">10% <= 30%</asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label15" runat="server" CssClass="input-xxs">Remote</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label16" runat="server" CssClass="input-xxs">The risk may occur but only in exceptional circumstances.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label17" runat="server" CssClass="input-xxs"><= 10%</asp:Label></asp:TableCell>                            
                        </asp:TableRow>
                    </asp:Table>
        </div>
    </form>
</body>
</html>

