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
    /// <summary>
    /// Formulário de alteração do <see cref="Cliente"/>
    /// </summary>
    public partial class FrmAlteraCliente : Form
    {
        internal NpgsqlConnection conexao = null;

        /// <summary>
        /// Inicialização do formulário
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="id"></param>
        public FrmAlteraCliente(NpgsqlConnection conexao, int id)
        {
            InitializeComponent();
            this.conexao = conexao;
            TbId.Text = Convert.ToString(id);
            buscaCliente();
        }

        private void buscaCliente()
        {
            Cliente cliente = ClienteDB.getCliente(conexao, Convert.ToInt32(TbId.Text));
            TbCpf.Text = cliente.cpf;
            TbNome.Text = cliente.nome;
            TbDataNascimento.Text = Convert.ToDateTime(cliente.data_nascimento).ToString("dd/MM/yyyy");
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
            string data_nascimento = TbDataNascimento.Text;
            Cliente cliente = new Cliente(id, cpf, nome, data_nascimento);
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
