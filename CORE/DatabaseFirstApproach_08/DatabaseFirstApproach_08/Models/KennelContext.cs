using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach_08.Models;

public partial class KennelContext : DbContext
{
    public KennelContext()
    {
    }

    public KennelContext(DbContextOptions<KennelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Person1> Persons { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetCountry> PetCountries { get; set; }

    public virtual DbSet<PhotoUpload> PhotoUploads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFBE5D05CC356");

            entity.ToTable("Person");
        });

        modelBuilder.Entity<Person1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC07838F6DDE");

            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__pets__DDF85079EAD91BCF");

            entity.ToTable("pets");

            entity.Property(e => e.PetId).HasColumnName("petId");
            entity.Property(e => e.Hobbies)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PetAdoptedDate).HasColumnName("petAdoptedDate");
            entity.Property(e => e.PetAge).HasColumnName("petAge");
            entity.Property(e => e.PetBreed)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("petBreed");
            entity.Property(e => e.PetGender)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("petGender");
            entity.Property(e => e.PetName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("petName");
            entity.Property(e => e.PetPhoto).IsUnicode(false);

            entity.HasOne(d => d.PetCountry).WithMany(p => p.Pets)
                .HasForeignKey(d => d.PetCountryId)
                .HasConstraintName("fk_PetCountryId");
        });

        modelBuilder.Entity<PetCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__PetCount__10D1609FBDB8804A");

            entity.Property(e => e.CountryName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("countryName");
        });

        modelBuilder.Entity<PhotoUpload>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__PhotoUpl__48E538024379648C");

            entity.ToTable("PhotoUpload");

            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.PetPhoto).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
