using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models.ContaDAOs;
using Projeto_Banking.Objetos;

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

        [TestMethod]
        public void TesteTransferencia()
        {
            Conta conta1 = new ContaDAO().PesquisarContaPorNumero(3);
            Conta conta2 = new ContaDAO().PesquisarContaPorNumero(1);
            Assert.IsNotNull(new ContaDAO().Transferir(conta1, conta2, 2000,"TransfSimples"));
        }

        [TestMethod]
        public void TesteTransferenciaInv()
        {
            Conta conta1 = new ContaDAO().PesquisarContaPorNumero(1);
            Conta conta2 = new ContaDAO().PesquisarContaPorNumero(4);
            Assert.IsNotNull(new ContaDAO().Transferir(conta1, conta2, 2000, "TransfInv"));
        }
    }

}
