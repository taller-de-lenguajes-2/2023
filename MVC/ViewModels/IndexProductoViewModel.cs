using PruebaMVC.Models;
namespace PruebaMVC.ViewModels
{
    public class IndexProductoViewModel
{
    public List<ElementoIndexProductoViewModel> ProductoViewModels{get;set;}

    public IndexProductoViewModel(List<Producto> productos)
    {
        ProductoViewModels = new List<ElementoIndexProductoViewModel>();
        foreach (var producto in productos)
        {
            ProductoViewModels.Add(new ElementoIndexProductoViewModel{
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio
            });
        }
    }
}
}