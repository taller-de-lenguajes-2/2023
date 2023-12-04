using MVC.Models;

namespace MVCLogin.Repositorio
{
    public interface IUsuarioRepositorio
    {
        bool AutenticarUsuario(string nombreUsuario, string contraseña);
        Usuario obtenerUsuario(string nombreUsuario, string contraseña);
    }
}