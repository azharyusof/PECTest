<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="CreateOpportunityCode.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="CreateOpportunityCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

<div class="panel-heading">OPPORTUNITY GO / NO-GO</div>
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

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Start & End Date" for="lblProjectStartEnd">Estimated Project Start & End Date </label>
            </div>            
            <div class="col-md-3">                
                <asp:Label ID="lblProjectStartEnd" runat="server" class="control-label input-xxs">(Estimated Project Start & End Date)</asp:Label>
            </div>
        </div>
        <div class="col-md-1"></div>
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="lblClientAddress">Client Address </label>
            </div>            
            <div class="col-md-3">                
                <asp:Label ID="lblClientAddress" runat="server" class="control-label input-xxs">(Client Address)</asp:Label>
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Nature of Client" for="fldClientNature">Nature of Client </label>
            </div>
            
            <div class="col-md-3">                
                <asp:TextBox ID="fldClientNature" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Nature of Client)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>        
    </div>

    <div class="row">
        <div id="dvStrategicClient" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Strategic Client?" for="fldStrategicClient">Strategic Client? </label>
            </div>            
            <div class="col-md-8">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldStrategicClient" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList> 
                    <asp:TextBox ID="fldStrategicClientComment" runat="server" CssClass="form-control input-xxs" Width="400px" PlaceHolder="(Comment)" MaxLength="850" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvStatusRel" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Status of Relationship" for="fldStatusRel">Status of Relationship </label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldStatusRel" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvPymntHistory" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Payment History" for="fldPymntHistory">Payment History </label>
            </div>
            <div class="col-md-1">  
                <asp:DropDownList ID="fldPymntHistory" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>
    
    <img src="Img/images2.png"/> <asp:Label ID="Label2" runat="server" class="control-label input-xxs" Text="Competition" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvCompetitorNo" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="How Many?" for="fldCompetitorNo">How Many? </label>
            </div>
            
            <div class="col-md-3">                
                <asp:TextBox ID="fldCompetitorNo" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
        <div class="col-md-1"></div> 
        <div id="dvCompetitorList" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Who Are The Competitors?" for="fldCompetitorList">Who Are The Competitors? </label>
            </div>            
            <div class="col-md-2">  
                <asp:TextBox ID="fldCompetitorList" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Who Are The Competitors?)" MaxLength="850" Enabled="false"></asp:TextBox>  
            </div> 
        </div>
    </div>

    <div class="row">
        <div id="dvCanCompete" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Can We Compete?" for="fldCanCompete">Can We Compete? </label>
            </div>            
            <div class="col-md-8">  
                 <div class="form-inline">
                    <asp:DropDownList ID="fldCanCompete" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList> 
                     <asp:TextBox ID="fldCanCompeteComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850" Enabled="false"></asp:TextBox> 
                 </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvMaterializingPercent" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Chances of Project Materializing" for="fldMaterializingPercent">Chances of Project Materializing </label>
            </div>            
            <div class="col-md-8">  
                <div class="form-inline">
                    <asp:TextBox ID="fldMaterializingPercent" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850" Enabled="false"></asp:TextBox><asp:Label ID="lblPercent" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                    <asp:TextBox ID="fldMaterializingComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvWinningPercent" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Chances of Winning" for="fldWinningPercent">Chances of Winning </label>
            </div>            
            <div class="col-md-8">  
                <div class="form-inline">
                    <asp:TextBox ID="fldWinningPercent" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850" Enabled="false"></asp:TextBox><asp:Label ID="lblPercent1" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                    <asp:TextBox ID="fldWinningComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>
    </div>
    
    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="Label4" runat="server" class="control-label input-xxs" Text="Finances" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvProjectValue" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Project Value" for="fldProjectValue">Potential Project Value </label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectValue" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvProjectFees" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Project Fees" for="fldProjectFees">Potential Project Fees </label>
            </div>
            <div class="col-md-2">  
                <div class="form-inline">
                    <asp:Label ID="lblRM1" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldProjectFees" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>
    </div>
    

    <div class="row">
        <div id="dvPotentialMargin" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Margin" for="fldPotentialMargin">Potential Gross Profit </label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <asp:TextBox ID="fldPotentialMargin" runat="server" CssClass="form-control input-xxs" Width="80px" Enabled="false"></asp:TextBox><asp:Label ID="lblPercent3" runat="server" class="control-label input-xxs" Text="%"></asp:Label>  
                </div>
            </div>
        </div>
        <div class="col-md-1"></div>
        <div id="dvPotentialBudget" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Pursuit Budget" for="fldPotentialBudget">Potential Pursuit Budget </label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <asp:Label ID="lblRM3" runat="server" class="control-label input-xxs" Text="RM"></asp:Label><asp:TextBox ID="fldPotentialBudget" runat="server" CssClass="form-control input-xxs" Width="100px" PlaceHolder="0.00" CausesValidation="true" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>
    </div>

     <div class="row">
        <div id="dvBudgetMargin" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Potential Pursuit Budget / Margin" for="fldBudgetMargin">Potential Pursuit Budget / Potential Gross Profit </label>
            </div>            
            <div class="col-md-4">  
                <div class="form-inline">
                    <asp:TextBox ID="fldBudgetMargin" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0.00" MaxLength="850" Enabled="false"></asp:TextBox><asp:Label ID="Label5" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    

    <img src="Img/images2.png"/> <asp:Label ID="Label6" runat="server" class="control-label input-xxs" Text="Project Specific" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvContractType" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Type" for="fldContractType">Contract Type </label>
            </div>
            <div class="col-md-3">                 
                <asp:DropDownList ID="fldContractType" runat="server" CssClass="form-control input-xxs" Width="250px" Enabled="false"></asp:DropDownList>  
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvContractDuration" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Contract Duration" for="fldContractDuration">Contract Duration </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldContractDuration" runat="server" CssClass="form-control input-xxs" Width="180px" PlaceHolder="(Contract Duration)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>        
    </div>

    <div class="row">
        <div id="dvDetailedScopeWork" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Detailed Scope of Work" for="fldDetailedScopeWork">Detailed Scope of Work </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldDetailedScopeWork" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="100" PlaceHolder="(Detailed Scope of Work)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOurCapability" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Our Capability to Execute" for="fldOurCapability">Our Capability to Execute </label>
            </div>
            <div class="col-md-8">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldOurCapability" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList> 
                     <asp:TextBox ID="fldOurCapabilityComment" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Comment)" MaxLength="850" Enabled="false"></asp:TextBox> 
                </div>
            </div>
        </div>        
    </div>

     <div class="row">
        <div id="dvOurDifferentiation" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Our Differentiation" for="fldOurDifferentiation">Our Differentiation </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldOurDifferentiation" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Our Differentiation)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>            
        </div>
        <div class="col-md-1"></div>
        <div id="dvTrackRecord" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Do We Have Track Record / Experience?" for="fldTrackRecord">Do We Have Track Record / Experience? </label>
            </div>            
            <div class="col-md-2">                 
                <asp:DropDownList ID="fldTrackRecord" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvPartnerReq" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Partner Required?" for="fldSOW">Partner Required? </label>
            </div>            
            <div class="col-md-8">  
                <div class="form-inline">
                    <asp:DropDownList ID="fldPartnerReq" runat="server" CssClass="form-control input-xxs" Width="150px" Enabled="false"></asp:DropDownList> 
                    <asp:TextBox ID="fldPartnerReqComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Comment - Who & Why)" MaxLength="850" Enabled="false"></asp:TextBox> 
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

    <asp:GridView ID="gvProjectRisk" runat="server" Width="85%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowCreated="gvProjectRisk_RowCreated" OnRowDataBound="gvProjectRisk_RowDataBound">
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

    <asp:TemplateField HeaderText="Mitigation" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblMitigation" runat="server" Text='<%# Eval("Mitigation").ToString() != "" ? Eval("Mitigation").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>   
    </Columns>
        <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-xxs"></asp:Label></EmptyDataTemplate>
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

    <asp:GridView ID="gvContractRisk" runat="server" Width="85%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" OnRowCreated="gvContractRisk_RowCreated" OnRowDataBound="gvContractRisk_RowDataBound">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Risk Description <br>(Include Cost & Impact of Risk)" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblRisk" runat="server" Text='<%# Eval("ContractRisk")%>' CssClass="input-xxs"></asp:Label>
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

    <asp:TemplateField HeaderText="Mitigation" HeaderStyle-Width="35%" ItemStyle-Width="35%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblMitigation" runat="server" Text='<%# Eval("Mitigation").ToString() != "" ? Eval("Mitigation").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>   
    </Columns>
        <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-xxs"></asp:Label></EmptyDataTemplate>
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <table><tr><td height="12"></td></tr></table>    

    <img src="Img/images2.png"/> <asp:Label ID="Label9" runat="server" class="control-label input-xxs" Text="Evaluation" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvEvaluationPerson" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Person / Committee" for="fldEvaluationPerson">Evaluation Person / Committee </label>
            </div>
            
            <div class="col-md-10"> 

    <asp:GridView ID="gvEvaluationPerson" runat="server" Width="60%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="Label10" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="Label11" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Evaluation Person / Committee" HeaderStyle-Width="80%" ItemStyle-Width="80%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblCommitteeMember" runat="server" Text='<%# Eval("CommitteeName")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Role" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-xxs"></asp:Label></EmptyDataTemplate>
    </asp:GridView>
                
            </div>            
        </div>
    </div>


    <div class="row">
        <div id="dvEvaluationComment" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Evaluation Comment / Justification" for="fldEvaluationComment">Evaluation Comment / Justification </label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldEvaluationComment" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="100" PlaceHolder="(Evaluation Comment / Justification)" MaxLength="850" Enabled="false"></asp:TextBox> 
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
        <div id="dvDecision" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Go / No-Go Decision" for="fldDecision">Go / No-Go Decision </label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldDecision" runat="server" CssClass="form-control input-xxs" Width="100px" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvCode" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Promotional Code" for="fldCode">Promotional Code <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldCode" runat="server" CssClass="form-control input-xxs" Width="180px" PlaceHolder="(Promotional Code)" MaxLength="80"></asp:TextBox> 
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to create the promotional code. Email notification will be sent to Project Manager for info.</asp:Label> 
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
    
