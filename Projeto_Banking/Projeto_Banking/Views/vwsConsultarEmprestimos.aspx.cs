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
            
            PopularGrid();
        }

        public void PopularGrid()
        {
            EmprestimoDAO empDao = new EmprestimoDAO();
            DataTable dTable = empDao.PesquisarEmprestimosContaCorrenteComTaxa(cc);


            dTable.Columns.Add("Pagamento_tipo", typeof(String));

            PagamentoDAO pagDAO = new PagamentoDAO();
            int i = 0;
            foreach (DataRow row in dTable.Rows) {
               row["Pagamento_tipo"] = pagDAO.TipoPagamentoEmprestimo(new Emprestimo() { Id = Convert.ToInt32(row["Emprestimo_id"].ToString()) });

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
                Response.Redirect("~/Views/vwsVisualizarEmprestimo.aspx");
            }
        }
    }
}