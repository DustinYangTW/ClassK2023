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

    public virtual DbSet<Book> Book { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<tStudent> tStudent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.GId);

            entity.Property(e => e.Author).HasMaxLength(20);
            entity.Property(e => e.ImageType).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(30);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.KId);

            entity.HasIndex(e => e.GId, "IX_Department_GId");

            entity.Property(e => e.Author).HasMaxLength(20);

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.Department).HasForeignKey(d => d.GId);
        });

        modelBuilder.Entity<tStudent>(entity =>
        {
            entity.HasKey(e => e.fStuId).HasName("PK__tStudent__08E5BA95D2C72773");

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
