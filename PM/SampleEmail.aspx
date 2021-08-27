<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="SampleEmail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="SampleEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

<div class="panel-heading">REGISTER NEW PROJECT</div>
<div class="panel-body">

    <ul class="nav nav-tabs">
        <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT INFO."></asp:Label></a></li>                    
     </ul>
    
    <table><tr><td height="12"></td></tr></table>
       

    
    <div class="row" align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" />                  
    </div>
    
</div>
    
</asp:Content>
    

