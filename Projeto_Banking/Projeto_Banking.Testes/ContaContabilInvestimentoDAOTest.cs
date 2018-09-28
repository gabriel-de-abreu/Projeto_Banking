using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models.ContaDAOs;

namespace Projeto_Banking.Testes
{
    /// <summary>
    /// Descrição resumida para ContaContabilInvestimentoDAOTest
    /// </summary>
    [TestClass]
    public class ContaContabilInvestimentoDAOTest
    {
        public ContaContabilInvestimentoDAOTest()
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
        public void TestMethodUpdateInvestimentoDAO()
        {
            ContaContabilInvestimentoDAO ccEmpDAO = new ContaContabilInvestimentoDAO();
            Assert.AreEqual(true, ccEmpDAO.AtualizarContaContabilInvestimento(3.0));
        }
        [TestMethod]
        public void TestMethodVisualizarSaldoEmprestimosDAO()
        {
            ContaContabilInvestimentoDAO ccEmpDAO = new ContaContabilInvestimentoDAO();
            Assert.AreNotEqual(-1, ccEmpDAO.BuscarSaldoContaContabilInvestimento());
        }
    }
}
