using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views.Gerencial
{
    public partial class PrincipalGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Carregar dados aqui
        }

        protected void btnCadastroConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Gerencial/vwsCadastroConta.aspx");
        }

        protected void btnCadastroInvestimento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Gerencial/vwsGerenciarInvestimento.aspx");

        }
    }
}