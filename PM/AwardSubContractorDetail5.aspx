<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail5.aspx.cs" Inherits="AwardSubContractorDetail5" %>

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
                    <li ID="tab6" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server"><a href='AwardSubContractorDetail6.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    <table><tr><td height="12"></td></tr></table>

    <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="1. External Support Variation Record" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvNCService" runat="server">
                        
            <div class="col-md-12"> 
                <asp:Button ID="Upload" runat="server" Text="New External Support Variation" CssClass="btn btn-warning btn-xs input-xxs" Width="192" Enabled="false" />
                
                <br />

    <asp:GridView ID="gvNCService" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" >
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Contract Name / No." HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblExtSupportName" runat="server" Text='<%# Eval("ExtSupportName")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtExtSupportName" runat="server" CssClass="form-control input-xxs" Width="160px"></asp:DropDownList> 
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Change Description" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
           <asp:Label ID="lblProposedAction6" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Detailed NC Services" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblNCServices" runat="server" Text='<%# Eval("NCServices")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtNCServices" runat="server" Text='<%# Eval("NCServices")%>' CssClass="form-control input-xxs" Width="220px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Impact Assessment to Project Schedule" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
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

    <asp:TemplateField HeaderText="Impact Assessment to Project Cost / Risk" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblProposedAction1" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Supporting Document" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblProposedAction2" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtProposedAction" runat="server" Text='<%# Eval("ProposedAction")%>' CssClass="form-control input-xxs" Width="180px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>  

    <asp:TemplateField HeaderText="Client Notified / Approved?" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblProposedAction3" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Contract Fees Change Approval Status" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblProposedAction4" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtStatus" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Bind("Status") %>'>
                    <asp:ListItem Value="Open" Text="Open" ></asp:ListItem>
                    <asp:ListItem Value="Closed" Text="Closed" ></asp:ListItem>
                </asp:DropDownList>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Contract Addendum" HeaderStyle-Width="5%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblProposedAction5" runat="server" Text='<%# Eval("ProposedAction").ToString() != "" ? Eval("ProposedAction").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
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

    <table><tr><td height="5"></td></tr></table>

    <asp:Label ID="Label11" runat="server" class="control-label input-xxs" Text="2. External Support Contract Fees Change Approval Request" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

     <div class="row">
        <div id="dvExtSupport" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="External Support to be Evaluated" for="fldExtSupport">External Support <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldExtSupport" runat="server" CssClass="form-control input-xxs" Width="180px" >
                    <asp:ListItem Text="-- Select External Support --" Value="1" Selected="true" />

                </asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div2" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Reason For Variation <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Address)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="Div5" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Variation Fees</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="Label25" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" ></asp:TextBox> 
                </div>
            </div>
        </div>
    </div>

    <table><tr><td height="5"></td></tr></table>


    <div class="row">
        <div id="dvDALApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
            </div>
            
            <div class="col-md-10"> 

            <asp:Table ID="tblDALApproval" runat="server" Width="80%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="4"><asp:Label ID="lblDALApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2" Width="50%"><asp:Label ID="lblDALApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Reviewer</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2" Width="50%"><asp:Label ID="lblDALReviewer" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDALR1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALR2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALR3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALR4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                

                                <asp:Label ID="lvlDALNA" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666" >-</asp:Label>

                                <br /><asp:Label ID="lblDAL_ReviewedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                                <br /><asp:Label ID="lblDAL_ReviewedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                                <br /><asp:Label ID="lblDAL_ReviewedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDALA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="Label21" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666" >-</asp:Label>

                                <br /><asp:Label ID="Label22" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                                <br /><asp:Label ID="Label23" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>
                                <br /><asp:Label ID="Label24" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666">-</asp:Label>  </asp:TableCell>
                        </asp:TableRow>
            </asp:Table>

            </div>
        </div>   
    </div>

    <table><tr><td height="5"></td></tr></table>

    <asp:Label ID="Label5" runat="server" class="control-label input-xxs" Text="3. Addendum Review" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="Div1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="External Support to be Evaluated" for="fldExtSupport">Contract Addendum <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control input-xxs" Width="200px" >
                    <asp:ListItem Text="-- Select Contract Addendum --" Value="1" Selected="true" />

                </asp:DropDownList> 
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label6" runat="server" class="control-label input-xxs" Font-Italic="true"><u>Instructions</u></asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="Label7" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> If Contract Addendum is required, the document needs to be reviewed by Legal, approved and signed by DAL person.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label8" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> The signed copy shall be prepared and signed in triplicate copies :</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label9" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> One (1) copy to be kept by the vendor.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label10" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> One (1) copy to be kept by the our Legal.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label12" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> One (1) copy to be kept by the project team.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label13" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Digital signed copy to be uploaded onto the system.</asp:Label> 
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Signed Proposal" for="fldSignedProposal">Signed Addendum</label> 
            </div>            
            <div class="col-md-3">                
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
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA3" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" Enabled="false"/></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA3" runat="server" Text="Upload" CssClass="btn btn-success btn-xs"  Enabled="false"/></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the variation info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label14" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Pre-Submit</b> button to submit the variation info. </asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to DAL (Discretionary Authority Limits) person for approval.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the variation info. No update is allowed when you have submitted this page.</asp:Label> 
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
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Payment due to variation will only be made to the external support through reference made to the Service Agreement (with Addendum) as attached, thus Finance will need to record the terms from the Service Agreement (and Addendum).</asp:Label> 
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
        &nbsp;&nbsp;<asp:Button ID="btnPreSubmit" runat="server" Text="Pre-Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="85" Enabled="false" OnClientClick = "return confirm('Are you sure you want to pre-submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" Enabled="false" OnClientClick = "return confirm('Are you sure you want to submit this page?')" />         
        
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" /> 
            
            
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
    





