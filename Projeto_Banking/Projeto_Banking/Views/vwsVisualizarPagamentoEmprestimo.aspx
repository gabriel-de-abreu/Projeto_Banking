<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsVisualizarPagamentoEmprestimo.aspx.cs" Inherits="Projeto_Banking.Views.vwsVisualizarEmprestimo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="gdvDebito">
        <asp:GridView ID="gdvPagamentosDebito" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
            DataKeyNames="Pagamento_id">

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
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

    </div>

    <div id="gdvBoleto">
        <asp:GridView ID="gdvPagamentosBoleto" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"
            DataKeyNames="Pagamento_id">

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
                        <asp:LinkButton ID="lkbImprimir" runat="server" Text="Imprimir"></asp:LinkButton>
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

    </div>
</asp:Content>
