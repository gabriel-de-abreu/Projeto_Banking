<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsEmprestimo.aspx.cs" Inherits="Projeto_Banking.Views.vwsEmprestimo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container container-border margin-1-upper">
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Qual o valor do empréstimo?"></asp:Label>
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" step="0.01" min="0.01" TextMode="Number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Número de Parcelas"></asp:Label>
                    <asp:TextBox ID="txtParcelas" runat="server" CssClass="form-control" TextMode="Number" min="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Vencimento da primeira parcela"></asp:Label>
                    <asp:Label ID="lblDataVencimento" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtDataPrimeiroVencimento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class=" form-group">
                    <asp:Button ID="btnSimular" runat="server" Text="Simular" OnClick="btnSimular_Click" CssClass="btn btn-primary" />
                    <br />
                    <asp:Label ID="lblAviso" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col">
                <div runat="server" id="divSimulacao">
                    <table class="table remove-border">
                        <tr>
                            <td><b>Parcelas</b></td>
                            <td>
                                <asp:Label ID="lblParcelas" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Valor</b></td>
                            <td>
                                <asp:Label ID="lblValor" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Valor Total</b></td>
                            <td>
                                <asp:Label ID="lblValorTotal" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Taxa de Juros</b></td>
                            <td>
                                <asp:Label ID="lblTaxa" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Pagamento"></asp:Label>
                        <asp:RadioButtonList ID="rblPagamento" runat="server">
                            <asp:ListItem Text="Débito em Conta" Value="debito" Selected="True" />
                            <asp:ListItem Text="Boleto" Value="boleto" />
                        </asp:RadioButtonList>
                    </div>
                    <div id="divRealizarBtn" runat="server">
                        <asp:Button ID="btnRealizar" runat="server" Text="Realizar Empréstimo" OnClick="btnRealizar_Click" CssClass="btn btn-primary inner-padding-button1" />
                        <asp:Button ID="btnCancear" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-primary inner-padding-button3" />
                        <br />
                        <br />
                    </div>
                    <div class="alert alert-success" role="alert" runat="server" id="divResultado">
                        <asp:Label ID="lblResultado" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="container text-center margin-2-upper margin-1-bottom">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar meus empréstimos" OnClick="btnConsultar_Click" CssClass=" btn btn-outline-primary" />
            </div>
        </div>
    </div>
</asp:Content>
