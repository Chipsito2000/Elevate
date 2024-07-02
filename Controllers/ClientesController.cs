namespace ElevateERP.Controllers
{
    using ElevateERP.Data;
    using ElevateERP.Filtro;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel;
    using System.Diagnostics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore.Design;

    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Clientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            return View(clientes);
        }


        public IActionResult Agregar()
        {
            Cliente cliente = new Cliente();
            return PartialView("_ClientesAddPartialView", cliente);
        }
       
        [HttpPost]
        public IActionResult Agregar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Clientes");
            }
            return PartialView("_ClientesAddPartialView", cliente);
        }


        // Método para mostrar la vista de actualización
        public IActionResult Editar(int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return PartialView("_ClientesEditPartialView", cliente);
        }

        // Método para manejar la solicitud POST de actualización
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Clientes");
            }
            return PartialView("_ClientesEditPartialView", cliente);
        }

        //// Método para mostrar la vista de eliminación
        //public async Task<IActionResult> Eliminar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_ClientesDeletePartialView", cliente);
        //}

        //// Método para manejar la solicitud POST de eliminación
        //[HttpPost, ActionName("Eliminar")]
        //public async Task<IActionResult> ConfirmarEliminacion(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cliente = await _context.Clientes.FindAsync(id);

        //    if (cliente != null)
        //    {
        //        _context.Clientes.Remove(cliente);
        //        await _context.SaveChangesAsync();

        //    }
        //    return RedirectToAction("Clientes");
        //}
    }


}
