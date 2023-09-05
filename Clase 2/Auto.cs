using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace MediosDeTrasporte


    public enum Marcas
{
    BMW,
    Ferrari,
    Fiat,
    Tesla
}

    public interface ISistemaDePersistencia
    {
        void Guardar();
        void Leer();
    }

    public interface IVehiculo
    {
        void Conducir();
    }


    public interface IVehiculosConMotor
    {
        void Encender();
        void Apagar();
    }

    public interface IVehiculosQueVuelan
    {
        void Volar();
    }

    public abstract class Vehiculo
    {
        protected string color;
        protected string patente;
        protected Marcas marca;

        public Vehiculo(string color, string patente, Marcas marca)
        {
            this.color = color;
            this.patente = patente;
            this.marca = marca;
        }

        public abstract void Conducir();    
    }

    public class Bicicleta:Vehiculo
    {
         private List<Rueda> ruedas;
           public Bicicleta(string color, string patente, Marcas marca)
        :base(color,patente,marca)
        {                    
            this.ruedas = new List<Rueda>();
            ruedas.Add(new Rueda());
            ruedas.Add(new Rueda());
        }

        public override void Conducir()
        {
            System.Console.WriteLine("Conduciendo Bicicleta");
        }
    }



    public class Auto : IVehiculo,IVehiculosConMotor
    {
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
        :base(color,patente,marca)
        {            
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

        public override void Conducir()
        {            
            System.Console.WriteLine("conducción de auto");
        }

        public void Apagar()
        {
            motor.Apagar();
        }

        public void Encender()
        {
            motor.Encender();
        }
    }
}