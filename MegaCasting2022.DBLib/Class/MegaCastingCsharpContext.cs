using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MegaCasting2022.DBLib.Class
{
    public partial class MegaCastingCsharpContext : DbContext
    {
        public MegaCastingCsharpContext()
        {
        }

        public MegaCastingCsharpContext(DbContextOptions<MegaCastingCsharpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<ActivityArtist> ActivityArtists { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ContractType> ContractTypes { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=MegaCastingCsharp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Activity");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ActivityArtist>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("ActivityArtist");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.HasOne(d => d.IdentifierActivityNavigation)
                    .WithMany(p => p.ActivityArtists)
                    .HasForeignKey(d => d.IdentifierActivity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityArtist_Activity");

                entity.HasOne(d => d.IdentifierArtistNavigation)
                    .WithMany(p => p.ActivityArtists)
                    .HasForeignKey(d => d.IdentifierArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityArtist_Artist");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Artist");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Client");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.Property(e => e.AddressCity).HasMaxLength(50);

                entity.Property(e => e.AddressComplement).HasMaxLength(50);

                entity.Property(e => e.AddressRoad).HasMaxLength(50);

                entity.Property(e => e.AddressZipCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("ContractType");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.ShortName).HasMaxLength(5);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Offer");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdentifierClientNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.IdentifierClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_Client");

                entity.HasOne(d => d.IdentifierContractTypeNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.IdentifierContractType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_ContractType");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.Identifier);

                entity.ToTable("Partner");

                entity.Property(e => e.Identifier).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
