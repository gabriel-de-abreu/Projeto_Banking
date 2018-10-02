<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsConsultarEmprestimos.aspx.cs" Inherits="Projeto_Banking.Views.vwsConsultarEmprestimos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container container-border margin-3-upper">
        <asp:GridView ID="gdvEmprestimos" runat="server" AutoGenerateColumns="False" DataKeyNames="Emprestimo_id" OnRowCommand="gdvEmprestimos_RowCommand"
            CssClass="table table-hover view-table">
            <Columns>
                <asp:TemplateField HeaderText="Data Início">
                    <ItemTemplate>
                        <asp:Label ID="lblData" runat="server" Text='<%# Bind("Emprestimo_inicio_Formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor ">
                    <ItemTemplate>
                        <asp:Label ID="lblValor" runat="server" Text='<%# "R$ "+Eval("Emprestimo_valor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nº de Parcelas">
                    <ItemTemplate>
                        <asp:Label ID="lblParcelas" runat="server" Text='<%# Bind("Emprestimo_parcelas") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Taxa de Juros">
                    <ItemTemplate>
                        <asp:Label ID="lblTaxa" runat="server" Text='<%# Eval("Taxa_valor")+"%" %>'></asp:Label>
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
        </asp:GridView>
    </div>
</asp:Content>
