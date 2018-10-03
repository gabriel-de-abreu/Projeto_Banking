using Projeto_Banking.Models.Opecacoes.EmprestimoDAOs;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PagamentoBoleto pagamentoBoleto = new PagamentoDAO().BuscarPagamentoPorId(Convert.ToInt32(Session["Pag_Boleto_id"])) as PagamentoBoleto;
            Label1.Text = pagamentoBoleto.ToString();
        }
    }
}