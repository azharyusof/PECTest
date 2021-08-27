<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="RegisterProjectDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="RegisterProjectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

<%--                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             --%>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">REGISTER NEW PROJECT</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Register_New_Project.pdf')"></asp:ImageButton></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>
    
    <table><tr><td height="10"></td></tr></table>

<!-------------------------------------------- Start in-active screen -------------------------------------------->
<div id="dvInactive" runat="server">

    <div class="row">
        <div>
            <div class="col-md-5">                
                <asp:Label ID="lblInactive" runat="server" class="control-label input-xxs" ForeColor="Red">SORRY, YOU ARE NOT ALLOWED TO ACCESS THIS PAGE.</asp:Label>
            </div>
        </div>        
    </div>

    <table><tr><td height="300"></td></tr></table>

</div>
<!-------------------------------------------- End of in-active screen -------------------------------------------->

<!-------------------------------------------- Start active screen -------------------------------------------->
<div id="dvActive" runat="server">
    
    <div class="row">
        <div id="dvCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="lblCode">Promotional Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>
    </div>
        
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
                <asp:DropDownList ID="fldCompany" runat="server" CssClass="form-control input-xxs" Width="240px"></asp:DropDownList>   
                <asp:Label ID="lblBtnSubmit" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
                <asp:Label ID="lblProjDBMigration" runat="server" class="control-label input-xxs" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvUnit" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Unit" for="fldUnit">Operating Unit <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:DropDownList ID="fldUnit" runat="server" CssClass="form-control input-xxs" Width="240px"></asp:DropDownList>
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
                    <asp:DropDownList ID="fldClientName" runat="server" CssClass="form-control input-xxs" Width="280px" OnSelectedIndexChanged="fldClientName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                       
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
                <asp:TextBox ID="fldClientAdd" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Client Address)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOpportunity" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="fldDescription">Project Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldDescription" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="80" PlaceHolder="(Project Name)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvSOW" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Scope of Work" for="fldSOW">Scope of Work <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">                
                <asp:TextBox ID="fldSOW" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="80" PlaceHolder="(Scope of Work)" MaxLength="850"></asp:TextBox>          
            </div>
        </div>
    </div>
    
    <div class="row">
        <div id="dvPM" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Manager" for="fldPM">Project Manager <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPM" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPD" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Director" for="fldPD">Project Director <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPD" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvPIC1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [1]" for="fldPIC1">Person In Charge [1]</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPIC1" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPIC2" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [2]" for="fldPIC2">Person In Charge [2]</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldPIC2" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvHSERep" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HSE Liaison Representative" for="fldHSERep">HSE Liaison Representative</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldHSERep" runat="server" CssClass="form-control input-xxs" Width="250px"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectValue" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Project Value <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectValue" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="cValidator1" ControlToValidate="fldProjectValue" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvProjectFee" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Project Fees <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:Label ID="lblRM1" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectFee" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true"></asp:TextBox> 
                <asp:CompareValidator runat="server" ID="cValidator2" ControlToValidate="fldProjectFee" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Start & End Date" for="fldDate">Project Start & End Date <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtStartDate'>
                        <asp:TextBox ID="fldStartDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>  
                    <asp:Label ID="lblStart" runat="server" class="control-label input-xxs" Text="[start date]"></asp:Label>                    
                </div>
            </div>
            <div class="col-md-2">  
                <div class="form-inline">                    
                    <div class='input-group input-group-xs input-xxs' id='dtEndDate'>
                        <asp:TextBox ID="fldEndDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div><br />
                    <asp:Label ID="lblEnd" runat="server" class="control-label input-xxs" Text="[end date]"></asp:Label>                    
                </div>
            </div>
        </div>
        <div id="dvMargin" runat="server">                      
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Margin" for="fldPercent">Project Margin <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                <asp:TextBox ID="fldPercent" runat="server" CssClass="form-control input-xxs" Width="60px" PlaceHolder="0" CausesValidation="true"></asp:TextBox><asp:Label ID="lblPercent" runat="server" class="control-label input-xxs" Text="%"></asp:Label> 
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
                <asp:TextBox ID="fldContractPeriod" runat="server" CssClass="form-control input-xxs" Width="180px" PlaceHolder="(Contract Period)" MaxLength="450"></asp:TextBox>          
            </div>
        </div>        
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="LOI " for="fldLOI">Letter of Intent (LOI) </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA3" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA3" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnCancelA3" />
                            <asp:PostBackTrigger ControlID="btnUpA3" />
                            <asp:PostBackTrigger ControlID="btnViewA3" />
                            <asp:PostBackTrigger ControlID="btnDeleteA3" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA3Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA3" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA3Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA3" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA3();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA3" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA3_Click" OnClientClick="return validateErrA3();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA3Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA3" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA3" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA3_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA3" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA3_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="LOA " for="fldContractLOA">Letter of Award (LOA) <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA1" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA1" UpdateMode="Conditional">
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
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA1" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA1();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA1" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA1_Click" OnClientClick="return validateErrA1();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA1Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA1" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA1" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA1_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA1" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA1_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
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
                            <asp:PostBackTrigger ControlID="btnCancelA2" />
                            <asp:PostBackTrigger ControlID="btnUpA2" />
                            <asp:PostBackTrigger ControlID="btnViewA2" />
                            <asp:PostBackTrigger ControlID="btnDeleteA2" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA2Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA2" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA2Upload" runat="server" Width="250px" CssClass="form-control input-xs" />
                                                <span class="input-group-btn"><asp:Button ID="btnCancelA2" runat="server" Text="Cancel" CssClass="btn btn-danger btn-xs" OnClientClick="clearUploadA2();" /></span>
                                                <span class="input-group-btn"><asp:Button ID="btnUpA2" runat="server" Text="Upload" CssClass="btn btn-success btn-xs" OnClick="btnUpA2_Click" OnClientClick="return validateErrA2();" /></span>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA2Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA2" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA2" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA2_Click" /></span>
                                            <span class="input-group-btn"><asp:Button ID="btnDeleteA2" runat="server" Text="Delete File" CssClass="btn btn-danger btn-xs" OnClick="btnDeleteA2_Click" OnClientClick = "return confirm('Are you sure you want to delete this file?')" /></span>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Supporting Document" for="fldSupportingDoc">Supporting Document </label> 
                <br />
                    <asp:Label ID="Label3" runat="server" class="control-label input-xxs"><em>(eg: Services Agreement, TOR, MOU)</em></asp:Label>
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
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pec.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/SupportingDoc/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteSupportingDoc"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <%--<EmptyDataTemplate>No Record Found</EmptyDataTemplate>  --%>
    </asp:GridView>
                 
            </div>            
        </div>
    </div>
        
    <div class="row">
        <div id="dvReasonDeviation" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Deviation" for="fldReasonDeviation">Reason For Deviation</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldReasonDeviation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="80" PlaceHolder="(Reason For Deviation)" MaxLength="850"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvDALApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="DAL Approval">DAL Approval </label>
                <br />
                    <asp:Label ID="Label1" runat="server" class="control-label input-xxs"><em>[<b>DAL 3.4:</b> Acceptance of Award Contract]</em></asp:Label>
            </div>
            
            <div class="col-md-10"> 

            <asp:Table ID="tblDALApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="lblDALApproval" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label></asp:TableCell>                            
                        </asp:TableRow>
                
                        <asp:TableRow>  
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblDALA1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALA2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALA3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblDALA4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
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

                                <br /><asp:Label ID="lblDAL_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblDAL_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br /><asp:Label ID="lblDAL_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>

                                <br /><asp:Label ID="lvlDALBOD" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Red" Visible="false">Please submit to BOD or MD/CEO for approval.<br /></asp:Label>

                                <asp:Label ID="lblOldDALRemarks" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="Blue" Visible="false"><br /></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
            </asp:Table>

            <asp:Table ID="tblProjDBApproval" runat="server" Width="60%" CssClass="table table-bordered input-xxs" Visible="false">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">   
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2"><asp:Label ID="Label2" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>DAL Approval</b></asp:Label></asp:TableCell>                            
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

    <div class="row">
        <div id="dvCOOApproval" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="COO Approval">COO Approval </label>
            </div>
            
            <div class="col-md-10"> 

            <asp:Table ID="tblCOOApproval" runat="server" Width="50%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" ColumnSpan="2" Width="50%"><asp:Label ID="Label4" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Approver</b></asp:Label></asp:TableCell>                           
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblCOO1" runat="server" class="control-label input-xxs"><b>Name :</b></asp:Label> 
                                <br /><asp:Label ID="lblCOO2" runat="server" class="control-label input-xxs"><b>Date :</b></asp:Label> 
                                <br /><asp:Label ID="lblCOO3" runat="server" class="control-label input-xxs"><b>Status :</b></asp:Label> 
                                <br /><asp:Label ID="lblCOO4" runat="server" class="control-label input-xxs"><b>Comment :</b></asp:Label> 
                            </asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Left" BackColor="White">
                                <asp:Label ID="lblCOOApprover" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblCOO_ApprovedDate" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblCOO_ApprovedStatus" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                                <br />
                                <asp:Label ID="lblCOO_ApprovedComment" runat="server" class="control-label input-xxs" Font-Italic="true" ForeColor="#666666"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
            </asp:Table>

            </div>
        </div>   
    </div>

    <%--<div class="row">
        <div id="dvPreProjectCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Pre-Regular Code" for="fldPreProjectCode">Pre-Regular Code </label>
            </div>            
            <div class="col-md-6">  
                <div class="form-inline">
                    <asp:TextBox ID="fldPreProjectCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox> &nbsp;&nbsp;<asp:Button ID="btnRequestConversion" runat="server" Text="Code Coversion" CssClass="btn btn-primary btn-xs input-xxs" Width="110" OnClick="btnRequestConversion_Click" />         
                </div>
            </div>
        </div>
    </div>--%>
    
    <div class="row">
        <div id="dvProjectCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code" for="fldProjectCode">Regular Code </label>
            </div>            
            <div class="col-md-6">  
                <div class="form-inline">
                    <asp:TextBox ID="fldProjectCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox> &nbsp;&nbsp;<asp:Button ID="btnChangeManagement" runat="server" Text="Change Management" CssClass="btn btn-warning btn-xs input-xxs" Width="140" OnClick="btnChangeManagement_Click" Visible="false"/> 
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOldCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code (Deltek)" for="fldOldCode">Regular Code (Deltek)</label>
            </div>            
            <div class="col-md-6">  
                <div class="form-inline">
                    <asp:TextBox ID="fldOldCode" runat="server" CssClass="form-control input-xxs" Width="150px" MaxLength="850" Enabled="false"></asp:TextBox> 
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the project info.</asp:Label> 
            </div>
        </div>
    </div>
         
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the project info. No update is allowed when you have submitted this page.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to DAL person for approval. Once approved, Finance will create project code.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Deviation</b> button if <u>LOA</u> is not available and only <u>LOI</u> with effective date is available.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; Email notification will be sent to COO for approval. Once approved, Finance will create regular code.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> For deviation cases, once LOA is secured, upload LOA, and click on <b>Submit</b> button for DAL Approval. Finance will be notified.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-12">
                <asp:Label ID="lblNote5" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> For VO awarded, click <b>Change Management</b> tab, to upload Variation Order / Letter of Acceptance document.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" /> 
        &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger btn-xs input-xxs" Width="65" OnClick="btnSubmit_Click" OnClientClick = "return confirm('Are you sure you want to submit this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnDeviation" runat="server" Text="Deviation" CssClass="btn btn-info btn-xs input-xxs" Width="75" OnClick="btnDeviation_Click" />         
        
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/>          
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->

<!-------------------------------------------- Attachment - Supporting Document -------------------------------------------->
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseE();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblProjectDoc" runat="server" class="control-label input-xxs" Text="New Supporting Document" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputE" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />
            
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


    <script>
        $(function () {
            $('#dtStartDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            $('#dtEndDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true,
                useCurrent: false
            });

            $("#dtStartDate").on("dp.change", function (e) {
                $('#dtEndDate').data("DateTimePicker").minDate(e.date);
            });

            $("#dtEndDate").on("dp.change", function (e) {
                $('#dtStartDate').data("DateTimePicker").maxDate(e.date);
            });
        });
    </script>

    <script type="text/javascript">
        function clearUploadA1() {
            document.getElementById('<%=fldA1Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA1.ClientID%>').className = "form-group";
        }

        function validateErrA1()
        {
            var chckErrA1 = true;

            if (document.getElementById('<%=fldA1Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA1.ClientID%>').className = "form-group has-error";
                chckErrA1 = false;
            }
            return chckErrA1;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA2() {
            document.getElementById('<%=fldA2Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA2.ClientID%>').className = "form-group";
        }

        function validateErrA2()
        {
            var chckErrA2 = true;

            if (document.getElementById('<%=fldA2Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA2.ClientID%>').className = "form-group has-error";
                chckErrA2 = false;
            }
            return chckErrA2;
        }
    </script>

    <script type="text/javascript">
        function clearUploadA3() {
            document.getElementById('<%=fldA3Upload.ClientID%>').value = "";
            document.getElementById('<%=dvA3.ClientID%>').className = "form-group";
        }

        function validateErrA3()
        {
            var chckErrA3 = true;

            if (document.getElementById('<%=fldA3Upload.ClientID%>').value == "")
            {
                document.getElementById('<%=dvA3.ClientID%>').className = "form-group has-error";
                chckErrA3 = false;
            }
            return chckErrA3;
        }
    </script>

    <script type="text/javascript">
        function funcOpenE() {
            $('#myModalE').modal('toggle');
            $('#myModalE').modal('show');
        }

        function funcCloseE() {
            $('#myModalE').modal('hide');
        }
    </script>
</asp:Content>
    


