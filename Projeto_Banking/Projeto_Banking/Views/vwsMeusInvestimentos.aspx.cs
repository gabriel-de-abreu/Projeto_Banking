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
            dt.Columns.Add("Investimento_Inicio_Formatado", typeof(String));
            dt.Columns.Add("Investimento_Fim_Formatado", typeof(String));
            dt.Columns.Add("Investimento_Resgate_Formatado", typeof(String));
            dt.Columns.Add("Investimento_Conta_Valor_Formatado", typeof(String));
            foreach (DataRow row in dt.Rows)
            {
                row["Investimento_Inicio_Formatado"] = Convert.ToDateTime(row["Investimento_Inicio"]).ToString("dd/MM/yyyy");
                row["Investimento_Fim_Formatado"] = Convert.ToDateTime(row["Investimento_Fim"]).ToString("dd/MM/yyyy");
                row["Investimento_Resgate_Formatado"] = (Convert.ToBoolean(row["Investimento_Resgate"])) ? ("Sim") : ("Não");
                row["Investimento_Conta_Valor_Formatado"] = Convert.ToDouble(row["Investimento_Conta_Valor"]).ToString("c2");

            }
            gdvMeusInvestimentos.DataSource = dt;
            gdvMeusInvestimentos.DataBind();
        }

        protected void gdvMeusInvestimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = gdvMeusInvestimentos.SelectedIndex;
            int id = Convert.ToInt32(gdvMeusInvestimentos.DataKeys[rowIndex].Value);
            iC = new InvestimentoDAO().BuscarInvestimento(new InvestimentoConta() { Id = id });
            Session["investimentoConta"] = iC;

            Response.Redirect("~/Views/vwsResgate.aspx");

        }
    }
}