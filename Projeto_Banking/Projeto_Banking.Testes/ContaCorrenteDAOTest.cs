﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;

namespace Projeto_Banking.Testes
{
    /// <summary>
    /// Descrição resumida para ContaCorrenteDAOTest
    /// </summary>
    [TestClass]
    public class ContaCorrenteDAOTest
    {
        public ContaCorrenteDAOTest()
        {
            //
            // TODO: Adicionar lógica de construtor aqui
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        public void TestAtualizarLimite()
        {
            bool atualizado = new ContaCorrenteDAO().AtualizarLimite(3, -5000);
            Assert.AreEqual(true, atualizado);
        }

        [TestMethod]
        public void TestCadastro()
        {
            Pessoa p = new Pessoa()
            {
                Nome = "Fulano",
                Cpf = "000.000.000-12"
            };

            ContaCorrente conta = new ContaCorrente()
            {
                Limite = 3000,
                Pessoa = p,
                Senha = "123"
            };

            Assert.IsNotNull(new ContaCorrenteDAO().InserirContaCorrente(conta));

        }


    }
}
