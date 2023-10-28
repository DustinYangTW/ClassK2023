using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyModel_DBFirst.Models;

public partial class dbStudentsContext : DbContext
{
    //public dbStudentsContext(DbContextOptions<dbStudentsContext> options)
    //    : base(options)
    //{
    //}

    //1.2.4 在dbStudentsContext.cs裡撰寫一個空的建構子
    public dbStudentsContext()
    { }


    //1.2.3 在dbStudentsContext.cs裡撰寫連線到資料庫的程式
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=C501A118;Database=dbStudents;Trusted_Connection=True;TrustServerCertificate=True;User ID=C501A118/user;Password=*");

    public virtual DbSet<tStudent> tStudent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tStudent>(entity =>
        {
            entity.HasKey(e => e.fStuId).HasName("PK__tStudent__08E5BA954E42645E");

            entity.Property(e => e.fStuId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.fEmail).HasMaxLength(40);
            entity.Property(e => e.fName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
