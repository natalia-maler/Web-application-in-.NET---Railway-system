using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Keyless]
public partial class SumaCenBiletow
{
    [Column("status_rezerwacji")]
    [StringLength(50)]
    public string? StatusRezerwacji { get; set; }

    [Column("Suma_cen", TypeName = "decimal(38, 2)")]
    public decimal? SumaCen { get; set; }
}
