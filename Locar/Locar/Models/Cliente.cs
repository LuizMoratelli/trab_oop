using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Cliente
    {
        public long cpf { get; set; }
        public string nome { get; set; }
        public string data_nascimento { get; set; }

        public Cliente(string nome, string data_nascimento)
        {
            this.nome = nome;
            this.data_nascimento = data_nascimento;
        }

        public Cliente(long cpf, string nome, string data_nascimento) : this(nome, data_nascimento)
        {
            this.cpf = cpf;
        }
        public override string ToString()
        {
            return nome;
        }
    }
}
