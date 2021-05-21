<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" UnobtrusiveValidationMode="None" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="MangAtongsPrototype.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input[type="number"]::-webkit-outer-spin-button, input[type="number"]::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        input[type="number"] {
            -moz-appearance: textfield;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--abc--%>
    <div class="container-fluid mons">
        <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h2 class="display-5 fw-normal" style="font-weight: 800;">Cart</h2>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12 col-lg-8">
                <div class="row" style="padding: 15px 0 15px">
                    <div class="container-fluid table-responsive">
                        <table class="table text-center table-hover table-borderless">
                            <thead>
                                <tr class="row">
                                    <th scope="col" class="col-3 col-lg-6">Item</th>
                                    <th scope="col" class="col-3 col-lg-2">Quantity</th>
                                    <th scope="col" class="col-3 col-lg-2">Price</th>
                                    <th scope="col" class="col-3 col-lg-2">Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="PrintCartItems" runat="server">
                                    <ItemTemplate>
                                        <tr class="row align-middle" style="font-size: 0.8rem">
                                            <td class="d-none d-lg-block col-lg-3 my-auto">
                                                <img src='<%#DataBinder.Eval(Container,"DataItem.ImagePath")%>' class="card-img-top" />
                                            </td>
                                            <td class="col-3 col-lg-3 my-auto">
                                                <span class="text-center">
                                                    <asp:Label runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ProductName")%>'></asp:Label></span>
                                                <asp:HiddenField ID="PID" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.CartProductID")%>' />
                                            </td>
                                            <td class="col-3 col-lg-2 my-auto">
                                                <asp:TextBox ID="QuantityBox" CssClass="cent" runat="server" min="1" max='<%#DataBinder.Eval(Container,"DataItem.ProductQuantity")%>' step="1" AutoPostBack="true" Text='<%#DataBinder.Eval(Container,"DataItem.CartQuantity")%>' OnTextChanged="UpdateQuantity" MaxLength="4" Width="50%" TextMode="Number" />
                                                <asp:HiddenField ID="MaximumQuantity" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.ProductQuantity")%>' />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator"
                                                    runat="server" ControlToValidate="QuantityBox"
                                                    Display="Dynamic" Text="<br>* Must only be positive numbers <br>"
                                                    ValidationExpression="^([0-9])*$" ForeColor="Red" />
                                                <asp:CompareValidator runat="server" ID="cmpNumbers" Display="Dynamic"
                                                    ControlToValidate="QuantityBox" ValueToCompare="0"
                                                    Operator="GreaterThan" Type="Integer" ErrorMessage="Quantity cannot be 0" /><br />
                                            </td>

                                            <td class="col-3 col-lg-2 my-auto">
                                                <span>₱<%#DataBinder.Eval(Container,"DataItem.CartPrice")%>.00</span>
                                            </td>

                                            <td class="col-3 col-lg-2 my-auto">
                                                <asp:Label ID="RemoveThis" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.CartProductID")%>' Visible="false"></asp:Label>
                                                <asp:LinkButton ID="modalPromptButton" runat="server" type="button" Style="width: 70%" CssClass="btn btn-outline-danger" OnClick="modalPromptButton_Click">
                                                    <i class="fas fa-trash"></i>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-4">
                <div class="row">
                    <div class="col-12">
                        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
                            <div class="col-md-5 p-lg-5 mx-auto">
                                <h4 class="display-5 fw-normal" style="font-weight: 800;">Summary</h4>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="table-responsive">
                            <table class="table table-hover table-borderless">
                                <tbody>
                                    <tr>
                                        <th scope="row">Sub Total:</th>
                                        <td>
                                            <asp:Label ID="SubTotal" runat="server" />.00</td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            <asp:Label Text="Payment Method" runat="server"></asp:Label></th>
                                        <td>
                                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Pick-up" GroupName="method" Checked="true" />
                                            <br />
                                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Cash on Delivery" GroupName="method" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">Total Amount:</th>
                                        <td>
                                            <asp:Label ID="TotalAmount" runat="server" />.00</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <asp:Button runat="server" CssClass="btn btn btn-success btn-block med" Text="Confirm Order" OnClick="ConfirmOrder"></asp:Button>
            </div>

        </div>


        <%--Modal for Remove Confirmation--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="modal fade" id="RemoveModal" tabindex="-1" aria-labelledby="RemoveModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="RemoveModalLabel">
                                    <asp:Label ID="ModalTitle" runat="server" Text=""></asp:Label></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="ModalFunction" runat="server" Text=""></asp:Label>
                                <asp:Label ID="itemNameRemove" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Label ID="ProdID" runat="server" Text="" Visible="False"></asp:Label>
                                <asp:Button ID="modalButton" runat="server" CssClass="btn btn-danger" Text="Yes, Remove Item" OnClick="RemoveItemFromCart" UseSubmitBehavior="false" data-dismiss="modal"></asp:Button>
                                <asp:Button ID="closeModalRemoveButton" runat="server" class="btn btn-success" data-dismiss="modal" Text="No, Keep Item"></asp:Button>
                                <asp:Button ID="ProceedToProductsPage" runat="server" class="btn btn-success" data-dismiss="modal" Text="Proceed to Products Page" OnClick="ProceedToProductsPage_Click" UseSubmitBehavior="false"></asp:Button>
                                <asp:Button ID="OrderSuccessButton" runat="server" class="btn btn-danger" data-dismiss="modal" Text="Close" OnClick="RefreshPage" UseSubmitBehavior="false"></asp:Button>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
