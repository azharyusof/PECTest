<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="OpportunityGoNoGoDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="OpportunityGoNoGoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs">
        <asp:TableRow runat="server" CssClass="table table-bordered input-sm">
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300">
                <asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
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
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF">
                <asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div class="panel-heading">OPPORTUNITY GO / NO-GO</div>
    <div class="panel-body">

        <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Opportunity_GoNoGo.pdf')"></asp:ImageButton></asp:TableCell>
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

        <!-------------------------------------------- Start in-active screen -------------------------------------------->
        <div id="dvInactive" runat="server">

            <div class="row">
                <div>
                    <div class="col-md-5">
                        <asp:Label ID="lblInactive" runat="server" class="control-label input-xxs" ForeColor="Red">SORRY, YOU ARE NOT ALLOWED TO ACCESS THIS PAGE.</asp:Label>
                    </div>
                </div>
            </div>

            <table>
                <tr>
                    <td height="300"></td>
                </tr>
            </table>

        </div>
        <!-------------------------------------------- End of in-active screen -------------------------------------------->

        <!-------------------------------------------- Start active screen -------------------------------------------->
        <div id="dvActive" runat="server">

            <div class="row">
                <div>
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Opportunity Name" for="lblDescription">Opportunity Name </label>
                    </div>

                    <div class="col-md-8">
                        <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs">(Opportunity Name)</asp:Label>
                    </div>
                </div>
            </div>

            <ul class="nav nav-tabs">
                <li id="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab">
                    <img src="Img/Icon/document_sans_accept24.png" />
                    <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="OPPORTUNITY INFO."></asp:Label></a></li>
