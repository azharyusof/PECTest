<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Viewer.aspx.cs" Inherits="Report_Viewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WAIS - Report Viewer</title>
</head>
<body>
   
   <div style="Width:auto;"> 
<form id="form2" runat="server" style="width:100%; height:100%;">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" AsyncRendering="true" SizeToReportContent="true">
    </rsweb:ReportViewer>
</form></div>


</body>
</html>
