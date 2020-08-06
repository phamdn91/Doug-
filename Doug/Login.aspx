<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Doug.Login" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>DPFitness - Login</title>

    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link href="CSS/Style.css" rel="stylesheet" />
</head>
<form runat="server" class="user">
    <body class="bg-gradient-info">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-7 col-lg-7 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control form-control-user" placeholder="Username" ValidationGroup="Validate" AutoPostBack="false" ClientIDMode="Static"></asp:TextBox>
<%--                                <asp:TextBox type="text" CssClass="form-control form-control-user" runat="server" ValidationGroup="Validate" ID="txtUsername" Placeholder="Username" AutoPostBack="false" ClientIDMode="Static"></asp:TextBox>--%>
<%--                                    <asp:RequiredFieldValidator runat="server" ID="txtUNRequiredFieldValidator" CssClass="errormsg" ControlToValidate="txtUsername" ValidationGroup="Validate" ErrorMessage="Incorrect Username and/or Password" />--%>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox type="password" CssClass="form-control form-control-user" runat="server" ID="txtPassword" Placeholder="Password"></asp:TextBox>
                                    <%--                                    <asp:RequiredFieldValidator runat="server" ID="RequiredPFieldValidator" CssClass="errormsg" ControlToValidate="txtPassword" ValidationGroup="Validate" ErrorMessage="Required" />--%>
                                </div>
                                <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-info btn-user btn-block" OnClick="btnLogin_Click" Text="Login" />
                                <div class="text-center">
                                </div>
                                <hr>
                                <div class="text-center">
                                    <a class="small" style="color: #36b8cb;" href="register.aspx">Create an Account!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="Scripts/jquery.min.js"></script>
        <script src="Scripts/bootstrap.bundle.min.js"></script>
        <script src="Scripts/jquery.easing.min.js"></script>
        <script src="Scripts/sbb-admin-2.js"></script>
        <script type="text/javascript">
            window.history.forward(-1);
        </script>
    </body>
</form>
</html>
