<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MangAtongsPrototype.WebForm2" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@900&display=swap" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto my-5">
                <h1 class="display-4 fw-normal" style="color: white; font-weight: 600;">Welcome to
                    <br />
                    Mang Atong's</h1>
                <p class="lead fw-normal">We are a One-Stop-Shop for all your Meat and Special Goods need. We offer different kinds of products including fresh, frozen and marinated meat.</p>
                <a class="btn btn-outline-secondary" href="#">About Us</a>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row row-cols-1 row-cols-lg-2 cent">
                <div class="col bg-light">
                    <div class="my-3 py-3">
                        <h2 class="display-5">Raw Products</h2>
                        <p class="lead">Various Fresh Beef Parts perfect for any occassion.</p>
                    </div>
                    <div class="bg-dark shadow-sm mx-auto" style="width: 80%; border-radius: 21px 21px 0 0;">
                        <div style="padding: 20px 20px 0">
                            <img src="../../../images/showcase1.jpg" class="img-fluid" style="border-radius: 21px 21px 0 0;" />
                        </div>

                    </div>
                </div>

                <div class="col bg-light">
                    <div class="my-3 p-3">
                        <h2 class="display-5">Homemade Products</h2>
                        <p class="lead">Delicious and Mouth watering food perfect for any meal.</p>
                    </div>
                    <div class="bg-dark shadow-sm mx-auto" style="width: 67%; border-radius: 21px 21px 0 0;">
                        <div style="padding: 20px 20px 0">
                            <img src="../../../images/rsz_showcase2.png" class="img-fluid" style="border-radius: 21px 21px 0 0;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid text-center" style="background-color: #ffb28f; padding-top: 10px; padding-bottom: 20px;">
            <div class="row row-cols-1 row-cols-lg-3">
                <div class="col">
                </div>
                <div class="col">
                    <div class="my-3">
                        <h2 class="display-5 text-white">Featured Products</h2>
                    </div>
                </div>

                <div class="col">
                </div>
            </div>
            <div class="row text-center">
                <div class="col-2"></div>
                <div class="col cent">
                    <div id="Featured" class="carousel slide" data-ride="carousel">
                        <!--Place images in the carousel-->
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="../../../images/chickenlongganisa.jpg" class="img-fluid" style="margin: auto; border-radius: 20px;" alt="...">
                            </div>

                            <div class="carousel-item">
                                <img src="../../images/beeftapa.jpg" class="img-fluid" style="margin: auto; border-radius: 20px;" alt="...">
                            </div>

                            <div class="carousel-item">
                                <img src="../../images/chickentocino.jpg" class="img-fluid" style="margin: auto; border-radius: 20px;" alt="...">
                            </div>
                        </div>

                        <a class="carousel-control-prev" href="#Featured" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#Featured" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>

                    </div>
                </div>
                <div class="col-2"></div>
            </div>

        </div>

        <div class="row row-cols-1 row-cols-lg-2 cent" style="margin: auto;">
            <div class="col bg-light" style="width: 80%; height: 80%;">
                <div class="my-3 py-3">
                    <h2 class="display-5">Chicken Products</h2>
                    <p class="lead">We offer delicous handmade chicken products that will satisfy your cravings!</p>
                </div>
                <div class="bg-light shadow-sm mx-auto" style="width: 80%; height: 80%; border-radius: 21px 21px 0 0;">
                    <div class="collage-container" style="width: 100%; height: 100%; border-radius: 21px 21px 0 0;">
                        <img src="../images/ChickenCollage.png" alt="" class="img-fluid" style="width: 100%; height: 100%; border-radius: 21px 21px 0 0;" />
                        <div class="collage-title">
                            <a href="ChickenPage.aspx">
                            <img src="../images/ChickenFront.png" class="img-fluid" />
                            </a>
                        </div>
                        <div class="overlay" style="border-radius: 21px 21px 0 0;"></div>
                        <a href="ChickenPage.aspx" role="button" class="button btn btn-info">Click Here</a>
                    </div>

                </div>
            </div>

            <div class="col bg-light" style="width: 80%; height: 80%;">
                <div class="my-3 py-3">
                    <h2 class="display-5">Beef Products</h2>
                    <p class="lead">AWe offer delicous handmade and raw beef products that will satisfy your cravings!.</p>
                </div>
                <div class="bg-light shadow-sm mx-auto" style="width: 80%; height: 80%; border-radius: 21px 21px 0 0;">
                    <div class="collage-container" style="width: 100%; height: 100%; border-radius: 21px 21px 0 0;">
                        <img src="../images/BeefCollage.png" alt="" class="img-fluid" style="width: 100%; height: 100%; border-radius: 21px 21px 0 0;" />
                        <div class="collage-title">
                            <a href="BeefPage.aspx">
                                <img src="../images/BeefFront.png" class="img-fluid" />
                            </a>
                        </div>
                        <div class="overlay" style="border-radius: 21px 21px 0 0;"></div>
                        <a href="BeefPage.aspx" role="button" class="button btn btn-info">Click Here</a>
                    </div>

                </div>
            </div>
        </div>


        <div class="container-fluid text-center" style="background-color: #ffb28f; padding: 10px 10px 10px;">
            <div class="row">
                <div class="col-2">
                </div>
                <div class="col">
                    <div class="my-3 p-3">
                        <h2 class="display-5 text-white">Best-Selling Products</h2>
                    </div>
                </div>

                <div class="col-2">
                </div>
            </div>
            <div class="row row-cols-1 row-cols-lg-3">
                <div class="col mb-4">
                    <div class="card card-effect">
                        <img src="../images/chickentocino.jpg" class="card-img-top" alt="Chicken Tocino">
                        <div class="card-body">
                            <p class="card-title med">
                                <asp:Label ID="label1" runat="server" Text='Chicken Tocino' />
                            </p>
                            <p class="card-text">
                                This is a longer card with supporting text below as a natural lead-in to additional content.
                                                    <br />
                                Price: <span class="productprice">
                                    <asp:Label ID="label2" runat="server" Text='P 150.00' />
                                </span>
                                <br />
                            </p>
                        </div>
                        <div class="card-footer">
                            <div class="row">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col mb-4">
                    <div class="card card-effect">
                        <img src="../images/beeftapa.jpg" class="card-img-top" alt="Beef Tapa">
                        <div class="card-body">
                            <p class="card-title med">
                                <asp:Label ID="label3" runat="server" Text='Beef Tapa' />
                            </p>
                            <p class="card-text">
                                This is a longer card with supporting text below as a natural lead-in to additional content.
                                                    <br />
                                Price: <span class="productprice">
                                    <asp:Label ID="label4" runat="server" Text='P 160.00' />
                                </span>
                                <br />
                            </p>
                        </div>
                        <div class="card-footer">
                            <div class="row">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col mb-4">
                    <div class="card card-effect">
                        <img src="../images/chickenlongganisa.jpg" class="card-img-top" alt="Chicken Longganisa">
                        <div class="card-body">
                            <p class="card-title med">
                                <asp:Label ID="label5" runat="server" Text='Chicken Longganisa' />
                            </p>
                            <p class="card-text">
                                This is a longer card with supporting text below as a natural lead-in to additional content.
                                                    <br />
                                Price: <span class="productprice">
                                    <asp:Label ID="label6" runat="server" Text='P 150.00' />
                                </span>
                                <br />
                            </p>
                        </div>
                        <div class="card-footer">
                            <div class="row">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row no-gutters rounded" style="background-color: #ffe4c4; padding: 20px;">
            <div class="col-12 col-md-7">
                <div class="jumbotron my-auto mons" style="background-color: #ffe4c4;">
                    <p class="lead med">Do you want to resell our products to gain more money?</p>
                    <hr class="my-4">
                    <p class="mynav">Say no more to Mang Atong's, as we are open for any resellers or distributor of our products. </p>
                    <p class="mynav">We are glad to help you with your business by providing you the best frozen products that will definitely satisfy your customers.</p>
                    <br />
                    <a class="btn btn-primary btn-lg mynav" href="ResellersPage.aspx" role="button">Go to Resellers Page</a>
                </div>

            </div>

            <div class="col-12 col-md-5 my-auto">
                <img src="../images/resellerpic.jpg" class="img-fluid" />
            </div>
        </div>
            <div class="row">
                <div class="col">
                    <div class="jumbotron jumbotron-fluid text-center" style="background-color: #8fdbff; margin-bottom: 0">
                        <h2>Have more Questions?</h2>
                        <p class="lead">Feel free to reach out to us or Ask us your question.</p>
                        <a href="ContactUsPage.aspx" class="btn btn-primary btn-lg" role="button">Contact Us</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
