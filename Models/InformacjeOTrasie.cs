using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Informacje_o_trasie")]
public partial class InformacjeOTrasie
{
    [Key]
    [Column("ID_trasy")]
    public int IdTrasy { get; set; }

    [Column("ID_stacji_zrodlowej")]
    public int IdStacjiZrodlowej { get; set; }

    [Column("ID_stacji_docelowej")]
    public int IdStacjiDocelowej { get; set; }

    [Column("Odleglosc_km")]
    public int? OdlegloscKm { get; set; }

    [ForeignKey("IdStacjiDocelowej")]
    [InverseProperty("InformacjeOTrasieIdStacjiDocelowejNavigations")]
    public virtual Stacje IdStacjiDocelowejNavigation { get; set; } = null!;

    [ForeignKey("IdStacjiZrodlowej")]
    [InverseProperty("InformacjeOTrasieIdStacjiZrodlowejNavigations")]
    public virtual Stacje IdStacjiZrodlowejNavigation { get; set; } = null!;
}
