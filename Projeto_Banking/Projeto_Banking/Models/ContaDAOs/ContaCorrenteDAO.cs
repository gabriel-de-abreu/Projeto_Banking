using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using Projeto_Banking.Utils;
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
                    Limite = float.Parse(reader["Conta_Corrente_limite"].ToString()),

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

        public bool AtualizarLimite(int numeroCC, float valor)
        {

            ContaCorrente cc = PesquisarPorNumero(numeroCC);
            cc.Limite += valor;

            MySqlCommand command = Connection.Instance.CreateCommand();

            command.CommandText = $"UPDATE conta_corrente SET Conta_Corrente_limite = @limite" +
                $" WHERE `Conta_Conta_Corrente_id` = {cc.Numero};";
            command.Parameters.AddWithValue("@limite", (float)cc.Limite);

            if (command.ExecuteNonQuery() == 1) return true;
            else return false;
        }

        public ContaCorrente InserirContaCorrente(ContaCorrente conta)
        {
            // INSERT INTO `ProjetoBanking`.`Conta` (`Conta_saldo`) VALUES (0);
            // INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`, `Pessoa_Pessoa_cpf`, `Conta_Corrente_senha`) VALUES (NULL, NULL, NULL, NULL);
            new PessoaDAO().InserirPessoa(conta.Pessoa);
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = " INSERT INTO `ProjetoBanking`.`Conta` (`Conta_saldo`) VALUES (0);";
            command.ExecuteNonQuery();
            int contaID = (int)command.LastInsertedId;
            command.CommandText = "INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`, `Pessoa_Pessoa_cpf`, `Conta_Corrente_senha`)" +
                " VALUES (@id, @limite, @cpf, @senha);";
            command.Parameters.AddWithValue("@id", contaID);
            command.Parameters.AddWithValue("@limite", conta.Limite);
            command.Parameters.AddWithValue("@cpf", conta.Pessoa.Cpf);
            command.Parameters.AddWithValue("@senha", Criptografia.GerarHashMd5(conta.Senha));
            if (command.ExecuteNonQuery() > 0)
            {
                conta.Numero = contaID;
                return conta;
            }
            return null;
        }
    }
}