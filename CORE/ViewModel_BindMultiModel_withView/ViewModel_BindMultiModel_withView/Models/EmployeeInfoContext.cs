using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ViewModel_BindMultiModel_withView.Models;

public partial class EmployeeInfoContext : DbContext
{
    public EmployeeInfoContext()
    {
    }

    public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AFB3EC0DD5FB0B34");

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("empEmail");
            entity.Property(e => e.EmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("empName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
