<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableRiskImpactF.aspx.cs" Inherits="TableRiskImpactF" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Impact Table (Financial)</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <a href="TableHeatMap.aspx"><asp:Label ID="lbl1" runat="server" CssClass="input-xxs"><b>Risk Heat Map</b></asp:Label></a> | <a href="TableLikelihood.aspx"><asp:Label ID="lbl2" runat="server" CssClass="input-xxs"><b>Likelihood Table</b></asp:Label></a> | <asp:Label ID="lbl3" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Financial)</b></asp:Label> | <a href="TableRiskImpactNF.aspx"><asp:Label ID="lbl4" runat="server" CssClass="input-xxs"><b>Risk Impact Table (Non-Financial)</b></asp:Label></a>
        <br /><br />
        <div>

                   

            <asp:GridView ID="gvProjectListing" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gvRiskAssessment_RowCreated" OnRowDataBound="gvRiskAssessment_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Factor" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblFactor" runat="server" Text='<%# Eval("Factor").ToString() != "" ? Eval("Factor").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Insignificant" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Insignificant" runat="server" Text='<%# Eval("Impact_Insignificant").ToString() != "" ? Eval("Impact_Insignificant").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Minor" HeaderStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Minor" runat="server" Text='<%# Eval("Impact_Minor").ToString() != "" ? Eval("Impact_Minor").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Moderate" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Moderate" runat="server" Text='<%# Eval("Impact_Moderate").ToString() != "" ? Eval("Impact_Moderate").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Major" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Major" runat="server" Text='<%# Eval("Impact_Major").ToString() != "" ? Eval("Impact_Major").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Catastrophic" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblImpact_Catastrophic" runat="server" Text='<%# Eval("Impact_Catastrophic").ToString() != "" ? Eval("Impact_Catastrophic").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>

          

        <asp:Label ID="Label15" runat="server" CssClass="input-xxs" />
        <br />
        <asp:Label ID="Label16" runat="server" CssClass="input-xxs"><u>Note:</u><br />&nbsp;PATANCI - Profit after tax and non-controlling interest <br />&nbsp;EBITDA - Earnings before interest, depreciation and amortisation  <br />&nbsp;AOP - Annual Operating Plan<br /></asp:Label>
        </div>
    </form>
</body>
</html>

