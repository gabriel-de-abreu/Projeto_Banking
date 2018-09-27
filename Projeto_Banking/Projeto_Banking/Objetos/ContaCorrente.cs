using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class ContaCorrente : Conta
    {
        public Pessoa Pessoa { get; set; }
        public float Limite { get; set; }
        public List<InvestimentoConta> Investimentos { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }
        public String Senha { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Pessoa: {Pessoa.ToString()} Limite: {Limite}";
        }
    }
}