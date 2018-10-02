<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsInvestimento.aspx.cs" Inherits="Projeto_Banking.Views.vwsInvestimento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div>
            <br />
            <asp:Label ID="lblValorIni" runat="server" Text="Valor inicial do Investimento:"></asp:Label>
            <asp:TextBox ID="txtValorIni" runat="server"></asp:TextBox>
            <asp:Label ID="lblValorFim" runat="server" Text="Valor final do Investimento:"></asp:Label>
            <asp:TextBox ID="txtValorFim" runat="server" ></asp:TextBox>
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
         <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
