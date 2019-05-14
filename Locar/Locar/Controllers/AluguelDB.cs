using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locar.Controllers
{
    public class AluguelDB
    {
        public static DataTable getConsultaAlugueis(NpgsqlConnection conexao)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT  * FROM aluguel";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataAdapter dat = new NpgsqlDataAdapter(cmd);
                dat.Fill(dt);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return dt;
        }
    }
}
