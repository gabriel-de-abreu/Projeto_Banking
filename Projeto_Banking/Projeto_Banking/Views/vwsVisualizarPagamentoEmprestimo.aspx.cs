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
    public partial class vwsVisualizarEmprestimo : System.Web.UI.Page
    {
        Emprestimo emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = Session["emprestimo"] as Emprestimo;
            PopularGrid();
        }

        public void PopularGrid()
        {
            PagamentoDAO pagDao = new PagamentoDAO();
            DataTable dTable = pagDao.BuscarPagamentosPorIdDoEmprestimo(emp.Id);
            dTable.Columns.Add("TipoPagamento", typeof(String));

            foreach (DataRow row in dTable.Rows)
            {   
                if(int.Parse(row["Pagamento_Pago"].ToString()) == 1)
                {
                    row["TipoPagamento"] = "Pago";
                }
                else if(int.Parse(row["Pagamento_Pago"].ToString()) == 0)
                {
                    row["TipoPagamento"] = "Não Pago";
                }
            }

            gdvPagamentosDebito.DataSource = dTable;
            gdvPagamentosDebito.DataBind();
        }


    }
}