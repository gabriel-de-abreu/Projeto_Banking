using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Pessoa
    {
        public int Id;
        public String Cpf { get; set; }
        public String Nome { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Cpf: {Cpf} Nome: {Nome}";
        }

    }

}