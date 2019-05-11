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
    public class CarroDB
    {
        public static DataTable getConsultaCarros(NpgsqlConnection conexao)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM carro";
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

        public static bool setIncluiCarro(NpgsqlConnection conexao, Carro carro)
        {
            bool incluiu = false;

            try
            {
                string sql = "INSERT INTO carro(nome, descricao, data_aquisicao) VALUES(@nome, @descricao, @data_aquisicao)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = carro.nome;
                cmd.Parameters.Add("@descricao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = carro.descricao;
                cmd.Parameters.Add("@data_aquisicao", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(carro.data_aquisicao);

                incluiu = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return incluiu;
        }

        public static bool setExcluiCarro(NpgsqlConnection conexao, int id)
        {
            bool excluiu = false;

            try
            {
                string sql = "DELETE FROM carro WHERE id = @id";
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

        public static bool setAlteraCarro(NpgsqlConnection conexao, Carro carro)
        {
            bool alterou = false;

            try
            {
                string sql = @"UPDATE carro
                                  SET nome = @nome, descricao = @descricao, data_aquisicao = @data_aquisicao
                                WHERE id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = carro.id;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = carro.nome;
                cmd.Parameters.Add("@descricao", NpgsqlTypes.NpgsqlDbType.Varchar).Value = carro.descricao;
                cmd.Parameters.Add("@data_aquisicao", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(carro.data_aquisicao);

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
