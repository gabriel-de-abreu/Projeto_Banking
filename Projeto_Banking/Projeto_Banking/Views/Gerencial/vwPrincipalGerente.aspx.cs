using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Projeto_Banking.Views.Gerencial
{
    public partial class PrincipalGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean isActive = Convert.ToBoolean(Session["gerente"]);
            if (!isActive || Session["gerente"] == null)
            {
                Response.Redirect("~/Views/Gerencial/vwLoginGerente.aspx.cs");
            }
            LoadLastMovs();
            CarregaSaldos();
        }

        protected void btnCadastroConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Gerencial/vwsCadastroConta.aspx");
        }

        protected void btnConsultarMovimentacoes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Gerencial/vwsMovimentacao.aspx");
        }
        private void CarregaSaldos()
        {
            lblSaldEmprestimo.Text = new ContaContabilEmprestimoDAO().BuscarSaldoContaContabilEmprestimo().ToString("c2");
            lblSaldoInvestimentos.Text = new ContaContabilInvestimentoDAO().BuscarSaldoContaContabilInvestimento().ToString("c2");
        }
        private void LoadLastMovs()
        {
            List<Movimentacao> movimentacoes = new MovimentacaoDAO().Buscar5Ultimas();
            foreach (Movimentacao mov in movimentacoes)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                td.InnerText = mov.Origem.Numero.ToString();
                if (td.InnerText.Equals("1"))
                {
                    td.InnerText = "Contábil Investimentos";
                }
                if (td.InnerText.Equals("2"))
                {
                    td.InnerText = "Contábil Empréstimos";
                }
                tr.Controls.Add(td);

                td = new HtmlTableCell();
                td.InnerText = mov.Destino.Numero.ToString();
                if (td.InnerText.Equals("1"))
                {
                    td.InnerText = "Contábil Investimentos";
                }
                if (td.InnerText.Equals("2"))
                {
                    td.InnerText = "Contábil Empréstimos";
                }
                tr.Controls.Add(td);

                td = new HtmlTableCell();
                td.InnerText = mov.Descricao;
                tr.Controls.Add(td);

                td = new HtmlTableCell();
                td.InnerText = mov.Valor.ToString("c2");
                tr.Controls.Add(td);

                ultimasMovimentacoes.Rows.Add(tr);
            }
        }
    }
}
