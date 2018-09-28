﻿using MySql.Data.MySqlClient;
using Projeto_Banking.Models.Opecacoes.Emprestimo;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class EmprestimoDAO
    {
        public bool InserirEmprestimo(Emprestimo emp, String tipo)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("INSERT INTO Emprestimo(Emprestimo_valor,Emprestimo_parcelas, Taxa_Taxa_id, " +
                                "Conta_Corrente_Conta_Conta_Corrente_id, Emprestimo_Inicio) VALUES (@Emprestimo_valor," +
                                "@Emprestimo_parcelas, @Taxa_Taxa_id, @Conta_Corrente_Conta_Conta_Corrente_id, @Emprestimo_Inicio)");

                command.CommandText = sql;
                command.Parameters.AddWithValue("@Emprestimo_valor", emp.Valor);
                command.Parameters.AddWithValue("@Emprestimo_parcelas", emp.Parcelas);
                command.Parameters.AddWithValue("@Taxa_Taxa_id", emp.Taxa.Id);
                command.Parameters.AddWithValue("@Conta_Corrente_Conta_Conta_Corrente_id", emp.ContaCorrente.Numero);
                command.Parameters.AddWithValue("@Emprestimo_Inicio", emp.DataInicio);
                int retorno = command.ExecuteNonQuery();
                emp.Id = (int) command.LastInsertedId;
                // Adicionar cálculo do valor de parcela Valor dummy 5
                if (tipo.Equals("debito"))
                {
                    for (int i = 0; i < emp.Parcelas; i++)
                    {
                        new PagamentoDAO().Inserir(new PagamentoConta()
                        {
                            Valor = 5,
                            Emprestimo = emp,
                            Data = emp.DataInicio.AddMonths(i)

                        });
                    }
                }

                if (retorno > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}