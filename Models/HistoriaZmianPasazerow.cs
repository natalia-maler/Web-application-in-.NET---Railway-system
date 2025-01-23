using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Historia_zmian_pasazerow")]
public partial class HistoriaZmianPasazerow
{
    [Key]
    [Column("ID_zmiany")]
    public int IdZmiany { get; set; }

    [Column("ID_pasazera")]
    public int IdPasazera { get; set; }

    [Column("Stare_imie")]
    [StringLength(100)]
    public string? StareImie { get; set; }

    [Column("Nowe_imie")]
    [StringLength(100)]
    public string? NoweImie { get; set; }

    [Column("Stare_nazwisko")]
    [StringLength(100)]
    public string? StareNazwisko { get; set; }

    [Column("Nowe_nazwisko")]
    [StringLength(100)]
    public string? NoweNazwisko { get; set; }

    [Column("Stary_email")]
    [StringLength(100)]
    public string? StaryEmail { get; set; }

    [Column("Nowy_email")]
    [StringLength(100)]
    public string? NowyEmail { get; set; }

    [Column("Data_zmiany", TypeName = "datetime")]
    public DateTime DataZmiany { get; set; }
}
