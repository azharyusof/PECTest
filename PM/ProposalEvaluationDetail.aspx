<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProposalEvaluationDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProposalEvaluationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">PROPOSAL EVALUATION / SUBMISSION</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Proposal_Evaluation.pdf')"></asp:ImageButton></asp:TableCell>
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
                <asp:Label ID="lblProjectFees" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="lblCode">Promotional Code </label>
            </div>            
            <div class="col-md-2">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs">(Promotional Code)</asp:Label>
            </div>
        </div>
    </div>

    <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="EVALUATION / SUBMISSION"></asp:Label></a></li>                    
     </ul>

    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Board / Management Approval" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Board / Management Approval Required?" for="fldBoardRequired">Board / Management Approval Required?</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldBoardRequired" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList>                     
                <asp:Label ID="lblBtnSubmit" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
                <asp:Label ID="lblBtnPreSubmit" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>        
    </div>
        
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Service AgreementBoard / Management Paper" for="fldBoardPaper">Board / Management Paper</label>
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

    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Final Proposal & Review" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div id="dvClosingDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal Closing Date" for="fldClosingDate">Proposal Closing Date <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtClosingDate'>
                        <asp:TextBox ID="fldClosingDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
            </div>
        </div>     
        <div class="col-md-1">  </div>
        <div id="dvAwardDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Tentative Award Date" for="fldAwardDate">Tentative Award Date</label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtAwardDate'>
                        <asp:TextBox ID="fldAwardDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvReviewedByDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal To Be Approved By" for="fldReviewedByDate">Proposal To Be Approved <br />By <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtReviewedByDate'>
                        <asp:TextBox ID="fldReviewedByDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
            </div>
        </div>
    </div>
    
    

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Organization Chart" for="fldOrgChart">Project Organization Chart </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA7" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA7" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA7" />
                            <asp:PostBackTrigger ControlID="btnUpA7" />
                            <asp:PostBackTrigger ControlID="btnViewA7" />
                            <asp:PostBackTrigger ControlID="btnDeleteA7" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA7Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA7" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA7Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA7" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA7();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA7" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA7_Click" OnClientClick="return validateErrA7();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA7Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA7" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA7" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA7_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA7" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA7_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Manning Schedule" for="fldManSchedule">Manning Schedule </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA10" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA10" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA10" />
                            <asp:PostBackTrigger ControlID="btnUpA10" />
                            <asp:PostBackTrigger ControlID="btnViewA10" />
                            <asp:PostBackTrigger ControlID="btnDeleteA10" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA10Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA10" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA10Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA10" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA10();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA10" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA10_Click" OnClientClick="return validateErrA10();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA10Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA10" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA10" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA10_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA10" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA10_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
    </div>

        
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal For Review" for="fldProposalForReview">Technical Proposal For Approve <font color="Red">*</font></label>
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
        
    </div>
        
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvTechnicalApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Technical Approval">Technical Approval </label>
            </div>
            
            <div class="col-md-10"> 
                
                <asp:Table ID="tblTechnicalApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblTechnicalApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>                            
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblTechnicalA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldTechnicalApprover" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList>
                                <asp:Label ID="lblTechnical_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblTechnical_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblTechnical_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

            </div>
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>
       
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal For Review" for="fldProposalForReview">Commercial Proposal For Approve <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA4" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA4" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA4" />
                            <asp:PostBackTrigger ControlID="btnUpA4" />
                            <asp:PostBackTrigger ControlID="btnViewA4" />
                            <asp:PostBackTrigger ControlID="btnDeleteA4" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA4Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA4" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA4Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA4" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA4();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA4" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA4_Click" OnClientClick="return validateErrA4();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA4Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA4" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA4" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA4_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA4" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA4_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
        
    </div>
        
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvCommercialApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Commercial Approval">Commercial Approval </label>
            </div>
            
            <div class="col-md-10"> 
                
                <asp:Table ID="tblCommercialApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs" >
                        
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblCommercialApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>   
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblCommercialA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldCommercialApprover" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList>
                                <asp:Label ID="lblCommercial_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblCommercial_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblCommercial_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

            </div>
        </div>
    </div>



    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvLegalRequired" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Legal / Risk Approval Required?" for="fldLegalRequired">Legal / Risk Approval Required? <font color="Red">*</font></label>
                <br />
                    <asp:Label ID="Label8" runat="server" class="control-label input-xxs"><em>[Legal / Risk Approval is required for Potential Project Fees >= RM10m]</em></asp:Label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldLegalRequired" runat="server" CssClass="form-control input-xxs" Width="150px" OnSelectedIndexChanged="fldLegalRequired_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                     
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvLegalJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldLegalJustification">Justification</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldLegalJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850"></asp:TextBox>          
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal For Review" for="fldProposalForReview">Legal / Risk Proposal For Approve </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA5" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA5" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA5" />
                            <asp:PostBackTrigger ControlID="btnUpA5" />
                            <asp:PostBackTrigger ControlID="btnViewA5" />
                            <asp:PostBackTrigger ControlID="btnDeleteA5" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA5Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA5" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA5Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA5" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA5();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA5" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA5_Click" OnClientClick="return validateErrA5();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA5Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA5" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA5" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA5_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA5" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA5_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
        
    </div>
        
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvLegalApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Legal / Risk Approval">Legal / Risk Approval </label>
            </div>
            
            <div class="col-md-10"> 
                    <asp:Label ID="lblLegalApp" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">N/A</asp:Label>

                    <asp:Table ID="tblLegalApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs" Visible="false">
                        
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblLegalApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblLegalA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldLegalApprover" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList>
                                <asp:Label ID="lblLegal_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblLegal_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblLegal_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="Signed Proposal" Font-Bold="true"></asp:Label>

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
        <div id="dvDALApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Acknowledgement </label>
                <br />
                    <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>[As per <b>DAL 3.2:</b> Submission of Tender Bids / Proposals]</em></asp:Label>
            </div>
            
            <div class="col-md-10"> 

            <asp:Table ID="tblDALApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="4"><asp:Label ID="lblDALApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Acknowledgement</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDAL1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblDAL2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblDAL3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                            </asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDAL_Approver" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblDAL_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblDAL_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                
                            </asp:TableCell>
                        </asp:TableRow>
            </asp:Table>

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
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Pre-Submit</b> button to submit the proposal for review. </asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Technical, Commercial and / or Legal / Risk for approval.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the signed proposal. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to DAL (Discretionary Authority Limits) person for acknowledgement.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" />         
        &nbsp;&nbsp;<asp:Button ID="btnPreSubmit" runat="server" Text="Pre-Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="85" OnClick="btnPreSubmit_Click" OnClientClick = "return confirm('Are you sure you want to pre-submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" OnClientClick = "return confirm('Are you sure you want to submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/> 
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->

    <script>
        $(function () {
            $('#dtClosingDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            $('#dtAwardDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            $('#dtReviewedByDate').datetimepicker({
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

    <script type="text/javascript">
        function clearUploadA4() {
            document.getElementById('<%=fldA4Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA4.ClientID%>').className = "form-group";
        }

        function validateErrA4()
        {
            var chckErrA4 = true;

            if (document.getElementById('<%=fldA4Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA4.ClientID%>').className = "form-group has-error";
                chckErrA4 = false;
            }
            return chckErrA4;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA5() {
            document.getElementById('<%=fldA5Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA5.ClientID%>').className = "form-group";
        }

        function validateErrA5()
        {
            var chckErrA5 = true;

            if (document.getElementById('<%=fldA5Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA5.ClientID%>').className = "form-group has-error";
                chckErrA5 = false;
            }
            return chckErrA5;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA7() {
            document.getElementById('<%=fldA7Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA7.ClientID%>').className = "form-group";
        }

        function validateErrA7()
        {
            var chckErrA7 = true;

            if (document.getElementById('<%=fldA7Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA7.ClientID%>').className = "form-group has-error";
                chckErrA7 = false;
            }
            return chckErrA7;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA10() {
            document.getElementById('<%=fldA10Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA10.ClientID%>').className = "form-group";
        }

        function validateErrA10()
        {
            var chckErrA10 = true;

            if (document.getElementById('<%=fldA10Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA10.ClientID%>').className = "form-group has-error";
                chckErrA10 = false;
            }
            return chckErrA10;
        }
    </script>

</asp:Content>
    



