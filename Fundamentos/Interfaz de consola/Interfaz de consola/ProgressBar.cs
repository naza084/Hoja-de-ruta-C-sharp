using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_de_consola
{
    internal class ProgressBar
    {
        private readonly int _tamañoBarra;
        private readonly char _caracterCompleto;
        private readonly char _caracterPendiente;

        public ProgressBar(int tamañoBarra = 12, char caracterCompleto = '=', char caracterPendiente = ' ')
        {
            if (tamañoBarra <= 0)
            {
                throw new ArgumentException("El tamaño de la barra debe ser mayor que 0.");
            }
            _tamañoBarra = tamañoBarra;
            _caracterCompleto = caracterCompleto;
            _caracterPendiente = caracterPendiente;
        }


        public void MostrarProgreso(int progresoActual, int progresoMaximo)
        {
            if (progresoMaximo <= 0)
            {
                Console.WriteLine("El valor de 'progresoMaximo' debe ser mayor que 0.");
                return;
            }

            if (progresoActual < 0)
            {
                progresoActual = 0;
            }

            int barraCompleta = Math.Min((progresoActual * _tamañoBarra) / progresoMaximo, _tamañoBarra);
            int porcentaje = Math.Min((progresoActual * 100) / progresoMaximo, 100);


            Console.ForegroundColor = ColorearBarraSegunPorcentaje(porcentaje);
            ImprimirBarra(barraCompleta, porcentaje);

            Console.ResetColor();
            Console.WriteLine();
        }


        private void ImprimirBarra(int barraCaracteres, int porcentaje)
        {
            Console.Write("[");
            Console.Write(new string(_caracterCompleto, barraCaracteres)); // Parte completada
            Console.Write(new string(_caracterPendiente, _tamañoBarra - barraCaracteres)); // Espacios restantes
            Console.Write($"] {porcentaje}%");
        }


        private static ConsoleColor ColorearBarraSegunPorcentaje(int porcentaje)
        {
            ConsoleColor colorBarra = porcentaje switch
            {
                0 => ConsoleColor.Gray,
                < 50 => ConsoleColor.Red,
                > 50 and < 80 => ConsoleColor.Yellow,
                _ => ConsoleColor.Green
            };

            return colorBarra;
        }
    }
}
