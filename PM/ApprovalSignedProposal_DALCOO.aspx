<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="ApprovalSignedProposal_DALCOO.aspx.cs" Inherits="ApprovalSignedProposal_DALCOO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

<div class="panel-heading">PROPOSAL EVALUATION / SUBMISSION</div>
<div class="panel-body">

     <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal Name" for="lblDescription">Proposal Name </label>
            </div>            
            <div class="col-md-4">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs">(Proposal Name)</asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="lblCode">Promotional Code </label>
            </div>            
            <div class="col-md-2">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs">(Promotional Code)</asp:Label>
            </div>
        </div>
    </div>

    <table><tr><td height="5"></td></tr></table>

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
                <asp:DropDownList ID="fldBoardRequired" runat="server" CssClass="form-control input-xxs" Width="150px" OnSelectedIndexChanged="fldBoardRequired_SelectedIndexChanged" AutoPostBack="true" Enabled="false"></asp:DropDownList>                     
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvBoardComment" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Comment" for="fldBoardComment">Comment</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldBoardComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Comment)" MaxLength="850" Enabled="false"></asp:TextBox>          
            </div>
        </div>
    </div>
        
    <div class="row">
        <div id="dvBoardPaper" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Board / Management Paper" for="fldBoardPaper">Board / Management Paper</label>
            </div>            
            <div class="col-md-6">                    
                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/BoardPaper/<%=lblFileNameBP.Text%>" target="_blank" title="Click here"><asp:Label ID="lblFileNameBP" runat="server" CssClass="input-xxs" Visible="false" Text="None"></asp:Label></a>
                <asp:Label ID="lblFileNameBP_Empty" runat="server" CssClass="input-xxs" Visible="false" Text="None"></asp:Label>
            </div>
        </div>        
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Final Proposal & Review" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
        
    <div class="row">
        <div id="dvClosingDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal Closing Date" for="fldClosingDate">Proposal Closing Date</label>
            </div>            
            <div class="col-md-3">                
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtClosingDate'>
                        <asp:TextBox ID="fldClosingDate" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
            </div>
        </div>     
        <div class="col-md-1">  </div>
        <div id="dvAwardDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Tentative Award Date" for="fldAwardDate">Tentative Award Date</label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtAwardDate'>
                        <asp:TextBox ID="fldAwardDate" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProposalForReview" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal For Review" for="fldProposalForReview">Proposal For Review</label>
            </div>            
            <div class="col-md-4">                
                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/Proposal/<%=lblFileNameP.Text%>" target="_blank" title="Click here"><asp:Label ID="lblFileNameP" runat="server" CssClass="input-xxs" Visible="false"></asp:Label></a>
                <asp:Label ID="lblFileNameP_Empty" runat="server" CssClass="input-xxs" Visible="false" Text="None"></asp:Label>
            </div>
        </div>    
        <div id="dvReviewedByDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Proposal To Be Reviewed By" for="fldReviewedByDate">Proposal To Be Reviewed <br />By</label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtReviewedByDate'>
                        <asp:TextBox ID="fldReviewedByDate" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvTechnicalRequired" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Technical Approval Required?" for="fldTechnicalRequired">Technical Approval Required?</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldTechnicalRequired" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList>                     
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvTechnicalJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldTechnicalJustification">Justification</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldTechnicalJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox>          
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvTechnicalApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Technical Approval">Technical Approval </label>
            </div>
            
            <div class="col-md-10"> 
                <asp:Label ID="lblTechnicalApp" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">N/A</asp:Label>

                <asp:Table ID="tblTechnicalApproval" runat="server" Width="80%" CssClass="table table-bordered input-xxs" Visible="false">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="4"><asp:Label ID="lblTechnicalApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Technical Approval</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblTechnicalReviewer" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Reviewer</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblTechnicalApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblTechnicalR1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalR2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalR3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalR4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldTechnicalReviewer" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblTechnical_ReviewedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblTechnical_ReviewedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblTechnical_ReviewedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblTechnicalA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblTechnicalA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldTechnicalApprover" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblTechnical_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblTechnical_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblTechnical_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

            </div>
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvCommercialRequired" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Commercial Approval Required?" for="fldCommercialRequired">Commercial Approval Required?</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldCommercialRequired" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList>                     
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvCommercialJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldCommercialJustification">Justification</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldCommercialJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox>          
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvCommercialApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Commercial Approval">Commercial Approval </label>
            </div>
            
            <div class="col-md-10"> 
                <asp:Label ID="lblCommercialApp" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">N/A</asp:Label>

                <asp:Table ID="tblCommercialApproval" runat="server" Width="80%" CssClass="table table-bordered input-xxs" Visible="false">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="4"><asp:Label ID="lblCommercialApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Commercial Approval</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblCommercialReviewer" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Reviewer</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblCommercialApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblCommercialR1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialR2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label>
                                <br /><asp:Label ID="lblCommercialR3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialR4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldCommercialReviewer" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblCommercial_ReviewedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblCommercial_ReviewedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblCommercial_ReviewedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblCommercialA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblCommercialA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldCommercialApprover" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblCommercial_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblCommercial_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblCommercial_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvLegalRequired" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Legal / Risk Approval Required?" for="fldLegalRequired">Legal / Risk Approval Required?</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldLegalRequired" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList>                     
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvLegalJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldLegalJustification">Justification</label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldLegalJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox>          
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvLegalApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Legal / Risk Approval">Legal / Risk Approval </label>
            </div>
            
            <div class="col-md-10"> 
                    <asp:Label ID="lblLegalApp" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">N/A</asp:Label>

                    <asp:Table ID="tblLegalApproval" runat="server" Width="80%" CssClass="table table-bordered input-xxs" Visible="false">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="4"><asp:Label ID="lblLegalApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Legal / Risk Approval</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblLegalReviewer" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Reviewer</b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblLegalApprover" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblLegalR1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalR2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalR3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalR4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldLegalReviewer" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblLegal_ReviewedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblLegal_ReviewedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblLegal_ReviewedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblLegalA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblLegalA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldLegalApprover" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>
                                <asp:Label ID="lblLegal_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblLegal_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblLegal_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

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
                <asp:Label ID="lblCreatedBy" runat="server" CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
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
                <asp:Label ID="lblCreatedDt" runat="server" CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
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

    <img src="Img/images2.png"/> <asp:Label ID="Label12" runat="server" class="control-label input-xxs" Text="DAL Approval Status" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Signed Proposal" for="fldBoardPaper">Signed Proposal</label>
            </div>            
            <div class="col-md-6">                    
                <a href="http://pectest.uemedgenta.com/PM/Upload/<%=Request.QueryString["ID"]%>/SignedProposal/<%=lblFileNameSP.Text%>" target="_blank" title="Click here"><asp:Label ID="lblFileNameSP" runat="server" CssClass="input-xxs" Visible="false" Text="None"></asp:Label></a>
                <asp:Label ID="lblFileNameSP_Empty" runat="server" CssClass="input-xxs" Visible="false" Text="None"></asp:Label>
            </div>
        </div>        
    </div>

    <div class="row">
        <div id="dvApprover" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Approver" for="lblApprover">Approver </label>
            </div>            
            <div class="col-md-3">                  
                <asp:Label ID="lblDALApprover" runat="server" CssClass="input-xxs" ></asp:Label>       
            </div>
        </div>
    </div>

   <div class="row">
        <div id="dvApprove" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Approved" for="lblDtApproved">Date Approved </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtApproved" runat="server" CssClass="control-label input-xxs" ForeColor="Blue"></asp:Label>   
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvReject" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Rejected" for="lblDtReject">Date Rejected </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtReject" runat="server" CssClass="control-label input-xxs" ForeColor="Red"></asp:Label>   
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldJustification">Justification </label>
            </div>            
            <div class="col-md-10">                
                <asp:TextBox ID="fldJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)"></asp:TextBox>
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to approve this signed proposal.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; When you have approved this signed proposal, email notification will be sent to Project Manager to submit the proposal.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1b" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; When you have rejected this signed proposal, email notification will be sent to Project Manager for info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Close Window</b> button to close this window.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success btn-xs input-xxs" Width="72" OnClientClick="return confirm('Are you sure you want to approve this signed proposal?');" OnClick="btnApprove_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnNotApprove" runat="server" Text="Reject" CssClass="btn btn-danger btn-xs input-xxs" Width="60" OnClientClick="return confirm('Are you sure you want to reject this signed proposal?');" OnClick="btnNotApprove_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" />                    
    </div>
    
</asp:Content>
    




