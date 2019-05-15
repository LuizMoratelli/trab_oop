using Locar.Models;
using Npgsql;
using System;
using System.Collections;
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
        public static int getIndexCarro(NpgsqlConnection conexao, Carro carro)
        {
            ArrayList carros = getConsultaCarros(conexao);
            int i = 0;

            foreach (Carro dataCarro in carros)
            {
                if (dataCarro.id == carro.id)
                {
                    return i;
                }

                i++;
            }

            return 0;

        }

        public static Carro getIndexCarro(NpgsqlConnection conexao, int id) {
            ArrayList carros = getConsultaCarros(conexao);
            return (Carro) carros[id];
        }

        public static Carro getCarro(NpgsqlConnection conexao, int id)
        {
            Carro carro = null;

            try
            {
                string sql = "SELECT * FROM carro WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                carro = new Carro(id, (string)dr["nome"], (string)dr["descricao"], Convert.ToString(dr["data_aquisicao"]));
                dr.Close();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return carro;
        }

        public static ArrayList getConsultaCarros(NpgsqlConnection conexao)
        {
            ArrayList lista = new ArrayList();
            try
            {
                string sql = "SELECT * FROM carro";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Carro carro = new Carro(
                        (int)dr["id"],
                        (string)dr["nome"],
                        (string)dr["descricao"],
                        Convert.ToString(dr["data_aquisicao"])
                    );
                    lista.Add(carro);
                }
                dr.Close();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return lista;
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
