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
    public partial class FrmAlteraCarro : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmAlteraCarro(NpgsqlConnection conexao, int id)
        {
            InitializeComponent();
            this.conexao = conexao;
            TbId.Text = Convert.ToString(id);
            buscaCarro();
        }

        private void buscaCarro()
        {
            Carro carro = CarroDB.getCarro(conexao, Convert.ToInt32(TbId.Text));
            TbNome.Text = carro.nome;
            TbDescricao.Text = carro.descricao;
            TbDataAquisicao.Text = Convert.ToDateTime(carro.data_aquisicao).ToString("dd/MM/yyyy");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TbId.Text);
            string nome = TbNome.Text;
            string descricao = TbDescricao.Text;
            string data_aquisicao = TbDataAquisicao.Text;
            Carro carro = new Carro(id, nome, descricao, data_aquisicao);
            bool alterou = CarroDB.setAlteraCarro(conexao, carro);

            if (alterou)
            {
                MessageBox.Show("Carro alterado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o carro");
            }
        }
    }
}
