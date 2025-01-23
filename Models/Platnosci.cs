using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Platnosci")]
public partial class Platnosci
{
    [Key]
    [Column("ID_platnosci")]
    public int IdPlatnosci { get; set; }

    [Column("ID_rezerwacji")]
    public int IdRezerwacji { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Kwota { get; set; }

    [Column("Metoda_platnosci")]
    [StringLength(50)]
    public string MetodaPlatnosci { get; set; } = null!;

    [Column("Data_platnosci", TypeName = "datetime")]
    public DateTime DataPlatnosci { get; set; }

    [ForeignKey("IdRezerwacji")]
    [InverseProperty("Platnoscis")]
    public virtual RezerwacjeBiletow IdRezerwacjiNavigation { get; set; } = null!;
}
