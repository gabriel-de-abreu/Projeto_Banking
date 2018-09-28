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
        public InvestimentoConta InserirInvestimento(Projeto_Banking.Objetos.Investimento investimento, ContaCorrente conta, double valor)
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
                return null;
            }
        }
    }
}