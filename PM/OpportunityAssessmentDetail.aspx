<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="OpportunityAssessmentDetail.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="OpportunityAssessmentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

    <asp:Table ID="tblMenu" runat="server" Width="100%" CssClass="table table-bordered input-xxs" >
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" >                        
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblOpportunityRecord" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="OpportunityRecordDetail.aspx?Id=<%= Request.QueryString["Id"] %>">OPPORTUNITY RECORD</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#cc3300"><asp:Label ID="lblOpportunityGo" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b><a href="OpportunityGoNoGoDetail.aspx?Id=<%= Request.QueryString["Id"] %>" style="color:white">OPPORTUNITY GO / NO-GO</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalEvaluation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalEvaluationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL EVALUATION / SUBMISSION</a></b></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProposalClose" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProposalCloseDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROPOSAL CLOSE</a></b></asp:Label></asp:TableCell>                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblRegisterNewProject" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="RegisterProjectDetail.aspx?Id=<%= Request.QueryString["Id"] %>">REGISTER NEW PROJECT</a></b></asp:Label></asp:TableCell>                             
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectInitiation" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectInitiationDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT INITIATION</a></b></asp:Label></asp:TableCell>    
                            
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectMonthlyUpdate" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectMonthlyUpdateDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT MONTHLY UPDATE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblEDMS" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="EDMSIncoming.aspx?Id=<%= Request.QueryString["Id"] %>">DOCUMENT MANAGEMENT</a></b></asp:Label></asp:TableCell>

                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF" Wrap="false"><asp:Label ID="lblAwardSubCon" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AwardSubContractorDetail.aspx?Id=<%= Request.QueryString["Id"] %>">AWARD <BR />TO THIRD<BR /> PARTY</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblChangeRequest" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ChangeRequestVODetail.aspx?Id=<%= Request.QueryString["Id"] %>">CHANGE MANAGEMENT</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblSiteVisit" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="SiteVisitHSELegalDetail.aspx?Id=<%= Request.QueryString["Id"] %>">HSE</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblAuditSatisfaction" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="AuditTrail.aspx?Id=<%= Request.QueryString["Id"] %>">AUDIT / CUSTOMER SATISFACTION</a></b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#EFEFEF"><asp:Label ID="lblProjectClosing" runat="server" CssClass="input-xxs" ForeColor="#000000"><b><a href="ProjectClosingDetail.aspx?Id=<%= Request.QueryString["Id"] %>">PROJECT CLOSE</a></b></asp:Label></asp:TableCell> 
                        </asp:TableRow>
    </asp:Table>

