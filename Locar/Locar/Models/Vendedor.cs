using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Vendedor
    {
        public long cpf { get; set; }
        public string nome { get; set; }
        public int qtd_vendas { get; set; }

        public Vendedor(string nome, int qtd_vendas)
        {
            this.nome = nome;
            this.qtd_vendas = qtd_vendas;
        }

        public Vendedor(long cpf, string nome, int qtd_vendas)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.qtd_vendas = qtd_vendas;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
