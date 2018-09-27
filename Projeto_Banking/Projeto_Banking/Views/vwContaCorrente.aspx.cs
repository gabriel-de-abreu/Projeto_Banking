using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwContaCorrente : System.Web.UI.Page
    {
        ContaCorrente ccSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["contaCorrente"]!= null)
            {
                ccSession = Session["contaCorrente"] as ContaCorrente;
            }
            lblNumConta.Text = ccSession.NumConta; //validar nome com objeto
            lblSaldo.Text = ccSession.Saldo; //validar nome com objeto
        }

        protected void btnEmprestimo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vwEmprestimo.aspx");
        }

        protected void btnInvestimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vwInvestimento.aspx");
        }
    }
}