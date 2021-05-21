<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminItemManagement.aspx.cs" Inherits="MangAtongsPrototype.ASPX.AdminItemManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Grid {
            border: solid 2px Tan;
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
    <div class="container-fluid mons">
        <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
             <div class="col-md-5 p-lg-5 mx-auto" style="padding: 10px 15px 10px">
                <h2 class="display-5 fw-normal mons" style="font-weight: 600;">Item Management</h2>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-12 col-sm-12 col-md-3">
                <div class="card">
                    <div class="card-body">
                        <p class="card-title">Navigation</p>
                        <div class="btn-group-vertical">
                            <asp:LinkButton runat="server" class="btn btn-link text-left btn-block" ID="AllProducts" OnClick="AllProducts_Click">
							    All Products
                            </asp:LinkButton>

                            <asp:LinkButton runat="server" class="btn btn-link text-left btn-block" ID="ChickenButton" OnClick="Chicken_Click">
							    Chicken
                            </asp:LinkButton>

                            <asp:LinkButton runat="server" class="btn btn-link text-left btn-block" ID="BeefButton" OnClick="Beef_Click">
							    Beef
                            </asp:LinkButton>

                            <asp:LinkButton runat="server" class="btn btn-link text-left btn-block" ID="OthersButton" OnClick="Others_Click">
							   Others
                            </asp:LinkButton>
                        </div>

                    </div>
                </div>
                <br />
            </div>


            <div class="col-12 col-sm-12 col-md-9">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-2 my-auto">
                            </div>
                            <div class="col text-center my-auto form-group">
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" ID="itemSearch" CssClass="form-control mynav" aria-label="Search" aria-describedby="SearchButton" placeholder="Input Product ID to Search/Select"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:Button runat="server" CssClass="btn btn-info" ID="searchID" Text="Search" OnClick="SearchItem_Click" />
                                        <span></span>
                                        <asp:Button runat="server" ID="backButton" Text="Go Back" CssClass="btn btn-danger" OnClick="Back_Click" />
                                    </div>

                                </div>
                            </div>
                            <div class="col-2"></div>
                        </div>

                        <div class="overflow-hidden text-center bg-light">
                            <div class="col-md-5 p-lg-3 mx-auto" style="padding: 0px 10px 0px">
                                <h4 class="display-5 fw-normal mons" style="font-weight: 600;">Items List</h4>
                            </div>
                        </div>

                        <div class="overflow-auto" style="margin: 10px 0px 10px">
                            <div class="vertical-align top; height: 152px; overflow:auto; width:850px;">
                                <asp:DataGrid ID="DataGrid1" runat="server" CssClass="Grid">
                                    <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                                </asp:DataGrid>
                            </div>
                        </div>

                        <div class="row cent">
                            <div class="col-12 col-lg-4">
                                <a href="AdminAddItem.aspx" role="button" class="btn btn-success btn-block">Add Item</a>
                            </div>
                            <div class="col-12 col-lg-4">
                                <asp:LinkButton runat="server" ID="LinkButton1" OnClick="UpdateItem_Click">
							                    <button type="button" class="btn btn-warning btn-block">Update Item</button>
                                </asp:LinkButton>
                            </div>
                            <div class="col-12 col-lg-4">
                                <asp:Button runat="server" Text="Remove Item" CssClass="btn btn-danger btn-block" ID="DeleteButton" Style="height: 100%;" OnClick="DeleteItem_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Modal for Function Confirmation--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="modal fade" id="AdminItemManagementModal" tabindex="-1" aria-labelledby="AdminItemManagementModalLabel" data-backdrop="static" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="AdminItemManagementModalLabel">Add to Cart</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="firstPhrase" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lastPhrase" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="Proceed" CssClass="btn btn-success" Text="Proceed" data-dismiss="modal" UseSubmitBehavior="false" OnClick="Proceed_Click"></asp:Button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
