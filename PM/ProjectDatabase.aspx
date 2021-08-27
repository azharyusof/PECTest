<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectDatabase.aspx.cs" Inherits="ProjectDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">PROJECT DATABASE</div>
<div class="panel-body">

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Height="20"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Height="20"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

             <asp:Table ID="tblSearch" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell Height="40" Wrap="false">
                        <div class="form-inline">
                            <asp:TextBox ID="fldSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox> 
                            &nbsp;<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnSearch_Click" ImageAlign="Middle"/>                                
                            &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnClear_Click" ImageAlign="Middle" Visible="false"/>
                            
                            
                            <asp:Label ID="lblPM" runat="server" CssClass="input-xxs" Visible="false"></asp:Label>  
                            <asp:Label ID="lblAdmin" runat="server" CssClass="input-xxs" Visible="false" Text="50424"></asp:Label>  
                            <asp:Label ID="lblAdmin1" runat="server" CssClass="input-xxs" Visible="false" Text="22639"></asp:Label>  
                            <asp:Label ID="lblAdmin2" runat="server" CssClass="input-xxs" Visible="false" Text="22096"></asp:Label>
                            <asp:Label ID="lblAdmin3" runat="server" CssClass="input-xxs" Visible="false" Text="UEB1008"></asp:Label>
                            
                        </div>
                    </asp:TableCell>
                    
                </asp:TableRow>    
            </asp:Table>
    
    <table><tr><td height="12"></td></tr></table>

    <asp:GridView ID="gvProjectListing" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="100%" OnRowDataBound="gvProjectListing_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Operating Company" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("Company").ToString() != "" ? Eval("Company").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Year" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year").ToString() != "" ? Eval("Year").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Project Name" HeaderStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35%">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlDescription" runat="server" Text='<%# Eval("Package_Ref_BDU").ToString() != "" ? Eval("Package_Ref_BDU").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Package_Ref_BDU").ToString() != "" ? Eval("Package_Ref_BDU").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id").ToString() != "" ? Eval("Id") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label>   
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Code" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectCode" runat="server" Text='<%# Eval("Fin_Code").ToString() != "" ? Eval("Fin_Code").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
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
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Type" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectType" runat="server" Text='<%# Eval("ProjectType").ToString() != "" ? Eval("ProjectType").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>    
                
                <asp:TemplateField HeaderText="Migrate to PEC?" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectDbMigrateStatus" runat="server" Text='<%# Eval("ProjectType").ToString() == "REGULAR" ? Eval("ProjectDbMigrateStatus") : "N/A"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>
    
</div>
    
</asp:Content>
    


