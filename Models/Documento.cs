using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Documento")]
public partial class Documento
{
    [Key]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    public int? IdCliente { get; set; }

    public int? IdProveedor { get; set; }

    [Required(ErrorMessage = "Tipo de documento requerido")]
    public string? TipoDocumento { get; set; }

    public string? FileName { get; set; }

    public string? ContentType { get; set; }

    public byte[]? Data { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Documentos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdProveedor")]
    [InverseProperty("Documentos")]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
