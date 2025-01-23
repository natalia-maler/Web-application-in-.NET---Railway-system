using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

public partial class Opoznienium
{
    [Key]
    [Column("ID_opoznienia")]
    public int IdOpoznienia { get; set; }

    [Column("ID_rozkladu")]
    public int IdRozkladu { get; set; }

    [Column("Czas_opoznienia")]
    public TimeOnly CzasOpoznienia { get; set; }

    [StringLength(255)]
    public string Powod { get; set; } = null!;

    [ForeignKey("IdRozkladu")]
    [InverseProperty("Opoznienia")]
    public virtual Rozklad IdRozkladuNavigation { get; set; } = null!;
}
