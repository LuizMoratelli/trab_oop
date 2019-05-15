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
        public FrmAlteraVendedor(NpgsqlConnection conexao, long cpf)
        {
            InitializeComponent();
            this.conexao = conexao;
            TbCpf.Text = Convert.ToString(cpf);
            buscaVendedor();
        }

        private void buscaVendedor()
        {
            Vendedor vendedor = VendedorDB.getVendedor(conexao, Convert.ToInt64(TbCpf.Text));
            TbNome.Text = vendedor.nome;
            TbQtdVendas.Text = Convert.ToString(vendedor.qtd_vendas);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            long cpf = Convert.ToInt64(TbCpf.Text);
            string nome = TbNome.Text;
            int qtd_vendas = Convert.ToInt32(TbQtdVendas.Text);

            Vendedor vendedor = new Vendedor(cpf, nome, qtd_vendas);
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
