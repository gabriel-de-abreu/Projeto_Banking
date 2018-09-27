using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using System.Data;

namespace Projeto_Banking.Testes
{
    /// <summary>
    /// Descrição resumida para UnitTest1
    /// </summary>
    [TestClass]
    public class MovimentacaoDAOTest
    {
        public MovimentacaoDAOTest()
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
        public void TestMethodMovimentacao()
        {
            MovimentacaoDAO mDao = new MovimentacaoDAO();
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
            Movimentacao mov = new Movimentacao()
            {
                Movimentacao_id = 2,
                Origem = cli1,
                Destino = cli1,
                Valor = 300.00,
                Descricao = "Apenas um test",
                Data = DateTime.Today
            };

            bool result = mDao.InsererMovimentacao(mov);
            Console.WriteLine(result);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethodListarMovOrigem()
        {

            MovimentacaoDAO mDao = new MovimentacaoDAO();
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
            Movimentacao mov = new Movimentacao()
            {
                Movimentacao_id = 2,
                Origem = cli1,
                Destino = cli1,
                Valor = 300.00,
                Descricao = "Apenas um test",
                Data = DateTime.Today
            };

            DataTable table = new DataTable();

            table = mDao.ListarTodosPorOrigem(cli1);

            foreach (DataRow item in table.Rows)
            {
                Console.WriteLine(item["Movimentacao_id"]);
            }

            Assert.AreNotEqual(false, table);
        }

        [TestMethod]
        public void TestMethodListarMovPorData()
        {

            MovimentacaoDAO mDao = new MovimentacaoDAO();

            DataTable table = new DataTable();

            table = mDao.ListarPorIntervaloDeData(DateTime.Today, DateTime.Today);

            foreach (DataRow item in table.Rows)
            {
                Console.WriteLine(item["Movimentacao_id"]);
            }

            Assert.AreNotEqual(false, table);
        }
    }
}
