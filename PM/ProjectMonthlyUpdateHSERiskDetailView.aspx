<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectMonthlyUpdateHSERiskDetailView.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectMonthlyUpdateHSERiskDetailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProjectMonthlyUpdateDetailView.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncomingView.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetailView.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrailView.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetailView.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">PROJECT MONTHLY UPDATE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Project_Execution.pdf')"></asp:ImageButton></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

    <table><tr><td height="10"></td></tr></table>

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
                    <li ID="Li1" runat="server"><a href='ProjectMonthlyUpdateDetailView.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label21" runat="server" class="control-label input-xxs" Text="PROJECT STATUS"></asp:Label></a></li>
                    
                    <li ID="Li2" runat="server"><a href='ProjectMonthlyUpdateCostSheetDetailView.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="Label15" runat="server" class="control-label input-xxs" Text="COST SHEET"></asp:Label></a></li>
                    
                    <li ID="Li3" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="Label17" runat="server" class="control-label input-xxs" Text="RISK"></asp:Label></a></li>
                    
                </ul>


    <table><tr><td height="12"></td></tr></table>


    <div class="row">
        <div id="dvBeaconReport" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Report From Beacon" for="fldBeaconReport">Risk Report</label>
            </div>
            
            <div class="col-md-10"> 
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150" runat="server" disabled>&nbsp;&nbsp;New Risk Report&nbsp;&nbsp;</button>
                <br />

            <asp:GridView ID="gvBeaconReport" runat="server" Width="60%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs">
            <Columns>                
            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                   <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="50%" ItemStyle-Width="50%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/BeaconReport/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString()%></asp:HyperLink>            
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFileName" runat="server" Text='<%# Eval("FileName")%>' CssClass="form-control input-xxs" Width="280px"></asp:TextBox>
                </EditItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action Required" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblActionRequired" runat="server" Text='<%# Eval("ActionRequired")%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
                <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
            </asp:GridView>
                
            </div>            
        </div>
    </div>
           
    <table><tr><td height="12"></td></tr></table>
    

    <img src="Img/images2.png"/> <asp:Label ID="Label3" runat="server" class="control-label input-xxs" Text="Risk Assessment / Register" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>

        
     <div class="row">
        <div id="dvRiskAssessment" runat="server">
                        
            <div class="col-md-12"> 
                
                <table runat="server" width="100%">
                    <tr>
                    <td align="left">
                        <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalC" data-toggle="modal" width="150" runat="server" disabled>&nbsp;&nbsp;New Risk Assessment / Register&nbsp;&nbsp;</button>    
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="btnHeatMap" runat="server" ImageUrl="img/info.jpg" ToolTip="Risk Heat Map" OnClientClick="window.open('TableHeatMap.aspx', 'newwindow', 'width=700,height=450,toolbar=no'); return false;"></asp:ImageButton>  
                    </td>
                    </tr>
                </table>

    <asp:GridView ID="gvRiskAssessment" runat="server" Width="100%" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvRiskAssessment_OnPageIndexChanging" CssClass="table table-bordered table-striped input-xxs" OnRowCreated="gvRiskAssessment_RowCreated" OnRowDataBound="gvRiskAssessment_RowDataBound">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
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
        <EditItemTemplate>
                <asp:DropDownList ID="txtGrossRating" runat="server" CssClass="form-control input-xxs" Width="120px"></asp:DropDownList> 
            
                        <asp:TextBox ID="txtGrossRatingId" runat="server" Text='<%# Eval("GrossRating")%>' CssClass="form-control input-xxs" Width="280px" Visible="false"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Existing Control" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblExistingControl" runat="server" Text='<%# Eval("ExistingControl").ToString() != "" ? Eval("ExistingControl").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtExistingControl" runat="server" Text='<%# Eval("ExistingControl")%>' CssClass="form-control input-xxs" Width="120px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Likelihood" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblLikelihood" runat="server" Text='<%# Eval("Likelihood").ToString() != "" ? Eval("Likelihood").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtLikelihood" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Likelihood")%>'>
                    <asp:ListItem Value="Certain" Text="Certain" ></asp:ListItem>
                    <asp:ListItem Value="Likely" Text="Likely" ></asp:ListItem>
                    <asp:ListItem Value="Possible" Text="Possible" ></asp:ListItem>
                    <asp:ListItem Value="Unlikely" Text="Unlikely" ></asp:ListItem>
                    <asp:ListItem Value="Remote" Text="Remote" ></asp:ListItem>
                </asp:DropDownList>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Impact" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact").ToString() != "" ? Eval("Impact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
                <asp:DropDownList ID="txtImpact" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Eval("Impact")%>'>
                    <asp:ListItem Value="Insignificant" Text="Insignificant" ></asp:ListItem>
                    <asp:ListItem Value="Minor" Text="Minor" ></asp:ListItem>
                    <asp:ListItem Value="Moderate" Text="Moderate" ></asp:ListItem>
                    <asp:ListItem Value="Major" Text="Major" ></asp:ListItem>
                    <asp:ListItem Value="Catastrophic" Text="Catastrophic" ></asp:ListItem>
                </asp:DropDownList>
        </EditItemTemplate> 
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
        <EditItemTemplate>
            <asp:TextBox ID="txtMitigation" runat="server" Text='<%# Eval("Mitigation")%>' CssClass="form-control input-xxs" Width="120px" TextMode="MultiLine" Height="60"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>  
        
    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
        
        <asp:DropDownList ID="txtStatus" CssClass="form-control input-xxs" Width="80" runat="server" SelectedValue='<%# Bind("Status") %>'>
                    <asp:ListItem Value="Open" Text="Open" ></asp:ListItem>
                    <asp:ListItem Value="Closed" Text="Closed" ></asp:ListItem>
                </asp:DropDownList>

    </EditItemTemplate> 
    </asp:TemplateField>
    </Columns>
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
    </asp:GridView>
                
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Report</b> button to upload HSE related report.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Risk Assessment</b> button to create risk assessment record.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> <b>Risk Assessment</b> record is linked with <b>Risk Assessment</b> in Project Initiation module.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" /> 
           
    </div>

    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblProjectDoc" runat="server" class="control-label input-xxs" Text="New Risk Report" Font-Bold="true"></asp:Label>
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

            <div class="row">
                <div id="dvActionReq" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Action Required" for="fldActionRequired">Action Required</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldActionRequired" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Action Required)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div id="dvStatus" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Status" for="fldStatus">Status</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldStatus" runat="server" CssClass="form-control input-xxs" Width="165px"></asp:DropDownList> 
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


    <div class="modal fade" id="myModalC" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXC" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="Label1" runat="server" class="control-label input-xxs" Text="New Risk Assessment" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputC" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />

            <div class="row">
                <div id="dvAssessDate" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date" for="fldAssessDate">Date <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtAssessDate'>
                        <asp:TextBox ID="fldAssessDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvRiskCategory" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk Category" for="fldRiskCategory">Risk Category <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldRiskCategory" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList> 
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div id="dvRiskTitle" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk Title" for="fldRiskTitle">Risk Title <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldRiskTitle" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Risk Title)" CausesValidation="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div id="dvRiskDescription" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Risk Description" for="fldRiskDescription">Risk Description <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldRiskDescription" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Risk Description)" CausesValidation="true" TextMode="MultiLine" Height="60"></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div id="dvGrossRating" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Gross Rating" for="fldGrossRating">Gross Rating <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldGrossRating" runat="server" CssClass="form-control input-xxs" Width="200px"></asp:DropDownList> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvExistingControl" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Existing Control" for="fldExistingControl">Existing Control <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldExistingControl" runat="server" CssClass="form-control input-xxs" Width="320px" PlaceHolder="(Existing Control)" CausesValidation="true"></asp:TextBox>
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

            <br />
            
            <asp:Button ID="btnSaveC" runat="server" Text="Save" CssClass="btn btn-danger btn-xs input-xxs" Width="50" OnClick="btnSaveC_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnCloseC" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="105" data-dismiss="modal" OnClick="btnCloseC_Click" UseSubmitBehavior="false" />
        </div>
    </div>
    </div>
    </div>

</div>

    <script>
        $(function () {
            $('#dtAssessDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            
        });
    </script>
    <script type="text/javascript">
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

</asp:Content>
    


