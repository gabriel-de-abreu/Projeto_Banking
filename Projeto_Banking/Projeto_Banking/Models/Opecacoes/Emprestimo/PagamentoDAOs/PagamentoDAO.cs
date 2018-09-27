using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.Emprestimo
{
    public class PagamentoDAO
    {
        public Pagamento Inserir(Pagamento pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Pagamento` (`Pagamento_id`, `Pagamento_data`, `Emprestimo_Emprestimo_id`, `Pagamento_Valor`)" +
                " VALUES (@data, @emprestimo_id,@valor);";
            command.Parameters.AddWithValue("@data", pagamento.Data);
            command.Parameters.AddWithValue("@emprestimo_id", pagamento.Id);
            command.Parameters.AddWithValue("@valor", pagamento.Valor);
            command.ExecuteNonQuery();
            pagamento.Id = Convert.ToInt32(command.LastInsertedId);
            return pagamento;
        }
    }
}