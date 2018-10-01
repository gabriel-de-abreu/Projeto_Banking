<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsEmprestimo.aspx.cs" Inherits="Projeto_Banking.Views.vwsEmprestimo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar meus empréstimos" Onclick="btnConsultar_Click"/>
    </div>
    <div>
            <asp:Label ID="Label1" runat="server" Text="Qual o valor do empréstimo?"></asp:Label>
            <br />
            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Número de Parcelas"></asp:Label>
            <br />
            <asp:TextBox ID="txtParcelas" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Vencimento da primeira parcela"></asp:Label>
            <br />
            <asp:TextBox ID="txtDataPrimeiroVencimento" runat="server"></asp:TextBox>
            <asp:Label ID="lblDataVencimento" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnSimular" runat="server" Text="Simular" OnClick="btnSimular_Click" />
            <br />
            <asp:Label ID="lblAviso" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div runat="server" id="divSimulacao">
            <br />
            <br />
            <table>
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

            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Pagamento"></asp:Label>
            <br />

            <asp:RadioButtonList ID="rblPagamento" runat="server">
                <asp:ListItem Text="Débito em Conta" Value="debito" Selected="True" />
                <asp:ListItem Text="Boleto" Value="boleto" />
            </asp:RadioButtonList>


            <br />
            <br />
            <asp:Button ID="btnRealizar" runat="server" Text="Realizar Empréstimo" OnClick="btnRealizar_Click" />
            <br /><br />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
