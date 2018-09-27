using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class EmprestimoDAO
    {
        public bool InserirEmprestimo(Emprestimo emp)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("INSERT INTO Emprestimo(Emprestimo_valor,Emprestimo_parcelas, Taxa_Taxa_id, " +
                                "Conta_Corrente_Conta_Conta_Corrente_id, Emprestimo_Inicio) VALUES (@Emprestimo_valor," +
                                "@Emprestimo_parcelas, @Taxa_Taxa_id, @Conta_Corrente_Conta_Conta_Corrente_id, @Emprestimo_Inicio)");

                command.CommandText = sql;
                command.Parameters.AddWithValue("@Emprestimo_valor", emp.Valor);
                command.Parameters.AddWithValue("@Emprestimo_parcelas", emp.Parcelas);
                command.Parameters.AddWithValue("@Taxa_Taxa_id", emp.Taxa.Id);
                command.Parameters.AddWithValue("@Conta_Corrente_Conta_Conta_Corrente_id", emp.ContaCorrente.Numero);
                command.Parameters.AddWithValue("@Emprestimo_Inicio", emp.DataInicio);
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
                Console.WriteLine(e);
                return false;
            }
        }
    }
}