using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class ContaCorrente
    {
        public Pessoa Pessoa { get; set; }
        public float Limite { get; set; }
        public List<InvestimentoConta> Investimentos { get; set; }
        public List<Emprestimos> Emprestimos { get; set; }
    }
}