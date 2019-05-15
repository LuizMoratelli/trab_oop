﻿using Locar.Controllers;
using Locar.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locar.Views
{
    public partial class FrmConsultaVendedores : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmConsultaVendedores(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            Dgw.DataSource = VendedorDB.getConsultaVendedores(conexao);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            long cpf = (long)Dgw.CurrentRow.Cells[0].Value;
            bool excluiu = VendedorDB.setExcluiVendedor(conexao, cpf);

            if (excluiu)
            {
                MessageBox.Show("Vendedor excluído com sucesso!");
                atualizaTela();
            }
            else
            {
                MessageBox.Show("Não foi possível excluir o vendedor");
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmNovoVendedor form = new FrmNovoVendedor(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            long cpf = Convert.ToInt64(Dgw.CurrentRow.Cells[0].Value);
            FrmAlteraVendedor form = new FrmAlteraVendedor(conexao, cpf);
            form.ShowDialog();
            atualizaTela();
        }
    }
}