<%--                <li id="tab2" runat="server"><a href='OpportunityAssessmentDetail.aspx?Id=<%=Request.QueryString["Id"]%>' onclick="JavaScript:return confirm('Have you updated the opportunity info?');">
                    <img src="Img/Icon/document_text24.png" />
                    <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="OPPORTUNITY ASSESSMENT"></asp:Label></a></li>--%>
            </ul>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <img src="Img/images2.png" />
            <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Client" Font-Bold="true"></asp:Label>

            <table>
                <tr>
                    <td height="5"></td>
                </tr>
            </table>

            <div style="width: 100%;">
                <div style="border: 1px solid darkgray; height: 2px;">
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <div class="row">
                <div id="dvClientNature" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contractor/Consultant/Asset Owner" for="fldClientNature">Nature of Client <font color="Red">*</font></label>
                    </div>

                    <div class="col-md-3">
                        <asp:TextBox ID="fldClientNature" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Nature of Client)" MaxLength="850"></asp:TextBox>
                        <asp:Label ID="lblBtnSubmit" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvStrategicClient" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Strategic Client? If Yes, Why?" for="fldStrategicClient">Strategic Client? <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-8">
                        <div class="form-inline">
                            <asp:DropDownList ID="fldStrategicClient" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                            <asp:TextBox ID="fldStrategicClientComment" runat="server" CssClass="form-control input-xxs" Width="400px" PlaceHolder="(Comment)" MaxLength="850"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvStatusRel" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Status of Relationship" for="fldStatusRel">Status of Relationship <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="fldStatusRel" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div id="dvPymntHistory" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Payment History" for="fldPymntHistory">Payment History <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-1">
                        <asp:DropDownList ID="fldPymntHistory" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <img src="Img/images2.png" />
            <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Competition" Font-Bold="true"></asp:Label>

            <table>
                <tr>
                    <td height="5"></td>
                </tr>
            </table>

            <div style="width: 100%;">
                <div style="border: 1px solid darkgray; height: 2px;">
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <div class="row">
                <div id="dvCompetitorNo" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="No. Of Competitors" for="fldCompetitorNo">How Many Competitors? <font color="Red">*</font></label>
                    </div>

                    <div class="col-md-3">
                        <asp:DropDownList ID="fldCompetitorNo" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div id="dvCompetitorList" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="State The Company" for="fldCompetitorList">Who Are The Competitors? <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="fldCompetitorList" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Who Are The Competitors?)" MaxLength="850"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvCanCompete" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Can We Compete? Why?" for="fldCanCompete">Can We Compete? <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-8">
                        <div class="form-inline">
                            <asp:DropDownList ID="fldCanCompete" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                            <asp:TextBox ID="fldCanCompeteComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvMaterializingPercent" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Chances of Project Materializing" for="fldMaterializingPercent">Chances of Project Materializing <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-8">
                        <div class="form-inline">
                            <asp:TextBox ID="fldMaterializingPercent" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850"></asp:TextBox><asp:Label ID="lblPercent" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                            <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="fldMaterializingPercent" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                            <asp:TextBox ID="fldMaterializingComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvWinningPercent" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Chances of Winning - Calculated % based on No. of Competitors and Chances of Project Materializing" for="fldWinningPercent">Chances of Winning <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-8">
                        <div class="form-inline">
                            <asp:TextBox ID="fldWinningPercent" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850"></asp:TextBox><asp:Label ID="lblPercent1" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                            <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToValidate="fldWinningPercent" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                            <asp:TextBox ID="fldWinningComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <img src="Img/images2.png" />
            <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="Finances" Font-Bold="true"></asp:Label>

            <table>
                <tr>
                    <td height="5"></td>
                </tr>
            </table>

            <div style="width: 100%;">
                <div style="border: 1px solid darkgray; height: 2px;">
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <div class="row">
                <div id="dvProjectValue" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Project Value" for="fldProjectValue">Potential Project Value <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <div class="form-inline">
                            <asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectValue" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator3" ControlToValidate="fldProjectValue" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div id="dvProjectFees" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Project Fees" for="fldProjectFees">Potential Project Fees <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-2">
                        <div class="form-inline">
                            <asp:Label ID="lblRM1" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectFees" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator4" ControlToValidate="fldProjectFees" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvPotentialMargin" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Gross Profit" for="fldPotentialMargin">Potential Gross Profit <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <div class="form-inline">
                            <asp:TextBox ID="fldPotentialMargin" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" CausesValidation="true"></asp:TextBox><asp:Label ID="lblPercent3" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                            <asp:CompareValidator runat="server" ID="CompareValidator5" ControlToValidate="fldPotentialMargin" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div id="dvPotentialBudget" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Pursuit Budget - How much it cost to do the bid" for="fldPotentialBudget">Potential Pursuit Budget <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-2">
                        <div class="form-inline">
                            <asp:Label ID="lblRM2" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldPotentialBudget" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator6" ControlToValidate="fldPotentialBudget" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvBudgetMargin" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Pursuit Budget / Potential Gross Profit" for="fldBudgetMargin">Potential Pursuit Budget / Potential Gross Profit </label>
                    </div>
                    <div class="col-md-4">
                        <div class="form-inline">
                            <asp:TextBox ID="fldBudgetMargin" runat="server" CssClass="form-control input-xxs" Width="80px" Enabled="false"></asp:TextBox><asp:Label ID="Label9" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                            <asp:Button ID="btnCalculate" runat="server" Text="Re-Calculate" CssClass="btn btn-danger btn-xs input-xxs" Width="90" OnClick="btnCalculate_Click" />
                            <asp:Label ID="lblBudgetMargin" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>


            <img src="Img/images2.png" />
            <asp:Label ID="Label6" runat="server" class="control-label input-xxs" Text="Project Specific" Font-Bold="true"></asp:Label>

            <table>
                <tr>
                    <td height="5"></td>
                </tr>
            </table>

            <div style="width: 100%;">
                <div style="border: 1px solid darkgray; height: 2px;">
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <div class="row">
                <div id="dvContractType" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Type" for="fldContractType">Contract Type <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="fldContractType" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div id="dvContractDuration" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Duration" for="fldContractDuration">Contract Duration <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="fldContractDuration" runat="server" CssClass="form-control input-xxs" Width="180px" PlaceHolder="(Contract Duration)" MaxLength="850"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvDetailedScopeWork" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Detailed Scope of Work" for="fldDetailedScopeWork">Detailed Scope of Work <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="fldDetailedScopeWork" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="100" PlaceHolder="(Detailed Scope of Work)" MaxLength="850"></asp:TextBox>
                    </div>
                </div>
            </div>


            <div class="row">
                <div>
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="RFP (If Available)" for="fldRFP ">RFP (If Available)</label>
                    </div>
                    <div class="col-md-3">
                        <asp:HiddenField ID="hidURLA1" runat="server" />
                        <asp:UpdatePanel runat="server" ID="UpA1" UpdateMode="Conditional">
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCancelA1" />
                                <asp:PostBackTrigger ControlID="btnUpA1" />
                                <asp:PostBackTrigger ControlID="btnViewA1" />
                                <asp:PostBackTrigger ControlID="btnDeleteA1" />
                            </Triggers>
                            <ContentTemplate>

                                <div id="dvUpA1Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div id="dvA1" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA1Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn">
                                                    <asp:Button ID="btnCancelA1" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA1();" /></span>
                                                <span class="input-group-btn">
                                                    <asp:Button ID="btnUpA1" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA1_Click" OnClientClick="return validateErrA1();" /></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA1Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA1" runat="server" CssClass="form-control input-xs" Width="250px" />
                                            <span class="input-group-btn">
                                                <asp:Button ID="btnViewA1" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA1_Click" /></span>
                                            <span class="input-group-btn">
                                                <asp:Button ID="btnDeleteA1" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA1_Click" OnClientClick="return confirm('Are you sure you want to delete this file?')" /></span>
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>



            <div class="row">
                <div id="dvOurCapability" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Our Capability to Execute" for="fldOurCapability">Our Capability to Execute <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-8">
                        <div class="form-inline">
                            <asp:DropDownList ID="fldOurCapability" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                            <asp:TextBox ID="fldOurCapabilityComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvOurDifferentiation" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Our Differentiation" for="fldOurDifferentiation">Our Differentiation <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="fldOurDifferentiation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Our Differentiation)" MaxLength="850"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div id="dvTrackRecord" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Do We Have Track Record / Experience?" for="fldTrackRecord">Do We Have Track Record / Experience? <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="fldTrackRecord" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvPartnerReq" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Partner Required?" for="fldSOW">Partner Required? <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-8">
                        <div class="form-inline">
                            <asp:DropDownList ID="fldPartnerReq" runat="server" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                            <asp:TextBox ID="fldPartnerReqComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Comment - Who & Why)" MaxLength="850"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvProjectRisk" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Risk" for="fldProjectRisk">Project Risk </label>
                    </div>

                    <div class="col-md-10">

                        <table runat="server" width="100%">
                            <tr>
                                <td align="rileftght">
                                    <button id="btnProjectRisk" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModal" data-toggle="modal" width="150">&nbsp;&nbsp;New Project Risk&nbsp;&nbsp;</button>
                                    <asp:Label ID="lblNone" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="btnHeatMap" runat="server" ImageUrl="img/info.jpg" ToolTip="Risk Heat Map" OnClientClick="window.open('TableHeatMap.aspx', 'newwindow', 'width=700,height=450,toolbar=no'); return false;"></asp:ImageButton>
                                </td>
                            </tr>
                        </table>

                        <asp:GridView ID="gvProjectRisk" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowEditing="EditProject" OnRowUpdating="UpdateProject" OnRowCancelingEdit="CancelProjectEdit" OnRowCreated="gvProjectRisk_RowCreated" OnRowDataBound="gvProjectRisk_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Risk Description <br>(Include Cost & Impact of Risk)" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRisk" runat="server" Text='<%# Eval("ProjectRisk")%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRisk" runat="server" Text='<%# Eval("ProjectRisk")%>' CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="60"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Likelihood" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLikelihood" runat="server" Text='<%# Eval("Likelihood").ToString() != "" ? Eval("Likelihood").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txtLikelihood" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Likelihood")%>'>
                                            <asp:ListItem Value="Certain" Text="Certain"></asp:ListItem>
                                            <asp:ListItem Value="Likely" Text="Likely"></asp:ListItem>
                                            <asp:ListItem Value="Possible" Text="Possible"></asp:ListItem>
                                            <asp:ListItem Value="Unlikely" Text="Unlikely"></asp:ListItem>
                                            <asp:ListItem Value="Remote" Text="Remote"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Impact" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact").ToString() != "" ? Eval("Impact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txtImpact" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Impact")%>'>
                                            <asp:ListItem Value="Insignificant" Text="Insignificant"></asp:ListItem>
                                            <asp:ListItem Value="Minor" Text="Minor"></asp:ListItem>
                                            <asp:ListItem Value="Moderate" Text="Moderate"></asp:ListItem>
                                            <asp:ListItem Value="Major" Text="Major"></asp:ListItem>
                                            <asp:ListItem Value="Catastrophic" Text="Catastrophic"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Risk Rating" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRiskRating" runat="server" Text='<%# Eval("RiskRating").ToString() != "" ? Eval("RiskRating").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mitigation" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMitigation" runat="server" Text='<%# Eval("Mitigation").ToString() != "" ? Eval("Mitigation").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMitigation" runat="server" Text='<%# Eval("Mitigation")%>' CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="60"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick="return confirm('Are you sure you want to remove this record?')" OnClick="DeleteProjectRisk" />
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
                            <%--<EmptyDataTemplate>No Record Found</EmptyDataTemplate>  --%>
                        </asp:GridView>

                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvContractRisk" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Risk" for="fldContractRisk">Contract Risk </label>
                    </div>

                    <div class="col-md-10">

                        <table runat="server" width="100%">
                            <tr>
                                <td align="rileftght">
                                    <button id="btnContractRisk" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalC" data-toggle="modal" width="150">&nbsp;&nbsp;New Contract Risk&nbsp;&nbsp;</button>
                                    <asp:Label ID="lblNone1" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/info.jpg" ToolTip="Risk Heat Map" OnClientClick="window.open('TableHeatMap.aspx', 'newwindow', 'width=700,height=450,toolbar=no'); return false;"></asp:ImageButton>
                                </td>
                            </tr>
                        </table>

                        <asp:GridView ID="gvContractRisk" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowEditing="EditContract" OnRowUpdating="UpdateContract" OnRowCancelingEdit="CancelContractEdit" OnRowCreated="gvContractRisk_RowCreated" OnRowDataBound="gvContractRisk_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Risk Description <br>(Include Cost & Impact of Risk)" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRisk" runat="server" Text='<%# Eval("ContractRisk")%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRisk" runat="server" Text='<%# Eval("ContractRisk")%>' CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="60"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Likelihood" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLikelihood" runat="server" Text='<%# Eval("Likelihood").ToString() != "" ? Eval("Likelihood").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txtLikelihood" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Likelihood")%>'>
                                            <asp:ListItem Value="Certain" Text="Certain"></asp:ListItem>
                                            <asp:ListItem Value="Likely" Text="Likely"></asp:ListItem>
                                            <asp:ListItem Value="Possible" Text="Possible"></asp:ListItem>
                                            <asp:ListItem Value="Unlikely" Text="Unlikely"></asp:ListItem>
                                            <asp:ListItem Value="Remote" Text="Remote"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Impact" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact").ToString() != "" ? Eval("Impact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txtImpact" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Impact")%>'>
                                            <asp:ListItem Value="Insignificant" Text="Insignificant"></asp:ListItem>
                                            <asp:ListItem Value="Minor" Text="Minor"></asp:ListItem>
                                            <asp:ListItem Value="Moderate" Text="Moderate"></asp:ListItem>
                                            <asp:ListItem Value="Major" Text="Major"></asp:ListItem>
                                            <asp:ListItem Value="Catastrophic" Text="Catastrophic"></asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Risk Rating" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRiskRating" runat="server" Text='<%# Eval("RiskRating").ToString() != "" ? Eval("RiskRating").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mitigation" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMitigation" runat="server" Text='<%# Eval("Mitigation").ToString() != "" ? Eval("Mitigation").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMitigation" runat="server" Text='<%# Eval("Mitigation")%>' CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="60"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick="return confirm('Are you sure you want to remove this record?')" OnClick="DeleteContractRisk" />
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
                            <%--<EmptyDataTemplate>No Record Found</EmptyDataTemplate>  --%>
                        </asp:GridView>

                    </div>
                </div>
            </div>


            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

            <img src="Img/images2.png" />
            <asp:Label ID="Label7" runat="server" class="control-label input-xxs" Text="Evaluation" Font-Bold="true"></asp:Label>

            <table>
                <tr>
                    <td height="5"></td>
                </tr>
            </table>

            <div style="width: 100%;">
                <div style="border: 1px solid darkgray; height: 2px;">
                </div>
            </div>

            <table>
                <tr>
                    <td height="12"></td>
                </tr>
            </table>

           <%-- <div class="row">
                <div id="dvScore" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Assessment Scoring" for="fldScore">Assessment Scoring </label>
                        <br />
                        <asp:Label ID="Label5" runat="server" class="control-label input-xxs"><em>[Assessment for Potential Project Fees >= 10M]</em></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <div class="form-inline">
                            <asp:TextBox ID="fldScore" runat="server" CssClass="form-control input-xxs" Width="60px" Enabled="false"></asp:TextBox>
                            <asp:Label ID="lblScore" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Blue">(Kindly complete the <b>Assessment</b> tab to obtain the scoring)</asp:Label>
                        </div>
                    </div>
                </div>
            </div>--%>

            <div class="row">
                <div id="dvEvaluationPerson" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Person / Committee" for="fldEvaluationPerson">Evaluation Person / Committee <font color="Red">*</font></label>
                        <br />
                        <asp:Label ID="Label8" runat="server" class="control-label input-xxs"><em>[Min. of 1 representative from Technical, Head of Division, BD, Bid Manager, Commercial, DAL 3.2 Approver]</em></asp:Label>
                    </div>

                    <div class="col-md-10">
                        <button id="btnEvaluationPerson" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150">&nbsp;&nbsp;New Evaluation Person / Committee&nbsp;&nbsp;</button>
                        <asp:Label ID="lblNone2" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                        <asp:Label ID="lblCheckEvaluation" runat="server" class="control-label input-xxs" ForeColor="White"></asp:Label>

                        <asp:GridView ID="gvEvaluationPerson" runat="server" Width="70%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowEditing="EditEvaluation" OnRowUpdating="UpdateEvaluation" OnRowCancelingEdit="CancelEvaluationEdit" OnRowCreated="gvEvaluationPerson_RowCreated" OnRowDataBound="gvEvaluationPerson_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Evaluation Person / Committee" HeaderStyle-Width="60%" ItemStyle-Width="60%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCommitteeMember" runat="server" Text='<%# Eval("CommitteeName")%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txtEvaluationCommittee" runat="server" CssClass="form-control input-xxs" Width="300px"></asp:DropDownList>

                                        <asp:TextBox ID="txtCommitteeMember" runat="server" Text='<%# Eval("CommitteeMember")%>' CssClass="form-control input-xxs" Width="280px" Visible="false"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Role" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role")%>' CssClass="input-xxs"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRole" runat="server" Text='<%# Eval("Role")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick="return confirm('Are you sure you want to remove this record?')" OnClick="DeleteEvaluation" />
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
                            <%--<EmptyDataTemplate>No Record Found</EmptyDataTemplate>  --%>
                        </asp:GridView>

                    </div>
                </div>
            </div>


            <div class="row">
                <div id="dvEvaluationComment" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Comment / Justification" for="fldEvaluationComment">Evaluation Comment / Justification <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="fldEvaluationComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="100" PlaceHolder="(Evaluation Comment / Justification)" MaxLength="850"></asp:TextBox>
                    </div>
                </div>
            </div>

            <br />

            <div class="row">
                <div id="dvDecision" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Go / No-Go Decision" for="fldDecision">Go / No-Go Recommend <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <div class="form-inline">
                            <asp:DropDownList ID="fldDecision" runat="server" AutoPostBack="true" CssClass="form-control input-xxs" Width="150px" OnSelectedIndexChanged="fldDecision_SelectedChanged"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvRemarks" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Remarks" for="fldRemarks">Remarks <font color="Red">*</font></label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="fldRemarks" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="50" PlaceHolder="(Remarks)" MaxLength="450"></asp:TextBox>
                    </div>
                </div>
            </div>

            <br />

            <%-- DAL Approval 3.3 --%>

            <div class="row">
                <div id="dvDALApprovalCost" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                        <br />
                        <asp:Label ID="Label1" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.3:</b> Cost of Preparing Proposal / Tender]</em></asp:Label>
                    </div>

                    <div class="col-md-10">

                        <asp:Table ID="tblDALApprovalCost" runat="server" Width="60%" CssClass="table table-bordered input-xxs">

                            <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2" Width="50%">
                                    <asp:Label ID="lblDALReviewerCost" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label></asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                    <asp:Label ID="lblDALA1Cost" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDALA2Cost" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDALA3Cost" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDALA4Cost" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                    <asp:DropDownList ID="fldDALApprover_COOCost" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="fldDALApproverCost" runat="server" CssClass="form-control input-xxs" Width="250px" AppendDataBoundItems="true" Visible="false">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:Label ID="lblDALApproverCost" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666" Visible="true"></asp:Label>

                                    <br />
                                    <asp:Label ID="lblDAL_ApprovedDateCost" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDAL_ApprovedStatusCost" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDAL_ApprovedCommentCost" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>

                                    <br />
                                    <asp:Label ID="lvlDALBODCost" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">Please submit to BOD or MD/CEO for approval.<br /></asp:Label>

                                    <asp:Label ID="lblErrorRemarks" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false"><br /></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </div>
                </div>
            </div>

            <%-- DAL Approval 3.2 --%>

            <div class="row">
                <div id="dvDALApproval" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                        <br />
                        <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.2:</b> Submission of Tender Bids / Proposals / Quotations]</em></asp:Label>
                    </div>

                    <div class="col-md-10">

                        <asp:Table ID="tblDALApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs">

                            <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">
                                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2" Width="50%">
                                    <asp:Label ID="lblDALReviewer" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label></asp:TableCell>
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

                                    <asp:Label ID="lblDALApprover" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666" Visible="true"></asp:Label>

                                    <br />
                                    <asp:Label ID="lblDAL_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDAL_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDAL_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>

                                    <br />
                                    <asp:Label ID="lvlDALBOD" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">Please submit to BOD or MD/CEO for approval.<br /></asp:Label>

                                    <asp:Label ID="lblOldDALRemarks" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Blue" Visible="false"><br /></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvCode" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="fldCode">Promotional Code </label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="fldCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvOldCode" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code (Deltek)" for="fldOldCode">Promotional Code (Deltek)</label>
                    </div>
                    <div class="col-md-6">
                        <div class="form-inline">
                            <asp:TextBox ID="fldOldCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox>
                        </div>
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
                        <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the opportunity details.</asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div>
                    <div class="col-md-8">
                        <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Project Risk</b> button to create project risk record.</asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div>
                    <div class="col-md-8">
                        <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Contract Risk</b> button to create contract risk record.</asp:Label>
                    </div>
                </div>
            </div>


            <div class="row">
                <div>
                    <div class="col-md-8">
                        <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Evaluation Person / Committee</b> button to create evaluation person / committee record.</asp:Label>
                    </div>
                </div>
            </div>


            <div class="row">
                <div>
                    <div class="col-md-12">
                        <asp:Label ID="lblNote5" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to recommend <b>GO</b> / <b>NO-GO</b> for the opportunity and to seek for DAL (Discretionary Authority Limits) approval. No update is allowed when you have submitted this page.</asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div>
                    <div class="col-md-8">
                        <asp:Label ID="lblNote5a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to DAL person for approval and CC to committee for <b>GO</b> / <b>NO-GO</b> decision.</asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div>
                    <div class="col-md-8">
                        <asp:Label ID="lblNote5b" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; If decision is <b>GO</b> and DAL person approved the <b>GO</b> recommendation, an email notification will be sent to Finance to create promotional code.</asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div>
                    <div class="col-md-8">
                        <asp:Label ID="lblNote5c" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; An email notification will be sent to Evaluation Person / Committee for info.</asp:Label>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row" align="center">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" />
                &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" OnClientClick="return confirm('Are you sure you want to submit this page?')" />
                &nbsp;&nbsp;<asp:Button ID="btnDrop" runat="server" Text="Drop Proposal" CssClass="btn btn-warning btn-xs input-xxs" Width="100" OnClick="btnDrop_Click" OnClientClick="return confirm('Are you sure you want to drop this proposal?')" />
                &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false" />
            </div>

        </div>
        <!-------------------------------------------- End of active screen -------------------------------------------->

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="lbtnCloseX" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcClose();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
                        <img src="Img/images2.png" />
                        <asp:Label ID="lblProject" runat="server" class="control-label input-xxs" Text="New Project Risk" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="modal-body">

                        <asp:Label ID="lblErrInput" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label>
                        <br />
                        <br />

                        <div class="row">
                            <div id="dvRisk" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk" for="fldRisk">Risk Description
                                        <br />
                                        (Include Cost & Impact of Risk) <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="fldRisk" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Risk Description)" MaxLength="850"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvLikelihood" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Likelihood" for="fldLikelihood">Likelihood <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldLikelihood" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvImpact" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Impact" for="fldImpact">Impact <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldImpact" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvMitigation" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Mitigation" for="fldMitigation">Mitigation <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="fldMitigation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Mitigation)" MaxLength="850"></asp:TextBox>
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

        <div class="modal fade" id="myModalC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="lbtnCloseXC" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
                        <img src="Img/images2.png" />
                        <asp:Label ID="lblContract" runat="server" class="control-label input-xxs" Text="New Contract Risk" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="modal-body">

                        <asp:Label ID="lblErrInputC" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label>
                        <br />
                        <br />

                        <div class="row">
                            <div id="dvRiskC" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk" for="fldRisk">Risk Description
                                        <br />
                                        (Include Cost & Impact of Risk) <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="fldRiskC" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Risk Description)" MaxLength="850"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvLikelihoodC" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Likelihood" for="fldLikelihood">Likelihood <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldLikelihoodC" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvImpactC" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Impact" for="fldImpactC">Impact <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldImpactC" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvMitigationC" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Mitigation" for="fldMitigationC">Mitigation <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="fldMitigationC" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Mitigation)" MaxLength="850"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />

                        <asp:Button ID="btnSaveC" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveC_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnCloseC" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseC_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
                        <img src="Img/images2.png" />
                        <asp:Label ID="lblEvaluation" runat="server" class="control-label input-xxs" Text="New Evaluation Person / Committee" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="modal-body">

                        <asp:Label ID="lblErrInputE" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label>
                        <br />
                        <br />

                        <div class="row">
                            <div id="dvEvaluationCommittee" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Person / Committee" for="fldEvaluationCommittee">Evaluation Person / Committee <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="fldEvaluationCommittee" runat="server" CssClass="form-control input-xxs" Width="300px"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div id="dvRole" runat="server">
                                <div class="col-md-3">
                                    <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Role" for="fldRole">Role <font color="Red">*</font></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="fldRole" runat="server" CssClass="form-control input-xxs" Width="280px" PlaceHolder="(Role)" MaxLength="850"></asp:TextBox>
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

        <script type="text/javascript">
            function funcOpen() {
                $('#myModal').modal('toggle');
                $('#myModal').modal('show');
            }

            function funcClose() {
                $('#myModal').modal('hide');
            }

            function funcOpenC() {
                $('#myModalC').modal('toggle');
                $('#myModalC').modal('show');
            }

            function funcCloseC() {
                $('#myModalC').modal('hide');
            }

            function funcOpenE() {
                $('#myModalE').modal('toggle');
                $('#myModalE').modal('show');
            }

            function funcCloseE() {
                $('#myModalE').modal('hide');
            }
        </script>


        <script type="text/javascript">
            function clearUploadA1() {
                document.getElementById('<%=fldA1Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA1.ClientID%>').className = "form-group";
            }

            function validateErrA1() {
                var chckErrA1 = true;

                if (document.getElementById('<%=fldA1Upload.ClientID%>').value == "") {
                document.getElementById('<%=dvA1.ClientID%>').className = "form-group has-error";
                    chckErrA1 = false;
                }
                return chckErrA1;
            }
        </script>


    </div>

</asp:Content>
