using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Rozklad")]
public partial class Rozklad
{
    [Key]
    [Column("ID_rozkladu")]
    public int IdRozkladu { get; set; }

    [Column("ID_pociagu")]
    public int IdPociagu { get; set; }

    [Column("Czas_odjazdu", TypeName = "datetime")]
    public DateTime CzasOdjazdu { get; set; }

    [Column("Czas_przyjazdu", TypeName = "datetime")]
    public DateTime CzasPrzyjazdu { get; set; }

    [Column("Stacja_zrodlowa")]
    [StringLength(100)]
    public string StacjaZrodlowa { get; set; } = null!;

    [Column("Stacja_docelowa")]
    [StringLength(100)]
    public string StacjaDocelowa { get; set; } = null!;

    [StringLength(50)]
    public string? Trasa { get; set; }

    [Column("Numer_peronu")]
    public int NumerPeronu { get; set; }

    [Column("Czas_trwania")]
    public TimeOnly? CzasTrwania { get; set; }

    [ForeignKey("IdPociagu")]
    [InverseProperty("Rozklads")]
    public virtual Pociagi IdPociaguNavigation { get; set; } = null!;

    [InverseProperty("IdRozkladuNavigation")]
    public virtual ICollection<Opoznienium> Opoznienia { get; set; } = new List<Opoznienium>();

    [InverseProperty("IdRozkladuNavigation")]
    public virtual ICollection<RezerwacjeBiletow> RezerwacjeBiletows { get; set; } = new List<RezerwacjeBiletow>();
}
