using System;
using System.IO;

namespace EjemplosConcurso
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
            }            
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"[Directorio no encontrado] {e}"); // Información para el usuario                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"[Archivo no encontrado] {e}"); // Información para el usuario             
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hubo un problema al intentar abrir el archivo {e}"); // Información para el usuario               
            }

            finally
            {
                if (fs != null)
                    fs.Close();
            }
            
        }
    }
}
