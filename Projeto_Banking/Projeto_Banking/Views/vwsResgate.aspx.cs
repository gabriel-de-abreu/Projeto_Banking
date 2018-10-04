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
        private float valorInicial;
        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            iC = Session["investimentoConta"] as InvestimentoConta;
            valorInicial = (float)(Session["investimentoConta"] as InvestimentoConta).Valor;

            if (cc == null || iC == null) Response.Redirect("~/Views/vwsContaCorrente.aspx");

            if (!IsPostBack)
            {

                PreencherCampos();
            }
        }

        private void PreencherCampos()
        {

            txtValorIni.Text = ((Convert.ToDouble(iC.Valor))).ToString("c2");
            txtValorFim.Text = ("");
            txtDataResgate.Text = ("");
            txtDataIni.Text = (iC.DataInicio).ToString("dd/MM/yyyy");
            txtDataFim.Text = (iC.DataFim).ToString("dd/MM/yyyy");

            if (iC.Resgatado)
            {
                btnResgatar.Enabled = false;
                divSelData.Visible = false;
            }

        }
        public void SimularInvestimento(object sender, EventArgs e)
        {
            try
            {
                DateTime.Parse(txtDataResgate.Text);
                txtValorFim.Text = (new InvestimentoDAO().SimulaResgate(iC, Convert.ToDateTime(txtDataResgate.Text))).ToString("c2");
                divResultado.Visible = true;
            }
            catch
            {
                divResultado.Visible = true;
                lblStringValorFim.Text = "Formato de data inválido!";
            }
            iC.Valor = valorInicial;
        }

        protected void btnResgatar_Click(object sender, EventArgs e)
        {
            InvestimentoDAO invDAO = new InvestimentoDAO();
            try
            {
                DateTime.Parse(txtDataResgate.Text);
                txtValorFim.Text = (invDAO.Resgate(iC, Convert.ToDateTime(txtDataResgate.Text))).ToString("c2");

                Response.Write("<script language='javascript'>alert('Resgate Realizado com sucesso!');</script>");
                Response.Redirect("~/Views/vwsMeusInvestimentos.aspx");
            }
            catch
            {
                divResultado.Visible = true;
                lblStringValorFim.Text = "Formato de data inválido!";
            }

        }
    }
}