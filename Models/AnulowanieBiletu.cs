using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Anulowanie_biletu")]
public partial class AnulowanieBiletu
{
    [Key]
    [Column("ID_anulowania")]
    public int IdAnulowania { get; set; }

    [Column("ID_rezerwacji")]
    public int IdRezerwacji { get; set; }

    [Column("Powód_anulowania")]
    [StringLength(255)]
    public string? PowódAnulowania { get; set; }

    [Column("Data_anulowania", TypeName = "datetime")]
    public DateTime DataAnulowania { get; set; }

    [Column("Zwrot_kwoty", TypeName = "decimal(10, 2)")]
    public decimal ZwrotKwoty { get; set; }

    [Column("Status_zwrotu")]
    [StringLength(50)]
    public string? StatusZwrotu { get; set; }

    [ForeignKey("IdRezerwacji")]
    [InverseProperty("AnulowanieBiletus")]
    public virtual RezerwacjeBiletow IdRezerwacjiNavigation { get; set; } = null!;
}
