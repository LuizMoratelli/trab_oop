using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Cliente
    {
        public static string[] camposBloqueados = new string[] { "id" };
        public int id { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public string data_nascimento { get; set; }

        public Cliente(string cpf, string nome, string data_nascimento)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.data_nascimento = data_nascimento;
        }

        public Cliente(int id, string cpf, string nome, string data_nascimento) : this(cpf, nome, data_nascimento)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
