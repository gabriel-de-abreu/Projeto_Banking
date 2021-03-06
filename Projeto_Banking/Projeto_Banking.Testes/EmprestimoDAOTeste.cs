﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;

namespace Projeto_Banking.Testes
{

    [TestClass]
    public class EmprestimoDAOTeste
    {
        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethodEmprestimoDAODebito()
        {
            EmprestimoDAO empDAO = new EmprestimoDAO();
            PessoaDAO dao = new PessoaDAO();
            Pessoa p = dao.PesquisaPessoaPorId(2);

            ContaCorrente cli1 = new ContaCorrente
            {
                Numero = 4,
                Saldo = 0.0,
                Limite = 0.0f,
                Pessoa = p,
                Emprestimos = null,
                Investimentos = null
            };
            Taxa taxa = new Taxa()
            {
                Id = 1,
                Valor = 10
            };

            Emprestimo emprestimo = new Emprestimo()
            {
                Valor = 2000,
                Parcelas = 10,
                ContaCorrente = cli1,
                Taxa = taxa,
                DataInicio = DateTime.Now
            };

            Assert.AreEqual(true, empDAO.InserirEmprestimo(emprestimo, "debito"));

        }

        [TestMethod]
        public void TestMethodEmprestimoDAOBoleto()
        {
            EmprestimoDAO empDAO = new EmprestimoDAO();
            PessoaDAO dao = new PessoaDAO();
            Pessoa p = dao.PesquisaPessoaPorId(2);

            ContaCorrente cli1 = new ContaCorrente
            {
                Numero = 4,
                Saldo = 0.0,
                Limite = 0.0f,
                Pessoa = p,
                Emprestimos = null,
                Investimentos = null
            };
            Taxa taxa = new Taxa()
            {
                Id = 1,
                Valor = 10
            };

            Emprestimo emprestimo = new Emprestimo()
            {
                Valor = 2000,
                Parcelas = 10,
                ContaCorrente = cli1,
                Taxa = taxa,
                DataInicio = DateTime.Now
            };

            Assert.AreEqual(true, empDAO.InserirEmprestimo(emprestimo, "boleto"));
        }

        [TestMethod]
        public void ConsultaEmprestimoTeste()
        {
            var table = new EmprestimoDAO().PesquisarEmprestimosContaCorrente(new ContaDAO().PesquisarContaPorNumero(3) as ContaCorrente);
            Assert.AreEqual(1, table.Rows.Count);
        }
        [TestMethod]
        public void ConsultaEmprestimoTaxaTeste()
        {
            var table = new EmprestimoDAO().PesquisarEmprestimosContaCorrenteComTaxa(new ContaDAO().PesquisarContaPorNumero(3) as ContaCorrente);
            Assert.AreEqual(6, table.Rows.Count);
        }

        [TestMethod]
        public void ConsultarEmprestimoIdTeste()
        {
            Emprestimo emprestimo = new EmprestimoDAO().PesquisarEmprestimoPorId(1);
            Console.Write(emprestimo);
            Assert.IsNotNull(emprestimo);
        }
        [TestMethod]
        public void ConsultarTipoEmprestimo()
        {
            Emprestimo emprestimo = new EmprestimoDAO().PesquisarEmprestimoPorId(5);
            Console.WriteLine(new PagamentoDAO().BuscarPagamentosPorEmprestimo(emprestimo)[0]);
            
            String tipo = new PagamentoDAO().TipoPagamentoEmprestimo(emprestimo);
            Console.Write(tipo);
        }
    }
}
