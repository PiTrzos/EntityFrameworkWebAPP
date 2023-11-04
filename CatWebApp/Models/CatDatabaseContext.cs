using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CatWebApp.Models;

public partial class CatDatabaseContext : DbContext
{
    public CatDatabaseContext()
    {
    }

    public CatDatabaseContext(DbContextOptions<CatDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BreedType> BreedTypes { get; set; }

    public virtual DbSet<Cat> Cats { get; set; }

    public virtual DbSet<FunFact> FunFacts { get; set; }

    public virtual DbSet<HealthIssue> HealthIssues { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BreedType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BreedType_pk");

            entity.ToTable("BreedType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cat_pk");

            entity.ToTable("Cat");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ActivityLevel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AffectionLevel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BreedName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BreedTypeId).HasColumnName("BreedTypeID");
            entity.Property(e => e.CoatLength)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CoatPattern)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CommonBreedIssues)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ExerciseNeeds)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GoodWith)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImgSrc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LifeSpan)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MainCharacteristics)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OriginDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.PersonalityTraitsDescription)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Playfulness)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SheddingAmmount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TendencyToVocalize)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.BreedType).WithMany(p => p.Cats)
                .HasForeignKey(d => d.BreedTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cat_BreedType");

            entity.HasMany(d => d.FunFacts).WithMany(p => p.Cats)
                .UsingEntity<Dictionary<string, object>>(
                    "CatFunFact",
                    r => r.HasOne<FunFact>().WithMany()
                        .HasForeignKey("FunFactsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CatFunFacts_FunFacts"),
                    l => l.HasOne<Cat>().WithMany()
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CatFunFacts_Cat"),
                    j =>
                    {
                        j.HasKey("CatId", "FunFactsId").HasName("CatFunFact_pk");
                        j.ToTable("CatFunFact");
                        j.IndexerProperty<int>("CatId").HasColumnName("CatID");
                        j.IndexerProperty<int>("FunFactsId").HasColumnName("FunFactsID");
                    });

            entity.HasMany(d => d.HealthIssues).WithMany(p => p.Cats)
                .UsingEntity<Dictionary<string, object>>(
                    "CatHealthIssue",
                    r => r.HasOne<HealthIssue>().WithMany()
                        .HasForeignKey("HealthIssuesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CatHealthIssue_HealthIssues"),
                    l => l.HasOne<Cat>().WithMany()
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CatHealthIssue_Cat"),
                    j =>
                    {
                        j.HasKey("CatId", "HealthIssuesId").HasName("CatHealthIssue_pk");
                        j.ToTable("CatHealthIssue");
                        j.IndexerProperty<int>("CatId").HasColumnName("Cat_ID");
                        j.IndexerProperty<int>("HealthIssuesId").HasColumnName("HealthIssues_ID");
                    });
        });

        modelBuilder.Entity<FunFact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FunFact_pk");

            entity.ToTable("FunFact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HealthIssue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HealthIssue_pk");

            entity.ToTable("HealthIssue");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
