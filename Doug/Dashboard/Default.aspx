<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Doug.Dashboard.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>

        window.onload = function () {
            var ctx = document.getElementById("myActivityChart");
            var myActivityChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ["Entry 1 (Oldest)", "Entry 2", "Entry 3", "Entry 4", "Entry 5", "Entry 6", "Entry 7 (Newest)"],
                    datasets: [{
                        label: "Weight Lifting (mins)",
                        lineTension: 0.3,
                        backgroundColor: "rgb(66, 189, 207, 0.05)",
                        borderColor: "rgb(66, 189, 207, 1)",
                        pointRadius: 3,
                        pointBackgroundColor: "rgb(66, 189, 207, 1)",
                        pointBorderColor: "rgb(66, 189, 207, 1)",
                        pointHoverRadius: 3,
                        pointHoverBackgroundColor: "rgb(66, 189, 207, 1)",
                        pointHoverBorderColor: "rgb(66, 189, 207, 1)",
                        pointHitRadius: 10,
                        pointBorderWidth: 2,
                        data: this.player,
                    }, {
                        label: "Running (mins)",
                        lineTension: 0.3,
                        backgroundColor: "rgb(231, 74, 59, 0.05)",
                        borderColor: "rgba(231, 74, 59, 1)",
                        pointRadius: 3,
                        pointBackgroundColor: "rgba(231, 74, 59, 1)",
                        pointBorderColor: "rgba(231, 74, 59, 1)",
                        pointHoverRadius: 3,
                        pointHoverBackgroundColor: "rgba(231, 74, 59, 1)",
                        pointHoverBorderColor: "rgba(231, 74, 59, 1)",
                        pointHitRadius: 10,
                        pointBorderWidth: 2,
                        data: this.player1,
                    }, {
                        label: "Walking (mins)",
                        lineTension: 0.3,
                        backgroundColor: "rgb(23, 166, 115, 0.05)",
                        borderColor: "rgb(23, 166, 115, 1)",
                        pointRadius: 3,
                        pointBackgroundColor: "rgb(23, 166, 115, 1)",
                        pointBorderColor: "rgb(23, 166, 115, 1)",
                        pointHoverRadius: 3,
                        pointHoverBackgroundColor: "rgb(23, 166, 115, 1)",
                        pointHoverBorderColor: "rgb(23, 166, 115, 1)",
                        pointHitRadius: 10,
                        pointBorderWidth: 2,
                        data: this.player2,
                    }, {
                        label: "Other (mins)",
                        lineTension: 0.3,
                        backgroundColor: "rgba(246, 194, 62, 0.05)",
                        borderColor: "#f6c23e",
                        pointRadius: 3,
                        pointBackgroundColor: "#f6c23e",
                        pointBorderColor: "#f6c23e",
                        pointHoverRadius: 3,
                        pointHoverBackgroundColor: "#f6c23e",
                        pointHoverBorderColor: "#f6c23e",
                        pointHitRadius: 10,
                        pointBorderWidth: 2,
                        data: this.player3,
                    }],
                },
                options: {
                    maintainAspectRatio: false,
                    layout: {
                        padding: {
                            left: 10,
                            right: 25,
                            right: 25,
                            top: 25,
                            bottom: 0
                        }
                    },
                    scales: {
                        xAxes: [{
                            time: {
                                unit: 'date'
                            },
                            gridLines: {
                                display: false,
                                drawBorder: false
                            },
                            ticks: {
                                maxTicksLimit: 7
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                maxTicksLimit: 5,
                                padding: 10,
                            },
                            gridLines: {
                                color: "rgb(234, 236, 244)",
                                zeroLineColor: "rgb(234, 236, 244)",
                                drawBorder: false,
                                borderDash: [2],
                                zeroLineBorderDash: [2]
                            }
                        }],
                    },
                    legend: {
                        display: true
                    }
                }
            });

            var ctx = document.getElementById("myWeightChart");
            var myWeightChart = new Chart(ctx, {
                type: 'line',
                //responsive: true,
                //height: 800,
                data: {
                    labels: ["Entry 1 (Oldest)", "Entry 2", "Entry 3", "Entry 4", "Entry 5", "Entry 6", "Entry 7 (Newest)"],
                    datasets: [{
                        label: "Weight (lb)",
                        lineTension: 0.3,
                        backgroundColor: "rgb(66, 189, 207, 0.05)",
                        borderColor: "rgb(66, 189, 207, 1)",
                        pointRadius: 3,
                        pointBackgroundColor: "rgb(66, 189, 207, 1)",
                        pointBorderColor: "rgb(66, 189, 207, 1)",
                        pointHoverRadius: 3,
                        pointHoverBackgroundColor: "rgb(66, 189, 207, 1)",
                        pointHoverBorderColor: "rgb(66, 189, 207, 1)",
                        pointHitRadius: 10,
                        pointBorderWidth: 2,
                        data: this.point,
                    }, {
                        label: "Body Fat (%)",
                        lineTension: 0.3,
                        backgroundColor: "rgba(246, 194, 62, 0.05)",
                        borderColor: "#f6c23e",
                        pointRadius: 3,
                        pointBackgroundColor: "#f6c23e",
                        pointBorderColor: "#f6c23e",
                        pointHoverRadius: 3,
                        pointHoverBackgroundColor: "#f6c23e",
                        pointHoverBorderColor: "#f6c23e",
                        pointHitRadius: 10,
                        pointBorderWidth: 2,
                        data: this.point1,
                    }],
                },
                options: {
                    maintainAspectRatio: false,
                    layout: {
                        padding: {
                            left: 10,
                            right: 25,
                            top: 25,
                            bottom: 0
                        }
                    },
                    scales: {
                        xAxes: [{
                            time: {
                                unit: 'date'
                            },
                            gridLines: {
                                display: false,
                                drawBorder: false
                            },
                            ticks: {
                                maxTicksLimit: 7
                            }
                        }],
                        yAxes: [{
                            ticks: {
                                maxTicksLimit: 5,
                                padding: 10,
                            },
                            gridLines: {
                                color: "rgb(234, 236, 244)",
                                zeroLineColor: "rgb(234, 236, 244)",
                                drawBorder: false,
                                borderDash: [2],
                                zeroLineBorderDash: [2]
                            }
                        }],
                    },
                    legend: {
                        display: true
                    }
                }
            });
        }

    </script>
    <div class="row">
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Today's Workout</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbDayOfTheWeek" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dumbbell fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-danger shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">Today's Calorie Intake</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbCalorieIntake" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-utensils fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Today's Activity (mins)</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbActivity" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-stopwatch fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Current Weight (lbs)</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbCurrentWeight" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-weight fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-xl-6 col-lg-7">
            <div class="card shadow mb-4">
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Activity Overview</h6>
                </div>
                <div class="card-body">
                    <div class="chart-area">
                        <canvas id="myActivityChart" width="400" height="400"></canvas>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-6 col-lg-5">
            <div class="card shadow mb-4">
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Weight Overview</h6>
                </div>
                <div class="card-body">
                    <div class="chart-area">
                        <canvas id="myWeightChart" width="400" height="1000"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
