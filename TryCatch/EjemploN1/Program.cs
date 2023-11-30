using System;

namespace EjemploN1
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Calculador de división"); // muestro la linea por pantalla

            Console.WriteLine("Ingrese el Dividendo:"); // muestro la linea por pantalla
            var N1 = Convert.ToInt32(Console.ReadLine()); // convierte el tipo string a int 

            Console.WriteLine("Ingrese el Divisor:"); // muestro la linea por pantalla
            var N2 = Convert.ToInt32(Console.ReadLine()); // convierte el tipo string a int

            int cociente = N1 / N2;

            Console.WriteLine(cociente); // muestro la linea por pantalla           
        }
    }
}
