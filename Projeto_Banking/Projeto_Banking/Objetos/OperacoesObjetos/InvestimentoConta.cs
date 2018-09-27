using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class InvestimentoConta
    {
        public ContaCorrente Conta { get; set; }
        public float Valor { get; set; }
        public Investimento Investimento { get; set; }
    }
}