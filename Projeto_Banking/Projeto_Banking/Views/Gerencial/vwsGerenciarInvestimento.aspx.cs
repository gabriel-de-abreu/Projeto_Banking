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

        List<Taxa> lTaxas = new List<Taxa>();
        int idSelecionado = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean isActive = Convert.ToBoolean(Session["gerente"]);
            if (!isActive || Session["gerente"] == null)
            {
                Response.Redirect("~/Views/Gerencial/vwLoginGerente.aspx");
            }
            divEditBtn.Visible = false;
            PopularGrid();
            if (!IsPostBack)
            {
                PopularMenuDD();

            }
            if (Session["cadInvIdSel"] != null)
            {
                idSelecionado = Convert.ToInt32(Session["cadInvIdSel"]);

            }
            else
            {
                idSelecionado = -1;
            }
            divRes.Visible = false;

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

        protected void gdvInvestimento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Selecionar"))
                {
                    PopularMenuDD();
                    idSelecionado = Convert.ToInt32(e.CommandArgument);
                    Session["cadInvIdSel"] = idSelecionado;
                    divEditBtn.Visible = true;
                    btnCad.Visible = false;
                    PopulaCamposInvestimento(idSelecionado);

                }
            }
            catch (Exception ee)
            {
                throw ee;
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
                int index = 0;
                foreach (Taxa taxa in ddlInvTax.DataSource as List<Taxa>)
                {
                    if (taxa.Id == inv.Taxa.Id)
                    {
                        ddlInvTax.SelectedIndex = index;
                    }
                    index++;
                }
            }
        }

        protected void btnCad_Click(object sender, EventArgs e)
        {

            try
            {
                TaxaDAO taxaDao = new TaxaDAO();
                string nome = txtInvNom.Text;
                double rentabilidade = 0;
                Taxa taxa = new TaxaDAO().PesquisarPorTaxa(int.Parse(ddlInvTax.SelectedValue));
                if (txtInvRen.Text.Length > 0)
                {
                    rentabilidade = Double.Parse(txtInvRen.Text);
                }
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
                    lblRes.Text = "Inserção realizada com sucesso";
                    LimpaCampos();
                    PopularGrid();
                }
                else
                {
                    lblRes.Text = "Erro na inserção.";
                }
                divRes.Visible = true;
            }

            catch (Exception)
            {
                lblRes.Text = "Investimento já existente";
                divRes.Visible = true;


            }
        }

        protected void btnRem_Click(object sender, EventArgs e)
        {
            InvestimentoDAO invDao = new InvestimentoDAO();
            if (invDao.RemoverInvestimento(idSelecionado))
            {
                lblRes.Text = "Investimento deletado com sucesso!";
                LimpaCampos();
                PopularGrid();
            }
            else
            {
                lblRes.Text = "Falha ao deletar o investimento !";
            }
            divRes.Visible = true;
        }


        protected void btnCan_Click(object sender, EventArgs e)
        {
            LimpaCampos();

        }

        protected void btnSal_Click(object sender, EventArgs e)
        {
            try
            {
                TaxaDAO taxaDao = new TaxaDAO();
                string nome = txtInvNom.Text;
                double rentabilidade = 0;
                Taxa taxa = taxaDao.PesquisarPorTaxa(int.Parse(ddlInvTax.SelectedValue));
                int id = idSelecionado;

                if (txtInvRen.Text.Length > 0)
                {
                    rentabilidade = Double.Parse(txtInvRen.Text);
                }
                InvestimentoDAO investimentoDao = new InvestimentoDAO();

                Investimento investimento = new Investimento()
                {
                    Id = id,
                    Nome = nome,
                    Taxa = taxa,
                    Rentabilidade = rentabilidade

                };

                investimento = investimentoDao.EditarInvestimento(investimento);


                if (investimento != null)
                {
                    lblRes.Text = "Investimento alterado com sucesso!";
                    LimpaCampos();
                    PopularGrid();
                }
                else
                {
                    lblRes.Text = "Falha ao alterar investimento!";

                }
                divRes.Visible = true;
            }
            catch (Exception exp)
            {
                lblRes.Text = "Erro!";

            }
        }


        public void LimpaCampos()
        {
            txtInvNom.Text = "";
            txtInvRen.Text = "";
            btnCad.Visible = true;
        }


    }
}