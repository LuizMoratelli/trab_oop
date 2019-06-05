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
    public class VendedorDB
    {
        public static int getIndexVendedor(NpgsqlConnection conexao, Vendedor vendedor)
        {
            ArrayList vendedores = getConsultaVendedores(conexao);
            int i = 0;

            foreach (Vendedor dataVendedor in vendedores)
            {
                if (dataVendedor.id == vendedor.id)
                {
                    return i;
                }

                i++;
            }

            return 0;
        }

        public static Vendedor getIndexVendedor(NpgsqlConnection conexao, int id)
        {
            ArrayList vendedores = getConsultaVendedores(conexao);
            return (Vendedor)vendedores[id];
        }

        public static Vendedor getVendedor(NpgsqlConnection conexao, int id)
        {
            Vendedor vendedor = null;

            try
            {
                string sql = "SELECT * FROM vendedor WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                vendedor = new Vendedor(id, (string)dr["cpf"], (string)dr["nome"], Convert.ToInt32(dr["qtd_vendas"]));
                dr.Close();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }


            return vendedor;
        }

        public static ArrayList getConsultaVendedores(NpgsqlConnection conexao, Consulta consulta = null)
        {
            ArrayList lista = new ArrayList();

            try
            {
                string sql = "SELECT * FROM vendedor";

                if (consulta != null)
                {
                    sql += $" WHERE {consulta.getCondicao()}";
                }

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Vendedor vendedor = new Vendedor(
                        (int)dr["id"],
                        (string)dr["cpf"],
                        (string)dr["nome"],
                        (int)(dr["qtd_vendas"])
                    );
                    lista.Add(vendedor);
                }
                dr.Close();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return lista;
        }

        public static bool setIncluiVendedor(NpgsqlConnection conexao, Vendedor vendedor)
        {
            bool incluiu = false;

            try
            {
                string sql = "INSERT INTO vendedor(cpf, nome, qtd_vendas) VALUES(@cpf, @nome, @qtd_vendas)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar).Value = vendedor.cpf;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = vendedor.nome;
                cmd.Parameters.Add("@qtd_vendas", NpgsqlTypes.NpgsqlDbType.Integer).Value = vendedor.qtd_vendas;
                incluiu = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return incluiu;
        }

        public static bool setExcluiVendedor(NpgsqlConnection conexao, int id)
        {
            bool excluiu = false;

            try
            {
                string sql = "DELETE FROM vendedor where id = @id";
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
        public static bool setAlteraVendedor(NpgsqlConnection conexao, Vendedor vendedor)
        {
            bool alterou = false;

            try
            {
                string sql = @"UPDATE vendedor
                                  SET nome = @nome, qtd_vendas = @qtd_vendas, cpf = @cpf
                                WHERE id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = vendedor.id;
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Varchar).Value = vendedor.cpf;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = vendedor.nome;
                cmd.Parameters.Add("@qtd_vendas", NpgsqlTypes.NpgsqlDbType.Integer).Value = vendedor.qtd_vendas;

                alterou = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show($"Ocorreu um erro com o banco de dados: {e.Message}");
            }

            return alterou;
        }

        public static ArrayList getAllProperties()
        {
            return new Vendedor().getAllProperties();
        }
    }
}
