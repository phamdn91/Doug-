<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Workouts.aspx.cs" Inherits="Doug.Dashboard.Workouts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 


        <div class=" row">

            


        <div class="center col-xl-8 col-lg-7">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-info">Workouts</h6>

                </div>
                <div class="card-body">
                   <div class="accordion" id="accordionExample">
            <div class="card">
                <div class="card-header" id="headingOne">
                    <h2 class="mb-0">
                        <button class="btn btn-info btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            Day 1 (Lower Focused Full Body)         
                        </button>
                    </h2>
                </div>

                <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordionExample">
                    <div class="card-body">
                        <p>Back Squat | 4x4</p>
                        <p>Dumbbell Incline Press | 3x8</p>
                        <p>Lying Leg Curl | 3X10</p>
                        <p>Supinated EZ Bar Curl | 3x15</p>
                        <p>Hanging Leg Raise | 3x12</p>

                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingTwo">
                    <h2 class="mb-0">
                        <button class="btn btn-info btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            Day 2 (Chest Focused Full Body)         
                        </button>
                    </h2>
                </div>

                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                    <div class="card-body">
                        <p>Barbell Bench Press | 3x3</p>
                        <p>Low To High Cable Fly | 3x15</p>
                        <p>Hip Thrust | 3X12</p>
                        <p>Chest-Supported Row | 3x10</p>
                        <p>Tricep Pressdown | 3x15</p>
                        <p>Shrugs | 3x12</p>

                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingThree">
                    <h2 class="mb-0">
                        <button class="btn btn-info btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            Day 3 (Back Focused Full Body)         
                        </button>
                    </h2>
                </div>

                <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                    <div class="card-body">
                        <p>Weighted Pull-Up | 3x6</p>
                        <p>Humble Row | 3x10</p>
                        <p>Leg Press | 3X15</p>
                        <p>Standing Calf Raise | 4x8</p>
                        <p>Cable Upright Row | 3x10</p>
                        <p>Hammer Curl | 3x8</p>

                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header" id="headingFour">
                    <h2 class="mb-0">
                        <button class="btn btn-info btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseThree">
                            Day 4 (Lower Focused Full Body)         
                        </button>
                    </h2>
                </div>

                <div id="collapseFour" class="collapse" aria-labelledby="headingFour" data-parent="#accordionExample">
                    <div class="card-body">
                        <p>Deadlift | 4x2</p>
                        <p>Dip | 3x10</p>
                        <p>Glute Ham Raise | 3X10</p>
                        <p>Leg Extension | 3x15</p>
                        <p>Cable Pull-Over | 3x15</p>
                        <p>Dumbbell Lateral Raise | 3x20</p>
                        <p>Face Pull | 3x20</p>
                        <p>EZ Bar Skull Crusher | 3x15</p>

                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingFive">
                    <h2 class="mb-0">
                        <button class="btn btn-info btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                            Day 5 (Deltoid Focused Full Body)         
                        </button>
                    </h2>
                </div>

                <div id="collapseFive" class="collapse" aria-labelledby="headingFive" data-parent="#accordionExample">
                    <div class="card-body">
                        <p>Overhead Press | 4x6</p>
                        <p>Egyptian Lateral Raise | 3x8</p>
                        <p>Cable Seated Row | 3X12</p>
                        <p>Seated Hip Abduction | 3x20</p>
                        <p>Incline Dumbbell Curl | 2x10</p>
                        <p>Bicycle Crunch | 3x15</p>
                        <p>Standing Calf Raise | 4x12</p>
                        <p>Push Up | 2xMax Out</p>

                    </div>
                </div>
            </div>


              </div>
                </div>
            </div>
        </div>

    </div>


        
   
</asp:Content>


