<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwsCadastroConta.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.vwsCadastroConta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container margin-3-upper">
        <div class="row">
            <div class="container container-border cadastro-width margin-2-bottom-final">
                <div class="row">
                    <div class="col-sm-8">
                        <div class="form-group">
                            <label>Nome</label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>CPF</label>
                            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <label>Limite</label>
                            <asp:TextBox ID="txtLimite" runat="server" CssClass="form-control" TextMode="Number" min="0" step="0.01"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <label>Senha</label>
                            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="container text-center">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary inner-padding-button1" OnClick="btnCadastrar_Click" />
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-outline-primary inner-padding-button3 btn-background-white" OnClick="btnVoltar_Click" />
                <div>
                    <asp:Label ID="lblResultado" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                    <br />
                    <asp:Label ID="lblResultado2" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
