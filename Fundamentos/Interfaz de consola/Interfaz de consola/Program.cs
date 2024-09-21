namespace Interfaz_de_consola
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Principales metodos 
             Console.SetCursorPosition(int left, int top): Establece la posición del cursor en la consola. 
             El parámetro left indica la columna (horizontal), y top indica la fila (vertical).

             Console.CursorLeft y Console.CursorTop: Propiedades para obtener o establecer la posición actual del cursor.

             Console.Clear(): Limpia la consola, dejando el cursor en la esquina superior izquierda.
             */

            Console.Clear(); // Limpia la pantalla

            Console.SetCursorPosition(12, 14); // primer parametro: horizontal (columna), segundo parametroetro: vertical (fila)
            int dato = Console.CursorLeft; // obtener posicion horizontal del cursor, con CursorTop obtenemos la posicion vertical
            Console.WriteLine(dato);


            // Ejemplo de menu interactivo

            // Configurar la consola
            Console.Clear();
            Console.SetWindowSize(50, 20);

            // Título
            Console.SetCursorPosition(10, 2); // Establecer posición en la fila 2, columna 10
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("INTERFAZ DE CONSOLA");

            // Mensajes en diferentes posiciones
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Opción 1: Ver datos");

            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Opción 2: Modificar datos");

            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opción 3: Salir");

            // Resetear el color original al finalizar
            Console.ResetColor();

            // Esperar input para mantener la consola abierta
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.Read();


            // Ejemplo de tablas
            Console.Clear();

            // Título de la tabla
            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Tabla de Datos:");

            // Encabezados
            Console.SetCursorPosition(5, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nombre      | Edad | Ciudad");

            // Filas de datos
            Console.SetCursorPosition(5, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ana         | 25   | Madrid");

            Console.SetCursorPosition(5, 7);
            Console.WriteLine("Carlos      | 30   | Barcelona");

            Console.SetCursorPosition(5, 8);
            Console.WriteLine("Lucía       | 28   | Valencia");

            // Resetear el color original al finalizar
            Console.ResetColor();

            // Esperar input para mantener la consola abierta
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadLine();



            //// Ejemplo de barra de progreso
            //Console.Clear();

            //MostrarBarraDeProgreso(ConsoleColor.Blue);
            //Console.ReadLine();
            //Console.Clear();

            // Ejemplo de viñetas
            Console.WriteLine("Lista de Tareas:");
            Console.WriteLine("• Tarea 1: Completar el informe");
            Console.WriteLine("• Tarea 2: Revisar correos");
            Console.WriteLine("• Tarea 3: Reunión a las 3:00 PM");

            
            //// Ejemplo de toolips
            //Console.WriteLine("Presiona una tecla para más información...");
            //Console.ReadKey(); // Espera a que el usuario presione una tecla
            //Console.SetCursorPosition(2, Console.CursorTop + 1); // Mueve el cursor 2 líneas abajo
            //Console.WriteLine("Tooltip: La opción seleccionada muestra más detalles.");
            //Console.ReadLine();
            //Console.Clear();


            // Otro ejemplo de barra de progreso
            //MostrarBarraProgresoArchivo(ConsoleColor.Red);
            //Console.ReadLine();
            //Console.Clear();
            


            Tarea tarea = new("Tarea 1", 90);
            tarea.MostrarTarea();

            Console.ReadLine();
            Console.Clear();

            Console.ReadKey();
        }

        // Se crean nuevos strings en cada iteración, menos eficiente
        public static void MostrarBarraDeProgreso(ConsoleColor color)
        {
            Console.WriteLine("Procesando...");

            for (int i = 0; i <= 100; i++)
            {
                Console.SetCursorPosition(0, 1); 
                Console.ForegroundColor = color;

                Console.Write($"[");
                // Parte completada de la barra
                Console.Write(new string('=', i / 2));
                // Espacios restantes
                Console.Write(new string(' ', 50 - i / 2)); 
                Console.Write($"] {i}%");
                Console.ResetColor();
                Thread.Sleep(50); 
            }

            Console.WriteLine("\nCompletado!");
            Console.ReadKey();

        }
        public static void MostrarBarraProgresoArchivo(ConsoleColor color)
        {

            Console.WriteLine("Descargando archivo...");
            for (int i = 0; i <= 100; i++)
            {
                Console.SetCursorPosition(0, 1);
                Console.ForegroundColor = color;

                Console.Write("[");
                for (int j = 0; j < i / 2; j++)
                {
                    Console.Write("="); // Progreso completado
                }
                for (int j = i / 2; j < 50; j++)
                {
                    Console.Write(" "); // Espacios restantes
                }
                Console.Write($"] {i}%");
                Console.ResetColor();

                Thread.Sleep(100); // Simular descarga
            }

            Console.SetCursorPosition(0, 3);
            Console.WriteLine("Descarga completada!");
        }
    }
}
