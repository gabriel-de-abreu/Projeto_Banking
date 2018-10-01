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
            command.Parameters.AddWithValue("@id", pagamento.Id);
            command.Parameters.AddWithValue("@boleto_cod", pagamento.Codigo);
            command.Parameters.AddWithValue("@vencimento", pagamento.Vencimento);
            command.ExecuteNonQuery();
            return pagamento;
        }

        public PagamentoBoleto BuscarPagamentoBoletoPorId(int id)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.pagamento_boleto" +
                " WHERE Pagamento_Pagamento_Boleto_id = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            PagamentoBoleto boleto = null;
            while (reader.Read())
            {
                boleto = new PagamentoBoleto()
                {
                    Codigo = Convert.ToInt32(reader["Pagamento_Boleto_codigo"]),
                    Vencimento = Convert.ToDateTime(reader["Pagamento_Boleto_vencimento"]),
                };
            }
            reader.Close();
            return boleto;
        }

    }

}