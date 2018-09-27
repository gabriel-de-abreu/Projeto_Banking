using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.Conta
{
    public class ContaCorrenteDAO
    {
        public ContaCorrente Login(ContaCorrente cc)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.conta_corrente WHERE Conta_Conta_Corrente_id = @id AND Conta_Corrente_senha = @senha;";
            command.Parameters.AddWithValue("@id", cc.Numero);
            command.Parameters.AddWithValue("@senha", cc.Senha);
            ContaCorrente conta = null;
            String cpfPessoa = "";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                conta = new ContaCorrente()
                {
                    Limite = float.Parse(reader["Conta_Corrente_limite"].ToString()),
                    Numero = cc.Numero
                };
                cpfPessoa = reader["Pessoa_Pessoa_cpf"].ToString();
            }
            reader.Close();

            if (conta != null)
            {
                conta.Pessoa = new PessoaDAO().PesquisaPessoaPorCPF(cpfPessoa);
            }
            return conta;

        }
    }
}