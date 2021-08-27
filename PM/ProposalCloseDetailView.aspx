<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProposalCloseDetailView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProposalCloseDetailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProposalCloseDetailView.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncomingView.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetailView.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrailView.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">PROPOSAL CLOSE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Proposal_Close.pdf')"></asp:ImageButton></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

    <table><tr><td height="10"></td></tr></table>

<!-------------------------------------------- Start in-active screen -------------------------------------------->
<div id="dvInactive" runat="server">

    <div class="row">
        <div>
            <div class="col-md-5">                
                <asp:Label ID="lblInactive" runat="server" class="control-label input-xxs" ForeColor="Red">SORRY, YOU ARE NOT ALLOWED TO ACCESS THIS PAGE.</asp:Label>
            </div>
        </div>        
    </div>

    <table><tr><td height="300"></td></tr></table>

</div>
<!-------------------------------------------- End of in-active screen -------------------------------------------->

<!-------------------------------------------- Start active screen -------------------------------------------->
<div id="dvActive" runat="server">

     <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal Name" for="lblDescription">Proposal Name </label>
            </div>
            
            <div class="col-md-4">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs">(Proposal Name)</asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="lblCode">Promotional Code </label>
            </div>            
            <div class="col-md-2">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs">(Promotional Code)</asp:Label>
                <asp:Label ID="lblRole" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
    </div>


    <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="CLOSED"></asp:Label></a></li>                            
     </ul>

    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Post Mortem" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Signed Proposal" for="fldSignedProposal">Signed Proposal</label>
            </div>            
            <div class="col-md-3">                
                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/SignedProposal/<%=lblFileNameSP.Text%>" target="_blank" title="Click here"><asp:Label ID="lblFileNameSP" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal Status" for="lblStatus">Proposal Status </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblStatus" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvResult" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Result" for="fldResult">Result <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:DropDownList ID="fldResult" runat="server" CssClass="form-control input-xxs" Width="140px"></asp:DropDownList>                     
            </div>
        </div>        
    </div>

    <div class="row">
        <div id="dvClientFeedback" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Feedback" for="fldClientFeedback">Client Feedback <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                <asp:TextBox ID="fldClientFeedback" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Client Feedback)" MaxLength="850"></asp:TextBox>                              
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvReasonResult" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Reason Win / Lose" for="fldReasonResult">Reason Win / Lose <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldReasonResult" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Reason Win / Lose)" MaxLength="850"></asp:TextBox>          
            </div>
        </div>
    </div>
        
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Feedback Form" for="fldFeedbackForm">Client Feedback Form</label>
            </div>            
            <div class="col-md-3">                
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
        <div id="dvResultMargin" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Win / Lose Margin" for="fldResultMargin">Win / Lose Margin</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <asp:TextBox ID="fldResultMargin" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" CausesValidation="true"></asp:TextBox><asp:Label ID="lblPercent3" runat="server" class="control-label input-xxs" Text="%"></asp:Label> 
                    <asp:CompareValidator runat="server" ID="cValidator1" ControlToValidate="fldResultMargin" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>

                    <asp:DropDownList ID="fldMargin" runat="server" CssClass="form-control input-xxs" Width="140px"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvLessonLearnt" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Lesson Learnt" for="fldLessonLearnt">Lesson Learnt</label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldLessonLearnt" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Lesson Learnt)" MaxLength="850"></asp:TextBox>          
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Contract / LOA" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract / LOA" for="fldContractLOA">Contract / LOA</label> 
            </div>            
            <div class="col-md-3">                
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
        <div class="col-md-1">   </div>
        <div id="dvJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldJustification">If None, Justification</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(If None, Justification)" MaxLength="850"></asp:TextBox>          
            </div>
        </div>
    </div>
    


    <div class="row">
        <div id="dvContractLOAExpDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Expected Contract / LOA To Be Obtained" for="fldContractLOAExpDate">Expected Contract / LOA <br />To Be Obtained </label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtContractLOAExpDate'>
                        <asp:TextBox ID="fldContractLOAExpDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the proposal details.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the proposal details. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Finance and Project Manager for info. Finance will close the promotional code in the Finance system.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" />  
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->

    <script>
        $(function () {            
            $('#dtContractLOAExpDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
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

</asp:Content>
    




