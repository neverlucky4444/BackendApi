using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models;

public partial class CartingContext : DbContext
{
    public CartingContext()
    {
    }

    public CartingContext(DbContextOptions<CartingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Loyaltyprogram> Loyaltyprograms { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= KOMPUTER\\SQLEXPRESS ;Database= Carting;User Id= sa1;Password= 12345; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B82A6CC34E");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534E9489D41").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateOfBirth)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Loyaltyprogram>(entity =>
        {
            entity.HasKey(e => e.LoyaltyId).HasName("PK__Loyaltyp__8D457913DFF36178");

            entity.ToTable("Loyaltyprogram");

            entity.Property(e => e.LoyaltyId).HasColumnName("LoyaltyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Tier).HasMaxLength(20);
            entity.Property(e => e.TotalSpending).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Loyaltyprograms)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Loyaltyprogram");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PK__Offers__8EBCF0B10B6A79E5");

            entity.Property(e => e.OfferId).HasColumnName("OfferID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.OfferType).HasMaxLength(50);
            entity.Property(e => e.ValidUntil).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Offers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Offers");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("PK__Races__05FBD6D4953D5ED6");

            entity.Property(e => e.RaceId).HasColumnName("RaceID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.RaceDate).HasColumnType("datetime");
            entity.Property(e => e.TrackId).HasColumnName("TrackID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Races)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Races");

            entity.HasOne(d => d.Track).WithMany(p => p.Races)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_Tracks");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C41FC5B169B5");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Item).HasMaxLength(100);
            entity.Property(e => e.SaleDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Sales");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PK__Tracks__7A74F8C0C3AD6960");

            entity.Property(e => e.TrackId).HasColumnName("TrackID");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TrackName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
