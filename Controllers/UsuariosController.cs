using Gestion_de_Turnos.Data;
using Gestion_de_Turnos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Turnos.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly BaseContext _context;

        public UsuariosController(BaseContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UsuarioR(string NI)
        {
            var usuario = _context.Usuarios.Where(x => x.Documento == NI).FirstOrDefault();
            if (usuario!= null)
            {
                HttpContext.Session.SetString("DocumentoUser", NI);
            }
            return View(usuario);
        }
        
        public IActionResult UsuarioN(string NI)
        {
            HttpContext.Session.SetString("DocumentoUser", NI);
            return View();
        }

        public IActionResult Turno()
        {
            var ultimoRegistro = _context.Turnos
                .OrderByDescending(x => x.FechaHoraTurno)
                .FirstOrDefault();
            
            if (ultimoRegistro.TipoServicio == "Solicitud de citas")
            {
                ViewBag.TurnoText = "SC" + "-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Autorización de medicamentos")
            {
                ViewBag.TurnoText = "AM" + "-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Pago de facturas")
            {
                ViewBag.TurnoText = "PF" + "-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Información en general")
            {
                ViewBag.TurnoText = "IG" + "-" + ultimoRegistro.Id;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SC(Turno t)
        {
            var usuario = _context.Usuarios.Where(x => x.Documento == HttpContext.Session.GetString("DocumentoUser")).FirstOrDefault();
            t.TipoServicio = "Solicitud de citas";
            t.FechaHoraTurno = DateTime.Now;
            t.Estado = "En espera";
            t.IdUsuario = usuario.Id;
            _context.Turnos.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Turno");
        }
        
        [HttpPost]
        public async Task<IActionResult> AM(Turno t)
        {
            var usuario = _context.Usuarios.Where(x => x.Documento == HttpContext.Session.GetString("DocumentoUser")).FirstOrDefault();
            t.TipoServicio = "Autorización de medicamentos";
            t.FechaHoraTurno = DateTime.Now;
            t.Estado = "En espera";
            t.IdUsuario = usuario.Id;
            _context.Turnos.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Turno");
        }
        
        [HttpPost]
        public async Task<IActionResult> PF(Turno t)
        {
            var usuario = _context.Usuarios.Where(x => x.Documento == HttpContext.Session.GetString("DocumentoUser")).FirstOrDefault();
            t.TipoServicio = "Pago de facturas";
            t.FechaHoraTurno = DateTime.Now;
            t.Estado = "En espera";
            t.IdUsuario = usuario.Id;
            _context.Turnos.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Turno");
        }
        [HttpPost]
        public async Task<IActionResult> IG(string tipoServicio, Turno t)
        {
            var usuario = _context.Usuarios.Where(x => x.Documento == HttpContext.Session.GetString("DocumentoUser")).FirstOrDefault();
            t.TipoServicio = "Información en general";
            t.FechaHoraTurno = DateTime.Now;
            t.Estado = "En espera";
            t.IdUsuario = usuario.Id;
            _context.Turnos.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Turno");
        }
    }
}

