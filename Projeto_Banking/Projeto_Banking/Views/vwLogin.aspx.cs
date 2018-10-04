using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using Projeto_Banking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogar_Click(object sender, EventArgs e)
        {

            ContaCorrente cc = new ContaCorrente()
            {
                Numero = int.Parse(TxtNumConta.Text),
                Senha = Criptografia.GerarHashMd5(TxtSenha.Text)
            };

            cc = new ContaCorrenteDAO().Login(cc);

            if (cc != null)
            {
                Session["contaCorrente"] = cc;
                Response.Redirect("~/Views/vwsContaCorrente.aspx");
            }
            else
            {
                LblResultado.Text = "Dados Inválidos!";
            }

        }
    }
}