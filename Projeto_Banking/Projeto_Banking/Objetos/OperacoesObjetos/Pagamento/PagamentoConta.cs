using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class PagamentoConta : Pagamento
    {
        public ContaCorrente ContaCorrente { get; set; }
    }
}