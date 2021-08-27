<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="EDMSIncoming.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="EDMSIncoming" %>

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
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="Label23" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell> 

<%--<asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             --%>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSEDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                            
                            
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">DOCUMENT MANAGEMENT</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
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
                &nbsp;&nbsp;<asp:Button ID="btnRequest" runat="server" Text="Request EDMS Link" CssClass="btn btn-success btn-xs input-xxs" Width="135" OnClick="btnRequest_Click" OnClientClick="return confirm('Are you sure you want to submit this request?')"/> 
<%--                <asp:Label ID="lblInactive" runat="server" class="control-label input-xxs" ForeColor="Red">SORRY, NO DOCUMENT MANAGEMENT FOUND FOR THIS PROJECT.</asp:Label>--%>
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Request EDMS Link</b> button to request a link with Electronic Document Management System (EDMS).</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Email notification will be sent to KMDC team with project details. Once approved, this tab will be activated.</asp:Label> 
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="lblDescription">EDMS Name </label>
            </div>            
            <div class="col-md-6">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs"></asp:Label> <asp:Label ID="lblCode" runat="server" class="control-label input-xxs" Visible="false"></asp:Label> <asp:Label ID="lblCode1" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>        
    </div>

                <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="INCOMING"></asp:Label></a></li>
                    
                    <li ID="tab2" runat="server"><a href='EDMSOutgoing.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="OUTGOING"></asp:Label></a></li>
                    
                </ul>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvProjectDoc" runat="server">            
            <div class="col-md-12"> 
                
                <table runat="server" width="100%">
                    <tr>   
                    <td align="left">
                        <div class="form-inline">
                            <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true">Filter By &nbsp;</label> <asp:DropDownList ID="fldRegion" runat="server" CssClass="form-control input-xxs" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="fldRegion_SelectedIndexChanged"></asp:DropDownList> 
                            <asp:DropDownList ID="fldYear" runat="server" CssClass="form-control input-xxs" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="fldYear_SelectedIndexChanged"></asp:DropDownList>   
                            <asp:DropDownList ID="fldCompany" runat="server" CssClass="form-control input-xxs" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="fldCompany_SelectedIndexChanged"></asp:DropDownList>   
                        </div>
                    </td>
                    <td align="right">
                        <div class="form-inline">
                            <asp:TextBox ID="fldSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox> 
                                &nbsp;<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnSearch_Click" ImageAlign="Middle"/>                                
                                &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnClear_Click" ImageAlign="Middle" Visible="false"/>
                        </div>
                    </td>
                    </tr>
                </table>


            <asp:GridView ID="gvProjectDoc" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" AllowPaging="true" PageSize="50" OnRowDataBound="gvProjectDoc_RowDataBound" OnPageIndexChanging="gvProjectDoc_OnPageIndexChanging">
            <Columns>                
            <asp:TemplateField HeaderText="#" HeaderStyle-Width="3%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="" ItemStyle-Width="30" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>                        
                           <asp:HyperLink ID="HyperLinkAll" ToolTip="Click here" runat="server" NavigateUrl='<%# "EDMSFile.aspx?C=" + Eval("PROJECT_CODE") + "&CC=" + Eval("COMPANY_CODE") + "&Y=" + Eval("YR") + "&M=In&TN=" + Eval("FLD_IN_SERIAL") %>' Target="_blank"><asp:Image style="cursor: pointer" src="Img/icon_pdf_small.gif" runat="server" id="img_all" /></asp:HyperLink>                        
                            <asp:Label ID="YR" runat="server" Text='<%# Eval("YR")%>' CssClass="input-sm" Visible="false"></asp:Label>
                            <asp:Label ID="TRACK_NO" runat="server" Text='<%# Eval("TRACK_NO")%>' CssClass="input-sm" Visible="false"></asp:Label>
                            <asp:Label ID="PROJECT_CODE" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>                                                         
                            <asp:Label ID="COMPANY_CODE" runat="server" Text='<%# Eval("COMPANY_CODE")%>' CssClass="input-sm" Visible="false"></asp:Label>                                                         
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Region" ItemStyle-Width="30" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>                       
                        <asp:Label ID="lblCode" runat="server" Text='<%# Eval("PROJECT_CODE")%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tracking No." ItemStyle-Width="100" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-Wrap="false" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>                       
                        <asp:Label ID="lblTNo" runat="server" Text='<%# Eval("FLD_IN_SERIAL")%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 
           <asp:TemplateField HeaderText="Date Received" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblRcvdDt" runat="server" Text='<%# Eval("FLD_IN_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="In Reference No." ItemStyle-Width="50" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblRefNo" runat="server" Text='<%# Eval("FLD_REFERENCE").ToString() != "" ? Eval("FLD_REFERENCE").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date of Document" ItemStyle-Width="80" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblDtDoc" runat="server" Text='<%# Eval("FLD_CORR_DATE", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Company" ItemStyle-Width="120" ItemStyle-CssClass="table" HeaderStyle-Width="50" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("FLD_COMPANY").ToString() != "" ? Eval("FLD_COMPANY").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Subject" ItemStyle-Width="300" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("FLD_TITLE1").ToString() != "" ? Eval("FLD_TITLE1").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" CssClass="form-control-plaintext form-control-sm" Text="No data found."></asp:Label></EmptyDataTemplate>
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
            </asp:GridView>
                
            </div>            
        </div>
    </div>
                   
    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Font-Italic="true">Note :</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span>  If the PDF file is not accessible, please contact the Document Controller of this project to upload the PDF file. </asp:Label> 
            </div>
        </div>
    </div>
            
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/>            
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->
    
    </div>
</asp:Content>
    


