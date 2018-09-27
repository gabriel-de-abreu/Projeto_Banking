using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public Double Saldo { get; set; }
    }
}