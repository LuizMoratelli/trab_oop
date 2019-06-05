using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    /// <summary>
    /// Determina um <see cref="Carro"/>
    /// </summary>
    public class Carro : Base
    {
        /// <summary>
        /// Especifica todos os campos que serão bloqueados para consulta das views
        /// </summary>
        public static string[] camposBloqueados = new string[] { "id" };

        /// <summary>
        /// Define o identificador único do <see cref="Carro"/>
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Define o nome do <see cref="Carro"/>
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Define a descrição do <see cref="Carro"/>
        /// </summary>
        public string descricao { get; set; }
        /// <summary>
        /// Define a data de aquisição do <see cref="Carro"/>
        /// </summary>
        public string data_aquisicao { get; set; }

        /// <summary>
        /// Construtor simples que chamará o construtor base
        /// </summary>
        public Carro()
            : base(camposBloqueados)
        {

        }

        /// <summary>
        /// Construtor de novos <see cref="Carro"/>
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="descricao"></param>
        /// <param name="data_aquisicao"></param>
        public Carro(string nome, string descricao, string data_aquisicao)
            : this()
        {
            this.nome = nome;
            this.descricao = descricao;
            this.data_aquisicao = data_aquisicao;
        }

        /// <summary>
        /// Construtor de <see cref="Carro"/> já inserido no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="descricao"></param>
        /// <param name="data_aquisicao"></param>
        public Carro(int id, string nome, string descricao, string data_aquisicao)
            : this(nome, descricao, data_aquisicao)
        {
            this.id = id;
        }

        /// <summary>
        /// Retorna o nome do <see cref="Carro"/>
        /// </summary>
        /// <returns><see cref="Carro"/> em string</returns>
        public override string ToString()
        {
            return nome;
        }
    }
}
