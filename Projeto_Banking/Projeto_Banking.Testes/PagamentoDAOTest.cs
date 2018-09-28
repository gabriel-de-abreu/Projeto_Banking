using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto_Banking.Objetos;
using Projeto_Banking.Models.Opecacoes.Emprestimo;

namespace Projeto_Banking.Testes
{
    [TestClass]
    public class PagamentoDAOTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PagamentoBoleto pagamento = new PagamentoBoleto() {
                Codigo = 1456456456,
                Data = DateTime.Now,
                Emprestimo = new Emprestimo()
                {
                    Id = 1
                },
                Valor = 100,
                Vencimento = DateTime.Now
            };

            var res = new PagamentoDAO().Inserir(pagamento);
            Assert.IsNotNull(res);
        }
    }
}
