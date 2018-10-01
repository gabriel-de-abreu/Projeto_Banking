using MySql.Data.MySqlClient;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
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
                        " Investimento_Conta_Valor)  VALUES (@Investimento_Investimento_id, @Conta_Corrente_Conta_Conta_Corrente_id," +
                        " @Investimento_Conta_valor)");

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Investimento_Investimento_id", investimentoConta.Investimento.Id);
                    command.Parameters.AddWithValue("@Conta_Corrente_Conta_Conta_Corrente_id", investimentoConta.Conta.Numero);
                    command.Parameters.AddWithValue("@Investimento_Conta_valor", investimentoConta.Valor);

                    int retorno = command.ExecuteNonQuery();


                    if (retorno > 0)
                    {
                        if (new ContaDAO().Transferir(investimentoConta.Conta, new ContaDAO().PesquisarContaPorNumero(1), (float)investimentoConta.Valor, "Realização de investimento") != null)
                            //Caso esteja tudo certo com a operação de inserção de investimento, o mesmo é sensibilizado na Conta Contábil de investimentos
                            return investimentoConta;
                    }
                }

                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public Investimento BuscarInvestimentoPorId(int id)
        {

            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = "SELECT * FROM Investimento WHERE Investimento_id= @Investimento_id;";

                command.CommandText = sql;
                command.Parameters.AddWithValue("@Investimento_id", id);

                var reader = command.ExecuteReader();
                Investimento investimento = null;

                int taxaId = -1;
                while (reader.Read())
                {
                    investimento = new Investimento()
                    {
                        Id = int.Parse(reader["Investimento_id"].ToString()),
                        Nome = reader["Investimento_nome"].ToString(),
                        //  investimento.PreFixada = reader["Investimento_nome"].ToString();
                        Rentabilidade = double.Parse(reader["Investimento_rentabilidade"].ToString()),
                        //investimento.DataInicio = DateTime.Parse(reader["Investimento_Inicio"].ToString());
                        //investimento.DataFim = DateTime.Parse(reader["Investimento_Fim"].ToString());
                    };
                    taxaId = int.Parse(reader["Taxa_Taxa_id"].ToString());
                }
                reader.Close();
                investimento.Taxa = new TaxaDAO().PesquisarPorTaxa(taxaId);

                return investimento;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        //public List<Investimento> PopularDropMenu()
        //{
        //    MySqlCommand command = Connection.Instance.CreateCommand();
        //    command.CommandText = "SELECT * FROM investimento";
        //    var reader = command.ExecuteReader();
        //    List<Investimento> lInvestimento = new List<Opera;
        //    while ()
        //}
    }
}