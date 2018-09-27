using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.ContaDAOs;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class ContaPessoaDAOTest
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
        public void TestMethod4()
        {
            ContaCorrente cc = new ContaDAO().PesquisarContaPorNumero(3) as ContaCorrente;
            Console.WriteLine(cc);
            Assert.IsNotNull(cc);

        }

    }
}
