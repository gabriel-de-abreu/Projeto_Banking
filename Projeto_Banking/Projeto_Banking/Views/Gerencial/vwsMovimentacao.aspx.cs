using Projeto_Banking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views.Gerencial
{
    public partial class vwsMovimentacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["gerente"] != null && (bool)Session["gerente"])
            {
                PopularGrid(DateTime.Today.AddYears(-1), DateTime.Today); //lista 1 ano por padrao
            }
            else
            {
                Response.Redirect("~/Views/Gerencial/vwLoginGerente.aspx");
            }
        }

        public void PopularGrid(DateTime inicio, DateTime fim)
        {
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            DataTable dTable = movDao.ListarPorIntervaloDeData(inicio, fim);

            dTable.Columns.Add("Movimentacao_data_formatado", typeof(String));
            dTable.Columns.Add("Movimentacao_valor_formatado", typeof(String));

            foreach (DataRow row in dTable.Rows)
            {
                //formatada a data retirando a hora
                row["Movimentacao_data_formatado"] = Convert.ToDateTime(row["Movimentacao_data"]).ToString("dd/MM/yyyy");
                row["Movimentacao_valor_formatado"] = Convert.ToDouble(row["Movimentacao_valor"]).ToString("c2"); //formata o valor para moeda real

            }

            gdvMovimentacao.DataSource = dTable;
            gdvMovimentacao.DataBind();
        }

        protected void btnSemana_Click(object sender, EventArgs e)
        {
            PopularGrid(DateTime.Today.AddDays(-7), DateTime.Today);
        }

        protected void btnMes_Click(object sender, EventArgs e)
        {
            PopularGrid(DateTime.Today.AddMonths(-1), DateTime.Today);
        }

        protected void btnAno_Click(object sender, EventArgs e)
        {
            PopularGrid(DateTime.Today.AddYears(-1), DateTime.Today);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime inicio, fim;

            if (DateTime.TryParse(txtInicio.Text, out inicio) && DateTime.TryParse(txtFim.Text, out fim))
            {
                if (DateTime.Today < inicio || fim < inicio)
                {
                    lblAviso.Text = "Período inválido!";
                }
                else if (fim > DateTime.Today)
                {
                    lblAviso.Text = "";
                    PopularGrid(inicio, fim);
                }
                else
                {
                    lblAviso.Text = "";
                    PopularGrid(inicio, fim);
                }
            }
        }
    }
}