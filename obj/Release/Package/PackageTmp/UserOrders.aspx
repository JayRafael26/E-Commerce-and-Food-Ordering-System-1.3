<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserOrders.aspx.cs" Inherits="MangAtongsPrototype.ASPX.UserOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h1 class="display-5 fw-normal mons" style="font-weight: 600;">Your Orders</h1>
            </div>
        </div>
        <br />
        <div class="row row-cols-1">
            <%--Side Navigation/Accordion--%>
            <div class="col col-lg-3">
                <div class="card bg-light">
                    <div class="card-body">
                        <p class="card-title">Navigation</p>
                        <div class="btn-group-vertical">
                            <asp:LinkButton runat="server" OnClick="AllOrders_Click" CssClass="btn btn-link btn-block text-left" ID="AllOrdersButton">All Orders
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="Pending_Click" class="btn btn-link btn-block text-left" ID="PendingButton">Pending
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="Shipped_Click" class="btn btn-link btn-block text-left" ID="ShippedButton">Shipped
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="Completed_Click" class="btn btn-link btn-block text-left" ID="CompletedButton">Completed
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="Canceled_Click" class="btn btn-link btn-block text-left" ID="CanceledButton">Canceled
                            </asp:LinkButton>

                        </div>

                    </div>
                </div>
                <br />
            </div>

            <div class="col col-lg-9">
                <div class="row">
                    <div class="container-fluid table-responsive">
                        <table class="table text-center table-hover">
                            <thead class="thead-light">
                                <tr>
                                    <th scope="col">ID</th>
                                    <th scope="col">Date<br />(mm/dd/yyyy)</th>
                                    <th scope="col">Total</th>
                                    <th scope="col">Transportation Method</th>
                                    <th scope="col">Status</th>
                                    <th scope="col">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="PrintOrderItems" runat="server">
                                    <ItemTemplate>
                                            <tr>
                                                <th scope="row">#<asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderID")%>' ID="OrderIDLabel"/></th>
                                                <td><asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderDate")%>'/></td>
                                                <td>₱<asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderTotal")%>'/></td>
                                                <td><asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.PaymentMethod")%>'/></td>
                                                <td><asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.OrderStatus")%>'/></td>
                                                <td><asp:Button runat="server" CssClass="btn btn-dark" Text="View" OnClick="ViewOrder_Click"/>
                    
                                                </td>
                                            </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <%--Modal for Remove Confirmation--%>
        </div>
    </div>
</asp:Content>
