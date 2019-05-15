using Locar.Controllers;
using Locar.Views;
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
    public partial class FrmPrincipal : Form
    {
        public NpgsqlConnection conexao = null;
        public FrmPrincipal()
        {
            InitializeComponent();
            conexao = Conexao.getConexao();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conexao.setFechaConexao(conexao);
        }

        private void BtnCarros_Click(object sender, EventArgs e)
        {
            FrmConsultaCarros form = new FrmConsultaCarros(conexao);
            form.Show();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmConsultaClientes form = new FrmConsultaClientes(conexao);
            form.Show();
        }

        private void BtnVendedores_Click(object sender, EventArgs e)
        {
            FrmConsultaVendedores form = new FrmConsultaVendedores(conexao);
            form.Show();
        }

        private void BtnAlugueis_Click(object sender, EventArgs e)
        {
            FrmConsultaAlugueis form = new FrmConsultaAlugueis(conexao);
            form.Show();
        }
    }
}
