using Locar.Controllers;
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
    public partial class FrmRelVendedor : Form
    {
        internal NpgsqlConnection conexao;
        public FrmRelVendedor(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
            InitializeComponent();
        }

        private void FrmRelVendedor_Load(object sender, EventArgs e)
        {
            VendedorBindingSource.DataSource = VendedorDB.getConsultaVendedores(conexao);
            this.RVVendedor.RefreshReport();
        }
    }
}
