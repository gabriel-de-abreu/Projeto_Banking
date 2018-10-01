<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsTransferencia.aspx.cs" Inherits="Projeto_Banking.Views.vwsTransferencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <asp:Label ID="lblContaAtual" runat="server" Text="Número da Conta: "></asp:Label>
    <br />
    <asp:Label ID="lblSaldo" runat="server" Text="Saldo: "></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblConta" runat="server" Text="Conta Destino: "></asp:Label>
    <asp:TextBox ID="txtConta" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblValor" runat="server" Text="Valor: "></asp:Label>
    <asp:TextBox ID="txtValor" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <br />
    <asp:Button ID="btnTransferir" runat="server" OnClick="btnTransferir_Click" Text="Transferir" />
    <br />


</asp:Content>
