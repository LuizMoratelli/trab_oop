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

namespace Locar
{
    public partial class FrmConsultaClientes : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmConsultaClientes(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            Dgw.DataSource = ClienteDB.getConsultaClientes(conexao);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            long cpf = (long)Dgw.CurrentRow.Cells[0].Value;
            bool excluiu = ClienteDB.setExcluiCliente(conexao, cpf);

            if (excluiu)
            {
                MessageBox.Show("Cliente excluído com sucesso!");
                atualizaTela();
            }
            else
            {
                MessageBox.Show("Não foi possível excluir o cliente");
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmNovoCliente form = new FrmNovoCliente(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            long cpf = (long)Dgw.CurrentRow.Cells[0].Value;
            string nome = Dgw.CurrentRow.Cells[1].Value.ToString();
            string data_nascimento = Dgw.CurrentRow.Cells[2].Value.ToString();
            Cliente cliente = new Cliente(cpf, nome, data_nascimento);
            bool alterou = ClienteDB.setAlteraCliente(conexao, cliente);

            if (alterou)
            {
                MessageBox.Show("Cliente alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o cliente");
                atualizaTela();
            }
        }
    }
}
