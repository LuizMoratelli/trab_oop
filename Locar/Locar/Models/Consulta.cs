using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public class Consulta
    {
        public string campo;
        public int tipo;
        public string valor;

        public string[] tipos = new string[] {
            "Contém",
            "Começa com",
            "Termina com",
            "Igual à",
            "Maior que",
            "Maior ou igual à",
            "Menor que",
            "Menor ou igual à",
            "Data"
        };

        public Consulta()
        {

        }

        public Consulta(string campo, int tipo, string valor)
        {
            this.campo = campo;
            this.tipo = tipo;
            this.valor = valor;
        }

        public string getCondicao()
        {
            string condicao = "";

            switch (tipo)
            {
                case 0:
                    condicao = $"{campo}::text ILIKE '%{valor}%'";
                    break;
                case 1:
                    condicao = $"{campo} ILIKE '{valor}%'";
                    break;
                case 2:
                    condicao = $"{campo} ILIKE '%{valor}'";
                    break;
                case 3:
                    condicao = $"{campo} = '{valor}'";
                    break;
                case 4:
                    condicao = $"{campo} > '{valor}'";
                    break;
                case 5:
                    condicao = $"{campo} >= '{valor}'";
                    break;
                case 6:
                    condicao = $"{campo} < '{valor}'";
                    break;
                case 7:
                    condicao = $"{campo} <= '{valor}'";
                    break;
                case 8:
                    try
                    {
                        condicao = $"{campo}::text ILIKE '%{Convert.ToDateTime(valor).ToString("yyyy-MM-dd")}%'";
                    }
                    catch
                    {
                        condicao = $"{campo}::text ILIKE '%{valor}%'";
                    }
                    break;
            }

            return condicao;
        }
    }
}
