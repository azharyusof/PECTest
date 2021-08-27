<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AwardSubContractorDetail.aspx.cs" Inherits="AwardSubContractorDetail" %>

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
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">AWARD TO THIRD PARTY</div>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Code" for="lblCode">Project Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>
    
                <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PRE-QUALIFIED <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VENDOR LIST"></asp:Label></a></li>
                    
                    <li ID="tab2" runat="server"><a href='AwardSubContractorDetail1.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="PRE-Q <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; REGISTRATION"></asp:Label></a></li>
                    <li ID="tab3" runat="server"><a href='AwardSubContractorDetail2.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="RECOMMEND FOR <BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; APPOINTMENT"></asp:Label></a></li>
                    <li ID="tab4" runat="server"><a href='AwardSubContractorDetail3.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="AWARD"></asp:Label></a></li>
                    <li ID="tab5" runat="server"><a href='AwardSubContractorDetail4.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/notes_accept24.png" /> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="PERFORMANCE REVIEW"></asp:Label></a></li>
                    <li ID="tab6" runat="server"><a href='AwardSubContractorDetail5.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/pdpa24.png" /> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="VARIATION"></asp:Label></a></li>
                    <li ID="tab7" runat="server"><a href='AwardSubContractorDetail6.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="CLOSE / TERMINATE"></asp:Label></a></li>
                    
                </ul>
    
        
    
    <table><tr><td height="12"></td></tr></table>


    <asp:Table ID="tblSearch" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell Height="40" Wrap="false">
                        <div class="form-inline">
                            <asp:TextBox ID="fldSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Company Name / Scope of Services)"></asp:TextBox> 
                            &nbsp;<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" ImageAlign="Middle"/>                                
                            &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" ImageAlign="Middle" Visible="false"/>
                                                        
                        </div>
                    </asp:TableCell>
                    
                </asp:TableRow>    
            </asp:Table>

    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Pre-Qualified Vendor" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <asp:Table ID="tblApproval" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="lblRequested" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>No.</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label29" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Company Name</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label22" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Scope of Services</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="lblReviewed" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Address</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label5" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Contact Person</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label7" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Performance Review</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label63" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Pre-Q Validity Expiry</b></asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="lblRequestedBy" runat="server" class="control-label input-xxs">1.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label30" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label24" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White" Wrap="false">
                                <asp:Label ID="lblReviewedBy" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="lblRecommendedBy_GCPM" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="lblRecommendedBy_GBD" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="lblApprovedBy" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                        </asp:TableRow>
        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label8" runat="server" class="control-label input-xxs">2.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label9" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label10" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC" Wrap="false">
                                <asp:Label ID="Label11" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label12" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label13" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label14" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                        </asp:TableRow>
    </asp:Table>


    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="Label26" runat="server" class="control-label input-xxs" Text="Blacklisted Vendor" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <asp:Table ID="Table2" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label42" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>No.</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label43" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Company Name</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label44" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Scope of Services</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label45" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Address</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label46" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Contact Person</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label47" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Performance Review</b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle"><asp:Label ID="Label60" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Reason for Blacklisting</b></asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label48" runat="server" class="control-label input-xxs">1.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label49" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label50" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White" Wrap="false">
                                <asp:Label ID="Label51" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label52" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label53" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="White">
                                <asp:Label ID="Label61" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                        </asp:TableRow>
        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label54" runat="server" class="control-label input-xxs">2.</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label55" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label56" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC" Wrap="false">
                                <asp:Label ID="Label57" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label58" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label59" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#FFECEC">
                                <asp:Label ID="Label62" runat="server" class="control-label input-xxs">xxxx</asp:Label>
                                
                            </asp:TableCell>
                        </asp:TableRow>
    </asp:Table>



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
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back to Listing</b> button to return to the listing.</asp:Label> 
            </div>
        </div>
    </div>
    
    <hr />
    
    <div class="row" align="center">
       <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105"  /> 
            
    </div>

<!-------------------------------------------- End of active screen -------------------------------------------->


   </div>

</asp:Content>
    


