using Projeto_Banking.Models.Conta;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Controllers
{
    public class ContaCorrenteController
    {
        public ContaCorrente Login(ContaCorrente cc)
        {
            return new ContaCorrenteDAO().Login(cc);
        }
        
    }
}