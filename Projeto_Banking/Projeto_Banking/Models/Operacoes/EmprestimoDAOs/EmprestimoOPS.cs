﻿using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Opecacoes.EmprestimoDAOs
{
    public class EmprestimoOPS
    {
        public static double CalcularParcelas(int parcelas, Taxa taxa, double valor) //calcula o valor das parcelas de acordo com o juros do perfil e o valor desejado
        {
            double valorParcela, taxaValor;
            taxaValor = taxa.Valor / 100;

            valorParcela = ((taxaValor) / (1 - Math.Pow((1 + taxaValor), -parcelas))) * valor;

            //valorTotal = valorDesejado + (parcelas * taxaValor * valorDesejado);


            return valorParcela;
        }

        public static int VerificarPerfil(ContaCorrente cc) //retorna a taxa de acordo com o perfil de pessoa
        {
            if (cc.Saldo < 0)
            {
                return 3;
            }
            else if (cc.Saldo > 0 && cc.Saldo <= 1000)
            {
                return 3;
            }
            else if (cc.Saldo >= 1001 && cc.Saldo <= 5000)
            {
                return 2;
            }
            else if (cc.Saldo > 5000)
            {
                return 1;
            }
            return 3;
        }
    }
}