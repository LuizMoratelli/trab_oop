using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    /// <summary>
    /// Classe abstrata que serve de base para as demais classes
    /// </summary>
    [Serializable]
    public abstract class Base
    {
        private string[] camposBloqueados;

        /// <summary>
        /// Construtor simples sem argumentos
        /// </summary>
        public Base()
        {

        }

        /// <summary>
        /// Define os campos que serão bloqueados nas views
        /// </summary>
        /// <param name="camposBloqueados"></param>
        public Base(string[] camposBloqueados)
        {
            this.camposBloqueados = camposBloqueados;
        }

        /// <summary>
        /// Retorna todas as propriedades não bloqueadas
        /// </summary>
        /// <returns>Propriedades da classe derivada</returns>
        public ArrayList getAllProperties()
        {
            ArrayList campos = new ArrayList();

            foreach (PropertyInfo campo in GetType().GetProperties())
            {
                if (!camposBloqueados.Contains(campo.Name))
                {
                    campos.Add(campo.Name);
                }
            }

            return campos;
        }

    }
}
