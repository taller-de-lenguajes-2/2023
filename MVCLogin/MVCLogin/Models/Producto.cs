using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MVC.ViewModels;

namespace MVC.Models
{
    public class Producto
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public int Precio {get;set;}

        public Producto()
        {           
            
        }
        public Producto(AltaProductoViewModel productoVM)
        {           
            Nombre = productoVM.Nombre;
            Precio = productoVM.Precio;        
        }

    }
}