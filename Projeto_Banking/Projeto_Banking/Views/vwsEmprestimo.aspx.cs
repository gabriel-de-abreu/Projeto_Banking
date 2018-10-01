using Projeto_Banking.Models;
using Projeto_Banking.Models.Opecacoes.Emprestimo;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsEmprestimo : System.Web.UI.Page
    {
        ContaCorrente cc;
        DateTime dataMinima = DateTime.Today.AddDays(1);
        DateTime dataMaxima = DateTime.Today.AddMonths(1);
        DateTime data;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;

            lblDataVencimento.Text = " (entre " + dataMinima.ToString("dd/MM/yyyy") + " e " + dataMaxima.ToString("dd/MM/yyyy") + ")"; //exibe data limites para o primeiro vencimento

            if (!IsPostBack)
            {
                divSimulacao.Visible = false;
            }
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {
            float valorDesejado;
            int parcelas;

            Taxa taxa = new TaxaDAO().PesquisarPorTaxa(EmprestimoOPS.VerificarPerfil(cc)); //obtem taxa atraves do perfil da pessoa

            string tipoPagamento = rblPagamento.SelectedValue;
            data = DateTime.Parse(txtDataPrimeiroVencimento.Text);

            if (float.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas) && dataMinima < data && dataMaxima > data)
            {
                Emprestimo emprestimo = new Emprestimo()
                {
                    Valor = valorDesejado,
                    Parcelas = parcelas,
                    ContaCorrente = cc,
                    Taxa = taxa,
                    DataInicio = data,
                };

                EmprestimoDAO empDAO = new EmprestimoDAO();
                if (empDAO.InserirEmprestimo(emprestimo, tipoPagamento))
                {
                    
                    //atualizar saldo da conta corrente

                    lblResultado.Text = "Empréstimo Realizado com Sucesso!";
                }
            }
            else
            {
                lblAviso.Text = "Dados incorretos!";
            }

        }

        protected void btnSimular_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";

            double valorDesejado, valorParcela, valorTotal;
            int parcelas;

            Taxa taxa = new TaxaDAO().PesquisarPorTaxa(EmprestimoOPS.VerificarPerfil(cc)); //obtem taxa atraves do perfil da pessoa
            data = DateTime.Parse(txtDataPrimeiroVencimento.Text);

            if (Double.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas) && dataMinima < data && dataMaxima > data)
            {
                divSimulacao.Visible = true;

                valorParcela = EmprestimoOPS.CalcularParcelas(parcelas, taxa, valorDesejado); //calcula valor das parcelas 
                valorTotal = valorParcela * parcelas;

                lblParcelas.Text = parcelas.ToString();
                lblValor.Text = "R$ " + valorParcela.ToString("0.00");
                lblValorTotal.Text = "R$" + valorTotal.ToString("0.00");
                lblTaxa.Text = taxa.Valor + "%";
            }
            else
            {
                lblAviso.Text = "Dados incorretos!";
            }
        }

    }
}