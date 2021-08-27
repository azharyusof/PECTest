<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SiteVisitHSEEAIDetailView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="SiteVisitHSEEAIDetailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncomingView.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetailView.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="SiteVisitHSELegalDetailView.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrailView.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">HSE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Execution.pdf')"></asp:ImageButton></asp:TableCell>
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
                    <li ID="tab2" runat="server"><a href='SiteVisitHSELegalDetailView.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="LEGAL REGISTER"></asp:Label></a></li>
                    <li ID="tab3" runat="server"><a href='SiteVisitHSEHIRARCDetailView.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="HIRARC"></asp:Label></a></li>
                    <li ID="tab4" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblFour" runat="server" class="control-label input-xxs" Text="ENVIRONMENTAL ASPECT & IMPACT"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='SiteVisitHSEPlanDetailView.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="lblFive" runat="server" class="control-label input-xxs" Text="HSE PLAN"></asp:Label></a></li>
                </ul>
    
     <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Contractor's Document (By Project Team)" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div id="dvEIA" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">EIA Report </label><br />
                <asp:Label ID="Label6" runat="server" class="control-label input-xxs"><em>(Environmental Impact Assessment)</em></asp:Label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150" runat="server">&nbsp;&nbsp;New EIA Report&nbsp;&nbsp;</button>
                <br />
    
    <%------------------------- EIA Report -------------------------%>
    <asp:GridView ID="gvEIA" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
        <Columns>                
        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
                <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
               <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/EIA/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
            </EditItemTemplate> 
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <div class="row">
        <div id="dvDOE" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Conditional Approval From DOE" for="fldDOE">Conditional Approval From DOE </label><br />
                <asp:Label ID="Label7" runat="server" class="control-label input-xxs"><em>(Department of Environment)</em></asp:Label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalF" data-toggle="modal" width="150" runat="server">&nbsp;&nbsp;New Conditional Approval From DOE&nbsp;&nbsp;</button>
                <br />

    <%------------------------- Conditional Approval From DOE -------------------------%>    
    <asp:GridView ID="gvDOE" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
        <Columns>                
        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
                <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
               <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/DOE/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFileNameDOE" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
            </EditItemTemplate> 
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>



    <div class="row">
        <div id="dvEMP" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EMP (Environmental Management Plan)" for="fldEMP">EMP (Environmental Management Plan) </label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalG" data-toggle="modal" width="150" runat="server">&nbsp;&nbsp;New EMP (Environmental Management Plan)&nbsp;&nbsp;</button>
                <br />

    <%------------------------- EMP (Environmental Management Plan) -------------------------%> 
    <asp:GridView ID="gvEMP" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
        <Columns>                
        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
                <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
               <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/EMP/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFileNameEMP" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
            </EditItemTemplate> 
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>



    <div class="row">
        <div id="dvCAI" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contractor's Aspect & Impact" for="fldCAI">Contractor's Aspect & Impact Assessment </label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalH" data-toggle="modal" width="150" runat="server">&nbsp;&nbsp;New Contractor's Aspect & Impact Assessment&nbsp;&nbsp;</button>
                <br />

    <%------------------------- Contractor's Aspect & Impact -------------------------%> 
    <asp:GridView ID="gvCAI" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
        <Columns>                
        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
           <ItemTemplate>
                <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
               <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/CAI/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFileNameCAI" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
            </EditItemTemplate> 
        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="OPUS's Document (By OPUS HSE)" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvOPUS" runat="server">
            <div class="col-md-2">
                <div class="form-inline">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Aspect / Impact Assessment" for="fldOPUS">Aspect / Impact Assessment </label>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('HSE/Aspect and Impact Template.xlsx')"></asp:ImageButton>
                    <br />
                    <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>(Standard aspect / impact assessment for OPUS)</em></asp:Label>
                    
                </div>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalI" data-toggle="modal" width="150" runat="server">&nbsp;&nbsp;New Aspect / Impact Assessment&nbsp;&nbsp;</button>
                <br />

                <%------------------------- OPUS's Aspect / Impact Assessment -------------------------%>
                <asp:GridView ID="gvOPUS" runat="server" Width="80%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
                    <Columns>                
                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                           <asp:Label ID="Label5" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="50%" ItemStyle-Width="50%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/OPUSEAI/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("DateCreated", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Reason for Revision" HeaderStyle-Width="30%" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblReason" runat="server" Text='<%# Eval("ReasonRevision").ToString() != "" ? Eval("ReasonRevision").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Uploaded By" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Eval("CREATEBYName").ToString() != "" ? Eval("CREATEBYName").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
                </asp:GridView>

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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New EIA Report</b> button to upload EIA report.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Conditional Approval From DOE</b> button to upload conditional approval from DOE.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New EMP (Environmental Management Plan)</b> button to upload EMP.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Contractor's Aspect & Impact Assessment</b> button to upload contractor's aspect & impact assessment.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote5" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Aspect / Impact Assessment</b> button to upload aspect / impact assessment.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote6" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on &nbsp;<img src="Img/dload.png"/>&nbsp; to download new template for aspect / impact assessment.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row" align="center">
       <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/> 
            
    </div>
    

    <%------------------------- EIA Report -------------------------%>
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblEIA" runat="server" class="control-label input-xxs" Text="New EIA Report" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputE" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>


    <%------------------------- Conditional Approval From DOE -------------------------%>
    <div class="modal fade" id="myModalF" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXF" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseF();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblDOE" runat="server" class="control-label input-xxs" Text="New Conditional Approval From DOE" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputF" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileNameDOE" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileNameDOE">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileNameDOE" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveF" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveF_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseF" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseF_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>


    <%------------------------- EMP (Environmental Management Plan) -------------------------%> 
    <div class="modal fade" id="myModalG" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXG" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseG();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblEMP" runat="server" class="control-label input-xxs" Text="New EMP (Environmental Management Plan)" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputG" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileNameEMP" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileNameEMP">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileNameEMP" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveG" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveG_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseG" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseG_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
    
    
    <%------------------------- Contractor's Aspect & Impact -------------------------%> 
    <div class="modal fade" id="myModalH" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXH" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseH();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblCAI" runat="server" class="control-label input-xxs" Text="New Contractor's Aspect & Impact" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputH" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileNameCAI" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileNameCAI">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileNameCAI" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveH" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveH_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseH" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseH_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>


    <%------------------------- Aspect / Impact Assessment -------------------------%> 
    <div class="modal fade" id="myModalI" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXI" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseI();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblAIA" runat="server" class="control-label input-xxs" Text="New Aspect / Impact Assessment" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label10" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileNameAIA" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName1">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileNameAIA" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvReason" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Reason for Revision" for="fldReasonRevision">Reason for Revision <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldReason" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Reason for Revision)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveI" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveI_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseI" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseI_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
    
</div>

    <script type="text/javascript">
        function funcOpenE() {
            $('#myModalE').modal('toggle');
            $('#myModalE').modal('show');
        }

        function funcCloseE() {
            $('#myModalE').modal('hide');
        }

        function funcOpenF() {
            $('#myModalF').modal('toggle');
            $('#myModalF').modal('show');
        }

        function funcCloseF() {
            $('#myModalF').modal('hide');
        }

        function funcOpenG() {
            $('#myModalG').modal('toggle');
            $('#myModalG').modal('show');
        }

        function funcCloseG() {
            $('#myModalG').modal('hide');
        }

        function funcOpenH() {
            $('#myModalH').modal('toggle');
            $('#myModalH').modal('show');
        }

        function funcCloseH() {
            $('#myModalH').modal('hide');
        }

        function funcOpenI() {
            $('#myModalI').modal('toggle');
            $('#myModalI').modal('show');
        }

        function funcCloseI() {
            $('#myModalI').modal('hide');
        }
    </script>

</asp:Content>
    


    



