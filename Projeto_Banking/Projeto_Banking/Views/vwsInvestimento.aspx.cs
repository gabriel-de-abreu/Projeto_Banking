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
    public partial class vwsInvestimento : System.Web.UI.Page
    {
        ContaCorrente cc;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            List<Investimento> investimentos = new List<Investimento>();

            
            if (!IsPostBack)
            {
                PopularMenuDD();
                txtValorFim.Visible = false;
                lblValorFim.Visible = false;
            }
        }

        protected void BtnSimular_Click(object sender, EventArgs e)
        {
            if(cc.Saldo > Double.Parse(txtValorIni.Text))
            {
                if (DateTime.Parse(txtDataFim.Text) >= DateTime.Parse(txtDataRet.Text) &&
                DateTime.Parse(txtDataIni.Text) < DateTime.Parse(txtDataRet.Text))
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

                    investimentoConta = investimentoDao.InserirInvestimento(investimentoConta);
                    txtValorFim.Visible = true;
                    lblValorFim.Visible = true;
                    txtValorFim.Text = investimentoDao.Resgate(investimentoConta, DateTime.Parse(txtDataRet.Text)).ToString();
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
    }
}