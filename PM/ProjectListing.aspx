<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectListing.aspx.cs" Inherits="ProjectListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<div class="panel-heading">OPPORTUNITY / PROJECT LISTING</div>
<div class="panel-body">

            <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Height="20"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Height="20"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

             <asp:Table ID="tblSearch" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell Height="20" Wrap="false">
                        <div class="form-inline">
                            
                            &nbsp;<asp:Button ID="btnOpportunity" runat="server" Text="New Opportunity"  OnClick="btnOpportunity_Click" CssClass="btn btn-danger btn-xs input-xxs" Width="115" />
                            &nbsp;<asp:Button ID="btnProject" runat="server" Text="New Project"  OnClick="btnProject_Click" CssClass="btn btn-danger btn-xs input-xxs" Width="95" />

                        </div>
                    </asp:TableCell>
                    
                </asp:TableRow>    
            </asp:Table>
    
                            <asp:Label ID="lblPM" runat="server" CssClass="input-xxs" Visible="false"></asp:Label>  
                            <asp:Label ID="lblAdmin" runat="server" CssClass="input-xxs" Visible="false" Text="50424"></asp:Label>  
                            <asp:Label ID="lblAdmin1" runat="server" CssClass="input-xxs" Visible="false" Text="UEB878"></asp:Label>
                            <asp:Label ID="lblAdmin2" runat="server" CssClass="input-xxs" Visible="false" Text="22096"></asp:Label>
                            <asp:Label ID="lblAdmin3" runat="server" CssClass="input-xxs" Visible="false" Text="22639"></asp:Label>
                            <asp:Label ID="lblAdmin4" runat="server" CssClass="input-xxs" Visible="false" Text="22655"></asp:Label>
                            <asp:Label ID="lblAdmin5" runat="server" CssClass="input-xxs" Visible="false" Text="UEB850"></asp:Label>
                            <asp:Label ID="lblAdmin6" runat="server" CssClass="input-xxs" Visible="false" Text="22603"></asp:Label>
                            <asp:Label ID="lblAdmin7" runat="server" CssClass="input-xxs" Visible="false" Text="22523"></asp:Label>
                            <asp:Label ID="lblBD" runat="server" CssClass="input-xxs" Visible="false" Text="UEB839"></asp:Label>   
                            <asp:Label ID="lblBD1" runat="server" CssClass="input-xxs" Visible="false" Text="UEB608"></asp:Label>
                            <asp:Label ID="lblBD2" runat="server" CssClass="input-xxs" Visible="false" Text="UEB1052"></asp:Label>
                            <asp:Label ID="lblRole" runat="server" CssClass="input-xxs" Visible="false"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <ul class="nav nav-tabs">

        <% if (Request.QueryString["Mode"] == "O") { %>
                    <li><a href='ProjectListing.aspx'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOp1" runat="server" class="control-label input-xxs" Text="PROJECT"></asp:Label></a></li>
                    <li class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblPr1" runat="server" class="control-label input-xxs" Text="OPPORTUNITY"></asp:Label></a></li>
        <% } else { %>            
                    <li class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOp2" runat="server" class="control-label input-xxs" Text="PROJECT"></asp:Label></a></li>
                    <li><a href='ProjectListing.aspx?Mode=O'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblPr2" runat="server" class="control-label input-xxs" Text="OPPORTUNITY"></asp:Label></a></li>
        <% } %>             
                </ul>


    <table><tr><td height="12"></td></tr></table>

    <table runat="server" width="100%">
                    <tr>   
                    <td align="left">
                        <div class="form-inline">
                            <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true">Filter By &nbsp;</label> <asp:DropDownList ID="fldStatus" runat="server" CssClass="form-control input-xxs" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="fldStatus_SelectedIndexChanged"></asp:DropDownList> 
                        </div>
                    </td>
                    <td align="right">
                        <div class="form-inline">
                            <asp:TextBox ID="fldSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox> 
                            &nbsp;<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnSearch_Click" ImageAlign="Middle"/>                                
                            &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnClear_Click" ImageAlign="Middle" Visible="false"/>
                            
                        </div>
                    </td>
                    </tr>
                </table>


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
                
                <asp:TemplateField HeaderText="Opportunity / Project Name" HeaderStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="35%">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlDescription" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:HyperLink ID="hlDescriptionRO" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:HyperLink ID="hlDescriptionHSE" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:HyperLink ID="hlDescriptionAuditor" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:HyperLink ID="hlDescriptionPC" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id").ToString() != "" ? Eval("Id") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label>   
                        <asp:Label ID="lblProjectManager" runat="server" Text='<%# Eval("ProjectManager").ToString() != "" ? Eval("ProjectManager") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Eval("CreatedBy").ToString() != "" ? Eval("CreatedBy") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblProjectPIC1" runat="server" Text='<%# Eval("ProjectPIC1").ToString() != "" ? Eval("ProjectPIC1") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblProjectPIC2" runat="server" Text='<%# Eval("ProjectPIC2").ToString() != "" ? Eval("ProjectPIC2") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblOpportunityPIC1" runat="server" Text='<%# Eval("OpportunityPIC1").ToString() != "" ? Eval("OpportunityPIC1") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblOpportunityPIC2" runat="server" Text='<%# Eval("OpportunityPIC2").ToString() != "" ? Eval("OpportunityPIC2") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblMigration" runat="server" Text='<%# Eval("ProjectDbMigrateStatus").ToString() != "" ? Eval("ProjectDbMigrateStatus") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 
                        <asp:Label ID="lblSubmitStatus" runat="server" Text='<%# Eval("BtnSubmit").ToString() != "" ? Eval("BtnSubmit") : "-"%>' CssClass="input-xxs" Visible="false"></asp:Label> 

                        <asp:HyperLink ID="hlDescriptionProjectDB" runat="server" Text='<%# Eval("Description").ToString() != "" ? Eval("Description").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>'></asp:HyperLink> 
                                                
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category").ToString() != "" ? Eval("Category").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Code" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblRCode" runat="server" Text='<%# Eval("ProjectCode").ToString() != "" ? Eval("ProjectCode").ToString().ToUpper(): ""%>' CssClass="input-xxs" Visible="false"></asp:Label>                                                                    
                        <asp:Label ID="lblPCode" runat="server" Text='<%# Eval("Code").ToString() != "" ? Eval("Code").ToString().ToUpper(): ""%>' CssClass="input-xxs" Visible="false"></asp:Label>                                                                    
                        <asp:Label ID="lblCode" runat="server" CssClass="input-xxs" ></asp:Label> 
                        <asp:Label ID="lblDeltekCode" runat="server" Text='<%# Eval("OldCode").ToString() != "" ? "("+Eval("OldCode").ToString().ToUpper()+")": ""%>' CssClass="input-xxs" Visible="false"></asp:Label> 
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
                        <br /><asp:Label ID="lblStatusRemarks" runat="server" Text='<%# Eval("StatusRemarks").ToString() != "" ? "(" + Eval("StatusRemarks").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) + ")" : ""%>' CssClass="input-xxs" ForeColor="Blue"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phase" HeaderStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblPhase" runat="server" Text='<%# Eval("Phase").ToString() != "" ? Eval("Phase").ToString().ToUpper().HighlightKeyWords(search_Word, "yellow", false) : "-"%>' CssClass="input-xxs"></asp:Label>
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
    


