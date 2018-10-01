using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;
using System.Data;

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
            Investimento investimento = new InvestimentoDAO().BuscarInvestimentoPorId(1);
            Assert.IsNotNull(investimento);

        }

        [TestMethod]
        public void TestInvestimentoDAO2()
        {
            Investimento investimento = new InvestimentoDAO().BuscarInvestimentoPorId(22);
            Assert.IsNull(investimento);
        }

        [TestMethod]
        public void TestInvestimentoDAO3()
        {

            InvestimentoConta ic = new InvestimentoConta()
            {
                Conta = new ContaDAO().PesquisarContaPorNumero(4) as ContaCorrente,
                Investimento = new InvestimentoDAO().BuscarInvestimentoPorId(1),
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1),
                Valor = 1000
            };

            Assert.IsNotNull(new InvestimentoDAO().InserirInvestimento(ic));

        }
        [TestMethod]
        public void TestInvestimentoDAO4()
        {

            InvestimentoConta ic = new InvestimentoConta()
            {
                Conta = new ContaDAO().PesquisarContaPorNumero(4) as ContaCorrente,
                Investimento = new InvestimentoDAO().BuscarInvestimentoPorId(1),
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1),
                Valor = 1000,
            };

            var invest = new InvestimentoDAO().Resgate(ic, DateTime.Now.AddMonths(6));
            Console.Write(invest);
            Assert.IsTrue(invest > -1);

        }

        [TestMethod]
        public void TestInvestimentoDAO5()
        {

            InvestimentoConta ic = new InvestimentoConta()
            {
                Conta = new ContaDAO().PesquisarContaPorNumero(4) as ContaCorrente,
                Investimento = new InvestimentoDAO().BuscarInvestimentoPorId(2),
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1),
                Valor = 1000,
            };

            Assert.IsNotNull(new InvestimentoDAO().InserirInvestimento(ic));
            var invest = new InvestimentoDAO().Resgate(ic, DateTime.Now.AddMonths(12));
            Console.Write(invest);
            Assert.IsTrue(invest > -1);
        }

        [TestMethod]
        public void TestInvestimentoDAO6()
        {

            InvestimentoConta ic = new InvestimentoConta()
            {
                Id = 1,
                Conta = new ContaDAO().PesquisarContaPorNumero(4) as ContaCorrente,
                Investimento = new InvestimentoDAO().BuscarInvestimentoPorId(2),
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1),
                Valor = 1000,
            };

            Assert.IsInstanceOfType(new InvestimentoDAO().BuscarInvestimento(ic), typeof(InvestimentoConta));
        }

        [TestMethod]
        public void TestInvestimentoDAO7()
        {
            ContaCorrente conta = new ContaDAO().PesquisarContaPorNumero(4) as ContaCorrente;

            Assert.IsInstanceOfType(new InvestimentoDAO().BuscarInvestimentosConta(conta), typeof(DataTable));
        }
    }
}
