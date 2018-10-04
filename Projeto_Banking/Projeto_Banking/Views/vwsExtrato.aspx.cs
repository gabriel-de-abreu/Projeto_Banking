using Projeto_Banking.Models;
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
    public partial class vwsExtrato : System.Web.UI.Page
    {
        ContaCorrente cc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contaCorrente"] != null)
            {
                cc = Session["contaCorrente"] as ContaCorrente;
                PopularGrid();
            }
            else
            {
                Response.Redirect("~/Views/vwsLogin.aspx");
            }
        }

        public void PopularGrid()
        {
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            DataTable dTable = movDao.BuscarExtratosConta(cc.Numero);

            dTable.Columns.Add("Movimentacao_data_formatado", typeof(String));
            dTable.Columns.Add("Movimentacao_valor_formatado", typeof(String));

            foreach (DataRow row in dTable.Rows)
            {
                //formatada a data retirando a hora
                row["Movimentacao_data_formatado"] = Convert.ToDateTime(row["Movimentacao_data"]).ToString("dd/MM/yyyy");
                row["Movimentacao_valor_formatado"] = Convert.ToDouble(row["Movimentacao_valor"]).ToString("c2"); //formata o valor para moeda real

                if (row["Movimentacao_descricao"].Equals("Transferência entre contas"))
                {
                    //caso for a conta do cliente significa que ele fez a transferencia
                    if (row["Conta_Movimentacao_origem_id"].Equals(cc.Numero)){     
                        row["Movimentacao_descricao"] = "Transferência para conta " + row["Conta_Movimetacao_destino"];
                        row["Movimentacao_valor_formatado"] = "- "+row["Movimentacao_valor_formatado"]; //formata p/ simbolizar debito
                    }
                    //caso não for a conta do cliente significa que recebeu a transferencia
                    else
                    {
                        row["Movimentacao_descricao"] = "Transferência de conta " + row["Conta_Movimentacao_origem_id"];
                        row["Movimentacao_valor_formatado"] = "+ "+row["Movimentacao_valor_formatado"]; //formata p/ simbolizar credito
                    }

                }else if(row["Movimentacao_descricao"].Equals("Realização de investimento"))
                {
                    row["Movimentacao_valor_formatado"] = "- " + row["Movimentacao_valor_formatado"]; //formata p/ simbolizar debito

                } else if(row["Movimentacao_descricao"].Equals("Realização de empréstimo"))
                {
                    row["Movimentacao_valor_formatado"] = "+ " + row["Movimentacao_valor_formatado"]; //formata p/ simbolizar credito

                } else if(row["Movimentacao_descricao"].Equals("Resgate de investimento"))
                {
                    row["Movimentacao_valor_formatado"] = "+ " + row["Movimentacao_valor_formatado"]; //formata p/ simbolizar credito
                }
            }

            gdvExtrato.DataSource = dTable;
            gdvExtrato.DataBind();
        }

    }
}