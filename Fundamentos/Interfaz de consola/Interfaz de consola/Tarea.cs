using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_de_consola
{
    internal class Tarea
    {
        public string Nombre { get; set; }
        private int _progreso;
        private readonly int _progresoMaximo = 100;
        private readonly int _progresoMinimo = 0;
        private readonly ProgressBar _barraProgreso;

        public int Progreso
        {
            get { return _progreso; }
            set
            {
                if (value < _progresoMinimo)
                {
                    _progreso = _progresoMinimo;
                }
                else if (value > _progresoMaximo)
                {
                    _progreso = _progresoMaximo;
                }
                else
                {
                    _progreso = value;
                }
            }
        }
            

        public Tarea(string nombre, int progreso)
        {
            Nombre = nombre;
            // Asegurar un valor positivo
            Progreso = progreso >= 0 ? progreso : 0; 
            _barraProgreso = new(12, '█');
        }


        public void MostrarTarea()
        {
            Console.WriteLine($"Tarea: {Nombre}");
            Console.Write($"Progreso: ");
            _barraProgreso.MostrarProgreso(Progreso, _progresoMaximo);
        }
    }
}

