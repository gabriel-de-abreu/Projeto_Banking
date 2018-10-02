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
    public partial class vwsRegaste : System.Web.UI.Page
    {
        ContaCorrente cc;
        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;

            if (cc == null) Response.Redirect("~/Views/vwsLogin.aspx");

            if (!IsPostBack)
            {
                PreencherCampos();
            }
        }

        private void PreencherCampos()
        {
            InvestimentoConta inv = new InvestimentoDAO().BuscarInvestimento(new InvestimentoConta() { Id = cc.Numero });

            txtValorIni.Text = ((Convert.ToDouble(inv.Valor))).ToString();
            txtValorFim.Text = ("");
            txtDataResgate.Text = ("");
            txtDataIni.Text = (inv.DataInicio).ToString();
            txtDataFim.Text = (inv.DataFim).ToString();

        }
        public void SimularInvestimento(object sender, EventArgs e)
        {
            InvestimentoConta inv = new InvestimentoConta();
            InvestimentoDAO invDAO = new InvestimentoDAO();
            inv.Id = cc.Numero;
            inv = invDAO.BuscarInvestimento(inv);
            if (!(txtDataResgate.Text).Equals(""))
            {
                txtValorFim.Text = (invDAO.SimulaResgate(inv, Convert.ToDateTime(txtDataResgate.Text))).ToString();
            }
        }

        protected void btnResgatar_Click(object sender, EventArgs e)
        {
            InvestimentoConta inv = new InvestimentoConta();
            InvestimentoDAO invDAO = new InvestimentoDAO();
            inv.Id = cc.Numero;
            inv = invDAO.BuscarInvestimento(inv);
            if (!(txtDataResgate.Text).Equals(""))
            {
                txtValorFim.Text = (invDAO.Resgate(inv, Convert.ToDateTime(txtDataResgate.Text))).ToString();
                Response.Write("<script language='javascript'>alert('Resgate Realizado com sucesso...');</script>");
                Response.Redirect("~/Views/vwsMeusInvestimentos.aspx");
            }

        }
    }
}