<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">REPORT</div>
<div class="panel-body">

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Height="20"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Height="20"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>
                
    <table><tr><td height="5"></td></tr></table>

    <ul class="nav nav-tabs">

        <% if (Request.QueryString["Mode"] == "O") { %>
                    <li><a href='Report.aspx'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOp1" runat="server" class="control-label input-xxs" Text="PROJECT"></asp:Label></a></li>
                    <li class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblPr1" runat="server" class="control-label input-xxs" Text="OPPORTUNITY"></asp:Label></a></li>
        <% } else { %>            
                    <li class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOp2" runat="server" class="control-label input-xxs" Text="PROJECT"></asp:Label></a></li>
                    <li><a href='Report.aspx?Mode=O'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblPr2" runat="server" class="control-label input-xxs" Text="OPPORTUNITY"></asp:Label></a></li>
        <% } %>             
                </ul>


    <table><tr><td height="12"></td></tr></table>

    <asp:Table ID="Table2" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left" Height="35">
                    <asp:Button ID="btnExcel" runat="server" Text="Download Excel File"  OnClick="btnExcel_Click" CssClass="btn btn-warning btn-xs input-xxs" Width="135" />
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
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("OperatingCompany").ToString() != "" ? Eval("OperatingCompany").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Opportunity / Project Name" HeaderStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35%">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category").ToString() != "" ? Eval("Category").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Code" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblFinanceCode" runat="server" Text='<%# Eval("FinanceCode").ToString() != "" ? Eval("FinanceCode").ToString().ToUpper(): "-"%>' CssClass="input-xxs"></asp:Label>                                                                                          
                   </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Client Name" HeaderStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName").ToString() != "" ? Eval("ClientName").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Manager" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblPMName" runat="server" Text='<%# Eval("PMName").ToString() != "" ? Eval("PMName").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() != "" ? Eval("Status").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phase" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblPhase" runat="server" Text='<%# Eval("Phase").ToString() != "" ? Eval("Phase").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Decision" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:Label ID="lblDecision" runat="server" Text='<%# Eval("Decision").ToString() != "" ? Eval("Decision").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 

            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>
    
</div>
    
</asp:Content>
    


