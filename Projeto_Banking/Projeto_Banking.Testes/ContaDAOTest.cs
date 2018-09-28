using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models.ContaDAOs;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class ContaDAOTest
    {
        [TestMethod]
        public void TesteContaCorrente()
        {
            Assert.IsNotNull(new ContaDAO().ContaAtualizarSaldo(new ContaDAO().PesquisarContaPorNumero(3), 200));
        }

        [TestMethod]
        public void TesteContaContabilEmprestimo()
        {
            Assert.IsNotNull(new ContaDAO().ContaAtualizarSaldo(new ContaDAO().PesquisarContaPorNumero(2), 2000));
        }

        [TestMethod]
        public void TesteContaContabilInvestimento()
        {
            Assert.IsNotNull(new ContaDAO().ContaAtualizarSaldo(new ContaDAO().PesquisarContaPorNumero(1), 2000));
        }
    }
}
