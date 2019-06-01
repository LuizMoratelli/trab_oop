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
            int id = (int)Dgw.CurrentRow.Cells[0].Value;
            bool excluiu = VendedorDB.setExcluiVendedor(conexao, id);

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
            int id = Convert.ToInt32(Dgw.CurrentRow.Cells[0].Value);
            FrmAlteraVendedor form = new FrmAlteraVendedor(conexao, id);
            form.ShowDialog();
            atualizaTela();
        }
    }
}
