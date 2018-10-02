<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsInvestimento.aspx.cs" Inherits="Projeto_Banking.Views.vwsInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container container-border margin-3-upper">
        <div class="row">
            <div id="dadosInvestimento" runat="server" class="col">
                <div class="form-group">
                    <asp:Label ID="lblValorIni" runat="server" Text="Valor inicial do Investimento:"></asp:Label>
                    <asp:TextBox ID="txtValorIni" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDataIni" runat="server" Text="Data Inicial do Investimento: "></asp:Label>
                    <asp:TextBox ID="txtDataIni" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDataFim" runat="server" Text="Data Final do Investimento: "></asp:Label>
                    <asp:TextBox ID="txtDataFim" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblInvestimento" runat="server" Text="Selecione o Tipo de Investimento: "></asp:Label>
                    <asp:DropDownList ID="ddlInvestimentos" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <asp:Button ID="BtnSimular" CssClass="btn btn-primary" runat="server" Text="Simular" OnClick="BtnSimular_Click" />
            </div>
            <div class="col">
                <%-- Exibir para auxiliar o usuário --%>
                <table class="table">
                    <tr>
                        <td><strong>Número da Conta</strong></td>
                        <td>
                            <asp:Label ID="lblContaAtual" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Saldo</strong></td>
                        <td>
                            <asp:Label ID="lblSaldo" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dadosSimulacao" class="col" runat="server" visible="false">
                <%-- Exibir após simulação --%>
                <div class="form-group">
                    <asp:Label ID="lblValorFim" runat="server" Text="Valor final do Investimento:"></asp:Label>
                    <asp:TextBox ID="txtValorFim" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnEfetuar" CssClass="btn btn-primary inner-padding-button1" runat="server" OnClick="btnEfetuar_Click" Text="Efetuar Investimento" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-outline-primary inner-padding-button2" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="container text-center margin-3-upper">
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
