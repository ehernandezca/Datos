using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class persona
    {
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }

        public persona(string linea)
        {
            string[] datos = linea.Split(',');
            nombre = datos[0];
            apellidoPaterno = datos[1];
            apellidoMaterno = datos[2];
        }

        public override string ToString()
        {
            return nombre + "," + apellidoPaterno + "," + apellidoMaterno;
        }
    }
}
