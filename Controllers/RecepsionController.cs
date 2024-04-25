using System.Diagnostics;
using Gestion_de_Turnos.Data;
using Microsoft.AspNetCore.Mvc;
using Gestion_de_Turnos.Models;

namespace Gestion_de_Turnos.Controllers
{
  public class RecepsionController : Controller
  {

    public readonly BaseContext _context;

    public RecepsionController(BaseContext context) 
    {
        _context = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Usuario usuario)
    {
      await _context.Usuarios.AddAsync(usuario);
      _context.SaveChanges();
      return RedirectToAction("Index", "Recepsion");
    }

  }

}

