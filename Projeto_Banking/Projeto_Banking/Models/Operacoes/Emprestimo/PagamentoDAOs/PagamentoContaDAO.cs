using MySql.Data.MySqlClient;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.Emprestimo.PagamentoDAOs
{
    public class PagamentoContaDAO
    {
        public PagamentoConta InserirPagamentoConta(PagamentoConta pagamento)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Pagamento_Conta` (`Pagamento_Pagamento_id`) VALUES (@id); ";
            command.Parameters.AddWithValue("@id", pagamento.Id);
            command.ExecuteNonQuery();
            return pagamento;
        }

        public PagamentoConta BuscarPagamentoContaPorId(int id)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.pagamento_conta WHERE Pagamento_Pagamento_id = @id;";
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            PagamentoConta pagamento = null;
            while (reader.Read())
            {
                pagamento = new PagamentoConta()
                {
                    Id = id
                };
            }
            reader.Close();
            return pagamento;
        }
        public void PagarPagamentoConta(PagamentoConta pagamento)
        {
            new ContaDAO().Transferir(pagamento.Emprestimo.ContaCorrente, new ContaDAO().PesquisarContaPorNumero(2), (float)pagamento.Valor,
                "Pagamento Parcela Empréstimo");
        }
    }
}