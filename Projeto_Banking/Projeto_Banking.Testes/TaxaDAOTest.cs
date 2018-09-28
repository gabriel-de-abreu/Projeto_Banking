using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class TaxaDAOTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Taxa taxa = null;
            taxa = new TaxaDAO().PesquisarPorTaxa(1);
            Assert.IsNotNull(taxa);
        }
    }
}
