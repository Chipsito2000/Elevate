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

    public int IdCliente { get; set; }

    public int IdProveedor { get; set; }

    [Unicode(false)]
    public string? Contrato { get; set; }

    [Unicode(false)]
    public string? Cotizacion { get; set; }

    [Unicode(false)]
    public string? Factura { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Documentos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdProveedor")]
    [InverseProperty("Documentos")]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
