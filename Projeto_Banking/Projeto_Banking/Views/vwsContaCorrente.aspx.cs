using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsContaCorrente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contaCorrente"] == null) Response.Redirect("~/Views/vwLogin.aspx");
            if (!IsPostBack)
            {
                Session["contaCorrente"] = new ContaDAO().PesquisarContaPorNumero((Session["contaCorrente"] as ContaCorrente).Numero);
                ContaCorrente ccSession = Session["contaCorrente"] as ContaCorrente;
                lblNumero.Text += ccSession.Numero.ToString(); //validar nome com objeto
                lblSaldo.Text += ccSession.Saldo.ToString("c2"); //validar nome com objeto
                lblLimite.Text += ccSession.Limite.ToString("c2");
                lblTitular.Text += ccSession.Pessoa.Nome;
            }

        }

        protected void btnEmprestimo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsEmprestimo.aspx");
        }

        protected void btnInvestimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsInvestimento.aspx");
        }

        protected void btnMeusInvestimentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsMeusInvestimentos.aspx");
        }

        protected void btnTransferencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsTransferencia.aspx");

        }
        protected void btnExtrato_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsExtrato.aspx");

        }
    }
}