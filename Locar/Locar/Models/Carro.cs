﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Carro
    {
        public static string[] camposBloqueados = new string[] { "id" };
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string data_aquisicao { get; set; }

        public Carro(string nome, string descricao, string data_aquisicao)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.data_aquisicao = data_aquisicao;
        }

        public Carro(int id, string nome, string descricao, string data_aquisicao) : this(nome, descricao, data_aquisicao)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
