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
    public partial class FrmAlteraCliente : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmAlteraCliente(NpgsqlConnection conexao, long cpf)
        {
            InitializeComponent();
            this.conexao = conexao;
            TbCpf.Text = Convert.ToString(cpf);
            buscaCliente();
        }

        private void buscaCliente()
        {
            Cliente cliente = ClienteDB.getCliente(conexao, Convert.ToInt64(TbCpf.Text));
            TbNome.Text = cliente.nome;
            TbDataNascimento.Text = cliente.data_nascimento;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            long cpf = Convert.ToInt64(TbCpf.Text);
            string nome = TbNome.Text;
            string data_nascimento = TbDataNascimento.Text;
            Cliente cliente = new Cliente(cpf, nome, data_nascimento);
            bool alterou = ClienteDB.setAlteraCliente(conexao, cliente);

            if (alterou)
            {
                MessageBox.Show("Cliente alterado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o cliente");
            }
        }
    }
}
