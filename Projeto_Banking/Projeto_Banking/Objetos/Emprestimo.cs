using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Emprestimo
    {
        public int Parcelas { get; set; }
        public int Valor { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public Pagamento Pagamento { get; set; }
        public Taxa Taxa { get; set; }

    }
}