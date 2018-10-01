<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsLogin.aspx.cs" Inherits="Projeto_Banking.Views.vwsLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            <div>   
                <asp:Label ID="LblNumConta" runat="server" Text="Número da Conta:"></asp:Label>
                <asp:TextBox ID="TxtNumConta" runat="server" OnTextChanged="TxtNumConta_TextChanged"></asp:TextBox>
            </div>

             <div>   
                <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
                <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="BtnLogar" class = "btn btn-primary" runat="server" Text="Logar" OnClick="BtnLogar_Click" style="height: 26px" />

            <br />
        <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
</asp:Content>
