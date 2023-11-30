using System;
using System.IO;

namespace EjemploN5
{
    class Program
    {
        static void Main(string[] args)
        {

            string nombreDeArchivo = @"Data\\config.json";
            FileStream fs = null;
            try
            {
                fs = NewMethod(nombreDeArchivo);
            }
            catch (DirectoryNotFoundException e)
            {                
                throw new ConfigFileDontFoundException($"[La carpeta {nombreDeArchivo} no encontrada]", e);
            }
            catch (ConfigFileDontFoundException e)
            {
                Console.WriteLine($"[Archivo de configuración no fué encontrado]"); // Información para el usuario                                        
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }

        private static FileStream NewMethod(string nombreDeArchivo)
        {
            try
            {
                FileStream fs;
                fs = new FileStream(nombreDeArchivo, FileMode.Open); // busco un archivo
                var sr = new StreamReader(fs); // Abro el archivo                
                string line = sr.ReadLine(); // Leo una linea 
                Console.WriteLine(line); // muestro la linea por pantalla
                return fs;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new ConfigFileDontFoundException($"[La carpeta {nombreDeArchivo} no encontrada]", e);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"[Archivo no encontrado] {e}"); // Información para el usuario
                throw new ConfigFileDontFoundException($"[Archivo no encontrado] {e}", e);
            }
        }
    }
}
