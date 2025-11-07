using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using modelos; // Usamos el modelo de dominio en el controlador
using ViewModels; // Usamos los ViewModels para las vistas

namespace TuProyecto.Controllers
{
    public class ProductosController : Controller
    {
        // Lista Estática: Contiene objetos del MODELO DE DOMINIO (modelos.Producto)
        private static List<Producto> _productosDominio = new List<Producto>
        {
            // Inicializamos la lista estática con el Modelo de Dominio
            new Producto { Id = 1, Nombre = "Laptop Gaming", Precio = 1200 },
            new Producto { Id = 2, Nombre = "Mouse Inalámbrico", Precio = 25 },
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Precio = 80 }
        };

        private static int _nextId = 4; // Para asignar IDs únicos

        public ProductosController()
        {
        }

        //
        // GET: /Productos/Index
        //
        public IActionResult Index()
        {
            // 💡 Transformación: De List<Producto> a List<ProductoViewModel>
            var productosViewModel = _productosDominio
                .OrderBy(p => p.Id)
                .Select(p => new ProductoViewModel(p)) // Usamos el constructor de mapeo
                .ToList();

            var viewModel = new ProductoListViewModel
            {
                Productos = productosViewModel
            };
            return View(viewModel);
        }

            //
        // POST: /Productos/Create
        //
        [HttpGet]     
        public IActionResult Create()
        {            
            return View(new ProductoViewModel());
        }

        //
        // POST: /Productos/Create
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductoViewModel productoVM)
        {
            if (ModelState.IsValid)
            {
                // 💡 Transformación Inversa: De ProductoViewModel a Producto (Modelo de Dominio)
                var productoDominio = new Producto
                {
                    Id = _nextId++,
                    Nombre = productoVM.Nombre,
                    Precio = productoVM.Precio
                };

                _productosDominio.Add(productoDominio);
                return RedirectToAction(nameof(Index));
            }
            return View(productoVM);
        }

   
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var productoDominio = _productosDominio.FirstOrDefault(p => p.Id == id);
            if (productoDominio == null) return NotFound();
            
            // Creamos un ViewModel a partir del Dominio para la vista de confirmación
            var productoVM = new ProductoViewModel(productoDominio); 
            return View(productoVM);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productoDominio = _productosDominio.FirstOrDefault(p => p.Id == id);
            if (productoDominio != null)
            {
                _productosDominio.Remove(productoDominio);
            }
            return RedirectToAction(nameof(Index)); 
        }
    }
}