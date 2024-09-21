using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_de_consola
{
    internal class Menu
    {
        public enum MenuOption
        {
            VerDatos = 1,
            ModificarDatos = 2,
            Salir = 3
        }

        private readonly Dictionary<MenuOption, Action> _menuActions;

        public Menu()
        {
            // Inicializar las acciones del menú
            _menuActions = new Dictionary<MenuOption, Action>
            {
                { MenuOption.VerDatos, MostrarDatos },
                { MenuOption.ModificarDatos, ModificarDatos },
                { MenuOption.Salir, Salir }
            };
        }



        

        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción:");
                MostrarOpciones();
                Console.Write("Opción: ");

               

            }
        }

        private void PedirOpcionValida(ref bool continuar)
        {
            if (Enum.TryParse(Console.ReadLine(), out MenuOption opcion) && _menuActions.TryGetValue(opcion, out Action? accion))
            {
                accion.Invoke(); // Ejecutar la acción correspondiente
                continuar = opcion != MenuOption.Salir;
            }
            else
            {
                Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        // Mostrar opciones
        private static void MostrarOpciones()
        {
            Console.WriteLine("1. Ver datos");
            Console.WriteLine("2. Modificar datos");
            Console.WriteLine("3. Salir");
        }

        // Métodos responsables de las acciones del menú
        private void MostrarDatos()
        {
            Console.Clear();
            Console.WriteLine("Mostrando datos...");
            // Lógica para mostrar datos
            Console.WriteLine("Presione una tecla para volver al menú.");
            Console.ReadKey();
        }

        private void ModificarDatos()
        {
            Console.Clear();
            Console.WriteLine("Modificando datos...");
            // Lógica para modificar datos
            Console.WriteLine("Datos modificados. Presione una tecla para volver al menú.");
            Console.ReadKey();
        }

        private void Salir()
        {
            Console.WriteLine("Saliendo de la aplicación...");
        }
    }
}
