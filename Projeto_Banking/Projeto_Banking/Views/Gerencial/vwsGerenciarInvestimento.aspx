<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Gerencial/vwGerencialMaster.Master" AutoEventWireup="true" CodeBehind="vwsGerenciarInvestimento.aspx.cs" Inherits="Projeto_Banking.Views.Gerencial.vwsGerenciarInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container container-border margin-3-upper col-lg-6 ">
        <div>
            <div class="container">
                <div class="form-group" id="divIdInv" runat="server">
                    <label>Id do Investimento</label>
                    <asp:TextBox ID="txtIdInv" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label><strong>Nome do Investimento</strong></label>
                    <asp:TextBox ID="txtInvNom" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label><strong>Rendimento do Investimento</strong></label>
                    <asp:TextBox ID="txtInvRen" runat="server" TextMode="Number" placeholder="Caso o investimento seja pós-fixado, esse campo deve ficar vazio." CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label><strong>Selecione uma Taxa</strong></label>
                    <asp:DropDownList ID="ddlInvTax" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="container text-center margin-3-upper margin-1-bottom">
                    <asp:Button ID="btnCad" runat="server" class="btn btn-primary" Text="Cadastrar Novo" OnClick="btnCad_Click" />
                    <asp:Button ID="btnEdi" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnEdi_Click" />
                    <asp:Button ID="btnSal" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSal_Click" />
                    <asp:Button ID="btnRem" runat="server" class="btn btn-outline-primary" Text="Remover" OnClick="btnRem_Click" />
                    <asp:Button ID="btnCan" runat="server" class="btn btn-outline-primary" Text="Cancelar" OnClick="btnCan_Click" />

                    <br />
                    <br />
                    <div class="alert alert-primary" role="alert" id="divRes" runat="server">
                        <asp:Label ID="lblRes" runat="server" Text="" CssClass="margin-1-upper"></asp:Label>
                    </div>
                </div>
            </div>
        </div>




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
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Taxa_valor") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Taxa_valor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbEditar" runat="server" Text="Selecione" CommandArgument='<%# Bind("Investimento_id") %>' CommandName="Selecionar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
