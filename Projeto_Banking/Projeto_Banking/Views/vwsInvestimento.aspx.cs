using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
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
            lblValorFim.Visible = txtValorFim.Visible = btnEfetuar.Visible = false;

            if (!IsPostBack)
            {
                PopularMenuDD();
            }
        }

        protected void BtnSimular_Click(object sender, EventArgs e)
        {
            if(cc.Saldo > Double.Parse(txtValorIni.Text))
            {
                if(DateTime.Parse(txtDataIni.Text) < DateTime.Parse(txtDataFim.Text))
                {
                    InvestimentoDAO investimentoDao = new InvestimentoDAO();
                    Investimento investimento = investimentoDao.BuscarInvestimentoPorId(int.Parse(ddlInvestimentos.SelectedValue));

                    InvestimentoConta investimentoConta = new InvestimentoConta()
                    {
                        Conta = cc,
                        Investimento = investimento,
                        DataInicio = DateTime.Parse(txtDataIni.Text),
                        DataFim = DateTime.Parse(txtDataFim.Text),
                        Valor = double.Parse(txtValorIni.Text)

                    };

                    //investimentoDao.InserirInvestimento(investimentoConta);
                     txtValorFim.Text = investimentoDao.SimulaResgate(investimentoConta, DateTime.Parse(txtDataFim.Text)).ToString();
                    lblValorFim.Visible = txtValorFim.Visible = btnEfetuar.Visible = true ;
                }
                else
                {
                    lblResultado.Text = "Insira as datas de forma válida!";
                }
            }
            else
            {
                lblResultado.Text = "O valor não pode ser maior que o saldo!";

            }




        }
        private void PopularMenuDD()
        {
            InvestimentoDAO investimentoDao = new InvestimentoDAO();
            List<Investimento> lInvestimento = investimentoDao.PopularDropMenu();

            ddlInvestimentos.DataSource = lInvestimento;
            ddlInvestimentos.DataTextField = "Nome";
            ddlInvestimentos.DataValueField = "Id";
            ddlInvestimentos.DataBind();
        }

        public void PreencherCampos()
        {
            InvestimentoConta investimento = new InvestimentoDAO().BuscarInvestimento(new InvestimentoConta() {  Id = cc.Numero });

            txtValorIni.Text = ((Convert.ToDouble(investimento.Valor))).ToString();
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
                Valor = double.Parse(txtValorIni.Text)

            };

            if (investimentoDao.InserirInvestimento(investimentoConta) != null)
            {
                lblResultado.Text = "Investimento realizado com sucesso!";
            }
            else lblResultado.Text = "Falha ao realizar investimento...";
        }
    }
}