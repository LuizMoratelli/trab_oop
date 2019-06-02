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
        public static int getIndexCliente(NpgsqlConnection conexao, Cliente cliente)
        {
            ArrayList clientes = getConsultaClientes(conexao);
            int i = 0;

            foreach (Cliente dataCliente in clientes)
            {
                if (dataCliente.id == cliente.id)
                {
                    return i;
                }

                i++;
            }

            return 0;
        }

        public static Cliente getIndexCliente(NpgsqlConnection conexao, int id)
        {
            ArrayList clientes = getConsultaClientes(conexao);
            return (Cliente)clientes[id];
        }

        public static Cliente getCliente(NpgsqlConnection conexao, int id)
        {
            Cliente cliente = null;

            try
            {
                string sql = "SELECT * FROM cliente WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                cliente = new Cliente(id, (string)dr["cpf"], (string)dr["nome"], Convert.ToString(dr["data_nascimento"]));
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
                        (int)dr["id"],
                        (string) dr["cpf"],
                        (string)dr["nome"],
                        Convert.ToDateTime(dr["data_nascimento"]).ToString("dd/MM/yyyy")
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
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cliente.cpf;
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

        public static bool setExcluiCliente(NpgsqlConnection conexao, int id)
        {
            bool excluiu = false;

            try
            {
                string sql = "DELETE FROM cliente where id = @id";
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
        public static bool setAlteraCliente(NpgsqlConnection conexao, Cliente cliente)
        {
            bool alterou = false;

            try
            {
                string sql = @"UPDATE cliente
                                  SET nome = @nome, data_nascimento = @data_nascimento, cpf = @cpf
                                WHERE id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = cliente.id;
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cliente.cpf;
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
