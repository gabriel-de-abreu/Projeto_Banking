using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views.Gerencial
{
    public partial class vwsGerenciarInvestimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Taxa> lTaxas = new List<Taxa>();

            PopularMenuDD();
            PopularGrid();

        }

        private void PopularMenuDD()
        {
            TaxaDAO taxaDao = new TaxaDAO();
            List<Taxa> lTaxas = taxaDao.BuscarTodasTaxas();

            ddlInvTax.DataSource = lTaxas;
            ddlInvTax.DataTextField = "Nome";
            ddlInvTax.DataValueField = "Id";
            ddlInvTax.DataBind();

        }
        public void PopularGrid()
        {
            InvestimentoDAO investimentoDAO = new InvestimentoDAO();
            DataTable dt = investimentoDAO.MostrarInvestimentos();

            gdvInvestimento.DataSource = dt;
            gdvInvestimento.DataBind();
        }

        protected void btnCad_Click(object sender, EventArgs e)
        {
            try
            {
                TaxaDAO taxaDao = new TaxaDAO();
                string nome = txtInvNom.Text;
                double rentabilidade = Double.Parse(txtInvRen.Text);
                Taxa taxa = taxaDao.PesquisarPorTaxa(int.Parse(ddlInvTax.SelectedValue));

                InvestimentoDAO investimentoDao = new InvestimentoDAO();

                Investimento investimento = new Investimento()
                {
                    Nome = nome,
                    Taxa = taxa,
                    Rentabilidade = rentabilidade

                };
                investimento = investimentoDao.CadastrarInvestimento(investimento);
                if (investimento != null)
                {
                    txtInvNom.Text = "";
                    txtInvRen.Text = "";
                    PopularGrid();
                }
            }

            catch (Exception exp)
            {
            }
        }
        protected void gdvInvestimento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Editar"))
                    PopulaCamposInvestimento(Convert.ToInt32(e.CommandArgument.ToString()));
            }
            catch (Exception ee)
            {

            }
        }

        public void PopulaCamposInvestimento(int cod)
        {
            InvestimentoDAO invDao = new InvestimentoDAO();
            Investimento inv = invDao.BuscarInvestimentoPorId(cod);

            if (inv != null)
            {
                txtInvNom.Text = inv.Nome;
                txtInvRen.Text = inv.Rentabilidade.ToString();
                ddlInvTax.SelectedIndex = inv.Taxa.Id;
            }
        }

    }
}