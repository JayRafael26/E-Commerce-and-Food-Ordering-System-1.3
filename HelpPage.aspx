<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HelpPage.aspx.cs" Inherits="MangAtongsPrototype.HelpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mons">
        <br />
         <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto">
                <h1 class="display-5 fw-normal mons" style="font-weight: 600;">Frequently Asked Questions</h1>
            </div>
        </div>
        <br />
        <div class="row row-cols-1 row-cols-lg-3">
            <div class="col">
                <div class="accordion" id="accordion">
                    <div class="card">
                        <div class="card-header" id="headingOne">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    What / Where do you sell?
                                </button>
                            </h5>
                        </div>

                        <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                            <div class="card-body lead fw-normal">
                                <p>We sell various frozen meat (non-pork) products which are both ready-made or raw. 
                                Typically sells in Metro Manila Area, We deliver on bulk orders or you can have them picked up on our location!</p>
                                
                                <span style="font-size: 1.6vmin !important;">Note: Raw meat products will be subject for availability. Pre order is preferred specially for those who wish to request bulk orders (3-4 days advance preferred)</span>
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header" id="headingTwo">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed med" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                    What are your payment methods?
                                </button>
                            </h5>
                        </div>
                        <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                            <div class="card-body">
                                Mang Atong's accepts: Cash on Delivery, Gcash, Bank Transfer(Bpi, PSBank, Security Bank).        
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header" id="headingThree">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed med" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                    How are deliveries made?
                                </button>
                            </h5>
                        </div>
                        <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                            <div class="card-body">
                                Delivery Service: Via Grab Delivery (will be shouldered by the customer), Personal delivery(payment depends to location, lesser as much as possible)
                            </div>
                        </div>
                    </div>

                </div>
                <br />
            </div>

            <div class="col">
                <div class="accordion" id="accordion2">
                    <div class="card">
                        <div class="card-header" id="headingOne2">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseOne2" aria-expanded="true" aria-controls="collapseOne2">
                                    What / Where do you sell?
                                </button>
                            </h5>
                        </div>

                        <div id="collapseOne2" class="collapse" aria-labelledby="headingOne2" data-parent="#accordion2">
                            <div class="card-body fw-normal">
                                <p>
                                    We sell various frozen meat (non-pork) products which are both ready-made or raw. 
                                Typically sells in Metro Manila Area, We deliver on bulk orders or you can have them picked up on our location!
                                </p>
                                <span style="font-size: 0.8rem !important;">Note: Raw meat products will be subject for availability. Pre order is preferred specially for those who wish to request bulk orders (3-4 days advance preferred)</span>
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header" id="headingTwo2">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo2" aria-expanded="false" aria-controls="collapseTwo2">
                                    What are your payment methods?
                                </button>
                            </h5>
                        </div>
                        <div id="collapseTwo2" class="collapse" aria-labelledby="headingTwo2" data-parent="#accordion2">
                            <div class="card-body">
                                Mang Atong's accepts: Cash on Delivery, Gcash, Bank Transfer(Bpi, PSBank, Security Bank).        
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header" id="headingThree2">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseThree2" aria-expanded="false" aria-controls="collapseThree2">
                                    How are deliveries made?
                                </button>
                            </h5>
                        </div>
                        <div id="collapseThree2" class="collapse" aria-labelledby="headingThree2" data-parent="#accordion2">
                            <div class="card-body">
                                Delivery Service: Via Grab Delivery (will be shouldered by the customer), Personal delivery(payment depends to location, lesser as much as possible)
                            </div>
                        </div>
                    </div>

                </div>
                <br />
            </div>

            <div class="col">
                <div class="accordion" id="accordion3">
                    <div class="card">
                        <div class="card-header" id="headingOne3">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseOne3" aria-expanded="true" aria-controls="collapseOne3">
                                    What / Where do you sell?
                                </button>
                            </h5>
                        </div>

                        <div id="collapseOne3" class="collapse" aria-labelledby="headingOne3" data-parent="#accordion3">
                            <div class="card-body fw-normal">
                                <p>
                                    We sell various frozen meat (non-pork) products which are both ready-made or raw. 
                                Typically sells in Metro Manila Area, We deliver on bulk orders or you can have them picked up on our location!
                                </p>
                                <span style="font-size: 0.8rem !important;">Note: Raw meat products will be subject for availability. Pre order is preferred specially for those who wish to request bulk orders (3-4 days advance preferred)</span>
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header" id="headingTwo3">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo3" aria-expanded="false" aria-controls="collapseTwo3">
                                    What are your payment methods?
                                </button>
                            </h5>
                        </div>
                        <div id="collapseTwo3" class="collapse" aria-labelledby="headingTwo3" data-parent="#accordion3">
                            <div class="card-body">
                                Mang Atong's accepts: Cash on Delivery, Gcash, Bank Transfer(Bpi, PSBank, Security Bank).        
                            </div>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header" id="headingThree3">
                            <h5 class="mb-0">
                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseThree3" aria-expanded="false" aria-controls="collapseThree3">
                                    How are deliveries made?
                                </button>
                            </h5>
                        </div>
                        <div id="collapseThree3" class="collapse" aria-labelledby="headingThree3" data-parent="#accordion3">
                            <div class="card-body">
                                Delivery Service: Via Grab Delivery (will be shouldered by the customer), Personal delivery(payment depends to location, lesser as much as possible)
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>

        <hr class="my-4">
        <div class="row">
            <div class="col">
                <div class="jumbotron jumbotron-fluid text-center" style="background-color: #e3f2fd; margin-bottom: 0">
                    <h2>Have more Questions?</h2>
                    <p class="lead">Feel free to reach out to us or Ask us your question.</p>
                    <a href="ContactUsPage.aspx" class="btn btn-primary btn-lg" role="button">Contact Us</a>
                </div>
            </div>

        </div>
        
        <%--<div class="row">
            <div class="col-1"></div>
            <div class="col">
                <div class="card card-body">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Ask us anything.</label>              
                        <input type="text" class="form-control" id="UserEmail" aria-describedby="emailHelp" readonly="readonly" runat="server" />                               
                        <small id="emailHelp" class="form-text text-muted">Your email will not be shared.</small>
                    </div>
                    <div class="form-group">
                        <input type="text" class="form-control" id="UserQuery" placeholder="Your Question" runat="server"/>
                    </div>
                     
                    <asp:Button ID="Button1" class="btn btn-primary btn-sm" OnClick="SubmitQuery_Click" runat="server" Text="Submit" />
                </div>
            </div>
            <div class="col-1"></div>
        </div>--%>

      
    </div>
</asp:Content>
