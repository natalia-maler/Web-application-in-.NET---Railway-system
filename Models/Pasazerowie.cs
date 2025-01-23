using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Pasazerowie")]
[Index("AdresEmail", Name = "UQ__Pasazero__D5EAE40D1CF740DB", IsUnique = true)]
public partial class Pasazerowie
{
    [Key]
    [Column("ID_pasazera")]
    public int IdPasazera { get; set; }

    [StringLength(100)]
    public string Imie { get; set; } = null!;

    [StringLength(100)]
    public string Nazwisko { get; set; } = null!;

    [Column("Adres_email")]
    [StringLength(100)]
    public string AdresEmail { get; set; } = null!;

    [StringLength(50)]
    public string Haslo { get; set; } = null!;

    [InverseProperty("IdPasazeraNavigation")]
    public virtual ICollection<RezerwacjeBiletow> RezerwacjeBiletows { get; set; } = new List<RezerwacjeBiletow>();
}
