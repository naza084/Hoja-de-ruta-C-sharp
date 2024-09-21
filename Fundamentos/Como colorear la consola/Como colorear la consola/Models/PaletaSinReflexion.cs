using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Como_colorear_la_consola.Models
{
    internal class PaletaSinReflexion
    {

        // Enum de propiedades, mantenido en esta clase para simplificar
        public enum PropiedadSimple
        {
            Daño,
            Vida,
            Nombre,
            HabilidadEspecial
        }


        // Diccionario que mapea propiedades específicas de superhéroe a colores
        private readonly Dictionary<PropiedadSimple, ConsoleColor> propiedadColorMap;

        public PaletaSinReflexion()
        {
            propiedadColorMap = new Dictionary<PropiedadSimple, ConsoleColor>
            {
                { PropiedadSimple.Daño, ConsoleColor.Red },
                { PropiedadSimple.Vida, ConsoleColor.Green },
                { PropiedadSimple.Nombre, ConsoleColor.Cyan },
                { PropiedadSimple.HabilidadEspecial, ConsoleColor.Yellow }
            };
        }

        /// <summary>
        /// Colorea el texto de un mensaje según los atributos de la clase Superheroe que contiene.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="superheroe"></param>
        public void Colorear(string mensaje, Superheroe superheroe)
        {
            // Dividimos el mensaje en palabras para detectar los valores numéricos o propiedades
            string[] partes = mensaje.Split(' ');

            foreach (var palabra in partes)
            {
                // Determinar si es un número y aplicar el color correspondiente
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

            ReiniciarColores();
        }
        private ConsoleColor ObtenerColorParaNumero(int valor, Superheroe superheroe)
        {
            ConsoleColor colorNumero = valor switch
            {
                _ when valor == superheroe.Daño => propiedadColorMap[PropiedadSimple.Daño],
                _ when valor == superheroe.Vida => propiedadColorMap[PropiedadSimple.Vida],
                _ => ConsoleColor.Gray

            };

            return colorNumero;
        }

        private ConsoleColor ObtenerColorParaPalabra(string palabra, Superheroe superheroe)
        {
            ConsoleColor colorPalabra = palabra switch
            {
                _ when palabra == superheroe.Nombre => propiedadColorMap[PropiedadSimple.Nombre],
                _ when palabra == superheroe.HabilidadEspecial => propiedadColorMap[PropiedadSimple.HabilidadEspecial],
                _ => ConsoleColor.Gray

            };

            return colorPalabra;
        }

        public static void ReiniciarColores()
        {
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
