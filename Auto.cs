using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public enum Marcas
{
    BMW,
    Ferrari,
    Fiat,
    Tesla
}

namespace _2023
{
    public class Auto
    {
        private string color;
        private string patente;
        private Marcas marca;
        private Motor motor;
        private List<Rueda> ruedas;

        /// <summary>
        /// Creando con composición o dependencia fuerte
        /// </summary>
        /// <param name="color"></param>
        /// <param name="patente"></param>
        /// <param name="marca"></param>
        /// <param name="sonido"></param>
        public Auto(string color, string patente, Marcas marca,string sonido)
        {
            this.color = color;
            this.patente = patente;
            this.marca = marca;
            motor = new Motor(sonido);
            this.ruedas = new List<Rueda>();
            ruedas.Add(new Rueda());
            ruedas.Add(new Rueda());
            ruedas.Add(new Rueda());
            ruedas.Add(new Rueda());
        }

        /// <summary>
        /// Creando con agregación o dependencia debil
        /// </summary>
        /// <param name="color"></param>
        /// <param name="patente"></param>
        /// <param name="marca"></param>
        /// <param name="motor"></param>
        /// <param name="ruedas"></param>
         public Auto(string color, string patente, Marcas marca,Motor motor,List<Rueda> ruedas)
        {
            this.color = color;
            this.patente = patente;
            this.marca = marca;
            this.motor = motor;
            this.ruedas = ruedas;
        }

        public void Encender()
        {
            motor.Encender();
        }
    }
}