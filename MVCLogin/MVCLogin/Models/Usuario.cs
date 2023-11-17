
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.ViewModels;

namespace MVC.Models
{
   public enum NivelDeAcceso
    {
        simple = 1,
        admin = 2
    }
    public class Usuario
    {
        public NivelDeAcceso NivelDeAcceso {get;set;}
        public string Nombre {get;set;}
        public string Contrasenia{get;set;}

        public Usuario(LoginViewModel loginViewModel)
        {          
            Nombre = loginViewModel.Nombre;
            Contrasenia = loginViewModel.Contrasenia;
        }

        public Usuario()
        {
        }
    }
}