<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwsGerenciarInvestimento.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.vwsGerenciarInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:label runat="server" id="lblIdInv" text="Id do Investimento: "></asp:label>
    <asp:textbox runat="server" id="txtIdInv"></asp:textbox>
    <br />
    <asp:label runat="server" id="lblInvNom" text="Investimento: "></asp:label>
    <asp:textbox runat="server" id="txtInvNom"></asp:textbox>
    <br />
    <asp:label runat="server" id="lblInvRen" text="Valor do Investimento: "></asp:label>
    <asp:textbox runat="server" id="txtInvRen"></asp:textbox>
    <br />
    <asp:label id="lblInvTax" runat="server" text="Selecione uma taxa: "></asp:label>
    <asp:dropdownlist id="ddlInvTax" runat="server"></asp:dropdownlist>
    <br />
    <br />

    <asp:button id="btnCad" runat="server" text="Cadastrar" onclick="btnCad_Click" />
    <asp:Button ID="btnRem" runat="server" Text="Remover" OnClick="btnRem_Click" />
    <asp:Button ID="btnEdi" runat="server" Text="Editar" />

    <asp:gridview id="gdvInvestimento" runat="server"
        autogeneratecolumns="False"
        datakeynames="Investimento_id" onrowcommand="gdvInvestimento_RowCommand"
        backcolor="White" bordercolor="#CCCCCC" borderstyle="None" borderwidth="1px" cellpadding="4" forecolor="Black" gridlines="Horizontal"> 
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
    </asp:gridview>

</asp:Content>
