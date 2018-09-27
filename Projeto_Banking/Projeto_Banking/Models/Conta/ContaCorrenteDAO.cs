using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Conta
{
    public class ContaCorrenteDAO
    {
        public ContaCorrente Login(ContaCorrente cc)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.conta_corrente WHERE Conta_Conta_Corrente ;";
            return null;

        }
    }
}