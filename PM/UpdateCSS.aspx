<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="UpdateCSS.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="UpdateCSS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    <asp:Table ID="Table4" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>                             
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

<%--                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell>                             --%>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
         </asp:Table>
<div class="panel-heading">AUDIT / CUSTOMER SATISFACTION</div>
<div class="panel-body">

    <asp:Table ID="tblHeader1" runat="server" Width="100%" CssClass="input-sm">
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
                    <li ID="tab2" runat="server"><a href='AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>'><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="AUDIT TRAIL"></asp:Label></a></li>
                    <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/group_full_add24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="CLIENT SATISFACTION SURVEY"></asp:Label></a></li>
                    
                    
                </ul>
    
        
    <table><tr><td height="10"></td></tr></table>
        
    <div class="row">
        <div id="dvYear" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Year" for="fldYear">Year <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldYear" runat="server" CssClass="form-control input-xxs" Width="180px" Enabled="false"></asp:DropDownList> 
            </div>            
        </div>
    </div>

    <div class="row">
        <div id="dvClientName" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Client Name <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldClientName" runat="server" CssClass="form-control input-xxs" Width="300px" PlaceHolder="(Client Name)" MaxLength="850" Enabled="false"></asp:TextBox> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvDateRequired" runat="server">   
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Required" for="fldDateRequired">Date Required <font color="Red">*</font></label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                    <div class='input-group input-group-xs' id='dtDateRequired'>
                        <asp:TextBox ID="fldDateRequired" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                     
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvStatus" runat="server">            
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Status" for="fldStatus">Status </label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldStatus" runat="server" CssClass="form-control input-xxs" Width="180px" Enabled="false"></asp:DropDownList> 
            </div>            
        </div>
    </div>
    
    <div class="row">
        <div>
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Survey Form " for="fldCSSForm ">Survey Form <font color="Red">*</font></label>
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
        <div id="dvProjectDate" runat="server">
            <div class="col-md-3">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Start & End Date" for="fldDate">Period <font color="Red">*</font></label>
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
    </div>

    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm" Visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <div id="errDvDate" runat="server" class="alert alert-warning input-sm " role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Period is required!
                    </div>
                    <div id="errDvA01" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 1 is required!
                    </div>
                    <div id="errDvA02" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 2 is required!
                    </div>
                    <div id="errDvA03" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 3 is required!
                    </div>
                    <div id="errDvA04" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 4 is required!
                    </div>
                    <div id="errDvA05" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 5 is required!
                    </div>
                    <div id="errDvA06" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 6 is required!
                    </div>
                    <div id="errDvA07" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 7 is required!
                    </div>
                    <div id="errDvA08" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 8 is required!
                    </div>
                    <div id="errDvA09" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 9 is required!
                    </div>
                    <div id="errDvA10" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 10 is required!
                    </div>                    
                    <div id="errDvB01" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Future Engagement / Recommendation : No. 11 is required!
                    </div>
                    <div id="errDvB02" runat="server" class="alert alert-warning input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Future Engagement / Recommendation : No. 12 is required!
                    </div>                           
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>
           
                        
            <asp:Table ID="tbl" runat="server" Width="100%" CssClass="table table-bordered input-sm" BackColor="#666666">
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" RowSpan="2" ForeColor="White"><b>#</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Left" RowSpan="2" ForeColor="White"><b>Performance Area</b></asp:TableCell>                
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White" ColumnSpan="10"><b>Poor &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; to &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Excellent</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>                
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>1</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>2</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>3</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>4</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>5</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>6</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>7</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>8</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>9</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>10</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>N/A</b></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow BackColor="#FFECEC">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">1.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Provide practical solutions / Overcome the identified problems</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa1" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa2" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa3" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa4" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa5" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa6" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa7" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa8" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa9" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa10" GroupName="PA1" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAa11" GroupName="PA1" runat="server"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow BackColor="White">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">2.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Understand the agreed scope of services and comply with the Client's interest and expectation</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb1" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb2" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb3" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb4" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb5" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb6" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb7" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb8" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb9" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb10" GroupName="PA2" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAb11" GroupName="PA2" runat="server"/></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow BackColor="#FFECEC">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">3.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Assign appropriate skilled personnel to the job</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc1" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc2" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc3" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc4" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc5" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc6" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc7" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc8" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc9" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc10" GroupName="PA3" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAc11" GroupName="PA3" runat="server"/></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow BackColor="White">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">4.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Our people having a good understanding of your business environment / company's strategic directions</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd1" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd2" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd3" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd4" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd5" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd6" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd7" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd8" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd9" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd10" GroupName="PA4" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAd11" GroupName="PA4" runat="server"/></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow BackColor="#FFECEC">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">5.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Quality of services (E.g: Deliverables, reports)</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe1" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe2" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe3" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe4" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe5" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe6" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe7" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe8" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe9" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe10" GroupName="PA5" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAe11" GroupName="PA5" runat="server"/></asp:TableCell>
            </asp:TableRow>                          
            <asp:TableRow BackColor="White">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">6.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Timeliness of services<br />Conduct proper project planning and control for project execution</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf1" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf2" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf3" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf4" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf5" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf6" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf7" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf8" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf9" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf10" GroupName="PA6" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAf11" GroupName="PA6" runat="server"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow BackColor="#FFECEC">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">7.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Keep you well-informed of progress<br />Conduct adequate and frequent communication between team members to ensure accurate information flow and monitoring of progress</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg1" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg2" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg3" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg4" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg5" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg6" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg7" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg8" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg9" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg10" GroupName="PA7" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAg11" GroupName="PA7" runat="server"/></asp:TableCell>
            </asp:TableRow>           
            <asp:TableRow BackColor="White">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">8.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Anticipating problems and taking pre-emptive actions</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh1" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh2" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh3" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh4" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh5" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh6" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh7" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh8" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh9" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh10" GroupName="PA8" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAh11" GroupName="PA8" runat="server"/></asp:TableCell>
            </asp:TableRow>        
            <asp:TableRow BackColor="#FFECEC">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">9.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Responsive to inquiries</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi1" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi2" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi3" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi4" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi5" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi6" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi7" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi8" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi9" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi10" GroupName="PA9" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAi11" GroupName="PA9" runat="server"/></asp:TableCell>
            </asp:TableRow>    
            <asp:TableRow BackColor="White">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">10.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Trustworthiness (E.g: Reliability and dependability)</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj1" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj2" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj3" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj4" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj5" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj6" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj7" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj8" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj9" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj10" GroupName="PA10" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPAj11" GroupName="PA10" runat="server"/></asp:TableCell>
            </asp:TableRow>  

            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center" ForeColor="White"><b>#</b></asp:TableCell>
                <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Left" ForeColor="White" ColumnSpan="12"><b>Future Engagement / Recommendation</b></asp:TableCell>  
            </asp:TableRow>

            <asp:TableRow BackColor="#FFECEC">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">11.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Would you engage Opus again for your future projects?</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa1" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa2" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa3" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa4" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa5" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa6" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa7" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa8" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa9" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa10" GroupName="PA11" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERa11" GroupName="PA11" runat="server"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow BackColor="White">
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Center">12.</asp:TableCell>
                <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">Would you recommend Opus to your business associates?</asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb1" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb2" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb3" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb4" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb5" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb6" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb7" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb8" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb9" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb10" GroupName="PA12" runat="server"/></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:RadioButton ID="rbPERb11" GroupName="PA12" runat="server"/></asp:TableCell>
            </asp:TableRow>     
        </asp:Table>

            <asp:Table ID="Table2" runat="server" Width="100%" CssClass="input-sm" >
            <asp:TableRow>
                <asp:TableCell Height="8" ColumnSpan="4"></asp:TableCell>
            </asp:TableRow>
                
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">Please provide your observation, grievances or recommendations<br />
                    (suggestions on areas for improvement would be most welcome)
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Top">:</asp:TableCell>
                <asp:TableCell VerticalAlign="Top">&nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="fldRemarks" runat="server" CssClass="form-control input-sm" Width="500" TextMode="MultiLine" Rows="5" BackColor="#FFFFFF"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>                      
    </asp:Table>

    
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update </b> button to update CSS record.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Back</b> button to return to the previous page.</asp:Label> 
            </div>
        </div>
    </div>
    
    <hr />

    <div class="row" align="center">               
        &nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" /> 
        &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-xs input-xxs" Width="55" OnClick="btnBack_Click" /> 
        
    </div>

    <br />
    
   

    <script>
        $(function () {
            $('#dtDateRequired').datetimepicker({
                format: 'DD-MMM-YYYY',
                showTodayButton: true,
                showClear: true
            });

        });

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

</div>



</asp:Content>
    



    