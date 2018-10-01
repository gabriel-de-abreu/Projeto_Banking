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
        public Emprestimo Emprestimo { get; set; }
        public Boolean Pago { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Valor: {Valor} Data: {Data} Emprestimo: {{{Emprestimo}}} Pago: {(Pago?"Sim":"Não")}";
        }
    }

}