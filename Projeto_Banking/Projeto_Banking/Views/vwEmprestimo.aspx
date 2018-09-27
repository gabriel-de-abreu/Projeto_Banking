<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwEmprestimo.aspx.cs" Inherits="Projeto_Banking.Views.vwEmprestimo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Qual o valor do empréstimo?"></asp:Label>
            <br />
            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Número de Parcelas"></asp:Label>
            <br />
            <asp:TextBox ID="txtParcelas" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSimular" runat="server" Text="Simular" OnClick="btnSimular_Click" />
            <br />
            <asp:Label ID="lblAviso" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div runat="server" id="divSimulacao">
            <br />
            <br />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Pagamento"></asp:Label>
            <br />
            <asp:RadioButton runat="server" Text="Débito em Conta" ID="radioBtnConta" GroupName="Pagamento"></asp:RadioButton>
            <br />
            <asp:RadioButton runat="server" Text="Boleto" ID="radioBtnBoleto" GroupName="Pagamento"></asp:RadioButton>
            <br />
            <br />
            <asp:Button ID="btnRealizar" runat="server" Text="Realizar Empréstimo" OnClick="btnRealizar_Click" />
        </div>
    </form>
</body>
</html>
