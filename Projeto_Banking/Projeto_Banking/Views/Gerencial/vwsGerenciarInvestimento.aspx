<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwsGerenciarInvestimento.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.vwsGerenciarInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container container-border margin-3-upper col-lg-6 ">
        <div class="container text-center margin-3-upper margin-1-bottom">

            <asp:Label runat="server" ID="lblIdInv" Text="Id do Investimento: "></asp:Label>
            <asp:TextBox runat="server" ID="txtIdInv"  ReadOnly="true"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="lblInvNom" Text="Investimento: "></asp:Label>
            <asp:TextBox runat="server" ID="txtInvNom"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="lblInvRen" Text="Valor do Investimento: "></asp:Label>
            <asp:TextBox runat="server" ID="txtInvRen"></asp:TextBox>
            <br />
            <asp:Label ID="lblInvTax" runat="server" Text="Selecione uma taxa: "></asp:Label>
            <asp:DropDownList ID="ddlInvTax" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblRes" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <asp:Button ID="btnCad" runat="server" Text="Cadastrar" OnClick="btnCad_Click" />
        <asp:Button ID="btnRem" runat="server" Text="Remover" OnClick="btnRem_Click" />
        <asp:Button ID="btnEdi" runat="server" Text="Editar" OnClick="btnEdi_Click" />

        <asp:GridView ID="gdvInvestimento" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Investimento_id" OnRowCommand="gdvInvestimento_RowCommand"
            CssClass="table table-hover view-table ">
            <Columns>
                <asp:TemplateField HeaderText="Nome do Investimento">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Investimento_nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Investimento_nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rentabilidade %">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Investimento_rentabilidade") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Investimento_rentabilidade") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Taxa %">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Taxa_Taxa_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Taxa_Taxa_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbEditar" runat="server" Text="Editar" CommandArgument='<%# Bind("Investimento_id") %>' CommandName="Editar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
