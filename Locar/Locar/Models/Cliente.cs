using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    /// <summary>
    /// Determina um <see cref="Cliente"/>
    /// </summary>
    [Serializable]
    public class Cliente : Base
    {
        /// <summary>
        /// Especifica todos os campos que serão bloqueados para consulta das views
        /// </summary>
        public static string[] camposBloqueados = new string[] { "id" };
        /// <summary>
        /// Define o identificador único do <see cref="Cliente"/>
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Define o CPF do <see cref="Cliente"/>
        /// </summary>
        public string cpf { get; set; }
        /// <summary>
        /// Define o nome do <see cref="Cliente"/>
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Define a data de nascimento do <see cref="Cliente"/>
        /// </summary>
        public string data_nascimento { get; set; }

        /// <summary>
        /// Construtor simples que chamará o construtor base
        /// </summary>
        public Cliente()
            : base(camposBloqueados)
        {

        }

        /// <summary>
        /// Construtor de novos <see cref="Cliente"/>
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <param name="data_nascimento"></param>
        public Cliente(string cpf, string nome, string data_nascimento)
            : this()
        {
            this.cpf = cpf;
            this.nome = nome;
            this.data_nascimento = data_nascimento;
        }

        /// <summary>
        /// Construtor de <see cref="Cliente"/> já inserido no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <param name="data_nascimento"></param>
        public Cliente(int id, string cpf, string nome, string data_nascimento)
           : this(cpf, nome, data_nascimento)
        {
            this.id = id;
        }

        /// <summary>
        /// Retorna o nome do <see cref="Cliente"/>
        /// </summary>
        /// <returns><see cref="Cliente"/> em string</returns>
        public override string ToString()
        {
            return nome;
        }
    }
}
