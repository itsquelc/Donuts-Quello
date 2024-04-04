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
       List<Donuts> donuts = GetDonuts();
       List<Tipo> tipos = GetTipos();
       ViewData["Tipos"] = tipos;
       return View(donuts);
    }
    public IActionResult Details(int id)
    {
        List<Donuts> donuts = GetDonuts();
        List<Tipo> tipos = GetTipos();
        DetailsVM details = new() {
            Tipos = tipos,
            Atual = donuts.FirstOrDefault(p => p.Numero == id),
            Anterior = donuts.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = donuts.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id)
        };
        return View(details);
    }

    private List<Donuts> GetDonuts()
    {
        using (StreamReader leitor = new("Data\\donuts.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Donuts>>(dados);
        }
    }
    
    private List<Tipo> GetTipos()
    {
        using (StreamReader leitor = new("Data\\tipo.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
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
