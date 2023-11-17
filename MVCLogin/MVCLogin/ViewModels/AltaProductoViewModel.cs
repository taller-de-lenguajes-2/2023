using System.ComponentModel.DataAnnotations;
using MVC.Models;

namespace MVC.ViewModels
{
    public class AltaProductoViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre")] 
        public string Nombre {get;set;}        
        
        [Required] 
        public int Precio {get;set;}

        public AltaProductoViewModel(Producto producto)
        {           
            Nombre = producto.Nombre;
            Precio = producto.Precio;        
        }

        public AltaProductoViewModel()
        {
        }
    }
}