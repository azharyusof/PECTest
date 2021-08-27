<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectMonthlyUpdateDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectMonthlyUpdateDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
<script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

<%--                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             --%>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
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
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Regular Code" for="lblCode">Regular Code </label>
            </div>
            
            <div class="col-md-3">                
                <asp:Label ID="lblCode" runat="server" class="control-label input-xxs"></asp:Label>
            </div>
        </div>        
    </div>

                <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT STATUS"></asp:Label></a></li>
                    
<%--                    <li ID="tab2" runat="server"><a href='ProjectMonthlyUpdateCostSheetDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="COST SHEET"></asp:Label></a></li>--%>
                    <li ID="tab3" runat="server"><a href='ProjectMonthlyUpdateHSERiskDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblThree" runat="server" class="control-label input-xxs" Text="RISK"></asp:Label></a></li>
                    
                </ul>

    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvProjectDoc" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Document " for="fldProjectDoc">Project Document  </label>
            </div>
            
            <div class="col-md-10"> 
                
                <table runat="server" width="100%">
                    <tr>
                    <td align="rileftght">
                        <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalE" data-toggle="modal" width="150">&nbsp;&nbsp;New Project Document&nbsp;&nbsp;</button>
                    </td>
                    <td align="right">
                        <div class="form-inline">
                            <asp:TextBox ID="fldSearch" runat="server" CssClass="form-control input-xxs" Width="250px" PlaceHolder="(Search Keyword)"></asp:TextBox> 
                                &nbsp;<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="Img/search1.png" AlternateText="Search" Width="16" Height="15" OnClick="btnSearch_Click" ImageAlign="Middle"/>                                
                                &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="Img/delete1.png" AlternateText="Clear" Width="19" Height="18" OnClick="btnClear_Click" ImageAlign="Middle" Visible="false"/>
                        </div>
                    </td>
                    </tr>
                </table>


            <asp:GridView ID="gvProjectDoc" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-striped input-xxs" onrowediting="EditProjectDoc" onrowupdating="UpdateProjectDoc" onrowcancelingedit="CancelProjectDocEdit">
            <Columns>                
            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
                   <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="25%" ItemStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "http://pectest.uemedgenta.com/PM/Upload/" + Request.QueryString["ID"] + "/MonthlyProjectDocument/" + Eval("FileName") + "" %>' Target="_blank"><%# Eval("FileName").ToString().HighlightKeyWords(search_Word, "yellow", false)%></asp:HyperLink>            
                </ItemTemplate>
                
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="25%" ItemStyle-Width="25%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().HighlightKeyWords(search_Word, "yellow", false)%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description")%>' CssClass="form-control input-xxs" Width="180px"></asp:TextBox>
                </EditItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Received From" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblReceivedFrom" runat="server" Text='<%# Eval("ReceivedFrom").ToString() != "" ? Eval("ReceivedFrom").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox ID="txtReceivedFrom" runat="server" Text='<%# Eval("ReceivedFrom")%>' CssClass="form-control input-xxs" Width="180px"></asp:TextBox>
                </EditItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Received" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                <ItemTemplate>
                    <asp:Label ID="lblDateReceived" runat="server" Text='<%# Eval("DateReceived").ToString() != "" ? Eval("DateReceived", "{0:dd-MMM-yyyy}") : "-"%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Submit To" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblSubmitTo" runat="server" Text='<%# Eval("SubmitTo").ToString() != "" ? Eval("SubmitTo").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox ID="txtSubmitTo" runat="server" Text='<%# Eval("SubmitTo")%>' CssClass="form-control input-xxs" Width="180px"></asp:TextBox>
                </EditItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date Submitted" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                <ItemTemplate>
                    <asp:Label ID="lblDateSubmitted" runat="server" Text='<%# Eval("DateSubmitted").ToString() != "" ? Eval("DateSubmitted", "{0:dd-MMM-yyyy}") : "-"%>' CssClass="input-xxs"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this file?')" OnClick="DeleteProjectDoc"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>            
            <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" />
        </ItemTemplate>
        <EditItemTemplate>   
            <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update" ></asp:ImageButton>  
            <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>  
        </EditItemTemplate> 
    </asp:TemplateField>

            </Columns>
                <EmptyDataTemplate>No Record Found</EmptyDataTemplate>  
            </asp:GridView>
                
            </div>            
        </div>
    </div>
       
    <table><tr><td height="12"></td></tr></table>

    <img src="Img/images2.png"/> <asp:Label ID="lblHeader1" runat="server" class="control-label input-xxs" Text="Project Status" Font-Bold="true"></asp:Label>

    <table><tr><td height="5"></td></tr></table>

    <div style="width: 100%;">
        <div style="border: 1px solid darkgray; height: 2px;">
        </div>
    </div>

    <table><tr><td height="12"></td></tr></table>
    
    <div class="row">
        <div id="dvMonthlyUpdate" runat="server">
                        
            <div class="col-md-12"> 
                
                <button class="btn btn-warning btn-xs input-xxs" onclick="javascript: return false;" data-target="#myModalC" data-toggle="modal" width="150">&nbsp;&nbsp;New Project Status&nbsp;&nbsp;</button>
                &nbsp;&nbsp;<asp:Button ID="btnManageWP" runat="server" Text="Work Package" CssClass="btn btn-success btn-xs input-xxs" Width="103" OnClick="btnManageWP_Click" /> 
                <br /><br />

                <div class="row">
                    <div id="dvWPCode" runat="server">
                        <div class="col-md-2">
                            <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true">Code</label>
                        </div>
                        <div class="col-md-4; form-inline">  
                            <asp:DropDownList ID="fldWP" runat="server" CssClass="form-control input-xxs" Width="240px" AutoPostBack="True" OnSelectedIndexChanged="fldWP_SelectedIndexChanged"></asp:DropDownList> 
                        </div>
                    </div>                    
                </div>
                <div class="row">
                    <div id="dvWP" runat="server">
                        <div class="col-md-2">
                            <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true">Work Package</label>
                        </div>
                        <div class="col-md-4; form-inline">  
                             <asp:Label ID="lblWP" runat="server" CssClass="form-control input-xxs" Width="700px" BackColor="#eeeeee"></asp:Label>
                        </div>
                    </div>
                </div>

    <asp:GridView ID="gvMonthlyUpdate" runat="server" Width="100%" AutoGenerateColumns="false" PageSize="5" AllowPaging="true"  OnPageIndexChanging="gvMonthlyUpdate_OnPageIndexChanging" CssClass="table table-bordered table-striped input-xxs" onrowediting="EditMonthlyUpdate" onrowupdating="UpdateMonthlyUpdate" onrowcancelingedit="CancelMonthlyUpdateEdit" OnRowDataBound="gvMonthlyUpdate_RowDataBound">
    <Columns>                
    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
       <ItemTemplate>
            <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>
           <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' CssClass="input-xxs" Visible="false"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Work Package" HeaderStyle-Width="10%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblPkg" runat="server" Text='<%# Eval("WorkPackage")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>

        <EditItemTemplate>
            <asp:DropDownList ID="ddlPkg" runat="server" CssClass="form-control input-xxs" Width="100px"></asp:DropDownList>

            <asp:TextBox ID="ddlPkgCode" runat="server" Text='<%# Eval("WorkPackage")%>' CssClass="form-control input-xxs" Width="100px" Visible="false"></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Date <br>(dd-mmm-yyyy)" HeaderStyle-Width="10%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date", "{0:dd-MMM-yyyy}")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("Date", "{0:dd-MMM-yyyy}")%>' CssClass="form-control input-xxs" Width="100px"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Status / Issues" HeaderStyle-Width="15%" ItemStyle-Width="30%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblIssues" runat="server" Text='<%# Eval("Issues")%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtIssues" runat="server" Text='<%# Eval("Issues")%>' CssClass="form-control input-xxs" Width="160px" TextMode="MultiLine" Height="80"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Schedule" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblProjectSchedule" runat="server" Text='<%# Eval("ProjectSchedule").ToString() != "" ? Eval("ProjectSchedule").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>Days
        </ItemTemplate>
        <EditItemTemplate>
                <asp:TextBox ID="txtProjectSchedule" runat="server" Text='<%# Eval("ProjectSchedule")%>' CssClass="form-control input-xxs" Width="40px"></asp:TextBox>Days
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Planned" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblPlanned" runat="server" Text='<%# Eval("Planned")%>' CssClass="input-xxs"></asp:Label>%
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtPlanned" runat="server" Text='<%# Eval("Planned")%>' CssClass="form-control input-xxs" Width="40px"></asp:TextBox>%
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Actual" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblActual" runat="server" Text='<%# Eval("Actual")%>' CssClass="input-xxs"></asp:Label>%
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtActual" runat="server" Text='<%# Eval("Actual")%>' CssClass="form-control input-xxs" Width="40px"></asp:TextBox>%
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Impact" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblImpact" runat="server" Text='<%# Eval("Impact").ToString() != "" ? Eval("Impact").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtImpact" runat="server" Text='<%# Eval("Impact")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>  
        
    <asp:TemplateField HeaderText="Activity Planned for The Month" HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblActivityPlannedForMonth" runat="server" Text='<%# Eval("ActivityPlannedForMonth").ToString() != "" ? Eval("ActivityPlannedForMonth").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtActivityPlannedForMonth" runat="server" Text='<%# Eval("ActivityPlannedForMonth")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Action to Be <br>Taken" HeaderStyle-Width="15%" ItemStyle-Width="10%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
        <ItemTemplate>
            <asp:Label ID="lblActionToBeTaken" runat="server" Text='<%# Eval("ActionToBeTaken").ToString() != "" ? Eval("ActionToBeTaken").ToString() : "-"%>' CssClass="input-xxs"></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtActionToBeTaken" runat="server" Text='<%# Eval("ActionToBeTaken")%>' CssClass="form-control input-xxs" Width="140px" TextMode="MultiLine" Height="80"></asp:TextBox>
        </EditItemTemplate> 
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" ImageUrl="img/remove.png" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID")%>' OnClientClick = "return confirm('Are you sure you want to remove this record?')" OnClick="DeleteMonthlyUpdate"/>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center">
        <ItemTemplate>            
            <asp:ImageButton ID="imgEdit" ImageUrl="img/edit.png" CommandName="Edit" runat="server" />
        </ItemTemplate>
        <EditItemTemplate>   
            <asp:ImageButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" ImageUrl="img/save.png" ToolTip="Update" ></asp:ImageButton>  
            <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" ImageUrl="img/back.png" ToolTip="Cancel" CausesValidation="False"></asp:ImageButton>  
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Project Document</b> button to upload project document.</asp:Label> 
            </div>
        </div>
    </div>
         
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>New Project Status</b> button to create project status record.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Work Package</b> button to add work package, if required.</asp:Label> 
            </div>
        </div>
    </div>
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/>            
    </div>

