using Interfaces.Models;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cerveza cerveza = new(120, 15);
            var vino = new Vino(100, 8, "Vino tinto");

            MostrarRecomendacion(cerveza);
            MostrarRecomendacion(vino);


            Console.ReadKey();
        }

        public static void MostrarRecomendacion(IBebidaAlcoholica bebida)
        {
            int cantidad = bebida.MaximoBebidasPermitido();
            Console.WriteLine($"Recomendacion: {cantidad} tragos");
        }

        
    }
}
