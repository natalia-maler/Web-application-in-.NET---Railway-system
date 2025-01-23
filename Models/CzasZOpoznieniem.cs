using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Keyless]
public partial class CzasZOpoznieniem
{
    [Column("ID_rozkladu")]
    public int IdRozkladu { get; set; }

    [Column("Czas_trwania")]
    public TimeOnly? CzasTrwania { get; set; }

    [Column("Czas_opoznienia")]
    public TimeOnly CzasOpoznienia { get; set; }

    [Column("Czas_calkowity")]
    public TimeOnly? CzasCalkowity { get; set; }
}
