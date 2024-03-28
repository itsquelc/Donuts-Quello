using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using DonutsQuello.Models;

namespace DonutsQuello.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

   
    public IActionResult Index()
    {
       List<Donuts> donuts = [];
       using (StreamReader leitor = new("Data\\donuts.json"))
       {
        string dados = leitor.ReadToEnd();
        donuts = JsonSerializer.Deserialize<List<Donuts>>(dados);
       } 
    return View(donuts);
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
