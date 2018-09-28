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
            if (investimentoConta.Investimento.DataFim == dataResgate)
                mes = investimentoConta.Investimento.DataFim.Subtract(investimentoConta.Investimento.DataInicio);

            else
                mes = dataResgate.Subtract(investimentoConta.Investimento.DataInicio);

            int meses = (int)(mes.TotalDays / 30);

            if (investimentoConta.Investimento.PreFixada)
                for (int i = 0; i < meses; i++)
                {
                    investimentoConta = AtualizaInvestimento(investimentoConta);
                    investimentoConta.Valor -= investimentoConta.Valor * (investimentoConta.Investimento.Taxa.Valor / 100) / 12;
                }

            else
                for (int i = 0; i < meses; i++)
                {
                    investimentoConta = AtualizaInvestimento(investimentoConta, random.Next(7, 13)); // Taxa de rentabilidade aleatoria entre 7% e 13% ao mês
                    investimentoConta.Valor -= investimentoConta.Valor * (investimentoConta.Investimento.Taxa.Valor / 100) / 12;
                }

            return investimentoConta.Valor;
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