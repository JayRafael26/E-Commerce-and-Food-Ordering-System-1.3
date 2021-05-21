<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminAddItem.aspx.cs" Inherits="MangAtongsPrototype.ASPX.AdminAddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mons">
        <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h2 class="display-5 fw-normal mons" style="font-weight: 600;">Add Item</h2>
            </div>
        </div>
        <br />


        <div class="row" style="margin-bottom: 20px;">
            <div class="col-lg-2"></div>

            <div class="col-12 col-lg-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row" style="padding: 0px 20px 0px">

                            <div class="form-group">
                                <label for="ItemImage" class="adminformlabel">Image file input</label>
                                <asp:FileUpload class="form-control-file" ID="ItemImage" runat="server" accept=".png,.jpg,.jpeg" />
                            </div>

                            <div class="form-group">
                                <label for="ItemDescription" class="adminformlabel">Description</label>
                                <asp:TextBox class="form-control adminformdetail" ID="itemDescription" runat="server" TextMode="MultiLine" MaxLength="100" Rows="5" Columns="40" />
                                <asp:RequiredFieldValidator ID="desc" runat="server" ControlToValidate="itemDescription" ErrorMessage="please input an description" ForeColor="Red" Display="Dynamic" />
                            </div>

                        </div>

                        <div class="form-group">
                            <label for="itemName" class="adminformlabel">Name</label>
                            <asp:TextBox class="form-control adminformdetail" ID="itemName" placeholder="Enter item name" runat="server" />
                            <asp:RequiredFieldValidator ID="name" runat="server" ControlToValidate="itemName" ErrorMessage="please input an item name" ForeColor="Red" Display="Dynamic" />
                        </div>

                        <div class="form-group">
                            <label for="itemPrice" class="adminformlabel">Price</label>
                            <asp:TextBox class="form-control adminformdetail" ID="itemPrice" placeholder="Enter item price" runat="server" />
                            <asp:RequiredFieldValidator ID="price" runat="server" ControlToValidate="itemPrice" ErrorMessage="please input a price" ForeColor="Red" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator"
                                runat="server" ControlToValidate="itemPrice"
                                Display="Dynamic" Text="* Must only be numbers <br>"
                                ValidationExpression="^([0-9])*$" ForeColor="Red" />
                        </div>

                            <div class="form-group">
                                <label for="itemQty" class="adminformlabel">Quantity</label>
                                <asp:TextBox class="form-control adminformdetail" ID="itemQty" placeholder="Product Qty" runat="server" />
                                <asp:RequiredFieldValidator ID="qty" runat="server" ControlToValidate="itemQty" ErrorMessage="please input the quantity" ForeColor="Red" Display="Dynamic" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server" ControlToValidate="itemQty"
                                    Display="Dynamic" Text="* Must only be numbers <br>"
                                    ValidationExpression="^([0-9])*$" ForeColor="Red" />
                            </div>
  
                            <div class="form-group">
                                <label for="ctgID" class="adminformlabel">Category ID (1 - Chicken, 2 - Beef, 3 - Others)</label>
                                <asp:DropDownList class="form-control adminformdetail" ID="ctgID" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        <hr />
                        <div class="row small">
                            <div class="col-lg-2"></div>
                            <div class="col-12 col-lg-4">
                                <asp:LinkButton runat="server" ID="CancelButton" CssClass="btn btn-danger" CausesValidation="false" OnClick="CancelButton_Click" Style="width: 100%; height: 100%">Cancel/Back</asp:LinkButton>
                            </div>
                            <div class="col-12 col-lg-4">
                                <asp:LinkButton runat="server" ID="save" OnClick="AddItem_Click">
						            <button type="button" class="btn btn-success" style="width: 100%; height: 100%">Save</button>
                                </asp:LinkButton>
                            </div>
                            <div class="col-lg-2"></div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-lg-2">
            </div>
            <%--Modal for Function Confirmation--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="modal fade" id="AddItem" tabindex="-1" aria-labelledby="AddItemLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="AddItemLabel">Add Item</h5>
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
                                    <asp:Button runat="server" ID="Close" CssClass="btn btn-danger" Text="Close" data-dismiss="modal" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

