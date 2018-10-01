using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class PagamentoBoleto : Pagamento
    {
        public int Codigo { get; set; }
        public DateTime Vencimento { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Código: {Codigo} Vencimento: {Vencimento}";
        }
    }
}