using Microsoft.AspNetCore.Mvc;
using Gestion_de_Turnos.Data;
using Gestion_de_Turnos.Models;

namespace Gestion_de_Turnos {
    public class TelevisorController : Controller
    {

        public readonly BaseContext _context;

        public TelevisorController(BaseContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ultimoRegistro = _context.Turnos.FirstOrDefault(x => x.Estado == "En proceso");
            if (ultimoRegistro == null)
            {
                ViewBag.TurnoText = "No hay turnos en proceso";
            }
            else if (ultimoRegistro.TipoServicio == "Solicitud de citas")
            {
                ViewBag.TurnoText = "SC-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Autorización de medicamentos")
            {
                ViewBag.TurnoText = "AM-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Pago de facturas")
            {
                ViewBag.TurnoText = "PF-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Información en general")
            {
                ViewBag.TurnoText = "IG-" + ultimoRegistro.Id;
            }
            else if (ultimoRegistro.TipoServicio == "Atencion Prioritaria")
            {
                ViewBag.TurnoText = "AP-" + ultimoRegistro.Id;
            }
            return View(_context.Turnos.ToList());
        }
    }
}