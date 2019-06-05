using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    /// <summary>
    /// Determina um <see cref="Vendedor"/>
    /// </summary>
    public class Vendedor : Base
    {
        /// <summary>
        /// Especifica todos os campos que serão bloqueados para consulta das views
        /// </summary>
        public static string[] camposBloqueados = new string[] { "id" };
        /// <summary>
        /// Define o identificador único do <see cref="Vendedor"/>
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Define o CPF do <see cref="Vendedor"/>
        /// </summary>
        public string cpf { get; set; }
        /// <summary>
        /// Define o nome do <see cref="Vendedor"/>
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Define a quantidade de vendas do <see cref="Vendedor"/>
        /// </summary>
        public int qtd_vendas { get; set; }

        /// <summary>
        /// Construtor simples que chamará o construtor base
        /// </summary>
        public Vendedor()
            : base(camposBloqueados)
        {

        }

        /// <summary>
        /// Construtor de novos <see cref="Vendedor"/>
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <param name="qtd_vendas"></param>
        public Vendedor(string cpf, string nome, int qtd_vendas)
            : this()
        {
            this.cpf = cpf;
            this.nome = nome;
            this.qtd_vendas = qtd_vendas;
        }

        /// <summary>
        /// Construtor de <see cref="Vendedor"/> já inserido no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <param name="qtd_vendas"></param>
        public Vendedor(int id, string cpf, string nome, int qtd_vendas)
            : this (cpf, nome, qtd_vendas)
        {
            this.id = id;
        }

        /// <summary>
        /// Retorna o nome do <see cref="Vendedor"/>
        /// </summary>
        /// <returns><see cref="Vendedor"/> em string</returns>
        public override string ToString()
        {
            return nome;
        }
    }
}
