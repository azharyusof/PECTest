<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail3.aspx.cs" Inherits="AwardSubContractorDetail3" %>

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
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">AWARD OF SUB CONTRACTOR</div>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Code" for="lblCode">Project Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>
    
                <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server"><a href='AwardSubContractorDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PRE-QUALIFIED <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VENDOR LIST"></asp:Label></a></li>
                    
                    <li ID="tab2" runat="server"><a href='AwardSubContractorDetail1.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="PRE-Q <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; REGISTRATION"></asp:Label></a></li>
                    <li ID="tab3" runat="server"><a href='AwardSubContractorDetail2.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="RECOMMEND FOR <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; APPOINTMENT"></asp:Label></a></li>
                    <li ID="tab4" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="AWARD"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='AwardSubContractorDetail4.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/notes_accept24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PERFORMANCE REVIEW"></asp:Label></a></li>
                    <li ID="tab6" runat="server"><a href='AwardSubContractorDetail5.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server"><a href='AwardSubContractorDetail6.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    <table><tr><td height="12"></td></tr></table>
    
     <div class="row">
        <div id="dvExtSupport" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="External Support to be Evaluated" for="fldExtSupport">Approved External Support Recommended for Appointment <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldExtSupport" runat="server" CssClass="form-control input-xxs" Width="180px" ></asp:DropDownList> 
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label5" runat="server" class="control-label input-xxs" Font-Italic="true"><u>Instructions</u></asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="Label7" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Once recommended vendor is approved, draft Consulting Services Agreement and draft LOA shall be prepared by Project Team.  Then, the draft shall be reviewed by Legal and signed by the DAL person that approved the recommended appointment.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label6" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> The signed copy shall be prepared and signed in triplicate copies :</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label8" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> One (1) copy to be kept by the vendor.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label9" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> One (1) copy to be kept by the our Legal.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label10" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> One (1) copy to be kept by the project team.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label11" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Digital signed copy to be uploaded onto the system, 3 mandatory documents (Service Agreement, LOA, Acceptance of LOA).</asp:Label> 
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvEIA" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">Signed Documents <font color="Red">*</font></label><br />
            </div>
            
            <div class="col-md-10"> 

                <asp:Table ID="tblApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Width="20%">
                                <asp:Label ID="lblRequestedBy" runat="server" class="control-label input-xxs">DOCUMENT 1</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Width="60%">
                                <asp:Label ID="Label30" runat="server" class="control-label input-xxs">SERVICE AGREEMENT</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White" Width="20%">
                                <asp:Button ID="Upload" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />

                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label12" runat="server" class="control-label input-xxs">DOCUMENT 2</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label13" runat="server" class="control-label input-xxs">SIGNED LOA</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button1" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />

                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label14" runat="server" class="control-label input-xxs">DOCUMENT 3</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label15" runat="server" class="control-label input-xxs">SIGNED ACCEPTANCE OF LOA</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button2" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />

                            </asp:TableCell>
                            </asp:TableRow>


                    

                </asp:Table>
            </div>
        </div>
    </div>

            
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the award info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the award info. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="Label29" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Procurement / Finance / Legal / DAL person will be notified. Any of these parties must “acknowledge” or “reject” if document is found in-complete and actions were not performed as instructed above.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Payment will only be made to the external support through reference made to the Service Agreement as attached, thus Finance will need to record the terms from the Service Agreement.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label16" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; The “acknowledged” External Support will be available for Performance Review.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label31" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back to Listing</b> button to return to the listing.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" Enabled="false"/> 
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Enabled="false" Width="65" OnClientClick = "return confirm('Are you sure you want to submit this page?')" />         
        
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" /> 
           
    </div>



   </div>

</asp:Content>
    




