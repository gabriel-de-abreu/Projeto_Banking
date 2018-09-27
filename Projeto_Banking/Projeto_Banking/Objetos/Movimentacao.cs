﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Objetos
{
    public class Movimentacao
    {
        public int Movimentacao_id { get; set; }
        public Conta Origem { get; set; }
        public Conta Destino { get; set; }
        public Double Valor { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}