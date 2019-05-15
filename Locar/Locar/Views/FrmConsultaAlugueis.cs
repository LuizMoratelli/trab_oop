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
            int id = (int)Dgw.CurrentRow.Cells[0].Value;
            int carro_id = (int) Dgw.CurrentRow.Cells[1].Value;
            long cliente_id = Convert.ToInt64(Dgw.CurrentRow.Cells[2].Value);
            long vendedor_id = Convert.ToInt64(Dgw.CurrentRow.Cells[3].Value);
            string data_inicio = Dgw.CurrentRow.Cells[4].Value.ToString();
            string data_fim = Dgw.CurrentRow.Cells[5].Value.ToString();

            Aluguel aluguel = new Aluguel(id, carro_id, cliente_id, vendedor_id, data_inicio, data_fim);
            bool alterou = AluguelDB.setAlteraAluguel(conexao, aluguel);

            if (alterou)
            {
                MessageBox.Show("Aluguel alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o aluguel");
                atualizaTela();
            }
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
