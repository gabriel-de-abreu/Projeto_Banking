<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsLogin.aspx.cs" Inherits="Projeto_Banking.Views.vwsLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container login-div";>
        <div class="row align-items-center justify-content-center">
            <div class="col-sm-4">
                <div class="form-group">
                    <asp:Label ID="LblNumConta" runat="server" Text="Número da Conta:"></asp:Label>
                    <asp:TextBox ID="TxtNumConta" runat="server" CssClass="form-control" placeholder="Digite o número da conta"
                        OnTextChanged="TxtNumConta_TextChanged"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
                    <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" CssClass="form-control"
                        placeholder="Enter Password" required OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
                </div>
                <asp:Button ID="BtnLogar" Class="btn btn-primary" runat="server" Text="Logar" OnClick="BtnLogar_Click" />
                <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
            </div>
        </div>

    </div>

</asp:Content>
