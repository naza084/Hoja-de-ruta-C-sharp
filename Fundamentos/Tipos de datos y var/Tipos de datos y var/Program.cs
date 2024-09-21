using System;
using System.Runtime.InteropServices.ObjectiveC;

namespace Tipos_de_datos_y_var
{
    public struct Punto(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Byte, solo permite entre 0 y 255
            byte dato = 255;
            Console.WriteLine(byte.MaxValue);

            // Byte con negativos(por defecto es solo positivos), permite entre -128 y 127
            sbyte dato2 = -128;
            Console.WriteLine(sbyte.MinValue);
            Console.WriteLine(sbyte.MaxValue);
            

            // int pero solo positivos (el nemesis xd), solo permite entre 0 y 2147483647
            uint enteroPositivo = 2147483647;
            Console.WriteLine(uint.MinValue); // 0

            // lo mismo aplica con los demas tipos:
            ulong enteroLargoPositivo = 9223372036854775807;
            Console.WriteLine(ulong.MinValue); // 0


            // float y double
            float flotanteSimple = 3.1416f; // hay que agregar el f al final
            double flotanteLargo = 3.1416; 
            decimal flotanteDecimal = 3.1416m; // hay que agregar el m al final, mejor precision (usado principalmente para cálculos financieros)

            Console.WriteLine(double.MaxValue);
            Console.WriteLine(decimal.MaxValue);


            // Cadenas
            char caracter = 'd'; // con comillas dobles lo detecta como string, y un solo caracter xd
            string cadena = "Hola";


            // Tiempo
            int diasEnTalMes = DateTime.DaysInMonth(2022, 4);
            DateTime fecha = DateTime.Now;
            Console.WriteLine(fecha);
            Console.WriteLine(diasEnTalMes);


            // Null, los tipos primitivos(enteros, los flotantes, chars y booleanos) no permiten valores nulos al menos que se ponga ? al final del tipo
            int? datoNulo = null;
            Console.WriteLine(datoNulo);



            // Var, el compilador infiere el tipo de la variable basado en la expresión de inicialización
            // y es util para consultas LINQ

            // Uso de var normal
            var numeroEntero = 10; // El compilador infiere que "numero" es de tipo int
            var mensajeNormal = "Hola, mundo"; // El compilador infiere que "mensaje" es de tipo string
            var listaNormal = new List<int> { 2, 3, 6, 7, 8, 1 }; // El compilador infiere que "lista" es de tipo List<int>

            // Uso de var con LINQ
            var numerosPares = listaNormal.Where(n => n % 2 == 0).ToList(); // List<int>

            // Object anonimo con var
            var posicion = new {X = 50, Y = 100}; // El compilador infiere que "posicion" es un objeto anonimo
            Console.WriteLine(posicion.X);// 50


            // Object, se pueden crear objetos anonimos (sin clase)
            Object persona1 = new{ nombre = "Naza", edad = 25 };
            Console.WriteLine(persona1);


            // Ejemplos de tipo primitivo
            int entero = 100;
            float flotante = 10.5f;
            double doble = 20.5;
            decimal decimales = 30.5m;
            char letra = 'A';
            bool esVerdadero = true;


            // Ejemplo de tipo referenciado
            string mensaje = "Hola, mundo";
            object objeto = mensaje;
            int[] arrayNumeros = { 1, 2, 3, 4, 5 };
            Console.WriteLine(arrayNumeros.GetType()); // System.Int32[], osea matriz unidimensional o array


            // Ejemplo de tipo de valor
            Punto punto = new(10, 20);


            // Ejemplo de enumeración
            DiasDeLaSemana dia = DiasDeLaSemana.Martes;


            // Ejemplo de tipo mutable
            List<int> listaNumeros = [ 1, 2, 3, 4, 5 ];
            listaNumeros.Add(6);


            // Ejemplo de tipo inmutable
            Persona persona = new("Ana");
            // persona.Nombre = "Pedro";  Esto causará un error de compilación porque Nombre es readonly.


            // Imprimir valores para verificar
            Console.WriteLine($"Entero: {entero}");
            Console.WriteLine($"Flotante: {flotante}");
            Console.WriteLine($"Doble: {doble}");
            Console.WriteLine($"Decimal: {decimales}");
            Console.WriteLine($"Char: {letra}");
            Console.WriteLine($"Booleano: {esVerdadero}");
            Console.WriteLine($"String: {mensaje}");
            Console.WriteLine($"Objeto: {objeto}");
            Console.WriteLine($"Array: {string.Join(", ", arrayNumeros)}");
            Console.WriteLine($"Punto: ({punto.X}, {punto.Y})");
            Console.WriteLine($"Día de la semana: {dia}");
            Console.WriteLine($"Lista de números: {string.Join(", ", listaNumeros)}");
            Console.WriteLine($"Nombre de la persona: {persona.Nombre}");


            Console.ReadKey();
        }

    }
    public class Persona
    {
        public readonly string Nombre; // readonly = asignado solo en declaracion o constructor

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    public enum DiasDeLaSemana
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }
}
