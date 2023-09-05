// See https://aka.ms/new-console-template for more information
using _2023;

Console.WriteLine("Hello, World!");

var motor = new Motor("brawwwsssshhhh");
List<Rueda> ruedas = new List<Rueda>();
ruedas.Add(new Rueda());
ruedas.Add(new Rueda());
ruedas.Add(new Rueda());
ruedas.Add(new Rueda());

var auto = new Auto("amarillo","123",Marcas.Ferrari,motor,ruedas);
auto.Encender();
