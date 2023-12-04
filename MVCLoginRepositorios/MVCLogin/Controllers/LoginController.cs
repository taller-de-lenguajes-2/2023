using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;
using MVCLogin.Repositorio;

namespace MVC.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public LoginController(ILogger<LoginController> logger, IUsuarioRepositorio usuarioRepositorio)
    {
        _logger = logger;
        _usuarioRepositorio = usuarioRepositorio;
    }

    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }


    public IActionResult Login(Usuario usuario)
    {
        try
        {
            //existe el usuario?
            var usuarioLogeado = _usuarioRepositorio.AutenticarUsuario(usuario.Nombre, usuario.Contrasenia);

            // si el usuario no existe devuelvo al index
            if (usuarioLogeado == null)
            { 
                return RedirectToAction("Index"); 
            }
            
            logearUsuario(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar logear un usuario {ex.ToString()}");
            
        }
        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }

    private void logearUsuario(Usuario user)
    {
        HttpContext.Session.SetString("Usuario", user.Nombre);
        HttpContext.Session.SetString("NivelDeAcceso", user.Contrasenia);
        HttpContext.Session.SetString("NivelAcceso", user.NivelDeAcceso.ToString());
    }
}