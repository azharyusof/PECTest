<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="ApprovalOpportunityGoNoGo_DAL.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ApprovalOpportunityGoNoGo_DAL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

<div class="panel-heading">OPPORTUNITY GO / NO-GO APPROVAL</div>
<div class="panel-body">
    
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Opportunity Name" for="lblDescription">Opportunity Name </label>
            </div>            
            <div class="col-md-4">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs">(Opportunity Name)</asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Company" for="lblCompany">Operating Company </label>
            </div>            
            <div class="col-md-3">                
                <asp:Label ID="lblCompany" runat="server" class="control-label input-xxs">(Operating Company)</asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Manager" for="lblPM">Project Manager </label>
            </div>            
            <div class="col-md-3">                
                <asp:Label ID="lblPM" runat="server" class="control-label input-xxs">(Project Manager)</asp:Label>
            </div>
        </div>
        <div class="col-md-1"></div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="lblClientName">Client Name </label>
            </div>            
            <div class="col-md-3">                
                <asp:Label ID="lblClientName" runat="server" class="control-label input-xxs">(Client Name)</asp:Label>
                <asp:Label ID="lblDALApproverLevel" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

    <table><tr><td height="5"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Client" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

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
                                    <button id="btnProjectRisk" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModal" data-toggle="modal" width="150" disabled>&nbsp;&nbsp;New Project Risk&nbsp;&nbsp;</button>
                                    <asp:Label ID="lblNone" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="btnHeatMap" runat="server" ImageUrl="img/info.jpg" ToolTip="Risk Heat Map" OnClientClick="window.open('TableHeatMap.aspx', 'newwindow', 'width=700,height=450,toolbar=no'); return false;"></asp:ImageButton>
                                </td>
                            </tr>
                        </table>

                        <asp:GridView ID="gvProjectRisk" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowCreated="gvProjectRisk_RowCreated" OnRowDataBound="gvProjectRisk_RowDataBound">
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
                                    <button id="btnContractRisk" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalC" data-toggle="modal" width="150" disabled>&nbsp;&nbsp;New Contract Risk&nbsp;&nbsp;</button>
                                    <asp:Label ID="lblNone1" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/info.jpg" ToolTip="Risk Heat Map" OnClientClick="window.open('TableHeatMap.aspx', 'newwindow', 'width=700,height=450,toolbar=no'); return false;"></asp:ImageButton>
                                </td>
                            </tr>
                        </table>

                        <asp:GridView ID="gvContractRisk" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowCreated="gvContractRisk_RowCreated" OnRowDataBound="gvContractRisk_RowDataBound">
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

            <div class="row">
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
            </div>

            <div class="row">
                <div id="dvEvaluationPerson" runat="server">
                    <div class="col-md-2">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Person / Committee" for="fldEvaluationPerson">Evaluation Person / Committee <font color="Red">*</font></label>
                        <br />
                        <asp:Label ID="Label8" runat="server" class="control-label input-xxs"><em>[Min. of 1 representative from Technical, Head of Division, BD, Bid Manager, Commercial, DAL 3.2 Approver]</em></asp:Label>
                    </div>

                    <div class="col-md-10">
                        <button id="btnEvaluationPerson" runat="server" class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150" disabled>&nbsp;&nbsp;New Evaluation Person / Committee&nbsp;&nbsp;</button>
                        <asp:Label ID="lblNone2" runat="server" class="control-label input-xs" Visible="false">None</asp:Label>
                        <asp:Label ID="lblCheckEvaluation" runat="server" class="control-label input-xxs" ForeColor="White"></asp:Label>

                        <asp:GridView ID="gvEvaluationPerson" runat="server" Width="70%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowCreated="gvEvaluationPerson_RowCreated" OnRowDataBound="gvEvaluationPerson_RowDataBound">
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
                            <asp:DropDownList ID="fldDecision" runat="server" AutoPostBack="true" CssClass="form-control input-xxs" Width="150px"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

    <table><tr><td height="12"></td></tr></table>

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

    <table><tr><td height="12"></td></tr></table>    

    <img src="Img/images2.png"/> <asp:Label ID="Label12" runat="server" class="control-label input-xxs" Text="DAL Approval Status" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvApprover" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Approver" for="lblApprover">Approver </label>
            </div>            
            <div class="col-md-4">                  
                <asp:Label ID="lblDALApprover" runat="server" CssClass="input-xxs" ></asp:Label>       
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvReviewer" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Reviewer" for="lblReviewer">Reviewer </label>
            </div>            
            <div class="col-md-4">                  
                <asp:Label ID="lblDALReviewer" runat="server" CssClass="input-xxs" ></asp:Label>       
            </div>
        </div>
    </div>

   <div class="row">
        <div id="dvApprove" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Approved" for="lblDtApproved">Date Approved </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtApproved" runat="server" CssClass="control-label input-xxs" ForeColor="Blue"></asp:Label>   
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvReview" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Reviewed" for="lblDtReviewed">Date Reviewed </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtReviewed" runat="server" CssClass="control-label input-xxs" ForeColor="Blue"></asp:Label>   
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvReject" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Rejected" for="lblDtReject">Date Rejected </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtReject" runat="server" CssClass="control-label input-xxs" ForeColor="Red"></asp:Label>   
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvJustification" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldJustification">Justification </label>
            </div>            
            <div class="col-md-10">                
                <asp:TextBox ID="fldJustification" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)"></asp:TextBox>
            </div>
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>
        
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Approve</b> or <b>Reject</b> button.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; If <b>Approved</b>, email notification will be sent to Finance to create promotional code.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1b" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; If <b>Rejected</b>, email notification will be sent to Project Manager for info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Close Window</b> button to close this window.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success btn-xs input-xxs" Width="70" OnClientClick="return confirm('Are you sure you want to approve this request?');" OnClick="btnApprove_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnNotApprove" runat="server" Text="Reject" CssClass="btn btn-danger btn-xs input-xxs" Width="58" OnClientClick="return confirm('Are you sure you want to reject this request?');" OnClick="btnNotApprove_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" /><asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="125" OnClick="btnListing_Click"/>                                                                                                    
    </div>
    
</div>
    
</asp:Content>
    