using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;
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
    public partial class vwsMeusInvestimentos : System.Web.UI.Page
    {
        int numeroConta = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ContaCorrente cc = Session["contaCorrente"] as ContaCorrente;
            numeroConta = cc.Numero;
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            InvestimentoDAO investimentoDAO = new InvestimentoDAO();
            ContaCorrente cc = new ContaCorrenteDAO().PesquisarPorNumero(numeroConta);
            DataTable dt = investimentoDAO.BuscarInvestimentosConta(cc);
            gdvMeusInvestimentos.DataSource = dt;
            gdvMeusInvestimentos.DataBind();
        }

        protected void gdvMeusInvestimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gdvMeusInvestimentos.SelectedIndex;
            int id = Convert.ToInt32(gdvMeusInvestimentos.DataKeys[rowIndex].Value);
            ContaCorrente ccSession = Session["contaCorrente"] as ContaCorrente;
            ccSession.Numero = Convert.ToInt32(gdvMeusInvestimentos.DataKeys[rowIndex].Value.ToString());
            Response.Redirect("~/Views/vwsInvestimento.aspx");
        }
    }
}