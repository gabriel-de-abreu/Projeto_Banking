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
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                command.CommandText = "SELECT * FROM taxa WHERE Taxa_id  = @id";
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();
                Taxa t = new Taxa();
                while (reader.Read())
                {
                    t = new Taxa();
                    t.Id = id;
                    t.Valor = Convert.ToInt32(reader["Taxa_valor"]);
                }
                reader.Close();
                return t;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public List<Taxa> BuscarTodasTaxas()
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM taxa";
            var reader = command.ExecuteReader();
            List<Taxa> lTaxa = new List<Taxa>();
            while (reader.Read())
            {
                Taxa taxa = new Taxa()
                {
                    Id = int.Parse(reader["Taxa_id"].ToString()),
                    Nome = reader["Taxa_nome"].ToString(),
                    Valor = double.Parse(reader["Taxa_valor"].ToString())

                };
                lTaxa.Add(taxa);
            }
            reader.Close();
            
            return lTaxa;
        }
    }
}