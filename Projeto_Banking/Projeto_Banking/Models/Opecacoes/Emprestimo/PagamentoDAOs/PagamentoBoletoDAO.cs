using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.Emprestimo.PagamentoDAOs
{
    public class PagamentoBoletoDAO
    {
        public PagamentoBoletoDAO InserirPagamentoBoleto(PagamentoBoleto pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Pagamento_Boleto` (`Pagamento_Pagamento_Boleto_id`, `Pagamento_Boleto_codigo`, `Pagamento_Boleto_vencimento`) " +
                "VALUES (@id, @boleto_cod,@vencimento);";
            command.Parameters.AddWithValue("@id",pagamento.Id);
            command.Parameters.AddWithValue("@boleto_cod", pagamento.Codigo);
            command.Parameters.AddWithValue("@vencimento", pagamento.Vencimento);
            command.ExecuteNonQuery();
            return null;
        }
    }
}