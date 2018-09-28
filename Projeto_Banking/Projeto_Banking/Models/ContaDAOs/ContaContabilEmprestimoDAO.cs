using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.ContaDAOs
{
    public class ContaContabilEmprestimoDAO
    {
        public bool AtualizarContaContabilEmprestimo(Double ValorEmprestimo)
        {

            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("Update conta " +
                              "SET Conta_saldo = @valorEmprestimo " +
                              "WHERE Conta_id = (Select Conta_Conta_Contabil_Emprestimo_id " +
                                                "FROM conta_contabil_emprestimo); ");

                command.CommandText = sql;
                command.Parameters.AddWithValue("@valorEmprestimo", ValorEmprestimo);

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
        public float BuscarSaldoContaContabilEmprestimo()
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("SELECT Conta_saldo " +
                              "FROM conta_contabil_emprestimo, conta " +
                              "WHERE Conta_Conta_Contabil_Emprestimo_id = Conta_id;");

                command.CommandText = sql;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return float.Parse(reader["Conta_saldo"].ToString());
                }
                return -1;
                           }
            catch (Exception e)
            {
                throw e;
            }

        }

    }   
}