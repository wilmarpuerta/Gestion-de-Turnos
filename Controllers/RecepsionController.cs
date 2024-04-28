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

      if (Turno == null)
      {
        var turnoEspera = _context.Turnos.FirstOrDefault(t => t.Estado == "En espera");

        if (turnoEspera == null)
        {
          var user = _context.Usuarios.First(u => u.Id == 7);
          ViewBag.TurnoId = user.Id;
          return View(user);
        }
        
        turnoEspera.Estado = "En proceso";

        _context.Turnos.Update(turnoEspera);
        _context.SaveChanges();
        return View("Index");
      }

      ViewBag.TurnoId = Turno.Id;

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
      else if (Turno.TipoServicio == "Atencion Prioritaria")
      {
        ViewBag.TurnoText = "AP" + "-" + Turno.Id;
      }
      else if (Turno.TipoServicio == "No hay mas turnos")
      {
        ViewBag.TurnoText = "No hay mas turnos";
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

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Usuario usuario)
    {
      _context.Usuarios.Update(usuario);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    public IActionResult SiguienteTurno(int id)
    {
      var turnoActual = _context.Turnos.FirstOrDefault(t => t.Id == id);

      if (turnoActual == null)
      {
        ViewBag.TurnoText = "No hay mas turnos";
        
        return RedirectToAction("Index");

      }

      turnoActual.Estado = "Finalizado";

      _context.Turnos.Update(turnoActual);
      _context.SaveChanges();

      var turnoSiguiente = _context.Turnos.FirstOrDefault(t => t.Estado == "En espera");

      if (turnoSiguiente == null)
      {
        return View("Index");
      }
      turnoSiguiente.Estado = "En proceso";

      _context.Turnos.Update(turnoSiguiente);
      _context.SaveChanges();

      return RedirectToAction("Index");

    }

    public IActionResult Ausente(int id)
    {
      var turnoActual = _context.Turnos.FirstOrDefault(t => t.Id == id);

      turnoActual.Estado = "Ausente";

      _context.Turnos.Update(turnoActual);
      _context.SaveChanges();

      var turnoSiguiente = _context.Turnos.FirstOrDefault(t => t.Estado == "En espera");
      turnoSiguiente.Estado = "En proceso";

      _context.Turnos.Update(turnoSiguiente);
      _context.SaveChanges();

      return RedirectToAction("Index");

    }

  }
}

