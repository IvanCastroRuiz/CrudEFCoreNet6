using CrudEFCoreNet6.Data; // Trasemos el na
using CrudEFCoreNet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudEFCoreNet6.Controllers;

public class HomeController : Controller
{
  
    private readonly AppDBContext _contexto; // 1

    public HomeController(AppDBContext contexto) // 2
    {
       _contexto = contexto;
    }

    [HttpGet]
    public async Task<IActionResult> Index() // 3
    {
        return View(await _contexto.Usuario.ToListAsync());
    }

    // Crear
    [HttpGet]
    public IActionResult Crear() // 4
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Usuario usuario) //
    {
        if (ModelState.IsValid)
        {
            _contexto.Usuario.Add(usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    // Editar
    [HttpGet]
    public IActionResult Editar(int? id) 
    {
        if(id == null)
        {
            return NotFound();
        }

        var usuario = _contexto.Usuario.Find(id);

        if(usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Usuario usuario) //
    {
        if (ModelState.IsValid)
        {
            _contexto.Usuario.Update(usuario);
            
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    // Detalle
    [HttpGet]
    public IActionResult Detalle(int? id) 
    {
        if(id == null)
        {
            return NotFound();
        }

        var usuario = _contexto.Usuario.Find(id);

        if(usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // Borrar
    [HttpGet]
    public IActionResult Borrar(int? id) 
    {
        if(id == null)
        {
            return NotFound();
        }

        var usuario = _contexto.Usuario.Find(id);

        if(usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    [HttpPost, ActionName("Borrar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BorrarUsuario(int? id)
    {
        var usuario = await _contexto.Usuario.FindAsync(id);
        if (usuario == null)
        {
            return View();
        }

        _contexto.Usuario.Remove(usuario);
        await _contexto.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
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
