using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Keyless]
public partial class AktualneRezerwacje
{
    [Column("ID_rezerwacji")]
    public int IdRezerwacji { get; set; }

    [Column("pasazer")]
    [StringLength(201)]
    public string Pasazer { get; set; } = null!;

    [Column("stacja_poczatkowa")]
    [StringLength(100)]
    public string StacjaPoczatkowa { get; set; } = null!;

    [Column("stacja_koncowa")]
    [StringLength(100)]
    public string StacjaKoncowa { get; set; } = null!;

    [Column("cena", TypeName = "decimal(10, 2)")]
    public decimal Cena { get; set; }

    [Column("status_rezerwacji")]
    [StringLength(50)]
    public string? StatusRezerwacji { get; set; }

    [Column("data_rezerwacji", TypeName = "datetime")]
    public DateTime DataRezerwacji { get; set; }
}
