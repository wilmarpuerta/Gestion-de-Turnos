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
        return View();
        }
    
    }
}