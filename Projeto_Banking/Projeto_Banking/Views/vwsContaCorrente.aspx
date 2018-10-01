<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsContaCorrente.aspx.cs" Inherits="Projeto_Banking.Views.vwsContaCorrente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div>
            <div>
                <asp:Label ID="lblTitular" runat="server" Text="Titular da Conta: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblNumero" runat="server" Text="Número da Conta: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblLimite" runat="server" Text="Limite: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblSaldo" runat="server" Text="Saldo: "></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnEmprestimo" runat="server" Text="Empréstimos" OnClick="btnEmprestimo_Click" />
                <asp:Button ID="btnInvestimento" runat="server" Text="Investimentos" OnClick="btnInvestimento_Click" />
                <asp:Button ID="btnTransferencias" runat="server" OnClick="btnTransferencias_Click" Text="Transferências" />
            </div>
        </div>
</asp:Content>
