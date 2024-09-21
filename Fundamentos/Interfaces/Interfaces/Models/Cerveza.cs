using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    /* Modificadores de acceso de clases o metodos:
     
       public: La clase o miembro es accesible desde cualquier ensamblado.
       internal: La clase o miembro es accesible solo dentro del mismo ensamblado(por defecto una clase sin modificador es internal como cerveza).
       protected: La clase o miembro es accesible solo dentro de su propia clase y clases derivadas.
       private: La clase o miembro es accesible solo dentro de su propia clase.
       protected internal: La clase o miembro es accesible dentro del mismo ensamblado y también en clases derivadas fuera del ensamblado.
    */


    // con constructor principal:
    // class Cerveza(int cantidadMililitros, double precio, string marca = "Cerveza") : Bebida(marca, precio, cantidadMililitros)

    // cuando se se usa una clase para heredar se llama herencia, cuando se use una interfaz se llama implementar.
    class Cerveza : Bebida, IBebidaAlcoholica
    {

        // Atributo obligatorio a la clase por la interfaz
        public int Alcohol { get; set; }

        public Cerveza(int cantidadMililitros, double precio, string marca = "Cerveza") : base(marca, precio, cantidadMililitros)
        {

        }

        public int MaximoBebidasPermitido() => 4;

    }
}
