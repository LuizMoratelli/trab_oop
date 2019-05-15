using Locar.Controllers;
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
    public partial class FrmConsultaCarros : Form
    {
        internal NpgsqlConnection conexao = null;

        public FrmConsultaCarros(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
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

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            int id= (int)Dgw.CurrentRow.Cells[0].Value;
            FrmAlteraCarro form = new FrmAlteraCarro(conexao, id);
            form.ShowDialog();
            atualizaTela();
        }
    }
}
