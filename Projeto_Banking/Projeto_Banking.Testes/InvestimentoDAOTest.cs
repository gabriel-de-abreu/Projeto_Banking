using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Operacoes.Investimento;

namespace Projeto_Banking.Testes
{
    /// <summary>
    /// Descrição resumida para InvestimentoDAOTest
    /// </summary>
    [TestClass]
    public class InvestimentoDAOTest
    {
        public InvestimentoDAOTest()
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
        public void TestInvestimentoDAO1()
        {
            ContaCorrente conta = new ContaCorrente()
            {
                Numero = 4,
                Saldo = 1999
            };
            Investimento investimento = new Investimento() {
                Id=1                
            };

            InvestimentoDAO investDao = new InvestimentoDAO();

            InvestimentoConta investimentoConta = investDao.InserirInvestimento(investimento,conta,1000);
            Assert.IsNotNull(investimentoConta);
        }

        [TestMethod]
        public void TestInvestimentoDAO2()
        {
            ContaCorrente conta = new ContaCorrente()
            {
                Numero = 4,
                Saldo = 999
            };
            Investimento investimento = new Investimento()
            {
                Id = 2
            };

            InvestimentoDAO investDao = new InvestimentoDAO();

            InvestimentoConta investimentoConta = investDao.InserirInvestimento(investimento, conta, 1000);
            Assert.IsNull(investimentoConta);
        }
    }
}
