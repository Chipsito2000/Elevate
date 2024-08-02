namespace ElevateERP.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using ElevateERP.Data;
    using ElevateERP.Models;
    using ElevateERP.Filtro;
    using ElevateERP.Models;

    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [VerificacionSession] 
        [Validar_Permiso(12)]  
        public ActionResult Usuario()
        {
            List<Usuario> usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        // Acción GET para mostrar el formulario de agregar nuevo usuario
        [VerificacionSession]
        [Validar_Permiso(13)]
        public IActionResult Agregar()
        {
           
            Usuario usuarios = new Usuario();
            return PartialView("_UsuarioAddPartialView", usuarios);
        }

        // Acción POST para manejar el envío del formulario
        [HttpPost]
        public IActionResult Agregar(Usuario usuarios)
        {
            if (!ModelState.IsValid)
            {
                _context.Usuarios.Add(usuarios);
                _context.SaveChanges();
                return RedirectToAction("Usuario");
            }          

            return PartialView("_UsuarioAddPartialView", usuarios);
        }

        // Método para mostrar la vista de actualización
        [VerificacionSession]
        [Validar_Permiso(14)]
        public IActionResult Editar(int id)
        {
            Usuario usuarios = _context.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return PartialView("_UsuarioEditPartialView", usuarios);
        }

        // Método para manejar la solicitud POST de actualización
        [HttpPost]
        public IActionResult Editar(Usuario usuarios)
        {
            if (!ModelState.IsValid)
            {
                _context.Usuarios.Update(usuarios);
                _context.SaveChanges();
                return RedirectToAction("Usuario");
            }
            return PartialView("_UsuarioEditPartialView", usuarios);
        }
    }
}
