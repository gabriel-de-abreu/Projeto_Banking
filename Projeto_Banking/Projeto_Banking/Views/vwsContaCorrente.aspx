<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsContaCorrente.aspx.cs" Inherits="Projeto_Banking.Views.vwsContaCorrente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container container-border margin-3-upper margin-2-bottom-final">
        <table class="table table-hover remove-border">
            <tr>
                <td><strong>Titular da Conta</strong></td>
                <td>
                    <asp:Label ID="lblTitular" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Número da Conta</strong></td>
                <td>
                    <asp:Label ID="lblNumero" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Limite</strong></td>
                <td>
                    <asp:Label ID="lblLimite" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Saldo</strong></td>
                <td>
                    <asp:Label ID="lblSaldo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="margin-3-upper container text-center">
        <asp:Button ID="btnEmprestimo" runat="server" CssClass="btn btn-primary btn-conta-corrente inner-padding-button1" Text="Realizar Empréstimo" OnClick="btnEmprestimo_Click" />
        <asp:Button ID="btnInvestimento" runat="server" CssClass="btn btn-primary btn-conta-corrente inner-padding-button2 " Text="Realizar Investimento" OnClick="btnInvestimento_Click" />
        <asp:Button ID="btnTransferencias" runat="server" CssClass="btn btn-primary btn-conta-corrente inner-padding-button2" OnClick="btnTransferencias_Click" Text="Transferir" />
        <asp:Button ID="btnExtrato" runat="server" CssClass="btn btn-primary btn-conta-corrente inner-padding-button3" OnClick="btnExtrato_Click" Text="Extrato" />
    </div>
</asp:Content>
