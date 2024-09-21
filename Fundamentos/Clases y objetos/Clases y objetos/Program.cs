using Clases_y_objetos.Models; // importamos el namespace Models, (si quiero importar una clase en especifico hay que usar static)
// using static Clases_y_objetos.Models.Bebida;  importar una clase especifica por medio de static
using ConsolaEnEspañol = System.Console; // importo un espacio de nombres y lo asigno a un alias para usarlo
using ListaEnteros = System.Collections.Generic.List<int>;

namespace Clases_y_objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Practica del video
            Bebida bebida = new("Coca cola", 1.5, 500);
            bebida.MostrarInformacion();
            bebida.Beber(100);

            Cerveza cerveza = new(2, 5.5);
            cerveza.Beber(330);



            // Practica propia
            /*
            Importación de Carpeta Completa:
            En C#, no puedes importar una carpeta completa con todas sus clases directamente. Debes importar cada espacio de nombres individualmente. 
            Sin embargo, si todas las clases en una carpeta están bajo el mismo espacio de nombres, una sola importación del espacio de nombres será suficiente.
            
            Ejemplo:
            using Clases_y_objetos.Models; aca se importa la clase bebida y las que se vayan a crear en ese espacio de nombres
            */

            Superheroe superheroe1 = new("Superman", 150);
            superheroe1.Saludar();
            superheroe1.Atacar();

            ConsolaEnEspañol.WriteLine(superheroe1.PoderAtaque);
            ConsolaEnEspañol.WriteLine(nameof(superheroe1.Nombre));

            ListaEnteros lista = [1, 2, 3];
            lista.Add(1);
            ConsolaEnEspañol.WriteLine(string.Join(", ", lista)); // 1, 2, 3, 1
            
            
            ConsolaEnEspañol.ReadKey();
        }
    }
    
    // Clase con constructor principal(tambien de instancia como el tradicional), no tiene constructor tradicional y es más conciso
    // Util para clases con pocos atributos o que esos atributos no requieran logica que no se puede expresar en una linea
    class Superheroe(string nombre, int poderAtaque)
    {
        public string Nombre { get; set; } = nombre;
        public int PoderAtaque { get; set; } = poderAtaque;

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy {Nombre} y mi poder de ataque es {PoderAtaque}");
        }

        public void Atacar()
        {
            Console.WriteLine($"Estoy atacando y causo {PoderAtaque} de daño");
        }
    }


}
