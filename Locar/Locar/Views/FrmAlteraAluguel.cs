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

            Carro carro = CarroDB.getCarro(conexao, aluguel.carro_id);
            CBCarro.DataSource = CarroDB.getConsultaCarros(conexao);
            CBCarro.SelectedIndex = CarroDB.getIndexCarro(conexao, carro);

            Cliente cliente = ClienteDB.getCliente(conexao, aluguel.cliente_id);
            CBCliente.DataSource = ClienteDB.getConsultaClientes(conexao);
            CBCliente.SelectedIndex = ClienteDB.getIndexCliente(conexao, cliente);

            Vendedor vendedor = VendedorDB.getVendedor(conexao, aluguel.vendedor_id);
            CBVendedor.DataSource = VendedorDB.getConsultaVendedores(conexao);
            CBVendedor.SelectedIndex = VendedorDB.getIndexVendedor(conexao, vendedor);

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
            int carro_id = CarroDB.getIndexCarro(conexao, CBCarro.SelectedIndex).id;
            long cliente_id = ClienteDB.getIndexCliente(conexao, CBCliente.SelectedIndex).cpf;
            long vendedor_id = VendedorDB.getIndexVendedor(conexao, CBVendedor.SelectedIndex).cpf;
            string data_inicio = TBDataInicio.Text;
            string data_fim = TBDataFim.Text;
            Console.WriteLine(data_inicio);
            Console.WriteLine(data_fim);

            Aluguel aluguel = new Aluguel(id, carro_id, cliente_id, vendedor_id, data_inicio, data_fim);
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
