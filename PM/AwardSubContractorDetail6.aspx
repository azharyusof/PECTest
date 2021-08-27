<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail6.aspx.cs" Inherits="AwardSubContractorDetail6" %>

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
                    <li ID="tab4" runat="server"><a href='AwardSubContractorDetail3.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="AWARD"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='AwardSubContractorDetail4.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/notes_accept24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PERFORMANCE REVIEW"></asp:Label></a></li>
                    <li ID="tab6" runat="server"><a href='AwardSubContractorDetail5.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvClientName" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Type / Request? <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                 <asp:DropDownList ID="fldType" runat="server" CssClass="form-control input-xxs" Width="230px" ></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvClientAdd" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Reason <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldClientAdd" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Reason)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvFinancialCloseOut" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Financial Close Out" for="fldFinancialCloseOut">Financial Close Out <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:DropDownList ID="fldFinancialCloseOut" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvCerts" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Report From Beacon" for="fldBeaconReport">All Relevant Certs </label>
            </div>
            
            <div class="col-md-10"> 
                <asp:Button ID="Upload" runat="server" Text="New Relevant Certs" CssClass="btn btn-warning btn-xs input-xxs" Width="135" Enabled="false" />
                <br />

            <asp:GridView ID="gvCerts" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
            <Columns>                
            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                   <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/Certs/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
                </EditItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteCerts"/>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
                <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
            </asp:GridView>
                
            </div>            
        </div>
    </div>

    <div class="row">
        <div id="dvRetentionSumClaimed" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Retention Sum Claimed?" for="fldRetentionSumClaimed">Retention Sum Claimed? <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldRetentionSumClaimed" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>            
        </div>
        <div class="col-md-1"></div>
        <div id="dvActionReqSumClaimed" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Action Required" for="fldActionReqSumClaimed">Final Performance Review Completed? </label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldPerformReview" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
    </div>


    <div class="row">
        <div id="dvLessonLearnt" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Lesson Learnt" for="fldLessonLearnt">Lesson Learnt </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldLessonLearnt" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Lesson Learnt)" MaxLength="850"></asp:TextBox> 
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the close out or termination request.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the close out or termination request. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Procurement / Finance for approval.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back to Listing</b> button to return to the listing.</asp:Label> 
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
    



