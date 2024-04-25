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
    }
}

