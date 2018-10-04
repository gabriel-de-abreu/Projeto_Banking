using MySql.Data.MySqlClient;
using Projeto_Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos.ContaObjetos
{
    public class GerenteDAO
    {
        public Gerente LoginGerente(Gerente gerente)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.gerente WHERE Gerente_login = @login AND Gerente_senha = @senha;";
            command.Parameters.AddWithValue("@login", gerente.Login);
            command.Parameters.AddWithValue("@senha", gerente.Senha);
            Gerente ge = null;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ge = new Gerente()
                {
                    Id = Convert.ToInt32(reader["Gerente_id"])
                };

            }
            reader.Close();

            return ge;

        }
    }
}