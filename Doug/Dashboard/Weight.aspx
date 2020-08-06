<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Weight.aspx.cs" Inherits="Doug.Dashboard.Weight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
     
        window.onload = function () {
            var ctx = document.getElementById("myWeightChart");
            var myWeightChart = new Chart(ctx, {
                type: 'line',
                responsive: true,
                height: 800,
                data: {
                    labels: ["Week 1", "Week 2", "Week 3", "Week 4", "Week 5", "Week 6", "Week 7", "Week 8", "Week 9", "Week 10", "Week 11", "Week 12"],
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
                        data: [200, 195, 193, 190, 188, 185, 184, 181, 179, 175, 173, 170],
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
    <div class="container">

  <%--      <div class="col-xl-8 col-lg-7">
                <div class="card shadow mb-4">
                    <!-- Card Header - Dropdown -->
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                        <h6 class="m-0 font-weight-bold text-info">Calories</h6>
                    </div>
                    <div class="card-body">

                            <label for="dg">Daily Goal (cal):</label>
                            <input class="form-control form-control-user" type="number" id="dg" name="dg" value="2000"><br>
                            <label for="breakfast">Breakfast (cal):</label>
                            <input class="form-control form-control-user" type="number" id="breakfast" name="breakfast"><br>
                            <label for="lunch">Lunch (cal):</label>
                            <input class="form-control form-control-user" type="number" id="lunch" name="lunch"><br>
                            <label for="dinner">Dinner (cal):</label>
                            <input class="form-control form-control-user" type="number" id="dinner" name="dinner"><br>
                            <label for="snacks">Snacks (cal):</label>
                            <input class="form-control form-control-user" type="number" id="snacks" name="snacks"><br>
                            <button type="button" class="btn btn-info btn-user btn-block" onclick="myFunction(); return false;">Calculate</button><br>
                   
                        <p id="result"></p>

                    </div>
                </div>
            </div>--%>

        <!-- Area Chart -->
<%--        <div class="col-xl-8 col-lg-7">--%>
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Weight Overview</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <canvas id="myLineChart" width="400" height="1000"></canvas>
                    </div>
                </div>
            </div>
        </div>


 <%--   </div>--%>


</asp:Content>
