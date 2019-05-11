﻿using Locar.Controllers;
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
    }
}
