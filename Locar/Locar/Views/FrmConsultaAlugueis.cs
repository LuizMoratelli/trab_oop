using Locar.Controllers;
using Locar.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;

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
            ArrayList alugueis = AluguelDB.getConsultaAlugueis(conexao);

            Dgw.Columns.Add("ID", "ID");
            Dgw.Columns.Add("Carro", "Carro");
            Dgw.Columns.Add("Cliente", "Cliente");
            Dgw.Columns.Add("Vendedor", "Vendedor");
            Dgw.Columns.Add("Data Início", "Data Início");
            Dgw.Columns.Add("Data Fim", "Data Fim");

            Dgw.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                Dgw.Rows.Add(
                    aluguel.id,
                    CarroDB.getCarro(conexao, aluguel.carro_id),
                    ClienteDB.getCliente(conexao, aluguel.cliente_id),
                    VendedorDB.getVendedor(conexao, aluguel.vendedor_id),
                    aluguel.data_inicio,
                    aluguel.data_fim
                );
            }
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
