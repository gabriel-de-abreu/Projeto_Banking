using Projeto_Banking.Objetos.ContaObjetos;
using Projeto_Banking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsLoginGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            Gerente g = new Gerente()
            {
                Login = TxtUserGerente.Text,
                Senha = TxtSenha.Text
                //Senha = Criptografia.GerarHashMd5(TxtSenha.Text)
            };

            g = new GerenteDAO().LoginGerente(g);

            if (g != null)
            {
                Session["gerente"] = g;
                //Response.Redirect("~/Views/");
            }
            else
            {
                LblResultado.Text = "Dados Inválidos!";
            }
        }
    }
}