using Projeto_Banking.Models;
using Projeto_Banking.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Banking.Views
{
    public partial class vwsExtrato : System.Web.UI.Page
    {
        ContaCorrente cc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["contaCorrente"] != null)
            {
                cc = Session["contaCorrente"] as ContaCorrente;
                PopularGrid();
            }
            else
            {
                Response.Redirect("~/Views/vwsLogin.aspx");
            }
        }

        public void PopularGrid()
        {
            MovimentacaoDAO movDao = new MovimentacaoDAO();
            DataTable dTable = movDao.BuscarExtratosConta(cc);

            gdvExtrato.DataSource = dTable;
            gdvExtrato.DataBind();
        }

    }
}