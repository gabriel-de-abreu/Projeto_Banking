using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Investimento
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Taxa Taxa { get; set; }
        public Boolean PreFixada { get; set; }
        public Double Rentabilidade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}