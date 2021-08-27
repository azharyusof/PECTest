<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="OutOfOffice.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="OutOfOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
       
<div class="panel-heading">OUT OF OFFICE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

    <table><tr><td height="10"></td></tr></table>

<!-------------------------------------------- Start active screen -------------------------------------------->
<div id="dvActive" runat="server">
        
    
    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Checklist" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvHSEInduction" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbHSEInduction">HSE Induction Training Awareness </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbHSEInduction" runat="server" />
            </div>            
        </div>
    </div>
       
    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="lbl1" runat="server" class="control-label input-xxs" style="color:blue"><em>(In-house induction training is only for first timer. Refresher course required every 2 years. Contact L&D if training required.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvEOSP" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbEOSP">EOSP (If Perform Work At Expressway) </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbEOSP" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="lbl2" runat="server" class="control-label input-xxs" style="color:blue"><em>(Training conducted by NIOSH for workers works at expressway. Contact L&D if training required.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvKTM038" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbKTM038">KTM038 (If Perform Work At KTMB Project) </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbKTM038" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="lbl3" runat="server" class="control-label input-xxs" style="color:blue"><em>(Training conducted by KTMB to enable workers works at KTMB site. Contact L&D if training required.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvCIDB" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbCIDB">CIDB Green Card (For Any Construction Site Include Site Visit For Inspection) </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbCIDB" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="lbl4" runat="server" class="control-label input-xxs" style="color:blue"><em>(Contact L&D if training required.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvPPE" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbPPE">Do You Have Proper PPE (To Suit According To Nature Of Work)? </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbPPE" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="Label2" runat="server" class="control-label input-xxs"><em>(<a href="Basic PPE Requirement.pdf" target="_blank">Click here</a>)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvLegalRegister" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbLegalRegister">Legal Register</label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbLegalRegister" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="lbl5" runat="server" class="control-label input-xxs" style="color:blue"><em>(Have you referred to the HSE legal register related to the site that you are visiting to ensure understanding of legal compliance.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvHIRARC" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbHIRARC">HIRARC (Hazard Identification, Risk Assessment and Risk Control)</label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbHIRARC" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12"><asp:Label ID="lbl6" runat="server" class="control-label input-xxs" style="color:blue"><em>(Have you referred to the HIRARC to ensure HSE risk awareness. If your activity or new risk to existing activity is not found, please highlight this to your project / div. HSE rep. and update the HIRARC before the visit.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvEnvAI" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbEnvAI">Environmental Aspect & Impact</label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbEnvAI" runat="server" />
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8"><asp:Label ID="lbl7" runat="server" class="control-label input-xxs" style="color:blue"><em>(Have you referred to the Environmental Aspect & Impact to check if your activity has or may have an impact on the environment.)</em></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>


    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="Out Of Office Details" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvProjectName" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="fldProjectName">Project Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-5">                
                <asp:TextBox ID="fldProjectName" runat="server" CssClass="form-control input-xxs" Width="500px" PlaceHolder="(Project Name)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>        
    </div>

    <div class="row">
        <div id="dvPM" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="PM's Email" for="fldPMEmail">PM's Email <font color="Red">*</font></label>
            </div>
            <div class="col-md-5">                 
                <asp:TextBox ID="fldPMEmail" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(PM's Email)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>   
    </div>

    <div class="row">        
        <div id="dvHSSE" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HSSE's Email" for="fldHSSEEmail">HSSE's Email <font color="Red">*</font></label>
            </div>            
            <div class="col-md-5">                
                <asp:TextBox ID="fldHSSEEmail" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(HSSE's Email)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>     
    </div>

    <div class="row">
        <div id="dvDateTime" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date / Time" for="fldDateTime">Date / Time <font color="Red">*</font></label>
            </div>            
            <div class="col-md-5">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtDate'>
                        <asp:TextBox ID="fldDateTime" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                      
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvLocation" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Location" for="fldLocation">Location <font color="Red">*</font></label>
            </div>
            <div class="col-md-5">                 
                <asp:TextBox ID="fldLocation" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(Location)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>   
    </div>

    <div class="row">        
        <div id="dvReason" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Reason For Visit" for="fldReasonForVisit">Reason For Visit <font color="Red">*</font></label>
            </div>            
            <div class="col-md-5">                
                <asp:TextBox ID="fldReasonForVisit" runat="server" CssClass="form-control input-xxs" Width="500px" PlaceHolder="(Reason For Visit)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>     
    </div>
    
    <div class="row">        
        <div id="dvAck" runat="server">
            <div class="col-md-5">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" for="cbAck">I hereby acknowledge that I have obtained all HSSE documents, read all necessary documents and make necessary arrangements to mitigate and minimise all the risk at the project site. <font color="Red">*</font></label>
            </div>            
            <div class="col-md-5">                
                <asp:CheckBox ID="cbAck" runat="server" />
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> This section is not applicable for site people.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Out of office consist of activities at construction site (eg: attending site meeting / inspection / audit).</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Above is the checklist to go through for HSE awareness & precaution before activity is conducted.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the out of office checklist.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to Project Manager and HSSE Liaison Rep. for info.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" OnClientClick = "return confirm('Are you sure you want to submit this checklist?')" />         
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/>          
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->

    <script>
        $(function () {
            $('#dtDate').datetimepicker({
                format: 'DD-MMM-YYYY HH:mm',
                showTodayButton: true,
                showClear: true
            });

        });
    </script>

   </div>

</asp:Content>
    



