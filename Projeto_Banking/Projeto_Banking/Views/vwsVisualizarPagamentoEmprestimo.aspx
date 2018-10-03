<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsVisualizarPagamentoEmprestimo.aspx.cs" Inherits="Projeto_Banking.Views.vwsVisualizarEmprestimo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="divPagDebito" runat="server" class="container container-border margin-3-upper">
        <asp:GridView ID="gdvPagamentosDebito" runat="server" AutoGenerateColumns="False"
            DataKeyNames="Pagamento_id" CssClass="table table-hover view-table">
            <Columns>
                <asp:TemplateField HeaderText="Parcela">
                    <ItemTemplate>
                        <asp:Label ID="lblParcela" runat="server" Text='<%# Bind("NumeroParcela") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor">
                    <ItemTemplate>
                        <asp:Label ID="lblValor" runat="server" Text='<%# "R$ "+Eval("Pagamento_Valor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vencimento">
                    <ItemTemplate>
                        <asp:Label ID="lblVencimento" runat="server" Text='<%# Bind("Pagamento_data_formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusPagamento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div id="divPagBoleto" runat="server" class="container container-border margin-3-upper">
        <asp:GridView ID="gdvPagamentosBoleto" runat="server" AutoGenerateColumns="False"
            DataKeyNames="Pagamento_id" CssClass="table table-hover view-table" OnRowCommand="gdvPagamentosBoleto_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Parcela">
                    <ItemTemplate>
                        <asp:Label ID="lblParcela" runat="server" Text='<%# Bind("NumeroParcela") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor">
                    <ItemTemplate>
                        <asp:Label ID="lblValor" runat="server" Text='<%# "R$ "+Eval("Pagamento_Valor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vencimento">
                    <ItemTemplate>
                        <asp:Label ID="lblVencimento" runat="server" Text='<%# Bind("Pagamento_data_formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusPagamento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbImprimir" runat="server" Text="Imprimir" CommandArgument='<%# Bind("Pagamento_id") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
