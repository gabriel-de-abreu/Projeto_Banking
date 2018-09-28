﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Opecacoes.Emprestimo;
using System.Data;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class PagamentoDAOTest
    {
        [TestMethod]
        public void TestPagamentoBoleto()
        {
            PagamentoBoleto pagamento = new PagamentoBoleto()
            {
                Codigo = DateTime.Now.GetHashCode(),
                Data = DateTime.Now,
                Emprestimo = new Emprestimo()
                {
                    Id = 1
                },
                Valor = 100,
                Vencimento = DateTime.Now
            };

            var res = new PagamentoDAO().Inserir(pagamento);
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void TestPagamentoConta()
        {
            PagamentoConta pagamento = new PagamentoConta()
            {
                Data = DateTime.Now,
                Emprestimo = new Emprestimo()
                {
                    Id = 1
                },
                Valor = 100
            };
            var res = new PagamentoDAO().Inserir(pagamento);
            Assert.IsNotNull(res);
        }
        [TestMethod]
        public void TestListarTodosOsPagamentos()
        {
            PagamentoDAO pDAO = new PagamentoDAO();
            

            DataTable table = new DataTable();

            table = pDAO.BuscarPagamentosPorIdDoEmprestimo(1);

            foreach (DataRow item in table.Rows)
            {
                Console.WriteLine(item["Pagamento_Id"]);
            }

            Assert.AreNotEqual(false, table);
        }
    }
}
