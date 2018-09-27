using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwEmprestimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divSimulacao.Visible = false;
            }
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSimular_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";

            double valorDesejado, valorParcela, valorTotal, taxa;
            int parcelas;

            taxa = 1;

            if(Double.TryParse(txtValor.Text, out valorDesejado) && Int32.TryParse(txtParcelas.Text, out parcelas))
            {
                divSimulacao.Visible = true;

                //valorTotal = valorDesejado * (Math.Pow((1 + taxa), parcelas));
                //valorParcela = valorTotal / parcelas;
                
                //lblResultado.Text = "Número de Parcelas: " + parcelas + "\nValor da parcela: R$ " + valorParcela + "\nValor Total: R$" + valorTotal;
            }
            else
            {
                lblAviso.Text = "Dados incorretos!";
            }
        }
        
    }
}