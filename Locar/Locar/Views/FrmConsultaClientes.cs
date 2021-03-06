﻿using Locar.Controllers;
using Locar.Models;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locar.Views
{
    /// <summary>
    /// Formulário de consulta <see cref="Cliente"/>
    /// </summary>
    public partial class FrmConsultaClientes : Form
    {
        internal NpgsqlConnection conexao = null;

        /// <summary>
        /// Inicialização do formulário
        /// </summary>
        /// <param name="conexao"></param>
        public FrmConsultaClientes(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            CBCampo.DataSource = ClienteDB.getAllProperties();
            CBTipo.DataSource = new Consulta().tipos;
            CBTipo.SelectedItem = CBTipo.Items[0];
            Dgw.DataSource = ClienteDB.getConsultaClientes(conexao);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (Dgw.RowCount != 0)
            {
                int id = (int)Dgw.CurrentRow.Cells[0].Value;
                bool excluiu = ClienteDB.setExcluiCliente(conexao, id);

                if (excluiu)
                {
                    MessageBox.Show("Cliente excluído com sucesso!");
                    atualizaTela();
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir o cliente");
                }
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmNovoCliente form = new FrmNovoCliente(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (Dgw.RowCount != 0)
            {
                int id = Convert.ToInt32(Dgw.CurrentRow.Cells[0].Value);
                FrmAlteraCliente form = new FrmAlteraCliente(conexao, id);
                form.ShowDialog();
                atualizaTela();
            }
        }

        private void Consulta()
        {
            Consulta consulta = new Consulta(CBCampo.SelectedValue.ToString(), CBTipo.SelectedIndex, TBValor.Text);
            Dgw.DataSource = ClienteDB.getConsultaClientes(conexao, consulta);
        }

        private void TBValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Consulta();
            }
        }
    }
}
