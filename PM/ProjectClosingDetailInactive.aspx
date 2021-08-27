<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectClosingDetailInactive.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectClosingDetailInactive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">PROJECT CLOSE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Execution.pdf')"></asp:ImageButton></asp:TableCell>
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
        <div id="dvCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Code" for="lblCode">Project Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>

               <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="INACTIVE"></asp:Label></a></li>
                    <li ID="tab2" runat="server"><a href='ProjectClosingClosedDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="CLOSED"></asp:Label></a></li>                    
                </ul>
    
    <table><tr><td height="12"></td></tr></table>
    
    
    <div class="row">
        <div id="dvRequestInactive" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Request System to Be Inactive" for="cbRequestInactive">Request System to Be Inactive <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:CheckBox ID="cbRequestInactive" runat="server" />
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvReason" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Reason" for="fldReason">Reason <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldReason" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Reason)" MaxLength="850" ></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvDuration" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Duration" for="fldDuration">Duration </label>
            </div>            
            <div class="col-md-4">   
                <div class="form-inline">             
                    <asp:TextBox ID="fldDurationNo" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" CausesValidation="true"></asp:TextBox> 
                    <asp:CompareValidator runat="server" ID="cValidator1" ControlToValidate="fldDurationNo" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/> 
                    <asp:DropDownList ID="fldDuration" runat="server" CssClass="form-control input-xxs" Width="130px" AppendDataBoundItems="true"></asp:DropDownList> 
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvNotifyFinance" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Notify Finance to Freeze Timesheet?" for="cbNotifyFinance">Notify Finance to Freeze Timesheet?</label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbNotifyFinance" runat="server" />
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvRetentionSumClaimed" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Retention Sum Claimed?" for="fldRetentionSumClaimed">Retention Sum Claimed?</label>
            </div>            
            <div class="col-md-4">                
                <div class="form-inline">
                    <asp:Label ID="lblRM1" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldRetentionSumClaimed" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                    <asp:CompareValidator runat="server" ID="cValidator2" ControlToValidate="fldRetentionSumClaimed" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvUpdateFinancialPlanning" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Update Financial Planning?" for="fldUpdateFinancialPlanning">Update Financial Planning?</label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldUpdateFinancialPlanning" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOutAmountToBill" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Outstanding Amount to Bill?" for="fldOutAmountToBill">Outstanding Amount to Bill?</label>
            </div>            
            <div class="col-md-3">                
                <div class="form-inline">
                    <asp:Label ID="lblRM2" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldOutAmountToBill" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                    <asp:CompareValidator runat="server" ID="cValidator3" ControlToValidate="fldOutAmountToBill" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvOutAmountUncollected" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Outstanding Amount Uncollected?" for="fldOutAmountUncollected">Outstanding Amount Uncollected?</label>
            </div>            
            <div class="col-md-3">                
                <div class="form-inline">
                    <asp:Label ID="lblRM3" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldOutAmountUncollected" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                    <asp:CompareValidator runat="server" ID="cValidator4" ControlToValidate="fldOutAmountUncollected" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvSubConFinalClaim" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Have Sub Consultant's Submitted Final Claim?" for="fldSubConFinalClaim">Have Sub Consultant's Submitted Final Claim?</label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldSubConFinalClaim" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvSubConFinalClaimRemarks" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldSubConFinalClaimRemarks">Remarks <br />(If No)</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldSubConFinalClaimRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks - Have Sub Consultant's Submitted Final Claim?)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvRemarks" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldRemarks">Remarks </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks)" MaxLength="850"></asp:TextBox> 
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
                <asp:Label ID="lblCreatedBy" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
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
                <asp:Label ID="lblCreatedDt" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the project status to Inactive.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the project inactive details. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-10">
                <asp:Label ID="lblNote2a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Finance, Project Manager and Knowledge Management & Document Control (KMDC) for info. Finance will freeze the project code in the Finance system.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" />         
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" OnClientClick = "return confirm('Are you sure you want to submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/>          
    </div>
    
</div>
<!-------------------------------------------- End of active screen -------------------------------------------->

</div>

</asp:Content>
    


