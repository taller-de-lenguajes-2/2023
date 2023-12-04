using MVC.Models;

namespace MVCLogin.Repositorio
{
    public interface IProductoRepositorio
    {
        void Actualizar(Producto producto);
        void Agregar(Producto producto);
        void Eliminar(int id);
        Producto ObtenerPorId(int id);
        IEnumerable<Producto> ObtenerTodos();
    }
}