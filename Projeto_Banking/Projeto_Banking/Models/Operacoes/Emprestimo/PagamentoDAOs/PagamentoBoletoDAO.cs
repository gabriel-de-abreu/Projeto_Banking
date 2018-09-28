using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.Emprestimo.PagamentoDAOs
{
    public class PagamentoBoletoDAO
    {
        public PagamentoBoleto InserirPagamentoBoleto(PagamentoBoleto pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Pagamento_Boleto` (`Pagamento_Pagamento_Boleto_id`, `Pagamento_Boleto_codigo`, `Pagamento_Boleto_vencimento`) " +
                "VALUES (@id, @boleto_cod,@vencimento);";
            command.Parameters.AddWithValue("@id",pagamento.Id);
            command.Parameters.AddWithValue("@boleto_cod", pagamento.Codigo);
            command.Parameters.AddWithValue("@vencimento", pagamento.Vencimento);
            command.ExecuteNonQuery();
            return pagamento;
        }

        public DataTable BuscarPagamentosBoletos(int numPagamento)
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT Pagamento_Boleto_codigo " +
                                                                "FROM projetobanking.pagamento_boleto, pagamento " +
                                                                "WHERE Pagamento_Pagamento_Boleto_id = " +
                                                                    "(SELECT pagamento.Pagamento_id FROM emprestimo, pagamento" +
                                                                        " WHERE Pagamento_id  = @pagamento.Emprestimo_Emprestimo_id);", Connection.Instance);

                sqlData.SelectCommand.Parameters.AddWithValue("@pagamento.Emprestimo_Emprestimo_id", numPagamento);

                sqlData.Fill(table);

                return table;

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

}