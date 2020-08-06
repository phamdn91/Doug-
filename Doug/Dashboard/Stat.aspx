<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Stat.aspx.cs" Inherits="Doug.Dashboard.Stat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="center col-xl-8 col-lg-7">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Stats Overview</h6>

                </div>
                <div class="card-body">

                    <form  class="user">

                        <label for="age">Age (yr):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Age"></asp:TextBox>
                        </div>

                        <label for="Height">Height (in):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Height"></asp:TextBox>
                        </div>

                        <label for="Weight">Weight (lb):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Weight"></asp:TextBox>
                        </div>

                        <label for="bf">Body Fat (%):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="BodyFat"></asp:TextBox>
                        </div>

                       <%-- <label for="cg">Calorie Goal:</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Calorie"></asp:TextBox>
                        </div>--%>

                        <asp:Button runat="server" ID="btnStat" CssClass="btn btn-info btn-user btn-block" OnClick="btnStat_Click" Text="Update" />
                    </form>


                </div>
            </div>
        </div>

    </div>













</asp:Content>
