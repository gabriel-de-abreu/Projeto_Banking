using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking
{
    public partial class vwfTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contaCorrente"] != null)
            {
                aMeusEmprestimos.Visible = true;
                aMeusInvestimentos.Visible = true;
                lbEntrarSair.Text = "Sair";
            }
            else
            {

                aMeusEmprestimos.Visible = false;
                aMeusInvestimentos.Visible = false;
                lbEntrarSair.Text = "Entrar";
                Response.Redirect("~/Views/vwsLogin.aspx");

            }
        }

        protected void lbEntrarSair_Click(object sender, EventArgs e)
        {
            if(Session["contaCorrente"] != null)
            {
                Session["contaCorrente"] = null;
                Response.Redirect("~/Views/vwsLogin.aspx");
            }
            else
            {
                Response.Redirect("~/Views/vwsLogin.aspx");
            }
        }
    }
}