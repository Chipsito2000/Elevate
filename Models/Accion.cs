using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Accion")]
public partial class Accion
{
    [Key]
    [Required(ErrorMessage = "No existe ID")]
    public int Id { get; set; }

    [Column("Accion")]
    [StringLength(50)]
    [Unicode(false)]
    [Required (ErrorMessage ="No hay accion")]
    public string? Accion1 { get; set; }

    [Column("idPantalla")]
    public int? IdPantalla { get; set; }

    [ForeignKey("IdPantalla")]
    [InverseProperty("Accions")]
    public virtual Pantalla? IdPantallaNavigation { get; set; }

    [InverseProperty("IdAccionNavigation")]
    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
