using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers;

public class LoginController : Controller
{
    List<Usuario> Usuarios = new List<Usuario>();

    private readonly ILogger<LoginController> _logger;
    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;

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
        Usuarios.Add(usuarioAdmin);
        Usuarios.Add(usuarioSimple);
    }

    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }


    public IActionResult Login(Usuario usuario)
    {
        //existe el usuario?
        var usuarioLogeado = Usuarios.FirstOrDefault(u => u.Nombre == usuario.Nombre && u.Contrasenia == usuario.Contrasenia);

        // si el usuario no existe devuelvo al index
        if (usuarioLogeado == null) return RedirectToAction("Index");
        
        //Registro el usuario
        logearUsuario(usuarioLogeado);
        
        //Devuelvo el usuario al Home
        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }

    private void logearUsuario(Usuario user)
    {
        HttpContext.Session.SetString("Usuario", user.Nombre);
        HttpContext.Session.SetString("NivelDeAcceso", user.Contrasenia);
        HttpContext.Session.SetString("NivelAcceso", user.NivelDeAcceso.ToString());
    }
}