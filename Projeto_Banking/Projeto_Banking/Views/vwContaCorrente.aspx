<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwContaCorrente.aspx.cs" Inherits="Projeto_Banking.Views.vwContaCorrente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNumConta" runat="server" Text="Número da conta não foi carregado."></asp:Label>
            <br />
            <asp:Label ID="lblSaldo" runat="server" Text="Saldo não foi carregado."></asp:Label>
            <br />
            <asp:Button ID="btnEmprestimo" runat="server" Text="Empréstimos" OnClick="btnEmprestimo_Click" />
            <asp:Button ID="btnInvestimento" runat="server" Text="Investimentos" OnClick="btnInvestimento_Click" />
        </div>
    </form>
        <!-- #include file="/Views/Footer.html"-->
</body>
</html>
