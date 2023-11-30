using System;
using System.IO;

namespace EjemploN2
{
    class Program
    {
        static void Main(string[] args)
        {

            string nombreDeArchivo = @"Data\\config.json";
            FileStream fs = null;
            try
            {
                fs = new FileStream(nombreDeArchivo, FileMode.Open); // busco un archivo
                var sr = new StreamReader(fs); // Abro el archivo                
                string line = sr.ReadLine(); // Leo una linea 
                Console.WriteLine(line); // muestro la linea por pantalla
                if (fs != null)
                    fs.Close();
            }
            catch (Exception e)
            {             
                Console.WriteLine($"[Archivo no encontrado] {e}"); // Información para el usuario               
            }
            finally
            {
               
            }

        }
    }
}
