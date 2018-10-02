using Projeto_Banking.Models;
using Projeto_Banking.Models.ContaDAOs;
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
    public partial class vwsMeusInvestimentos : System.Web.UI.Page
    {
        int numeroConta = -1;
        ContaCorrente cc; InvestimentoConta iC;
        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            if (cc == null) Response.Redirect("~/Views/vwsLogin.aspx");
            numeroConta = cc.Numero;
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            InvestimentoDAO investimentoDAO = new InvestimentoDAO();
            DataTable dt = investimentoDAO.BuscarInvestimentosConta(cc);
            gdvMeusInvestimentos.DataSource = dt;
            gdvMeusInvestimentos.DataBind();
        }

        protected void gdvMeusInvestimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gdvMeusInvestimentos.SelectedIndex;
            int id = Convert.ToInt32(gdvMeusInvestimentos.DataKeys[rowIndex].Value);
            iC=new InvestimentoDAO().BuscarInvestimento(new InvestimentoConta() { Id = id });
            Session["investimentoConta"] = iC;

            //Session["contaCorrente"] = ccSession;
            //if (int.Parse(gdvMeusInvestimentos.Rows[rowIndex].Cells[6].Text) ==0 )
            //{

            Response.Redirect("~/Views/vwsRegaste.aspx");
            //}
            //else
            //{
            //    Response.Write("<script language='javascript'>alert('Este investimento já foi resgatado!');</script>");
            //}

        }
    }
}