// See https://aka.ms/new-console-template for more information
using MediosDeTrasporte;


var motor = new Motor("brawwwsssshhhh");
List<Rueda> ruedas = new List<Rueda>();
ruedas.Add(new Rueda());
ruedas.Add(new Rueda());
ruedas.Add(new Rueda());
ruedas.Add(new Rueda());

Vehiculo auto = new Auto("amarillo","123",Marcas.Ferrari,motor,ruedas);
Vehiculo Bici = new Bicicleta("amarillo","123",Marcas.Ferrari);
List<Vehiculos> lista = new List<Vehiculos>();
lista.Add(auto);
lista.Add(Bici);


foreach (var VehiculoX in lista)
{
    VehiculoX.Conducir();
}