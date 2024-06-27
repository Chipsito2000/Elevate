namespace ElevateERP.Controllers
{

    using ElevateERP.Filtro;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;


    public class ClienteController : Controller
    {

        [Validar_Permiso(idAccion: 14)]
        public ActionResult pCliente()
        {
            return View();
        }

    }
}
