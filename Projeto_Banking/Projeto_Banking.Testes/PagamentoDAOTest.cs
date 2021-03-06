﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;
using System.Data;
using Projeto_Banking.Models;
using System.Collections.Generic;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class PagamentoDAOTest
    {

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

        [TestMethod]
        public void TestBuscarPagamentoBoleto()
        {
            Pagamento pagamento = new PagamentoDAO().BuscarPagamentoPorId(1);
            Console.Write(pagamento);
        }

        [TestMethod]
        public void TestBuscarPagamentoConta()
        {
            Pagamento pagamento = new PagamentoDAO().BuscarPagamentoPorId(2);
            Console.Write(pagamento);
            Assert.IsNotNull(pagamento);
        }

        [TestMethod]
        public void TestPagarBoleto()
        {
            Pagamento pagamento = new PagamentoDAO().BuscarPagamentoPorId(2);
            pagamento = new PagamentoDAO().Pagar(pagamento);
            Console.Write(pagamento);
            Assert.IsNotNull(pagamento);
        }

        [TestMethod]
        public void TestPagarConta()
        {
            Pagamento pagamento = new PagamentoDAO().BuscarPagamentoPorId(2);
            pagamento = new PagamentoDAO().Pagar(pagamento);
            Console.Write(pagamento);
            Assert.IsNotNull(pagamento);
        }
        [TestMethod]
        public void TestListarTodosPag()
        {
            List<Pagamento> pagamentos = new PagamentoDAO().BuscarPagamentosPorEmprestimo(new EmprestimoDAO().PesquisarEmprestimoPorId(3));
            foreach (var pagamento in pagamentos)
            {
                Console.WriteLine(pagamento);

            }
        }
    }
}
