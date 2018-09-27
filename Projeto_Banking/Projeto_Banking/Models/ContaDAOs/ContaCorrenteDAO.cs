using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.ContaDAOs
{
    public class ContaCorrenteDAO
    {
        public ContaCorrente PesquisarPorNumero(int numero)
        {
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.conta_corrente WHERE Conta_Conta_Corrente_id = @id;";
            command.Parameters.AddWithValue("@id", numero);
            var reader = command.ExecuteReader();
            ContaCorrente conta = null;
            String cpfPessoa = null;
            while (reader.Read())
            {
                conta = new ContaCorrente()
                {
                    Numero = numero,
                    Limite = float.Parse(reader["Conta_Corrente_limite"].ToString())
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
                return new ContaDAO().PesquisarContaPorNumero(cc.Numero) as ContaCorrente;
            }
            return conta;

        }
    }
}