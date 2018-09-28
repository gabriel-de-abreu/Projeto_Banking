<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwInvestimento.aspx.cs" Inherits="Projeto_Banking.Views.vwSimualarInvestimento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblValorIni" runat="server" Text="Valor inicial do Investimento:"></asp:Label>
            <asp:TextBox ID="txtValorIni" runat="server"></asp:TextBox>
            <asp:Label ID="lblValorFim" runat="server" Text="Valor final do Investimento:"></asp:Label>
            <asp:TextBox ID="txtValorFim" runat="server" OnTextChanged="txtValorFim_TextChanged"></asp:TextBox>
            <br />

            <asp:Label ID="lblDataIni" runat="server" Text="Data Inicial do Investimento: "></asp:Label>
            <asp:TextBox ID="txtDataIni" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblDataFim" runat="server" Text="Data Final do Investimento: "></asp:Label>
            <asp:TextBox ID="txtDataFim" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblDataRet" runat="server" Text="Data da Retirada: "></asp:Label>
            <asp:TextBox ID="txtDataRet" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblInvestimento" runat="server" Text="Selecione o Tipo de Investimento: "></asp:Label>
            <asp:DropDownList ID="ddlInvestimentos" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="BtnSimular"  runat="server" Text="Simular" OnClick="BtnSimular_Click" />

        </div>
    </form>
</body>
</html>
