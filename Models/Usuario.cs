using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("Usuario")]
    [StringLength(50)]
    [Unicode(false)]
    public string Usuario1 { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Clave { get; set; } = null!;
   
    [Required(ErrorMessage = "ID no valido")]
    public int IdRol { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios")]
    public virtual Rol IdRolNavigation { get; set; } = null!;
}
