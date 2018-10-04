<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsLogin.aspx.cs" Inherits="Projeto_Banking.Views.vwsLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-5 offset-4">
                <div class="container-border margin-center-vertical">
                    <div class="form-group">
                        <asp:Label ID="LblNumConta" runat="server" Text="Número da Conta"></asp:Label>
                        <asp:TextBox ID="TxtNumConta" runat="server" CssClass="form-control" placeholder="Digite o número da conta"
                            OnTextChanged="TxtNumConta_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
                        <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" CssClass="form-control"
                            placeholder="Senha da Conta" required OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
                    </div>
                    <div class="container text-center margin-3-upper margin-1-bottom">
                        <asp:Button ID="BtnLogar" Class="btn btn-primary" runat="server" Text="Logar" OnClick="BtnLogar_Click" />
                        <br />
                        <asp:Label ID="LblResultado" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
