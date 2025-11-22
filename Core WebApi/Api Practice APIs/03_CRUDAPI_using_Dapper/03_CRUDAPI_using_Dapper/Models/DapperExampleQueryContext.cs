using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _03_CRUDAPI_using_Dapper.Models;

public partial class DapperExampleQueryContext : DbContext
{
    public DapperExampleQueryContext()
    {
    }

    public DapperExampleQueryContext(DbContextOptions<DapperExampleQueryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__person__3214EC07E0877925");

            entity.ToTable("person");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
