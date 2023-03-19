using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MobileApplicationListTest.Models;

public partial class MobileapplicationdataContext : DbContext
{
    public MobileapplicationdataContext()
    {
    }

    public MobileapplicationdataContext(DbContextOptions<MobileapplicationdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aplicationdetail> Aplicationdetails { get; set; }

    public virtual DbSet<Applicationbase> Applicationbases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=32768;Database=mobileapplicationdata;User Id=postgres;Password=postgrespw;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aplicationdetail>(entity =>
        {
            entity.ToTable("aplicationdetails");

            entity.HasIndex(e => e.ApplicationBaseId, "IX_aplicationdetails_ApplicationBaseId");

            entity.HasOne(d => d.ApplicationBase).WithMany(p => p.Aplicationdetails).HasForeignKey(d => d.ApplicationBaseId);
        });

        modelBuilder.Entity<Applicationbase>(entity =>
        {
            entity.ToTable("applicationbase");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
