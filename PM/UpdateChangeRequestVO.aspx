<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UpdateChangeRequestVO.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="PM_UpdateChangeRequestVO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">

    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs">
        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label>
            </asp:TableCell>

            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label>
            </asp:TableCell>

           <%-- <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false">
                <asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label>
            </asp:TableCell>--%>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300">
                <asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">CHANGE MANAGEMENT</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div class="panel-heading">CHANGE MANAGEMENT </div>
    <div class="panel-body">

        <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Execution.pdf')"></asp:ImageButton>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                    <asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
                    <asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <table>
            <tr>
                <td height="10"></td>
            </tr>
        </table>

        <div class="row">
            <div id="dvCode" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code" for="lblCode">Regular Code </label>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
                </div>
            </div>
        </div>

        <ul class="nav nav-tabs">
            <li id="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab">
                <img src="Img/Icon/user_half_information24.png" />
                <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="CHANGE MANAGEMENT"></asp:Label></a></li>

        </ul>

        <table>
            <tr>
                <td height="12"></td>
            </tr>
        </table>

        <div class="row">
            <div id="dvCRToFrom" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Change Request To / From" for="fldChangeRequestToFrom">Change Request To / From <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldChangeRequestToFrom" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvTitle" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Title" for="fldTitle">Title <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="fldTitle" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Title)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div id="dvContractNo" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract No." for="fldContractNo">Contract No. <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="fldContractNo" runat="server" CssClass="form-control input-xxs" Width="240px" PlaceHolder="(Contract No.)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvVariationType" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Type of Changes" for="fldVariationType">Type Of Changes <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldVariationType" runat="server" CssClass="form-control input-xxs" Width="240px"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div id="dvReason" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Reason For Changes" for="fldReason">Reason For Changes <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="fldReason" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Reason For Changes)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvClientApproval" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Has Client Approved The Changes?" for="fldClientApproval">Has Client Approved The Changes?</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldClientApproval" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvCostImpact" runat="server">
                <div class="col-md-2">
                    <label id="lblfldCostImpact" runat="server" class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Cost Impact Assessment" for="fldCostImpact"><font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <div class="form-inline">
                        <asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldCostImpact" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox>
                        <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="fldCostImpact" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div id="dvScheduleImpact" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Schedule Impact Due To Changes" for="fldScheduleImpact">Schedule Impact Due To Changes <font color="Red">*</font></label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="fldScheduleImpact" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Schedule Impact Due To Changes)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvLADImpact" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="LAD Impact?" for="fldLADImpact">Cumulative LAD Impact? </label>
                </div>
                <div class="col-md-8">
                    <div class="form-inline">
                        <asp:Label ID="lblRM2" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldLADImpact" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox>
                        <asp:CompareValidator runat="server" ID="cValidator3" ControlToValidate="fldLADImpact" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvGrantingVO" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Granting VO?" for="fldGrantingVO">Granting VO? <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldGrantingVO" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    <asp:Label ID="lblNA" runat="server" class="control-label input-xxs" Text="N/A" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div id="dvEOTFromClient" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Is This A Back-To-Back Changes From Client?" for="fldEOTFromClient">Is This A Back-To-Back Changes From Client? <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldEOTFromClient" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    <asp:Label ID="lblNA2" runat="server" class="control-label input-xxs" Text="N/A" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvIncreaseFee" runat="server" visible="false">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Is there an increase in fee?" for="fldIncreaseFee">Is there an increase in fee?</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldIncreaseFee" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    <asp:Label ID="lblNA3" runat="server" class="control-label input-xxs" Text="N/A" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvContractAddendum" runat="server" visible="false">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Is there any contract addendum?" for="fldContractAddendum">Is there any contract addendum?</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldContractAddendum" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    <asp:Label ID="lblNA4" runat="server" class="control-label input-xxs" Text="N/A" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvVOLetter" runat="server" visible="false">
                <div class="col-md-2">
                    <label runat="server" class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="VO Fee" for="fldCostImpact">VO Letter / Contract Addendum <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <div class="form-inline">
                        <%--<asp:TextBox ID="fldVOLetter" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:TextBox>--%>
                        <asp:FileUpload ID="fldVOLetter" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:FileUpload>
                        <asp:Button ID="btnSaveVOLetter" runat="server" Text="Save" CssClass="btn btn-primary btn-xs input-xxs" Width="50" OnClick="btnSaveVOLetter_Click" />
                    </div>
                    <div class="form-inline">
                        <em><asp:label id="lblVOLetter" runat="server" Visible="false" class="control-label input-xxs"></asp:label></em>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvVOFee" runat="server" visible="false">
                <div class="col-md-2">
                    <label runat="server" class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="VO Fee" for="fldCostImpact">VO Fees <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <div class="form-inline">
                        <asp:Label ID="lblRM3" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldVOFee" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox>
                        <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToValidate="fldCostImpact" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvGrantingEOT" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Granting EOT?" for="fldGrantingEOT">Granting EOT? <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldGrantingEOT" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    <asp:Label ID="lblNA1" runat="server" class="control-label input-xxs" Text="N/A" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Supporting Document" for="fldSupportingDoc">Supporting Document </label>
                    <br />
                    <em>
                        <asp:Label ID="lblSupportingDoc" runat="server" class="control-label input-xxs">(eg: Management Paper, Board Paper)</asp:Label></em>
                </div>
                <div class="col-md-10">
                    <button id="btnSupportingDoc" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150">&nbsp;&nbsp;New Supporting Document&nbsp;&nbsp;</button>
                    <asp:Label ID="lblNone" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                    <br />

                    <asp:GridView ID="gvSupportingDoc" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
                        <Columns>
                            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/" + Request.QueryString["ID1"] + "/CRSupportingDoc/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick="return confirm('Are you sure you want to remove this file?')" OnClick="DeleteSupportingDoc" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <%--<EmptyDataTemplate>No Record Found</EmptyDataTemplate>  --%>
                    </asp:GridView>

                </div>
            </div>
        </div>

        <%-- DAL Approval 3.8 --%>

        <div class="row">
            <div id="dvDALApproval" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                    <br />
                    <asp:Label ID="Label2" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.8:</b> Submission / Acceptance of Variation Order (VO) / Claims, Reimbursable Work (RW) and Extension of Time (EOT) To / From Clients]</em></asp:Label>
                </div>

                <div class="col-md-10">

                    <asp:Table ID="tblDALApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2">
                                <asp:Label ID="lblDALApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDALA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldDALApprover" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="fldDALApprover_HOD" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="fldDALApprover_COO" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:Label ID="lblDAL_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblDAL_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblDAL_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>

                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </div>
            </div>
        </div>

        <%-- end of DAL Approval 3.8 --%>

        <%-- DAL Approval 3.9 --%>

        <div class="row">
            <div id="dvDALApproval_VO" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                    <br />
                    <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.9:</b> Award of Variation Order (“VO”)/ Claims, and Reimbursable Work (“RW”) to Sub-contractors]</em></asp:Label>
                </div>

                <div class="col-md-10">

                    <asp:Table ID="tblDALApproval_VO" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2">
                                <asp:Label ID="lblDALApproval_VO" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDALA1_VO" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA2_VO" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA3_VO" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA4_VO" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldDALApprover_VO" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="fldDALApprover_HOD_VO" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="fldDALApprover_COO_VO" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:Label ID="lblDAL_ApprovedDate_VO" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblDAL_ApprovedStatus_VO" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblDAL_ApprovedComment_VO" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>

                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </div>
            </div>
        </div>

        <%-- end of DAL Approval 3.9 --%>

        <%-- DAL Approval 3.13 --%>

        <div class="row">
            <div id="dvDALApproval_EOT" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                    <br />
                    <asp:Label ID="Label1" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.13:</b> Granting of Extension of Time (“EOT”) to Contractors / Sub-contractors]</em></asp:Label>
                </div>

                <div class="col-md-10">

                    <asp:Table ID="tblDALApproval_EOT" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2">
                                <asp:Label ID="lblDALApproval_EOT" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDALA1_EOT" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA2_EOT" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA3_EOT" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label>
                                <br />
                                <asp:Label ID="lblDALA4_EOT" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:DropDownList ID="fldDALApprover_HOD_EOT" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="fldDALApprover_COO_EOT" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:Label ID="lblDAL_ApprovedDate_EOT" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblDAL_ApprovedStatus_EOT" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblDAL_ApprovedComment_EOT" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>

                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </div>
            </div>
        </div>

        <%-- end of DAL Approval 3.13 --%>

        <table>
            <tr>
                <td height="12"></td>
            </tr>
        </table>

        <div class="row">
            <div>
                <div class="col-md-2">
                    <label class="control-label input-xxs">Created By </label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblCreatedBy" runat="server" CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                </div>
            </div>
            <div>
                <div class="col-md-2">
                    <label class="control-label input-xxs">Modified By </label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblLastUpdate" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-2">
                    <label class="control-label input-xxs">Created Date </label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblCreatedDt" runat="server" CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                </div>
            </div>
            <div>
                <div class="col-md-2">
                    <label class="control-label input-xxs">Modified Date </label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblLastUpdateDt" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                </div>
            </div>
        </div>

        <table>
            <tr>
                <td height="12"></td>
            </tr>
        </table>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote" runat="server" class="control-label input-xxs" Font-Italic="true">Note :</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update </b> button to update change record.</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the change record. No update is allowed when you have submitted this page.</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote2a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to DAL person for approval.</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back</b> button to return to the previous page.</asp:Label>
                </div>
            </div>
        </div>

        <hr />

        <div class="row" align="center">
            &nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" OnClientClick="return confirm('Are you sure you want to submit this page?')" />
            &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-xs input-xxs" Width="55" OnClick="btnBack_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false" />

        </div>
    </div>

    <!-------------------------------------------- Attachment - Supporting Document -------------------------------------------->
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
                    <img src="Img/images2.png" />
                    <asp:Label ID="lblProjectDoc" runat="server" class="control-label input-xxs" Text="New Supporting Document" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-body">

                    <asp:Label ID="lblErrInputE" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label>
                    <br />
                    <br />

                    <div class="row">
                        <div id="dvFileName" runat="server">
                            <div class="col-md-3">
                                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="File Name" for="fldFileName">File Name <font color="Red">*</font></label>
                            </div>
                            <div class="col-md-4">
                                <asp:FileUpload ID="fldFileName" CssClass="form-control input-xxs" runat="server" Width="350px" />
                            </div>
                        </div>
                    </div>

                    <br />

                    <asp:Button ID="btnSaveE" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveE_Click" />
                    &nbsp;&nbsp;<asp:Button ID="btnCloseE" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseE_Click" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!-------------------------------------------- End of Attachment - Supporting Document -------------------------------------------->
</asp:Content>
