using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
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
                return false;
            }
        }
        public DataTable ListarTodosPorOrigem( Conta origem )
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM projetobanking.movimentacao " +
                    "WHERE " + origem.Numero, Connection.Instance);

                sqlData.Fill(table);
                return table;
                
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public DataTable ListarPorIntervaloDeData(DateTime DataIni, DateTime DataFim)
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM projetobanking.movimentacao " +
                    "WHERE Movimentacao_data BETWEEN  @dataIni AND @dataFim", Connection.Instance);
                sqlData.SelectCommand.Parameters.AddWithValue("@dataIni", DataIni);
                sqlData.SelectCommand.Parameters.AddWithValue("@dataFim", DataFim);
                sqlData.Fill(table);
                return table;

            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}