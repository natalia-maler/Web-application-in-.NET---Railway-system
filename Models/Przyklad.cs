using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Keyless]
[Table("przyklad")]
public partial class Przyklad
{
    [Column("id_przyklad")]
    public int? IdPrzyklad { get; set; }
}
