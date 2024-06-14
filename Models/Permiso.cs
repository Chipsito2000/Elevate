using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

public partial class Permiso
{
    [Key]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    [Column("idRol")]
    [Required(ErrorMessage = "ID no valido")]
    public int? IdRol { get; set; }

    [Column("idAccion")]
    [Required(ErrorMessage = "ID no valido")]
    public int? IdAccion { get; set; }

    [ForeignKey("IdAccion")]
    [InverseProperty("Permisos")]
    public virtual Accion? IdAccionNavigation { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("Permisos")]
    public virtual Rol? IdRolNavigation { get; set; }
}
