using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;

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
            Console.WriteLine(p.ToString());
            Assert.AreNotEqual(null, p);
        }
    }
}
