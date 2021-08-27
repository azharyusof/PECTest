<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectApproval.aspx.cs" Inherits="ProjectApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">PENDING APPROVAL SUMMARY</div>
<div class="panel-body">

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Height="20"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Height="20"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

    
    <table><tr><td height="12"></td></tr></table>

   
             <asp:Table ID="tblDALApproval" runat="server" Width="70%" CssClass="table table-bordered input-xxs">

                            <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="30%">
                                    <asp:Label ID="lblPhaseName" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Phase</b></asp:Label></asp:TableCell>

                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="40%">
                                    <asp:Label ID="lblDAL" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL</b></asp:Label></asp:TableCell>
                                
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="20%">
                                    <asp:Label ID="lblPending" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Total Pending</b></asp:Label></asp:TableCell>

                                 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></asp:TableCell>
                            </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblPhaseOppGoNoGo1" runat="server" class="input-xxs"><b>OPPORTUNITY GO / NO-GO</b></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblDALOppGoNoGo1" runat="server" class="input-xxs"><b>DAL 3.2</b> <br /><i>[Submission of Tender Bids / Proposals / Quotations]</i></asp:Label>
                    </asp:TableCell>
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblTotalOppGoNoGo1" runat="server" class="control-label input-xxs" Font-Bold="true"></asp:Label>
                    </asp:TableCell>   
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                       <asp:Button ID="btnApprove3_2" runat="server" Text="Click Here" CssClass="btn btn-warning btn-xs input-xxs" Width="90" OnClick="btnApprove3_2_Click"/> 
                    </asp:TableCell>  
                </asp:TableRow>

                 <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblPhaseOppGoNoGo2" runat="server" class="input-xxs"><b>OPPORTUNITY GO / NO-GO</b></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblDALOppGoNoGo2" runat="server" class="input-xxs"><b>DAL 3.3</b> <br /><i>[Cost of Preparing Proposal / Tender]</i></asp:Label>
                    </asp:TableCell>
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblTotalOppGoNoGo2" runat="server" class="control-label input-xxs" Font-Bold="true"></asp:Label>
                    </asp:TableCell>      
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                       <asp:Button ID="btnApprove3_3" runat="server" Text="Click Here" CssClass="btn btn-danger btn-xs input-xxs" Width="90" OnClick="btnApprove3_3_Click"/> 
                    </asp:TableCell>  
                </asp:TableRow>
                 
                 <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblPhaseEvaluate" runat="server" class="input-xxs"><b>PROPOSAL EVALUATION / SUBMISSION</b></asp:Label>
                    </asp:TableCell>
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblDALEvaluate" runat="server" class="input-xxs"><b>DAL 3.2</b> <br /><i>[Submission of Tender Bids / Proposals / Quotations]</i></asp:Label>
                    </asp:TableCell>                     
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblTotEvaluate" runat="server" class="control-label input-xxs" Font-Bold="true"></asp:Label>
                    </asp:TableCell>   
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                       <asp:Button ID="btnApprove3_2a" runat="server" Text="Click Here" CssClass="btn btn-success btn-xs input-xxs" Width="90" OnClick="btnApprove3_2a_Click"/> 
                    </asp:TableCell>  
                </asp:TableRow>  
                 
                 <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblPhaseRegProject" runat="server" class="input-xxs"><b>REGISTER NEW PROJECT</b></asp:Label>
                    </asp:TableCell>
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblDALRegProject" runat="server" class="input-xxs"><b>DAL 3.4</b> <br /><i>[Acceptance of Award Contract]</i></asp:Label>
                    </asp:TableCell>                     
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                        <asp:Label ID="lblTotRegProject" runat="server" class="control-label input-xxs" Font-Bold="true"></asp:Label>
                    </asp:TableCell>   
                     <asp:TableCell Wrap="false" HorizontalAlign="Center">
                       <asp:Button ID="btnApprove3_4" runat="server" Text="Click Here" CssClass="btn btn-primary btn-xs input-xxs" Width="90" OnClick="btnApprove3_4_Click"/> 
                    </asp:TableCell>  
                </asp:TableRow>    

            </asp:Table>
    
</div>
    
</asp:Content>
    


