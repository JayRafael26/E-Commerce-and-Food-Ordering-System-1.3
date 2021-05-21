<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="MangAtongsPrototype.ASPX.AdminOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Grid {
            border: solid 2px Tan;
            Width: 100%;
            vertical-align: top;
            height: 10%;
            overflow: auto;
            width: 100%;
        }

        .GridHeader {
            font-weight: bold;
            background-color: #FFCCCC;
            text-align: center;
        }

        .Grid td {
            border: solid 3px #000000;
            margin: 3px 3px 3px 3px;
            font-family: Arial;
            padding: 5px 5px 5px 5px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 10px 15px 10px">
                <h2 class="display-5 fw-normal mons" style="font-weight: 600;">Orders</h2>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-lg-1"></div>


            <div class="card col-12 col-lg-10">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-2 my-auto">
                            </div>
                            <div class="col text-center my-auto form-group">
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" ID="itemSearch" CssClass="form-control mynav" aria-label="Search" aria-describedby="SearchButton" placeholder="Input Product ID to Search/Select"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:Button runat="server" CssClass="btn btn-info button-size" ID="searchID" Text="Search" OnClick="SearchItem_Click" />
                                        <span></span>
                                        <asp:Button runat="server" ID="backButton" Text="Go Back" CssClass="btn btn-danger button-size" OnClick="Back_Click" />
                                    </div>

                                </div>
                            </div>
                            <div class="col-2"></div>
                        </div>
                        <br />

                        <div class="overflow-hidden text-center bg-light">
                            <div class="col-md-5 p-lg-3 mx-auto" style="padding: 0px 0 0px">
                                <h3 class="display-5 fw-normal mons" style="font-weight: 600;">List of Orders</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col overflow-auto">
                                    
                                    <asp:DataGrid ID="OrderDataGrid" runat="server" CssClass="Grid" PageSize="12" AllowPaging="true" PagerStyle-Mode="NumericPages" PagerStyle-PageButtonCount="5" OnPageIndexChanged="Grid_Change">
                                        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                                    </asp:DataGrid>
                                </div>
                        </div>

                        <hr />

                        <div class="row cent">
                            <div class="col-12 col-lg-6">
                                <asp:LinkButton runat="server" class="btn btn-warning btn-block" ID="LinkButton1" OnClick="ViewOrder_Click">
							                   View Order
                                </asp:LinkButton>
                            </div>
                            <div class="col-12 col-lg-6">
                                <asp:LinkButton runat="server" class="btn btn-danger btn-block" ID="AllButton" OnClick="AllOrders_Click">
						                       All Orders
                                </asp:LinkButton>

                            </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1">
            </div>

        </div>

    </div>
</asp:Content>
