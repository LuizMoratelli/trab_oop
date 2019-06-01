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
    public partial class FrmAlteraAluguel : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmAlteraAluguel(NpgsqlConnection conexao, int id)
        {
            InitializeComponent();
            this.conexao = conexao;
            TBId.Text = Convert.ToString(id);
            buscaAluguel();
        }

        private void buscaAluguel()
        {
            Aluguel aluguel = AluguelDB.getAluguel(conexao, Convert.ToInt32(TBId.Text));

            CBCarro.DataSource = CarroDB.getConsultaCarros(conexao);
            CBCarro.SelectedIndex = CarroDB.getIndexCarro(conexao, aluguel.carro);

            CBCliente.DataSource = ClienteDB.getConsultaClientes(conexao);
            CBCliente.SelectedIndex = ClienteDB.getIndexCliente(conexao, aluguel.cliente);

            CBVendedor.DataSource = VendedorDB.getConsultaVendedores(conexao);
            CBVendedor.SelectedIndex = VendedorDB.getIndexVendedor(conexao, aluguel.vendedor);

            TBDataInicio.Text = aluguel.data_inicio;
            TBDataFim.Text = aluguel.data_fim;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TBId.Text);
            Carro carro = CarroDB.getIndexCarro(conexao, CBCarro.SelectedIndex);
            Cliente cliente = ClienteDB.getIndexCliente(conexao, CBCliente.SelectedIndex);
            Vendedor vendedor  = VendedorDB.getIndexVendedor(conexao, CBVendedor.SelectedIndex);
            string data_inicio = TBDataInicio.Text;
            string data_fim = TBDataFim.Text;

            Aluguel aluguel = new Aluguel(id, carro, cliente, vendedor, data_inicio, data_fim);
            bool alterou = AluguelDB.setAlteraAluguel(conexao, aluguel);

            if (alterou)
            {
                MessageBox.Show("Aluguel alterado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o aluguel");
            }
        }
    }
}
