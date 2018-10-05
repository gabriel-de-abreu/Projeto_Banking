using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            divComprovante.Visible = false;
            if (Session["contaCorrente"] == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }


            AtualizaLabels();
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                ContaCorrente conta = new ContaDAO().PesquisarContaPorNumero(int.Parse(txtConta.Text)) as ContaCorrente;

                float valor = float.Parse(txtValor.Text, CultureInfo.InvariantCulture.NumberFormat);
                if (conta != null)
                {
                    if (conta.Numero.Equals(cc.Numero))
                    {
                        lblResultado.Text = "Falha ao realizar transferência. Não é possível realizar transferências para a própria conta.";
                        AtualizaLabels();
                    }
                    else if (valor > 0 && cc.Saldo >= valor)
                    {
                        List<Conta> contas = new ContaDAO().Transferir(cc, conta, valor, "Transferência entre contas");
                        if (contas != null)
                        {
                            Session["contaCorrente"] = contas.First();
                            lblResultado.Text = "Transferência realizada com sucesso!";
                            divTransf.Visible = false;
                            divComprovante.Visible = true;
                            //Atualizar os dados para comprovante
                            lblContaOrigem.Text = cc.Numero.ToString();
                            lblNomeOrigem.Text = cc.Pessoa.Nome;
                            lblContaDestino.Text = conta.Numero.ToString();
                            lblNomeDestino.Text = conta.Pessoa.Nome;
                            lblValor.Text = valor.ToString("c2");
                        }
                        else
                            lblResultado.Text = "Falha ao realizar transferência...";

                    }
                    else
                        lblResultado.Text = "Falha ao realizar transferência...";

                }
                else
                    lblResultado.Text = "Conta de destino não encontrada!";

                AtualizaLabels();
            }
            catch
            {
                lblResultado.Text = "Entrada inválida!";
            }
        }

        private void AtualizaLabels()
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            lblContaAtual.Text = cc.Numero.ToString();
            lblSaldo.Text = cc.Saldo.ToString("c2");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsContaCorrente.aspx");
        }
    }
}