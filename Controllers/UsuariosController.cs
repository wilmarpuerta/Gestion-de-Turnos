using Gestion_de_Turnos.Data;
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
        public async Task <IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }
    }
}

