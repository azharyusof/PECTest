<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="CreateChangeRequestVO.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="CreateChangeRequestVO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">

    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs">
        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>

            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

<%--            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false">
                <asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>--%>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300">
                <asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div class="panel-heading">CHANGE MANAGEMENT </div>
    <div class="panel-body">

        <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Execution.pdf')"></asp:ImageButton></asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                    <asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
                    <asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
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
                    <asp:DropDownList ID="fldChangeRequestToFrom" runat="server" CssClass="form-control input-xxs" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="fldChangeRequestToFrom_changed"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvTitle" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Title" for="fldTitle">Title <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="fldTitle" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Title / N/A)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-1"></div>
            <div id="dvContractNo" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract No." for="fldContractNo">Contract No. <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="fldContractNo" runat="server" CssClass="form-control input-xxs" Width="240px" PlaceHolder="(Contract No. / N/A)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvVariationType" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Type of Changes" for="fldVariationType">Type Of Changes <font color="Red">*</font></label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="fldVariationType" runat="server" CssClass="form-control input-xxs" Width="240px" OnSelectedIndexChanged="fldVariationType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                    <asp:TextBox ID="fldScheduleImpact" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Schedule Impact Due To Changes / N/A)" MaxLength="850"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div id="dvLADImpact" runat="server">
                <div class="col-md-2">
                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Cumulative LAD Impact?" for="fldLADImpact">Cumulative LAD Impact? <font color="Red">*</font></label>
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
                    <asp:DropDownList ID="fldGrantingVO" runat="server" CssClass="form-control input-xxs" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="fldGrantingVO_changed"></asp:DropDownList>
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
                    <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Create</b> button to create change record.</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Write N/A (Not Applicable) to any empty field.</asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div>
                <div class="col-md-8">
                    <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> You are required to <b>SUBMIT</b> this page after change record created.</asp:Label>
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

        <br />

        <div class="row" align="center">
            <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnCreate_Click" OnClientClick="return confirm('Are you sure you want to create new Change Item?')" />
            &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-xs input-xxs" Width="55" OnClick="btnBack_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false" />
            &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClientClick="return confirm('Are you sure you want to submit this page?')" Visible="false" />

        </div>


    </div>

</asp:Content>
