<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwLogin.aspx.cs" Inherits="Projeto_Banking.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>   
            <asp:Label ID="LblNumConta" runat="server" Text="Número da Conta:"></asp:Label>
            <asp:TextBox ID="TxtNumConta" runat="server" OnTextChanged="TxtNumConta_TextChanged"></asp:TextBox>
        </div>

         <div>   
            <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
            <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="BtnLogar" runat="server" Text="Logar" OnClick="BtnLogar_Click" style="height: 26px" />
    </form>
    <br />
    <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
</body>
</html>