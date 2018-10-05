using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using Projeto_Banking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views.Gerencial
{
    public partial class vwsCadastroConta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa()
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text
            };

            ContaCorrente cc = new ContaCorrente()
            {
                Limite = float.Parse(txtLimite.Text),
                Pessoa = p,
                Senha = txtSenha.Text
            };
            try
            {
                cc = new ContaCorrenteDAO().InserirContaCorrente(cc);

                if (cc != null)
                {
                    lblResultado.Text = "Cadastro de Cliente Realizado com Sucesso!";
                    lblResultado2.Text = "Numero da Conta: " + cc.Numero.ToString();
                }

            }
            catch
            {
                lblResultado.Text = "CPF Já Cadastrado em Nosso Sistema";
                lblResultado2.Text = "Favor Inserir um CPF Diferente";
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Gerencial/vwPrincipalGerente.aspx");
        }
    }
}