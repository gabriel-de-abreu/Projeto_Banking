using Projeto_Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views.Gerencial
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logar_Click(object sender, EventArgs e)
        {
            if (new GerenteDAO().Login(txtUsuario.Text, txtSenha.Text))
            {
                Session["Gerente"] = true;
                Response.Redirect("~/Views/Gerencial/vwPrincipalGerente.aspx");
            }
            else
            {
                lblResultado.Text = "Login ou Senha inválidos!";
            }
        }
    }
}