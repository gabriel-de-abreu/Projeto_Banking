using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class PessoaDAO
    {
        public Pessoa PesquisaPessoaPorId(int id)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.pessoa WHERE Pessoa_id = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            Pessoa p = null;
            if (reader.HasRows)
            {
                reader.Read();
                p = new Pessoa();
                p.Cpf = reader["Pessoa_cpf"].ToString();
                p.Id = id;
                p.Nome = reader["Pessoa_nome"].ToString();
            }
            return p;
        }
    }
}