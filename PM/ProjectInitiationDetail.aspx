<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectInitiationDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectInitiationDetail" %>

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
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

<%--                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             --%>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">PROJECT INITIATION</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Initiation.pdf')"></asp:ImageButton></asp:TableCell>
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
        <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT INITIATION"></asp:Label></a></li>                    
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
        <div id="dvBoardRequired" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Board / Management Approval Required?" for="fldBoardRequired">Board / Management Approval Required?</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldBoardRequired" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList>                     
            </div>
        </div>
    </div>
        
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Board / Management Paper" for="fldBoardPaper">Board / Management Paper</label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA11" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA11" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA11" />
                            <asp:PostBackTrigger ControlID="btnUpA11" />
                            <asp:PostBackTrigger ControlID="btnViewA11" />
                            <asp:PostBackTrigger ControlID="btnDeleteA11" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA11Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA11" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA11Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA11" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA11();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA11" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA11_Click" OnClientClick="return validateErrA11();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA11Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA11" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA11" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA11_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA11" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA11_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label5" runat="server" class="control-label input-xxs" Text="Project Initiation" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvKickOffMeeting" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbKickOffMeeting">Contract Kick-Off Meeting Performed? </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbKickOffMeeting" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Service Agreement" for="fldServiceAgreement">Service Agreement </label>
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
        <div id="dvAgreement" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Supplement Agreement" for="fldAgreement">Supplement Agreement </label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalF" data-toggle="modal" width="150">&nbsp;&nbsp;New Supplement Agreement&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvAgreement" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/Agreement/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteAgreement"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Execution Plan" for="fldExecutionPlan">Project Execution Plan </label>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE1" data-toggle="modal" width="150">&nbsp;&nbsp;New Project Execution Plan&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvPEP" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/PEP/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeletePEP"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="PQP" for="fldPQP">PQP </label>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE2" data-toggle="modal" width="150">&nbsp;&nbsp;New PQP&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvPQP" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/PQP/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeletePQP"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="PSP" for="fldPSP">PSP </label>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE9" data-toggle="modal" width="150">&nbsp;&nbsp;New PSP&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvPSP" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/PSP/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeletePSP"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Legal Register" for="fldLegalRegister">Legal Register </label> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('HSE/General Legal Compliance Template.zip')"></asp:ImageButton>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE3" data-toggle="modal" width="150">&nbsp;&nbsp;New Legal Register&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvLegalRegister" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/LegalRegister/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteLegalRegister"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>
    

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HIRARC" for="fldHIRARC">HIRARC </label> <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('HSE/HIRACH Template.xlsx')"></asp:ImageButton>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE4" data-toggle="modal" width="150">&nbsp;&nbsp;New HIRARC&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvHIRARC" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/HIRARC/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteHIRARC"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>

    
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Environmental Aspect & Impact" for="fldEAI">Environmental Aspect & Impact </label><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('HSE/Aspect and Impact Template.xlsx')"></asp:ImageButton>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE5" data-toggle="modal" width="150">&nbsp;&nbsp;New Environmental Aspect & Impact&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvEAI" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/EAI/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteEAI"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>


    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HSE Plan" for="fldHSEPlan">HSE Plan </label> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('HSE/General 2018 (compliance check) BLANK COPY.doc')"></asp:ImageButton>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE6" data-toggle="modal" width="150">&nbsp;&nbsp;New HSE Plan&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvHSEPlan" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/HSEPlan/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteHSEPlan"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>


    <div class="row">
        <div id="dvProjectDoc" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Relevant Project Document" for="fldProjectDoc">Relevant Project Document </label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150">&nbsp;&nbsp;New Project Document&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvProjectDoc" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectDocument/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteProjectDoc"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Organization Chart" for="fldOrgChart">Organization Chart </label>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE7" data-toggle="modal" width="150">&nbsp;&nbsp;New Organization Chart&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvOrgChart" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/OrgChart/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteOrgChart"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Manning Schedule" for="fldManSchedule">Manning Schedule </label>
            </div>            
            <div class="col-md-10">                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE8" data-toggle="modal" width="150">&nbsp;&nbsp;New Manning Schedule&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvManningSchedule" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ManningSchedule/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteManningSchedule"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>

            </div>            
        </div>
    </div>

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

    

    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Risk Assessment / Register" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    
    <table><tr><td height="12"></td></tr></table>

         
    <div class="row">
        <div id="dvRiskAssessment" runat="server">
                        
            <div class="col-md-12"> 
                
                <table runat="server" width="100%">
                    <tr>
                    <td align="left">
                        <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalC" data-toggle="modal" width="150">&nbsp;&nbsp;New Risk Assessment&nbsp;&nbsp;</button>    
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="btnHeatMap" runat="server" ImageUrl="img/info.jpg" ToolTip="Risk Heat Map" OnClientClick="window.open('TableHeatMap.aspx', 'newwindow', 'width=700,height=450,toolbar=no'); return false;"></asp:ImageButton>  
                    </td>
                    </tr>
                </table>

    <asp:GridView ID="gvRiskAssessment" runat="server" Width="100%" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvRiskAssessment_OnPageIndexChanging" CssClass="table table-bordered table-striped input-xxs" onrowediting="EditRisk" onrowupdating="UpdateRisk" onrowcancelingedit="CancelRiskEdit" OnRowCreated="gvRiskAssessment_RowCreated" OnRowDataBound="gvRiskAssessment_RowDataBound">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblAssessDate" runat="server" Text='<%# Eval("AssessDate", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Category" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskCategory" runat="server" Text='<%# Eval("RiskCategory")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Title" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskTitle" runat="server" Text='<%# Eval("RiskTitle")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Description <br>(Include Cost & Impact of Risk)" HeaderStyle-Width="30%" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskDescription" runat="server" Text='<%# Eval("RiskDescription")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Gross Rating" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblGrossRating" runat="server" Text='<%# Eval("GrossRating").ToString() != "" ? Eval("GrossRating").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtGrossRating" runat="server" CssClass="form-control input-xxs" Width="120px"></asp:DropDownList> 
            
                        <asp:TextBox ID="txtGrossRatingId" runat="server" Text='<%# Eval("GrossRating")%>' CssClass="form-control input-xxs" Width="280px" Visible="false"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Existing Control" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblExistingControl" runat="server" Text='<%# Eval("ExistingControl").ToString() != "" ? Eval("ExistingControl").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtExistingControl" runat="server" Text='<%# Eval("ExistingControl")%>' CssClass="form-control input-xxs" Width="120px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Likelihood" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblLikelihood" runat="server" Text='<%# Eval("Likelihood").ToString() != "" ? Eval("Likelihood").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtLikelihood" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Likelihood")%>'>
                    <asp:ListItem Value="Certain" Text="Certain" ></asp:ListItem>
                    <asp:ListItem Value="Likely" Text="Likely" ></asp:ListItem>
                    <asp:ListItem Value="Possible" Text="Possible" ></asp:ListItem>
                    <asp:ListItem Value="Unlikely" Text="Unlikely" ></asp:ListItem>
                    <asp:ListItem Value="Remote" Text="Remote" ></asp:ListItem>
                </asp:DropDownList>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Impact" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact").ToString() != "" ? Eval("Impact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtImpact" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Impact")%>'>
                    <asp:ListItem Value="Insignificant" Text="Insignificant" ></asp:ListItem>
                    <asp:ListItem Value="Minor" Text="Minor" ></asp:ListItem>
                    <asp:ListItem Value="Moderate" Text="Moderate" ></asp:ListItem>
                    <asp:ListItem Value="Major" Text="Major" ></asp:ListItem>
                    <asp:ListItem Value="Catastrophic" Text="Catastrophic" ></asp:ListItem>
                </asp:DropDownList>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Rating" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskRating" runat="server" Text='<%# Eval("RiskRating").ToString() != "" ? Eval("RiskRating").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>   

    <asp:TemplateField HeaderText="Mitigation" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblMitigation" runat="server" Text='<%# Eval("Mitigation").ToString() != "" ? Eval("Mitigation").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtMitigation" runat="server" Text='<%# Eval("Mitigation")%>' CssClass="form-control input-xxs" Width="120px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>  
        
    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
        
        <asp:DropDownList ID="txtStatus" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Bind("Status") %>'>
                    <asp:ListItem Value="Open" Text="Open" ></asp:ListItem>
                    <asp:ListItem Value="Closed" Text="Closed" ></asp:ListItem>
                </asp:DropDownList>

    </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this record?')" OnClick="DeleteRisk"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>            
            <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" />
        </ItemTemplate>
        <EditItemTemplate>   
            <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update" ></asp:ImageButton>  
            <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>  
        </EditItemTemplate> 
    </asp:TemplateField>
    </Columns>
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Director Approval">Project Director Approval </label>
            </div>
            
            <div class="col-md-10"> 

            <asp:Table ID="tblPDApproval" runat="server" Width="50%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2" Width="50%"><asp:Label ID="Label4" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblPD1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblPD2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblPD3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblPD4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblPDApprover" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblPD_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                                <br />
                                <asp:Label ID="lblPD_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                                <br />
                                <asp:Label ID="lblPD_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
            </asp:Table>

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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the project initiation details.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Supplement Agreement</b> button to upload supplement agreement (if any).</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Project Document</b> button to upload relevant project document.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Risk Assessment</b> button to create risk assessment record.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote5" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the project initiation details. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote5a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Project Director for approval.</asp:Label> 
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
    
<!-------------------------------------------- Attachment - Relevant Project Document -------------------------------------------->
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblProjectDoc" runat="server" class="control-label input-xxs" Text="New Project Document" Font-Bold="true"></asp:Label>
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
<!-------------------------------------------- End of Attachment - Relevant Project Document -------------------------------------------->

<!-------------------------------------------- Attachment - Project Execution Plan -------------------------------------------->
    <div class="modal fade" id="myModalE1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE1();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="New Project Execution Plan" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label6" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName1" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName1">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName1" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE1" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE1_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE1" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE1_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - Project Execution Plan -------------------------------------------->

<!-------------------------------------------- Attachment - PQP -------------------------------------------->
    <div class="modal fade" id="myModalE2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE2();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label7" runat="server" class="control-label input-xxs" Text="New PQP" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label8" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName2" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName2">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName2" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE2" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE2_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE2" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE2_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - PQP -------------------------------------------->

<!-------------------------------------------- Attachment - Legal Register -------------------------------------------->
    <div class="modal fade" id="myModalE3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE3();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label9" runat="server" class="control-label input-xxs" Text="New Legal Register" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label10" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName3" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName3">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName3" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE3" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE3_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE3" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE3_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - Legal Register -------------------------------------------->

<!-------------------------------------------- Attachment - HIRARC -------------------------------------------->
    <div class="modal fade" id="myModalE4" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE4();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label11" runat="server" class="control-label input-xxs" Text="New HIRARC" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label12" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName4" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName4">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName4" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE4" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE4_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE4" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE4_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - HIRARC -------------------------------------------->

<!-------------------------------------------- Attachment - EAI -------------------------------------------->
    <div class="modal fade" id="myModalE5" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE5();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label13" runat="server" class="control-label input-xxs" Text="New Environmental Aspect & Impact" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label14" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName5" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName5">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName5" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE5" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE5_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE5" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE5_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - EAI -------------------------------------------->

<!-------------------------------------------- Attachment - HSE Plan -------------------------------------------->
    <div class="modal fade" id="myModalE6" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE6();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label15" runat="server" class="control-label input-xxs" Text="New HSE Plan" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label16" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName6" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName6">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName6" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE6" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE6_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE6" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE6_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - HSE Plan -------------------------------------------->

<!-------------------------------------------- Attachment - Organization Chart -------------------------------------------->
    <div class="modal fade" id="myModalE7" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE7();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label17" runat="server" class="control-label input-xxs" Text="New Organization Chart" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label18" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName7" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName7">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName7" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE7" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE7_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE7" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE7_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - Organization Chart -------------------------------------------->

<!-------------------------------------------- Attachment - Manning Schedule -------------------------------------------->
    <div class="modal fade" id="myModalE8" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE8();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label19" runat="server" class="control-label input-xxs" Text="New Manning Schedule" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label20" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName8" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName8">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName8" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE8" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE8_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE8" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE8_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - Manning Schedule -------------------------------------------->

    <!-------------------------------------------- Attachment - PSP -------------------------------------------->
    <div class="modal fade" id="myModalE9" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="LinkButton9" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE9();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label21" runat="server" class="control-label input-xxs" Text="New PSP" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="Label22" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileName9" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName9">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileName9" CssClass="form-control input-xxs" runat="server" Width="350px" />
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveE9" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE9_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseE9" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE9_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>
<!-------------------------------------------- End of Attachment - PSP -------------------------------------------->

<!-------------------------------------------- Attachment - Supplement Agreement -------------------------------------------->
    <div class="modal fade" id="myModalF" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXF" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseF();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblAgreement" runat="server" class="control-label input-xxs" Text="New Supplement Agreement" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputF" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
            <div class="row">
                <div id="dvFileNameA" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName">File Name <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:FileUpload ID="fldFileNameA" CssClass="form-control input-xxs" runat="server" Width="350px" />
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
<!-------------------------------------------- End of Attachment - Supplement Agreement -------------------------------------------->


    <div class="modal fade" id="myModalC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXC" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="New Risk Assessment / Register" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputC" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />

            <div class="row">
                <div id="dvAssessDate" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date" for="fldAssessDate">Date <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtAssessDate'>
                        <asp:TextBox ID="fldAssessDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvRiskCategory" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk Category" for="fldRiskCategory">Risk Category <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldRiskCategory" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList> 
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div id="dvRiskTitle" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk Title" for="fldRiskTitle">Risk Title <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldRiskTitle" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Risk Title)" CausesValidation="true"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvRiskDescription" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk Description" for="fldRiskDescription">Risk Description <br />(Include Cost & Impact of Risk) <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldRiskDescription" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Risk Description)" CausesValidation="true" TextMode="MultiLine" Height="60"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvGrossRating" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Gross Rating" for="fldGrossRating">Gross Rating <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldGrossRating" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvExistingControl" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Existing Control" for="fldExistingControl">Existing Control <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldExistingControl" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Existing Control)" CausesValidation="true"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvLikelihood" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Likelihood" for="fldLikelihood">Likelihood <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldLikelihood" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvImpact" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Impact" for="fldImpact">Impact <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldImpact" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList> 
                    </div>
                </div>
            </div>

            <br />
            
            <asp:Button ID="btnSaveC" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveC_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseC" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseC_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>

