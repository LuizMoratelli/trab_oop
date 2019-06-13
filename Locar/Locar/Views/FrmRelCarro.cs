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
    public partial class FrmRelCarro : Form
    {
        internal NpgsqlConnection conexao;

        public FrmRelCarro(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
            InitializeComponent();
        }

        private void FrmRelCarro_Load(object sender, EventArgs e)
        {
            CarroBindingSource.DataSource = CarroDB.getConsultaCarros(conexao);
            this.RVCarro.RefreshReport();
        }
    }
}
