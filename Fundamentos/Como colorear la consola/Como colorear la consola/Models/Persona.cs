using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Como_colorear_la_consola.Models
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        public Persona(string nombre, int edad, string apellido, string direccion)
        {
            Nombre = nombre;
            Edad = edad;
            Apellido = apellido;
            Direccion = direccion;
        }
    }

}
