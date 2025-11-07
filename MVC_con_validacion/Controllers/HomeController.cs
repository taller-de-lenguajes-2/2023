using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using modelos;
using muestrao.Models;

namespace muestrao.Controllers;

public class HomeController : Controller
{
    private static List<Producto> productos = new List<Producto>();


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult CrearProducto()
    {
        return View(new Producto());
    }

    [HttpGet]
    public IActionResult ListarProductos()
    {
        Producto producto1 = new Producto();
        producto1.Nombre = "Papas fritas";
        producto1.Precio = 123;
        
        Producto producto2 = new Producto();
        producto2.Nombre = "Chocolates";
        producto2.Precio = 123;
        
        productos.Add(producto2);
        productos.Add(producto1);

        return View(productos);
    }
    
    [HttpPost]
    public IActionResult CrearProducto(Producto producto)
    {   
        return View("Index");
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult Producto()
    {
        Producto producto = new Producto();
        producto.Nombre = "Papas fritas";
        producto.Precio = 123;
        return View(producto);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
