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

/*             var moduloRegistro = _context.Turnos.Where(x => x.Estado == "En proceso" && x.Estado > (double)4);


            if (moduloRegistro.TipoServicio == "Solicitud de citas")
            {
                ViewBag.TurnoText = "SC" + "-" + moduloRegistro.Id;
            }
            else if (moduloRegistro.TipoServicio == "Autorización de medicamentos")
            {
                ViewBag.TurnoText = "AM" + "-" + moduloRegistro.Id;
            }
            else if (moduloRegistro.TipoServicio == "Pago de facturas")
            {
                ViewBag.TurnoText = "PF" + "-" + moduloRegistro.Id;
            }
            else if (moduloRegistro.TipoServicio == "Información en general")
            {
                ViewBag.TurnoText = "IG" + "-" + moduloRegistro.Id;
            } */

            return View();
        }
    }
}