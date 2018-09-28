using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
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
        public ContaContabilEmprestimo PesquisarContaContabilEmprestimo(int numero)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "Select Conta_Conta_Contabil_Emprestimo_id FROM conta_contabil_emprestimo WHERE Conta_Conta_Contabil_Emprestimo_id " +
                "= @numero";
            command.Parameters.AddWithValue("@numero", numero);
            var reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            reader.Close();
            return count > 0 ? new ContaContabilEmprestimo() : null;
        }

    }
}