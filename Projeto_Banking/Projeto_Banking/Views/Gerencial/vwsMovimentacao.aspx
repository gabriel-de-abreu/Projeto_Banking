<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwsMovimentacao.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.vwsMovimentacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">


    <div class="container container-border margin-3-upper col-lg-6 ">
        <div class="container text-center margin-3-upper margin-1-bottom">

            <h5 class="align-content-center"><strong>Movimentações </strong></h5>

            <div class="btn-group btn-group-toggle" role="group">
                <asp:button id="btnSemana" runat="server" text="7 dias" class="btn btn-secondary" onclick="btnSemana_Click" />
                <asp:button id="btnMes" runat="server" text="30 dias" class="btn btn-secondary" onclick="btnMes_Click" />
                <asp:button id="btnAno" runat="server" text="Ano" class="btn btn-secondary" onclick="btnAno_Click" />
            </div>
            <p class="align-content-center"><strong>Demias períodos </strong></p>
            <div>
                <asp:textbox id="txtInicio" runat="server" cssclass="form-control" textmode="Date"></asp:textbox>
                <asp:textbox id="txtFim" runat="server" cssclass="form-control" textmode="Date"></asp:textbox>
                <asp:button id="btnFiltrar" runat="server" text="Filtrar" class="btn btn-secondary" onclick="btnFiltrar_Click" />
            </div>

            <asp:label ID="lblAviso" runat="server" text=""></asp:label>

        </div>
        <asp:gridview id="gdvMovimentacao" runat="server" autogeneratecolumns="False" cssclass="table table-hover view-table ">
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
        </asp:gridview>
    </div>

</asp:Content>
