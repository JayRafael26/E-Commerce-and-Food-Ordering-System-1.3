<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="MangAtongsPrototype.ASPX.SearchPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <br />
                <div class="container-fluid">
                    <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
                        <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                            <h2 class="display-5 fw-normal" style="font-weight: 800;">Search Results</h2>
                        </div>
                    </div>
                    <br />
                    <div class="row row-cols-1 row-cols-lg-3">
                        <asp:Repeater runat="server" ID="repeater">
                            <ItemTemplate>
                                <div class="col mb-4">
                                    <div class="card card-effect mynav">
                                        <img src='<%# Eval("ImagePath") %>' class="card-img-top" alt='<%# Eval("ProductName") %>'>
                                        <div class="card-body">
                                            <h4 class="card-title">
                                                <asp:Label ID="label1" runat="server" Text='<%# Eval("ProductName") %>' />
                                            </h4>
                                            <p class="card-text">
                                                <asp:Label ID="description" runat="server" Text='<%# Eval("ProductDescription") %>'></asp:Label>
                                                <br />
                                                Price: <span style="color: green;">₱<asp:Label ID="label2" runat="server" Text='<%# Eval("ProdPrice") %>' />
                                                </span>
                                                <br />
                                                Available Stock:
                                                <asp:Label ID="ProdQuantity" Style="color: cornflowerblue;" runat="server" Text='<%# Eval("ProductQuantity") %>' />
                                            </p>
                                        </div>
                                        <div class="card-footer">
                                            <div class="row">
                                                <div class="col cent">
                                                    <asp:Label ID="QuantityLabel" runat="server" Text="Quantity: "></asp:Label>
                                                    <div class="input-group inline-group">
                                                        <%--<asp:TextBox ID="txtQuantity" Style="text-align: center;" CssClass="form-control form-control-sm button-size" runat="server" value="1" min="1" ClientIDMode="Static"></asp:TextBox>--%>
                                                        <asp:TextBox ID="txtQuantity" CssClass="form-control form-control-sm cent" TextMode="Number" value="1" runat="server" min="1" max='<%# Eval("ProductQuantity") %>' step="1" AutoPostBack="false" />
                                                    </div>
                                                </div>

                                                <div class="col cent">
                                                    <asp:Label ID="PID" runat="server" Text='<%# Eval("ProductID")%>' Visible="false"></asp:Label>
                                                    <asp:Button CssClass="btn btn-warning btn-block" Style="height: 100%;" Text="Add to Cart" runat="server" OnClick="AddToCart_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <%--Modal for Remove Confirmation--%>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="modal fade" id="AddedToCartModal" tabindex="-1" aria-labelledby="AddedToCartModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="RemoveModalLabel">Add to Cart</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="firstPhrase" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="condition" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="addedItem" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lastPhrase" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Label ID="ProdID" runat="server" Text="" Visible="False"></asp:Label>
                                        <asp:Button runat="server" ID="ProceedToLogin" CssClass="btn btn-success" Text="Proceed to Log-in Page" data-dismiss="modal" UseSubmitBehavior="false" OnClick="ProceedToLogin_Click"></asp:Button>
                                        <asp:Button runat="server" ID="AddMoreItemsButton" CssClass="btn btn-primary" Text="Add More Items" data-dismiss="modal"></asp:Button>
                                        <asp:Button runat="server" ID="ProceedToCartButton" class="btn btn-success" data-dismiss="modal" Text="Proceed to Cart" UseSubmitBehavior="false" OnClick="ProceedToCart_Click"></asp:Button>
                                        <asp:Button runat="server" ID="closeButton" class="btn btn-danger" data-dismiss="modal" Text="Close" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
