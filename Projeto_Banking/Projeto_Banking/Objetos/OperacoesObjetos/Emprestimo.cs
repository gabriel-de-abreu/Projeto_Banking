using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int Parcelas { get; set; }
        public double Valor { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public Taxa Taxa { get; set; }
        public DateTime DataInicio { get; set; }
        
    }
}