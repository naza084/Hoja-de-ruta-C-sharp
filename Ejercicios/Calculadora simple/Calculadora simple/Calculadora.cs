using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_simple
{
    static class Calculadora
    {

        public static double Calcular(double operando1, double operando2, string operacion)
        {
            double resultado = operacion switch
            {
                "+" => operando1 + operando2,
                "-" => operando1 - operando2,
                "*" => operando1 * operando2,
                "/" when ValidarDivisor(operando2) => operando1 / operando2,
                _ => 0
            };

            return resultado;
        }

        private static bool ValidarDivisor(double divisor) => divisor != 0;
    }
}
