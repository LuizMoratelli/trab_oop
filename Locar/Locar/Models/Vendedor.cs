using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Vendedor : Base
    {
        public static string[] camposBloqueados = new string[] { "id" };

        public int id { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public int qtd_vendas { get; set; }

        public Vendedor()
            : base(camposBloqueados)
        {

        }

        public Vendedor(string cpf, string nome, int qtd_vendas)
            : this()
        {
            this.cpf = cpf;
            this.nome = nome;
            this.qtd_vendas = qtd_vendas;
        }

        public Vendedor(int id, string cpf, string nome, int qtd_vendas)
            : this (cpf, nome, qtd_vendas)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
