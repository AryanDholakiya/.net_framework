using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bind_DropDownList_With_Db_13.Models;

public partial class BindDropDownListContext : DbContext
{


    public BindDropDownListContext(DbContextOptions<BindDropDownListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetCountry> PetCountries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pet__3214EC0712CF3F8C");

            entity.ToTable("Pet");

            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Pets)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("fk_PetCountry");
        });

        modelBuilder.Entity<PetCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PetCount__3214EC07A20D7153");

            entity.Property(e => e.Countries)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("countries");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
