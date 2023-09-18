using System.Collections.Generic;
using System.Linq;

namespace Web_Api;


public class Cadeteria{

    private static Cadeteria cadeteria;

    public static Cadeteria GetCadeteria()
    {
        if (cadeteria==null)
        {
            cadeteria = new Cadeteria();
        }
        return cadeteria;
    }

    private List<Pedido> _pedidos;
    private string _nombre;

    public string Nombre { get => _nombre; set => _nombre = value; }

    public Cadeteria()
    {
        _pedidos = new List<Pedido>();
        _nombre = "Cadeteria la prueba";
        _pedidos.Add(new Pedido{
            Nro = 1,
            Observacion = " Es el primer pedido"
        });
        _pedidos.Add(new Pedido{
            Nro = 2,
            Observacion = " Es el segundo pedido"
        });
        _pedidos.Add(new Pedido{
            Nro = 3,
            Observacion = " Es el tercer pedido"
        });
    }

    public Pedido GetPedido(int nro)
    {
        return _pedidos.FirstOrDefault(t => t.Nro == nro);
    }

    public List<Pedido> DevolverPedidos()
    {
        return _pedidos;
    }


     public Pedido AgregarPedido(Pedido pedido)
    {
        _pedidos.Add(pedido);
        pedido.Nro = _pedidos.Count;
        return pedido;
    }

    public Pedido ModificarPedido(Pedido pedido)
    {
        var pedidoAModificar = _pedidos.FirstOrDefault(t => t.Nro == pedido.Nro);
        pedidoAModificar.Observacion =  pedido.Observacion;
        return pedidoAModificar;
    }

}