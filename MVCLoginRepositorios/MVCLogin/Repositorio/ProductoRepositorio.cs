using MVC.Models;

namespace MVCLogin.Repositorio
{

    public class ProductoRepositorio : IProductoRepositorio
    {
        private static List<Producto> _productos = new List<Producto>();

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _productos;
        }

        public Producto ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {         
            producto.Id = obtenerProximoId();
            _productos.Add(producto);
        }


        public void Actualizar(Producto entidad)
        {
            var productoExistente = _productos.FirstOrDefault(p => p.Id == entidad.Id);

            if (productoExistente == null)
            {
                throw new InvalidOperationException("Producto que se intenta actualizar no existe.");
            }

            productoExistente.Nombre = entidad.Nombre;
            productoExistente.Precio = entidad.Precio;
        }

        public void Eliminar(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                throw new InvalidOperationException("Producto que se intenta eliminar no existe.");
            }           
           _productos.Remove(producto);           
        }
        private static int obtenerProximoId()
        {
            return (_productos.Count() == 0) ? 1 : _productos.Max(prod => prod.Id) + 1;
        }
    }
    
}
