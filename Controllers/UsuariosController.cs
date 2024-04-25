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

        public IActionResult UsuarioR(string NI)
        {
            var usuario = _context.Usuarios.Where(x => x.Documento == NI).FirstOrDefault();
            return View();
        }
        
        public IActionResult UsuarioN()
        {
            return View();
        }
    }
}

