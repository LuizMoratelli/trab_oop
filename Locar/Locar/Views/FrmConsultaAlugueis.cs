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
    public partial class FrmConsultaAlugueis : Form
    {
        internal NpgsqlConnection conexao = null;

        public FrmConsultaAlugueis(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            Dgw.DataSource = AluguelDB.getConsultaAlugueis(conexao);
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmNovoAluguel form = new FrmNovoAluguel(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Dgw.CurrentRow.Cells[0].Value);
            FrmAlteraAluguel form = new FrmAlteraAluguel(conexao, id);
            form.ShowDialog();
            atualizaTela();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            int id = (int)Dgw.CurrentRow.Cells[0].Value;
            bool excluiu = AluguelDB.setExcluiAluguel(conexao, id);

            if (excluiu)
            {
                MessageBox.Show("Aluguel excluído com sucesso!");
                atualizaTela();
            }
            else
            {
                MessageBox.Show("Não foi possível excluir o aluguel");
            }
        }
    }
}
