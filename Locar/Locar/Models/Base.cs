using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locar.Models
{
    public abstract class Base
    {
        private string[] camposBloqueados;

        public Base(string[] camposBloqueados)
        {
            this.camposBloqueados = camposBloqueados;
        }

        public ArrayList getAllProperties()
        {
            ArrayList campos = new ArrayList();

            foreach (PropertyInfo campo in this.GetType().GetProperties())
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
