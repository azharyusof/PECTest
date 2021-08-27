<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UpdateTrailAuditor.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="UpdateTrailAuditor" %>

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
                <asp:DropDownList ID="fldAuditType" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>            
        </div>
    </div>

    <div class="row">
        <div id="dvAuditor" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Auditor" for="fldAuditor">Auditor Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldAuditor" runat="server" CssClass="form-control input-xxs" Width="320px" Enabled="false"></asp:TextBox>    
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
                        <asp:TextBox ID="fldAuditDate" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
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
                <asp:TextBox ID="fldAuditNo" runat="server" CssClass="form-control input-xxs" Width="200px" PlaceHolder="(Audit No.)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>        
    </div>

    <div class="row">
        <div id="dvMemoFile" runat="server">    
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Audit Memo" for="fldMemoFile">Audit Memo & Audit Plan <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2"> 
                <asp:HiddenField ID="hidURLA1" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA1" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA1" />
                            <asp:PostBackTrigger ControlID="btnUpA1" />
                            <asp:PostBackTrigger ControlID="btnViewA1" />
                            <asp:PostBackTrigger ControlID="btnDeleteA1" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA1Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA1" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA1Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA1" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA1();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA1" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA1_Click" OnClientClick="return validateErrA1();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA1Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA1" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA1" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA1_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA1" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA1_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>
        </div>
   </div>
            
    <div class="row">
        <div id="dvFindings" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Findings" for="fldFindings">Findings <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldFindings" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
       </div>        
    </div>

            <div class="row">
                <div id="dvFindingsFile" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Findings Attachment" for="fldFindingsFile">Findings Attachment <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:HiddenField ID="hidURLA2" runat="server" />
                        <asp:UpdatePanel runat="server" id="UpA2" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnCancelA2" />
                                    <asp:PostBackTrigger ControlID="btnUpA2" />
                                    <asp:PostBackTrigger ControlID="btnViewA2" />
                                    <asp:PostBackTrigger ControlID="btnDeleteA2" />
                                </Triggers>
                                <ContentTemplate>
                           
                                        <div id="dvUpA2Sec" runat="server" class="row">
                                            <div class="col-md-3"> 
                                                <div id="dvA2" runat="server" class="form-group">
                                                    <div class="input-group input-group-xs">
                                                        <asp:FileUpload ID="fldA2Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                        <span class="input-group-btn"><asp:Button ID="btnCancelA2" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA2();" /></span>
                                                        <span class="input-group-btn"><asp:Button ID="btnUpA2" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA2_Click" OnClientClick="return validateErrA2();" /></span>
                                                    </div>                                            
                                                </div>
                                            </div>
                                        </div>
                                        <div id="dvVwA2Sec" runat="server" class="row">
                                            <div class="col-md-3">
                                                <div class="input-group input-group-xs">
                                                    <asp:Label ID="lblURLA2" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                                    <span class="input-group-btn"><asp:Button ID="btnViewA2" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA2_Click" /></span>
                                                    <span class="input-group-btn"><asp:Button ID="btnDeleteA2" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA2_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                                </div>
                                            </div>
                                        </div>
                            
                                </ContentTemplate>
                            </asp:UpdatePanel>

                    </div>
                </div>
            </div>

    <div class="row">
        <div id="dvFindingsDescription" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Description of Findings" for="fldFindingsDescription">Description of Findings <font color="Red">*</font></label>
            </div>
            
            <div class="col-md-2">                
                <asp:TextBox ID="fldFindingsDescription" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Description of Findings)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
                <div id="dvReportFile" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Audit Report" for="fldReportFile">Audit Report</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:HiddenField ID="hidURLA3" runat="server" />
                        <asp:UpdatePanel runat="server" id="UpA3" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnCancelA3" />
                                    <asp:PostBackTrigger ControlID="btnUpA3" />
                                    <asp:PostBackTrigger ControlID="btnViewA3" />
                                    <asp:PostBackTrigger ControlID="btnDeleteA3" />
                                </Triggers>
                                <ContentTemplate>
                           
                                        <div id="dvUpA3Sec" runat="server" class="row">
                                            <div class="col-md-3"> 
                                                <div id="dvA3" runat="server" class="form-group">
                                                    <div class="input-group input-group-xs">
                                                        <asp:FileUpload ID="fldA3Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                        <span class="input-group-btn"><asp:Button ID="btnCancelA3" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA3();" /></span>
                                                        <span class="input-group-btn"><asp:Button ID="btnUpA3" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA3_Click" OnClientClick="return validateErrA3();" /></span>
                                                    </div>                                            
                                                </div>
                                            </div>
                                        </div>
                                        <div id="dvVwA3Sec" runat="server" class="row">
                                            <div class="col-md-3">
                                                <div class="input-group input-group-xs">
                                                    <asp:Label ID="lblURLA3" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                                    <span class="input-group-btn"><asp:Button ID="btnViewA3" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA3_Click" /></span>
                                                    <span class="input-group-btn"><asp:Button ID="btnDeleteA3" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA3_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                                </div>
                                            </div>
                                        </div>
                            
                                </ContentTemplate>
                            </asp:UpdatePanel>

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
                        <asp:TextBox ID="fldCompletionDateReq" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
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

    <div class="row">
        <div id="dvRemarks" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldRemarks">Remarks </label>
            </div>
            
            <div class="col-md-2">                
                <asp:TextBox ID="fldRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvRemarksDate" runat="server">      
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date" for="fldRemarksDate">Date </label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <div class='input-group input-group-xs' id='dtRemarksDate'>
                        <asp:TextBox ID="fldRemarksDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                    
                </div>
            </div>
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs">Created By </label>
            </div>
            <div class="col-md-4">                
                <asp:Label ID="lblCreatedBy" runat="server" CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs">Modified By </label>
            </div>
            <div class="col-md-4">                
                <asp:Label ID="lblLastUpdate" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>       
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs">Created Date </label>
            </div>
            <div class="col-md-4">                
                <asp:Label ID="lblCreatedDt" runat="server" CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs">Modified Date </label>
            </div>
            <div class="col-md-4">                
                <asp:Label ID="lblLastUpdateDt" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>       
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update </b> button to update audit trail record.</asp:Label> 
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
        &nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" /> 
        &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-xs input-xxs" Width="55" OnClick="btnBack_Click" /> 
        &nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs input-xxs" Width="60" OnClick="btnBack_Click" Enabled="false"/> 
        
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

        $(function () {
            $('#dtRemarksDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                //showTodayButton: true,
                showClear: true
            });

        });
    </script>

    <script type="text/javascript">
        function clearUploadA1() {
            document.getElementById('<%=fldA1Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA1.ClientID%>').className = "form-group";
        }

        function validateErrA1()
        {
            var chckErrA1 = true;

            if (document.getElementById('<%=fldA1Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA1.ClientID%>').className = "form-group has-error";
                chckErrA1 = false;
            }
            return chckErrA1;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA2() {
            document.getElementById('<%=fldA2Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA2.ClientID%>').className = "form-group";
        }

        function validateErrA2()
        {
            var chckErrA2 = true;

            if (document.getElementById('<%=fldA2Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA2.ClientID%>').className = "form-group has-error";
                chckErrA2 = false;
            }
            return chckErrA2;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA3() {
            document.getElementById('<%=fldA3Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA3.ClientID%>').className = "form-group";
        }

        function validateErrA3()
        {
            var chckErrA3 = true;

            if (document.getElementById('<%=fldA3Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA3.ClientID%>').className = "form-group has-error";
                chckErrA3 = false;
            }
            return chckErrA3;
        }
    </script>

</div>



</asp:Content>
    



    