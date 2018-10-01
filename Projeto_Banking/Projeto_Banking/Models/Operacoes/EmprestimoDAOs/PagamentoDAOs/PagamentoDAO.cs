using MySql.Data.MySqlClient;
using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs.PagamentoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.EmprestimoDAOs
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

        public List<Pagamento> BuscarPagamentosPorEmprestimo(Emprestimo emprestimo)
        {
            List<Pagamento> pagamentos = new List<Pagamento>();
            DataTable table = BuscarPagamentosPorIdDoEmprestimo(emprestimo.Id);
            foreach (DataRow row in table.Rows)
            {
                pagamentos.Add(BuscarPagamentoPorId(Convert.ToInt32(row["Pagamento_id"])));
            }

            return pagamentos;
        }

        public String TipoPagamentoEmprestimo(Emprestimo emprestimo)
        {   
            if(BuscarPagamentosPorEmprestimo(emprestimo) == null)
            {
                return null;
            }else if(BuscarPagamentosPorEmprestimo(emprestimo)[0] is PagamentoConta)
            {
                return "debito";
            }
            else if(BuscarPagamentosPorEmprestimo(emprestimo)[0] is PagamentoBoleto)
            {
                return "boleto";
            }
            return null;
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
                    Vencimento = pagamentoBoleto.Vencimento,
                    Pago = Convert.ToBoolean(table.Rows[0]["Pagamento_Pago"])
                };
            }
            return null;
        }

        public Pagamento Pagar(Pagamento pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "UPDATE `projetobanking`.`pagamento` SET `Pagamento_id` = @id, " +
                "`Pagamento_data` = @data," +
                "`Emprestimo_Emprestimo_id` = @emprestimo_id," +
                "`Pagamento_Valor` = @valor," +
                "`Pagamento_Pago` = @pago" +
                " WHERE `Pagamento_id` = @id;";
            command.Parameters.AddWithValue("@id", pagamento.Id);
            command.Parameters.AddWithValue("@data", pagamento.Data);
            command.Parameters.AddWithValue("@emprestimo_id", pagamento.Emprestimo.Id);
            command.Parameters.AddWithValue("@valor", pagamento.Valor);
            command.Parameters.AddWithValue("@pago", true);
            pagamento.Pago = true;
            int retorno = command.ExecuteNonQuery();
            if (retorno > 0)
            {
                if (pagamento is PagamentoConta)
                {
                    new PagamentoContaDAO().PagarPagamentoConta(pagamento as PagamentoConta);
                }
                else if (pagamento is PagamentoBoleto)
                {
                    new PagamentoBoletoDAO().PagarPagamentoBoleto(pagamento as PagamentoBoleto);
                }
                return pagamento;
            }
            return null;
        }
    }
}