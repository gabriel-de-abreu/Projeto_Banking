using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Taxa
    {
        public int Id { get; set; }
        public Double Valor { get; set; }
        public String Nome { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Valor: {Valor} Nome: {Nome}";
        }

    }
}