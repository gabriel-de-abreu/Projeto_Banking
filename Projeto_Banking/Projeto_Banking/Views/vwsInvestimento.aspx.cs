using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsInvestimento : System.Web.UI.Page
    {
        ContaCorrente cc;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            List<Investimento> investimentos = new List<Investimento>();
            if (cc == null) Response.Redirect("~/Views/vwLogin.aspx");

            if (!IsPostBack)
            {
                PopularMenuDD();
            }
            AtualizaLabels();
        }

        protected void BtnSimular_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            try
            {
                float valorIni = float.Parse(txtValorIni.Text, CultureInfo.InvariantCulture.NumberFormat);
                if (cc.Saldo >= valorIni)
                {
                    if (valorIni > 0)
                    {
                        if (DateTime.Parse(txtDataIni.Text) < DateTime.Parse(txtDataFim.Text))
                            if (DateTime.Parse(txtDataIni.Text) >= DateTime.Now.Date)
                            {
                                InvestimentoDAO investimentoDao = new InvestimentoDAO();
                                Investimento investimento = investimentoDao.BuscarInvestimentoPorId(int.Parse(ddlInvestimentos.SelectedValue));

                                InvestimentoConta investimentoConta = new InvestimentoConta()
                                {
                                    Conta = cc,
                                    Investimento = investimento,
                                    DataInicio = DateTime.Parse(txtDataIni.Text),
                                    DataFim = DateTime.Parse(txtDataFim.Text),
                                    Valor = valorIni

                                };

                                //investimentoDao.InserirInvestimento(investimentoConta);
                                txtValorFim.Text = "";

                                if (!investimento.PreFixada) txtValorFim.Text = "Aproximadamente ";

                                txtValorFim.Text += investimentoDao.SimulaResgate(investimentoConta, DateTime.Parse(txtDataFim.Text)).ToString("c2");
                                dadosSimulacao.Visible = true;
                                dadosSimulacaoBtn.Visible = true;
                                lblResultado.Text = "";
                            }

                            else
                            {
                                lblResultado.Text = "Insira as datas de forma válida!";
                                txtValorFim.Text = "";
                            }
                    }
                    else
                    {
                        lblResultado.Text = "O valor precisa ser maior que zero!";
                    }
                }
                else
                {
                    lblResultado.Text = "O valor não pode ser maior que o saldo!";
                }
            }
            catch
            {
                lblResultado.Text = "Entrada inválida!";
            }
        }

        private void PopularMenuDD()
        {
            InvestimentoDAO investimentoDao = new InvestimentoDAO();
            List<Investimento> lInvestimento = investimentoDao.BuscarTodosInvestimentos();

            ddlInvestimentos.DataSource = lInvestimento;
            ddlInvestimentos.DataTextField = "Nome";
            ddlInvestimentos.DataValueField = "Id";
            ddlInvestimentos.DataBind();

            txtDataIni.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            txtDataFim.Text = DateTime.Now.Date.AddYears(1).ToString("yyyy-MM-dd");
        }

        private void PreencherCampos()
        {
            InvestimentoConta investimento = new InvestimentoDAO().BuscarInvestimento(new InvestimentoConta() { Id = cc.Numero });

            txtValorIni.Text = ((float)investimento.Valor).ToString("c2");
            //txtValorFim.Text = 

        }

        protected void btnEfetuar_Click(object sender, EventArgs e)
        {
            InvestimentoDAO investimentoDao = new InvestimentoDAO();
            Investimento investimento = investimentoDao.BuscarInvestimentoPorId(int.Parse(ddlInvestimentos.SelectedValue));
            InvestimentoConta investimentoConta = new InvestimentoConta()
            {
                Conta = cc,
                Investimento = investimento,
                DataInicio = DateTime.Parse(txtDataIni.Text),
                DataFim = DateTime.Parse(txtDataFim.Text),
                Valor = double.Parse(txtValorIni.Text, CultureInfo.InvariantCulture.NumberFormat)
            };
            if (investimentoDao.InserirInvestimento(investimentoConta) != null)
            {
                dadosSimulacaoBtn.Visible = false;
                lblResultado.Text = "Investimento realizado com sucesso!";
            }
            else
            {
                lblResultado.Text = "Falha ao realizar investimento...";
            }
            AtualizaLabels();
        }
        private void AtualizaLabels()
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            lblContaAtual.Text = cc.Numero.ToString();
            lblSaldo.Text = ((float)cc.Saldo).ToString("c2");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            dadosSimulacao.Visible = false;
            dadosSimulacaoBtn.Visible = false;
            lblResultado.Text = "";
        }

        protected void BtnConsultarInvestimentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsMeusInvestimentos.aspx");
        }
    }
}