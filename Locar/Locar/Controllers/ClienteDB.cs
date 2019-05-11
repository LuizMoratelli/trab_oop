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
    public class ClienteDB
    {
        public static DataTable getConsultaClientes(NpgsqlConnection conexao)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT  * FROM cliente";
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

        public static bool setIncluiCliente(NpgsqlConnection conexao, Cliente cliente)
        {
            bool incluiu = false;

            try
            {
                string sql = "INSERT INTO cliente(cpf, nome, data_nascimento) VALUES(@cpf, @nome, @data_nascimento)";
                Console.WriteLine(sql);
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
