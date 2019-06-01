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
    public partial class FrmAlteraVendedor : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmAlteraVendedor(NpgsqlConnection conexao, int id)
        {
            InitializeComponent();
            this.conexao = conexao;
            TbId.Text = Convert.ToString(id);
            buscaVendedor();
        }

        private void buscaVendedor()
        {
            Vendedor vendedor = VendedorDB.getVendedor(conexao, Convert.ToInt32(TbId.Text));
            TbCpf.Text = vendedor.cpf;
            TbNome.Text = vendedor.nome;
            TbQtdVendas.Text = Convert.ToString(vendedor.qtd_vendas);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TbId.Text);
            string cpf = TbCpf.Text;
            string nome = TbNome.Text;
            int qtd_vendas = Convert.ToInt32(TbQtdVendas.Text);

            Vendedor vendedor = new Vendedor(id, cpf, nome, qtd_vendas);
            bool alterou = VendedorDB.setAlteraVendedor(conexao, vendedor);

            if (alterou)
            {
                MessageBox.Show("Vendedor alterado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o vendedor");
            }
        }
    }
}
