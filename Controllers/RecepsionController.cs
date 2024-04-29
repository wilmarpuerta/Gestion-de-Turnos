using Gestion_de_Turnos.Data;
using Microsoft.AspNetCore.Mvc;
using Gestion_de_Turnos.Models;

namespace Gestion_de_Turnos.Controllers
{
  public class RecepsionController : Controller
  {
    private readonly BaseContext _context;

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
          ViewBag.TurnoText = "No hay turnos";
          ViewBag.Nombre = "No hay turnos";
          ViewBag.Apellido = "";
          ViewBag.Documento = "";
          ViewBag.FechaNacimiento = "";
          ViewBag.CorreoElectronico = "";
          ViewBag.TipoAfiliacion = "";
          ViewBag.Direccion = "";
          ViewBag.Telefono = "";
          ViewBag.IdUsuario = "";
          
          return View();
        }
        
        turnoEspera.Estado = "En proceso";
        _context.Turnos.Update(turnoEspera);
        _context.SaveChanges();
        return RedirectToAction("Index");
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

      ViewBag.TipoServicio = Turno.TipoServicio;
      
      var usuario =
        _context.Usuarios.FirstOrDefault(u => u.Id == Turno.IdUsuario);
      
      if (usuario == null)
      {
        return RedirectToAction("Index");
      }
      
      ViewBag.Nombre = usuario.Nombre;
      ViewBag.Apellido = usuario.Apellido;
      ViewBag.Documento = usuario.Documento;
      ViewBag.FechaNacimiento = usuario.FechaNacimiento;
      ViewBag.CorreoElectronico = usuario.CorreoElectronico;
      ViewBag.TipoAfiliacion = usuario.TipoAfiliacion;
      ViewBag.Direccion = usuario.Direccion;
      ViewBag.Telefono = usuario.Telefono;
      ViewBag.IdUsuario = usuario.Id;
      
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
      await _context.SaveChangesAsync();
      return RedirectToAction("Index", "Recepsion");
    }

    public IActionResult Edit(int id)
    {
      var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
      if (usuario == null)
      {
        return RedirectToAction("Index");
      }
      return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Usuario usuario)
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
        return RedirectToAction("Index");
      }

      turnoActual.Estado = "Finalizado";
      _context.Turnos.Update(turnoActual);
      _context.SaveChanges();

      var turnoSiguiente = _context.Turnos.FirstOrDefault(t => t.Estado == "En espera");

      if (turnoSiguiente == null)
      {
        return RedirectToAction("Index");
      }

      turnoSiguiente.Estado = "En proceso";
      _context.Turnos.Update(turnoSiguiente);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    public IActionResult Ausente(int id)
    {
      var turnoActual = _context.Turnos.FirstOrDefault(t => t.Id == id);

      if (turnoActual == null)
      {
        return RedirectToAction("Index");
      }

      turnoActual.Estado = "Ausente";
      _context.Turnos.Update(turnoActual);
      _context.SaveChanges();

      var turnoSiguiente = _context.Turnos.FirstOrDefault(t => t.Estado == "En espera");
      
      if (turnoSiguiente == null)
      {
        return RedirectToAction("Index");
      }
      
      turnoSiguiente.Estado = "En proceso";
      _context.Turnos.Update(turnoSiguiente);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}

