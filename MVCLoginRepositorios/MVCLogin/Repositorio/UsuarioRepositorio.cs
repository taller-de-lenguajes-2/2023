using MVC.Models;

namespace MVCLogin.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        public UsuarioRepositorio()
        {
            // Agregar algunos usuarios de ejemplo a la lista estática
            var usuarioAdmin = new Usuario()
            {
                Nombre = "admin",
                Contrasenia = "admin",
                NivelDeAcceso = NivelDeAcceso.admin
            };

            var usuarioSimple = new Usuario()
            {
                Nombre = "simple",
                Contrasenia = "simple",
                NivelDeAcceso = NivelDeAcceso.simple
            };
            _usuarios.Add(usuarioAdmin);
            _usuarios.Add(usuarioSimple);
        }

        public bool AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario && u.Contrasenia == contraseña);
            return usuario != null;
        }

        public Usuario obtenerUsuario(string nombreUsuario, string contraseña)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario && u.Contrasenia == contraseña);
            if (usuario != null) { throw  new InvalidOperationException("Usuario no encontrado"); }
            return usuario!;
        }
    }

}
