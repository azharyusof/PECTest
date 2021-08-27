<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectDbStatus.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectDbStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
   

<div class="panel-heading input">PROJECT DATABASE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

    

     <ul class="nav nav-tabs">                    
         <li ID="tab1" runat="server"><a href='ProjectDbInfo.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="PROJECT INFO."></asp:Label></a></li>                    
         <li ID="tab2" runat="server"><a href='ProjectDbDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT DETAILS"></asp:Label></a></li>                    
         <li ID="tab3" runat="server" class="active"><a href='#tab1primary'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label9" runat="server" class="control-label input-xxs" Text="PROJECT STATUS"></asp:Label></a></li>    
     </ul>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvEIA" runat="server">
                        
            <div class="col-md-12"> 

    <asp:GridView ID="gvGeneric" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="100%" OnRowDataBound="gvProjectListing_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Stage" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldDetailedScopeWork1" runat="server" CssClass="form-control input-xxs" Width="80px" TextMode="MultiLine" Height="160" Text='<%# Eval("Stage").ToString() != "" ? Eval("Stage").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Key Issue" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldDetailedScopeWork3" runat="server" CssClass="form-control input-xxs" Width="100px" TextMode="MultiLine" Height="160" Text='<%# Eval("KeyIssue").ToString() != "" ? Eval("KeyIssue").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Physical Progress" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <div class="form-inline">
                            <b>Plan:</b> <asp:TextBox ID="fldDetailedScopeWork3" runat="server" CssClass="form-control input-xxs" Width="40px" Text='<%# Eval("PHYSICAL_PLAN").ToString() != "" ? Eval("PHYSICAL_PLAN").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> <b>%</b><br />                                                                   
                            <b>Actual:</b> <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-xxs" Width="40px" TText='<%# Eval("PHYSICAL_ACTUAL").ToString() != "" ? Eval("PHYSICAL_ACTUAL").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> <b>%</b><br />
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-xxs" Width="100px" TextMode="MultiLine" Height="120" Text='<%# Eval("ISSUE_PHYSICAL").ToString() != "" ? Eval("ISSUE_PHYSICAL").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox>                                                                    
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Current Status" HeaderStyle-Width="65%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldDetailedScopeWork2" runat="server" CssClass="form-control input-xxs" Width="200px" TextMode="MultiLine" Height="160" Text='<%# Eval("Activity").ToString() != "" ? Eval("Activity").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> 
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Design Issue" HeaderStyle-Width="65%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldDetailedScopeWork2" runat="server" CssClass="form-control input-xxs" Width="100px" TextMode="MultiLine" Height="160" Text='<%# Eval("ISSUE_DESIGN").ToString() != "" ? Eval("ISSUE_DESIGN").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> 
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Contractual Issue" HeaderStyle-Width="65%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldDetailedScopeWork2" runat="server" CssClass="form-control input-xxs" Width="100px" TextMode="MultiLine" Height="160" Text='<%# Eval("ISSUE_CONTRACT").ToString() != "" ? Eval("ISSUE_CONTRACT").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> 
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="HR Issue" HeaderStyle-Width="65%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldDetailedScopeWork2" runat="server" CssClass="form-control input-xxs" Width="100px" TextMode="MultiLine" Height="160" Text='<%# Eval("ISSUE_HR").ToString() != "" ? Eval("ISSUE_HR").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> 
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action Plan" HeaderStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <asp:TextBox ID="fldActionPlan" runat="server" CssClass="form-control input-xxs" Width="100px" TextMode="MultiLine" Height="160" Text='<%# Eval("ActionPlan").ToString() != "" ? Eval("ActionPlan").ToString().ToUpper() : "-"%>' Enabled="false"></asp:TextBox> 
                    </ItemTemplate>
                </asp:TemplateField>   

                <asp:TemplateField HeaderText="Created Date" HeaderStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%" ItemStyle-Wrap="false">
                    <ItemTemplate>
                    <asp:Label ID="lblDateReceived" runat="server" Text='<%# Eval("PMLOGGEDDATE").ToString() != "" ? Eval("PMLOGGEDDATE", "{0:dd-MMM-yyyy}") : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>

    </div>
        </div>
            
    </div>
         

        
    

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click"/> 
           
    </div>
    
</asp:Content>
    


