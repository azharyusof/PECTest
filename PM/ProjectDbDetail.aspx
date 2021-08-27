<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectDbDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectDbDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
   

<div class="panel-heading input">PROJECT DATABASE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

     <ul class="nav nav-tabs">                    
         <li ID="tab1" runat="server"><a href='ProjectDbInfo.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="PROJECT INFO."></asp:Label></a></li>                    
         <li ID="tab2" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PROJECT DETAILS"></asp:Label></a></li>                    
         <li ID="tab3" runat="server"><a href='ProjectDbStatus.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="PROJECT STATUS"></asp:Label></a></li>    
     </ul>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvCompany" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Company" for="fldCompany">No. of Staff</label>
            </div>
            <div class="col-md-3">  
                <asp:TextBox ID="fldStaff" runat="server" CssClass="form-control input-xxs" Width="320px" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvUnit" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Unit" for="fldUnit">No. of Man-Month</label>
            </div>            
            <div class="col-md-3">     
                <asp:TextBox ID="fldManMonth" runat="server" CssClass="form-control input-xxs" Width="320px" Enabled="false"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvClientName" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Project Description</label>
            </div>
            <div class="col-md-3">  
                <asp:TextBox ID="fldDesc" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="140" MaxLength="850" Enabled="false"></asp:TextBox>                          
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvClientAdd" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Scope of Services/Works</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldScope" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="140" MaxLength="850" Enabled="false"></asp:TextBox>                          
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOpportunity" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Opportunity Name" for="fldDescription">Market Sector</label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList id="fldMarket" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
            <div class="col-md-1">  </div>
        <div id="dvSOW" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Scope of Work" for="fldSOW">Status</label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList id="fldStatus" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>


    <div class="row">
        <div id="dvPIC1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [1]" for="fldPIC1">Country</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList id="fldCountry" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPIC2" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [2]" for="fldPIC2">Remarks</label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="80" MaxLength="850" Enabled="false"></asp:TextBox>                          
            </div>
        </div>
    </div>

         

        
    

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click"/> 
           
    </div>

    <script>
        $(function () {
            $('#dtStartDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            $('#dtEndDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true,
                useCurrent: false
            });

            $("#dtStartDate").on("dp.change", function (e) {
                $('#dtEndDate').data("DateTimePicker").minDate(e.date);
            });

            $("#dtEndDate").on("dp.change", function (e) {
                $('#dtStartDate').data("DateTimePicker").maxDate(e.date);
            });
        });
    </script>


</asp:Content>
    


