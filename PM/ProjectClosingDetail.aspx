<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectClosingDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectClosingDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

<%--                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             --%>
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
                    <li ID="tab2" runat="server" class="active"><a href="#tab2primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="CLOSED"></asp:Label></a></li>
                </ul>

    <table><tr><td height="12"></td></tr></table>

    
    <div class="row">
        <div id="dvStatus" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Status" for="fldStatus">Status </label>
            </div>            
            <div class="col-md-2">                
                <asp:Label ID="lblStatus" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvCerts" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="All Relevant Certs" for="fldCerts">All Relevant Certs </label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150">&nbsp;&nbsp;New Relevant Certs&nbsp;&nbsp;</button>
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
        <div id="dvEIA" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">Checklist <font color="Red">*</font></label><br />
                <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>Job Completion Report</em></asp:Label> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/dload.png" ToolTip="Download template" OnClientClick="window.open('Template/E2E Job Completion Report Template_Final.doc')"></asp:ImageButton>
            </div>
            
            <div class="col-md-10"> 

                <asp:Table ID="tblChecklist" runat="server" Width="80%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl01" runat="server" class="control-label input-xxs">1.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistA" runat="server" class="control-label input-xxs">Issuance of Certificate of Practical Completion (CPC)</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/MonthlyProjectDocument/<%=lblChecklist01.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist01" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist01_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl08" runat="server" class="control-label input-xxs">2.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistH" runat="server" class="control-label input-xxs">Submit final copies of plan / as-built drawings, operations <br />& maintenance manuals & records to Client</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">

                                <asp:HiddenField ID="hidURLA1" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA1" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA1" />
                                            <asp:PostBackTrigger ControlID="btnUpA1" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA1Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA1" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA1Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA1" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA1" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                
                            </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl09" runat="server" class="control-label input-xxs">3.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistI" runat="server" class="control-label input-xxs">Submit the Job Completion Report (JCR)</asp:Label>
                                
                                <div class="row">
                                    <div>
                                        <div class="col-md-12">
                                            <asp:Label ID="chk1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Prepare and sign by PD / PM</asp:Label> 
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div>
                                        <div class="col-md-12">
                                            <asp:Label ID="chk2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Review and sign by HOD from Project Delivery</asp:Label> 
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div>
                                        <div class="col-md-12">
                                            <asp:Label ID="chk3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Approve and sign by COO</asp:Label> 
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div>
                                        <div class="col-md-12">
                                            <asp:Label ID="chk4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Presented to the Management</asp:Label> 
                                        </div>
                                    </div>
                                </div>

                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                
                                <asp:HiddenField ID="hidURLA2" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA2" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA2" />
                                            <asp:PostBackTrigger ControlID="btnUpA2" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA2Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA2" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA2Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA2" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA2" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                            </asp:TableCell>
                         </asp:TableRow>


                         <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl02" runat="server" class="control-label input-xxs">4.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistB" runat="server" class="control-label input-xxs">Project Proposal</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/SignedProposal/<%=lblChecklist02.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist02" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist02_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl03" runat="server" class="control-label input-xxs">5.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistC" runat="server" class="control-label input-xxs">Service Agreement</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/ServiceAgreement/<%=lblChecklist03.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist03" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist03_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl04" runat="server" class="control-label input-xxs">6.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistD" runat="server" class="control-label input-xxs">LOA</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/ProjectLOA/<%=lblChecklist04.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist04" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist04_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl05" runat="server" class="control-label input-xxs">7.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistE" runat="server" class="control-label input-xxs">Tender / Construction Drawing</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/MonthlyProjectDocument/<%=lblChecklist05.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist05" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist05_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl06" runat="server" class="control-label input-xxs">8.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistF" runat="server" class="control-label input-xxs">Contract Document</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/MonthlyProjectDocument/<%=lblChecklist06.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist06" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist06_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl07" runat="server" class="control-label input-xxs">9.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistG" runat="server" class="control-label input-xxs">PQP / PSP</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                
                                <asp:GridView ID="gvPQP" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
                                <Columns>                
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>
                                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                       <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/PQP/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
                                    </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                </asp:GridView>

                            </asp:TableCell>
                         </asp:TableRow>
                                            

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl10" runat="server" class="control-label input-xxs">10.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistJ" runat="server" class="control-label input-xxs">As-built drawing - soft copy</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">

                                <asp:HiddenField ID="hidURLA3" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA3" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA3" />
                                            <asp:PostBackTrigger ControlID="btnUpA3" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA3Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA3" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA3Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA3" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA3" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl11" runat="server" class="control-label input-xxs">11.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistK" runat="server" class="control-label input-xxs">All files pertaining to Contractual matters, Variation Orders and Claims</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/CRVO/<%=lblChecklist11.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist11" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist11_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl12" runat="server" class="control-label input-xxs">12.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistL" runat="server" class="control-label input-xxs">Archive records based on the Record Retention Table (RRT)</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                
				            <asp:HiddenField ID="hidURLA4" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA4" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA4" />
                                            <asp:PostBackTrigger ControlID="btnUpA4" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA4Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA4" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA4Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA4" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA4" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl13" runat="server" class="control-label input-xxs">13.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistM" runat="server" class="control-label input-xxs">Defect Liability Period (DLP) / Certificate of Make Good Defect (CMGD)</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/CRVO/<%=lblChecklist13.Text%>" target="_blank" title="Click here"><asp:Label ID="lblChecklist13" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                                <asp:Label ID="lblChecklist13_Blank" runat="server" class="control-label input-xxs" Text="None"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl14" runat="server" class="control-label input-xxs">14.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistN" runat="server" class="control-label input-xxs">Submit Final Claim (Contractor / Consultant)</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                
				            <asp:HiddenField ID="hidURLA5" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA5" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA5" />
                                            <asp:PostBackTrigger ControlID="btnUpA5" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA5Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA5" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA5Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA5" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA5" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                            </asp:TableCell>
                         </asp:TableRow>


                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl15" runat="server" class="control-label input-xxs">15.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="lblChecklistO" runat="server" class="control-label input-xxs">Submit Final Account (Contractor / Consultant)</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                
				            <asp:HiddenField ID="hidURLA6" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA6" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA6" />
                                            <asp:PostBackTrigger ControlID="btnUpA6" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA6Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA6" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA6Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA6" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA6" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                            </asp:TableCell>
                         </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label1" runat="server" class="control-label input-xxs">16.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label2" runat="server" class="control-label input-xxs">Other Additional Documents</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                
				            <asp:HiddenField ID="hidURLA7" runat="server" />
                                <asp:UpdatePanel runat="server" id="UpA7" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnCancelA7" />
                                            <asp:PostBackTrigger ControlID="btnUpA7" />
                                        </Triggers>
                                        <ContentTemplate>
                           
                                                <div id="dvUpA7Sec" runat="server" class="row">
                                                    <div class="col-md-3"> 
                                                        <div id="dvA7" runat="server" class="form-group">
                                                            <div class="input-group input-group-xs">
                                                                <asp:FileUpload ID="fldA7Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                                <span class="input-group-btn"><asp:Button ID="btnCancelA7" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" /></span>
                                                                <span class="input-group-btn"><asp:Button ID="btnUpA7" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" /></span>
                                                            </div>                                            
                                                        </div>
                                                    </div>
                                                </div>
                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                            </asp:TableCell>
                         </asp:TableRow>
                        
                    </asp:Table>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvFinalAccSubCon" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Have Sub Consultant Submitted Final Claim?" for="fldFinalClaimSubCon">Have Sub Consultant Submitted Final Claim? <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldFinalClaimSubCon" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvFinalAccSubConRemarks" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldFinalClaimSubConRemarks">Remarks <br />(If No)</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldFinalClaimSubConRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks - Have Sub Consultant Submitted Final Claim?)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>
        
    <div class="row">
        <div id="dvClosedUpSubCon" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Have You Closed Up Sub Consultant's Final Account?" for="fldClosedUpSubCon">Have You Closed Up Sub Consultant's Final Account? <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldClosedUpSubCon" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvClosedUpSubConRemarks" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldClosedUpSubConRemarks">Remarks <br />(If No)</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldClosedUpSubConRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks - Have You Closed Up Sub Consultant's Final Account?)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvFinalizeManMonth" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Have You Finalized Man-Month Input (7 days from DLP close)?" for="fldFinalizeManMonth">Have You Finalized Man-Month Input? <font color="Red">*</font><br />(7 days from DLP close) </label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldFinalizeManMonth" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvFinalizeManMonthRemarks" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldFinalizeManMonthRemarks">Remarks <br />(If No)</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldFinalizeManMonthRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks - Have You Finalized Man-Month Input?)" MaxLength="850"></asp:TextBox> 
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
        <div id="dvRetentionSumClaimedRemarks" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldRetentionSumClaimedRemarks">Remarks <br />(If No)</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldRetentionSumClaimedRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks - Retention Sum Claimed?)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
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
        <div class="col-md-1"></div>
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

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Summary" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
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

    <div class="row">
        <div id="dvWhatWentWell" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="What Went Well?" for="fldWhatWentWell">What Went Well?</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldWhatWentWell" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(What Went Well?)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>   
        <div class="col-md-1"></div>
        <div id="dvWhatCanImprove" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="What Can We Improve?" for="fldWhatCanImprove">What Can We Improve?</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldWhatCanImprove" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(What Can We Improve?)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvHighlightInnovation" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Highlights & Innovation" for="fldHighlightInnovation">Highlights & Innovation</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldHighlightInnovation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Highlights & Innovation)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>   
        <div class="col-md-1"></div>
        <div id="dvPerformClientExpectation" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Performance Against Client's Expectation" for="fldPerformClientExpectation">Performance Against Client's Expectation</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldPerformClientExpectation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Performance Against Client's Expectation)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvPerformSchedule" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Performance Against Schedule" for="fldPerformSchedule">Performance Against Schedule</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldPerformSchedule" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Performance Against Schedule)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>   
        <div class="col-md-1"></div>
        <div id="dvPerformBudget" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Performance Against Budget" for="fldPerformBudget">Performance Against Budget</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldPerformBudget" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Performance Against Budget)" MaxLength="850"></asp:TextBox> 
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the project status to Closed.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Relevant Certs</b> button to upload certificates.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Close</b> button to close the project details. No update is allowed when you have closed this project.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-10">
                <asp:Label ID="lblNote3a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Finance, Project Manager and Knowledge Management & Document Control (KMDC) for info. Finance will close the project account in the Finance system.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Inactive</b> button to inactive the project details.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-10">
                <asp:Label ID="lblNote4a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Finance for info. No more charging timesheet & internal claims but project account still open.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" />            
        &nbsp;&nbsp;<asp:Button ID="btnInactive" runat="server" Text="Inactive" CssClass="btn btn-warning btn-xs input-xxs" Width="70" OnClick="btnInactive_Click" OnClientClick = "return confirm('Are you sure you want to inactive this project?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnClose_Click" OnClientClick = "return confirm('Are you sure you want to close this project?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/> 
        &nbsp;&nbsp;<asp:Button ID="btnPCC" runat="server" Text="Project Closure Checklist" CssClass="btn btn-warning btn-xs input-xxs" Width="160" OnClick="btnPCC_Click" Visible="false"/> 
         
            
    </div>
    
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblProjectDoc" runat="server" class="control-label input-xxs" Text="New Relevant Certs" Font-Bold="true"></asp:Label>
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


</div>

    <script type="text/javascript">        
        function funcOpenE() {
            $('#myModalE').modal('toggle');
            $('#myModalE').modal('show');
        }

        function funcCloseE() {
            $('#myModalE').modal('hide');
        }
    </script>

    

</asp:Content>
    