<div class="panel-heading">OPPORTUNITY GO / NO-GO</div>
<div class="panel-body">
    
    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/info.jpg" ToolTip="Workflow" OnClientClick="window.open('Workflow/Workflow_Opportunity_GoNoGo.pdf')"></asp:ImageButton></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Opportunity Name" for="lblDescription">Opportunity Name </label>
            </div>
            
            <div class="col-md-6">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-xxs">(Opportunity Name)</asp:Label>
            </div>
        </div>
    </div>

    <ul class="nav nav-tabs">
                    <li ID="tab1" runat="server"><a href='OpportunityGoNoGoDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="OPPORTUNITY INFO."></asp:Label></a></li>                    
                    <li ID="tab2" runat="server" class="active"><a href="#tab2primary" data-toggle="tab"><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="OPPORTUNITY ASSESSMENT"></asp:Label></a></li>
                </ul>

    <table><tr><td height="12"></td></tr></table>

    <table runat="server" width="100%">
                    <tr>
                    <td align="left">
                        <asp:Label ID="Label10" runat="server" class="control-label input-xxs"><b>Country & Project Risk Assessment</b></asp:Label>
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/info.jpg" ToolTip="Guideline" OnClientClick="window.open('Rating Guidelines.pdf')"></asp:ImageButton>
                    </td>
                    </tr>
                </table>

    <asp:Table ID="tblAssessment" runat="server" Width="100%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow runat="server" CssClass="table table-bordered input-sm" BackColor="#808080">                        
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label4" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Rating Item</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label1" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>10 - 9 - 8</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label2" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>7 - 6 - 5 - 4</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label3" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>3 - 2 - 1 - 0</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="Label5" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Rating (0 - 10)</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label6" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Weightage</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label7" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Weightage Rating</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label8" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Points</b></asp:Label></asp:TableCell>                           
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label9" runat="server" CssClass="input-xxs" ForeColor="#ffffff"><b>Analyst's Comments</b></asp:Label></asp:TableCell>   
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="#cc3300" ForeColor="White" ColumnSpan="9">
                                <asp:Label ID="lblHeaderA" runat="server" class="control-label input-xxs"><b>A. Financial (Max 90 Points, Hurdle 60 Points)</b></asp:Label> 
                            </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA1" runat="server" class="control-label input-xxs">Potential Fee Volume (2-3 years)</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA1a" runat="server" class="control-label input-xxs">>RM15M</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA1b" runat="server" class="control-label input-xxs">RM10 - 15M</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA1c" runat="server" class="control-label input-xxs">RM5 - 10M</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA1" runat="server">
                                    <asp:TextBox ID="fldA1_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA1_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA1" ControlToValidate="fldA1_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA1d" runat="server" class="control-label input-xxs">10%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA1_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA1_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA1_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA2" runat="server" class="control-label input-xxs">Pre-Tax Margin / Revenue</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA2a" runat="server" class="control-label input-xxs">>15%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA2b" runat="server" class="control-label input-xxs">10 - 15%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA2c" runat="server" class="control-label input-xxs">7 - 10%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA2" runat="server">
                                    <asp:TextBox ID="fldA2_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA2_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA2" ControlToValidate="fldA2_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA2d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA2_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA2_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA2_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA3" runat="server" class="control-label input-xxs">Source of Funding</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA3a" runat="server" class="control-label input-xxs">Realiable</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA3b" runat="server" class="control-label input-xxs">Marginal</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA3c" runat="server" class="control-label input-xxs">Unreliable</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA3" runat="server">
                                    <asp:TextBox ID="fldA3_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA3_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA3" ControlToValidate="fldA3_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA3d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA3_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA3_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA3_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA4" runat="server" class="control-label input-xxs">Likehood of Funding</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA4a" runat="server" class="control-label input-xxs">80% - 100%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA4b" runat="server" class="control-label input-xxs">40% - 79%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA4c" runat="server" class="control-label input-xxs"><39%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA4" runat="server">
                                    <asp:TextBox ID="fldA4_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA4_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA4" ControlToValidate="fldA4_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA4d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA4_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA4_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA4_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA5" runat="server" class="control-label input-xxs">Payment Terms</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA5a" runat="server" class="control-label input-xxs"><30 days</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA5b" runat="server" class="control-label input-xxs">30 - 60 days</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA5c" runat="server" class="control-label input-xxs">>60 days</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA5" runat="server">
                                    <asp:TextBox ID="fldA5_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA5_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA5" ControlToValidate="fldA5_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA5d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA5_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA5_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA5_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA6" runat="server" class="control-label input-xxs">Tax Risk</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA6a" runat="server" class="control-label input-xxs">Low</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA6b" runat="server" class="control-label input-xxs">Medium</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA6c" runat="server" class="control-label input-xxs">High</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA6" runat="server">
                                    <asp:TextBox ID="fldA6_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA6_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA6" ControlToValidate="fldA6_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA6d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA6_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA6_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA6_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA7" runat="server" class="control-label input-xxs">Foreign Exchange Risk</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA7a" runat="server" class="control-label input-xxs">Low</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA7b" runat="server" class="control-label input-xxs">Medium</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA7c" runat="server" class="control-label input-xxs">High</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA7" runat="server">
                                    <asp:TextBox ID="fldA7_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA7_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA7" ControlToValidate="fldA7_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA7d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA7_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA7_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA7_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblA8" runat="server" class="control-label input-xxs">Fund Repatriation Risk / Restriction</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA8a" runat="server" class="control-label input-xxs">Low</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA8b" runat="server" class="control-label input-xxs">Medium</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblA8c" runat="server" class="control-label input-xxs">High</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvA8" runat="server">
                                    <asp:TextBox ID="fldA8_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldA8_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorA8" ControlToValidate="fldA8_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblA8d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA8_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA8_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldA8_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#ffffdf">     
                            <asp:TableCell HorizontalAlign="Right" Wrap="false" ColumnSpan="7"><asp:Label ID="lblAST" runat="server" class="control-label input-xxs"><b>SubTotal</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldASubTotal" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="#cc3300" ForeColor="White" ColumnSpan="9">
                                <asp:Label ID="lblHeaderB" runat="server" class="control-label input-xxs"><b>B. Project (Max 50 Points, Hurdle 33 Points)</b></asp:Label> 
                            </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblB1" runat="server" class="control-label input-xxs">See Category (<a href="Rating Category.pdf" target="_blank">click here</a>)</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB1a" runat="server" class="control-label input-xxs">Category 1</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB1b" runat="server" class="control-label input-xxs">Category 2</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB1c" runat="server" class="control-label input-xxs">Category 3</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvB1" runat="server">
                                    <asp:TextBox ID="fldB1_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldB1_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorB1" ControlToValidate="fldB1_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblB1d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB1_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB1_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB1_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblB2" runat="server" class="control-label input-xxs">Country Priority</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB2a" runat="server" class="control-label input-xxs">Priority 1</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB2b" runat="server" class="control-label input-xxs">Priority 2</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB2c" runat="server" class="control-label input-xxs">Priority 3</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvB2" runat="server">
                                    <asp:TextBox ID="fldB2_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldB2_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorB2" ControlToValidate="fldB2_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblB2d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB2_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB2_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB2_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblB3" runat="server" class="control-label input-xxs">Potential for Flow-on Work RM (2-3 years)</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB3a" runat="server" class="control-label input-xxs">>RM45M</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB3b" runat="server" class="control-label input-xxs">RM30 - 45M</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB3c" runat="server" class="control-label input-xxs"><30M</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvB3" runat="server">
                                    <asp:TextBox ID="fldB3_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldB3_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorB3" ControlToValidate="fldB3_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblB3d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB3_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB3_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB3_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblB4" runat="server" class="control-label input-xxs">Knowledge of Client or Decision Maker</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB4a" runat="server" class="control-label input-xxs">Excellent</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB4b" runat="server" class="control-label input-xxs">Good</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB4c" runat="server" class="control-label input-xxs">Little</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvB4" runat="server">
                                    <asp:TextBox ID="fldB4_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldB4_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorB4" ControlToValidate="fldB4_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblB4d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB4_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB4_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB4_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblB5" runat="server" class="control-label input-xxs">Relationship with Client or Decision Maker</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB5a" runat="server" class="control-label input-xxs">Excellent</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB5b" runat="server" class="control-label input-xxs">Good</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblB5c" runat="server" class="control-label input-xxs">Little</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvB5" runat="server">
                                    <asp:TextBox ID="fldB5_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldB5_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorB5" ControlToValidate="fldB5_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblB5d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB5_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB5_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldB5_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#ffffdf">     
                            <asp:TableCell HorizontalAlign="Right" Wrap="false" ColumnSpan="7"><asp:Label ID="lblBST" runat="server" class="control-label input-xxs"><b>SubTotal</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldBSubTotal" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="#cc3300" ForeColor="White" ColumnSpan="9">
                                <asp:Label ID="lblHeaderC" runat="server" class="control-label input-xxs"><b>C. Resources / Competition (Max 40 Points, Hurdle 27 Points)</b></asp:Label> 
                            </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblC1" runat="server" class="control-label input-xxs">Opus People Availability</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC1a" runat="server" class="control-label input-xxs">80%></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC1b" runat="server" class="control-label input-xxs">50% - 79%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC1c" runat="server" class="control-label input-xxs"><49%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvC1" runat="server">
                                    <asp:TextBox ID="fldC1_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldC1_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorC1" ControlToValidate="fldC1_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblC1d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC1_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC1_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC1_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblC2" runat="server" class="control-label input-xxs">Competition</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC2a" runat="server" class="control-label input-xxs">Weak</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC2b" runat="server" class="control-label input-xxs">Some</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC2c" runat="server" class="control-label input-xxs">Heavy</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvC2" runat="server">
                                    <asp:TextBox ID="fldC2_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldC2_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorC2" ControlToValidate="fldC2_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblC2d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC2_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC2_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC2_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblC3" runat="server" class="control-label input-xxs">Availability of JV Partners</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC3a" runat="server" class="control-label input-xxs">Good</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC3b" runat="server" class="control-label input-xxs">Moderate</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC3c" runat="server" class="control-label input-xxs">Poor</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvC3" runat="server">
                                    <asp:TextBox ID="fldC3_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldC3_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorC3" ControlToValidate="fldC3_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblC3d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC3_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC3_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC3_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblC4" runat="server" class="control-label input-xxs">Reliability / Trust of Possible JV Partners</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC4a" runat="server" class="control-label input-xxs">Good</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC4b" runat="server" class="control-label input-xxs">Moderate</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblC4c" runat="server" class="control-label input-xxs">Poor</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvC4" runat="server">
                                    <asp:TextBox ID="fldC4_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldC4_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorC4" ControlToValidate="fldC4_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblC4d" runat="server" class="control-label input-xxs">5%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC4_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC4_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldC4_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#ffffdf">     
                            <asp:TableCell HorizontalAlign="Right" Wrap="false" ColumnSpan="7"><asp:Label ID="lblCST" runat="server" class="control-label input-xxs"><b>SubTotal</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldCSubTotal" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" BackColor="#cc3300" ForeColor="White" ColumnSpan="9">
                                <asp:Label ID="lblHeaderD" runat="server" class="control-label input-xxs"><b>D. Cost and Time to Prepare Proposal (Max 20 Points, Hurdle 13 Points)</b></asp:Label> 
                            </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblD1" runat="server" class="control-label input-xxs">Time to Prepare Proposal</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD1a" runat="server" class="control-label input-xxs">Plenty</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD1b" runat="server" class="control-label input-xxs">Enough</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD1c" runat="server" class="control-label input-xxs">Not Enough</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvD1" runat="server">
                                    <asp:TextBox ID="fldD1_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldD1_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorD1" ControlToValidate="fldD1_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblD1d" runat="server" class="control-label input-xxs">3%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD1_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD1_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD1_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#FFECEC">     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblD2" runat="server" class="control-label input-xxs">Cost to Prepare EOI vs Fees</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD2a" runat="server" class="control-label input-xxs">0 - 2%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD2b" runat="server" class="control-label input-xxs">2 - 4%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD2c" runat="server" class="control-label input-xxs">>4%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvD2" runat="server">
                                    <asp:TextBox ID="fldD2_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldD2_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorD2" ControlToValidate="fldD2_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblD2d" runat="server" class="control-label input-xxs">3%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD2_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD2_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD2_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow>     
                            <asp:TableCell HorizontalAlign="Left" Wrap="false"><asp:Label ID="lblD3" runat="server" class="control-label input-xxs">Cost to Prepare Proposal vs Fee</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD3a" runat="server" class="control-label input-xxs">0 - 2%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD3b" runat="server" class="control-label input-xxs">2 - 4%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblD3c" runat="server" class="control-label input-xxs">>4%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center">
                                <div id="dvD3" runat="server">
                                    <asp:TextBox ID="fldD3_Input" runat="server" CssClass="form-control input-xxs" Width="60px" OnTextChanged="fldD3_Input_TextChanged" AutoPostBack="true" CausesValidation="true"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cValidatorD3" ControlToValidate="fldD3_Input" Type="Integer" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" CssClass="input-xxs" ForeColor="Red"/>
                                </div>
                            </asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblD3d" runat="server" class="control-label input-xxs">4%</asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD3_Rating" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD3_Point" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldD3_Comment" runat="server" CssClass="form-control input-xxs" Width="280px" TextMode="MultiLine" Height="40" MaxLength="850"></asp:TextBox> </asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#ffffdf">     
                            <asp:TableCell HorizontalAlign="Right" Wrap="false" ColumnSpan="7"><asp:Label ID="lblDST" runat="server" class="control-label input-xxs"><b>SubTotal</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldDSubTotal" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"></asp:TableCell> 
                        </asp:TableRow>

                        <asp:TableRow BackColor="#ffffdf">     
                            <asp:TableCell HorizontalAlign="Right" Wrap="false" ColumnSpan="5"></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center" Wrap="false"><asp:Label ID="lblPercent" runat="server" class="control-label input-xxs"><b>100%</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Right" Wrap="false"><asp:Label ID="lblTotal" runat="server" class="control-label input-xxs"><b>Total</b></asp:Label></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"><asp:TextBox ID="fldTotal" runat="server" CssClass="form-control input-xxs" Width="60px" BackColor="#e8e8e8" ReadOnly="true"></asp:TextBox></asp:TableCell> 
                            <asp:TableCell HorizontalAlign="Center"></asp:TableCell> 
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
                <asp:Label ID="lblNote1" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Enter <b>Rating (0 - 10)</b> and press on <b>Tab</b> button to proceed with the next item. Repeat the same steps until you get the <b>Total</b> for all sections.</asp:Label> 
            </div>
        </div>
    </div>
         
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Update</b> button to update the assessment details.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote3" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Calculate</b> button to calculate the total score.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote4" runat="server" class="control-label input-xxs" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Complete</b> button to complete the assessment details. No update is allowed when you have completed this page.</asp:Label> 
            </div>
        </div>
    </div>
        
    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-xs input-xxs" Width="65" OnClick="btnUpdate_Click" />         
        &nbsp;&nbsp;<asp:Button ID="btnComplete" runat="server" Text="Complete" CssClass="btn btn-danger btn-xs input-xxs" Width="75" OnClick="btnComplete_Click" OnClientClick = "return confirm('Are you sure you want to complete this page?')" /> 
        &nbsp;&nbsp;<asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="btn btn-info btn-xs input-xxs" Width="75" OnClick="btnCalculate_Click" Enabled="false"/>         
        &nbsp;&nbsp;<asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click" Visible="false"/> 
    </div>

</div>
    
</asp:Content>
    
