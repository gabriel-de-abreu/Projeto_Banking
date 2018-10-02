<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsRegaste.aspx.cs" Inherits="Projeto_Banking.Views.vwsRegaste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <div>
        <asp:Label ID="lblValorIni" runat="server" Text="Valor inicial do Investimento: "></asp:Label>
        <asp:TextBox ID="txtValorIni" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDataIni" runat="server" Text="Data Inicial do Investimento: "></asp:Label>
        <asp:TextBox ID="txtDataIni" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDataFim" runat="server" Text="Data Final do Investimento: "></asp:Label>
        <asp:TextBox ID="txtDataFim" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDataResgate" runat="server" Text="Data Desejada do Resgate: "></asp:Label>
        <asp:TextBox ID="txtDataResgate" 
            runat="server"
            AutoPostBack="True" 
            ontextchanged="SimularInvestimento"></asp:TextBox>
        <br />
        <asp:Label ID="lblValorFinal" runat="server" Text="Valor Final do Investimento: "></asp:Label>
        <asp:TextBox ID="txtValorFim" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnResgatar" runat="server" Text="Resgatar Investimento" OnClick="btnResgatar_Click" />
        

    </div>
</asp:Content>
