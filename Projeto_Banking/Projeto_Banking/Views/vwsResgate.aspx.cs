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
            if (cc == null) Response.Redirect("~/Views/vwLogin.aspx");
            iC = Session["investimentoConta"] as InvestimentoConta;
            valorInicial = (float)(Session["investimentoConta"] as InvestimentoConta).Valor;

            if (iC == null) Response.Redirect("~/Views/vwsContaCorrente.aspx");

            if (!IsPostBack)
            {
                PreencherCampos();
                if (!iC.Resgatado)
                    SimularInvestimento();
            }
        }

        private void PreencherCampos()
        {

            txtValorIni.Text = ((Convert.ToDouble(iC.Valor))).ToString("c2");
            txtValorFim.Text = ("");
            txtDataIni.Text = (iC.DataInicio).ToString("dd/MM/yyyy");
            txtDataFim.Text = (iC.DataFim).ToString("dd/MM/yyyy");
            txtDataResgate.Text = (iC.DataFim).ToString("yyyy-MM-dd");
            txtResgate.Text = (iC.DataResgate).ToString("dd/MM/yyyy");
            txtValorRecebido.Text = (iC.ValorResgate).ToString("c2");


            if (iC.Resgatado)
            {
                btnResgatar.Enabled = false;
                divSelData.Visible = false;
            }
            else
            {
                txtResgate.Text = "Não Resgatado";
                txtValorRecebido.Text = "Não Resgatado";
            }

        }
        public void SimularInvestimento(object sender, EventArgs e)
        {
            SimularInvestimento();
        }

        private void SimularInvestimento()
        {
            lblStringValorFim.Text = "";
            try
            {
                if (iC.Investimento.Rentabilidade <= 0)
                    txtValorFim.Text = "Aproximadamente ";
                else
                    txtValorFim.Text = "";

                if (DateTime.Parse(txtDataResgate.Text) < DateTime.Now.Date)
                    throw new System.ArgumentException();


                txtValorFim.Text += (new InvestimentoDAO().SimulaResgate(iC, DateTime.Parse(txtDataResgate.Text))).ToString("c2");
                divResultado.Visible = true;
            }
            catch
            {
                divResultado.Visible = true;
                lblStringValorFim.Text = "Formato de data inválido!";
                txtValorFim.Text = "";
            }
            iC.Valor = valorInicial;
        }

        protected void btnResgatar_Click(object sender, EventArgs e)
        {
            InvestimentoDAO invDAO = new InvestimentoDAO();
            try
            {
                txtValorFim.Text = (invDAO.Resgate(iC, DateTime.Parse(txtDataResgate.Text))).ToString("c2");

                Response.Write("<script language='javascript'> alert('Investimento resgatado com sucesso!');</script>");
                Response.Write("<script>window.location.href='vwsMeusInvestimentos.aspx';</script>");
            }
            catch
            {
                divResultado.Visible = true;
                lblStringValorFim.Text = "Formato de data inválido!";
                txtValorFim.Text = "";
            }
        }

    }
}
