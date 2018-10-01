﻿using Projeto_Banking.Objetos;
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
            if (Session["contaCorrente"] != null)
            {
                if (!IsPostBack)
                {
                    ContaCorrente ccSession = Session["contaCorrente"] as ContaCorrente;
                    lblNumero.Text += ccSession.Numero.ToString(); //validar nome com objeto
                    lblSaldo.Text += ccSession.Saldo.ToString(); //validar nome com objeto
                    lblLimite.Text += ccSession.Limite.ToString();
                    lblTitular.Text += ccSession.Pessoa.Nome;
                }
            }
            else
            {
                Response.Redirect("~/Views/vwsLogin.aspx");
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
    }
}