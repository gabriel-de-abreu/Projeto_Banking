using MySql.Data.MySqlClient;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banking.Models.ContaDAOs
{
    public class ContaDAO
    {
        public Conta PesquisarContaPorNumero(int numero)
        {
            float saldo = 0;
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = "SELECT * FROM projetobanking.conta WHERE Conta_id = @id;";
            command.Parameters.AddWithValue("@id", numero);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                saldo = float.Parse(reader["Conta_saldo"].ToString());
            }
            reader.Close();

            ContaCorrente cc = new ContaCorrenteDAO().PesquisarPorNumero(numero);
            if (cc != null)
            {
                cc.Saldo = saldo;
                return cc;
            }

            ContaContabilEmprestimo cce = new ContaContabilEmprestimoDAO().PesquisarContaContabilEmprestimo(numero);
            if (cce != null)
            {
                return new ContaContabilEmprestimo()
                {
                    Numero = numero,
                    Saldo = saldo
                };
            }
            ContaContabilInvestimento cci = new ContaContabilInvestimentoDAO().PesquisarContaContabilInvestimento(numero);
            if (cci != null)
            {
                return new ContaContabilInvestimento()
                {
                    Numero = numero,
                    Saldo = saldo
                };
            }
            return null;
        }

        public Conta ContaAtualizarSaldo(Conta conta, float valor)
        {
            if (conta==null) return null;
            Conta contaAux = PesquisarContaPorNumero(conta.Numero);
            contaAux.Saldo += valor;
            MySqlCommand command = Connection.Instance.CreateCommand();
            command.CommandText = $"UPDATE `projetobanking`.`conta` SET `Conta_id` = {conta.Numero} , `Conta_saldo` = @saldo" +
                $" WHERE `Conta_id` = {conta.Numero};";
            command.Parameters.AddWithValue("@saldo", (float)contaAux.Saldo);

            return command.ExecuteNonQuery() > 0 ? contaAux : null;
        }

        public List<Conta> Transferir(Conta origem, Conta destino, float valor, String descricao)
        {
            if (origem != null)
            {
                if (ContaAtualizarSaldo(origem, (valor * -1)) != null && ContaAtualizarSaldo(destino, valor) != null)
                {
                    List<Conta> contas = new List<Conta>();
                    origem.Saldo -= valor;
                    destino.Saldo += valor;
                    contas.Add(origem);
                    contas.Add(destino);
                    Movimentacao log = new Movimentacao()
                    {
                        Data = DateTime.Now,
                        Destino = destino,
                        Origem = origem,
                        Valor = valor,
                        Descricao = descricao
                    };
                    new MovimentacaoDAO().InsererMovimentacao(log);
                    return contas;
                }
            }
            else
            {
                if (ContaAtualizarSaldo(destino, valor) != null)
                {
                    List<Conta> contas = new List<Conta>();
                    destino.Saldo += valor;
                    contas.Add(destino);
                    Movimentacao log = new Movimentacao()
                    {
                        Data = DateTime.Now,
                        Destino = destino,
                        Origem = origem,
                        Valor = valor,
                        Descricao = descricao
                    };
                    new MovimentacaoDAO().InsererMovimentacao(log);
                    return contas;
                }
            }
            return null;
        }
    }
}