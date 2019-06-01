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
    public partial class FrmNovoVendedor : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmNovoVendedor(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string cpf = TbCpf.Text;
            string nome = TbNome.Text;
            int qtd_vendas = Convert.ToInt16(TbQtdVendas.Text);

            Vendedor vendedor = new Vendedor(cpf, nome, qtd_vendas);
            bool incluiu = VendedorDB.setIncluiVendedor(conexao, vendedor);

            if (incluiu)
            {
                MessageBox.Show("Vendedor incluído com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar incluir um novo vendedor.");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
