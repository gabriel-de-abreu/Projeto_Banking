<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwPrincipalGerente.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.PrincipalGerente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container margin-3-upper">
        <div class="container  container-border margin-2-bottom-final">
            <div class="row">
                <div class="col-md-8 borda-lateral">
                    <div class="container text-center">
                        <h4 class="text-center margin-1-bottom">Últimas Movimentações
                        </h4>
                        <table class="table">
                            <tr>
                                <th>Conta de Origem
                                </th>
                                <th>Conta de Destino
                                </th>
                                <th>Descrição
                                </th>
                                <th>Valor
                                </th>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>2
                                </td>
                                <td>Movimentação de dinheiro
                                </td>
                                <td>100
                                </td>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>2
                                </td>
                                <td>Movimentação de dinheiro
                                </td>
                                <td>100
                                </td>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>2
                                </td>
                                <td>Movimentação de dinheiro
                                </td>
                                <td>100
                                </td>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>2
                                </td>
                                <td>Movimentação de dinheiro
                                </td>
                                <td>100
                                </td>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>2
                                </td>
                                <td>Movimentação de dinheiro
                                </td>
                                <td>100
                                </td>
                            </tr>
                            <tr>
                                <td>1
                                </td>
                                <td>2
                                </td>
                                <td>Movimentação de dinheiro
                                </td>
                                <td>100
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="container text-center">
                        <h4 class="text-center margin-1-bottom">Contas Contábeis
                        </h4>
                        <table class="table">
                            <tr>
                                <td><strong>Investimentos</strong></td>
                                <td>10000</td>
                            </tr>
                            <tr>
                                <td><strong>Empréstimos</strong></td>
                                <td>10000</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="container text-center">
                <asp:Button ID="btnCadastroConta" runat="server" Text="Cadastrar Conta" CssClass="btn btn-primary btn-principal inner-padding-button1" OnClick="btnCadastroConta_Click" />
                <asp:Button ID="btnCadastroInvestimento" runat="server" Text="Cadastrar Investimento" CssClass="btn btn-primary btn-principal inner-padding-button2" />
                <asp:Button ID="btnConsultarMovimentacoes" runat="server" Text="Consultar Movimentações" CssClass="btn btn-primary btn-principal inner-padding-button3" OnClick="btnConsultarMovimentacoes_Click" />
            </div>
        </div>
    </div>
</asp:Content>
