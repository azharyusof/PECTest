<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Admin_EDMS.aspx.cs" Inherits="Admin_EDMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">Administration - Project With EDMS</div>
<div class="panel-body">

    <div class="row">
        <div id="dvUser" runat="server">
            <div class="col-md-10">
                <asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label>
            </div>
        </div>
      
        <div id="dvCurrDt" runat="server">
            <div class="col-md-2; text-right">
                <asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label>&nbsp;&nbsp;
            </div>
        </div>
    </div>
        
    <table><tr><td height="12"></td></tr></table>

<!--Start Grid View-->
    <asp:GridView ID="gvEDMS" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" Width="100%">
            <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true"/>
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Project Name" ItemStyle-Width="40%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Regular Code" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblProjectCode" runat="server" Text='<%# Eval("ProjectCode").ToString() != "" ? Eval("ProjectCode").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EDMS Name" ItemStyle-Width="40%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblEDMSName" runat="server" Text='<%# Eval("EDMSDesc").ToString() != "" ? Eval("EDMSDesc").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EDMS Code <br>[1]" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:Label ID="lblEDMSCode" runat="server" Text='<%# Eval("EDMSCode").ToString() != "" ? Eval("EDMSCode").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EDMS Code <br>[2]" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:Label ID="lblEDMSCode1" runat="server" Text='<%# Eval("EDMSCode1").ToString() != "" ? Eval("EDMSCode1").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

                <EmptyDataTemplate>  </EmptyDataTemplate>

            </asp:GridView>
<!--End Grid View-->
        </div>



    
</asp:Content>
    



