using MySql.Data.MySqlClient;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class EmprestimoDAO
    {
        public bool InserirEmprestimo(Emprestimo emp, String tipo)
        {
            try
            {
                emp.Taxa = new TaxaDAO().PesquisarPorTaxa(EmprestimoOPS.VerificarPerfil(emp.ContaCorrente));
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
                emp.Id = (int)command.LastInsertedId;
                // Adicionar cálculo do valor de parcela Valor dummy 5
                // Gerar pagamentos
                if (tipo.Equals("debito"))
                {
                    for (int i = 0; i < emp.Parcelas; i++)
                    {
                        new PagamentoDAO().Inserir(new PagamentoConta()
                        {
                            Valor = EmprestimoOPS.CalcularParcelas(emp.Parcelas, emp.Taxa, emp.Valor),
                            Emprestimo = emp,
                            Data = emp.DataInicio.AddMonths(i)

                        });
                    }
                }
                else if (tipo.Equals("boleto"))
                {
                    for (int i = 0; i < emp.Parcelas; i++)
                    {
                        new PagamentoDAO().Inserir(new PagamentoBoleto()
                        {
                            Codigo = Math.Abs(emp.DataInicio.AddMonths(i).GetHashCode()),
                            Data = emp.DataInicio.AddMonths(i),
                            Valor = EmprestimoOPS.CalcularParcelas(emp.Parcelas, emp.Taxa, emp.Valor),
                            Vencimento = emp.DataInicio.AddMonths(i),
                            Emprestimo = emp
                        });
                    }
                }
                // Fim da gerar pagamentos
                new ContaDAO().Transferir(new ContaDAO().PesquisarContaPorNumero(2), emp.ContaCorrente, emp.Valor, "Realização de empréstimo");
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
        public DataTable PesquisarEmprestimosContaCorrente(ContaCorrente conta)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            String sql = $"SELECT * FROM projetobanking.emprestimo WHERE Conta_Corrente_Conta_Conta_Corrente_id={conta.Numero};";
            MySqlDataAdapter mAdpater = new MySqlDataAdapter(sql, Connection.Instance);
            DataTable table = new DataTable();
            mAdpater.Fill(table);
            return table;
        }

        public DataTable PesquisarEmprestimosContaCorrenteComTaxa(ContaCorrente conta)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            String sql = $"SELECT * FROM emprestimo INNER JOIN taxa ON Taxa_Taxa_id=Taxa_id where Conta_Corrente_Conta_Conta_Corrente_id ={conta.Numero};";
            MySqlDataAdapter mAdpater = new MySqlDataAdapter(sql, Connection.Instance);
            DataTable table = new DataTable();
            mAdpater.Fill(table);
            return table;
        }

        public Emprestimo PesquisarEmprestimoPorId(int id)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.emprestimo WHERE Emprestimo_id = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            Emprestimo emprestimo = null;
            int contaId = -1;
            int taxaId = -1;
            while (reader.Read())
            {
                emprestimo = new Emprestimo()
                {
                    DataInicio = Convert.ToDateTime(reader["Emprestimo_Inicio"]),
                    Id = id,
                    Parcelas = Convert.ToInt32(reader["Emprestimo_parcelas"]),
                    Valor = float.Parse(reader["Emprestimo_valor"].ToString())

                };
                contaId = Convert.ToInt32(reader["Conta_Corrente_Conta_Conta_Corrente_id"]);
                taxaId = Convert.ToInt32(reader["Taxa_Taxa_id"]);
            }
            reader.Close();
            emprestimo.ContaCorrente = new ContaCorrenteDAO().PesquisarPorNumero(contaId);
            emprestimo.Taxa = new TaxaDAO().PesquisarPorTaxa(taxaId);
            return emprestimo;
        }
    }
}