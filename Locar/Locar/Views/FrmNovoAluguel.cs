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
using System.Collections;

namespace Locar.Views
{
    /// <summary>
    /// Formulário de novo <see cref="Aluguel"/>
    /// </summary>
    public partial class FrmNovoAluguel : Form
    {
        internal NpgsqlConnection conexao = null;

        /// <summary>
        /// Inicialização do formulário
        /// </summary>
        /// <param name="conexao"></param>
        public FrmNovoAluguel(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            carregaCampos();
        }

        private void carregaCampos()
        {
            ArrayList clientes = ClienteDB.getConsultaClientes(conexao);
            CBCliente.DataSource = clientes;

            ArrayList carros = CarroDB.getConsultaCarros(conexao);
            CBCarro.DataSource = carros;

            ArrayList vendedores = VendedorDB.getConsultaVendedores(conexao);
            CBVendedor.DataSource = vendedores;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Carro carro = (Carro)CBCarro.SelectedItem;
            Cliente cliente = (Cliente)CBCliente.SelectedItem;
            Vendedor vendedor = (Vendedor)CBVendedor.SelectedItem;
            string data_inicio = TBDataInicio.Text;
            string data_fim = TBDataFim.Text;

            Aluguel aluguel = new Aluguel(carro, cliente, vendedor, data_inicio, data_fim);
            bool incluiu = AluguelDB.setIncluiAluguel(conexao, aluguel);

            if (incluiu)
            {
                MessageBox.Show("Aluguel incluído com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar incluir um novo aluguel.");
            }
        }
    }
}
