<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AuditCSSView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="AuditCSSView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    <asp:Table ID="Table4" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncomingView.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetailView.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="AuditTrailView.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
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
                    <li ID="tab2" runat="server"><a href='AuditTrailView.aspx?Id=<%= Request.QueryString["Id"] %>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="AUDIT TRAIL"></asp:Label></a></li>
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="CLIENT SATISFACTION SURVEY"></asp:Label></a></li>
                    
                    
                </ul>
    
        
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvAuditCSS" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="CSS" for="fldEIA">CSS </label><br />
                <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>Survey Form</em></asp:Label> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('Template/Survey Form - opus rev.8.docx')"></asp:ImageButton>
            </div>
            
            <div class="col-md-10">                 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalC" data-toggle="modal" width="150" runat="server" disabled>&nbsp;&nbsp;New CSS&nbsp;&nbsp;</button>
                <br />

    <asp:GridView ID="gvAuditCSS" runat="server" Width="100%" AutoGenerateColumns="false" PageSize="5" AllowPaging="true"  OnPageIndexChanging="gvAuditCSS_OnPageIndexChanging" CssClass="table table-bordered table-striped input-xxs" OnRowDataBound="gvAuditCSS_RowDataBound">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Year" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Client Name" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName")%>' CssClass="input-xxs"></asp:Label> 
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email").ToString() != "" ? Eval("Email") : "N/A"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date Required" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblDateRequired" runat="server" Text='<%# Eval("DateRequired", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>' CssClass="input-xxs"></asp:Label> 
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>    

    <asp:TemplateField HeaderText="CSS Link" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Hyperlink ID="lblLink" runat="server" Text='Result' CssClass="input-xxs" Target="_blank"></asp:Hyperlink>

            <asp:LinkButton ID="lnkReminder" runat="server" CommandArgument = '<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to send reminder to this client?')" Text = "Send Reminder" OnClick = "SendReminder"></asp:LinkButton>
            
            <asp:Hyperlink ID="lblManualUpdate" runat="server" Text='Link' CssClass="input-xxs"></asp:Hyperlink>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="CSS Form" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="lblLinkForm" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/" + Eval("Id") + "/CSSForm/" + Eval("CSSForm") + "" %>' Target="_blank"><%# Eval("CSSForm").ToString()%></asp:HyperLink>            

            <asp:Label ID="lblNAForm" runat="server" Text='N/A' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                
    </Columns>
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New CSS</b> button to send the CSS link to the selected client.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Result</b> link to see the CSS result that has been submitted by the selected client.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Send Reminder</b> link to send a reminder to the selected client.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/> 
         
    </div>
    
   <div class="modal fade" id="myModalC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXC" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblContract" runat="server" class="control-label input-xxs" Text="New CSS" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputC" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />

    <div class="row">
        <div id="dvYear" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Year" for="fldYear">Year <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldYear" runat="server" CssClass="form-control input-xxs" Width="180px"></asp:DropDownList> 
            </div>            
        </div>
    </div>

    <div class="row">
        <div id="dvClientName" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Client Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldClientName" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(Client Name)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvEmail" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Email Address" for="fldEmail">Email Address <font color="Red">*</font></label>
            </div>            
            <div class="col-md-7">  
                <div class="form-inline">
                    <asp:TextBox ID="fldEmail" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Email Address)" MaxLength="850"></asp:TextBox> <br />
                    <asp:Label ID="Label1" runat="server" class="control-label input-xxs"><em>(Required for send email option)</em></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvDateRequired" runat="server">   
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Required" for="fldDateRequired">Date Required <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <div class='input-group input-group-xs' id='dtDateRequired'>
                        <asp:TextBox ID="fldDateRequired" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                     
                </div>
            </div>
        </div>
    </div>

    <br />
            
    <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" CssClass="btn btn-danger btn-xs input-xxs" Width="90" OnClick="btnSendEmail_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnManualInput" runat="server" Text="Manual Input" CssClass="btn btn-basic btn-xs input-xxs" Width="100" OnClick="btnManualInput_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseC" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseC_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
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

    <script>
        $(function () {
            $('#dtDateRequired').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

        });
    </script>

</div>



</asp:Content>
    



    