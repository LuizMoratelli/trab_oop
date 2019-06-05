using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Aluguel : Base
    {
        public static string[] camposBloqueados = new string[] { "id" };
        public int id { get; set; }
        public Cliente cliente { get; set; }
        public Carro carro { get; set; }
        public Vendedor vendedor { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }

        public Aluguel() 
            : base(camposBloqueados)
        {

        }

        public Aluguel(Carro carro, Cliente cliente, Vendedor vendedor, string data_inicio, string data_fim)
            : this()
        {
            this.carro = carro;
            this.cliente = cliente;
            this.vendedor = vendedor;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
        }

        public Aluguel(int id, Carro carro, Cliente cliente, Vendedor vendedor, string data_inicio, string data_fim)
            : this(carro, cliente, vendedor, data_inicio, data_fim)
        {
            this.id = id;
        }
    }
}
