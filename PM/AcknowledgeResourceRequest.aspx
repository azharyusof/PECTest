<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="AcknowledgeResourceRequest.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="AcknowledgeResourceRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

<div class="panel-heading">PROJECT INITIATION</div>
<div class="panel-body">

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="lblDescription">Project Name </label>
            </div>            
            <div class="col-md-4">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs">(Project Name)</asp:Label>
            </div>
        </div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Code" for="lblCode">Project Code </label>
            </div>            
            <div class="col-md-2">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>
    </div>

    <table><tr><td height="5"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Project Initiation" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvKickOffMeeting" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Kick-Off Meeting Performed?" for="cbKickOffMeeting">Contract Kick-Off Meeting Performed? </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbKickOffMeeting" runat="server" Enabled="false"/>
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Service Agreement" for="fldServiceAgreement">Service Agreement </label>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Execution Plan" for="fldExecutionPlan">Project Execution Plan </label>
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
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Legal Register" for="fldLegalRegister">Legal Register </label> 
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA4" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA4" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA4" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA4Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA4" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA4Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="False"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA4Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA4" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA4" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA4_Click" /></span>
                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
        <div class="col-md-1">   </div>
        <div id="dvLegalRegisterComment" runat="server">    
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldLegalRegisterComment">Justification <br />(If None) </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldLegalRegisterComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>
    

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HIRARC" for="fldHIRARC">HIRARC </label> 
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA5" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA5" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA5" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA5Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA5" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA5Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="false"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA5Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA5" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA5" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA5_Click" /></span>
                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
        <div class="col-md-1">   </div>
        <div id="dvHIRARC" runat="server">    
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldHIRARC">Justification <br />(If None) </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldHIRARCComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Environmental Aspect & Impact" for="fldEAI">Environmental Aspect & Impact </label> 
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA6" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA6" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA6" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA6Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA6" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA6Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="false"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA6Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA6" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA6" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA6_Click" /></span>
                                            
                                        </div>
                                    </div>
                                </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>

            </div>            
        </div>
        <div class="col-md-1">   </div>
        <div id="dvEAI" runat="server">    
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldEAI">Justification <br />(If None) </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldEAIComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>


    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="HSE Plan" for="fldHSEPlan">HSE Plan </label> 
            </div>            
            <div class="col-md-3">                
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

            </div>            
        </div>
        <div class="col-md-1">   </div>
        <div id="dvHSEPlanComment" runat="server">    
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Justification" for="fldHSEPlanComment">Justification <br />(If None) </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldHSEPlanComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Justification)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>


    <div class="row">
        <div id="dvProjectDoc" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Relevant Project Document" for="fldProjectDoc">Relevant Project Document </label>
            </div>
            
            <div class="col-md-10"> 
                
    <asp:GridView ID="gvProjectDoc" runat="server" Width="50%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/ProjectDocument/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <div class="row">
        <div id="dvFinancialPlanning" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Request Finance to Approve Financial Planning" for="cbFinancialPlanning">Request Finance to Approve Financial Planning </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbFinancialPlanning" runat="server" Enabled="false"/>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvResourceRequest" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Resource Request" for="cbResourceRequest">Resource Request </label>
            </div>            
            <div class="col-md-3">                
                <asp:CheckBox ID="cbResourceRequest" runat="server" Enabled="false"/>
            </div>            
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Organization Chart" for="fldOrgChart">Organization Chart </label>
            </div>            
            <div class="col-md-3">                
                <asp:HiddenField ID="hidURLA7" runat="server" />
                <asp:UpdatePanel runat="server" id="UpA7" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnViewA7" />
                        </Triggers>
                        <ContentTemplate>
                           
                                <div id="dvUpA7Sec" runat="server" class="row">
                                    <div class="col-md-3"> 
                                        <div id="dvA7" runat="server" class="form-group">
                                            <div class="input-group input-group-xs">
                                                <asp:FileUpload ID="fldA7Upload" runat="server" Width="250px" CssClass="form-control input-xs" Enabled="false"/>
                                                
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="dvVwA7Sec" runat="server" class="row">
                                    <div class="col-md-3">
                                        <div class="input-group input-group-xs">
                                            <asp:Label ID="lblURLA7" runat="server" CssClass="form-control input-xs" Width="250px"/>
                                            <span class="input-group-btn"><asp:Button ID="btnViewA7" runat="server" Text="View File" CssClass="btn btn-primary btn-xs" OnClick="btnViewA7_Click" /></span>
                                            
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

    

    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Risk Assessment" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    
    <table><tr><td height="12"></td></tr></table>

         
    <div class="row">
        <div id="dvRiskAssessment" runat="server">
                        
            <div class="col-md-12"> 
                                
    <asp:GridView ID="gvRiskAssessment" runat="server" Width="100%" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvRiskAssessment_OnPageIndexChanging" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblAssessDate" runat="server" Text='<%# Eval("AssessDate", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Category" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskCategory" runat="server" Text='<%# Eval("RiskCategory")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Title" HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskTitle" runat="server" Text='<%# Eval("RiskTitle")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Description <br>(Include Cost & Impact of Risk)" HeaderStyle-Width="30%" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskDescription" runat="server" Text='<%# Eval("RiskDescription")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Gross Rating" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblGrossRating" runat="server" Text='<%# Eval("GrossRating").ToString() != "" ? Eval("GrossRating").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Existing Control" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblExistingControl" runat="server" Text='<%# Eval("ExistingControl").ToString() != "" ? Eval("ExistingControl").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Likelihood" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblLikelihood" runat="server" Text='<%# Eval("Likelihood").ToString() != "" ? Eval("Likelihood").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Impact" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact").ToString() != "" ? Eval("Impact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Rating" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRiskRating" runat="server" Text='<%# Eval("RiskRating").ToString() != "" ? Eval("RiskRating").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>   

    <asp:TemplateField HeaderText="Mitigation" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblMitigation" runat="server" Text='<%# Eval("Mitigation").ToString() != "" ? Eval("Mitigation").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>  
        
    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    </Columns>
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
            </div>            
        </div>
    </div>

       
    <table><tr><td height="12"></td></tr></table>    

    <img src="Img/images2.png"/> <asp:Label ID="Label12" runat="server" class="control-label input-xxs" Text="Project Director Approval Status" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvApprover" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Acknowledged By" for="lblApprover">Acknowledged By </label>
            </div>            
            <div class="col-md-3">                  
                <asp:Label ID="lblApprover" runat="server" CssClass="input-xxs" Text="Human Resource"></asp:Label>       
            </div>
        </div>
    </div>
    
   <div class="row">
        <div id="dvApprove" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Acknowledged" for="lblDtApproved">Date Acknowledged </label>
            </div>            
            <div class="col-md-10">                
                <asp:Label ID="lblDtApproved" runat="server" CssClass="control-label input-xxs" ForeColor="Blue"></asp:Label>   
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Acknowledge</b> button to acknowledge this project.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1a" runat="server" class="control-label input-xxs" Font-Italic="true">&nbsp;&nbsp;&nbsp;&nbsp; When you have acknowledged this project, email notification will be sent to Project Manager for info.</asp:Label> 
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
        <asp:Button ID="btnAcknowledge" runat="server" Text="Acknowledge" CssClass="btn btn-success btn-xs input-xxs" Width="95" OnClick="btnAcknowledge_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" />                    
    </div>
        
</asp:Content>
    



