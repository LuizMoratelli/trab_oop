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
    public partial class FrmNovoCarro : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmNovoCarro(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string nome = TbNome.Text;
            string descricao = TbDescricao.Text;
            string data_aquisicao = TbDataAquisicao.Text;

            Carro carro = new Carro(nome, descricao, data_aquisicao);
            bool incluiu = CarroDB.setIncluiCarro(conexao, carro);

            if (incluiu)
            {
                MessageBox.Show("Carro incluído com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar incluir um novo carro.");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TbDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TbDataAquisicao_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
