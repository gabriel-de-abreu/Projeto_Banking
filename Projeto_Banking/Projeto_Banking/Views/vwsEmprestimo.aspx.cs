﻿using Projeto_Banking.Models;
using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsEmprestimo : System.Web.UI.Page
    {
        ContaCorrente cc;
        DateTime dataMinima = DateTime.Today.AddDays(1);
        DateTime dataMaxima = DateTime.Today.AddMonths(1);
        DateTime data;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;

            if (cc == null)
            {
                Response.Redirect("~/Views/vwLogin.aspx");
            }

            lblDataVencimento.Text = " (entre " + dataMinima.ToString("dd/MM/yyyy") + " e " + dataMaxima.ToString("dd/MM/yyyy") + ")"; //exibe data limites para o primeiro vencimento

            divResultado.Visible = false;

            if (!IsPostBack)
            {
                divSimulacao.Visible = false;
                txtDataPrimeiroVencimento.Text = dataMinima.ToString("yyyy-MM-dd");
            }
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {
            float valorDesejado;
            int parcelas;

            
            string tipoPagamento = rblPagamento.SelectedValue;

            if (!DateTime.TryParse(txtDataPrimeiroVencimento.Text, out data))
            {   //verifica data
                lblAviso.Text = "Escolha uma data válida!";
                divSimulacao.Visible = false;

            }
            else if (float.TryParse(txtValor.Text, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas) && dataMinima <= data && dataMaxima >= data && parcelas > 0)
            {
                if (valorDesejado > cc.Limite)
                {
                    lblAviso.Text = "Valor é superior ao limite disponível em sua conta!";
                }
                else if (valorDesejado > 0)
                {
                    Taxa taxa = new TaxaDAO().PesquisarPorTaxa(EmprestimoOPS.VerificarPerfil(cc)); //obtem taxa atraves do perfil da pessoa

                    Emprestimo emprestimo = new Emprestimo()
                    {
                        Valor = valorDesejado,
                        Parcelas = parcelas,
                        ContaCorrente = cc,
                        Taxa = taxa,
                        DataInicio = data,
                    };

                    EmprestimoDAO empDAO = new EmprestimoDAO();
                    if (empDAO.InserirEmprestimo(emprestimo, tipoPagamento))
                    {
                        lblResultado.Text = "Empréstimo Realizado com Sucesso!";
                        divResultado.Visible = true;
                        divRealizarBtn.Visible = false;
                    }
                }
                else
                {
                    divSimulacao.Visible = false;
                    lblAviso.Text = "Valor precisa ser maior que zero!";
                }
            }
            else
            {
                divSimulacao.Visible = false;
                lblAviso.Text = "Dados incorretos!";
            }

        }

        protected void btnSimular_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";

            double valorDesejado, valorParcela, valorTotal;
            int parcelas;

            
            if (!DateTime.TryParse(txtDataPrimeiroVencimento.Text, out data))
            {   //verifica data
                lblAviso.Text = "Escolha uma data válida!";
                divSimulacao.Visible = false;

            }
            else if (Double.TryParse(txtValor.Text, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out valorDesejado) 
                && Int32.TryParse(txtParcelas.Text, out parcelas) && dataMinima <= data && dataMaxima >= data)

            {
                if (valorDesejado > cc.Limite)
                {
                    lblAviso.Text = "Valor é superior ao limite disponível em sua conta!";
                }

                else if (valorDesejado > 0)
                {
                    divSimulacao.Visible = true;
                    divRealizarBtn.Visible = true;

                    Taxa taxa = new TaxaDAO().PesquisarPorTaxa(EmprestimoOPS.VerificarPerfil(cc)); //obtem taxa atraves do perfil da pessoa

                    valorParcela = EmprestimoOPS.CalcularParcelas(parcelas, taxa, valorDesejado); //calcula valor das parcelas 
                    valorTotal = valorParcela * parcelas;

                    lblParcelas.Text = parcelas.ToString();
                    lblValor.Text = valorParcela.ToString("c2");
                    lblValorTotal.Text = valorTotal.ToString("c2");
                    lblTaxa.Text = taxa.Valor.ToString("F") + " % a.m.";
                }
                else
                {
                    divSimulacao.Visible = false;
                    lblAviso.Text = "Valor precisa ser maior que zero!";
                }

            }
            else
            {
                divSimulacao.Visible = false;
                lblAviso.Text = "Dados incorretos!";
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/vwsConsultarEmprestimos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDataPrimeiroVencimento.Text = dataMinima.ToString("yyyy-MM-dd");
            divSimulacao.Visible = false;
        }
    }
}