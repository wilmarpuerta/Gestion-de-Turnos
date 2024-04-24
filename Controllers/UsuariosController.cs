using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gestion_de_Turnos.Models;

namespace Gestion_de_Turnos.Controllers;

public class UsuariosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
