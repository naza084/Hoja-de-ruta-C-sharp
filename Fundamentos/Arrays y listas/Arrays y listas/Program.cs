using System.Diagnostics;

namespace Arrays_y_listas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[] numeros = new int[5]; // Array de 5 enteros, inicialmente todos son 0

            // Inicialización con valores
            int[] otrosNumeros = new int[5] { 1, 2, 3, 4, 5 };

            // Declaración e inicialización implícita
            int[] masNumeros = { 6, 7, 8, 9, 10 };

            // Declaración e inicialización con nueva forma de expresión de colección
            int[] nuevosNumeros = [1, 2, 3, 4, 5];


            // Recorrido con for tradicional
            for (int i = 0; i < nuevosNumeros.Length; i++)
            {
                Console.Write(nuevosNumeros[i] + " ");
            }

            // Recorrido con foreach
            foreach (int i in nuevosNumeros)
            {
                Console.Write(i + " ");
            }


            double[] decimales = new double[5] { 1.1, 2.2, 3.3, 4.4, 5.5 }; // se puede simplificar como abajo con expresiones de coleccion
            double[] doubles = [1.1, 2.2, 3.3, 4.4, 5.5];


            // forma de medir el tiempo con stopwatch

            Stopwatch sw = new();
            sw.Start();
            sw.Stop();
            sw.Restart();
            sw.Stop();
            Console.WriteLine($"milisegundos: {sw.ElapsedMilliseconds}");


            Console.WriteLine(new string('*', 50));

            List<int> lista = [1, 2]; // por defecto sin elementos tiene tamaño 0, igual que cualquier colección creo xd
            Queue<int> cola = [];


            lista.Add(1);
            cola.Enqueue(1);
            cola.Dequeue();

            foreach (int numero in lista)
            {
                Console.WriteLine(numero);
            }


            // lista de objetos, seguir con esto 
            List<Persona> personas = [new Estudiante("naza", 19, "UTN FRA")];
            personas.Add(new Estudiante("beto", 49, "UBA"));

            Persona persona = new("lara", 20);
            personas.Add(persona);


            // Polimorfismo
            foreach (Persona p in personas)
            {
                p.Presentarse();
            }


            Console.ReadKey();
        }
    }
    

    // Clase con constructor tradicional, si quiero usar el principal no debe ser una clase de la que otras van a heredar, osea clase padre
    // ya que el constructor principal seria solo para clases y objetos que almacenan datos y ya.
    // El uso de constructores principales es limitado en escenarios de herencia.
    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }


        public Persona(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        public virtual void Presentarse()
        {
            Console.Write($"Hola, me llamo {Nombre} y tengo {Edad} años ");
        }
    }


    class Estudiante : Persona
    {
        public string Universidad { get; set; }

        public Estudiante(string nombre, int edad, string universidad) : base(nombre, edad)
        {
            this.Universidad = universidad;
        }
            

        public override void Presentarse()
        {
            base.Presentarse();
            Console.WriteLine($"y estoy estudiando en {Universidad}.");
        }

    }
}
