using Locar.Models;
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

        public static bool setExcluiAluguel(NpgsqlConnection conexao, int id)
        {
            bool excluiu = false;

            try
            {
                string sql = "DELETE FROM aluguel WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                excluiu = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return excluiu;
        }

        public static bool setIncluiAluguel(NpgsqlConnection conexao, Aluguel aluguel)
        {
            bool incluiu = false;

            try
            {
                string sql = "INSERT INTO aluguel(carro_id, cliente_id, vendedor_id, data_inicio, data_fim)" +
                                          "VALUES(@carro_id, @cliente_id, @vendedor_id, @data_inicio, @data_fim)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@carro_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.carro_id;
                cmd.Parameters.Add("@cliente_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.cliente_id;
                cmd.Parameters.Add("@vendedor_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.vendedor_id;
                cmd.Parameters.Add("@data_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(aluguel.data_inicio);
                cmd.Parameters.Add("@data_fim", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(aluguel.data_fim);

                incluiu = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return incluiu;
        }

        public static bool setAlteraAluguel(NpgsqlConnection conexao, Aluguel aluguel)
        {
            bool alterou = false;

            try
            {
                string sql = @"UPDATE aluguel
                                  SET carro_id = @carro_id, cliente_id = @cliente_id, vendedor_id = @vendedor_id
                                      data_inicio = @data_inicio, data_fim = @data_fim
                                WHERE id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.id;
                cmd.Parameters.Add("@carro_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = aluguel.carro_id;
                cmd.Parameters.Add("@cliente_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = aluguel.cliente_id;
                cmd.Parameters.Add("@vendedor_id", NpgsqlTypes.NpgsqlDbType.Varchar).Value = aluguel.vendedor_id;
                cmd.Parameters.Add("@data_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(aluguel.data_inicio);
                cmd.Parameters.Add("@data_fim", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(aluguel.data_fim);

                alterou = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return alterou;
        }
    }
}
