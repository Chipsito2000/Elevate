namespace ElevateERP.Controllers
{

    using ElevateERP.Data;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Mvc;


    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Proveedores()
        {
            List<Proveedor> proveedor = _context.Proveedors.ToList();
            return View(proveedor);
        } 

        //Metodo para agregar un cliente
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
