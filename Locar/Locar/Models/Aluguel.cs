using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Aluguel
    {
        public int id { get; set; }
        public int carro_id { get; set; }
        public long cliente_id { get; set; }
        public long vendedor_id { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }

        public Aluguel(int carro_id, long cliente_id, long vendedor_id, string data_inicio, string data_fim)
        {
            this.carro_id = carro_id;
            this.cliente_id = cliente_id;
            this.vendedor_id = vendedor_id;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
        }

        public Aluguel(int id, int carro_id, long cliente_id, long vendedor_id, string data_inicio, string data_fim) : this(carro_id, cliente_id, vendedor_id, data_inicio, data_fim)
        {
            this.id = id;
        }
    }
}
