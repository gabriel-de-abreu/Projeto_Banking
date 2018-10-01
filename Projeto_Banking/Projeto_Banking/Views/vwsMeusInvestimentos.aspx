<%@ Page Title="" Language="C#" MasterPageFile="~/Views/vwfTemplate.Master" AutoEventWireup="true" CodeBehind="vwsMeusInvestimentos.aspx.cs" Inherits="Projeto_Banking.Views.vwsMeusInvestimentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:gridview id="gdvMeusInvestimentos" runat="server"></asp:gridview>
    </div>
</asp:Content>
