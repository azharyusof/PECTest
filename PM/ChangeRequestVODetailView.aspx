 <%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ChangeRequestVODetailView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ChangeRequestVODetailView" %>

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

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ChangeRequestVODetailView.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrailView.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">CHANGE MANAGEMENT </div>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code" for="lblCode">Regular Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>

                <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="CHANGE MANAGEMENT"></asp:Label></a></li>
                    
                </ul>
    
    <table><tr><td height="12"></td></tr></table>
        
    <asp:Button ID="btnChange" runat="server" Text="New Change Item"  OnClick="btnChange_Click" CssClass="btn btn-warning btn-xs input-xxs" Width="125"/>
             
    <br />

    <!--Start of GridView Change Management-->
    
    <asp:GridView ID="gvChangeRequestVO" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvChangeRequestVO_OnPageIndexChanging" ShowHeaderWhenEmpty="True" Width="100%" EnableSortingAndPagingCallbacks="False" OnRowDataBound="gvChangeRequestVO_RowDataBound">
            <Columns>

                    <asp:TemplateField HeaderText="No." HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>                        
                    </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Change Request To / From" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblChangeRequestToFrom" runat="server" Text='<%# Eval("ChangeRequestToFrom").ToString() != "" ? Eval("ChangeRequestToFrom").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Title" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title").ToString() != "" ? Eval("Title").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contract No." HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblContractNo" runat="server" Text='<%# Eval("ContractNo").ToString() != "" ? Eval("ContractNo").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Type Of Changes" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblVariationType" runat="server" Text='<%# Eval("VariationType").ToString() != "" ? Eval("VariationType").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Reason For Changes" HeaderStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="30%">
                    <ItemTemplate>
                        <asp:Label ID="lblReason" runat="server" Text='<%# Eval("Reason").ToString() != "" ? Eval("Reason").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id").ToString() != "" ? Eval("Id") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cost Impact Due To Changes (RM)" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCostImpact" runat="server" Text='<%# Eval("CostImpact").ToString() != "" ? Eval("CostImpact", "{0:#,00.00}").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Schedule Impact Due To Changes" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblScheduleImpact" runat="server" Text='<%# Eval("ScheduleImpact").ToString() != "" ? Eval("ScheduleImpact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DAL Approval Status" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblDALApprovalStatus" runat="server" Text='<%# Eval("DALAppStatus").ToString() != "" ? Eval("DALAppStatus").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Supporting Documents" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%" ItemStyle-Wrap="false">
                        <ItemTemplate>
                        
                            <asp:GridView ID="GridViewAttachment" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/" + Eval("ChangeRequestId") + "/CRSupportingDoc/" + Eval("FileName") + "" %>' Target="_blank"><asp:Label ID="lblRemark" runat="server" Text= '<%# Eval("FileName").ToString()%>' ></asp:Label></asp:HyperLink>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>                            
                         </asp:GridView>

                         <asp:Label ID="lblAttachment" runat="server" CssClass="input-sm" Visible="false"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                
            </Columns>
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
    
    <!--End of GridView Change Request/VO-->
    
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Change Item</b> button to create change record.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Reason For Changes</b> link to update existing record.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/>                     
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->    

</div>

    <script>
        $(function () {

            $('#dtEBid').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true,
                useCurrent: false
            });
            
        });
    </script>


</asp:Content>
    


