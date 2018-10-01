﻿using Projeto_Banking.Models;
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
    public partial class vwsConsultarEmprestimos : System.Web.UI.Page
    {
        ContaCorrente cc;

        protected void Page_Load(object sender, EventArgs e)
        {
            cc = Session["contaCorrente"] as ContaCorrente;
            
            PopularGrid();
        }

        public void PopularGrid()
        {
            EmprestimoDAO empDao = new EmprestimoDAO();
            DataTable dTable = empDao.PesquisarEmprestimosContaCorrente(cc);
            //criar query SELECT * FROM emprestimo INNER JOIN taxa ON Taxa_Taxa_id=Taxa_id where Conta_Corrente_Conta_Conta_Corrente_id =

            gdvEmprestimos.DataSource = dTable;
            gdvEmprestimos.DataBind();
        }
    }
}