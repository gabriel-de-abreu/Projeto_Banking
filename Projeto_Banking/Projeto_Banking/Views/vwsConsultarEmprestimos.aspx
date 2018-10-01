<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsConsultarEmprestimos.aspx.cs" Inherits="Projeto_Banking.Views.vwsConsultarEmprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:GridView ID="gdvEmprestimos" runat="server" AutoGenerateColumns="False" DataKeyNames="Emprestimo_id">
        <Columns>
            <asp:TemplateField HeaderText="Data Início">
               <ItemTemplate>
                    <asp:Label ID="lblData" runat="server" Text='<%# Bind("Emprestimo_inicio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor ">
                <ItemTemplate>
                    <asp:Label ID="lblValor" runat="server" Text='<%# Bind("Emprestimo_valor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nº de Parcelas">
                <ItemTemplate>
                    <asp:Label ID="lblParcelas" runat="server" Text='<%# Bind("Emprestimo_parcelas") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Taxa de Juros">
                <ItemTemplate>
                    <asp:Label ID="lblTaxa" runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
