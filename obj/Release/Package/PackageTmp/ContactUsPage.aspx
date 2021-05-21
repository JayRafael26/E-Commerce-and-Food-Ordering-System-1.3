<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUsPage.aspx.cs" Inherits="MangAtongsPrototype.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-center bg-light">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h1 class="display-5 fw-normal mons" style="font-weight: 600;">Contact Us</h1>
            </div>
        </div>
        <div class="row row-cols-1 row-cols-lg-2" style="margin: auto;">
            <div class="col text-center" style="line-height: 2; background-color: #ffb28f;">
                <div class="my-3 py-3" style="border-radius: 5px; padding: 10px 10px 10px;">
                    <img src="../images/logo.png" class="img-fluid rounded-circle " style="width: 45%;" />
                    <br />
                    <hr />
                    <p>
                        If you have any questions or queries a member of staff will 
                    always be happy to help. Feel free to contact us by telephone or email 
                    and we will be sure to get back to you as soon as possible.
                    </p>
                </div>
            </div>
            <div class="col text-center bg-dark text-white" style="line-height: 2;">
                <div class="my-3 py-3" style="border-radius: 5px;">
                    <div class="row row-cols-1 row-cols-lg-2" style="padding: 60px 10px 20px; border-radius: 5px;">
                        <div class="col text-center">
                            <p><i class="fas fa-mobile-alt fa-5x"></i></p>
                            <span>Contact Number</span>
                            <p>+63 927 478 4074</p>
                        </div>

                        <div class="col text-center">
                            <p><i class="fas fa-envelope fa-5x"></i></p>
                            <span>Email Us </span>
                            <p>mangatongsgoods@gmail.com</p>
                        </div>
                    </div>
                    <div class="row row-cols-1 row-cols-lg-1" style="padding: 10px 10px 20px; border-radius: 5px;">
                        <div class="col text-center">
                            <p><i class="fab fa-facebook-f fa-4x"></i></p>
                            <span>Reach Us on Facebook!</span>
                            <p>
                                <a href="https://www.facebook.com/MangAtongs" class="btn btn-outline-light" role="button">Mang Atong's Meat</a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row ">
            <div class="container-fluid">
                <div class="col mb-4 my-auto  map-responsive">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3859.0390995328103!2d121.08450101484149!3d14.710380989732606!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3397bb1ef3482af1%3A0xf3f1273abd362120!2sMang%20Atong&#39;s%20Frozen%20Food%20and%20Special%20Goods!5e0!3m2!1sen!2sph!4v1617812937091!5m2!1sen!2sph" width="800" height="600" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
