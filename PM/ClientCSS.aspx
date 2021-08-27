<%@ Page Title="" Language="C#" MasterPageFile="TMS_Email_MasterPage.master" AutoEventWireup="true" CodeFile="ClientCSS.aspx.cs" Inherits="ClientCSS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">

<div class="panel-heading">CLIENT SATISFACTION SURVEY ONLINE</div>
<div class="panel-body">
    
    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-sm" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Company Name" for="lblClientName">Company Name </label>
            </div>            
            <div class="col-md-4">                
                <asp:Label ID="lblClientName" runat="server" class="control-label input-sm"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-sm" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Project Name" for="lblDescription">Project Name </label>
            </div>            
            <div class="col-md-6">                
                <asp:Label ID="lblDescription" runat="server" class="control-label input-sm"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-2">
                <label class="control-label input-sm" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Respondent Name" for="lblRespondentName">Respondent Name / Email</label>
            </div>            
            <div class="col-md-4">                
                <asp:Label ID="lblRespondentName" runat="server" class="control-label input-sm"></asp:Label>/<asp:Label ID="lblRespondentEmail" runat="server" class="control-label input-sm"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvDateCompleted" runat="server">
            <div class="col-md-2">
                <label class="control-label input-sm" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Date Completed" for="lblCompletedDt">Date Completed</label>
            </div>            
            <div class="col-md-4">                
                <asp:Label ID="lblCompletedDt" runat="server" class="control-label input-sm"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div id="dvProjectDate" runat="server">
            <div class="col-md-2">
                <label class="control-label input-sm" data-toggle="tooltip" data-placement="right" data-container="body" data-html="true" title="Period" for="fldDate">Period <font color="Red">*</font></label>
            </div>            
            <div class="col-md-2">  
                <div class="form-inline">
                    <div class='input-group input-group-xs input-sm' id='dtStartDate'>
                        <asp:TextBox ID="fldStartDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                    
                </div>
            </div>
            <div class="col-md-1">                  
                    <asp:Label ID="lblTo" runat="server" class="control-label input-sm" Text="to"></asp:Label>   
            </div>
            <div class="col-md-2">  
                <div class="form-inline">                    
                    <div class='input-group input-group-xs input-sm' id='dtEndDate'>
                        <asp:TextBox ID="fldEndDate" runat="server" CssClass="form-control input-xxs"></asp:TextBox><span class="input-group-addon input-xxs"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>                   
                </div>
            </div>
        </div>
    </div>
    
    <asp:Table ID="tblHeader" runat="server" Width="100%" CssClass="input-sm" Visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <div id="errDvDate" runat="server" class="alert alert-danger input-sm " role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Period is required!
                    </div>

                    <div id="errDvA01" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 1 is required!
                    </div>
                    <div id="errDvA02" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 2 is required!
                    </div>
                    <div id="errDvA03" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 3 is required!
                    </div>
                    <div id="errDvA04" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 4 is required!
                    </div>
                    <div id="errDvA05" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 5 is required!
                    </div>
                    <div id="errDvA06" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 6 is required!
                    </div>
                    <div id="errDvA07" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 7 is required!
                    </div>
                    <div id="errDvA08" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 8 is required!
                    </div>
                    <div id="errDvA09" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 9 is required!
                    </div>
                    <div id="errDvA10" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Performance Area : No. 10 is required!
                    </div>
                    
                    <div id="errDvB01" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Future Engagement / Recommendation : No. 11 is required!
                    </div>
                    <div id="errDvB02" runat="server" class="alert alert-danger input-sm" role="alert" visible="false">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;Future Engagement / Recommendation : No. 12 is required!
                    </div>                           
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>
            
            <asp:Table ID="tblNote" runat="server" Width="100%" CssClass="input-xxs"> 
            <asp:TableRow>
                <asp:TableCell Height="3"></asp:TableCell>
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

            <asp:Table ID="Table1" runat="server" Width="100%" CssClass="input-sm" >
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
            <div class="col-md-8">
                <asp:Label ID="lblNote" runat="server" class="control-label input-sm" Font-Italic="true">Note :</asp:Label> 
            </div>
        </div>
    </div>
         
    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote1" runat="server" class="control-label input-sm" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Submit</b> button to submit the survey.</asp:Label> 
            </div>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-md-8">
                <asp:Label ID="lblNote2" runat="server" class="control-label input-sm" Font-Italic="true"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Click on <b>Close Window</b> button to close this window.</asp:Label> 
            </div>
        </div>
    </div>

    <hr />
    
    <div class="row" align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="65" CssClass="btn btn-success btn-xs input-xxs" OnClick="btnSubmit_Click" OnClientClick = "return confirm('Are you sure you want to submit this page?')" />
        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" Text="Close Window" CssClass="btn btn-primary btn-xs input-xxs" Width="102" OnClick="btnClose_Click" />                    
    </div>
    
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
    