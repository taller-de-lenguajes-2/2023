using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2023
{
    public class Motor
    {
        
        private string sonido;
        public Motor(string sonido)
        {
            this.sonido = sonido;
        }

        public void Encender()
        {
            System.Console.WriteLine(sonido);
        }
    }
}