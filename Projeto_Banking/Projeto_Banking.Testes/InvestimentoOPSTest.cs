using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Operacoes.Investimento;
using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;

namespace Projeto_Banking.Testes
{
    /// <summary>
    /// Descrição resumida para InvestimentoOPSTest
    /// </summary>
    [TestClass]
    public class InvestimentoOPSTest
    {
        public InvestimentoOPSTest()
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
        public void TestInvestimentoOPS1()
        {
            Taxa taxa = new Taxa()
            {
                Id = 1,
                Nome = "Taxa louca",
                Valor = 6
            };

            Investimento investimento = new Investimento()
            {
                Nome = "Tesouro Direto",
                PreFixada = true,
                Rentabilidade = 10,
                Taxa = taxa,
                
            };

            ContaCorrente conta = new ContaCorrente()
            {
                Limite = 1000,
                Emprestimos = null,
                Investimentos = null,
                Numero = 1213,
                Pessoa = null,
                Saldo = 1500,
                Senha = "1234"
            };

            InvestimentoConta investimentoConta = new InvestimentoConta()
            {
                Conta = conta,
                Investimento = investimento,
                Valor = 1000,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1)

            };
            double saidaDouble = InvestimentoOPS.Resgate(investimentoConta, DateTime.Now.AddMonths(3));
            Console.Write(saidaDouble);
            int saidaInt = Convert.ToInt32(saidaDouble);
            Assert.AreEqual(1311, saidaInt);
        }

        [TestMethod]
        public void TestInvestimentoOPS2()
        {
            Taxa taxa = new TaxaDAO().PesquisarPorTaxa(1);
            Investimento investimento = new InvestimentoDAO().BuscarInvestimentoPorId(1);

            ContaCorrente conta = new ContaCorrenteDAO().PesquisarPorNumero(3);

            InvestimentoConta investimentoConta = new InvestimentoConta()
            {
                Conta = conta,
                Investimento = investimento,
                Valor = 1000,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1)

            };

            double saidaDouble = InvestimentoOPS.Resgate(investimentoConta, DateTime.Now.AddMonths(12));
            Console.Write(saidaDouble);
            int saidaInt = Convert.ToInt32(saidaDouble);
            Assert.AreEqual(2955, saidaInt);
        }


        [TestMethod]
        public void TestInvestimentoOPS3()
        {
            Taxa taxa = new TaxaDAO().PesquisarPorTaxa(1);

            Investimento investimento = new InvestimentoDAO().BuscarInvestimentoPorId(1);

            ContaCorrente conta = new ContaCorrenteDAO().PesquisarPorNumero(3);

            InvestimentoConta investimentoConta = new InvestimentoConta()
            {
                Conta = conta,
                Investimento = investimento,
                Valor = 1000,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddYears(1)

            };
            double saidaDouble = InvestimentoOPS.Resgate(investimentoConta, DateTime.Now.AddMonths(12));
            Console.Write(saidaDouble);
            int saidaInt = Convert.ToInt32(saidaDouble);
            Assert.IsTrue(saidaInt > 2120 && saidaInt < 4081);
        }

    }
}
