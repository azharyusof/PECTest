<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="AssignEDMSCode.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="AssignEDMSCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

<div class="panel-heading">DOCUMENT MANAGEMENT</div>
<div class="panel-body">

    
    <ul class="nav nav-tabs">
        <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT INFO."></asp:Label></a></li>                    
     </ul>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvCompany" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Company" for="fldCompany">Operating Company <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldCompany" runat="server" CssClass="form-control input-xxs" Width="240px" Enabled="false"></asp:DropDownList>   
                <asp:Label ID="lblBtnSubmit" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvUnit" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Unit" for="fldUnit">Operating Unit <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:DropDownList ID="fldUnit" runat="server" CssClass="form-control input-xxs" Width="240px" Enabled="false"></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvClientName" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Client Name <font color="Red">*</font></label>
            </div>
            <div class="col-md-3">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldClientName" runat="server" CssClass="form-control input-xxs" Width="280px" OnSelectedIndexChanged="fldClientName_SelectedIndexChanged" AutoPostBack="true" Enabled="false"></asp:DropDownList>                       
                    <br /><asp:TextBox ID="fldNewClientName" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Client Name)"></asp:TextBox> 
                </div>   
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvClientAdd" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Client Address <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldClientAdd" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Client Address)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOpportunity" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="fldDescription">Project Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldDescription" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Project Name)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvSOW" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Scope of Work" for="fldSOW">Scope of Work <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldSOW" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Scope of Work)" MaxLength="850" Enabled="false"></asp:TextBox>          
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvPM" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Manager" for="fldPM">Project Manager <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPM" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPD" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Director" for="fldPD">Project Director <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPD" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvPIC1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [1]" for="fldPIC1">Person In Charge [1]</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPIC1" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPIC2" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [2]" for="fldPIC2">Person In Charge [2]</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPIC2" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <%--<div class="row">
        <div id="dvHSERep" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HSE Liaison Representative" for="fldHSERep">HSE Liaison Representative</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldHSERep" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>--%>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs">Created By </label>
            </div>
            <div class="col-md-4">                
                <asp:Label ID="lblCreatedBy" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
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
                <asp:Label ID="lblCreatedDt" runat="server" Text='None' CssClass="input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
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

    <img src="Img/images2.png"/> <asp:Label ID="Label12" runat="server" class="control-label input-xxs" Text="KMDC Section" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvProjectCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code" for="fldProjectCode">Regular Code </label>
            </div>            
            <div class="col-md-4">  
                <div class="form-inline">
                    <asp:TextBox ID="fldProjectCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>

        <div id="dvOldCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code (Deltek)" for="fldOldCode">Regular Code (Deltek)</label>
            </div>            
            <div class="col-md-4">  
                <div class="form-inline">
                    <asp:TextBox ID="fldOldCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvEDMSCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EDMS Code" for="fldEDMSCode">EDMS Code [1] <font color="Red">*</font></label>
            </div>            
            <div class="col-md-6">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldEDMSCode" runat="server" CssClass="form-control input-xxs" Width="140px" OnSelectedIndexChanged="fldEDMSCode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                       
                    &nbsp;<asp:TextBox ID="fldEDMSName" runat="server" CssClass="form-control input-xxs" Width="400px" PlaceHolder="(EDMS Name)" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvEDMSCode1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="EDMS Code" for="fldEDMSCode">EDMS Code [2] </label>
            </div>            
            <div class="col-md-6">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldEDMSCode1" runat="server" CssClass="form-control input-xxs" Width="140px" OnSelectedIndexChanged="fldEDMSCode1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                       
                    &nbsp;<asp:TextBox ID="fldEDMSName1" runat="server" CssClass="form-control input-xxs" Width="400px" PlaceHolder="(EDMS Name)" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    
   <%--<div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Created" for="lblDtCreated">Date Created </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtEDMSCreated" runat="server" CssClass="control-label input-xxs" ForeColor="Blue"></asp:Label>   
            </div>
        </div>
    </div>
       --%>

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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to assign the EDMS code. Email notification will be sent to Project Manager for info.</asp:Label> 
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
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" />                    
    </div>
        
</asp:Content>
    



