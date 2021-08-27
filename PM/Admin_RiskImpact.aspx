<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Admin_RiskImpact.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Admin_RiskImpact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">Administration - Risk Impact</div>
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
        
    
    <asp:GridView ID="gvRiskImpact" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="100%" onrowediting="EditRiskImpact" onrowupdating="UpdateRiskImpact" onrowcancelingedit="CancelRiskImpactEdit">
            <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true"/>
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                         <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                               
                <asp:TemplateField HeaderText="Factor" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblFactor" runat="server" Text='<%# Eval("Factor").ToString() != "" ? Eval("Factor").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtFactor" runat="server" Text='<%# Eval("Factor")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Insignificant" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Insignificant" runat="server" Text='<%# Eval("Impact_Insignificant").ToString() != "" ? Eval("Impact_Insignificant").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtImpact_Insignificant" runat="server" Text='<%# Eval("Impact_Insignificant")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Minor" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Minor" runat="server" Text='<%# Eval("Impact_Minor").ToString() != "" ? Eval("Impact_Minor").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtImpact_Minor" runat="server" Text='<%# Eval("Impact_Minor")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Moderate" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Moderate" runat="server" Text='<%# Eval("Impact_Moderate").ToString() != "" ? Eval("Impact_Moderate").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtImpact_Moderate" runat="server" Text='<%# Eval("Impact_Moderate")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Major" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Major" runat="server" Text='<%# Eval("Impact_Major").ToString() != "" ? Eval("Impact_Major").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtImpact_Major" runat="server" Text='<%# Eval("Impact_Major")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Catastrophic" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Catastrophic" runat="server" Text='<%# Eval("Impact_Catastrophic").ToString() != "" ? Eval("Impact_Catastrophic").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtImpact_Catastrophic" runat="server" Text='<%# Eval("Impact_Catastrophic")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>
                	                	                                                     
                <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>            
                        <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" />
                    </ItemTemplate>

                    <EditItemTemplate>   
                        <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update" ></asp:ImageButton>  
                        <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>  
                    </EditItemTemplate> 
                </asp:TemplateField>
            </Columns>
                <EmptyDataTemplate>  </EmptyDataTemplate>
            </asp:GridView>
    
    
</div>
    
</asp:Content>
    




