using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ViewModel_BindMultiModel_withView.Models;

public partial class StudentInfoContext : DbContext
{
    public StudentInfoContext()
    {
    }

    public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
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
            entity.HasKey(e => e.Sid).HasName("PK__StudentI__CA19595061488BDB");

            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.Saddress)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SAddress");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
