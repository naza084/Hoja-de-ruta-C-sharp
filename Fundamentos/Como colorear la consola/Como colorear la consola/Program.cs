using Como_colorear_la_consola.Models;
using static Como_colorear_la_consola.Models.PaletaDeAtributos;
using System.Drawing;
using static Como_colorear_la_consola.Models.PaletaMejorada;
using System.Reflection;

namespace Como_colorear_la_consola
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Propiedades basicas de los colores:

            Console.ForegroundColor: Controla el color del texto.
            Console.BackgroundColor: Controla el color de fondo del texto.
            Console.ResetColor(): Restablece los colores de texto y fondo a sus valores predeterminados.

             */

            /* Coloreo sin funciones
            // Ejemplo
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.BackgroundColor = ConsoleColor.Blue;

            //Console.WriteLine("Este texto es rojo y con fondo azul.");
            //Console.ResetColor(); // Restablecer colores predeterminados


            //// Colorear numeros
            //string texto = "La cuenta es de 150 dólares.";
            //Colorear(texto);


            //// Colorear mensaje de error o acierto
            //int numero = Convert.ToInt32(Console.ReadLine());

            //if (numero < 0)
            //{
            //    ColorearError("El numero debe ser positivo");
            //}
            //else
            //{
            //    ColorearAcierto("Correcto!");
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine("El valor es {0}.", numero);
            //}
            //ReiniciarColores();




            //// Colorear palabras de texto
            //string datos = "Nombre: Juan, Edad: 30";
            //Dictionary<string, ConsoleColor> palabraColorMap = new()
            //{
            //    { "Nombre", ConsoleColor.Cyan },
            //    { "Edad", ConsoleColor.Magenta }
            //};

            //string[] palabras = datos.Split(' ');
            //string atributoBuscado;

            //foreach (string palabra in palabras)
            //{
            //    atributoBuscado = palabra.TrimEnd(':');

            //    if (palabraColorMap.TryGetValue(atributoBuscado, out ConsoleColor value))
            //    {
            //        Console.ForegroundColor = value;
            //        Console.WriteLine();
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Gray;
            //    }

            //    Console.Write(palabra + " ");

            //    /* Colorear palabras especificas sin otros signos al lado
            //     // Separar la palabra del signo de puntuación si existe
            //    string cleanWord = palabra.TrimEnd(':', ',', '.');

            //    // Colorear la palabra sin el signo de puntuación
            //    if (palabraColorMap.ContainsKey(cleanWord))
            //    {
            //        Console.ForegroundColor = palabraColorMap[cleanWord];
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Gray;
            //    }
            //    Console.WriteLine(cleanWord);
            //     
            //}
            //ReiniciarColores();



            // Usando objetos
            //// PaletaDeAtributos paletaSuperheroe = new();
            //// Persona persona = new("Emilio", 30);
            //// 
            //// paletaSuperheroe.ImprimirAtributoColoreado(persona);
            //

            //// Usando objetos con enum
            //Persona persona = new("Juan", 30, "Pérez", "Calle Falsa 123");
            //PaletaDeAtributos paletaSuperheroe = new();
            //paletaSuperheroe.ImprimirAtributoColoreado(persona);
            */



            // Con reflexión y enum para la paletaSuperheroe de atributos
            // Crear una persona para el ejemplo
            Persona persona1 = new("Juan", 30, "Pérez", "Calle Falsa 123");

            // Crear el mapa de categorías para las propiedades
            var mapaDeCategorias = new Dictionary<string, Categoria>
            {
                { "Nombre", Categoria.InformacionPersonal },
                { "Edad", Categoria.InformacionPersonal },
                { "Apellido", Categoria.InformacionPersonal },
                { "Salario", Categoria.InformacionFinanciera }
            };

            PaletaMejorada paletaConReflexion = new();
            paletaConReflexion.ImprimirAtributosColoreados(persona1, mapaDeCategorias);

            // Otro ejemplo con un objeto anónimo
            var coche = new
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Precio = 20000m
            };

            // Mapa de categorías para el objeto anónimo
            var mapaCoche = new Dictionary<string, Categoria>
            {
                { "Marca", Categoria.InformacionPersonal },
                { "Modelo", Categoria.InformacionPersonal },
                { "Precio", Categoria.InformacionFinanciera }
            };

            paletaConReflexion.ImprimirAtributosColoreados(coche, mapaCoche);


            // Con objeto superheroe
            var superheroe1 = new
            {
                Nombre = "Superman",
                Poder = "Super fuerza",
                Daño = 130,
            };

            var mapaSuperheroe = new Dictionary<string, Categoria>
            {
                { "Nombre", Categoria.InformacionPersonal },
                { "Daño", Categoria.InformacionImportante },
                { "Poder", Categoria.InformacionPersonal }
            };

            paletaConReflexion.ImprimirAtributosColoreados(superheroe1, mapaSuperheroe);


            // Pruebas
            ColorearDaño(130);
            ColorearNumeros($"{superheroe1.Nombre} hizo {superheroe1.Daño} de daño.");


            // Coloreando propiedades como vida y daño con funcion
            Superheroe superheroe = new("Thor", 130, 200, "Rayo");
            ColorearPropiedades($"{superheroe.Nombre} hizo {superheroe.Daño} de daño y tiene {superheroe.Vida} de vida.", superheroe);


            // Coloreando propiedades con clase paletaSuperheroe
            PaletaSuperheroe paletaSuperheroe = new PaletaSuperheroe();

            // Ejemplo de uso del nuevo método Colorear
            paletaSuperheroe.ColorearMensaje($"{superheroe.Nombre} hizo {superheroe.Daño} de daño usando su {superheroe.HabilidadEspecial} y tiene {superheroe.Vida} de vida.", superheroe);

            // Ejemplo de uso del método ImprimirAtributosColoreados
            paletaSuperheroe.ImprimirAtributosColoreados(superheroe);

            

            // Coloreando con configurador simple sin reflexión
            PaletaSinReflexion configurador = new();

            // Ejemplo de uso del método Colorear simplificiado
            configurador.Colorear($"{superheroe.Nombre} hizo {superheroe.Daño} de daño y tiene {superheroe.Vida} de vida.", superheroe);



            Console.ReadKey();
        }


        // Otras funciones
        public static void ReiniciarColores()
        {
            Console.ResetColor();
            Console.WriteLine();
        }


        // Colorear propiedades mejorado de superheroe
        public static void ColorearPropiedades(string texto, Superheroe superheroe)
        {
            // Mapeo de las propiedades a sus respectivos colores
            var coloresPropiedades = new Dictionary<string, ConsoleColor>
            {
                { nameof(superheroe.Daño), ConsoleColor.Red },
                { nameof(superheroe.Vida), ConsoleColor.Green }
            };


            // Analizar el texto e identificar los valores asociados a las propiedades
            string[] partes = texto.Split(' ');
            foreach (string palabra in partes)
            {
                // Si la palabra coincide con uno de los valores de las propiedades, aplica el color correspondiente
                if (int.TryParse(palabra, out int valor))
                {
                    if (valor == superheroe.Daño)
                    {
                        Console.ForegroundColor = coloresPropiedades[nameof(superheroe.Daño)];
                    }
                    else if (valor == superheroe.Vida)
                    {
                        Console.ForegroundColor = coloresPropiedades[nameof(superheroe.Vida)];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray; // Otros números en gris
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray; // Otros caracteres en gris
                }
                Console.Write(palabra + " ");
            }

            ReiniciarColores();
        }

        // Colorear solo numeros de una cadena
        public static void ColorearNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (char.IsDigit(c))
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Números en rojo
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray; // Otros caracteres en gris
                }
                Console.Write(c);
            }
            ReiniciarColores();
        }


        public static void ColorearDaño(int daño)
        {
            Console.Write("Daño: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{daño}");
            ReiniciarColores();
        }

        public static void ColorearError(string mensajeError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensajeError);
            Console.ResetColor();
        }

        public static void ColorearAcierto(string mensajeAcierto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensajeAcierto);
            Console.ResetColor();
        }





    
    }

    class Superheroe(string nombre, int daño, int vida, string hablidadEspecial)
    {
        public string Nombre { get; set; } = nombre;
        public int Daño { get; set; } = daño;
        public int Vida { get; set; } = vida;
        public string HabilidadEspecial { get; set; } = hablidadEspecial;
    }
}
