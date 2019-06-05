using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    /// <summary>
    /// Determina um <see cref="Aluguel"/>
    /// </summary>
    public class Aluguel : Base
    {
        /// <summary>
        /// Especifica todos os campos que serão bloqueados para consulta das views
        /// </summary>
        public static string[] camposBloqueados = new string[] { "id", "Carro", "Cliente", "Vendedor" };
        /// <summary>
        /// Define o identificador único do <see cref="Aluguel"/>
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Define o <see cref="Cliente"/> associado com o <see cref="Aluguel"/>
        /// </summary>
        public Cliente Cliente { get; set; }
        /// <summary>
        /// Define o <see cref="Carro"/> associado com o <see cref="Aluguel"/>
        /// </summary>
        public Carro Carro { get; set; }
        /// <summary>
        /// Define o <see cref="Vendedor"/> associado com o <see cref="Aluguel"/>
        /// </summary>
        public Vendedor Vendedor { get; set; }
        /// <summary>
        /// Define a data de início do <see cref="Aluguel"/>
        /// </summary>
        public string data_inicio { get; set; }
        /// <summary>
        /// Define a data de fim do <see cref="Aluguel"/>
        /// </summary>
        public string data_fim { get; set; }

        /// <summary>
        /// Construtor simples que chamará o construtor base
        /// </summary>
        public Aluguel() 
            : base(camposBloqueados)
        {

        }

        /// <summary>
        /// Construtor de novos <see cref="Aluguel"/>
        /// </summary>
        /// <param name="carro"></param>
        /// <param name="cliente"></param>
        /// <param name="vendedor"></param>
        /// <param name="data_inicio"></param>
        /// <param name="data_fim"></param>
        public Aluguel(Carro carro, Cliente cliente, Vendedor vendedor, string data_inicio, string data_fim)
            : this()
        {
            this.Carro = carro;
            this.Cliente = cliente;
            this.Vendedor = vendedor;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
        }

        /// <summary>
        /// Construtor de <see cref="Aluguel"/> já inserido no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carro"></param>
        /// <param name="cliente"></param>
        /// <param name="vendedor"></param>
        /// <param name="data_inicio"></param>
        /// <param name="data_fim"></param>
        public Aluguel(int id, Carro carro, Cliente cliente, Vendedor vendedor, string data_inicio, string data_fim)
            : this(carro, cliente, vendedor, data_inicio, data_fim)
        {
            this.id = id;
        }
    }
}
