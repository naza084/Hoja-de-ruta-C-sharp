using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_y_objetos.Models
{
    /* Modificadores de acceso de clases o metodos:
     
       public: La clase o miembro es accesible desde cualquier ensamblado.
       internal: La clase o miembro es accesible solo dentro del mismo ensamblado(por defecto una clase sin modificador es internal como cerveza).
       protected: La clase o miembro es accesible solo dentro de su propia clase y clases derivadas.
       private: La clase o miembro es accesible solo dentro de su propia clase.
       protected internal: La clase o miembro es accesible dentro del mismo ensamblado y también en clases derivadas fuera del ensamblado.
     */
   
    class Cerveza : Bebida
    {
        // Por defecto todas tienen el nombre de cerveza, lo puedo cambiar en la declaracion o lo puedo especificar con un parametro en el constructor:
        //public Cerveza(string marca, double precio, int cantidadMililitros) : base(marca, precio,cantidadMililitros) 
        //public Cerveza() : base("Cerveza", 0.5, 355) otro ejemplo
        public Cerveza(int cantidadMililitros, double precio, string marca = "Cerveza") : base(marca, precio, cantidadMililitros)
        {

        }
    }
}
