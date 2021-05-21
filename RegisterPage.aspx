<%@ Page Language="C#" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="MangAtongsPrototype.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <title></title>

    <%--Main CSS file with Bootstrap and Fontawesome imported--%>
    <link href="../css/MainStyle.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js"></script>
</head>
<body style="background-image: url('../images/MangAtongsBG.png'); background-size: contain; background-position: center;">
    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="row row-cols-1 row-cols-lg-3" style="margin-left: 10px; margin-right: 10px";>
                <div class="col-2"></div>


                <div class="col loginstyle" style="background: white; padding: 20px; margin-top: 20px; margin-bottom: 20px;">
                    <asp:LinkButton runat="server" ID="btnSubmit" class="btn btn-warning" OnClick="BackButton_Click" CausesValidation="false">
                        <i class="fas fa-arrow-left"></i> Back
                    </asp:LinkButton>
                    <div class="cent">
                        <br />
                        <img class="rounded-circle logo" src="../images/Logo.png" style="width: 30%;" />
                    </div>
                    <br />
                    <p class="cent">Member Registration</p>
                    <hr />
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label>First Name</label>
                                <asp:TextBox class="form-control" ID="FNameTxtBox" placeholder="First Name" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqFName"
                                    ControlToValidate="FNameTxtBox" EnableClientScript="true"
                                    Display="Dynamic" Text="* First Name is Required"
                                    Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10"
                                    runat="server" ControlToValidate="FNameTxtBox"
                                    Display="Dynamic" Text="* Letters Only<br>"
                                    ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" />
                            </div>
                            <div class="col-md-6">
                                <label>Last Name</label>
                                <asp:TextBox class="form-control" ID="LNameTxtBox" placeholder="Last Name" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqLName"
                                    ControlToValidate="LNameTxtBox" EnableClientScript="true"
                                    Display="Dynamic" Text="* Last Name is Required"
                                    Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11"
                                    runat="server" ControlToValidate="LNameTxtBox"
                                    Display="Dynamic" Text="* Letters Only<br>"
                                    ValidationExpression="^[a-zA-Z\s]*$" ForeColor="Red" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox class="form-control" ID="EmailAddressTxtBox" placeholder="juandelacruz@example.com" runat="server" />
                        <asp:RequiredFieldValidator ID="ReqEmail"
                            ControlToValidate="EmailAddressTxtBox" EnableClientScript="true"
                            Display="Dynamic" Text="* Email is Required"
                            Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9"
                            runat="server" ControlToValidate="EmailAddressTxtBox"
                            Display="Dynamic" Text="* Not a valid email address<br>"
                            ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ForeColor="Red" />

                    </div>
                    <div class="form-group">
                        <label>Username</label>
                        <asp:TextBox class="form-control" ID="UsernameTxtBox" placeholder="Must have 5 to 20 characters" runat="server" />
                        <asp:RequiredFieldValidator ID="ReqUsername"
                            ControlToValidate="UsernameTxtBox" EnableClientScript="true"
                            Display="Dynamic" Text="* Username is Required"
                            Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="valPassword" runat="server"
                            ControlToValidate="UsernameTxtBox" Display="Dynamic"
                            ErrorMessage="Minimum username length is 5"
                            ValidationExpression="^[\s\S]{5,}$" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                            ControlToValidate="UsernameTxtBox" Display="Dynamic"
                            ErrorMessage="Maximum username length is 20"
                            ValidationExpression="^[\s\S]{0,20}$" ForeColor="Red" />
                    </div>

                    <div class="form-group">
                        <label>Password</label>
                        <div class="input-group">
                            <asp:TextBox class="form-control" ID="PasswordTxtBox" TextMode="Password" placeholder="Must have at least 8 characters" runat="server" aria-describedby="basic-addon2" />
                            <div class="input-group-append">
                                <span class="input-group-text" id="basic-addon2" style="background-color: white;"><i id="togglePassword" class="fa fa-eye" style="text-align: center; margin: auto;"></i></span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="ReqPassword"
                            runat="server" ControlToValidate="PasswordTxtBox"
                            Display="Dynamic" Text="* Password is Required"
                            ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                            runat="server" ControlToValidate="PasswordTxtBox"
                            Display="Dynamic" Text="* Minimum password length is 8<br>"
                            ValidationExpression=".{8}.*" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="PasswordTxtBox"
                            Display="Dynamic" Text="* 1 or more uppercase letters (A-Z)<br>"
                            ValidationExpression="^(.*?[A-Z]){1,}.*$" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                            runat="server" ControlToValidate="PasswordTxtBox"
                            Display="Dynamic" Text="* 1 or more special characters (~!@#$%^&*()\-_=+{};:,<.>])<br>"
                            ValidationExpression="^(.*?[~!@#$%^&*()\-_=+{};:,<.>]){1,}.*$" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                            runat="server" ControlToValidate="PasswordTxtBox"
                            Display="Dynamic" Text="* 1 or more numbers (0-9)<br>"
                            ValidationExpression="^(.*?[0-9]){1,}.*$" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                            runat="server" ControlToValidate="PasswordTxtBox"
                            Display="Dynamic" Text="* 1 or more lowercase letters (a-z)<br>"
                            ValidationExpression="^(.*?[a-z]){1,}.*$" ForeColor="Red" />
                    </div>

                    <div class="form-group">
                        <label>Confirm Password</label>
                        <asp:TextBox class="form-control" ID="CPasswordTxtBox" TextMode="Password" placeholder="Confirm Password" runat="server" />
                        <asp:CompareValidator runat="server" ID="cmpNumbers"
                            ControlToValidate="PasswordTxtBox" ControlToCompare="CPasswordTxtBox"
                            Operator="Equal" Type="string" ErrorMessage="* The Passwords are not the Same."
                            Display="Dynamic" ForeColor="Red" />
                    </div>

                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label>Street</label>
                                <asp:TextBox class="form-control" ID="StreetTxtBox" placeholder="Street (Ex: 123 Dela Cruz Street)" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqStreet"
                                    ControlToValidate="StreetTxtBox" EnableClientScript="true"
                                    Display="Dynamic" Text="* Please input your Street"
                                    Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                                <label>District & City</label>
                                <asp:TextBox class="form-control" ID="CityTxtBox" placeholder="District, City (Ex: Sampaloc, Manila)" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqCity"
                                    ControlToValidate="CityTxtBox" EnableClientScript="true"
                                    Display="Dynamic" Text="* Please input your City"
                                    Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Contact No.</label>
                        <asp:TextBox class="form-control" ID="ContactTxtBox" placeholder="Contact No." runat="server" />
                        <asp:RequiredFieldValidator ID="ReqContact"
                            ControlToValidate="ContactTxtBox" EnableClientScript="true"
                            Display="Dynamic" Text="* Please input your Contact No."
                            Enabled="true" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                            runat="server" ControlToValidate="ContactTxtBox"
                            Display="Dynamic" Text="* Must only be numbers <br>"
                            ValidationExpression="^([0-9])*$" ForeColor="Red" />

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                            runat="server" ControlToValidate="ContactTxtBox"
                            Display="Dynamic" Text="* Must be 11 digits"
                            ValidationExpression=".{11}.*" ForeColor="Red" />
                    </div>


                    <div class="row text-center">
                        <div class="col">
                            <asp:Button runat="server" ID="clearButton" CssClass="btn btn-block btn-secondary" Text="Clear" />
                        </div>
                        <div class="col">
                            <asp:Button runat="server" CssClass="btn btn-block btn-success" Text="Submit" OnClick="RegisterSubmit_Click" />
                        </div>
                    </div>
                    <hr />
                    <div>
                        <p class="cent" style="font-weight: 600;">Already a Member? <a href="LoginPage.aspx">Click Here!</a></p>
                    </div>
                </div>
                <div class="col-2"></div>
            </div>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="modal fade" id="RegisterModal" data-backdrop="static" tabindex="-1" aria-labelledby="RegisterModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="RegisterModalLabel">Register</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="firstPhrase" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="secondPhrase" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="thirdPhrase" runat="server" Text=""></asp:Label>
                                <asp:Label ID="samplePass" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="tryagainButton" class="btn btn-success" data-dismiss="modal" Text="Try Again" />
                                <asp:Button runat="server" ID="closeButton" CssClass="btn btn-outline-success" Text="Close" data-dismiss="modal" UseSubmitBehavior="false" OnClick="CloseButton_Click" CausesValidation="false"></asp:Button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </form>
    <script type="text/javascript">
        $(function () {
            $("#clearButton").click(function (e) {
                e.preventDefault();
                $("#FNameTxtBox").val("");
                $("#LNameTxtBox").val("");
                $("#EmailAddressTxtBox").val("");
                $("#UsernameTxtBox").val("");
                $("#PasswordTxtBox").val("");
                $("#CPasswordTxtBox").val("");
                $("#StreetTxtBox").val("");
                $("#CityTxtBox").val("");
                $("#ContactTxtBox").val("");

                if (window.Page_Validators)
                    for (var vI = 0; vI < Page_Validators.length; vI++) {
                        var vValidator = Page_Validators[vI];
                        vValidator.isvalid = true;
                        ValidatorUpdateDisplay(vValidator);
                    }
            });
        });
    </script>
    <script type="text/javascript">
        var togglePassword = document.querySelector('#togglePassword');
        var password = document.querySelector('#PasswordTxtBox');
        togglePassword.addEventListener('click', function (e) {
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            this.classList.toggle('fa-eye-slash');
        });
    </script>
</body>
</html>
