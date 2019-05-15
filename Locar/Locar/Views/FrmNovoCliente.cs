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
    public partial class FrmNovoCliente : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmNovoCliente(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            long cpf = Convert.ToInt64(TbCpf.Text);
            string nome = TbNome.Text;
            string data_nascimento = TbDataNascimento.Text;

            Cliente cliente = new Cliente(cpf, nome, data_nascimento);
            bool incluiu = ClienteDB.setIncluiCliente(conexao, cliente);

            if (incluiu)
            {
                MessageBox.Show("Cliente incluído com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar incluir um novo cliente.");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
