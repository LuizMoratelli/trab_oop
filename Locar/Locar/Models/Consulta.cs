using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    /// <summary>
    /// Classe genérica para filtro dos SQLs nas views
    /// </summary>
    public class Consulta
    {
        /// <summary>
        /// <see cref="campo"/> do banco de dados à ser filtrado
        /// </summary>
        public string campo;
        /// <summary>
        /// <see cref="tipo"/> de <see cref="Consulta"/>  que será realizada
        /// </summary>
        public int tipo;
        /// <summary>
        /// <see cref="valor"/> de <see cref="Consulta"/> 
        /// </summary>
        public string valor;

        /// <summary>
        /// <see cref="tipos"/> de <see cref="Consulta"/> permitidos nas views
        /// </summary>
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

        /// <summary>
        /// Construtor simples
        /// </summary>
        public Consulta()
        {

        }

        /// <summary>
        /// Construtor de nova <see cref="Consulta"/> à ser realizada
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="tipo"></param>
        /// <param name="valor"></param>
        public Consulta(string campo, int tipo, string valor)
        {
            this.campo = campo;
            this.tipo = tipo;
            this.valor = valor;
        }

        /// <summary>
        /// Retorna a string de condicação do SQL
        /// Ex: nome ILIKE '%Luiz%'
        /// </summary>
        /// <returns></returns>
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
