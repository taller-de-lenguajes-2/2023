namespace Web_Api;

public class Pedido
{
    private int _nro;
    private string _observacion;
    public int Nro { get => _nro; set => _nro = value; }
    public string Observacion { get => _observacion; set => _observacion = value; }
}