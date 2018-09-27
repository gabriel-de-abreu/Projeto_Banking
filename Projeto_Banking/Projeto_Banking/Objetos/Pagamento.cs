using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public abstract class Pagamento
    {
        public int Id { get; set; }
        public Double Valor { get; set; }
        public DateTime Data { get; set; }

    }
}