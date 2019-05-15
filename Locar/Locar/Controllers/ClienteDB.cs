using Locar.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locar.Controllers
{
    public class ClienteDB
    {
        public static Cliente getCliente(NpgsqlConnection conexao, long cpf)
        {
            Cliente cliente = null;

            try
            {
                string sql = "SELECT * FROM cliente WHERE cpf = @cpf";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Bigint).Value = cpf;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                cliente = new Cliente(cpf, (string)dr["nome"], Convert.ToString(dr["data_nascimento"]));
                dr.Close();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return cliente;
        }

        public static ArrayList getConsultaClientes(NpgsqlConnection conexao)
        {
            ArrayList lista = new ArrayList();

            try
            {
                string sql = "SELECT  * FROM cliente";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Cliente cliente = new Cliente(
                        (long) dr["cpf"],
                        (string)dr["nome"],
                        Convert.ToString(dr["data_nascimento"])
                    );
                    lista.Add(cliente);
                }

                dr.Close();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return lista;
        }

        public static bool setIncluiCliente(NpgsqlConnection conexao, Cliente cliente)
        {
            bool incluiu = false;

            try
            {
                string sql = "INSERT INTO cliente(cpf, nome, data_nascimento) VALUES(@cpf, @nome, @data_nascimento)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Bigint).Value = cliente.cpf;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cliente.nome;
                cmd.Parameters.Add("@data_nascimento", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(cliente.data_nascimento);

                incluiu = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return incluiu;
        }

        public static bool setExcluiCliente(NpgsqlConnection conexao, long cpf)
        {
            bool excluiu = false;

            try
            {
                string sql = "DELETE FROM cliente where cpf = @cpf";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Bigint).Value = cpf;

                excluiu = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return excluiu;
        }
        public static bool setAlteraCliente(NpgsqlConnection conexao, Cliente cliente)
        {
            bool alterou = false;

            try
            {
                string sql = @"UPDATE cliente
                                  SET nome = @nome, data_nascimento = @data_nascimento
                                WHERE cpf = @cpf";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Bigint).Value = cliente.cpf;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cliente.nome;
                cmd.Parameters.Add("@data_nascimento", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Convert.ToDateTime(cliente.data_nascimento);

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
