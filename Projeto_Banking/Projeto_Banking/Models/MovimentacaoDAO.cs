﻿using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models
{
    public class MovimentacaoDAO
    {

        public bool InsererMovimentacao(Movimentacao mov)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = ("INSERT INTO movimentacao(Movimentacao_id, Conta_Movimentacao_origem_id, Conta_Movimetacao_destino, " +
                    "Movimentacao_valor, Movimentacao_descricao, Movimentacao_data) " +
                    "VALUES(@movimentacao_id, @conta_Movimentacao_origem_id, @conta_Movimetacao_destino," +
                    " @movimentacao_valor, @movimentacao_descricao, @movimentacao_data);");

                command.CommandText = sql;
                command.Parameters.AddWithValue("@movimentacao_id", mov.Movimentacao_id);
                command.Parameters.AddWithValue("@conta_Movimentacao_origem_id", mov.Origem.Numero);
                command.Parameters.AddWithValue("@conta_Movimetacao_destino", mov.Destino.Numero);
                command.Parameters.AddWithValue("@movimentacao_valor", mov.Valor);
                command.Parameters.AddWithValue("@movimentacao_descricao", mov.Descricao);
                command.Parameters.AddWithValue("@movimentacao_data", mov.Data);
                int retorno = command.ExecuteNonQuery();
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