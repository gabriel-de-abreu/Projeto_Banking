<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwLogin.aspx.cs" Inherits="Projeto_Banking.Views.vwLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Vendors/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Vendors/Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Vendors/Scripts/bootstrap.min.js"></script>
    <script src="../Vendors/Scripts/bootstrap.bundle.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Noto+Sans" rel="stylesheet" />
    <link href="common.css" rel="stylesheet" />
    <link href="../Vendors/Snippets/center-login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="flex-parent">
        <div class="container">
            <div class="row">
                <div class="col-5 offset-4">
                    <div class="container-border">
                        <div class="form-group">
                            <label>Número da Conta</label>
                            <asp:TextBox ID="TxtNumConta" runat="server" CssClass="form-control" placeholder="Digite o número da conta"
                                required="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Senha</label>
                            <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" CssClass="form-control"
                                placeholder="Senha da Conta" required="true"></asp:TextBox>
                        </div>
                        <div class="container text-center margin-3-upper margin-1-bottom">
                            <asp:Button ID="BtnLogar" Class="btn btn-primary" runat="server" Text="Logar" OnClick="BtnLogar_Click" />
                            <br />
                            <asp:Label ID="LblResultado" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
