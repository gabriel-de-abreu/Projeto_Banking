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
            ContaCorrente cc = Session["contaCorrente"] as ContaCorrente;
            if (cc == null) Response.Redirect("~/Views/vwsLogin.aspx");
            emp = Session["emprestimo"] as Emprestimo;

            divPagBoleto.Visible = false;
            divPagDebito.Visible = false;
            if (!IsPostBack)
            {
                if (Session["tipoPagamento"].Equals("Débito em Conta"))
                {
                    divPagBoleto.Visible = false;
                    divPagDebito.Visible = true;
                    PopularGridDebito();

                }
                else if (Session["tipoPagamento"].Equals("Boleto"))
                {
                    divPagBoleto.Visible = true;
                    divPagDebito.Visible = false;
                    PopularGridBoleto();

                }
            }

        }

        public void PopularGridDebito()
        {
            PagamentoDAO pagDao = new PagamentoDAO();
            DataTable dTable = pagDao.BuscarPagamentosPorIdDoEmprestimo(emp.Id);
            dTable.Columns.Add("StatusPagamento", typeof(String));
            dTable.Columns.Add("NumeroParcela", typeof(int));
            dTable.Columns.Add("Pagamento_data_Formatado", typeof(String));

            int i = 1;

            foreach (DataRow row in dTable.Rows)
            {
                row["NumeroParcela"] = i++; //gera o indice do numero de parcela

                DateTime data = Convert.ToDateTime(row["Pagamento_data"]);  //formatada a data retirando a hora
                row["Pagamento_data_Formatado"] = data.ToString("dd/MM/yyyy");

                if (int.Parse(row["Pagamento_Pago"].ToString()) == 1) //se for 1 no banco, atribui como pago
                {
                    row["StatusPagamento"] = "Pago";
                }
                else if (int.Parse(row["Pagamento_Pago"].ToString()) == 0) //se for 0 no banco, atribui como não pago
                {
                    row["StatusPagamento"] = "Não Pago";
                }
            }

            gdvPagamentosDebito.DataSource = dTable;
            gdvPagamentosDebito.DataBind();
        }

        public void PopularGridBoleto()
        {
            PagamentoDAO pagDao = new PagamentoDAO();
            DataTable dTable = pagDao.BuscarPagamentosPorIdDoEmprestimo(emp.Id);
            dTable.Columns.Add("StatusPagamento", typeof(String));
            dTable.Columns.Add("NumeroParcela", typeof(int));
            dTable.Columns.Add("Pagamento_data_Formatado", typeof(String));

            int i = 1;

            foreach (DataRow row in dTable.Rows)
            {
                row["NumeroParcela"] = i++; //gera o indice do numero de parcela

                DateTime data = Convert.ToDateTime(row["Pagamento_data"]);
                row["Pagamento_data_Formatado"] = data.ToString("dd/MM/yyyy");

                if (int.Parse(row["Pagamento_Pago"].ToString()) == 1) //se for 1 no banco, atribui como pago
                {
                    row["StatusPagamento"] = "Pago";
                }
                else if (int.Parse(row["Pagamento_Pago"].ToString()) == 0) //se for 0 no banco, atribui como não pago
                {
                    row["StatusPagamento"] = "Não Pago";
                }
            }

            gdvPagamentosBoleto.DataSource = dTable;
            gdvPagamentosBoleto.DataBind();
        }


    }
}