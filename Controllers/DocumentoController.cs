using ElevateERP.Data;
using ElevateERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Accion para ir a vista con datos de la tabla documento
        public async Task<IActionResult> VerDocumento()
        {
            var documentosConProveedores = _context.Documentos
            .Include(d => d.IdProveedorNavigation)
            .Select(d => new
            {
                ProveedorNombre = d.IdProveedorNavigation.Nombre,
                TipoDocumento = d.TipoDocumento,
                FileName = d.FileName,
                DocumentoId = d.Id
            })
            .ToList();

            return View(documentosConProveedores);
        }

        // Accion para enlistar los proveedores en un select
        public IActionResult SubirDocumento()
        {
            var proveedores = _context.Proveedors.ToList();
            ViewBag.Proveedors = proveedores;
            return View();
        }

        // Acción para manejar la carga de documentos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubirDocumento(IFormFile archivo, int proveedorId, string tipodocumento)
        {
            if (archivo != null && archivo.Length > 0)
            {
                var documento = new Documento
                {
                    IdProveedor = proveedorId,
                    TipoDocumento = tipodocumento,
                    FileName = Path.GetFileName(archivo.FileName),
                    ContentType = archivo.ContentType
                };

                using (var memoryStream = new MemoryStream())
                {
                    await archivo.CopyToAsync(memoryStream);
                    documento.Data = memoryStream.ToArray();
                }

                _context.Documentos.Add(documento);
                await _context.SaveChangesAsync();

                return RedirectToAction("VerDocumento");
            }

            return View();
        }

        // Acción para descargar el documento
        public IActionResult DescargarDocumento(int id)
        {
            var documento = _context.Documentos.Find(id);
            if (documento == null)
            {
                return NotFound();
            }

            return File(documento.Data, documento.ContentType, documento.FileName);
        }
    }

}
