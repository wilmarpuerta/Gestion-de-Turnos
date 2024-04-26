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
      var Turno = _context.Turnos.FirstOrDefault(t => t.Estado == "En proceso");
      
      if (Turno.TipoServicio == "Solicitud de citas")
      {
        ViewBag.TurnoText = "SC" + "-" + Turno.Id;
      }
      else if (Turno.TipoServicio == "Autorización de medicamentos")
      {
        ViewBag.TurnoText = "AM" + "-" + Turno.Id;
      }
      else if (Turno.TipoServicio == "Pago de facturas")
      {
        ViewBag.TurnoText = "PF" + "-" + Turno.Id;
      }
      else if (Turno.TipoServicio == "Información en general")
      {
        ViewBag.TurnoText = "IG" + "-" + Turno.Id;
      }
      
      var usuario =
        _context.Usuarios.FirstOrDefault(u => u.Id == Turno.IdUsuario);
      return View(usuario);
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

    public async Task<IActionResult> Edit(int? id)
    {
      return View(await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Usuario usuario)
    {
      _context.Usuarios.Update(usuario);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

  }
}

