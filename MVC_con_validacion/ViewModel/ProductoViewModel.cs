using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using modelos; // Importamos el namespace del modelo de dominio

namespace ViewModels
{
    public class ProductoViewModel
    {
        // 🔑 Propiedades del ViewModel
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre {2} y {1} caracteres.")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1, 100000, ErrorMessage = "El precio debe estar entre {1} y {2}.")]
        [DisplayName("Precio Unitario")]
        public int Precio { get; set; }

        // ----------------------------------------------------
        // 🛠️ Constructor para Mapeo (Transformación)
        // ----------------------------------------------------
        
        // Constructor vacío (necesario para la deserialización y los formularios POST)
        public ProductoViewModel() { } 

        /// <summary>
        /// Crea un ProductoViewModel a partir de un objeto Producto (Modelo de Dominio).
        /// </summary>
        public ProductoViewModel(Producto producto)
        {
            // Mapeo (Transformación) de Propiedades
            this.Id = producto.Id;
            this.Nombre = producto.Nombre;
            this.Precio = producto.Precio;
        }
    }

    // ViewModel para la lista (Index)
    public class ProductoListViewModel
    {
        public IEnumerable<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();
    }
}