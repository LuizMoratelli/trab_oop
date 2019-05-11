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

namespace Locar
{
    public partial class FrmConsultaClientes : Form
    {
        internal NpgsqlConnection conexao = null;
        public FrmConsultaClientes(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            Dgw.DataSource = ClienteDB.getConsultaClientes(conexao);
        } 
    }
}
