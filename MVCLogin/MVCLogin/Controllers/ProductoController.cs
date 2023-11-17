using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productos = new List<Producto>();
        private readonly ILogger<ProductoController> _logger;
        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(productos);
        }

        [HttpGet]
        public IActionResult CrearProducto()
        {  
            if(!isAdmin()) return RedirectToAction("Index");
            return View(new AltaProductoViewModel());
        }

    
        [HttpPost]
        public IActionResult CrearProducto(AltaProductoViewModel productoVM)
        {   
            if(!ModelState.IsValid) return RedirectToAction("Index");
            if(!isAdmin()) return RedirectToAction("Index");

            var producto = new Producto(productoVM);
            producto.Id = productos.Count()+1;
            productos.Add(producto);
            
            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult EditarProducto(int idProducto)
        {  
            if(!isAdmin()) return RedirectToAction("Index");
            var productoBuscado = productos.FirstOrDefault( producto => producto.Id == idProducto);
            if(productoBuscado == null) RedirectToAction("Index");
        
            return View(new ProductoViewModel(productoBuscado!));
        } 


        [HttpPost]
        public IActionResult EditarProducto(ProductoViewModel productoVM)
        {
            if(!isAdmin()) return RedirectToAction("Index");
            var productoEditado = productos.FirstOrDefault(producto => producto.Id == producto.Id);
            if(productoEditado == null)  return RedirectToAction("Index");
            
            productoEditado.Nombre = productoVM.Nombre;
            productoEditado.Precio = productoVM.Precio;
            return RedirectToAction("Index");
           
        }
        public IActionResult DeleteProducto(int idProducto)
        {  
            if(!isAdmin()) return RedirectToAction("Index");
            var productoBuscado = productos.FirstOrDefault( producto => producto.Id == idProducto);
            productos.Remove(productoBuscado);
            return RedirectToAction("Index");
        }

        private bool isAdmin()
        {
            if (HttpContext.Session != null && HttpContext.Session.GetString("NivelDeAcceso") == "admin") 
                return true;
                
            return false;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
