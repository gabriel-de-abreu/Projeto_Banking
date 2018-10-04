using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Models;
using Projeto_Banking.Objetos;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class GerenteDAOTest
    {
        [TestMethod]
        public void LoginGerente()
        {
            Assert.IsTrue(new GerenteDAO().Login("gerente", "1234"));
        }

        [TestMethod]
        public void CadastroInvestimento()
        {
            Investimento investimento = new Investimento()
            {
                Nome = "Teste",
                Rentabilidade = 5,
                Taxa = new TaxaDAO().PesquisarPorTaxa(1)

            };
            Assert.IsNotNull(new InvestimentoDAO().CadastrarInvestimento(investimento));

        }
    }
}
