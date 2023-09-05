using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace PrimerWEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController : ControllerBase
{
     private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Arroz", PrecioEnPesos = 50.99M },
            new Producto { Id = 2, Nombre = "Leche", PrecioEnPesos = 30.49M },
            new Producto { Id = 3, Nombre = "Pan", PrecioEnPesos = 25.00M },
            new Producto { Id = 4, Nombre = "Huevos", PrecioEnPesos = 40.75M },
            new Producto { Id = 5, Nombre = "Aceite de cocina", PrecioEnPesos = 70.25M }
        };

    private readonly ILogger<ProductosController> _logger;

    public ProductosController(ILogger<ProductosController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProductos")] 
    public ActionResult<IEnumerable<Producto>> GetAll()
    {
        return Ok(productos);
    }

    [HttpGet("Producto/{id}")]   
    public ActionResult<Producto> Get(int id)
    {
        return Ok(productos.First( a=> a.Id == id));
    }
}
