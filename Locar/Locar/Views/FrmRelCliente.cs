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
    /// <summary>
    /// Relatório de clientes
    /// </summary>
    public partial class FrmRelCliente : Form
    {
        internal NpgsqlConnection conexao;

        /// <summary>
        /// Inicialização do relatório
        /// </summary>
        /// <param name="conexao"></param>
        public FrmRelCliente(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
            InitializeComponent();
        }

        private void FrmRelCliente_Load(object sender, EventArgs e)
        {
            ClienteBindingSource.DataSource = ClienteDB.getConsultaClientes(conexao);
            this.RVCliente.RefreshReport();
        }
    }
}
