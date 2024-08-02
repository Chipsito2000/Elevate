using Microsoft.AspNetCore.Mvc;

namespace ElevateERP.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult ErrorOperacion(string accion, string pantalla, string msjErrorPermiso)
        {
            ViewBag.Accion = accion;
            ViewBag.Pantalla = pantalla;
            ViewBag.msjErrorPermiso = msjErrorPermiso;
            return View();
        }
    }
}
