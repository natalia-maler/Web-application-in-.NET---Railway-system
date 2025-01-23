using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Pociagi")]
public partial class Pociagi
{
    [Key]
    [Column("ID_pociagu")]
    public int IdPociagu { get; set; }

    [Column("Nazwa_pociagu")]
    [StringLength(50)]
    public string NazwaPociagu { get; set; } = null!;

    [Column("Liczba_wagonow")]
    public int LiczbaWagonow { get; set; }

    [Column("Typ_pociagu")]
    [StringLength(50)]
    public string TypPociagu { get; set; } = null!;

    [InverseProperty("IdPociaguNavigation")]
    public virtual ICollection<Rozklad> Rozklads { get; set; } = new List<Rozklad>();

    [InverseProperty("IdPociaguNavigation")]
    public virtual SzczegolyTechnicznePociagow? SzczegolyTechnicznePociagow { get; set; }
}
