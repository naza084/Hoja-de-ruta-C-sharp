using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    class Vino : Bebida, IBebidaAlcoholica
    {

        public int Alcohol { get; set; }

        public Vino(int cantidadMililitros, double precio, string marca = "Vino") : base(marca, precio, cantidadMililitros)
        {

        }

        public int MaximoBebidasPermitido() => 3;

    }
}
