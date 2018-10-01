<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsConsultarEmprestimos.aspx.cs" Inherits="Projeto_Banking.Views.vwsConsultarEmprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:GridView ID="gdvEmprestimos" runat="server" AutoGenerateColumns="False" DataKeyNames="Emprestimo_id" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="gdvEmprestimos_RowCommand">
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
                    <asp:Label ID="lblTaxa" runat="server" Text='<%# Bind("Taxa_valor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo de Pagamento">
               <ItemTemplate>
                    <asp:Label ID="lblPagamento" runat="server" Text='<%# Bind("Pagamento_tipo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                   <asp:LinkButton ID="lkbVer" runat="server" Text="Ver" CommandArgument='<%# Bind("Emprestimo_id") %>' CommandName="Ver"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</asp:Content>
