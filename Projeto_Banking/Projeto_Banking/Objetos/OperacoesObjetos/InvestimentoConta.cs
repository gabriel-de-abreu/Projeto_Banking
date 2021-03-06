﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class InvestimentoConta
    {
        public ContaCorrente Conta { get; set; }
        public double Valor { get; set; }
        public double ValorResgate { get; set; }
        public Investimento Investimento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataResgate { get; set; }
        public int Id { get; set; }
        public bool Resgatado { get; set; }
    }
}