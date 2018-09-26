using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class ExemploTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreEqual(Exemplo.soma(2, 3), 5);
        }
    }
}
