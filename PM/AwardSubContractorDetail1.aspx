<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail1.aspx.cs" Inherits="AwardSubContractorDetail1" %>

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
                    
                    <li ID="tab2" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="PRE-Q <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; REGISTRATION"></asp:Label></a></li>
                    <li ID="tab3" runat="server"><a href='AwardSubContractorDetail2.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="RECOMMEND FOR <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; APPOINTMENT"></asp:Label></a></li>
                    <li ID="tab4" runat="server"><a href='AwardSubContractorDetail3.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="AWARD"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='AwardSubContractorDetail4.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/notes_accept24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PERFORMANCE REVIEW"></asp:Label></a></li>
                    <li ID="tab6" runat="server"><a href='AwardSubContractorDetail5.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server"><a href='AwardSubContractorDetail6.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    
    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Pre-Q Registration" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvClientName" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Company Name <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                 <asp:TextBox ID="fldNewClientName" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Company Name)"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvClientAdd" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Scope of Services <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldClientAdd" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Scope of Services)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div2" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Address <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Address)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="Div5" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Contact Person <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                 <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Company Name)"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Email Address <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Contact Person)"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="Div3" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Contact No. <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control input-xxs" Width="130px" PlaceHolder="(Contact No.)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div4" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Remarks </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Remarks)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvEIA" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EIA Report" for="fldEIA">Pre-Q Forms <font color="Red">*</font></label><br />
            </div>
            
            <div class="col-md-10"> 

                <asp:Table ID="tblApproval" runat="server" Width="70%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lblRequestedBy" runat="server" class="control-label input-xxs">FORM A</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label30" runat="server" class="control-label input-xxs">LETTER OF APPLICATION</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Upload" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label5" runat="server" class="control-label input-xxs">FORM B</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label6" runat="server" class="control-label input-xxs">COMPANY PARTICULARS</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button1" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label7" runat="server" class="control-label input-xxs">FORM C</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5">
                                <asp:Label ID="Label8" runat="server" class="control-label input-xxs">EXPERIENCE IN SIMILAR PROJECTS IN THE LAST 5 YEARS</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button2" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label9" runat="server" class="control-label input-xxs">FORM D</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label10" runat="server" class="control-label input-xxs">CONSULTANT EXPERIENCE OF SIMILAR PROJECTS (VERIFICATION BY THE CLIENT)</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button3" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label11" runat="server" class="control-label input-xxs">FORM E</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label12" runat="server" class="control-label input-xxs">TECHNICAL APPROACH AND METHODOLOGY</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button4" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label13" runat="server" class="control-label input-xxs">FORM F</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label14" runat="server" class="control-label input-xxs">WORK PLAN</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button5" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label15" runat="server" class="control-label input-xxs">FORM G</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label16" runat="server" class="control-label input-xxs">CERTIFICATION BY ACCREDITATION BODY</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button6" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label17" runat="server" class="control-label input-xxs">FORM H</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label18" runat="server" class="control-label input-xxs">OWNERSHIP OF RELEVANT SOFTWARE</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button7" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label19" runat="server" class="control-label input-xxs">FORM I</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label20" runat="server" class="control-label input-xxs">ORGANISATION AND STAFFING</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button8" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label21" runat="server" class="control-label input-xxs">FORM J</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label22" runat="server" class="control-label input-xxs">PROJECT TEAM AND CV OF PERSONNEL</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button9" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label23" runat="server" class="control-label input-xxs">FORM K</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label24" runat="server" class="control-label input-xxs">AVERAGE TURNOVER IN LAST 3 YEARS</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button10" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>


                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label25" runat="server" class="control-label input-xxs">FORM L</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label26" runat="server" class="control-label input-xxs">PROFITABILITY IN LAST 3 YEARS</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button11" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
                            </asp:TableCell>
                            </asp:TableRow>

                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White" Wrap="false">
                                <asp:Label ID="Label27" runat="server" class="control-label input-xxs">ADDITIONAL</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#E5E5E5" Wrap="false">
                                <asp:Label ID="Label28" runat="server" class="control-label input-xxs">PRE-Q CRITERIA</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Button ID="Button12" runat="server" Text="Upload" CssClass="btn btn-warning btn-xs input-xxs" Width="55" Enabled="false" />
                                
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the pre-q registration info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the pre-q registration info. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="Label29" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; The pre-q registration info will be updated in the <b>Pre-Qualified Vendor List</b>.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Email Pre-Q Forms</b> button to email the empty Pre-Q forms in zip format to vendor.</asp:Label> 
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
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" Enabled="false" /> 
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" Enabled="false" OnClientClick = "return confirm('Are you sure you want to submit this page?')" />         
        &nbsp;&nbsp;<asp:Button ID="btnReview" runat="server" Text="Email Pre-Q Forms" CssClass="btn btn-warning btn-xs input-xxs" Width="126" Enabled="false"/>     
        
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" /> 
           
    </div>





   </div>

</asp:Content>
    


