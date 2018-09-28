using MySql.Data.MySqlClient;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Operacoes.Investimento
{
    public class InvestimentoDAO
    {
        public InvestimentoConta InserirInvestimento(InvestimentoConta investimentoConta)
        {
            try
            {
                if (investimentoConta.Conta.Saldo > investimentoConta.Valor) // Necessário ter saldo suficiente para investir
                {

                    MySqlCommand command = Connection.Instance.CreateCommand();
                    string sql = ("INSERT INTO Investimento_Conta (Investimento_Investimento_id, Conta_Corrente_Conta_Conta_Corrente_id," +
                        " Investimento_Conta_Valor, Investimento_Inicio, Investimento_Fim)  VALUES (@Investimento_Investimento_id, " +
                        "@Conta_Corrente_Conta_Conta_Corrente_id, @Investimento_Conta_valor, @Investimento_Inicio, @Investimento_Fim)");

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Investimento_Investimento_id", investimentoConta.Investimento.Id);
                    command.Parameters.AddWithValue("@Conta_Corrente_Conta_Conta_Corrente_id", investimentoConta.Conta.Numero);
                    command.Parameters.AddWithValue("@Investimento_Conta_valor", investimentoConta.Valor);
                    command.Parameters.AddWithValue("@Investimento_Inicio", investimentoConta.DataInicio);
                    command.Parameters.AddWithValue("@Investimento_Fim", investimentoConta.DataFim);

                    int retorno = command.ExecuteNonQuery();

                    if (retorno > 0)
                    {
                        new ContaDAO().Transferir(investimentoConta.Conta, new ContaDAO().PesquisarContaPorNumero(1),  (float)investimentoConta.Valor, "Realização de investimento");
                        return investimentoConta;
                    }
                }
                // }
                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Projeto_Banking.Objetos.Investimento BuscarInvestimentoPorId(int id)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = "SELECT * FROM projetobanking.investimento WHERE Investimento_id= @Investimento_id;";

                command.CommandText = sql;
                command.Parameters.AddWithValue("@Investimento_id", id);

                var reader = command.ExecuteReader();
                Investimento investimento = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    investimento.Id = int.Parse(reader["Investimento_id"].ToString());
                    investimento.Nome = reader["Investimento_nome"].ToString();
                    //  investimento.PreFixada = reader["Investimento_nome"].ToString();
                    investimento.Rentabilidade = double.Parse(reader["Investimento_rentabilidade"].ToString());
                    investimento.Taxa = new TaxaDAO().PesquisarPorTaxa(int.Parse(reader["Taxa_Taxa_id"].ToString()));
                }
                reader.Close();
                return investimento;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}