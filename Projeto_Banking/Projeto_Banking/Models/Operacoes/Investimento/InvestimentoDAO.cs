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
        public InvestimentoConta InserirInvestimento(Investimento investimento, ContaCorrente conta, double valor)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("INSERT INTO Investimento_Conta (Investimento_Investimento_id, Conta_Corrente_Conta_Conta_Corrente_id," +
                    " Investimento_Conta_Valor)  VALUES (@Investimento_Investimento_id, @Conta_Corrente_Conta_Conta_Corrente_id," +
                    " @Investimento_Conta_valor)");

                command.CommandText = sql;
                command.Parameters.AddWithValue("@Investimento_Investimento_id", investimento.Id);
                command.Parameters.AddWithValue("@Conta_Corrente_Conta_Conta_Corrente_id", conta.Numero);
                command.Parameters.AddWithValue("@Investimento_Conta_valor", valor);

                if (conta.Saldo > valor) // Necessário ter saldo suficiente para investir
                {
                    //Antes de criar o investimento no banco de dados, é necessário verificar na conta contábil se a operação
                    //é valida.

                    // if (ContaContabilInvestimento.VerificaInvestimento(valor)) { 

                    int retorno = command.ExecuteNonQuery();

                    if (retorno > 0)
                    {
                        InvestimentoConta investimentoConta = new InvestimentoConta()
                        {
                            Conta = conta,
                            Investimento = investimento,
                            Valor = valor
                        };
                        //Caso esteja tudo certo com a operação de inserção de investimento, o mesmo é sensibilizado na Conta Contábil de investimentos
                        // ContaContabilInvestimento.SensibilizaInvestimento(investimentoConta);
                        return investimentoConta;
                    }
                }
                // }
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