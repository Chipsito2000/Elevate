namespace ElevateERP.Controllers
{
    using ElevateERP.Data;
    using ElevateERP.Filtro;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;


    /// <summary>
    /// Controlador principal home
    /// </summary>
    public class HomeController : Controller
    {
    

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }

        [VerificacionSession]
        [Validar_Permiso(1)]
        public ActionResult Index()
        {
            //salida de informacion para datos  de dashboard
            var numClientes = _context.Clientes.Count();
            var numProveedores = _context.Proveedors.Count();
            ViewBag.NumClientes = numClientes;
            ViewBag.NumProveedores = numProveedores;
            return View();
        }

       
        public ActionResult Ajustes()
        {
            return View();
        }

        [VerificacionSession]
        [Validar_Permiso(15)]
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }      


    }
}
