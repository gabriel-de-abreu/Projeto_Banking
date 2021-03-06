﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsMeusInvestimentos.aspx.cs" Inherits="Projeto_Banking.Views.vwsMeusInvestimentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class = "container container-border margin-3-upper">
        <asp:GridView ID="gdvMeusInvestimentos" runat="server"
            AutoGenerateColumns="False" OnSelectedIndexChanged="gdvMeusInvestimentos_SelectedIndexChanged"
            DataKeyNames="Investimento_Conta_Id" CssClass ="table table-hover view-table">
            <Columns>
                <asp:TemplateField HeaderText="Conta Corrente">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContaCorrenteId" runat="server" Text='<%# Bind("Conta_Corrente_Conta_Conta_Corrente_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblContaCorrenteId" runat="server" Text='<%# Bind("Conta_Corrente_Conta_Conta_Corrente_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor do Investimento">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Investimento_Conta_Valor_Formatado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Investimento_Conta_Valor_Formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Inicio">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtInvestimentoInicio" runat="server" Text='<%# Bind("Investimento_Inicio_Formatado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ldlInvestimentoInicio" runat="server" Text='<%# Bind("Investimento_Inicio_Formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Término">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtInvestimentoFim" runat="server" Text='<%# Bind("Investimento_Fim_Formatado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInvestimentoFim" runat="server" Text='<%# Bind("Investimento_Fim_Formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resgatado">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Investimento_Resgate_Formatado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Investimento_Resgate_Formatado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Operações">
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbAbrir" runat="server" Text="Abrir"
                            CommandName="Select"
                            CommandArgument='<%# Bind("Investimento_Conta_Id") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
