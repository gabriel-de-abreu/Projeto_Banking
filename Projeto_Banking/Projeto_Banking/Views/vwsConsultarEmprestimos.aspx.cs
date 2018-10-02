using Projeto_Banking.Models;
using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsConsultarEmprestimos : System.Web.UI.Page
    {
        ContaCorrente cc;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;

            if (cc == null) Response.Redirect("~/Views/vwsLogin.aspx");
            if (new EmprestimoDAO().PesquisarEmprestimosContaCorrente(cc).Rows.Count > 0)
            {
                PopularGrid();
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Você não tem nenhum empréstimo realizado ainda!');</script>");
                
            }
            
        }

        public void PopularGrid()
        {
            EmprestimoDAO empDao = new EmprestimoDAO();
            DataTable dTable = empDao.PesquisarEmprestimosContaCorrenteComTaxa(cc);


            dTable.Columns.Add("Pagamento_tipo", typeof(String));
            dTable.Columns.Add("Emprestimo_Inicio_Formatado", typeof(String));

            PagamentoDAO pagDAO = new PagamentoDAO();

            foreach (DataRow row in dTable.Rows) {
                row["Pagamento_tipo"] = pagDAO.TipoPagamentoEmprestimo(new Emprestimo() { Id = Convert.ToInt32(row["Emprestimo_id"].ToString()) });
                DateTime data = Convert.ToDateTime(row["Emprestimo_Inicio"]);
                row["Emprestimo_Inicio_Formatado"] = data.ToString("dd/MM/yyyy");
            }
            
            gdvEmprestimos.DataSource = dTable;
            gdvEmprestimos.DataBind();
        }

        protected void gdvEmprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Ver"))
            {
                EmprestimoDAO empDao = new EmprestimoDAO();
                Session["emprestimo"] = empDao.PesquisarEmprestimoPorId(Convert.ToInt32(e.CommandArgument.ToString()));

                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Label lblPagamento = (Label)clickedRow.FindControl("lblPagamento");

                if (lblPagamento.Text.Equals("Débito em Conta")){
                    Session["tipoPagamento"] = "Débito em Conta";
                    Response.Redirect("~/Views/vwsVisualizarPagamentoEmprestimo.aspx");

                }else if (lblPagamento.Text.Equals("Boleto"))
                {
                    Session["tipoPagamento"] = "Boleto";
                    Response.Redirect("~/Views/vwsVisualizarPagamentoEmprestimo.aspx");
                }
            }
        }
    }
}