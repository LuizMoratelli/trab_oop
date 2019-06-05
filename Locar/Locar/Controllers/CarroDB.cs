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
    /// <summary>
    /// Realiza a busca das informações do banco de dados do modelo <see cref="Carro"/>
    /// </summary>
    public class CarroDB
    {
        /// <summary>
        /// Realiza a busca de um determinado <see cref="Carro"/> de acordo com o banco de dados e retorna a respectiva posição
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="carro"></param>
        /// <returns>Retorna o indice de um <see cref="Carro"/> na listagem</returns>
        public static int getIndexCarro(NpgsqlConnection conexao, Carro carro)
        {
            ArrayList carros = getConsultaCarros(conexao);
            int i = 0;

            foreach (Carro dadosCarro in carros)
            {
                if (dadosCarro.id == carro.id)
                {
                    return i;
                }

                i++;
            }

            return 0;

        }

        /// <summary>
        /// Realiza a busca de um determinado <see cref="Carro"/> de acordo com o respectivo <paramref name="id"/> e retorna o modelo do banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="id"></param>
        /// <returns><see cref="Carro"/> de determinado <paramref name="id"/></returns>
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

        /// <summary>
        /// Realiza a busca dos <see cref="Carro"/> que satisfaçam a <paramref name="consulta"/>
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="consulta"></param>
        /// <returns>Lista de <see cref="Carro"/> com os filtros da <paramref name="consulta"/></returns>
        public static ArrayList getConsultaCarros(NpgsqlConnection conexao, Consulta consulta = null)
        {
            ArrayList lista = new ArrayList();
            try
            {
                string sql = "SELECT * FROM carro";
                
                if (consulta != null)
                {
                    sql += $" WHERE {consulta.getCondicao()}";
                }

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Carro carro = new Carro(
                        (int)dr["id"],
                        (string)dr["nome"],
                        (string)dr["descricao"],
                        Convert.ToDateTime(dr["data_aquisicao"]).ToString("dd/MM/yyyy")
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

        /// <summary>
        /// Realiza a inserção do novo <see cref="Carro"/> no banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="carro"></param>
        /// <returns>Verdadeiro se conseguiu incluir, falso se não</returns>
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

        /// <summary>
        /// Realiza a remoção de determinado <see cref="Carro"/> do banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="id"></param>
        /// <returns>Verdadeiro se conseguiu incluir, falso se não</returns>
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

        /// <summary>
        /// Realiza a alteração de determinado <see cref="Carro"/> do banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="carro"></param>
        /// <returns>Verdadeiro se conseguiu incluir, falso se não</returns>
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

        /// <summary>
        /// Retorna todas as propridades permitidas do <see cref="Aluguel"/>
        /// </summary>
        /// <returns>Propriedades do <see cref="Aluguel"/></returns>
        public static ArrayList getAllProperties()
        {
            return new Carro().getAllProperties();
        }
    }
}
