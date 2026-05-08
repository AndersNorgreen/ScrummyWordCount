using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScrummyWordCountApi.Core.Models;

namespace ScrummyWordCountApi.Infrastructure;

public partial class ScrummyWordCountContext : DbContext
{
    public ScrummyWordCountContext(DbContextOptions<ScrummyWordCountContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Search> Searches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Search>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("searches_pkey");

            entity.ToTable("searches");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Numberofoccurrences).HasColumnName("numberofoccurrences");
            entity.Property(e => e.Searchedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("searchedat");
            entity.Property(e => e.Searchquery)
                .HasMaxLength(255)
                .HasColumnName("searchquery");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
