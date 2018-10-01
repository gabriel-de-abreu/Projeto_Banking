<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsMeusInvestimentos.aspx.cs" Inherits="Projeto_Banking.Views.vwsMeusInvestimentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:GridView ID="gdvMeusInvestimentos" runat="server" 
            AutoGenerateColumns="False" OnSelectedIndexChanged="gdvMeusInvestimentos_SelectedIndexChanged"
            DataKeyNames="Investimento_Conta_Id">
            
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
                        <asp:TextBox ID="txtContaValor" runat="server" Text='<%# Bind("Investimento_Conta_Valor") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblContaValor" runat="server" Text='<%# Bind("Investimento_Conta_Valor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Inicio">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtInvestimentoInicio" runat="server" Text='<%# Bind("Investimento_Inicio") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ldlInvestimentoInicio" runat="server" Text='<%# Bind("Investimento_Inicio") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Término">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtInvestimentoFim" runat="server" Text='<%# Bind("Investimento_Fim") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInvestimentoFim" runat="server" Text='<%# Bind("Investimento_Fim") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Operações">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbAbrir" runat="server" Text="Abrir"
                                CommandName="Select" 
                                OnClientClick="return confirm('Deseja realmente visualizar esse investimento?');" 
                                CommandArgument='<%# Bind("Investimento_Conta_Id") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>                                               
                    </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblDeuPau" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
