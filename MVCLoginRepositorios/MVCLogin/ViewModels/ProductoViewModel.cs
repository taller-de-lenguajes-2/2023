using System.ComponentModel.DataAnnotations;
using MVC.Models;

namespace MVC.ViewModels
{
    public class ProductoViewModel
    {
        [Display(Name = "Id")] 
        public int Id {get;set;}    

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre")] 
        public string Nombre {get;set;}        
        
        [Required] 
        public int Precio {get;set;}

        public ProductoViewModel(Producto producto)
        {  
            Id = producto.Id;         
            Nombre = producto.Nombre;
            Precio = producto.Precio;        
        }

        public ProductoViewModel()
        {
        }
    }
}