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
    /// Realiza a busca das informações do banco de dados do modelo <see cref="Aluguel"/>
    /// </summary>
    public class AluguelDB
    {
        /// <summary>
        /// Realiza a busca de um determinado <see cref="Aluguel"/> de acordo com o respectivo <paramref name="id"/> e retorna o modelo do banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="id"></param>
        /// <returns><see cref="Aluguel"/> de determinado <paramref name="id"/></returns>
        public static Aluguel getAluguel(NpgsqlConnection conexao, int id)
        {
            Aluguel aluguel = null;

            try
            {
                string sql = "SELECT * FROM aluguel WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Hashtable dados = getDados(dr);
                dr.Close();

                aluguel = new Aluguel(
                    id,
                    CarroDB.getCarro(conexao, (int)dados["carro_id"]),
                    ClienteDB.getCliente(conexao, (int)dados["cliente_id"]),
                    VendedorDB.getVendedor(conexao, (int)dados["vendedor_id"]),
                    Convert.ToString(dados["data_inicio"]),
                    Convert.ToString(dados["data_fim"])
                );
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return aluguel;
        }

        /// <summary>
        /// Realiza a busca dos <see cref="Aluguel"/> que satisfaçam a <paramref name="consulta"/>
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="consulta"></param>
        /// <returns>Lista de <see cref="Aluguel"/> com os filtros da <paramref name="consulta"/></returns>
        public static ArrayList getConsultaAlugueis(NpgsqlConnection conexao, Consulta consulta = null)
        {
            ArrayList lista = new ArrayList();
            ArrayList listaDados = new ArrayList();

            try
            {
                string sql = "SELECT  * FROM aluguel";

                if (consulta != null)
                {
                    sql += $" WHERE {consulta.getCondicao()}";
                }

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Hashtable dados = getDados(dr);
                    listaDados.Add(dados);
                }

                dr.Close();

                foreach (Hashtable dados in listaDados)
                {
                    Aluguel aluguel = new Aluguel(
                        (int)dados["id"],
                        CarroDB.getCarro(conexao, (int)dados["carro_id"]),
                        ClienteDB.getCliente(conexao, (int)dados["cliente_id"]),
                        VendedorDB.getVendedor(conexao, (int)dados["vendedor_id"]),
                        Convert.ToDateTime(dados["data_inicio"]).ToString("dd/MM/yyyy"),
                        Convert.ToDateTime(dados["data_fim"]).ToString("dd/MM/yyyy")
                    );

                    lista.Add(aluguel);
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return lista;
        }

        /// <summary>
        /// Realiza a inserção do novo <see cref="Aluguel"/> no banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="id"></param>
        /// <returns>Verdadeiro se conseguiu alterar, falso se não</returns>
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

        /// <summary>
        /// Realiza a remoção de determinado <see cref="Aluguel"/> do banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="aluguel"></param>
        /// <returns>Verdadeiro se conseguiu alterar, falso se não</returns>
        public static bool setIncluiAluguel(NpgsqlConnection conexao, Aluguel aluguel)
        {
            bool incluiu = false;

            try
            {
                string sql = "INSERT INTO aluguel(carro_id, cliente_id, vendedor_id, data_inicio, data_fim)" +
                                          "VALUES(@carro_id, @cliente_id, @vendedor_id, @data_inicio, @data_fim)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@carro_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.Carro.id;
                cmd.Parameters.Add("@cliente_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.Cliente.id;
                cmd.Parameters.Add("@vendedor_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.Vendedor.id;
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

        /// <summary>
        /// Realiza a alteração de determinado <see cref="Aluguel"/> do banco de dados
        /// </summary>
        /// <param name="conexao"></param>
        /// <param name="aluguel"></param>
        /// <returns>Verdadeiro se conseguiu alterar, falso se não</returns>
        public static bool setAlteraAluguel(NpgsqlConnection conexao, Aluguel aluguel)
        {
            bool alterou = false;

            try
            {
                string sql = @"UPDATE aluguel
                                  SET carro_id = @carro_id, cliente_id = @cliente_id, vendedor_id = @vendedor_id,
                                      data_inicio = @data_inicio, data_fim = @data_fim
                                WHERE id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.id;
                cmd.Parameters.Add("@carro_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.Carro.id;
                cmd.Parameters.Add("@cliente_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.Cliente.id;
                cmd.Parameters.Add("@vendedor_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = aluguel.Vendedor.id;
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

        /// <summary>
        /// Retorna os dados do aluguel em forma de HashTable
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>Hashtable de dados do <see cref="Aluguel"/></returns>
        private static Hashtable getDados(NpgsqlDataReader dr)
        {
            Hashtable dados = new Hashtable();
            dados.Add("id", dr["id"]);
            dados.Add("carro_id", dr["carro_id"]);
            dados.Add("cliente_id", dr["cliente_id"]);
            dados.Add("vendedor_id", dr["vendedor_id"]);
            dados.Add("data_inicio", dr["data_inicio"]);
            dados.Add("data_fim", dr["data_fim"]);

            return dados;
        }

        /// <summary>
        /// Retorna todas as propridades permitidas do <see cref="Aluguel"/>
        /// </summary>
        /// <returns>Propriedades do <see cref="Aluguel"/></returns>
        public static ArrayList getAllProperties()
        {
            return new Aluguel().getAllProperties();
        }
    }
}
