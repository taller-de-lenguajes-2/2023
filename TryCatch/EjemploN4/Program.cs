using System;

namespace EjemploN4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Calculador de división"); // muestro la linea por pantalla
                
                Console.WriteLine("Ingrese el Dividendo:"); // muestro la linea por pantalla
                var N1 = Convert.ToInt32(Console.ReadLine()); // muestro la linea por pantalla
                
                Console.WriteLine("Ingrese el Divisor:"); // muestro la linea por pantalla
                var N2 = Convert.ToInt32(Console.ReadLine()); // muestro la linea por pantalla
                
                int cociente = Dividir(N1,N2);
                
                Console.WriteLine(cociente); // muestro la linea por pantalla
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Error al dividir] {e.Message}"); // Información para el usuario
                Console.WriteLine($"[Error al dividir] {e.StackTrace}"); // Información para el usuario 
            }

        }
        
        static int Dividir(int Dividendo,int Divisor)
        {
            return Dividendo / Divisor;                      
        }
    }
}
