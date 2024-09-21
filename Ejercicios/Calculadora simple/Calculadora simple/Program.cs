using System.Linq;
using System.Text;

namespace Calculadora_simple
{
    internal class Program
    {

        /*
        Ejercicio:

         Realizar un programa que permita realizar operaciones matemáticas simples (suma, resta, multiplicación y división).


        Requisitos: 

         Crear una clase llamada Calculadora que posea dos métodos estáticos (de clase)

         Calcular (público): Recibirá tres parámetros, el primer operando, el segundo operando y la operación matemática. 
         El método devolverá el resultado de la operación.

         Validar (privado): Recibirá como parámetro el segundo operando. Este método se debe utilizar sólo cuando la operación elegida sea la DIVISIÓN.
         Este método devolverá true si el operando es distinto de cero.


        Se le debe pedir al usuario que ingrese dos números y la operación que desea realizar (ingresando el cadena +, -, * o /).
        El usuario decidirá cuándo finalizar el programa con un "S" o "N". 
        */
        static void Main(string[] args)
        {

            string operacion, mensaje;
            double operando1, operando2, resultado;
            bool ejecutar = true;


            // Programa principal
            while (ejecutar)
            {
                operando1 = PedirDoubleValido("Digite el primer operando: ");
                operando2 = PedirDoubleValido("Digite el segundo operando: ");

                operacion = PedirOperacionValida("Digite la operacion: ");
                resultado = Calculadora.Calcular(operando1, operando2, operacion);

                mensaje = $"El resultado es: {resultado}";
                ColorearMensaje(mensaje);

                ejecutar = ContinuarPrograma("Desea continuar (S/N)?: ");
            }

            Console.Clear();
            Console.WriteLine("Programa finalizado.");


            Console.ReadKey();
        }


        /// <summary>
        /// Esta función toma un mensaje como entrada y devuelve el mismo mensaje con los dígitos en rojo y el resto en gris.
        /// </summary>
        /// <param name="mensaje">El mensaje que se desea colorear.</param>
        /// <returns>El mensaje coloreado.</returns>
        public static void ColorearMensaje(string mensaje)
        {

            foreach (char caracter in mensaje)
            {
                if (char.IsDigit(caracter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write(caracter);
            }

            // Restablecer el color de la consola
            Console.ResetColor();


            // Salto de línea al final
            Console.WriteLine();
        }

        /// <summary>
        /// Obtener el numero valido entero.
        /// </summary>
        /// <param name="mensaje">el mensaje a mostrar al usuario.</param>
        /// <param name="valorMin">el entradaValor minimo.</param>
        /// <param name="valorMax">el entradaValor maximo.</param>
        /// <returns> Devuelve el valor valido. </returns>
        public static double PedirDoubleValido(string mensaje)
        {
            double numero;
            string? entrada;
            bool esValido;

            do
            {
                Console.Write(mensaje);

                entrada = Console.ReadLine();
                esValido = ValidarDouble(entrada, out numero);
            } while (!esValido);

            return numero;
        }



        

        /// <summary>
        /// Solicita al usuario ingresar una operación válida y devuelve la operación elegida.
        /// </summary>
        /// <param name="mensaje">El mensaje para mostrar al usuario.</param>
        /// <returns>La operación elegida.</returns>
        public static bool ContinuarPrograma(string mensaje)
        {
            bool opcionValida, continuarPrograma;
            string? opcion;

            do
            {
                Console.Write(mensaje);
                opcion = Console.ReadLine();

                opcionValida = ValidarCadena(opcion, ["S", "N"]);
            } while (!opcionValida);


            if (opcion.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                continuarPrograma = true;
            }
            else
            {
                continuarPrograma = false;
            }

            return continuarPrograma;
        }


        /// <summary>
        /// Solicita al usuario ingresar una operación válida y devuelve la operación elegida.
        /// </summary>
        /// <param name="mensaje">El mensaje para mostrar al usuario.</param>
        /// <returns>La operación elegida.</returns>
        public static string PedirOperacionValida(string mensaje)
        {
            List<string> operaciones = ["+", "-", "*", "/"];
            string? operacion;

            do
            {
                Console.Write(mensaje);
                operacion = Console.ReadLine();

            } while (!operaciones.Contains(operacion));


            return operacion;
        }


        /// <summary>
        /// Valida si una cadena dada existe en una lista de cadenas válidas, ignorando mayúsculas y minúsculas.
        /// </summary>
        /// <param name="cadena">La cadena a validar.</param>
        /// <param name="cadenaValidas">La lista de cadenas válidas.</param>
        /// <returns>True si la cadena existe en la lista, false de lo contrario.</returns>
        private static bool ValidarCadena(string cadena, List<string> cadenaValidas)
        {
            // Se usa Exists con lambda para verificar si la cadena no es null y existe en la lista, ignorando mayúsculas y minúsculas.
            // A diferencia de any, exists esta diseñado y optimizado especificamente para listas aunque la diferencia de rendimiento sea minima(en listas grandes conviene exists)
            bool contieneCaracter = cadenaValidas.Exists(elemento => elemento != null && elemento.Equals(cadena, StringComparison.OrdinalIgnoreCase));

            return contieneCaracter;
        }


        /// <summary>
        /// Valida el valor de un double.
        /// </summary>
        /// <param name="entrada">La cadena de entradaValor a validar.</param>
        /// <param name="resultado">El resultado double analizado si tiene éxito.</param>
        /// <returns> True si la entradaValor es un double válido, false de lo contrario.</returns>
        public static bool ValidarDouble(string entrada, out double resultado)
        {
            bool esValido = double.TryParse(entrada, out resultado);

            return esValido;
        }


    }
}
