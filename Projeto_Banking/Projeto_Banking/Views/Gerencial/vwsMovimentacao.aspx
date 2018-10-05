<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwsMovimentacao.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.vwsMovimentacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container container-border margin-3-upper col-lg-6 ">
        <div class="container margin-3-upper margin-1-bottom">
            <div class="container text-center">
                <h5 class="align-content-center"><strong>Movimentações </strong></h5>
                <asp:Button ID="btnSemana" runat="server" Text="7 dias" class="btn btn-secondary inner-padding-button1 btn-mov-width" OnClick="btnSemana_Click" />
                <asp:Button ID="btnMes" runat="server" Text="30 dias" class="btn btn-secondary inner-padding-button2 btn-mov-width" OnClick="btnMes_Click" />
                <asp:Button ID="btnAno" runat="server" Text="Ano" class="btn btn-secondary inner-padding-button3 btn-mov-width" OnClick="btnAno_Click" />
            </div>
            <div class="container-border margin-2-bottom-final margin-3-upper">
                <div class="container text-center">
                    <p><strong>Demais períodos </strong></p>
                </div>
                <div>
                    <div class="form-group">
                        <label>
                            Data Inicial
                        </label>
                        <asp:TextBox ID="txtInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Data Final</label>
                        <asp:TextBox ID="txtFim" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="container text-right">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" class="btn btn-primary btn-mov-width" OnClick="btnFiltrar_Click" />
                    </div>
                </div>
                <div class="container text-center">
                    <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="container text-center">
            <asp:GridView ID="gdvMovimentacao" runat="server" AutoGenerateColumns="False" CssClass="table table-hover view-table ">
                <Columns>
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
                    <asp:TemplateField HeaderText="Origem">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Conta_Movimentacao_origem_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Destino">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Conta_Movimetacao_destino") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Movimentacao_valor_formatado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
