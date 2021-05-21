<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AboutUsPage.aspx.cs" Inherits="MangAtongsPrototype.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #map {
            height: 400px;
            /* The height is 400 pixels */
            width: 100%;
            /* The width is the width of the web page */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-center bg-light">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h1 class="display-5 fw-normal mons" style="font-weight: 600;">About Us</h1>
            </div>
        </div>
        <div class="row row-cols-1 row-cols-lg-2" style="margin: auto;">
            <div class="col text-center bg-dark text-white" style="padding: 20px 50px 10px;">
                <div class="my-3 py-3" style="border-radius: 5px;">
                    <h3 class="display-5">Special Treat for your Loved Ones?</h3>
                    <h4>Worry no more! </h4>
                    <p class="lead" style="text-align: center;">Mang Atong's Meat will give you the sweetness your are looking for! One of the most awaited frozen products that's easy to cook and will definitely satisfy your taste!</p>

                    <img class="d-none d-md-block w-100 " src="../images/banner.png">
                    <br /><br />
                        <a href="ChickenPage.aspx" class="btn btn-warning btn-lg" role="button">Browse Our Products</a>
                </div>
            </div>
            <br />
            <div class="col text-center" style="padding: 20px 50px 10px; background-color: #ffb28f;">
                <div class="my-3 py-3" style="border-radius: 5px;">
                <h3 class="display-5 text-white">Our Satisfied Customers</h3>
                    <br />
                <div class="container-fluid">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="5"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img class="d-block w-100 img-fluid" src="../images/abt2.jpg" alt="Second slide" style="margin: auto; border-radius: 20px;">
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100 img-fluid" src="../images/abt3.jpg" alt="Third slide" style="margin: auto; border-radius: 20px;">
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100 img-fluid" src="../images/abt4.jpg" alt="Fourth slide" style="margin: auto; border-radius: 20px;">
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100 img-fluid" src="../images/abt5.jpg" alt="Fifth slide" style="margin: auto; border-radius: 20px;">
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100 img-fluid" src="../images/abt6.jpg" alt="Sixth slide" style="margin: auto; border-radius: 20px;">
                            </div>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>
                    </div>
            </div>
        </div>
        <div class="row">
            <div class="col mb-4">
                <div class="jumbotron jumbotron-fluid text-center" style="background-color: #e3f2fd; margin-bottom: 0; padding: 60px">
                    <h2>Have more Questions?</h2>
                    <p class="lead">Feel free to reach out to us or Ask us your question.</p>
                    <a href="ContactUsPage.aspx" class="btn btn-primary btn-lg" role="button">Contact Us</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
