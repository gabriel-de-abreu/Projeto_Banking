<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsLoginGerente.aspx.cs" Inherits="Projeto_Banking.Views.vwsLoginGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-5 offset-4">
                <div class="container-border margin-center-vertical">
                    <div class="form-group">
                        <asp:Label ID="LblUserGerente" runat="server" Text="Usuário:"></asp:Label>
                        <asp:TextBox ID="TxtUserGerente" runat="server" CssClass="form-control" placeholder="ID"
                            ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
                        <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" CssClass="form-control"
                            placeholder="Enter Password"></asp:TextBox>
                    </div>
                    <div class="container text-center margin-3-upper margin-1-bottom">
                        <asp:Button ID="BtnLogar" Class="btn btn-primary" runat="server" Text="Logar" OnClick="BtnLogar_Click"/>
                        <br />
                        <asp:Label ID="LblResultado" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
