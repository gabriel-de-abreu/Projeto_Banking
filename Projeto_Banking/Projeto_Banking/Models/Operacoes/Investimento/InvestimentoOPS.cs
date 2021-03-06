﻿using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Operacoes.Investimento
{
    public static class InvestimentoOPS
    {

        public static double Resgate(InvestimentoConta investimentoConta, DateTime dataResgate)
        {
            Random random = new Random();
            TimeSpan mes;
            mes = dataResgate.Subtract(investimentoConta.DataInicio);
            float valorInicial = (float)investimentoConta.Valor;

            int meses = (int)(mes.TotalDays / 30);
            if (investimentoConta.Investimento.Rentabilidade > 0)
                investimentoConta.Investimento.PreFixada = true;
            else investimentoConta.Investimento.PreFixada = false;


            if (investimentoConta.Investimento.PreFixada)
            {
                for (int i = 0; i < meses; i++)
                {
                    investimentoConta = AtualizaInvestimento(investimentoConta);
                    investimentoConta.Valor -= investimentoConta.Valor * (investimentoConta.Investimento.Taxa.Valor / 100) / 12;
                }
                if (investimentoConta.DataFim > dataResgate)
                {
                    investimentoConta.Valor -= investimentoConta.Valor * 0.0005 * (investimentoConta.DataFim.Subtract(dataResgate).TotalDays);
                }
            }

            else
                for (int i = 0; i < meses; i++)
                {
                    investimentoConta = AtualizaInvestimento(investimentoConta, random.Next(4, 7)); // Taxa de rentabilidade aleatoria entre 7% e 13% ao mês
                    investimentoConta.Valor -= investimentoConta.Valor * (investimentoConta.Investimento.Taxa.Valor / 100) / 12;
                }

            return (investimentoConta.Valor < valorInicial ? valorInicial : investimentoConta.Valor);
        }

        public static InvestimentoConta AtualizaInvestimento(InvestimentoConta investimentoConta)
        {
            investimentoConta.Valor += investimentoConta.Valor * (investimentoConta.Investimento.Rentabilidade / 100);
            return investimentoConta;
        }

        public static InvestimentoConta AtualizaInvestimento(InvestimentoConta investimentoConta, double rentabilidadeAtual)
        {
            investimentoConta.Valor += investimentoConta.Valor * (rentabilidadeAtual / 100);
            return investimentoConta;
        }


    }
}