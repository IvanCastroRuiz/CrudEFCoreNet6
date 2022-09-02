using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudEFCoreNet6.Models;
using CrudEFCoreNet6.Data;

namespace CrudEFCoreNet6.Controllers;

public class HomeController : Controller
{
  
    private readonly AppDBContext _contexto;

    public HomeController(AppDBContext contexto)
    {
       _contexto = contexto;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _contexto.Usuario.ToListAsync());
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
