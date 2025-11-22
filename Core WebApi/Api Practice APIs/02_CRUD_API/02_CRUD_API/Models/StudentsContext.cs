using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _02_CRUD_API.Models;

public partial class StudentsContext : DbContext
{
    public StudentsContext()
    {
    }

    public StudentsContext(DbContextOptions<StudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.GrNumber).HasName("PK__Student__934FAA249DD1745A");

            entity.ToTable("Student");

            entity.Property(e => e.Sage).HasColumnName("SAge");
            entity.Property(e => e.Sgender)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SGender");
            entity.Property(e => e.Sname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SName");
            entity.Property(e => e.Sstd).HasColumnName("SStd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
