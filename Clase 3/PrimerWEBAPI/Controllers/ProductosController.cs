using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace PrimerWEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController : ControllerBase
{
     private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Arroz", PrecioEnPesos = 50.99M, Stock = 10 },
            new Producto { Id = 2, Nombre = "Leche", PrecioEnPesos = 30.49M, Stock = 20 },
            new Producto { Id = 3, Nombre = "Pan", PrecioEnPesos = 25.00M, Stock= 0 },
            new Producto { Id = 4, Nombre = "Huevos", PrecioEnPesos = 40.75M, Stock = 100},
            new Producto { Id = 5, Nombre = "Aceite de cocina", PrecioEnPesos = 70.25M, Stock = 1 }
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

    [HttpGet("GetProducto/{id}")]   
    public ActionResult<Producto> Get(int id)
    {
        Producto producto = productos.FirstOrDefault( a=> a.Id == id);
        
        if(producto==null) return NotFound();
        
        return Ok(producto);
    }

    [HttpGet("GetProducto/{id}/{stock}")]   
    public ActionResult<Producto> Get(int id, int stock)
    {
        Producto producto = productos.FirstOrDefault( a=> a.Id == id && a.Stock > stock );
        
        if(producto==null) return NotFound();
        
        return Ok(producto);
    }

    [HttpPost("Add")]   
    public ActionResult<Producto> Add([FromForm]Producto producto)
    {
        if(producto==null) return NotFound();
        int nuevoId = productos.Max(producto => producto.Id) + 1;
        producto.Id = nuevoId; 
        productos.Add(producto);
        return Ok(producto);
    }

    
}