</div>
<!-------------------------------------------- End of active screen -------------------------------------------->
    
    <div class="modal fade" id="myModalE" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
            <asp:LinkButton ID="lbtnCloseXE" runat="server" CssClass="close" data-dismiss="modal" OnClientClick="funcCloseC();" Width="10" UseSubmitBehavior="false">&times;</asp:LinkButton>
            <img src="Img/images2.png"/> <asp:Label ID="lblProjectDoc" runat="server" class="control-label input-xxs" Text="New Project Document" Font-Bold="true"></asp:Label>
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
                <div id="dvDescription" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Description" for="fldDescription">Description <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldDescription" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(Description)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvReceivedFrom" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Received From" for="fldReceivedFrom">Received From</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldReceivedFrom" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(Received From)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div id="dvDateReceived" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Received" for="fldDateReceived">Date Received</label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtDateReceived'>
                        <asp:TextBox ID="fldDateReceived" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvSubmitTo" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Submit To" for="SubmitTo">Submit To</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldSubmitTo" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(Submit To)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvDateSubmitted" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Submitted" for="fldDateSubmitted">Date Submitted</label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtDateSubmitted'>
                        <asp:TextBox ID="fldDateSubmitted" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
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
            <img src="Img/images2.png"/> <asp:Label ID="lblContract" runat="server" class="control-label input-xxs" Text="New Project Status" Font-Bold="true"></asp:Label>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblErrInputC" runat="server" CssClass="label label-danger input-sm">Please fill in the required fields.</asp:Label> 
            <br /><br />

            <div class="row">
                <div id="dvPkg" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Pkg" for="fldPkg">Work Package <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:DropDownList ID="fldPkg" runat="server" CssClass="form-control input-xxs" Width="240px"></asp:DropDownList>   
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvDate" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date" for="fldDate">Date <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                    <div class='input-group input-group-xs input-xxs' id='dtDate'>
                        <asp:TextBox ID="fldDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>              
                </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvIssues" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Issues" for="fldIssues">Status / Issues <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldIssues" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Issues)" MaxLength="850"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvActivityPlannedForMonth" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Activity Planned for The Month" for="fldActivityPlannedForMonth">Activity Planned for The Month</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldActivityPlannedForMonth" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Activity Planned for The Month)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvProjectSchedule" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Schedule" for="fldProjectSchedule">Schedule <font color="Red">*</font></label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                            <asp:TextBox ID="fldProjectSchedule" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850"></asp:TextBox><asp:Label ID="lblDays" runat="server" class="control-label input-xxs" Text="Days"></asp:Label> 
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvPlanned" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Planned" for="fldPlanned">Planned</label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                            <asp:TextBox ID="fldPlanned" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850"></asp:TextBox><asp:Label ID="lblRM" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvActual" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Actual" for="fldActual">Actual</label>
                    </div>            
                    <div class="col-md-4">  
                        <div class="form-inline">
                            <asp:TextBox ID="fldActual" runat="server" CssClass="form-control input-xxs" Width="80px" PlaceHolder="0" MaxLength="850"></asp:TextBox><asp:Label ID="lblRM1" runat="server" class="control-label input-xxs" Text="%"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvImpact" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Impact" for="fldImpact">Impact</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldImpact" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Impact)" MaxLength="850"></asp:TextBox> 
                    </div>
                </div>
            </div>

            <div class="row">
                <div id="dvActionToBeTaken" runat="server">
                    <div class="col-md-3">
                        <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Action to Be Taken" for="fldActionToBeTaken">Action to Be Taken</label>
                    </div>            
                    <div class="col-md-4">  
                        <asp:TextBox ID="fldActionToBeTaken" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="60" PlaceHolder="(Action to Be Taken)" MaxLength="850"></asp:TextBox> 
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
        
    <script>
        $(function () {
            $('#dtDate').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            $('#dtDateReceived').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

            $('#dtDateSubmitted').datetimepicker({
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

    </div>
</asp:Content>
    


