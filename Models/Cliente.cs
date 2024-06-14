using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    [Required(ErrorMessage = "No existe Nombre")]
    public string? Nombre { get; set; }

    [Column("nEmpresa")]
    [StringLength(25)]
    [Unicode(false)]
    [Required(ErrorMessage = "No hay empresa")]
    public string? NEmpresa { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [Column("formaPago")]
    [StringLength(15)]
    [Unicode(false)]
    public string? FormaPago { get; set; }

    [Column("CFDI")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Cfdi { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
