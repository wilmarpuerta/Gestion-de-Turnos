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
        public async Task <IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
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
    }
}

