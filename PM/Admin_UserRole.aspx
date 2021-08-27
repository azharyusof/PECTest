<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Admin_UserRole.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Admin_UserRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">

    <div class="panel-heading">Administration - User Role</div>
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

        <table>
            <tr>
                <td height="12"></td>
            </tr>
        </table>

        <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModal" data-toggle="modal" width="150">&nbsp;&nbsp;New User Role&nbsp;&nbsp;</button>
        <br /><br />

        <asp:GridView ID="gvUserRole" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="StaffNo" ShowHeaderWhenEmpty="True" Width="99%" OnRowEditing="EditUserRole" OnRowUpdating="UpdateUserRole" OnRowCancelingEdit="CancelUserRoleEdit" OnRowDataBound="gvUserRole_RowDataBound">
            <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true" />
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Staff No." ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffNo" runat="server" Text='<%# Eval("StaffNo").ToString() != "" ? Eval("StaffNo").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Staff Name" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("StaffName").ToString() != "" ? Eval("StaffName").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailId").ToString() != "" ? Eval("EmailId").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("EmailId")%>' CssClass="form-control input-xxs" Width="300px"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Secretary Name" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSecretary" runat="server" Text='<%# Eval("SecretaryName").ToString() != "" ? Eval("SecretaryName") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlSecretary" runat="server" CssClass="form-control input-xxs" Width="165px"></asp:DropDownList>

                        <asp:TextBox ID="ddlSecretaryCode" runat="server" Text='<%# Eval("SecretaryName")%>' CssClass="form-control input-xxs" Width="165px" Visible="false"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PA Name" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPA" runat="server" Text='<%# Eval("PANames").ToString() != "" ? Eval("PANames") : "-"%>' CssClass="input-xxs" Visible="true"></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlPA" runat="server" CssClass="form-control input-xxs" Width="165px"></asp:DropDownList>

                        <asp:TextBox ID="ddlPACode" runat="server" Text='<%# Eval("PANames")%>' CssClass="form-control input-xxs" Width="165px" Visible="false"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Role" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role").ToString() != "" ? Eval("Role").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:DropDownList ID="txtRole" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList>

                        <asp:TextBox ID="txtRoleCode" runat="server" Text='<%# Eval("Role")%>' CssClass="form-control input-xxs" Width="280px" Visible="false"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID" ) + "," + Eval("StaffNo") + "," + Eval("EmailId") + "," + Eval("Role") + "," + Eval("SecretaryName") + "," + Eval("PANames")%> ' OnClientClick="return confirm('Are you sure you want to remove this User Role?')" OnClick="DeleteRow" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" />
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update"></asp:ImageButton>
                        <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate></EmptyDataTemplate>
        </asp:GridView>

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="lbtnCloseX" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
                        <img src="Img/images2.png" />
                        <asp:Label ID="lblUserRole" runat="server" class="control-label input-xxs" Text="New User Role" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="modal-body">

                        <asp:Label ID="lblErrInput" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label>
                        <br />
                        <br />

                        <div class="row">
                            <div id="dvStaff" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Staff Name" for="fldStaff">Staff Name <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldStaff" runat="server" CssClass="form-control input-xxs" Width="300px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvRole" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Role" for="fldRole">Role <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldRole" runat="server" CssClass="form-control input-xxs" Width="180px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <br />

                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnClose_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            function funcOpen() {
                $('#myModal').modal('toggle');
                $('#myModal').modal('show');
            }

            function funcClose() {
                $('#myModal').modal('hide');
            }
        </script>

    </div>

</asp:Content>





