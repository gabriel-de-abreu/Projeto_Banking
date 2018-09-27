<<<<<<< HEAD
﻿using Projeto_Banking.Controllers;
=======
﻿using Projeto_Banking.Models.Conta;
>>>>>>> 350088d9a295ea4249d4d128fb9fa3928f9c06fc
using Projeto_Banking.Objetos;
using Projeto_Banking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtNumConta_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnLogar_Click(object sender, EventArgs e)
       {
            //    TxtSenha.Text = Criptografia.GerarHashMd5(TxtSenha.Text);
<<<<<<< HEAD
            ContaCorrenteController ccController = new ContaCorrenteController();
=======
            ContaCorrenteDAO ccDao = new ContaCorrenteDAO();
>>>>>>> 350088d9a295ea4249d4d128fb9fa3928f9c06fc
            ContaCorrente cc = new ContaCorrente() {
                Numero = int.Parse(TxtNumConta.Text),
                Senha = TxtSenha.Text
            };

<<<<<<< HEAD
            cc = ccController.Login(cc);
=======
            cc = ccDao.Login(cc);
>>>>>>> 350088d9a295ea4249d4d128fb9fa3928f9c06fc

            if (cc != null)
            {
                Session["contaCorrente"] = cc;
                Response.Redirect("~/Views/vwContaCorrente.aspx");
            }
            else
            {
               LblResultado.Text = "Dados Inválidos!";
            }
           
         }

     //   private Conta PesquisaPorNumero(int numero)
    //    {
     //       return new ContaCorrenteDAO().PesquisaPorNumero(numero);
      //  }

    }
}