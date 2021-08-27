<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ProjectDbInfo.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ProjectDbInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    
   

<div class="panel-heading input">PROJECT DATABASE</div>
<div class="panel-body">

     <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top"><asp:Label ID="lblUser" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top"><asp:Label ID="lblCurrDateTime" runat="server" class="control-label input-xxs" ForeColor="#666666"></asp:Label></asp:TableCell>
                </asp:TableRow>   
            </asp:Table>

     <ul class="nav nav-tabs">
         <li ID="tab1" runat="server" class="active"><a href="#tab1primary" data-toggle="tab"><img src="Img/Icon/user_half_information24.png" /> <asp:Label ID="lblOne" runat="server" class="control-label input-xxs" Text="PROJECT INFO."></asp:Label></a></li>                    
         <li ID="tab2" runat="server"><a href='ProjectDbDetail.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_text24.png" /> <asp:Label ID="lblTwo" runat="server" class="control-label input-xxs" Text="PROJECT DETAILS"></asp:Label></a></li>    
         <li ID="tab3" runat="server"><a href='ProjectDbStatus.aspx?Id=<%=Request.QueryString["Id"]%>'><img src="Img/Icon/document_sans_accept24.png" /> <asp:Label ID="Label9" runat="server" class="control-label input-xxs" Text="PROJECT STATUS"></asp:Label></a></li>    
     </ul>
    
    <table><tr><td height="12"></td></tr></table>

    <div class="row">
        <div id="dvCompany" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Company" for="fldCompany">Company</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList id="fldCompany" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvUnit" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Operating Unit" for="fldUnit">Type Of Sector</label>
            </div>            
            <div class="col-md-3">     
                <asp:DropDownList id="fldSector" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvClientName" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Name" for="fldClientName">Type Of Service</label>
            </div>
            <div class="col-md-3">  
                <asp:DropDownList id="fldService" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvClientAdd" runat="server">            
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Client Address" for="fldClientAdd">Project Assigned To Department</label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList id="fldDept" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvOpportunity" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Opportunity Name" for="fldDescription">Project Name</label>
            </div>            
            <div class="col-md-3">                
                <asp:TextBox ID="fldProjectName" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="100" MaxLength="850" Enabled="false"></asp:TextBox>                          
            </div>
        </div>
            <div class="col-md-1">  </div>
        <div id="dvSOW" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Scope of Work" for="fldSOW">Project Manager</label>
            </div>            
            <div class="col-md-3">                
                <asp:DropDownList id="fldPM" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>


    <div class="row">
        <div id="dvPIC1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [1]" for="fldPIC1">Client Name</label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldClientName" runat="server" CssClass="form-control input-xxs" Width="320px" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-1">  </div>
        <div id="dvPIC2" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Person In Charge [2]" for="fldPIC2">Client Address</label>
            </div>            
            <div class="col-md-3">  
                <asp:TextBox ID="fldClientAdd" runat="server" CssClass="form-control input-xxs" Width="320px" TextMode="MultiLine" Height="80" MaxLength="850" Enabled="false"></asp:TextBox>                          
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectValue" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">LOI/LOA/PMA Status</label>
            </div>            
            <div class="col-md-2">  
                <asp:DropDownList id="fldLOI" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
            <div class="col-md-2">  </div>
        <div id="dvProjectFee" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Project Type</label>
            </div>            
            <div class="col-md-2">  
                <asp:DropDownList id="fldType" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div10" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Project Phases & Tasks</label>
            </div>            
            <div class="col-md-2">  
                <asp:DropDownList ID="fldPhase" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
            
    </div>


    <div class="row">
        <div id="dvEIA" runat="server">
            <div class="col-md-2">
               
            </div>
            
            <div class="col-md-10"> 


    <%--Generic--%>

    <asp:GridView ID="gvGeneric" runat="server" CssClass="table table-bordered table-striped input-xxs" AutoGenerateColumns="false" DataKeyNames="Id" ShowHeaderWhenEmpty="True" Width="60%">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="lblNoUp" runat="server" Text='<%# Container.DataItemIndex + 1 %>' CssClass="input-xxs"></asp:Label>                        
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Code" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("PhaseCode").ToString() != "" ? Eval("PhaseCode").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Task" HeaderStyle-Width="5%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Task").ToString() != "" ? Eval("Task").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>                                                                    
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Phase Name" HeaderStyle-Width="85%" ItemStyle-CssClass="table" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("Phase").ToString() != "" ? Eval("Phase").ToString().ToUpper() : "-"%>' CssClass="input-xxs"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>            
            </Columns>
                <EmptyDataTemplate><asp:Label ID="lblDownEmpty" runat="server" Text="No Record Found." CssClass="input-sm"></asp:Label></EmptyDataTemplate>
            </asp:GridView>

        <%--end of Generic--%>


        <%--Specific--%>

                <asp:Table ID="tblSpecific" runat="server" Width="60%" CssClass="table table-bordered input-xxs">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="Label1" runat="server" class="control-label input-xxs">#</asp:Label>                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lbl01" runat="server" class="control-label input-xxs">Phase</asp:Label>                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" BackColor="#808080" ForeColor="White">
                                <asp:Label ID="lblChecklistA" runat="server" class="control-label input-xxs">Phase Name</asp:Label>                                
                            </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" >
                                <asp:Label ID="Label2" runat="server" class="control-label input-xxs">1</asp:Label>                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:Label ID="Label3" runat="server" class="control-label input-xxs">1st Phase</asp:Label>                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" >
                                <asp:Label ID="Label4" runat="server" class="control-label input-xxs">Fee Proposal/Evaluation</asp:Label>                                
                            </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center" >
                                <asp:Label ID="Label5" runat="server" class="control-label input-xxs">2</asp:Label>                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:Label ID="Label6" runat="server" class="control-label input-xxs">2nd Phase</asp:Label>                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" >
                                <asp:Label ID="Label7" runat="server" class="control-label input-xxs">Project Implementation</asp:Label>                                
                            </asp:TableCell>
                        </asp:TableRow>
                </asp:Table>

        <%--end of Specific--%>

    </div>
        </div>
            
    </div>





    <div class="row">
        <div id="Div1" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Estimated Project Value</label>
            </div>            
            <div class="col-md-2">  
                <asp:TextBox ID="fldValue" runat="server" CssClass="form-control input-xxs" Width="200px" Enabled="false"></asp:TextBox>
            </div>
        </div>
            <div class="col-md-2">  </div>
        <div id="Div2" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Estimated Project Fee Including Reimbursable (excluding GST)</label>
            </div>            
            <div class="col-md-2">  
                <asp:TextBox ID="fldFees" runat="server" CssClass="form-control input-xxs" Width="200px" Enabled="false"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div5" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Estimated Project Start Date</label>
            </div>            
            <div class="col-md-2">  
                <asp:TextBox ID="fldStartDate" runat="server" CssClass="form-control input-xxs" Width="200px" Enabled="false"></asp:TextBox>
            </div>
        </div>
            <div class="col-md-2">  </div>
        <div id="Div6" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Estimated Project End Date</label>
            </div>            
            <div class="col-md-2">  
                <asp:TextBox ID="fldEndDate" runat="server" CssClass="form-control input-xxs" Width="200px" Enabled="false"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="Div3" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Confidential</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                                &nbsp;&nbsp;<asp:RadioButton ID="rbCon1" GroupName="Confidential" runat="server"/> <label class="control-label input-xxs">Yes</label>&nbsp;&nbsp;

                                <asp:RadioButton ID="rbCon2" GroupName="Confidential" runat="server"/> <label class="control-label input-xxs">No</label>&nbsp;&nbsp;
                            </div>
            </div>
        </div>
            <div class="col-md-1">  </div>
        <div id="Div4" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Project To Be Included In QMS</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                                &nbsp;&nbsp;<asp:RadioButton ID="rbQMS1" GroupName="QMS" runat="server"/> <label class="control-label input-xxs">Yes</label>&nbsp;&nbsp;

                                <asp:RadioButton ID="rbQMS2" GroupName="QMS" runat="server"/> <label class="control-label input-xxs">No</label>&nbsp;&nbsp;
                            </div>
            </div>
        </div>
    </div>

     <div class="row">
        <div id="Div7" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">External Support Requirement</label>
            </div>            
            <div class="col-md-3">  
                <div class="form-inline">
                                &nbsp;&nbsp;<asp:RadioButton ID="rbExt1" GroupName="Ext" runat="server"/> <label class="control-label input-xxs">Yes</label>&nbsp;&nbsp;

                                <asp:RadioButton ID="rbExt2" GroupName="Ext" runat="server"/> <label class="control-label input-xxs">No</label>&nbsp;&nbsp;
                            </div>
            </div>
        </div>
            <div class="col-md-1">  </div>
        <div id="Div8" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Business Manager</label>
            </div>            
            <div class="col-md-3">  
                <asp:DropDownList ID="fldBM" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
    </div>



    <div class="row">
        <div id="Div9" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title=">Estimated Project Value" for="fldProjectValue">Year</label>
            </div>            
            <div class="col-md-2">  
                <asp:DropDownList ID="fldYear" runat="server" CssClass="form-control input-xxs" Enabled="false"></asp:DropDownList> 
            </div>
        </div>
             <div class="col-md-2">  </div>
        <div id="Div11" runat="server">
            <div class="col-md-2">
                <label class="control-label input-xxs" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Estimated Project Fees" for="fldProjectFee">Project Code</label>
            </div>            
            <div class="col-md-2">  
                <asp:TextBox ID="fldCode" runat="server" CssClass="form-control input-xxs" Width="200px" Enabled="false"></asp:TextBox>
                <asp:TextBox ID="fldCodeDt" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldLoggedDt" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldBMApprovalDt" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldCOOApprovalDt" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldID" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldStatus" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldPMNo" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldBMNo" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldBMName" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldScope" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
                <asp:TextBox ID="fldDateMigrate" runat="server" CssClass="form-control input-xxs" Width="200px" Visible="false"></asp:TextBox>
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

    

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnListing" runat="server" Text="Back to Listing" CssClass="btn btn-primary btn-xs input-xxs" Width="105" OnClick="btnListing_Click"/> 
        &nbsp;&nbsp;<asp:Button ID="btnMigrate" runat="server" Text="Migrate to PEC" CssClass="btn btn-warning btn-xs input-xxs" Width="110" OnClick="btnMigrate_Click" OnClientClick="return confirm('Are you sure you want to migrate this project?')" />
   
    </div>

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


</asp:Content>
    


