using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Keyless]
public partial class AnulowaneRezerwacje
{
    [Column("ID_anulowania")]
    public int IdAnulowania { get; set; }

    [StringLength(201)]
    public string Pasazer { get; set; } = null!;

    [Column("typ_biletu")]
    [StringLength(50)]
    public string TypBiletu { get; set; } = null!;

    [Column("stacja_poczatkowa")]
    [StringLength(100)]
    public string StacjaPoczatkowa { get; set; } = null!;

    [Column("stacja_koncowa")]
    [StringLength(100)]
    public string StacjaKoncowa { get; set; } = null!;

    [Column("Data_anulowania", TypeName = "datetime")]
    public DateTime DataAnulowania { get; set; }

    [Column("Powód_anulowania")]
    [StringLength(255)]
    public string? PowódAnulowania { get; set; }

    [Column("Zwrot_kwoty", TypeName = "decimal(10, 2)")]
    public decimal ZwrotKwoty { get; set; }

    [Column("Status_zwrotu")]
    [StringLength(50)]
    public string? StatusZwrotu { get; set; }
}
