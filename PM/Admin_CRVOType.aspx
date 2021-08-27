<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Admin_CRVOType.aspx.cs" Inherits="PM_Admin_CRVOType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

<div class="panel-heading">Administration - Change Request / VO Type</div>

<div class="panel-body"> <!--Start Panel Body-->

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


    <!--Start here New CRVO button-->
 
    <button type="button" class="btn btn-warning btn-xs input-xxs"  data-toggle="modal" data-target="#myModal" onclick="javascript: return false;" width="150">&nbsp;&nbsp;New Change Request / VO Type&nbsp;&nbsp;</button> 

    <!--End here New CRVO button-->

    <!--Start here Modal Operating Company-->

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="Evaluation" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:LinkButton ID="lbtnCloseX" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcClose();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
                    <img src="Img/images2.png"/> <asp:Label ID="lblProject" runat="server" class="control-label input-xxs" Text="New Change Request / VO Type" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                </div>
                <div class="modal-body">

                    <asp:Label ID="lblErrInput" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label><br />
                   <br />
                    <div class="row">
                        <div id="dvChangeRequestVariationOrder" runat="server"> 
                            <div class="col-md-3">
                                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Change Request / VO Type" for="fldChangeRequestVariationOrder">Change Request / VO Type <font color="Red">*</font></label>
                            </div>            
                            <div class="col-md-4">  
                                 <asp:TextBox ID="fldChangeRequestVariationOrder" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Change Request / VO Type)" MaxLength="850"></asp:TextBox> 
                            </div>
                        </div> 
                    </div>
                     <br />
  
                </div>
                <div class="modal-footer">

                <div class="row">
                    <div class="pull-left">
                   
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSave_Click" />
                  
                        <asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnClose_Click" UseSubmitBehavior="false" />
             
                    </div>
                 </div>     
                </div>
                </div>
            </div>
        </div

    <!--End here Modal Change Request Variation Order-->

    <!--Start Grid View-->

    <asp:GridView ID="gvCRVO" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="50%" onrowediting="EditChangeRequestVariationOrder" onrowupdating="UpdateChangeRequestVariationOrder"  onrowcancelingedit="CancelEdit">
            <HeaderStyle BackColor="#808080" ForeColor="White" Font-Bold="true"/>
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-sm" Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Change Request / VO Type" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblChangeRequestVariationOrder" runat="server" Text='<%# Eval("ChangeRequestVOType").ToString() != "" ? Eval("ChangeRequestVOType").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>                    
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:TextBox ID="fldChangeRequestVariationOrder" runat="server" Text='<%# Eval("ChangeRequestVOType")%>' Width="250" CssClass="form-control input-xxs"></asp:TextBox>
                    </EditItemTemplate> 

                    <FooterTemplate>   
                        <asp:TextBox ID="fldChangeRequestVariationOrder" runat="server" Width="250" CssClass="form-control input-xxs"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                                
                <asp:TemplateField ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" runat="server" CommandName ="Delete" CommandArgument = '<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this Change Request / VO Type?')"  OnClick = "DeleteRow"></asp:ImageButton> <!--CHECKN IMMED-->
                    </ItemTemplate>
                </asp:TemplateField>
            
                   
                <asp:TemplateField ItemStyle-CssClass="table" ItemStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
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

    <!--End Grid View-->



</div> <!--End Panel Body-->


     <script type="text/javascript">
        function funcOpen() {
            $('#myModal').modal('toggle');
            $('#myModal').modal('show');
        }

        function funcClose() {
            $('#myModal').modal('hide');
        }
    </script>


</asp:Content>

