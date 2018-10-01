using MySql.Data.MySqlClient;
using Projeto_Banking.Models.Opecacoes.Emprestimo.PagamentoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.Emprestimo
{
    public class PagamentoDAO
    {
        public Pagamento Inserir(Pagamento pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Pagamento` (`Pagamento_data`, `Emprestimo_Emprestimo_id`, `Pagamento_Valor`)" +
                " VALUES (@data, @emprestimo_id,@valor);";
            command.Parameters.AddWithValue("@data", pagamento.Data);
            command.Parameters.AddWithValue("@emprestimo_id", pagamento.Emprestimo.Id);
            command.Parameters.AddWithValue("@valor", pagamento.Valor);
            command.ExecuteNonQuery();
            pagamento.Id = Convert.ToInt32(command.LastInsertedId);
            if (pagamento is PagamentoBoleto)
            {
                new PagamentoBoletoDAO().InserirPagamentoBoleto(pagamento as PagamentoBoleto);
            }
            if (pagamento is PagamentoConta)
            {
                new PagamentoContaDAO().InserirPagamentoConta(pagamento as PagamentoConta);
            }
            return pagamento;
        }

        public DataTable BuscarPagamentosPorIdDoEmprestimo(int numPagamento)
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM projetobanking.pagamento " +
                    "WHERE pagamento.Emprestimo_Emprestimo_id = @numPagamento", Connection.Instance);
                sqlData.SelectCommand.Parameters.AddWithValue("@numPagamento", numPagamento);

                sqlData.Fill(table);
                return table;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Pagamento BuscarPagamentoPorId(int id)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM projetobanking.pagamento" +
                $" WHERE Pagamento_id = {id}", Connection.Instance);
            DataTable table = new DataTable();
            adapter.Fill(table);
            PagamentoConta pagamento = new PagamentoContaDAO().BuscarPagamentoContaPorId(id);
            if (pagamento != null)
            {
                return new PagamentoConta()
                {
                    Data = Convert.ToDateTime(table.Rows[0]["Pagamento_data"]),
                    Id = id,
                    Valor = float.Parse(table.Rows[0]["Pagamento_Valor"].ToString()),
                    Emprestimo = new EmprestimoDAO().PesquisarEmprestimoPorId(
                      Convert.ToInt32(table.Rows[0]["Emprestimo_Emprestimo_id"]))
                };
            }
            PagamentoBoleto pagamentoBoleto = new PagamentoBoletoDAO().BuscarPagamentoBoletoPorId(id);
            if (pagamentoBoleto != null)
            {
                return new PagamentoBoleto()
                {
                    Codigo = pagamentoBoleto.Codigo,
                    Data = Convert.ToDateTime(table.Rows[0]["Pagamento_data"]),
                    Valor = float.Parse(table.Rows[0]["Pagamento_Valor"].ToString()),
                    Emprestimo = new EmprestimoDAO().PesquisarEmprestimoPorId(
                      Convert.ToInt32(table.Rows[0]["Emprestimo_Emprestimo_id"])),
                    Id = id,
                    Vencimento = pagamentoBoleto.Vencimento
                };
            }
            return null;
        }
    }
}