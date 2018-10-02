<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsTransferencia.aspx.cs" Inherits="Projeto_Banking.Views.vwsTransferencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container text-center margin-3-upper">
        <div id="divTransf" runat="server">
            <div class="row">
                <div class="col-4">
                    <div class="form-group">
                        <label>Conta Destino</label>
                        <asp:TextBox ID="txtConta" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Valor</label>
                        <asp:TextBox ID="txtValor" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnTransferir" runat="server" OnClick="btnTransferir_Click" Text="Transferir" CssClass="btn btn-primary" />
                    <br />
                </div>
                <div class="col">
                    <div class="form-group">
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
                </div>
            </div>
            <div class="row">
                <div class="container text-center">
                    <asp:Label ID="lblResultado" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div id="divComprovante" class="row" runat="server">
            <div class="container text-center">
                <div class="margin-2-upper">
                    <h5>Comprovante de Envio
                    </h5>
                    <table class="table">
                        <tr>
                            <td>
                                <strong>Conta de Origem</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblContaOrigem" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td><strong>Nome</strong></td>
                            <td>
                                <asp:Label ID="lblNomeOrigem" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Conta de Destino</strong></td>
                            <td>
                                <asp:Label ID="lblContaDestino" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td><strong>Nome</strong></td>
                            <td>
                                <asp:Label ID="lblNomeDestino" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Valor</strong>
                            </td>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblValor" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="alert alert-success" role="alert">
                        Operação Realizada com sucesso!
                    </div>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-primary" OnClick="btnVoltar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
