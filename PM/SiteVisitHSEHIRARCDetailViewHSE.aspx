<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SiteVisitHSEHIRARCDetailViewHSE.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="SiteVisitHSEHIRARCDetailViewHSE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>OPPORTUNITY RECORD</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>OPPORTUNITY GO / NO-GO</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROPOSAL EVALUATION / SUBMISSION</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROPOSAL CLOSE</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>REGISTER NEW PROJECT</b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROJECT INITIATION</b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROJECT MONTHLY UPDATE</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>DOCUMENT MANAGEMENT</b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>AWARD <BR />TO THIRD<BR /> PARTY</b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>CHANGE MANAGEMENT</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="SiteVisitHSELegalDetailViewHSE.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>AUDIT / CUSTOMER SATISFACTION</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b>PROJECT CLOSE</b></asp:Label></asp:TableCell> 
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
                    <li ID="tab2" runat="server"><a href='SiteVisitHSELegalDetailViewHSE.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="LEGAL REGISTER"></asp:Label></a></li>
                    <li ID="tab3" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="HIRARC"></asp:Label></a></li>
                    <li ID="tab4" runat="server"><a href='SiteVisitHSEEAIDetailViewHSE.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblFour" runat="server" class="control-label input-xxs" Text="ENVIRONMENTAL ASPECT & IMPACT"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='SiteVisitHSEPlanDetailViewHSE.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="lblFive" runat="server" class="control-label input-xxs" Text="HSE PLAN"></asp:Label></a></li>
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
        <div id="dvHIRARC" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HIRARC Document" for="fldHIRARC">HIRARC Document </label><br />
                <asp:Label ID="Label4" runat="server" class="control-label input-xxs"><em>(Hazard Identification, Risk Assessment and Risk Control)</em></asp:Label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150" runat="server" disabled>&nbsp;&nbsp;New HIRARC Document&nbsp;&nbsp;</button>
                <br />

    <%------------------------- Contractor's HIRARC -------------------------%>                
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
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HIRARC Document" for="fldOPUS">HIRARC Document </label>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('HSE/HIRACH Template.xlsx')"></asp:ImageButton>
                    <br />
                    <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>(Standard HIRARC document for OPUS)</em></asp:Label>
                    
                </div>
            </div>
            
            <div class="col-md-10"> 
            <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalF" data-toggle="modal" width="150" runat="server" disabled>&nbsp;&nbsp;New HIRARC Document&nbsp;&nbsp;</button>
                <br />

    <%------------------------- OPUS's HIRARC -------------------------%>    
    <asp:GridView ID="gvOPUS" runat="server" Width="80%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="50%" ItemStyle-Width="50%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/HIRARC_OPUS/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New HIRARC Document</b> button to upload HIRARC document.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on &nbsp;<img src="Img/dload.png"/>&nbsp; to download new template for HIRARC.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row" align="center">
       <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/> 
    </div>
    
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblHIRARC" runat="server" class="control-label input-xxs" Text="New HIRARC Document" Font-Bold="true"></asp:Label>
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


    <div class="modal fade" id="myModalF" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXF" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblHIRARC1" runat="server" class="control-label input-xxs" Text="New HIRARC Document" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputF" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
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
            
            <asp:Button ID="btnSaveF" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveF_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseF" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseF_Click" UseSubmitBehavior="false" />
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
    </script>

</asp:Content>
    


    



