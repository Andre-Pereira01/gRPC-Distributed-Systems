using System;
using System.Collections.Generic;
using GrpcServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Data;

public partial class SistD2Context : DbContext
{
    public SistD2Context()
    {
    }

    public SistD2Context(DbContextOptions<SistD2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cobertura> Coberturas { get; set; }

    public virtual DbSet<Operacoes> Operacoes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=SistD2Context");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cobertura>(entity =>
        {
            entity.HasKey(e => e.NumAdmin).HasName("PK__Cobertura__F37EB4978306F78A");

            entity.Property(e => e.NumAdmin).ValueGeneratedNever();
        });

        modelBuilder.Entity<Operacoes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operacoes__3213E83F240AE940");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F8A2C33C3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
