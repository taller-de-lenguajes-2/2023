using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;
using MVCLogin.Repositorio;

namespace MVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoController(ILogger<ProductoController> logger,IProductoRepositorio productoRepositorio)
        {
            _logger = logger;
            this._productoRepositorio = productoRepositorio;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_productoRepositorio.ObtenerTodos());
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });            
            }
        }

        [HttpGet]
        public IActionResult CrearProducto()
        {
            try
            {
                if (!isAdmin()) return RedirectToAction("Index");
                return View(new AltaProductoViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear producto {ex.ToString()}");
                return RedirectToAction("Index");
            }
        }

    
        [HttpPost]
        public IActionResult CrearProducto(AltaProductoViewModel productoVM)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("Index");
                if (!isAdmin()) return RedirectToAction("Index");

                var producto = new Producto(productoVM);
                _productoRepositorio.Agregar(producto); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear producto {ex.ToString()}");
               
            }

            return RedirectToAction("Index");           
        }

        [HttpGet]
        public IActionResult EditarProducto(int idProducto)
        {
            try
            {
                if (!isAdmin()) return RedirectToAction("Index");
                var productoBuscado = _productoRepositorio.ObtenerPorId(idProducto);
                if (productoBuscado == null) RedirectToAction("Index");

                return View(new ProductoViewModel(productoBuscado!));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar acceder a un producto {ex.ToString()}");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoViewModel productoVM)
        {
            try
            {
                if (!isAdmin()) return RedirectToAction("Index");
                if (!ModelState.IsValid) return RedirectToAction("Index");

                _productoRepositorio.Actualizar(new Producto(productoVM));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar modificar un producto {ex.ToString()}");
                return RedirectToAction("Index");
            }

        }
        public IActionResult DeleteProducto(int idProducto)
        {
            try
            {
                if (!isAdmin()) return RedirectToAction("Index");
                 _productoRepositorio.Eliminar(idProducto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar modificar un producto {ex.ToString()}");
                return RedirectToAction("Index");
            }
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
