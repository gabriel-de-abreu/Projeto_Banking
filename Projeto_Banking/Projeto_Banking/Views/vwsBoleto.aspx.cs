using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PagamentoBoleto pagamentoBoleto = new PagamentoDAO().BuscarPagamentoPorId(Convert.ToInt32(Session["Pag_Boleto_id"])) as PagamentoBoleto;
            lblCodBarras.Text = pagamentoBoleto.Codigo.ToString();
            lblConta.Text = pagamentoBoleto.Emprestimo.ContaCorrente.Numero.ToString();
            lblEmpCod.Text = pagamentoBoleto.Emprestimo.Id.ToString();
            lblPago.Text = (pagamentoBoleto.Pago ? "Sim" : "Não");
            lblValor.Text = pagamentoBoleto.Valor.ToString("c2");
            lblVencimento.Text = pagamentoBoleto.Vencimento.ToString("dd/MM/yyyy");
            lblCliente.Text = pagamentoBoleto.Emprestimo.ContaCorrente.Pessoa.Nome;
            lblClienteCPF.Text = pagamentoBoleto.Emprestimo.ContaCorrente.Pessoa.Cpf;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsVisualizarPagamentoEmprestimo.aspx");
        }
    }
}