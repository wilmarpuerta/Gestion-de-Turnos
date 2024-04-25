using System.Diagnostics;
using Gestion_de_Turnos.Data;
using Microsoft.AspNetCore.Mvc;
using Gestion_de_Turnos.Models;
using Microsoft.EntityFrameworkCore;

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
        return Json("Todo nice");
        await _context.Usuarios.AddAsync(usuario);
        _context.SaveChanges();
        return RedirectToAction("Index", "Usuarios");

    }

    public async Task<IActionResult> Edit(int? id)
    {
      return View(await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id));
    }

    [HttpPost]
    public IActionResult Edit(int id, Usuario usuario)
    {
      _context.Usuarios.Update(usuario);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

  }

}

