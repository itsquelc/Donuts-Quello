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
       List<Tipo> tipos = [];
       using (StreamReader leitor = new("Data\\tipo.json"))
       {
        string dados = leitor.ReadToEnd();
        tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
       }
       ViewData["Tipos"] = tipos;
    return View(donuts);
    }
    public IActionResult Details(int id)
    {
        List<Donuts> donuts = [];
        using (StreamReader leitor = new("Data\\donuts.json"))
        {
            string dados = leitor.ReadToEnd();
            donuts = JsonSerializer.Deserialize<List<Donuts>>(dados);
        }
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\donuts.json"))
        {
            string dados = leitor.ReadToEnd();
            donuts = JsonSerializer.Deserialize<List<Donuts>>(dados);
        }
        DetailsVM details = new()
        {
            Tipos = tipos,
            Atual = donuts.FirstOrDefault(p => p.Numero == id),
            Anterior = donuts.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = donuts.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id)
        };
        return View(details);
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
