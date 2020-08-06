<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Doug.Register" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>DPFitness - Register</title>

    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link href="CSS/Style.css" rel="stylesheet" />
</head>
<form runat="server" class="user">
    <body class="bg-gradient-info">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
                                </div>
                                <div class="text-center">
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control form-control-user" placeholder="First Name" ValidationGroup="Validate" AutoPostBack="false" ClientIDMode="Static"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="txtFNRequiredValidator" CssClass="errormsg" ControlToValidate="txtFirstName" ValidationGroup="Validate" ErrorMessage="Required" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control form-control-user" placeholder="Last Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="txtLNRequiredValidator" CssClass="errormsg" ControlToValidate="txtLastName" ValidationGroup="Validate" ErrorMessage="Required" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-user" placeholder="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="txtEmailRequiredValidator" CssClass="errormsg" ControlToValidate="txtEmail" ValidationGroup="Validate" ErrorMessage="Required" />
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control form-control-user" placeholder="Username"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="txtUNRequiredValidator" CssClass="errormsg" ControlToValidate="txtUsername" ValidationGroup="Validate" ErrorMessage="Required" />
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control form-control-user" placeholder="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="txtPWRequiredValidator" CssClass="errormsg" ControlToValidate="txtPassword" ValidationGroup="Validate" ErrorMessage="Required" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox runat="server" TextMode="Password" ID="txtRepeatPassword" CssClass="form-control form-control-user" placeholder="Confirm Password"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="txtRepeatPassword" CssClass="ValidationError" ControlToCompare="txtPassword" ErrorMessage="Passwords must be the same" />
                                            <asp:RequiredFieldValidator runat="server" ID="txtRPWRequiredValidator" CssClass="errormsg" ControlToValidate="txtRepeatPassword" ValidationGroup="Validate" ErrorMessage="Required" />
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-info btn-user btn-block" OnClick="btnRegister_Click" Text="Register" ValidationGroup="Validate" />
                                </div>
                                <hr>
                                <div class="text-center">
                                    <a class="small" style="color: #36b8cb;" href="login.aspx">Already have an account? Login!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
</form>
</html>
