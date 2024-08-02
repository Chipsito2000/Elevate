namespace ElevateERP.Controllers
{

    using ElevateERP.Data;
    using ElevateERP.Filtro;
    using ElevateERP.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Protocols;


    public class DocumentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        #region Constructor 
        public DocumentoController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Descargar Documentos
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
        #endregion

        #region Documentos de Proveedores

        // Accion para ir a vista con datos de la tabla documento
        [VerificacionSession]
        [Validar_Permiso(11)]
        public async Task<IActionResult> DocumentoProv()
        {
            var documentosConProveedores = _context.Documentos
            .Include(d => d.IdProveedorNavigation)
                   .Where(d => d.IdProveedor != null)

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
        [VerificacionSession]
        [Validar_Permiso(10)]
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

                return RedirectToAction("DocumentoProv");
            }

            return View();
        }
        #endregion

        #region Documentos de Clientes

        // Acción para ir a vista con datos de la tabla documento
        [VerificacionSession]
        [Validar_Permiso(6)]
        public async Task<IActionResult> DocumentoCliente()
        {
            var documentosConClientes = _context.Documentos
       .Include(d => d.IdClienteNavigation)
       .Where(d => d.IdCliente != null)
       .Select(d => new
       {
           ClienteNombre = d.IdClienteNavigation.Nombre,
           TipoDocumento = d.TipoDocumento,
           FileName = d.FileName,
           DocumentoId = d.Id
       })
       .ToList();

            return View(documentosConClientes);
        }

        // Acción para enlistar los clientes en un select
        public IActionResult SubirDocumentoClie()
        {
            var clientes = _context.Clientes.ToList();
            ViewBag.Clientes = clientes;
            return View();
        }

        // Acción para manejar la carga de documentos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubirDocumentoClie(IFormFile archivo, int clienteId, string tipodocumento)
        {
            if (archivo != null && archivo.Length > 0)
            {
                var documento = new Documento
                {
                    IdCliente = clienteId,
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

                return RedirectToAction("DocumentoCliente");
            }

            return View();
        }
        #endregion


    }

}