</div>

    <script>
        $(function () {
            $('#dtAssessDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            
        });
    </script>
    <script type="text/javascript">
        function funcOpenC() {
            $('#myModalC').modal('toggle');
            $('#myModalC').modal('show');
        }

        function funcCloseC() {
            $('#myModalC').modal('hide');
        }

        function funcOpenE() {
            $('#myModalE').modal('toggle');
            $('#myModalE').modal('show');
        }

        function funcCloseE() {
            $('#myModalE').modal('hide');
        }

        function funcOpenE1() {
            $('#myModalE1').modal('toggle');
            $('#myModalE1').modal('show');
        }

        function funcCloseE1() {
            $('#myModalE1').modal('hide');
        }

        function funcOpenE2() {
            $('#myModalE2').modal('toggle');
            $('#myModalE2').modal('show');
        }

        function funcCloseE2() {
            $('#myModalE2').modal('hide');
        }

        function funcOpenE3() {
            $('#myModalE3').modal('toggle');
            $('#myModalE3').modal('show');
        }

        function funcCloseE3() {
            $('#myModalE3').modal('hide');
        }

        function funcOpenE4() {
            $('#myModalE4').modal('toggle');
            $('#myModalE4').modal('show');
        }

        function funcCloseE4() {
            $('#myModalE4').modal('hide');
        }

        function funcOpenE5() {
            $('#myModalE5').modal('toggle');
            $('#myModalE5').modal('show');
        }

        function funcCloseE5() {
            $('#myModalE5').modal('hide');
        }

        function funcOpenE6() {
            $('#myModalE6').modal('toggle');
            $('#myModalE6').modal('show');
        }

        function funcCloseE6() {
            $('#myModalE6').modal('hide');
        }

        function funcOpenE7() {
            $('#myModalE7').modal('toggle');
            $('#myModalE7').modal('show');
        }

        function funcCloseE7() {
            $('#myModalE7').modal('hide');
        }

        function funcOpenE8() {
            $('#myModalE8').modal('toggle');
            $('#myModalE8').modal('show');
        }

        function funcCloseE8() {
            $('#myModalE8').modal('hide');
        }

        function funcOpenE9() {
            $('#myModalE9').modal('toggle');
            $('#myModalE9').modal('show');
        }

        function funcCloseE9() {
            $('#myModalE9').modal('hide');
        }
    </script>

    <script language="javascript" type="text/javascript">

        function ShowPopUp(e) {

            var ReturnValue = window.showModalDialog("PopUpPage.aspx", 'toolbar=no,status=no,resizable=1,scrollbars=1,menubar=no,location=no,width='+screen.width+',height=700')
            
            // alert(ReturnValue);
        }
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
        function clearUploadA11() {
            document.getElementById('<%=fldA11Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA11.ClientID%>').className = "form-group";
        }

        function validateErrA11()
        {
            var chckErrA11 = true;

            if (document.getElementById('<%=fldA11Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA11.ClientID%>').className = "form-group has-error";
                chckErrA11 = false;
            }
            return chckErrA11;
        }
    </script>

</asp:Content>
    


