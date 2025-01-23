using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Szczegoly_techniczne_pociagow")]
public partial class SzczegolyTechnicznePociagow
{
    [Key]
    [Column("ID_pociagu")]
    public int IdPociagu { get; set; }

    [StringLength(100)]
    public string Producent { get; set; } = null!;

    [Column("Moc_silnika")]
    public int MocSilnika { get; set; }

    [Column("Typ_silnika")]
    [StringLength(50)]
    public string TypSilnika { get; set; } = null!;

    [Column("Rok_produkcji")]
    public int RokProdukcji { get; set; }

    [ForeignKey("IdPociagu")]
    [InverseProperty("SzczegolyTechnicznePociagow")]
    public virtual Pociagi IdPociaguNavigation { get; set; } = null!;
}
