<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableRiskImpactNF.aspx.cs" Inherits="TableRiskImpactNF" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Impact Table (Non-Financial)</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <a href="TableHeatMap.aspx"><asp:Label ID="lbl1" runat="server" CssClass="input-xxs"><b>Risk Heat Map</b></asp:Label></a> | <a href="TableLikelihood.aspx"><asp:Label ID="lbl2" runat="server" CssClass="input-xxs"><b>Likelihood Table</b></asp:Label></a> | <a href="TableRiskImpactF.aspx"><asp:Label ID="lbl3" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Financial)</b></asp:Label></a> | <asp:Label ID="lbl4" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Non-Financial)</b></asp:Label>
        <br /><br />
        <div>

                    <asp:Table runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#0033cc">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" RowSpan="2"><asp:Label ID="Label17" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Factor</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="5"><asp:Label ID="Label33" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Impact</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#0033cc">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label1" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Insignificant</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label5" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Minor</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label18" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Moderate</b></asp:Label></asp:TableCell>  
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label19" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Major</b></asp:Label></asp:TableCell>  
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label20" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Catastrophic</b></asp:Label></asp:TableCell>  
                        </asp:TableRow>                 
                 
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label2" runat="server" CssClass="input-xxs">2. Safety & Health</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label3" runat="server" CssClass="input-xxs">Slight injury or effect on health, no impact on work performance and daily activities.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label4" runat="server" CssClass="input-xxs">Minor injury or effect on health, affects work performance and daily activities of up to 5 days.</asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label21" runat="server" CssClass="input-xxs">Moderate injury or effect on health or irreversible damage to health, affects work performance and daily activities by more than 5 days.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label22" runat="server" CssClass="input-xxs">Major injury or effect on health, permanent total disability or up to 3 fatalities.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label23" runat="server" CssClass="input-xxs">More than 3 fatalities.</asp:Label></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#eeeeee">                        
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label6" runat="server" CssClass="input-xxs">3. Environmental & Social Impact</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label7" runat="server" CssClass="input-xxs">Slight environmental damage, contained within premises.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label8" runat="server" CssClass="input-xxs">Minor environmental damage with no lasting effect.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label24" runat="server" CssClass="input-xxs">Limited environmental damage that will persist or require cleaning up.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label25" runat="server" CssClass="input-xxs">Severe environmental damage that will require extensive measures to restore beneficial uses of environment.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label26" runat="server" CssClass="input-xxs">Massive or persistent severe environmental damage that will lead to loss of commercial, recreational use or loss of natural resources over a wide area.</asp:Label></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#eeeeee">                        
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label15" runat="server" CssClass="input-xxs">4. Legal / Regulatory  /Compliance</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label16" runat="server" CssClass="input-xxs"><ul><li>No litigation consequences.</li><li>Issuance of advice letter.</li></ul></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label34" runat="server" CssClass="input-xxs"><ul><li>Issuance of reprimand / warning letter.</li><li>Minimum fine.</li></ul></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label35" runat="server" CssClass="input-xxs"><ul><li>Issuance of public reprimand / warning letter.</li><li>Moderate fine.</li></ul></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label36" runat="server" CssClass="input-xxs"><ul><li>Multiple issuance of reprimands / warning letters.</li><li>Heavy fines / penalties.</li><li>Suspension of share.</li></ul></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label37" runat="server" CssClass="input-xxs"><ul><li>Delisting.</li><li>Closure of operations.</li><li>Jail sentence for directors.</li></ul></asp:Label></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">                        
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label9" runat="server" CssClass="input-xxs">5. Reputation / Media</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label10" runat="server" CssClass="input-xxs">Confined within the UEM Group. Internal Group complaints and no public concerns.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label11" runat="server" CssClass="input-xxs">Local / public complaints of concerns. Some local media and / or political attention with potentially adverse impact on operation.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label27" runat="server" CssClass="input-xxs">Public concerns and adverse local media coverage. Adverse stance of local government and / or action group.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label28" runat="server" CssClass="input-xxs">Adverse national media coverage. Attract regulators attention leading to restrictive measures and / or suspension of business licenses or temporary stoppage of operation.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label29" runat="server" CssClass="input-xxs">Adverse international media coverage or public media outrage. Demand for public enquiry. Loss of license to operate.</asp:Label></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#eeeeee">                        
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle"><asp:Label ID="Label12" runat="server" CssClass="input-xxs">6. Risk Impact Description</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label13" runat="server" CssClass="input-xxs">An event where the impact can be absorbed / managed through routine activity.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label14" runat="server" CssClass="input-xxs">An event where the impact can be absorbed / managed with minimum management effort.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label30" runat="server" CssClass="input-xxs">An event that causes the business to sustain negative financial / non-financial impacts that would require some work / planning from Management to manage the issue.</asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label31" runat="server" CssClass="input-xxs">An event that could lead the business to sustain huge adverse financial / non-financial impacts that would require hard work from Management to manage the issue.</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label32" runat="server" CssClass="input-xxs">An event that could potentially crumple the entire business in the long-term.</asp:Label></asp:TableCell> 
                        </asp:TableRow>
                    </asp:Table>
        </div>
    </form>
</body>
</html>

