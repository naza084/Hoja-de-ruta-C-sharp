using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Como_colorear_la_consola.Models
{
    class PaletaSuperheroe
    {
        /* Idealmente el enum debe ir al principio de la clase si una sola lo usa, de lo contrario guardarlo en un archivo aparte es mejor 
        public enum PropiedadSimple
        {
            Daño,
            Vida,
            Nombre,
            HabilidadEspecial
        }
        */


        // Diccionario que mapea propiedades específicas de superhéroe a colores
        private readonly Dictionary<Propiedad, ConsoleColor> propiedadColorMap;

        // Diccionario que mapea los nombres de las propiedades a valores del enum
        private readonly Dictionary<string, Propiedad> mapaPropiedadEnum;


        public PaletaSuperheroe()
        {
            propiedadColorMap = new Dictionary<Propiedad, ConsoleColor>
            {
                { Propiedad.Daño, ConsoleColor.Red },
                { Propiedad.Vida, ConsoleColor.Green },
                { Propiedad.Nombre, ConsoleColor.Cyan },
                { Propiedad.HabilidadEspecial, ConsoleColor.Yellow }
            };

            // Mapeo de nombres de propiedades al enum
            mapaPropiedadEnum = new Dictionary<string, Propiedad>
            {
                { nameof(Superheroe.Daño), Propiedad.Daño },
                { nameof(Superheroe.Vida), Propiedad.Vida },
                { nameof(Superheroe.Nombre), Propiedad.Nombre },
                { nameof(Superheroe.HabilidadEspecial), Propiedad.HabilidadEspecial }
            };
        }


        /// <summary>
        /// Muestra los atributos de una clase superheroe coloreados por consola
        /// </summary>
        /// <param name="superheroe"></param>
        public void ImprimirAtributosColoreados(Superheroe superheroe)
        {
            Type tipo = superheroe.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            string nombrePropiedad, valorTexto;
            object valorPropiedad;

            foreach (var propiedad in propiedades)
            {
                nombrePropiedad = propiedad.Name;
                valorPropiedad = propiedad.GetValue(superheroe);

                // Manejar posibles valores null
                valorTexto = valorPropiedad?.ToString() ?? "N/A";

                // Determinar la propiedad usando el diccionario de mapeo
                if (mapaPropiedadEnum.TryGetValue(nombrePropiedad, out Propiedad propiedadEnum))
                {
                    // Obtener el colorPalabra basado en la propiedad específica
                    ImprimirAtributo(propiedadColorMap[propiedadEnum], nombrePropiedad, valorTexto);
                }
                else
                {
                    // Si la propiedad no está mapeada, imprimirla en gris
                    ImprimirAtributo(ConsoleColor.Gray, nombrePropiedad, valorTexto);
                }
            }

            Console.ResetColor();
            Console.WriteLine();
        }


        /// <summary>
        /// Colorea el texto de un mensaje segun los atributos de la claseSuperheroe que contiene
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="superheroe"></param>
        public void ColorearMensaje(string mensaje, Superheroe superheroe)
        {
            // Dividimos el mensaje en palabras para detectar los valores numéricos o propiedades
            string[] partes = mensaje.Split(' ');

            foreach (var palabra in partes)
            {
                if (int.TryParse(palabra, out int valor))
                {
                    Console.ForegroundColor = ObtenerColorParaNumero(valor, superheroe);
                }
                else
                {
                    Console.ForegroundColor = ObtenerColorParaPalabra(palabra, superheroe);
                }

                Console.Write(palabra + " ");

            }

            Console.ResetColor();
            Console.WriteLine();
        }


        /// <summary>
        /// Imprime un solo atributo coloreado
        /// </summary>
        /// <param name="color"></param>
        /// <param name="atributo"></param>
        /// <param name="valor"></param>
        private static void ImprimirAtributo(ConsoleColor color, string atributo, string valor)
        {
            Console.ForegroundColor = color;
            Console.Write($"{atributo}: ");
            Console.ResetColor();
            Console.WriteLine(valor);
        }

        private ConsoleColor ObtenerColorParaNumero(int valor, Superheroe superheroe)
        {
            ConsoleColor colorNumero = valor switch
            {
                _ when valor == superheroe.Daño => propiedadColorMap[Propiedad.Daño],
                _ when valor == superheroe.Vida => propiedadColorMap[Propiedad.Vida],
                _ => ConsoleColor.Gray

            };

            return colorNumero;
        }

        private ConsoleColor ObtenerColorParaPalabra(string palabra, Superheroe superheroe)
        {
            ConsoleColor colorPalabra = palabra switch
            {
                _ when palabra == superheroe.Nombre => propiedadColorMap[Propiedad.Nombre],
                _ when palabra == superheroe.HabilidadEspecial => propiedadColorMap[Propiedad.HabilidadEspecial],
                _ => ConsoleColor.Gray

            };

            return colorPalabra;
        }


    }
}
