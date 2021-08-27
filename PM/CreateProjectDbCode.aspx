<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="CreateProjectDbCode.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="CreateProjectDbCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

<div class="panel-heading">REGISTER NEW PROJECT</div>
<div class="panel-body">

    <ul class="nav nav-tabs">
        <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT INFO."></asp:Label></a></li>                    
     </ul>
    
    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvCompany" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Company" for="fldCompany">Operating Company </label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList ID="fldCompany" runat="server" CssClass="form-control input-xxs" Width="240px" Enabled="false"></asp:DropDownList>   
                <asp:Label ID="lblSubmissionStatus" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvUnit" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Unit" for="fldUnit">Operating Unit </label>
            </div>            
            <div class="col-md-2">                
                <asp:DropDownList ID="fldUnit" runat="server" CssClass="form-control input-xxs" Width="240px" Enabled="false"></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvClientName" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Client Name </label>
            </div>
            <div class="col-md-3">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldClientName" runat="server" CssClass="form-control input-xxs" Width="280px" Enabled="false"></asp:DropDownList>     
                </div>   
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvClientAdd" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Client Address </label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldClientAdd" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Client Address)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOpportunity" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="fldDescription">Project Name </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldDescription" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Project Name)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvSOW" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Scope of Work" for="fldSOW">Scope of Work </label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldSOW" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Scope of Work)" MaxLength="850" Enabled="false"></asp:TextBox>          
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvPM" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Manager" for="fldPM">Project Manager </label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPM" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPD" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Director" for="fldPD">Project Director </label>
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

    <div class="row">
        <div id="dvHSERep" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HSE Liaison Representative" for="fldHSERep">HSE Liaison Representative</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldHSERep" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectValue" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Project Value </label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectValue" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true" Enabled="false"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="cValidator1" ControlToValidate="fldProjectValue" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvProjectFee" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Project Fees </label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="lblRM1" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectFee" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true" Enabled="false"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="cValidator2" ControlToValidate="fldProjectFee" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Start & End Date" for="fldDate">Project Start & End Date </label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtStartDate'>
                        <asp:TextBox ID="fldStartDate" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>  
                    <asp:Label ID="lblStart" runat="server" class="control-label input-xxs" Text="[start date]"></asp:Label>                    
                </div>
            </div>
            <div class="col-md-2">  
                <div class="form-inline">                    
                    <div class='input-group input-group-xs input-xxs' id='dtEndDate'>
                        <asp:TextBox ID="fldEndDate" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div><br />
                    <asp:Label ID="lblEnd" runat="server" class="control-label input-xxs" Text="[end date]"></asp:Label>                    
                </div>
            </div>
        </div>
        <div id="dvMargin" runat="server">                      
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Margin" for="fldPercent">Project Margin</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:TextBox ID="fldPercent" runat="server" CssClass="form-control input-xxs" Width="60px" PlaceHolder="0" CausesValidation="true" Enabled="false"></asp:TextBox><asp:Label ID="lblPercent" runat="server" class="control-label input-xxs" Text="%"></asp:Label> 
                    <asp:CompareValidator runat="server" ID="cValidator3" ControlToValidate="fldPercent" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>   
        </div>
    </div>

    <div class="row">
        <div id="dvContractPeriod" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Period" for="fldContractPeriod">Contract Period</label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldContractPeriod" runat="server" CssClass="form-control input-xxs" Width="180px" PlaceHolder="(Contract Period)" MaxLength="450" Enabled="false"></asp:TextBox>          
            </div>
        </div>        
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="LOI " for="fldLOI">Letter of Intent (LOI) </label> 
            </div>            
            <div class="col-md-4">                
                <asp:HiddenField ID="hidURLA3" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA3" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA3" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA3Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA3" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA3Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="false"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA3Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA3" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA3" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA3_Click" /></span>
                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="[eg: Services Agreement, LOI, TOR]"></asp:Label> 
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract / LOA " for="fldContractLOA ">Contract / LOA  </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA1" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA1" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA1" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA1Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA1" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA1Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="false"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA1Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA1" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA1" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA1_Click" /></span>
                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Letter of Acceptance" for="fldLOA">Letter of Acceptance </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA2" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA2" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA2" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA2Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA2" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA2Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="false"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA2Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA2" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA2" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA2_Click" /></span>
                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
    </div> 
    
    <div class="row">
        <div id="dvReasonDeviation" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Deviation" for="fldReasonDeviation">Reason For Deviation</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldReasonDeviation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="80" PlaceHolder="(Reason For Deviation)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvDALApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                <br />
                    <asp:Label ID="Label2" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.4:</b> Acceptance of Award Contract]</em></asp:Label>
            </div>
            
            <div class="col-md-10"> 

            <asp:Table ID="tblProjDBApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblDALApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>
                
                        <asp:TableRow>  
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblProjDBA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblProjDBA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblProjDBA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblProjDBA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">                                
                                <asp:Label ID="lblProjDBApprover" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666" Visible="true"></asp:Label>

                                <br /><asp:Label ID="lblProjDB_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblProjDB_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblProjDB_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblOldProjDBRemarks" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Blue"><br /></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
            </asp:Table>

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

    <img src="Img/images2.png"/> <asp:Label ID="Label12" runat="server" class="control-label input-xxs" Text="Finance Section" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="lblCode">Project Type</label>
            </div>            
            <div class="col-md-3">  
                <asp:Label ID="lblType" runat="server" class="control-label input-xxs" Text="REGULAR" ForeColor="Red" Font-Bold="true"></asp:Label>
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Code" for="fldCode">Project Code <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldCode" runat="server" CssClass="form-control input-xxs" Width="180px" PlaceHolder="(Project Code)" MaxLength="80"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-4">                
                <asp:Label ID="lblDate" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>
        <div>         
            <div class="col-md-3">                
                <asp:Label ID="lblFinance" runat="server" class="control-label input-xxs"></asp:Label>
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to create the project code. Email notification will be sent to Project Manager for info.</asp:Label> 
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
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" /> 
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" />                    
    </div>
    
</div>
    
</asp:Content>
    

