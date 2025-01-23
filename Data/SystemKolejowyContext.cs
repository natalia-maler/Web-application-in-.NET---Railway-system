using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SystemKolejowy.Models;

namespace SystemKolejowy.Data;

public partial class SystemKolejowyContext : DbContext
{
    public SystemKolejowyContext()
    {
    }

    public SystemKolejowyContext(DbContextOptions<SystemKolejowyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AktualneRezerwacje> AktualneRezerwacjes { get; set; }

    public virtual DbSet<AnulowaneRezerwacje> AnulowaneRezerwacjes { get; set; }

    public virtual DbSet<AnulowanieBiletu> AnulowanieBiletus { get; set; }

    public virtual DbSet<CzasZOpoznieniem> CzasZOpoznieniems { get; set; }

    public virtual DbSet<HistoriaZmianPasazerow> HistoriaZmianPasazerows { get; set; }

    public virtual DbSet<InformacjeOTrasie> InformacjeOTrasies { get; set; }

    public virtual DbSet<LogUsunieciaPlatnosci> LogUsunieciaPlatnoscis { get; set; }

    public virtual DbSet<Opoznienium> Opoznienia { get; set; }

    public virtual DbSet<Pasazerowie> Pasazerowies { get; set; }

    public virtual DbSet<Platnosci> Platnoscis { get; set; }

    public virtual DbSet<Pociagi> Pociagis { get; set; }

    public virtual DbSet<Przyklad> Przyklads { get; set; }

    public virtual DbSet<RezerwacjeBiletow> RezerwacjeBiletows { get; set; }

    public virtual DbSet<Rozklad> Rozklads { get; set; }

    public virtual DbSet<Stacje> Stacjes { get; set; }

    public virtual DbSet<SumaCenBiletow> SumaCenBiletows { get; set; }

    public virtual DbSet<SzczegolyTechnicznePociagow> SzczegolyTechnicznePociagows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-RGFJNK82;Initial Catalog=SystemKolejowy;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AktualneRezerwacje>(entity =>
        {
            entity.ToView("Aktualne_rezerwacje");
        });

        modelBuilder.Entity<AnulowaneRezerwacje>(entity =>
        {
            entity.ToView("Anulowane_rezerwacje");
        });

        modelBuilder.Entity<AnulowanieBiletu>(entity =>
        {
            entity.HasKey(e => e.IdAnulowania).HasName("PK__Anulowan__6E7F28038068365E");

            entity.Property(e => e.IdAnulowania).ValueGeneratedNever();

            entity.HasOne(d => d.IdRezerwacjiNavigation).WithMany(p => p.AnulowanieBiletus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anulowani__ID_re__5165187F");
        });

        modelBuilder.Entity<CzasZOpoznieniem>(entity =>
        {
            entity.ToView("Czas_z_opoznieniem");
        });

        modelBuilder.Entity<HistoriaZmianPasazerow>(entity =>
        {
            entity.HasKey(e => e.IdZmiany).HasName("PK__Historia__50C99C78ADE7223B");
        });

        modelBuilder.Entity<InformacjeOTrasie>(entity =>
        {
            entity.HasKey(e => e.IdTrasy).HasName("PK__Informac__3AA246FC621F731C");

            entity.Property(e => e.IdTrasy).ValueGeneratedNever();

            entity.HasOne(d => d.IdStacjiDocelowejNavigation).WithMany(p => p.InformacjeOTrasieIdStacjiDocelowejNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Informacj__ID_st__4222D4EF");

            entity.HasOne(d => d.IdStacjiZrodlowejNavigation).WithMany(p => p.InformacjeOTrasieIdStacjiZrodlowejNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Informacj__ID_st__412EB0B6");
        });

        modelBuilder.Entity<LogUsunieciaPlatnosci>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK__Log_usun__25BD3B9375F861ED");
        });

        modelBuilder.Entity<Opoznienium>(entity =>
        {
            entity.HasKey(e => e.IdOpoznienia).HasName("PK__Opoznien__8ABE617EC23452EE");

            entity.Property(e => e.IdOpoznienia).ValueGeneratedNever();

            entity.HasOne(d => d.IdRozkladuNavigation).WithMany(p => p.Opoznienia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Opoznieni__ID_ro__4E88ABD4");
        });

        modelBuilder.Entity<Pasazerowie>(entity =>
        {
            entity.HasKey(e => e.IdPasazera).HasName("PK__Pasazero__8D8882FD56A0BC6A");

            entity.ToTable("Pasazerowie", tb => tb.HasTrigger("Aktualizacja_danych_pasazera"));

            entity.Property(e => e.IdPasazera).ValueGeneratedNever();
        });

        modelBuilder.Entity<Platnosci>(entity =>
        {
            entity.HasKey(e => e.IdPlatnosci).HasName("PK__Platnosc__44388091FC3BD911");

            entity.ToTable("Platnosci", tb => tb.HasTrigger("Usuwanie_platnosci"));

            entity.Property(e => e.IdPlatnosci).ValueGeneratedNever();

            entity.HasOne(d => d.IdRezerwacjiNavigation).WithMany(p => p.Platnoscis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Platnosci__ID_re__4BAC3F29");
        });

        modelBuilder.Entity<Pociagi>(entity =>
        {
            entity.HasKey(e => e.IdPociagu).HasName("PK__Pociagi__EC7F8C522B528F16");

            entity.Property(e => e.IdPociagu).ValueGeneratedNever();
        });

        modelBuilder.Entity<RezerwacjeBiletow>(entity =>
        {
            entity.HasKey(e => e.IdRezerwacji).HasName("PK__Rezerwac__8B578F6BBD443AFA");

            entity.Property(e => e.IdRezerwacji).ValueGeneratedNever();

            entity.HasOne(d => d.IdPasazeraNavigation).WithMany(p => p.RezerwacjeBiletows)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rezerwacj__ID_pa__48CFD27E");

            entity.HasOne(d => d.IdRozkladuNavigation).WithMany(p => p.RezerwacjeBiletows)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rezerwacj__ID_ro__47DBAE45");
        });

        modelBuilder.Entity<Rozklad>(entity =>
        {
            entity.HasKey(e => e.IdRozkladu).HasName("PK__Rozklad__097DE530D6A8298C");

            entity.Property(e => e.IdRozkladu).ValueGeneratedNever();

            entity.HasOne(d => d.IdPociaguNavigation).WithMany(p => p.Rozklads)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rozklad__ID_poci__3C69FB99");
        });

        modelBuilder.Entity<Stacje>(entity =>
        {
            entity.HasKey(e => e.IdStacji).HasName("PK__Stacje__59FB69C779D05458");

            entity.Property(e => e.IdStacji).ValueGeneratedNever();
        });

        modelBuilder.Entity<SumaCenBiletow>(entity =>
        {
            entity.ToView("Suma_cen_biletow");
        });

        modelBuilder.Entity<SzczegolyTechnicznePociagow>(entity =>
        {
            entity.HasKey(e => e.IdPociagu).HasName("PK__Szczegol__EC7F8C5228F2C054");

            entity.Property(e => e.IdPociagu).ValueGeneratedNever();

            entity.HasOne(d => d.IdPociaguNavigation).WithOne(p => p.SzczegolyTechnicznePociagow)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Szczegoly__ID_po__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
