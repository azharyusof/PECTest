<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectApprovalList.aspx.cs" Inherits="ProjectApprovalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">PENDING APPROVAL LIST</div>
<div class="panel-body">

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Height="20"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Height="20"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

                
    <table><tr><td height="12"></td></tr></table>

    <asp:Table ID="tblDALApproval" runat="server" Width="50%">
                <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Left">
                        <asp:Label ID="lbl1" runat="server" class="input-xxs"><b>PHASE :</b></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Wrap="false" HorizontalAlign="Left">
                        <asp:Label ID="lblPhaseName" runat="server" class="input-xxs"><b></b></asp:Label>
                    </asp:TableCell>             
                </asp:TableRow>
        <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Left">
                        <asp:Label ID="lbl2" runat="server" class="input-xxs"><b>DAL :</b></asp:Label><br />
                    </asp:TableCell>
                    <asp:TableCell Wrap="false" HorizontalAlign="Left">
                        <asp:Label ID="lblDAL" runat="server" class="input-xxs"><b></b></asp:Label><br />
                    </asp:TableCell>             
                </asp:TableRow>
        <asp:TableRow>
                    <asp:TableCell Wrap="false" HorizontalAlign="Left" ColumnSpan="2" Height="40">
                        <asp:Button ID="btnListing" runat="server" Text="Back to Summary" CssClass="btn btn-primary btn-xs input-xxs" Width="125" OnClick="btnListing_Click"/> 
                    </asp:TableCell>
                                
                </asp:TableRow>
    </asp:Table>
       
    
    <asp:GridView ID="gvProjectListing" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="100%" OnRowDataBound="gvProjectListing_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Operating Company" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("OperatingCompany").ToString() != "" ? Eval("OperatingCompany").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Opportunity / Project Name" HeaderStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35%" ItemStyle-Wrap="true">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlDescription" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label>                                                                    
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id").ToString() != "" ? Eval("Id") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label>   
                         
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category").ToString() != "" ? Eval("Category").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        
                    </ItemTemplate>
                </asp:TemplateField>
                                
                <asp:TemplateField HeaderText="Client Name" HeaderStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName").ToString() != "" ? Eval("ClientName").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Manager" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblPMName" runat="server" Text='<%# Eval("PMName").ToString() != "" ? Eval("PMName").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
               <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() != "" ? Eval("Status").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                        <asp:Label ID="lblPhase" runat="server" Text='<%# Eval("Phase").ToString() != "" ? Eval("Phase").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label>
                        <asp:Label ID="lblDecision" runat="server" Text='<%# Eval("Decision").ToString() != "" ? Eval("Decision").ToString().ToUpper() : ""%>' CssClass="input-xxs" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DAL Approval Status" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblAppStatus" runat="server" CssClass="input-xxs"></asp:Label>

                        <asp:GridView ID="gvApprovalStatus" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Eval("ApprovalStatus").ToString() != "" ? Eval("ApprovalStatus").ToString().ToUpper() : "PENDING"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>                            
                         </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>
    
</div>
    
</asp:Content>
    


