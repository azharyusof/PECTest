<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail2.aspx.cs" Inherits="AwardSubContractorDetail2" %>

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
                    <li ID="tab3" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="RECOMMEND FOR <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; APPOINTMENT"></asp:Label></a></li>
                    <li ID="tab4" runat="server"><a href='AwardSubContractorDetail3.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="AWARD"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='AwardSubContractorDetail4.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/notes_accept24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PERFORMANCE REVIEW"></asp:Label></a></li>
                    <li ID="tab6" runat="server"><a href='AwardSubContractorDetail5.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server"><a href='AwardSubContractorDetail6.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    <table><tr><td height="12"></td></tr></table>
    
    
    <div class="row">
        <div id="dvExtSupport" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="External Support to be Evaluated" for="fldExtSupport">Scope of Services <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldExtSupport" runat="server" CssClass="form-control input-xxs" Width="250px" >
                    <asp:ListItem Text="-- Select Scope of Services --" Value="1" Selected="true" />

                </asp:DropDownList> 
            </div>
        </div>
    </div> 
    
    <div class="row">
        <div id="dvEIA" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">Company Name <font color="Red">*</font></label><br />
            </div>
            
            <div class="col-md-10"> 

                <asp:Table ID="tblApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Width="20%">
                                <asp:Label ID="lblRequestedBy" runat="server" class="control-label input-xxs">Selected Company A</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Width="60%">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control input-xxs" Width="320px" ><asp:ListItem Text="-- Select Company A --" Value="1" Selected="true" /></asp:DropDownList> 
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label12" runat="server" class="control-label input-xxs">Selected Company B</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control input-xxs" Width="320px" ><asp:ListItem Text="-- Select Company B --" Value="1" Selected="true" /></asp:DropDownList> 

                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label14" runat="server" class="control-label input-xxs">Selected Company C</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control input-xxs" Width="320px" ><asp:ListItem Text="-- Select Company C --" Value="1" Selected="true" /></asp:DropDownList> 
                                
                            </asp:TableCell>
                            </asp:TableRow>

                </asp:Table>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="External Support to be Evaluated" for="fldExtSupport">Is This Direct Appointment? <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList ID="fldTest" runat="server" CssClass="form-control input-xxs" Width="150px" ></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvBoardComment" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Comment" for="fldBoardComment">Comment</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldBoardComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Comment)" MaxLength="850"></asp:TextBox>          
            </div>
        </div>
    </div>
    
    <table><tr><td height="5"></td></tr></table>

    <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="A. Technical Evaluation Criteria" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <asp:Button ID="Button1" runat="server" Text="Upload Criteria" CssClass="btn btn-success btn-xs input-xxs" Width="105" Enabled="false"/> 
    &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Upload Submitted Quotation" CssClass="btn btn-info btn-xs input-xxs" Width="175" Enabled="false" />         
        
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="Div2" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">Technical Score <font color="Red">*</font></label><br />
            </div>
            
            <div class="col-md-10"> 

                <asp:Table ID="Table1" runat="server" Width="30%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Width="20%" Wrap="false">
                                <asp:Label ID="Label5" runat="server" class="control-label input-xxs">Company Name A</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Width="60%">
                                <asp:Label ID="Label8" runat="server" class="control-label input-xxs">Score A</asp:Label>
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Wrap="false">
                                <asp:Label ID="Label6" runat="server" class="control-label input-xxs">Company Name B</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label9" runat="server" class="control-label input-xxs">Score B</asp:Label>

                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Wrap="false">
                                <asp:Label ID="Label7" runat="server" class="control-label input-xxs">Company Name C</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label10" runat="server" class="control-label input-xxs">Score C</asp:Label>
                                
                            </asp:TableCell>
                            </asp:TableRow>

                </asp:Table>
            </div>
        </div>
    </div>

    
    <div class="row">
        <div id="dvCerts" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Report From Beacon" for="fldBeaconReport">Evaluation Committee <font color="Red">*</font></label></label>
            </div>
            
            <div class="col-md-10"> 
                <asp:Button ID="Upload" runat="server" Text="New Evaluation Committee" CssClass="btn btn-warning btn-xs input-xxs" Width="170" Enabled="false" />
                                
                <br />

            <asp:GridView ID="gvCerts" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
            <Columns>                
            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                   <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
                <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
            </asp:GridView>
                
            </div>            
        </div>
    </div>


    <table><tr><td height="5"></td></tr></table>

    <asp:Label ID="Label11" runat="server" class="control-label input-xxs" Text="B. Commercial Evaluation Criteria" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <asp:Button ID="Button3" runat="server" Text="Upload Criteria" CssClass="btn btn-success btn-xs input-xxs" Width="105" Enabled="false"/> 
    &nbsp;&nbsp;<asp:Button ID="Button4" runat="server" Text="Upload Submitted Quotation" CssClass="btn btn-info btn-xs input-xxs" Width="175" Enabled="false"/>         
        
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="Div3" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">Commercial Score <font color="Red">*</font></label><br />
            </div>
            
            <div class="col-md-10"> 

                <asp:Table ID="Table2" runat="server" Width="30%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Width="20%" Wrap="false">
                                <asp:Label ID="Label13" runat="server" class="control-label input-xxs">Company Name A</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Width="60%">
                                <asp:Label ID="Label15" runat="server" class="control-label input-xxs">Score A</asp:Label>
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Wrap="false">
                                <asp:Label ID="Label17" runat="server" class="control-label input-xxs">Company Name B</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label18" runat="server" class="control-label input-xxs">Score B</asp:Label>

                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Wrap="false">
                                <asp:Label ID="Label19" runat="server" class="control-label input-xxs">Company Name C</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label20" runat="server" class="control-label input-xxs">Score C</asp:Label>
                                
                            </asp:TableCell>
                            </asp:TableRow>

                </asp:Table>
            </div>
        </div>
    </div>

    
    <div class="row">
        <div id="Div4" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Report From Beacon" for="fldBeaconReport">Evaluation Committee <font color="Red">*</font></label></label>
            </div>
            
            <div class="col-md-10"> 
                <asp:Button ID="Button5" runat="server" Text="New Evaluation Committee" CssClass="btn btn-warning btn-xs input-xxs" Width="170" Enabled="false" />
                <br />

            <asp:GridView ID="GridView1" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
            <Columns>                
            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                   <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
                <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
            </asp:GridView>
                
            </div>            
        </div>
    </div>

    <div class="row">
        <div id="dvEvaluationComment" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Comment / Justification" for="fldEvaluationComment">Recommendation </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldEvaluationComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Evaluation Comment / Justification)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectValue" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Fee Before Negotiation</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectValue" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="cValidator" ControlToValidate="fldProjectValue" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div5" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Fee After Negotiation</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="Label25" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="fldProjectValue" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div6" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Final Fee Awarded</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="Label26" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToValidate="fldProjectValue" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the appointment details.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Pre-Submit</b> button to submit the appointment details. </asp:Label> 
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
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the final fee awarded. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to DAL (Discretionary Authority Limits) person for info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back to Listing</b> button to return to the listing.</asp:Label> 
            </div>
        </div>
    </div>


    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" Enabled="false" />         
        &nbsp;&nbsp;<asp:Button ID="btnPreSubmit" runat="server" Text="Pre-Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="85"  Enabled="false" OnClientClick = "return confirm('Are you sure you want to pre-submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" Enabled="false" OnClientClick = "return confirm('Are you sure you want to submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" /> 
    </div>




   </div>

</asp:Content>
    



