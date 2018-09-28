using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Banking.Models;
using Projeto_Banking.Models.Operacoes.Investimento;
using Projeto_Banking.Objetos;

namespace Projeto_Banking.Views
{
    public partial class vwSimualarInvestimento : System.Web.UI.Page
    {
        ContaCorrente cc;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
        }

        protected void BtnSimular_Click(object sender, EventArgs e)
        {

        }

    }
}