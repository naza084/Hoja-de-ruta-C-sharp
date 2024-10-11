namespace Convenciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Reglas para Nombres de Variables:
            /* 
            Deben comenzar con una letra o _: Los nombres de variables en C# deben comenzar con una 
            letra (a-z o A-Z) o _. No pueden comenzar con números u otros caracteres especiales.

            Pueden contener letras, números o _: Después del primer carácter, los nombres de variables
            pueden contener letras, números o _. No se permiten otros caracteres especiales.

            Sensible a mayúsculas y minúsculas: C# distingue entre mayúsculas y minúsculas en los nombres
            de las variables. Por lo tanto, miVariable y mivariable serían tratados como dos variables diferentes.

            No se pueden utilizar palabras reservadas: No puedes utilizar palabras reservadas de C# como 
            nombres de variables. Por ejemplo, int, string, for, class, etc.
            */


            // Convenciones de Nomenclatura:
            /* 
            camelCase: Nombrar las variables(locales y globales) y parámetros utilizando camelCase, 
            donde la primera letra de cada palabra, excepto la primera, se escribe en mayúscula. 
            Por ejemplo: miVariable, nombreUsuario, numeroDeIntentos.

            UpperCamelCase: Similar a PascalCase, se utiliza para nombrar namespaces. Por ejemplo: MiNamespace.

            ALL_CAPS: Utilizado para nombrar constantes, donde todas las letras se escriben en mayúscula y las 
            palabras están separadas por guiones bajos. Por ejemplo: LIMITE_INFERIOR, LIMITE_SUPERIOR.

            Underscore Prefix: Algunas veces se usa un guion bajo como prefijo para variables privadas. 
            Ejemplo: _miVariable, _nombreDeUsuario.
            */


            // Convenciones en POO
            /*
            PascalCase: Es la convención predominante en C# para nombrar METODOS y miembros de clase (campos, propiedades, etc.)
            e interfaces y enumeraciones. La primera letra de cada palabra en el nombre de la variable debe ser mayúscula. 
            Por ejemplo: NombreDeUsuario, ContadorDeClicks.

            camelCase: Nombrar las variables(locales y globales) y parámetros utilizando camelCase, 
            donde la primera letra de cada palabra, excepto la primera, se escribe en mayúscula. 
            Por ejemplo: nombreUsuario, numeroDeIntentos.

            Prefijos para Indicar Tipo: A veces se utilizan prefijos para indicar el tipo de variable, como 
            strNombre para una variable de tipo cadena, intContador para una variable de tipo entero, etc.

            Underscore Prefix: Algunas veces se usa un guion bajo como prefijo para campos privados. 
            Ejemplo: _nombreDeUsuario, _dniUsuario.
             */
        }
    }
}
