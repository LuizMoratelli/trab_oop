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

namespace Locar
{
    public partial class FrmNovoAluguel : Form
    {
        internal NpgsqlConnection conexao = null;
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
    }
}
