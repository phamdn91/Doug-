<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Diary.aspx.cs" Inherits="Doug.Dashboard.Diary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class=" row">
        <div class="col-xl-6 col-lg-5">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Track Today's Calories</h6>
                </div>
                <div class="card-body">
                    <form class="user">
                        <label for="dg">Daily Goal (cal):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Calorie"></asp:TextBox>
                        </div>
                        <label for="breakfast">Breakfast (cal):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Breakfast"></asp:TextBox>
                        </div>
                        <label for="lunch">Lunch (cal):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Lunch"></asp:TextBox>
                        </div>
                        <label for="dinner">Dinner (cal):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Dinner"></asp:TextBox>
                        </div>
                        <label for="snacks">Snacks (cal):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Snacks"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" ID="btnDiary" CssClass="btn btn-info btn-user btn-block" OnClick="btnDiary_Click" Text="Update" />
                        <p id="result"></p>
                </div>
            </div>
        </div>
        <div class="col-xl-6 col-lg-5">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Track Today's Activity</h6>
                </div>
                <div class="card-body">
                    <form class="user">
                        <label for="fname">Weight Lifting (mins):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="WeightLifting"></asp:TextBox>
                        </div>
                        <label for="lname">Running (mins):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Running"></asp:TextBox>
                        </div>
                        <label for="email">Walking (mins):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Walking"></asp:TextBox>
                        </div>
                        <label for="username">Other (mins):</label>
                        <div class="form-group">
                            <asp:TextBox type="number" CssClass="form-control form-control-user" runat="server" ID="Other"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" ID="btnActivity" CssClass="btn btn-info btn-user btn-block" OnClick="btnActivity_Click" Text="Update" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
