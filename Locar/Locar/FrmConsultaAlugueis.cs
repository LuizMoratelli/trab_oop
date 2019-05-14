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
    public partial class FrmConsultaAlugueis : Form
    {
        internal NpgsqlConnection conexao = null;

        public FrmConsultaAlugueis(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            Dgw.DataSource = AluguelDB.getConsultaAlugueis(conexao);
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FrmNovoAluguel form = new FrmNovoAluguel(conexao);
            form.ShowDialog();
            atualizaTela();
        }
    }
}
