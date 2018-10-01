<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsConsultarEmprestimos.aspx.cs" Inherits="Projeto_Banking.Views.vwsConsultarEmprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:GridView ID="gdvEmprestimos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Data Início" />
            <asp:BoundField HeaderText="Valor " />
            <asp:BoundField HeaderText="Nº de Parcelas" />
            <asp:BoundField HeaderText="Taxa de Juros" />
        </Columns>
    </asp:GridView>
</asp:Content>
