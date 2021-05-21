<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MangAtongsPrototype.WebForm7" %>

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
        <div class="container-fluid" style="margin-bottom: 10px">
            <div class="row row-cols-1 row-cols-lg-3" style="padding-top: 30px; margin-left: 10px; margin-right: 10px;">
                <div class="col-3">
                </div>

                <div class="col loginstyle" style="background: white; padding: 20px; margin-top: 20px;">
                    <asp:LinkButton runat="server" ID="btnSubmit" class="btn btn-warning button-size" OnClick="BackButton_Click">
                        <i class="fas fa-arrow-left"></i> Back
                    </asp:LinkButton>
                    <div class="cent">
                        <img src="../images/Logo.png" class="rounded-circle logo" style="width: 30%;" /><br />
                        <p class="large" style="font-weight: 500;">Member Sign-in</p>
                    </div>
                    <div class="form-group">
                        <label>Username</label>
                        <asp:TextBox class="form-control" ID="UsernameTxtBox" placeholder="Username" runat="server"/>
                    </div>

                    <div class="form-group">
                        <label>Password</label>
                        <div class="input-group">
                            <asp:TextBox class="form-control" ID="PasswordTxtBox" TextMode="Password" placeholder="Must have at least 8 characters" runat="server" aria-describedby="basic-addon2" />
                            <div class="input-group-append">
                                <span class="input-group-text" id="basic-addon2" style="background-color: white;"><i id="togglePassword" class="fa fa-eye" style="text-align: center; margin: auto;"></i></span>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" ID="login" OnClick="LoginSubmit_Click">
                            <button type="button" class="btn btn-block btn-primary">Submit</button>
                        </asp:LinkButton>
                    </div>
                    <div>
                        <br />
                        <p class="cent" style="font-weight: 600;">Not a Member yet? <a href="RegisterPage.aspx">Click Here!</a></p>
                    </div>

                </div>
                <div class="col-3"></div>
            </div>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="modal fade" id="LoginModal" data-backdrop="static" tabindex="-1" aria-labelledby="LoginModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="LoginModalLabel">Login</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="firstPhrase" runat="server" Text=""></asp:Label>
                                <asp:Label ID="secondPhrase" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="tryagainButton" class="btn btn-success" data-dismiss="modal" Text="Try Again" />
                                <asp:Button runat="server" ID="closeButton" class="btn btn-outline-success" Text="Close" UseSubmitBehavior="false" OnClick="CloseButton_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
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
