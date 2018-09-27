﻿using Projeto_Banking.Controllers;
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
            ContaCorrenteController ccController = new ContaCorrenteController();
            ContaCorrente cc = new ContaCorrente() {
                Numero = int.Parse(TxtNumConta.Text),
                Senha = TxtSenha.Text
            };

            cc = ccController.Login(cc);

            if (cc != null)
            {
                Session["contaCorrente"] = cc;
                Response.Redirect("~/vwContaCorrente.aspx");
            }
            else
            {
               LblResultado.Text = "Dados Inválidos!";
            }
           
         }
    }
}