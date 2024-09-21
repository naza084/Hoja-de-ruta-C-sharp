using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Como_colorear_la_consola.Models
{
    internal class PaletaDeAtributos
    {

        private readonly Dictionary<string, ConsoleColor> atributoColorMap;

        public PaletaDeAtributos()
        {
            // Sin enum
            atributoColorMap = new Dictionary<string, ConsoleColor>
            {
                 { "Nombre", ConsoleColor.Cyan },
                 { "Edad", ConsoleColor.Green },
                 { "Apellido", ConsoleColor.Yellow },
                 { "Direccion", ConsoleColor.Magenta }
            };
            
            /* Con enum
            atributoColorMap = new Dictionary<Atributo, ConsoleColor>
            {
                { Atributo.Nombre, ConsoleColor.Cyan },
                { Atributo.Edad, ConsoleColor.Green },
                { Atributo.Apellido, ConsoleColor.Yellow },
                { Atributo.Direccion, ConsoleColor.Magenta }
            };
            */
        }

        public ConsoleColor ObtenerColor(string atributo)
        {
            ConsoleColor color = atributoColorMap.TryGetValue(atributo, out color) ? color : ConsoleColor.Gray;
            return color;
        }


        public void ImprimirAtributoColoreado(Object obj)
        {
            /* Sin enum
            // Colorear el Nombre de la Persona
            Console.ForegroundColor = ObtenerColor("Nombre");
            Console.Write(persona.Nombre);
            Console.ResetColor();

            // Imprimir otros atributos
            Console.WriteLine($", Edad: {persona.Edad}");
            */

            /* con enum
            Console.ForegroundColor = ObtenerColor(Atributo.Nombre);
            Console.Write("Nombre: ");
            Console.ResetColor();
            Console.WriteLine(persona.Nombre);

            Console.ForegroundColor = ObtenerColor(Atributo.Edad);
            Console.Write("Edad: ");
            Console.ResetColor();
            Console.WriteLine($"{persona.Edad}");

            // Colorear otros atributos si es necesario
            Console.ForegroundColor = ObtenerColor(Atributo.Apellido);
            Console.Write("Apellido: ");
            Console.ResetColor();
            Console.WriteLine($"{persona.Apellido}");

            Console.ForegroundColor = ObtenerColor(Atributo.Direccion);
            Console.Write("Dirección: ");
            Console.ResetColor();
            Console.WriteLine($"{persona.Direccion}");

            Console.ResetColor(); // Restablecer el color al final
            */

            // Con reflexion
            Type tipo = obj.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (var propiedad in propiedades)
            {
                string nombrePropiedad = propiedad.Name;
                object valorPropiedad = propiedad.GetValue(obj);

                // Obtener el color basado en el nombre de la propiedad
                Console.ForegroundColor = ObtenerColor(nombrePropiedad);
                Console.Write($"{nombrePropiedad}: {valorPropiedad} ");
            }

            Console.ResetColor();
            Console.WriteLine();

        }

        public enum Atributo
        {
            Nombre,
            Edad,
            Apellido,
            Direccion
        }
    }
}
