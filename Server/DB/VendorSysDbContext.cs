using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.DB;

public partial class VendorSysDbContext : DbContext
{
    public VendorSysDbContext()
    {
    }

    public VendorSysDbContext(DbContextOptions<VendorSysDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cashier> Cashiers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductsSold> ProductsSolds { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cashiers__3214EC07F730A4E4");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.PhoneN).HasMaxLength(100);
            entity.Property(e => e.SecondName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC071A6D1DD8");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.PhoneN).HasMaxLength(100);
            entity.Property(e => e.SecondName).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07B0305AF2");

            entity.Property(e => e.Discount).HasDefaultValueSql("((0))");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("('awdad')")
                .HasColumnType("image");
            entity.Property(e => e.Pname)
                .HasMaxLength(100)
                .HasColumnName("PName");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.ProdTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProdType)
                .HasConstraintName("FK__Products__ProdTy__4316F928");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductT__3214EC074492BB6F");

            entity.ToTable("ProductType");

            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<ProductsSold>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07D67BA6B6");

            entity.ToTable("ProductsSold");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsSolds)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductsS__Produ__46E78A0C");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ProductsSolds)
                .HasForeignKey(d => d.ReceiptId)
                .HasConstraintName("FK__ProductsS__Recei__48CFD27E");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Receipts__3214EC07FCB538CB");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("money");

            entity.HasOne(d => d.Cashier).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.CashierId)
                .HasConstraintName("FK__Receipts__Cashie__3C69FB99");

            entity.HasOne(d => d.Customer).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Receipts__Custom__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
