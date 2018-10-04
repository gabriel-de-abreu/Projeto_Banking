<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwLoginGerente.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Vendors/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Vendors/Scripts/jquery-3.0.0.min.js"></script>
    <script src="../../Vendors/Scripts/bootstrap.min.js"></script>
    <script src="../../Vendors/Scripts/bootstrap.bundle.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Noto+Sans" rel="stylesheet" />
    <link href="../common.css" rel="stylesheet" />
    <link href="../../Vendors/Snippets/center-login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="flex-parent">
        <div class="container">
            <div class="row">
                <div class="col-5 offset-4">
                    <div class="container-border">
                        <div class="form-group">
                            <label>
                                Usuário
                            </label>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Senha
                            </label>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="container text-center">
                            <asp:Button ID="Logar" runat="server" Text="Logar" CssClass="btn btn-primary" OnClick="Logar_Click" />
                            <br />
                            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
