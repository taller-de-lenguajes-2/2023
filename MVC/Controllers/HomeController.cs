using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;

namespace PruebaMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger,Repo repo)
    {
        var _repo = repo; 
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogCritical("hola mundo");
        return BadRequest();
    }

    public IActionResult Privacy()
    {
        return View();
    }
  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
