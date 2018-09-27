
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwEmprestimo : System.Web.UI.Page
    {
        ContaCorrente cc;

        public object EmprestimoDAO { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            if (!IsPostBack)
            {
                divSimulacao.Visible = false;
            }
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {
            double valorDesejado, valorParcela, valorTotal;
            int parcelas;

            Taxa taxa = new TaxaDAO().PesquisarPorTaxa(1);
            //taxa.Valor = 1;

            string tipoPagamento = rblPagamento.SelectedValue;

            if (Double.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas))
            {
                Emprestimo emprestimo = new Emprestimo()
                {
                    Valor = valorDesejado,
                    Parcelas = parcelas,
                    ContaCorrente = cc,
                    Taxa = taxa,
                    DataInicio = DateTime.Now,
                };

                EmprestimoDAO empDAO = new EmprestimoDAO();
                //empDAO.InserirEmprestimo(emprestimo);

                if (tipoPagamento.Equals("Conta"))
                {
                    //a fazer
                }else if (tipoPagamento.Equals("Boleto"))
                {
                    //a fazer
                }

                lblAviso.Text = "Emrpestimo Realizado";
            }
            else
            {
                lblAviso.Text = "Dados incorretos!";
            }

        }

        protected void btnSimular_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";

            double valorDesejado, valorParcela, valorTotal, taxa;
            int parcelas;

            taxa = new TaxaDAO().PesquisarPorTaxa(1).Valor/100;


            if (Double.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas))
            {
                divSimulacao.Visible = true;

                valorTotal = valorDesejado + (parcelas*taxa*valorDesejado);
                valorParcela = valorTotal / parcelas;

                lblResultado.Text = "Número de Parcelas: " + parcelas + "\nValor da parcela: R$ " + valorParcela + "\nValor Total: R$" + valorTotal;
            }
            else
            {
                lblAviso.Text = "Dados incorretos!";
            }
        }

    }
}