using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    /* Usando constructor principal
    class Bebida(string marca, double precio, int cantidadMililitros)
    {
        public string Marca { get; set; } = marca;
        public double Precio { get; set; } = precio;
        public int CantidadMililitros { get; set; } = cantidadMililitros;
    }
    */

    class Bebida
    {
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int CantidadMililitros { get; set; }

        // Usando constructor tradicional
        public Bebida(string marca, double precio, int cantidadMililitros)
        {
            Marca = marca;
            Precio = precio;
            CantidadMililitros = cantidadMililitros;
        }


        public void Beber(int cantidadMililitros)
        {
            if (CantidadMililitros >= cantidadMililitros && CantidadMililitros > 0)
            {
                Console.WriteLine($"Bebiendo {cantidadMililitros}ml de {Marca}");
                CantidadMililitros -= cantidadMililitros;
            }
            else
            {
                Console.WriteLine("No hay suficiente bebida");
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Marca: {Marca} \nPrecio: {Precio} \nCantidad: {CantidadMililitros}ml");
        }

    }
}
