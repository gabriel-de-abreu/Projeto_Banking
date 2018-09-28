using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.Emprestimo.PagamentoDAOs
{
    public class PagamentoContaDAO
    {
        public PagamentoConta InserirPagamentoConta(PagamentoConta pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Pagamento_Conta` (`Pagamento_Pagamento_id`) VALUES (@id); ";
            command.Parameters.AddWithValue("@id", pagamento.Id);
            command.ExecuteNonQuery();
            return pagamento;
        }
    }
}