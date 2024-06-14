using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Proveedor")]
public partial class Proveedor
{
    [Key]
    [Column("id")]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("nEmpresa")]
    [StringLength(25)]
    [Unicode(false)]
    public string? NEmpresa { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("formaCompra")]
    [StringLength(15)]
    [Unicode(false)]
    public string? FormaCompra { get; set; }

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
