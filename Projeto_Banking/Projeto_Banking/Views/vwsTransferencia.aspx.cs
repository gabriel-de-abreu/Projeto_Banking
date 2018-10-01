using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsTransferencia : System.Web.UI.Page
    {
        ContaCorrente cc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contaCorrente"] != null)
            {
                cc = Session["contaCorrente"] as ContaCorrente;
                lblContaAtual.Text = "Número da Conta: " +cc.Numero;
                lblSaldo.Text = "Saldo: " +cc.Saldo;
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Numero = int.Parse(txtConta.Text);

            float valor = float.Parse(txtValor.Text);

            new ContaDAO().Transferir(cc,conta,valor,"Transferência entre contas");
        }
    }
}