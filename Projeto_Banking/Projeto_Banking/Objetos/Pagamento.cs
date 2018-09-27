using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Pagamento
    {
        public Double Valor { get; set; }
        public DateTime Data { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}