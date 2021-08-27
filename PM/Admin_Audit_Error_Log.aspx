<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Audit_Error_Log.aspx.cs" Inherits="PM_Admin_Audit_Error_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">
    <div class="panel-heading">Administration - Audit & Error Log</div>

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

        <div>
            <br />
        </div>

        <div class="container">
            <div id="content">
                <div id="Tabs" role="tabpanel">
                    <ul class="nav nav-tabs" role="tablist">
                        <li><a href="#Audit" aria-controls="Audit Log" data-toggle="tab" role="tab">Audit Log</a></li>
                        <li><a href="#Error" aria-controls="Error Log" data-toggle="tab" role="tab">Error Log</a></li>
                    </ul>

                    <div id="tab-content" class="tab-content">
                        <div role="tabpanel" class="tab-pane  active" id="Audit">
                            <br />
                            <div class="form-inline">
                                <asp:TextBox ID="fldAuditSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox>
                                &nbsp;<asp:ImageButton ID="btnAuditSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnAuditSearch_Click" ImageAlign="Middle" />
                                &nbsp;<asp:ImageButton ID="btnAuditClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnAuditClear_Click" ImageAlign="Middle" Visible="false" />
                            </div>

                            <br />
                            <asp:GridView ID="gvAuditLog" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="ID" ShowHeaderWhenEmpty="True" Width="90%"
                                EmptyDataText="No record found!">
                                <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true" />

                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Screen Name" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScreenName" runat="server" Text='<%# Eval("ScreenPath").ToString() != "" ? Eval("ScreenPath").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Audit Type" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScreenName" runat="server" Text='<%# Eval("Command").ToString() != "" ? Eval("Command").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="SP Name" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSPName" runat="server" Text='<%# Eval("SPName").ToString() != "" ? Eval("SPName").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Old Value" ItemStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOldValue" runat="server" Text='<%# Eval("OldValue").ToString() != "" ? Eval("OldValue").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="New Value" ItemStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNewValue" runat="server" Text='<%# Eval("NewValue").ToString() != "" ? Eval("NewValue").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modified By" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModifyBY" runat="server" Text='<%# Eval("StaffName").ToString() != "" ? Eval("StaffName").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modified Date" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModifyDT" runat="server" Text='<%# Eval("PerformDT").ToString() != "" ? Eval("PerformDT").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div role="tabpanel" class="tab-pane  active" id="Error">
                            <br />
                            <div class="form-inline">
                                <asp:TextBox ID="fldErrorSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox>
                                &nbsp;<asp:ImageButton ID="btnErrorSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnErrorSearch_Click" ImageAlign="Middle" />
                                &nbsp;<asp:ImageButton ID="btnErrorClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnErrorClear_Click" ImageAlign="Middle" Visible="false" />
                            </div>

                            <br />
                            <asp:GridView ID="gvErrorLog" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="ID" ShowHeaderWhenEmpty="True" Width="90%"
                                EmptyDataText="No record found!">
                                <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Screen Name" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScreenName" runat="server" Text='<%# Eval("pageName").ToString() != "" ? Eval("pageName").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Method" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMethod" runat="server" Text='<%# Eval("method").ToString() != "" ? Eval("method").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Line No." ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLineNo" runat="server" Text='<%# Eval("line_Number").ToString() != "" ? Eval("line_Number").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Error Message" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblErrorMsg" runat="server" Text='<%# Eval("errorMessage").ToString() != "" ? Eval("errorMessage").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Created By" ItemStyle-Width="45%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedBY" runat="server" Text='<%# Eval("StaffName").ToString() != "" ? Eval("StaffName").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Created Date" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDT" runat="server" Text='<%# Eval("createdDT").ToString() != "" ? Eval("createdDT").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="TabName" runat="server" />
        </div>

        <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Audit";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>
    </div>
</asp:Content>
