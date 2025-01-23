using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemKolejowy.Models;

[Table("Stacje")]
public partial class Stacje
{
    [Key]
    [Column("ID_stacji")]
    public int IdStacji { get; set; }

    [Column("Nazwa_stacji")]
    [StringLength(100)]
    public string NazwaStacji { get; set; } = null!;

    [StringLength(100)]
    public string? Miasto { get; set; }

    [InverseProperty("IdStacjiDocelowejNavigation")]
    public virtual ICollection<InformacjeOTrasie> InformacjeOTrasieIdStacjiDocelowejNavigations { get; set; } = new List<InformacjeOTrasie>();

    [InverseProperty("IdStacjiZrodlowejNavigation")]
    public virtual ICollection<InformacjeOTrasie> InformacjeOTrasieIdStacjiZrodlowejNavigations { get; set; } = new List<InformacjeOTrasie>();
}
