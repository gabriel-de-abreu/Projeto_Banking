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
        ContaCorrente cc; InvestimentoConta iC;
        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            iC = Session["investimentoConta"] as InvestimentoConta;

            if (cc == null || iC == null) Response.Redirect("~/Views/vwsLogin.aspx");

            if (!IsPostBack)
            {
                PreencherCampos();
            }
        }

        private void PreencherCampos()
        {

            txtValorIni.Text = ((Convert.ToDouble(iC.Valor))).ToString();
            txtValorFim.Text = ("");
            txtDataResgate.Text = ("");
            txtDataIni.Text = (iC.DataInicio).ToString("dd/MM/yyyy");
            txtDataFim.Text = (iC.DataFim).ToString("dd/MM/yyyy");

        }
        public void SimularInvestimento(object sender, EventArgs e)
        {
            if (!(txtDataResgate.Text).Equals(""))
            {
                txtValorFim.Text = (new InvestimentoDAO().SimulaResgate(iC, Convert.ToDateTime(txtDataResgate.Text))).ToString();
                divResultado.Visible = true;
            }
        }

        protected void btnResgatar_Click(object sender, EventArgs e)
        {
            InvestimentoDAO invDAO = new InvestimentoDAO();
            if (!(txtDataResgate.Text).Equals(""))
            {
                txtValorFim.Text = (invDAO.Resgate(iC, Convert.ToDateTime(txtDataResgate.Text))).ToString();
                Response.Write("<script language='javascript'>alert('Resgate Realizado com sucesso...');</script>");
                Response.Redirect("~/Views/vwsMeusInvestimentos.aspx");
            }

        }
    }
}