<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RequestAccess.aspx.cs" Inherits="RequestAccess" %>


<!DOCTYPE html>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="Img/uem_only.png"/>
    <title>Project Execution Control</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</head>
<body>  
    <form id="formLogin" runat="server">

    

    <div class="container">
        <div class="row">
            <img src="Img/PECbanner.png" class="img-responsive"/>
        </div>

        <div style="padding-top:50px">
        

        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">Request Access</div>
                    <div class="panel-body">
                        <div class="row">
                            <div id="errMain" runat="server">
                                <asp:Label ID="errfldMain" runat="server" CssClass="input-xs" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <label class="control-label input-xs" for="fldUserID">&nbsp;&nbsp;&nbsp;Staff ID</label><asp:Label ID="errDvfldUserID" runat="server" Text='Required !' CssClass="input-xs" ForeColor="Red"></asp:Label>
                        </div>

                        <div id="dvUserID" runat="server" class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class='input-group input-group-lg'>
                                        <span class="input-group-addon input-lg"><span class="glyphicon glyphicon-user"></span></span><asp:TextBox ID="fldUserID" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <label class="control-label input-xs" for="fldPass">&nbsp;&nbsp;&nbsp;Email Address</label><asp:Label ID="errDvfldPass" runat="server" Text='Required !' CssClass="input-xs" ForeColor="Red"></asp:Label>
                        </div>

                        <div id="dvPass" runat="server" class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class='input-group input-group-lg'>
                                        <span class="input-group-addon input-lg"><span class="glyphicon glyphicon-lock"></span></span><asp:TextBox ID="fldPass" runat="server" CssClass="form-control input-lg"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr class="style-primary" />
                                
                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Button ID="btnLogin" runat="server" Text="Submit" CssClass="form-control btn btn-success btn-sm" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Button ID="btnRequestAccess" runat="server" Text="Back To Login" CssClass="form-control btn btn-primary btn-sm" OnClick="btnRequestAccess_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="Scripts/jquery-2.2.3.min.js" />
        <asp:ScriptReference Path="Scripts/bootstrap.min.js" />
    </Scripts>
    </asp:ScriptManager>

    </form>
  
</body>
</html>
