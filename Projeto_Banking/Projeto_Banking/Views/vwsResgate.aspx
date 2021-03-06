﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsResgate.aspx.cs" Inherits="Projeto_Banking.Views.vwsRegaste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container container-border margin-3-upper">
        <div class="row">
            <div id="divSelData" class="col-4" runat="server">
                <div class="container-border">
                    <div class="form-group">
                        <label>Data Desejada do Resgate</label>
                        <asp:TextBox ID="txtDataResgate"
                            runat="server"
                            AutoPostBack="True"
                            OnTextChanged="SimularInvestimento" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="margin-1-upper">
                        <span>O valor disponível para resgate na data selecionada é de:
                            <asp:Label ID="txtValorFim" runat="server"></asp:Label></span>
                    </div>
                </div>
            </div>
            <div class="col">
                <table class="table remove-border">
                    <tr>
                        <td>
                            <strong>Valor Inicial do Investimento
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="txtValorIni" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Data Inicial do Investimento
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="txtDataIni" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <strong>Data Final do Investimento
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="txtDataFim" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Data de Resgate do Investimento
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="txtResgate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Valor Recebido Pelo Investimento
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="txtValorRecebido" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="container text-center margin-1-bottom">
                <div id="divResultado" class="form-group" runat="server" visible="false">
                    <asp:Label ID="lblStringValorFim" runat="server">Valor Final do Investimento:</asp:Label>
                </div>
                <asp:Button ID="btnResgatar" runat="server" Text="Resgatar Investimento" OnClick="btnResgatar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
