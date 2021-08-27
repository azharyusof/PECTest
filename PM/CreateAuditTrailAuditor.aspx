<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="CreateAuditTrailAuditor.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="CreateAuditTrailAuditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    <asp:Table ID="Table4" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>OPPORTUNITY RECORD</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>OPPORTUNITY GO / NO-GO</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROPOSAL EVALUATION / SUBMISSION</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROPOSAL CLOSE</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>REGISTER NEW PROJECT</b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROJECT INITIATION</b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROJECT MONTHLY UPDATE</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>DOCUMENT MANAGEMENT</b></asp:Label></asp:TableCell>

<%--                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>AWARD <BR />TO THIRD<BR /> PARTY</b></asp:Label></asp:TableCell>                             --%>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>CHANGE MANAGEMENT</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>HSE</b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="AuditTrailAuditor.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROJECT CLOSE</b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
         </asp:Table>
<div class="panel-heading">AUDIT / CUSTOMER SATISFACTION</div>
<div class="panel-body">

    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Execution.pdf')"></asp:ImageButton></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

    <table><tr><td height="10"></td></tr></table>

    <div class="row">
        <div id="dvCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code" for="lblCode">Regular Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>

                <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="AUDIT TRAIL"></asp:Label></a></li>
                    <li ID="tab2" runat="server"><a href='#'><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="CLIENT SATISFACTION SURVEY"></asp:Label></a></li>
                    
                    
                </ul>
    
        
    <table><tr><td height="10"></td></tr></table>
    
    <div class="row">
        <div id="dvAuditType" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Audit Type" for="fldAuditType">Audit Type <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldAuditType" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>            
        </div>
    </div>

    <div class="row">
        <div id="dvAuditor" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Auditor" for="fldAuditor">Auditor Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldAuditor" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvAuditDate" runat="server">      
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Audit Date" for="fldAuditDate">Audit Date <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <div class='input-group input-group-xs' id='dtAuditDate'>
                        <asp:TextBox ID="fldAuditDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                    
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvAuditNo" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Audit No." for="fldAuditNo">Audit No. </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldAuditNo" runat="server" CssClass="form-control input-xxs" Width="200px" PlaceHolder="(Audit No.)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>        
    </div>
                
    <div class="row">
        <div id="dvFindings" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Findings" for="fldFindings">Findings <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldFindings" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
       </div>        
    </div>
              
    <div class="row">
        <div id="dvFindingsDescription" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Description of Findings" for="fldFindingsDescription">Description of Findings <font color="Red">*</font></label>
            </div>
            
            <div class="col-md-2">                
                <asp:TextBox ID="fldFindingsDescription" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Description of Findings)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvCompletionDateReq" runat="server">      
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Corrective Action Completion Date" for="fldCompletionDateReq">Corrective Action Completion Date <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <div class='input-group input-group-xs' id='dtCompletionDateReq'>
                        <asp:TextBox ID="fldCompletionDateReq" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                    
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvStatusClosure" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Status Closure" for="fldStatusClosure">Status Closure </label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldStatusClosure" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
       </div>        
    </div>
    
    <table><tr><td height="12"></td></tr></table>
            
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote" runat="server" class="control-label input-xxs" Font-Italic="true">Note :</asp:Label> 
            </div>
        </div>
    </div>
         
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Next</b> button to create audit trail and upload files.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back</b> button to return to the previous page.</asp:Label> 
            </div>
        </div>
    </div>
    
    <hr />

    <div class="row" align="center">               
        &nbsp;&nbsp;<asp:Button ID="btnCreate" runat="server" Text="Next" CssClass="btn btn-success btn-xs input-xxs" Width="55" OnClick="btnCreate_Click" /> 
        &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-xs input-xxs" Width="55" OnClick="btnBack_Click" /> 
        
    </div>

    <br />
    
   

    <script>
        $(function () {
            $('#dtAuditDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

        });

        $(function () {
            $('#dtCompletionDateReq').datetimepicker({
                format: 'DD-MMM-YYYY',
                //showTodayButton: true,
                showClear: true
            });

        });
    </script>
    
</div>



</asp:Content>
    



    