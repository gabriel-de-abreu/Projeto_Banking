using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Conta;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class DAOTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PessoaDAO dao = new PessoaDAO();
            Pessoa p = dao.PesquisaPessoaPorId(2);
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine(Utils.Criptografia.GerarHashMd5("123"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            ContaCorrente cc = new ContaCorrenteDAO().Login(new ContaCorrente()
            {
                Numero = 3,
                Senha = Utils.Criptografia.GerarHashMd5("123")
            }
            );
            Console.WriteLine(cc);
            Assert.IsNotNull(cc);

        }
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
    }

}
