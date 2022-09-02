using CrudEFCoreNet6.Data;
using CrudEFCoreNet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _contexto.Usuario.Add(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
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
