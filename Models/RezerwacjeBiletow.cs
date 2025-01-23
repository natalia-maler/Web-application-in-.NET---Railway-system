using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Rezerwacje_biletow")]
public partial class RezerwacjeBiletow
{
    [Key]
    [Column("ID_rezerwacji")]
    public int IdRezerwacji { get; set; }

    [Column("ID_pasazera")]
    public int IdPasazera { get; set; }

    [Column("ID_rozkladu")]
    public int IdRozkladu { get; set; }

    [Column("Typ_biletu")]
    [StringLength(50)]
    public string TypBiletu { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Cena { get; set; }

    [Column("Data_rezerwacji", TypeName = "datetime")]
    public DateTime DataRezerwacji { get; set; }

    [Column("Czas_wyjazdu", TypeName = "datetime")]
    public DateTime CzasWyjazdu { get; set; }

    [Column("Czas_przyjazdu", TypeName = "datetime")]
    public DateTime CzasPrzyjazdu { get; set; }

    [Column("Czas_trwania")]
    public TimeOnly? CzasTrwania { get; set; }

    [Column("Stacja_poczatkowa")]
    [StringLength(100)]
    public string StacjaPoczatkowa { get; set; } = null!;

    [Column("Stacja_koncowa")]
    [StringLength(100)]
    public string StacjaKoncowa { get; set; } = null!;

    [Column("Numer_wagonu")]
    public int? NumerWagonu { get; set; }

    [Column("Numer_miejsca")]
    public int? NumerMiejsca { get; set; }

    [Column("Znizka_procentowa")]
    public int? ZnizkaProcentowa { get; set; }

    [Column("Typ_znizki")]
    [StringLength(255)]
    public string? TypZnizki { get; set; }

    [Column("Status_rezerwacji")]
    [StringLength(50)]
    public string? StatusRezerwacji { get; set; }

    [InverseProperty("IdRezerwacjiNavigation")]
    public virtual ICollection<AnulowanieBiletu> AnulowanieBiletus { get; set; } = new List<AnulowanieBiletu>();

    [ForeignKey("IdPasazera")]
    [InverseProperty("RezerwacjeBiletows")]
    public virtual Pasazerowie IdPasazeraNavigation { get; set; } = null!;

    [ForeignKey("IdRozkladu")]
    [InverseProperty("RezerwacjeBiletows")]
    public virtual Rozklad IdRozkladuNavigation { get; set; } = null!;

    [InverseProperty("IdRezerwacjiNavigation")]
    public virtual ICollection<Platnosci> Platnoscis { get; set; } = new List<Platnosci>();
}
