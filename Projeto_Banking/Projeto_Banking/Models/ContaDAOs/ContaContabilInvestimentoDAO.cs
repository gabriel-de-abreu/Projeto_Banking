using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.ContaDAOs
{
    public class ContaContabilInvestimentoDAO
    {
        public bool AtualizarContaContabilInvestimento(Double ValorInvestimento)
        {

            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("Update conta " +
                              "SET Conta_saldo = @valorInvestimento " +
                              "WHERE Conta_id = (Select Conta_Conta_Contabil_Investimento_id " +
                                                "FROM Conta_Contabil_Investimento); ");

                command.CommandText = sql;
                command.Parameters.AddWithValue("@valorInvestimento", ValorInvestimento);

                int retorno = command.ExecuteNonQuery();
                if (retorno > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }

        }
        public float BuscarSaldoContaContabilInvestimento()
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("SELECT Conta_saldo " +
                              "FROM conta_contabil_investimento, conta " +
                              "WHERE Conta_Conta_Contabil_Investimento_id = Conta_id;");

                command.CommandText = sql;
                MySqlDataReader reader = command.ExecuteReader();
                float saldo = -1;
                while (reader.Read())
                {
                    saldo = float.Parse(reader["Conta_saldo"].ToString());
                }
                reader.Close();
                return saldo;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ContaContabilInvestimento PesquisarContaContabilInvestimento(int numero)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "Select Conta_Conta_Contabil_Investimento_id FROM conta_contabil_investimento WHERE Conta_Conta_Contabil_Investimento_id " +
                "= @numero";
            command.Parameters.AddWithValue("@numero", numero);
            var reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            reader.Close();
            return count > 0 ? new ContaContabilInvestimento() : null;
        }

    }
}
