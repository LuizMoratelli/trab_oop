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
    /// Relatório de aluguéis
    /// </summary>
    public partial class FrmRelAluguel : Form
    {
        internal NpgsqlConnection conexao;

        /// <summary>
        /// Inicialização do relatório
        /// </summary>
        /// <param name="conexao"></param>
        public FrmRelAluguel(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
            InitializeComponent();
        }

        private void FrmRelAluguel_Load(object sender, EventArgs e)
        {
            AluguelBindingSource.DataSource = AluguelDB.getConsultaAlugueis(conexao);
            this.RVAlugueis.RefreshReport();
        }
    }
}
