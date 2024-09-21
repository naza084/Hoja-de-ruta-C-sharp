using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_y_objetos.Models
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
            this.Marca = marca;
            this.Precio = precio;
            this.CantidadMililitros = cantidadMililitros;
        }


        public void Beber(int cantidadMililitros)
        {
            if (this.CantidadMililitros >= cantidadMililitros && this.CantidadMililitros > 0)
            {
                Console.WriteLine($"Bebiendo {cantidadMililitros}ml de {this.Marca}");
                this.CantidadMililitros -= cantidadMililitros;
            }
            else
            {
                Console.WriteLine("No hay suficiente bebida");
            }            
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Marca: {this.Marca} \nPrecio: {this.Precio} \nCantidad: {this.CantidadMililitros}ml");
        }

    }
}
