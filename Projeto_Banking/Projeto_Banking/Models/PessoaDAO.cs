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
            if (reader.Read())
            {
                reader.Read();
                p = new Pessoa();
                p.Cpf = reader["Pessoa_cpf"].ToString();
                p.Id = id;
                p.Nome = reader["Pessoa_nome"].ToString();
            }
            reader.Close();
            return p;
        }

        public Pessoa PesquisaPessoaPorCPF(String cpf)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.pessoa WHERE Pessoa_cpf = @cpf;";
            command.Parameters.AddWithValue("@cpf", cpf);
            var reader = command.ExecuteReader();
            Pessoa p = null;
            if (reader.Read())
            {
                p = new Pessoa();
                p.Id = Convert.ToInt32(reader["Pessoa_id"]);
                p.Cpf = cpf;
                p.Nome = reader["Pessoa_nome"].ToString();
            }
            reader.Close();
            return p;
        }
    }
}