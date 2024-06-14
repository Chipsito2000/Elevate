using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Rol")]
public partial class Rol
{
    [Key]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    [Column("Rol")]
    [StringLength(50)]
    [Unicode(false)]
    public string Rol1 { get; set; } = null!;

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
