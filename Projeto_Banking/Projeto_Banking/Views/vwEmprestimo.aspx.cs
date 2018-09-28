
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Opecacoes.Emprestimo;
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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            lblDataVencimento.Text = " (entre " + DateTime.Today.AddDays(1).ToString("dd/MM/yyyy") + " e "+ DateTime.Today.AddMonths(1).ToString("dd/MM/yyyy")+")"; //exibe data limites para o primeiro vencimento

            if (!IsPostBack)
            {
                divSimulacao.Visible = false;
            }
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {
            double valorDesejado;
            int parcelas;

            Taxa taxa = new TaxaDAO().PesquisarPorTaxa(1);
           
            string tipoPagamento = rblPagamento.SelectedValue;

            if (Double.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas))
            {
                Emprestimo emprestimo = new Emprestimo()
                {
                    Valor = valorDesejado,
                    Parcelas = parcelas,
                    ContaCorrente = cc,
                    Taxa = taxa,
                    DataInicio = DateTime.Parse(txtDataPrimeiroVencimento.Text),
                };

                EmprestimoDAO empDAO = new EmprestimoDAO();
                //if(empDAO.InserirEmprestimo(emprestimo, tipoPagamento){

                lblAviso.Text = "Emprestimo Realizado";
                    //atualizar saldo da conta corrente
                    
                    lblResultado.Text = "Empréstimo Realizado com Sucesso!";
                //}
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

            cc = new ContaCorrente() {
                Pessoa = new PessoaDAO().PesquisaPessoaPorId(1)
            };

            Taxa taxa = EmprestimoOPS.VerificarPerfil(cc.Pessoa); //obtem taxa atraves do perfil da pessoa
            
            if (Double.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas))
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