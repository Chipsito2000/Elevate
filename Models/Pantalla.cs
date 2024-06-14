using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElevateERP.Models;

[Table("Pantalla")]
public partial class Pantalla
{
    [Key]
    [Required(ErrorMessage = "ID no valido")]
    public int Id { get; set; }

    [Column("nPantalla")]
    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "No hay pantalla ")]
    public string? NPantalla { get; set; }

    [InverseProperty("IdPantallaNavigation")]
    public virtual ICollection<Accion> Accions { get; set; } = new List<Accion>();
}
