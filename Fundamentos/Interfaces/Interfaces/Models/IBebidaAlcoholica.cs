using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    interface IBebidaAlcoholica
    {
        public int Alcohol { get; set; }


        // definición de metodo que cada clase debe implementar y desarrollar
        public int MaximoBebidasPermitido();

        
        // metodo implementado en la interfaz, las clases que lo implementen no tienen que definirlo
        public void MostrarEfectosAlcoholicos()
        {
            Console.WriteLine("Efectos Alcoholicos: mareos, falta de claridad visual, posibles vomitos.");
        }

    }
}
