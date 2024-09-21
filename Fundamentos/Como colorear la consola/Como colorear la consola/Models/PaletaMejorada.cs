using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Como_colorear_la_consola.Models
{
    class PaletaMejorada
    {

        // Diccionario que mapea categorías generales a colores
        private readonly Dictionary<Categoria, ConsoleColor> categoriaColorMap;

        public PaletaMejorada()
        {
            categoriaColorMap = new Dictionary<Categoria, ConsoleColor>
        {
            { Categoria.InformacionPersonal, ConsoleColor.Cyan },
            { Categoria.InformacionFinanciera, ConsoleColor.Green},
            { Categoria.InformacionImportante, ConsoleColor.Red},
            { Categoria.Otro, ConsoleColor.Gray }
        };
        }


        public ConsoleColor ObtenerColor(Categoria categoria)
        {
            ConsoleColor color = categoriaColorMap.TryGetValue(categoria, out color) ? color : ConsoleColor.Gray;
            return color;
        }


        public void ImprimirAtributosColoreados(object obj, Dictionary<string, Categoria> mapaDeCategorias)
        {
            Type tipo = obj.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            string nombrePropiedad;
            object valorPropiedad;

            foreach (var propiedad in propiedades)
            {
                nombrePropiedad = propiedad.Name;
                valorPropiedad = propiedad.GetValue(obj);

                // Manejar posibles valores null
                string valorTexto = valorPropiedad?.ToString() ?? "N/A";

                // Obtener la categoría de la propiedad o usar la categoría por defecto
                var categoria = mapaDeCategorias.TryGetValue(nombrePropiedad, out var value) ? value : Categoria.Otro;

                // Obtener el color basado en la categoría
                ImprimirAtributo(ObtenerColor(categoria), nombrePropiedad, valorTexto);
            }

            Console.ResetColor();
            Console.WriteLine();
        }


        public static void ImprimirAtributo(ConsoleColor color, string atributo, string valor)
        {
            Console.ForegroundColor = color;
            Console.Write($"{atributo}: ");
            Console.ResetColor();
            Console.WriteLine($"{valor}");
        }

        public enum Categoria
        {
            InformacionPersonal,
            InformacionFinanciera,
            InformacionImportante,
            Otro
        }

    }
}
