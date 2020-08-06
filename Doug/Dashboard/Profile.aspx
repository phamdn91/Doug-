<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Doug.Dashboard.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" container">

        <div class="center col-xl-8 col-lg-7">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Profile Overview</h6>
                </div>

                <div class="card-body">

                    <form class="user">

                        <label for="FirstName">First name:</label>
                        <div class="form-group">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" runat="server" ID="FirstName"></asp:TextBox>
                        </div>

                        <label for="LastName">Last name:</label>
                        <div class="form-group">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" runat="server" ID="LastName"></asp:TextBox>
                        </div>

                        <label for="Email">Email:</label>
                        <div class="form-group">
                            <asp:TextBox type="email" CssClass="form-control form-control-user" runat="server" ID="Email"></asp:TextBox>
                        </div>

                        <label for="UserName">Username:</label>
                        <div class="form-group">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" runat="server" ID="UserName"></asp:TextBox>
                        </div>

                        <label for="Password">New Password:</label>
                        <div class="form-group">
                            <asp:TextBox type="password" CssClass="form-control form-control-user" runat="server" ID="Password"></asp:TextBox>
                        </div>

                        <label for="ConfirmPassword">Confirm Password:</label>
                        <div class="form-group">
                            <asp:TextBox type="password" CssClass="form-control form-control-user" runat="server" ID="ConfirmPassword"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="ConfirmPassword" CssClass="ValidationError" ControlToCompare="Password" ErrorMessage="Passwords must be the same" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="ConfirmPassword" CssClass="ValidationError"></asp:RequiredFieldValidator>
                        </div>


                        <asp:Button runat="server" ID="btnProfile" CssClass="btn btn-info btn-user btn-block" OnClick="btnProfile_Click" Text="Update" />

                    </form>
                </div>


            </div>

        </div>
    </div>
    <%--<script type="text/javascript">

    document.getElementById("btnProfile").onclick = function test() {
            if ($("#<%= Password.ClientID %>").val() != $("#<%= ConfirmPassword.ClientID %>").val()) {
                alert("Your passwords don't match. Please enter them again.");
                return false;
            }
            else {
                document.getElementById("btnProfile_Click").click();

            }
    
            // use similar function to test for illegal characters in the password, but most sites will let you enter whatever characters you want (# . ! etc...)


            document.forms[0].submit();
        }
    </script>--%>
</asp:Content>
