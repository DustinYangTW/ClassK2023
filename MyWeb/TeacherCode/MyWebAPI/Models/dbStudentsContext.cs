using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Models;

public partial class dbStudentsContext : DbContext
{
    public dbStudentsContext(DbContextOptions<dbStudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<tStudent> tStudent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptID).HasName("PK__Departme__0148818E21835D76");

            entity.Property(e => e.DeptID)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.DeptName).HasMaxLength(30);
        });

        modelBuilder.Entity<tStudent>(entity =>
        {
            entity.HasKey(e => e.fStuId).HasName("PK__tStudent__08E5BA954E42645E");

            entity.Property(e => e.fStuId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DeptID)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('01')");
            entity.Property(e => e.fEmail).HasMaxLength(40);
            entity.Property(e => e.fName).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.tStudent)
                .HasForeignKey(d => d.DeptID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tStudent__DeptID__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
