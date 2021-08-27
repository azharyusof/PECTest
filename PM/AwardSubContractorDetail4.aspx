<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail4.aspx.cs" Inherits="AwardSubContractorDetail4" %>

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
                    <li ID="tab5" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/notes_accept24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PERFORMANCE REVIEW"></asp:Label></a></li>
                    <li ID="tab6" runat="server"><a href='AwardSubContractorDetail5.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server"><a href='AwardSubContractorDetail6.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="External Support Performance Review" Font-Bold="true"></asp:Label><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" class="control-label input-xxs" Text="(Frequency of review is yearly. If project duration is less than a year, perform review at end of service/contract. Regardless of duration of project, review at end of service/contract is mandatory)" Font-Italic="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvExtSupport" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="External Support to be Evaluated" for="fldExtSupport">External Support to be Evaluated <font color="Red">*</font></label>
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
                <asp:Label ID="Label5" runat="server" class="control-label input-xxs" Font-Italic="true">Note :</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label7" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Perform Review</b> button to perform review for the selected External Support.</asp:Label> 
            </div>
        </div>
    </div>
         
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label6" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> History of performance review record for an External Support can be viewed from <b>Pre-Qualified Vendor List</b>.</asp:Label> 
            </div>
        </div>
    </div>
    

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnReview" runat="server" Text="Perform Review" CssClass="btn btn-success btn-xs input-xxs" Width="110" Enabled="false"/>     
         
    </div>


    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="Label16" runat="server" class="control-label input-xxs" Text="Non-Conformance (NC) Service Monitoring Log" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvNCService" runat="server">
                        
            <div class="col-md-12"> 
                
                <asp:Button ID="Upload" runat="server" Text="New Non-Conformance (NC) Service" CssClass="btn btn-warning btn-xs input-xxs" Width="220" Enabled="false" />
                
                <br />

    <asp:GridView ID="gvNCService" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" >
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="External Support" HeaderStyle-Width="25%" ItemStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblExtSupportName" runat="server" Text='<%# Eval("ExtSupportName")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtExtSupportName" runat="server" CssClass="form-control input-xxs" Width="160px"></asp:DropDownList> 
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date Occurred" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblDateOccurred" runat="server" Text='<%# Eval("DateOccurred", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Detailed NC Services" HeaderStyle-Width="30%" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblNCServices" runat="server" Text='<%# Eval("NCServices")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtNCServices" runat="server" Text='<%# Eval("NCServices")%>' CssClass="form-control input-xxs" Width="220px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Required Action" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblRequiredAction" runat="server" Text='<%# Eval("RequiredAction").ToString() != "" ? Eval("RequiredAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtRequiredAction" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Bind("RequiredAction") %>'>
                    <asp:ListItem Value="Yes" Text="Yes" ></asp:ListItem>
                    <asp:ListItem Value="No" Text="No" ></asp:ListItem>
                </asp:DropDownList>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Notification Date" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblNotificationDate" runat="server" Text='<%# Eval("NotificationDate", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Proposed Action" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblProposedAction" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtProposedAction" runat="server" Text='<%# Eval("ProposedAction")%>' CssClass="form-control input-xxs" Width="180px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>  

    <asp:TemplateField HeaderText="Target Completion Date" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblTargetDate" runat="server" Text='<%# Eval("TargetDate", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() != "" ? Eval("Status").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
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
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this record?')" />
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Non-Conformance (NC) Service</b> button to create Non-Conformance (NC) service record.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back to Listing</b> button to return to the listing.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" /> 
         
            
    </div>

    

    <script type="text/javascript">
        function funcOpenC() {
            $('#myModalC').modal('toggle');
            $('#myModalC').modal('show');
        }

        function funcCloseC() {
            $('#myModalC').modal('hide');
        }
    </script>

    </div>
</asp:Content>
    







