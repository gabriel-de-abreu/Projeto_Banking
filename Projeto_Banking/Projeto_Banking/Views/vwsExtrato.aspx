<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsExtrato.aspx.cs" Inherits="Projeto_Banking.Views.vwsExtrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:GridView ID="gdvExtrato" runat="server" AutoGenerateColumns="False">
        <Columns>
            <%--<asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Movimentacao_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Data">
               <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Movimentacao_data_formatado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descrição">
               <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Movimentacao_descricao") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Origem">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Conta_Movimentacao_origem_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Destino">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Conta_Movimetacao_destino") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Valor">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Movimentacao_valor_formatado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
