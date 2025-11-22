using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudInDatabaseFirstApproach_09.Models;

public partial class CrudInDbFirstApproachContext : DbContext
{
    public CrudInDbFirstApproachContext()
    {
    }

    public CrudInDbFirstApproachContext(DbContextOptions<CrudInDbFirstApproachContext> options)
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
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B994718C28E");

            entity.Property(e => e.StudentGender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.StudentStd).HasColumnName("StudentSTD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
