<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCheckOrder.aspx.cs" Inherits="MangAtongsPrototype.ASPX.AdminCheckOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table, th, td {
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
             <div class="col-md-5 p-lg-5 mx-auto" style="padding: 10px 15px 10px">
                <h2 class="display-5 fw-normal mons" style="font-weight: 600;">Check Order</h2>
            </div>
        </div>
        <br />
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-12 col-lg-6">
                        <%-- Add necessary repeater details/code here --%>
                        <table style="padding: 10px">
                            <tr>
                                <th colspan="2">Order Details</th>
                            </tr>
                            <tr>
                                <td>Order ID:</td>
                                <td>
                                    <asp:Label runat="server" ID="OrderID" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Order Date:</td>
                                <td>
                                    <asp:Label runat="server" ID="OrderDate" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Payment Method:</td>
                                <td>
                                    <asp:Label runat="server" ID="PaymenMethod" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Total Price:</td>
                                <td>
                                    ₱<asp:Label ID="totalPrice" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-12 col-lg-6">
                        <table style="padding: 10px">
                            <tr>
                                <td colspan="2"><strong>Customer Details </strong></td>
                            </tr>
                            <tr>
                                <td>Name: </td>
                                <td>
                                    <asp:Label runat="server" ID="FullName" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Address: </td>
                                <td>
                                    <asp:Label runat="server" ID="Street" Text=""></asp:Label>
                                    <asp:Label runat="server" ID="City" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Contact No.: </td>
                                <td>
                                    <asp:Label runat="server" ID="Contact" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="row">

                    <div class="container-fluid table-responsive table-borderless">
                        <table class="table text-center table-hover">
                            <thead class="thead-light">
                                <tr>
                                    <th scope="col">Item Name</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="PrintOrderItems" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ProductName")%>' ID="OrderIDLabel" /></th>
                                            <td><asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderItemQuantity")%>'></asp:Label></td>
                                            <td>₱<asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderItemPrice")%>'></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <hr />

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-12 col-lg-2 text-center my-auto">
                        <span style="font-weight: 600;">Order Status:</span>
                    </div>
                    <div class="col-12 col-lg-6">
                        <div class="card-body">
                            <asp:DropDownList class="form-control" ID="OrderStatus" runat="server">
                                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                <asp:ListItem Value="Canceled">Canceled</asp:ListItem>
                                <asp:ListItem Value="Returned">Returned</asp:ListItem>
                                <asp:ListItem Value="Shipped">Shipped</asp:ListItem>
                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-12 col-lg-2 my-auto">
                        <asp:LinkButton runat="server" ID="UpdateOrder" OnClick="UpdateItem_Click">
							<button type="button" class="btn btn-block btn-outline-success">Update</button>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="BackButton" OnClick="Back_Click">
							<button type="button" class="btn btn-block btn-outline-danger">Go Back</button>
                        </asp:LinkButton>
                    </div>

                    <div class="col-lg-1"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
