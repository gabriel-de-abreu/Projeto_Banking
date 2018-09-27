using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.ContaDAOs
{
    public class ContaDAO
    {
        public Conta PesquisarContaPorNumero(int numero)
        {
            float saldo = 0;
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.conta WHERE Conta_id = @id;";
            command.Parameters.AddWithValue("@id", numero);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                saldo = float.Parse(reader["Conta_saldo"].ToString());
            }
            reader.Close();

            ContaCorrente cc = new ContaCorrenteDAO().PesquisarPorNumero(numero);
            if (cc != null)
            {
                cc.Saldo = saldo;
                return cc;
            }
            return null;
        }
    }
}