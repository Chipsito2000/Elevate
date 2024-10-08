﻿namespace ElevateERP.Controllers
{

    using ElevateERP.Data;
    using ElevateERP.Filtro;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Mvc;


    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [VerificacionSession]
        [Validar_Permiso(7)]
        public ActionResult Proveedores()
        {
            List<Proveedor> proveedor = _context.Proveedors.ToList();
            return View(proveedor);
        }

        //Metodo para agregar un cliente
        [VerificacionSession]
        [Validar_Permiso(8)]
        public IActionResult Agregar()
        {
            Proveedor proveedor = new Proveedor();
            return PartialView("_ProveedorAddPartialView", proveedor);
        }

        [HttpPost]
        public IActionResult Agregar(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Proveedors.Add(proveedor);
                _context.SaveChanges();
                return RedirectToAction("Proveedores");
            }
            return PartialView("_ClientesAddPartialView", proveedor);
        }


        // Método para mostrar la vista de actualización
        [VerificacionSession]
        [Validar_Permiso(9)]
        public IActionResult Editar(int id)
        {
            Proveedor proveedor = _context.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return PartialView("_ProveedorEditPartialView", proveedor);
        }

        // Método para manejar la solicitud POST de actualización
        [HttpPost]
        public IActionResult Editar(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Proveedors.Update(proveedor);
                _context.SaveChanges();
                return RedirectToAction("Proveedores");
            }
            return PartialView("_ProveedorEditPartialView", proveedor);
        }
    }
}
