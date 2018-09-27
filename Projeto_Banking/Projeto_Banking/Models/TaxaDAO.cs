using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class TaxaDAO
    {
        public Taxa PesquisarPorTaxa(int id)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM taxa WHERE Taxa_id  = @id";
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();
            Taxa t = null;
            if (reader.HasRows)
            {
                reader.Read();
                t = new Taxa();
                t.Id = id;
                t.Nome = reader["Taxa_nome"].ToString();
                t.Valor = Convert.ToInt32(reader["Taxa_valor"]);
            }
            reader.Close();
            return t;
        }
    }
}