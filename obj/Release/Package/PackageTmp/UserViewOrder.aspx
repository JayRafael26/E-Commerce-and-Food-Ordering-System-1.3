<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserViewOrder.aspx.cs" Inherits="MangAtongsPrototype.ASPX.UserViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-white" style="background-color: #ffb28f;">
            <a href="UserOrders.aspx" role="button" class="btn btn-danger">Back</a>
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h1 class="display-5 fw-normal mons text-center " style="font-weight: 600;">Order #<asp:Label runat="server" ID="OrderID"></asp:Label></h1>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="container-fluid">
                <table class="table align-middle text-center table-hover table-borderless" style="margin-bottom: 0;">
                    <thead class="thead-dark">
                        <tr class="row">
                            <th scope="col" class="d-none d-md-block col-lg-3">Image</th>
                            <th scope="col" class="col-4 col-lg-3">Name</th>
                            <th scope="col" class="col-4 col-lg-3">Price</th>
                            <th scope="col" class="col-4 col-lg-3">Quantity</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="ViewOrderedItems" runat="server">

                            <ItemTemplate>
                                <tr class="row align-middle">
                                    <th scope="row" class="d-none d-md-block col-lg-3">
                                        <img src='<%#DataBinder.Eval(Container,"DataItem.ImagePath")%>' class="img-fluid img-thumbnail"></th>
                                    <td class="col-4 col-lg-3 my-auto">
                                        <asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ProductName")%>' />
                                    </td>
                                    <td class="col-4 col-lg-3 my-auto">₱<asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ItemPrice")%>' />
                                    </td>
                                    <td class="col-4 col-lg-3 my-auto">
                                        <asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderItemQuantity")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="row text-center bg-dark text-white" style="padding: 10px;">
            <div class="col-2 col-lg-6"></div>
            <div class="col-4 col-lg-3">
                <h5 style="font-weight: 700;">Total Price</h5>
            </div>
            <div class="col-4 col-lg-3">
                <h5 style="font-weight: 700;">₱<asp:Label runat="server" ID="OrderTotal"></asp:Label></h5>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-lg-3">
            </div>
            <div class="col-12 col-lg-3">
                <asp:Button runat="server" CssClass="btn btn-block btn-outline-danger" ID="CancelOrderModalTrigger" Text="Cancel Order" OnClick="modalPromptButton_Click"/>
            </div>

            <div class="col-12 col-lg-3">
                <a href="UserOrders.aspx" role="button" class="btn btn-block btn-outline-dark">Back to Orders</a>
            </div>
            <div class="col-lg-3">
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="modal fade" id="CancelOrderModal" tabindex="-1" aria-labelledby="CancelOrderModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="CancelOrderModalLabel">Cancel Order?</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="firstPhrase" runat="server" Text="Are you sure you want to cancel your order?"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button runat="server" ID="CancelOrderButton" class="btn btn-success" data-dismiss="modal" Text="Yes" UseSubmitBehavior="false" OnClick="CancelOrderButton_Click"></asp:Button>
                            <asp:Button runat="server" ID="closeButton" class="btn btn-danger" data-dismiss="modal" Text="No" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
