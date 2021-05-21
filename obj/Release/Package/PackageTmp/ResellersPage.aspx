<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ResellersPage.aspx.cs" Inherits="MangAtongsPrototype.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-center bg-light">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h1 class="display-5 fw-normal mons" style="font-weight: 600;">Resellers</h1>
            </div>
        </div>
        <div class="row no-gutters rounded" style="background-color: #ffb28f; padding: 20px;">
            <div class="col-12 col-md-7">
                <div class="jumbotron my-auto mons" style="background-color: #ffb28f;">
                    <h2 class="display-5">Do you want to resell our products to gain more money?</h2>
                    <hr class="my-4">
                    <p class="mynav">Say no more to Mang Atong's, as we are open for any resellers or distributor of our products. </p>
                    <p class="mynav">We are glad to help you with your business by providing you the best frozen products that will definitely satisfy your customers.</p>
                    <br />
                    <a class="btn btn-primary btn-lg mynav" href="ContactUsPage.aspx" role="button">Contact Us</a>
                </div>

            </div>

            <div class="col-12 col-md-5 my-auto">
                <img src="../images/resellerpic.jpg" class="img-fluid" style="border-radius: 20px;" />
            </div>
        </div>

        <div class="row bg-dark" style="margin: 0 2px 0; padding: 20px 10px 20px;">
            <div class="col-3"></div>

            <%--Carousel Showcase of Customers--%>
            <div class="col-12 col-md-6 text-center">
                <div id="Featured" class="carousel slide my-auto" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="Featured" data-slide-to="0" class="active"></li>
                        <li data-target="Featured" data-slide-to="1"></li>
                        <li data-target="Featured" data-slide-to="2"></li>
                    </ol>

                    <!--Place images in the carousel-->
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="../images/abt2.jpg" class="d-block img-fluid" alt="...">
                        </div>

                        <div class="carousel-item">
                            <img src="../images/abt3.jpg" class="d-block img-fluid" alt="...">
                        </div>

                        <div class="carousel-item">
                            <img src="../images/abt4.jpg" class="d-block img-fluid " alt="...">
                        </div>

                    </div>

                    <a class="carousel-control-prev" href="#Featured" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span><span class="sr-only">Previous</span>
                    </a>

                    <a class="carousel-control-next" href="#Featured" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span><span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
            <div class="col-3"></div>
        </div>

        <div class="row no-gutters rounded" style="background-color: #ffb28f; padding: 20px;">
            <div class="col-12 col-md-5 my-auto">
                <img src="../images/resellerpic2.jpg" class="img-fluid" style="border-radius: 20px;" />
            </div>
            <div class="col-12 col-md-7">
                <div class="jumbotron my-auto mons" style="background-color: #ffb28f;">
                    <h2 class="display-5">Do you want to resell our products to gain more money?</h2>
                    <hr class="my-4">
                    <p class="mynav">Say no more to Mang Atong's, as we are open for any resellers or distributor of our products. </p>
                    <p class="mynav">We are glad to help you with your business by providing you the best frozen products that will definitely satisfy your customers.</p>
                    <br />
                    <a class="btn btn-primary btn-lg mynav" href="ContactUsPage.aspx" role="button">Contact Us</a>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
