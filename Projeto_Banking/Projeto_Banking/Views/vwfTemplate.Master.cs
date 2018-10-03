using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;

namespace Projeto_Banking
{
    public partial class vwfTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contaCorrente"] == null && !HttpContext.Current.Request.Url.AbsolutePath.Equals("/Views/vwsLogin.aspx"))
                Response.Redirect("~/Views/vwsLogin.aspx");

            if (Session["contaCorrente"] != null)
            {
                aMeusEmprestimos.Visible = true;
                aMeusInvestimentos.Visible = true;
                lbEntrarSair.Text = "Sair";
                lbEntrarSair.Visible = true;
            }
            else
            {

                aMeusEmprestimos.Visible = false;
                aMeusInvestimentos.Visible = false;
                lbEntrarSair.Visible = false;

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
        protected void ConsultarEmprestimos(object sender, EventArgs e)
        {
            if (new EmprestimoDAO().PesquisarEmprestimosContaCorrente(Session["contaCorrente"] as ContaCorrente).Rows.Count > 0)
            {
                Response.Redirect("~/Views/vwsConsultarEmprestimos.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Você não tem nenhum empréstimo realizado ainda!');</script>");

            }
        }
        protected void MeusInvestimentos(object sender, EventArgs e)
        {
            if (new InvestimentoDAO().BuscarInvestimentosConta(Session["contaCorrente"] as ContaCorrente).Rows.Count > 0)
            {
                Response.Redirect("~/Views/vwsMeusInvestimentos.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Você não tem nenhum investimento realizado ainda!');</script>");

            }
        }
    }
}