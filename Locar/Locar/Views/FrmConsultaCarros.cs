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
    /// Formulário de consulta do <see cref="Carro"/>
    /// </summary>
    public partial class FrmConsultaCarros : Form
    {
        internal NpgsqlConnection conexao = null;

        /// <summary>
        /// Inicialização do formulário
        /// </summary>
        /// <param name="conexao"></param>
        public FrmConsultaCarros(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            CBCampo.DataSource = CarroDB.getAllProperties();
            CBTipo.DataSource = new Consulta().tipos;
            CBTipo.SelectedItem = CBTipo.Items[0];
            Dgw.DataSource = CarroDB.getConsultaCarros(conexao);
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmNovoCarro form = new FrmNovoCarro(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (Dgw.RowCount != 0)
            {
                int id = (int) Dgw.CurrentRow.Cells[0].Value;
                bool excluiu = CarroDB.setExcluiCarro(conexao, id);

                if (excluiu)
                {
                    MessageBox.Show("Carro excluído com sucesso!");
                    atualizaTela();
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir o carro");
                }
            }
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (Dgw.RowCount != 0)
            {
                int id = (int)Dgw.CurrentRow.Cells[0].Value;
                FrmAlteraCarro form = new FrmAlteraCarro(conexao, id);
                form.ShowDialog();
                atualizaTela();
            }
        }

        private void Consulta()
        {
            Consulta consulta = new Consulta(CBCampo.SelectedValue.ToString(), CBTipo.SelectedIndex, TBValor.Text);
            Dgw.DataSource = CarroDB.getConsultaCarros(conexao, consulta);
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
