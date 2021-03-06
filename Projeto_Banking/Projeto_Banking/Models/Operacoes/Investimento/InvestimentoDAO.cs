﻿using MySql.Data.MySqlClient;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Models.Operacoes.Investimento;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class InvestimentoDAO
    {

        public DataTable MostrarInvestimentos()
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            string sql = "SELECT * FROM investimento i INNER JOIN taxa t ON i.Taxa_Taxa_id = t.Taxa_id";

            MySqlDataAdapter mAdpater = new MySqlDataAdapter(sql, Connection.Instance);
            DataTable table = new DataTable();
            mAdpater.Fill(table);
            return table;

        }
        public InvestimentoConta InserirInvestimento(InvestimentoConta investimentoConta)
        {
            try
            {
                if (investimentoConta.Conta.Saldo > investimentoConta.Valor) // Necessário ter saldo suficiente para investir
                {
                    MySqlCommand command = Connection.Instance.CreateCommand();
                    string sql = ("INSERT INTO Investimento_Conta (Investimento_Investimento_id, Conta_Corrente_Conta_Conta_Corrente_id," +
                        " Investimento_Conta_Valor, Investimento_Inicio, Investimento_Fim)  VALUES (@Investimento_Investimento_id, @Conta_Corrente_Conta_Conta_Corrente_id," +
                        " @Investimento_Conta_valor, @Investimento_Inicio, @Investimento_Fim)");

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Investimento_Investimento_id", investimentoConta.Investimento.Id);
                    command.Parameters.AddWithValue("@Conta_Corrente_Conta_Conta_Corrente_id", investimentoConta.Conta.Numero);
                    command.Parameters.AddWithValue("@Investimento_Conta_valor", investimentoConta.Valor);
                    command.Parameters.AddWithValue("@Investimento_Inicio", investimentoConta.DataInicio);
                    command.Parameters.AddWithValue("@Investimento_Fim", investimentoConta.DataFim);

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
                        Rentabilidade = double.Parse(reader["Investimento_rentabilidade"].ToString()),

                    };
                    taxaId = int.Parse(reader["Taxa_Taxa_id"].ToString());
                }
                reader.Close();
                investimento.Taxa = new TaxaDAO().PesquisarPorTaxa(taxaId);
                if (investimento.Rentabilidade > 0) investimento.PreFixada = true;

                return investimento;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public float Resgate(InvestimentoConta investimentoConta, DateTime dataResgate)
        {
            var valor = InvestimentoOPS.Resgate(investimentoConta, dataResgate);
            if (new ContaDAO().Transferir(new ContaDAO().PesquisarContaPorNumero(1),
                investimentoConta.Conta, (float)valor, "Resgate de investimento") != null)
                if (AtualizaInvestimentoConta(investimentoConta, dataResgate, (float)valor) != null)
                    return (float)valor;

            return -1;

        }
        public float SimulaResgate(InvestimentoConta investimentoConta, DateTime dataResgate)
        {
            return (float)InvestimentoOPS.Resgate(investimentoConta, dataResgate);
        }

        public List<Investimento> BuscarTodosInvestimentos()
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM investimento";
            var reader = command.ExecuteReader();
            List<Investimento> lInvestimento = new List<Investimento>();
            while (reader.Read())
            {
                Investimento investimento = new Investimento()
                {
                    Id = int.Parse(reader["Investimento_id"].ToString()),
                    Nome = reader["Investimento_nome"].ToString(),
                    Rentabilidade = double.Parse(reader["Investimento_rentabilidade"].ToString()),
                    Taxa = new Taxa()
                    {
                        Id = int.Parse(reader["Taxa_Taxa_id"].ToString())
                    }

                };
                lInvestimento.Add(investimento);
            }
            reader.Close();
            foreach (Investimento investimento in lInvestimento)
            {
                investimento.Taxa = new TaxaDAO().PesquisarPorTaxa(investimento.Taxa.Id);
            }
            return lInvestimento;
        }

        public DataTable BuscarInvestimentosConta(ContaCorrente conta)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            string sql = $"SELECT * FROM Investimento_Conta WHERE Conta_Corrente_Conta_Conta_Corrente_id={conta.Numero};";

            MySqlDataAdapter mAdpater = new MySqlDataAdapter(sql, Connection.Instance);
            DataTable table = new DataTable();
            mAdpater.Fill(table);
            return table;

        }

        public InvestimentoConta BuscarInvestimento(InvestimentoConta investimentoConta)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM Investimento_Conta WHERE Investimento_Conta_Id=@Investimento_Conta_Id;";
            command.Parameters.AddWithValue("@Investimento_Conta_Id", investimentoConta.Id);

            var reader = command.ExecuteReader();
            int contaId = -1, investimentoId = -1;
            InvestimentoConta iC = null;

            while (reader.Read())
            {
                iC = new InvestimentoConta()
                {
                    Id = int.Parse(reader["Investimento_Conta_id"].ToString()),
                    DataFim = DateTime.Parse(reader["Investimento_Fim"].ToString()),
                    DataInicio = DateTime.Parse(reader["Investimento_Inicio"].ToString()),
                    Valor = double.Parse(reader["Investimento_Conta_Valor"].ToString()),


                };
            }

            if (reader["Investimento_Resgate"].GetType() != typeof(DBNull))
            {
                iC.Resgatado = true;
                iC.DataResgate = DateTime.Parse(reader["Investimento_Resgate"].ToString());
                iC.ValorResgate = float.Parse(reader["Investimento_Valor_Resgate"].ToString());
            }

            contaId = int.Parse(reader["Conta_Corrente_Conta_Conta_Corrente_id"].ToString());
            investimentoId = int.Parse(reader["Investimento_Investimento_id"].ToString());
            reader.Close();

            iC.Investimento = new InvestimentoDAO().BuscarInvestimentoPorId(investimentoId);
            iC.Conta = new ContaDAO().PesquisarContaPorNumero(contaId) as ContaCorrente;


            return iC;

        }
        public InvestimentoConta AtualizaInvestimentoConta(InvestimentoConta investimentoConta, DateTime dataResgate, float valor)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            string sql = ("UPDATE projetobanking.investimento_conta " +
                          "SET Investimento_Resgate = @Investimento_Resgate, Investimento_Valor_Resgate = @valorResgate" +
                          " WHERE Investimento_Conta_Id = " + investimentoConta.Id) + ";";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@Investimento_Resgate", dataResgate);
            command.Parameters.AddWithValue("@valorResgate", valor);
            int retorno = command.ExecuteNonQuery();
            if (retorno > 0)
            {
                return investimentoConta;
            }
            else
            {
                return null;
            }

        }

        public Investimento CadastrarInvestimento(Investimento investimento)
        {
            //INSERT INTO `ProjetoBanking`.`Investimento` (`Investimento_nome`, `Investimento_rentabilidade`, `Taxa_Taxa_id`) VALUES (NULL, NULL, NULL);
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Investimento` (`Investimento_nome`, `Investimento_rentabilidade`, `Taxa_Taxa_id`) VALUES (@nome, @rentabilidade, @taxa_id);";
            command.Parameters.AddWithValue("@nome", investimento.Nome);
            command.Parameters.AddWithValue("@rentabilidade", investimento.Rentabilidade);
            command.Parameters.AddWithValue("@taxa_id", investimento.Taxa.Id);
            if (command.ExecuteNonQuery() > 0)
            {
                investimento.Id = (int)command.LastInsertedId;
                return investimento;
            }
            return null;
        }

        public Investimento EditarInvestimento(Investimento inv)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            string sql = ("UPDATE projetobanking.investimento " +
                          "SET Investimento_nome = @inv_nome, Investimento_rentabilidade = @inv_rentabilidade, Taxa_Taxa_id =  @inv_taxa " +
                          " WHERE Investimento_id = " + inv.Id) + ";";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@inv_nome", inv.Nome);
            command.Parameters.AddWithValue("@inv_rentabilidade", inv.Rentabilidade);
            command.Parameters.AddWithValue("@inv_taxa", inv.Taxa.Id);
            int retorno = command.ExecuteNonQuery();
            if (retorno > 0)
            {
                return inv;
            }
            else
            {
                return null;
            }
        }
        public bool RemoverInvestimento(int cod)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                command.CommandText = "DELETE FROM investimento WHERE Investimento_id =@id";
                command.Parameters.AddWithValue("@id", cod);

                if (command.ExecuteNonQuery() > 0)
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
    }
}
