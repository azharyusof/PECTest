<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Admin_PIC_Opportunity.aspx.cs" Inherits="Admin_PIC_Opportunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">
    <div class="panel-heading">Administration - Project Manager / Project Director / PIC</div>

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
                        <li><a href="#Opportunity" aria-controls="Opportunity" data-toggle="tab" role="tab">Opportunity</a></li>
                        <li><a href="#Project" aria-controls="Project" data-toggle="tab" role="tab">Project</a></li>
                    </ul>

                    <div id="tab-content" class="tab-content">
                        <div role="tabpanel" class="tab-pane  active" id="Opportunity">
                            <asp:GridView ID="gvPICOpportunity" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="80%"
                                OnRowDataBound="gvPICOpportunity_RowDataBound" OnRowEditing="EditPICOpportunity" OnRowCancelingEdit="CancelPICOpportunityEdit" OnRowUpdating="UpdatePICOpportunity" EmptyDataText="No record found!">
                                <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true" />

                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Opportunity Name" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOppName" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Opportunity Code" ItemStyle-Width="3%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOppCode" runat="server" Text='<%# Eval("Code").ToString() != "" ? Eval("Code") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                            <asp:Label ID="lblCodeOpp" runat="server" CssClass="input-xxs"></asp:Label>
                                            <asp:Label ID="lblDeltekOppCode" runat="server" Text='<%# Eval("OldCode").ToString() != "" ? "("+Eval("OldCode").ToString().ToUpper()+")": ""%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Project Manager" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("PMName").ToString() != "" ? Eval("PMName") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlProjectManager" runat="server" CssClass="form-control input-xxs" Width="165px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlProjectManagerCode" runat="server" Text='<%# Eval("PMName")%>' CssClass="form-control input-xxs" Width="165px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Person In Charge [1]" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOpportunityPIC1" runat="server" Text='<%# Eval("PIC1Name").ToString() != "" ? Eval("PIC1Name") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlOpportunityPIC1" runat="server" CssClass="form-control input-xxs" Width="165px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlOpportunityPIC1Code" runat="server" Text='<%# Eval("PIC1Name")%>' CssClass="form-control input-xxs" Width="165px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Person In Charge [2]" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOpportunityPIC2" runat="server" Text='<%# Eval("PIC2Name").ToString() != "" ? Eval("PIC2Name") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlOpportunityPIC2" runat="server" CssClass="form-control input-xxs" Width="165px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlOpportunityPIC2Code" runat="server" Text='<%# Eval("PIC2Name")%>' CssClass="form-control input-xxs" Width="165px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" ToolTip="Edit" />
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update"></asp:ImageButton>
                                            <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataTemplate />
                            </asp:GridView>
                        </div>

                        <div role="tabpanel" class="tab-pane  active" id="Project">
                            <asp:GridView ID="gvPICProject" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="97%"
                                OnRowDataBound="gvPICProject_RowDataBound" OnRowEditing="EditPICProject" OnRowCancelingEdit="CancelPICProjectEdit" OnRowUpdating="UpdatePICProject" EmptyDataText="No record found!">
                                <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true" />

                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Project Name" ItemStyle-Width="40%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProName" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Project Code" ItemStyle-Width="3%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProCode" runat="server" Text='<%# Eval("Code").ToString() != "" ? Eval("Code") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                            <asp:Label ID="lblCodePro" runat="server" CssClass="input-xs"></asp:Label>
                                            <asp:Label ID="lblDeltekProCode" runat="server" Text='<%# Eval("OldCode").ToString() != "" ? "("+Eval("OldCode").ToString().ToUpper()+")": ""%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Project Manager" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProProjectManager" runat="server" Text='<%# Eval("PMName").ToString() != "" ? Eval("PMName") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlProProjectManager" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlProProjectManagerCode" runat="server" Text='<%# Eval("PMName")%>' CssClass="form-control input-xxs" Width="150px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Project Director" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProProjectDirector" runat="server" Text='<%# Eval("PDName").ToString() != "" ? Eval("PDName") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlProProjectDirector" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlProProjectDirectorCode" runat="server" Text='<%# Eval("PDName")%>' CssClass="form-control input-xxs" Width="150px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Person In Charge [1]" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectPIC1" runat="server" Text='<%# Eval("PIC1Name").ToString() != "" ? Eval("PIC1Name") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlProjectPIC1" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlProjectPIC1Code" runat="server" Text='<%# Eval("PIC1Name")%>' CssClass="form-control input-xxs" Width="150px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Person In Charge [2]" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectPIC2" runat="server" Text='<%# Eval("PIC2Name").ToString() != "" ? Eval("PIC2Name") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlProjectPIC2" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>

                                            <asp:TextBox ID="ddlProjectPIC2Code" runat="server" Text='<%# Eval("PIC2Name")%>' CssClass="form-control input-xxs" Width="150px" Visible="false"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-Width="10%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" ToolTip="Edit" />
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update"></asp:ImageButton>
                                            <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataTemplate />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="TabName" runat="server" />
        </div>

        <script type="text/javascript">
            $(function () {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Opportunity";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });
        </script>
    </div>
</asp:Content>
