using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locar.Controllers
{
    /// <summary>
    /// Realiza a conexão com o banco de dados PostgreSQL
    /// </summary>
    public class Conexao
    {
        /// <summary>
        /// Realiza a conexão através dos dados de acesso definidos
        /// </summary>
        /// <returns>Conexão com o banco de dados</returns>
        public static NpgsqlConnection getConexao()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=;Database=locar");
                conexao.Open();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return conexao;
        }

        /// <summary>
        /// Encerra a <paramref name="conexao"/>
        /// </summary>
        /// <param name="conexao"></param>
        public static void setFechaConexao(NpgsqlConnection conexao)
        {
            if (conexao != null)
            {
                try
                {
                    conexao.Close();
                }
                catch (NpgsqlException e)
                {
                    MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");

                }
            }
        }
    }
}
