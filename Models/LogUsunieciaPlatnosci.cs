using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Log_usuniecia_platnosci")]
public partial class LogUsunieciaPlatnosci
{
    [Key]
    [Column("ID_log")]
    public int IdLog { get; set; }

    [StringLength(255)]
    public string? Opis { get; set; }

    [StringLength(500)]
    public string? Szczegoly { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Data { get; set; }
}
