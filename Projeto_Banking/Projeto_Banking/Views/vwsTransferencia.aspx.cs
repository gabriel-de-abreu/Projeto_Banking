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
            if (Session["contaCorrente"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
 
                AtualizaLabels();
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaDAO().PesquisarContaPorNumero(int.Parse(txtConta.Text)) as ContaCorrente;

            float valor = float.Parse(txtValor.Text);

            if (cc.Saldo >= valor)
            {
                List<Conta> contas = new ContaDAO().Transferir(cc, conta, valor, "Transferência entre contas");
                if (contas != null)
                {
                    Session["contaCorrente"] = contas.First();
                    lblResultado.Text = "Transferência realizada com sucesso!";
                    Response.Write("<script language='javascript'>alert('Transferência realizada com sucesso!');</script>");
                }
                else
                {
                    lblResultado.Text = "Falha ao realizar transferência...";
                    Response.Write("<script language='javascript'>alert('Falha ao realizar transferência...');</script>");
                }
            }
            else
            {
                lblResultado.Text = "Falha ao realizar transferência...";
                Response.Write("<script language='javascript'>alert('Falha ao realizar transferência...');</script>");
            }
            AtualizaLabels();

        }

        private void AtualizaLabels()
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            lblContaAtual.Text = "Número da Conta: " + cc.Numero;
            lblSaldo.Text = "Saldo: " + cc.Saldo;
        }
    }
}