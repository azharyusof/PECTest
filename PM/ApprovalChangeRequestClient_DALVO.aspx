<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="ApprovalChangeRequestClient_DALVO.aspx.cs" Inherits="ApprovalChangeRequestClient_DALVO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

<div class="panel-heading">CHANGE MANAGEMENT</div>
<div class="panel-body">
    
    <table><tr><td height="10"></td></tr></table>

    <div class="row">
        <div id="dvCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Code" for="lblCode">Project Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>
    
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
            <div class="col-md-3">                  
                <asp:Label ID="lblDALApprover" runat="server" CssClass="input-xxs" ></asp:Label>       
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to approve this project.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; When you have approved this project, email notification will be sent to Project Manager for info.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1b" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; When you have rejected this project, email notification will be sent to Project Manager for info.</asp:Label> 
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
        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success btn-xs input-xxs" Width="72" OnClientClick="return confirm('Are you sure you want to approve this request?');" OnClick="btnApprove_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnNotApprove" runat="server" Text="Reject" CssClass="btn btn-danger btn-xs input-xxs" Width="60" OnClientClick="return confirm('Are you sure you want to reject this request?');" OnClick="btnNotApprove_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" />                    
    </div>

</asp:Content>
