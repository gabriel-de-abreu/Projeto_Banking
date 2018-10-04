using MySql.Data.MySqlClient;
using Projeto_Banking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class GerenteDAO
    {
        public Boolean Login(String login, String senha)
        {
            //SELECT * FROM projetobanking.gerente  WHERE Gerente_login = @login AND Gerente_senha = @senha
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.gerente  WHERE Gerente_login = @login AND Gerente_senha = @senha;";
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@senha", Criptografia.GerarHashMd5(senha));
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            return false;
        }
    }
}