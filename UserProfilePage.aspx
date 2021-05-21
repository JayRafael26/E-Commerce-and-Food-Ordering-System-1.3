<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfilePage.aspx.cs" Inherits="MangAtongsPrototype.ASPX.UserProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../images/MangAtongsBG.png'); background-size: contain; background-position: center; margin: 0px;">
        <br />
        <div class="row" style="margin-left: 20px; margin-right: 20px; padding-bottom: 0px;">

            <div class="col-lg-3"></div>

            <div class="col col-lg-6 bg-light" style="padding: 10px 10px 10px">
                <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
                        <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                            <h2 class="display-5 fw-normal" style="font-weight: 400;">User Profile</h2>
                        </div>
                    </div>
                <br />
                <div class="form-group">
                    <label>Username</label>
                    <asp:TextBox class="form-control" ID="UsernameTxtBox" ReadOnly="true" runat="server" />
                </div>
                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <label>First Name</label>
                            <asp:TextBox class="form-control" ID="FName" placeholder="First Name" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqFName"
                                    ControlToValidate="FName" EnableClientScript="true"
                                    Display="Dynamic" Text="* First Name is Required"
                                    Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10"
                                    runat="server" ControlToValidate="FName"
                                    Display="Dynamic" Text="* Letters Only<br>"
                                    ValidationExpression="^[a-zA-Z\s]*" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
                            <label>Last Name</label>
                            <asp:TextBox class="form-control" ID="LName" placeholder="Last Name" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    ControlToValidate="LName" EnableClientScript="true"
                                    Display="Dynamic" Text="* First Name is Required"
                                    Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server" ControlToValidate="LName"
                                    Display="Dynamic" Text="* Letters Only<br>"
                                    ValidationExpression="^[a-zA-Z\s]*" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label>Street</label>
                    <asp:TextBox class="form-control" ID="Street" runat="server" />
                </div>
                <div class="form-group">
                    <label>City</label>
                    <asp:TextBox class="form-control" ID="City" runat="server" />
                </div>
                <div class="form-group">
                    <label>Phone</label>
                    <asp:TextBox class="form-control" ID="Phone" runat="server" />
                    <asp:RequiredFieldValidator ID="ReqContact"
                            ControlToValidate="Phone" EnableClientScript="true"
                            Display="Dynamic" Text="* Please input your Contact No."
                            Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                            runat="server" ControlToValidate="Phone"
                            Display="Dynamic" Text="* Must only be numbers <br>"
                            ValidationExpression="^([0-9])*$" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                            runat="server" ControlToValidate="Phone"
                            Display="Dynamic" Text="* Must be 11 digits"
                            ValidationExpression=".{11}.*" ForeColor="Red" />
                </div>

                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox class="form-control" ID="Email" runat="server" />
                    <asp:RequiredFieldValidator ID="ReqEmail"
                            ControlToValidate="Email" EnableClientScript="true"
                            Display="Dynamic" Text="* Email is Required"
                            Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9"
                            runat="server" ControlToValidate="Email"
                            Display="Dynamic" Text="* Not a valid email address<br>"
                            ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ForeColor="Red" />
                </div>
                <div class="mynav">
                    <asp:LinkButton runat="server" ID="edit" OnClick="Edit_Click">
                            <button type="button" class="btn btn-block btn-primary">Edit your Personal Details</button>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" ID="update" OnClick="Update_Click" Visible="false">
                            <button type="button" class="btn btn-block btn-outline-success">Update</button>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="col-lg-3"></div>
        </div>
        <br />
    </div>
</asp:Content>
