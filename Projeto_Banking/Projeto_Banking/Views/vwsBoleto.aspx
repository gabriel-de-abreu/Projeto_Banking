<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsBoleto.aspx.cs" Inherits="Projeto_Banking.Views.vwsBoleto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container container-border margin-3-upper">
        <h4 class="header-boleto">Boleto Para Pagamento de Parcela de Empréstimo
        </h4>
        <div class="container margin-1-upper text-center table-boleto">
            <h3>Boleto Para Pagamento de Empréstimo</h3>
            <table class="table">
                <tr>
                    <td><strong>Cliente</strong>
                    </td>
                    <td>
                        <asp:Label ID="lblCliente" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>CPF</strong></td>
                    <td>
                        <asp:Label ID="lblClienteCPF" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Conta</strong>
                    </td>
                    <td>
                        <asp:Label ID="lblConta" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Código do Empréstimo</strong>
                    </td>
                    <td>
                        <asp:Label ID="lblEmpCod" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td><strong>Pago</strong>
                    </td>
                    <td>
                        <asp:Label ID="lblPago" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Vencimento</strong>
                    </td>
                    <td>
                        <asp:Label ID="lblVencimento" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Valor</strong>
                    </td>
                    <td>
                        <asp:Label ID="lblValor" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="container margin-3-upper">
                <h5>
                    <asp:Label ID="lblCodBarras" runat="server" Text="Label"></asp:Label>
                </h5>
                <p>Código de Barras</p>
            </div>
            <div class="margin-1-upper margin-1-bottom">
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn-outline-primary btn" OnClick="btnVoltar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
