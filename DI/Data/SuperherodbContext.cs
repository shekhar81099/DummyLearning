using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DI;

public partial class SuperherodbContext : DbContext
{
    public SuperherodbContext()
    {
    }

    public SuperherodbContext(DbContextOptions<SuperherodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<MyTest> MyTests { get; set; }

    public virtual DbSet<MyTest1> MyTest1s { get; set; }

    public virtual DbSet<MyTest2> MyTest2s { get; set; }

    public virtual DbSet<SuperHero> SuperHeroes { get; set; }

    public virtual DbSet<SuperPower> SuperPowers { get; set; }

    public virtual DbSet<SuperVillain> SuperVillains { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<Table2> Table2s { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=syadav\\SQLEXPRESS;Initial Catalog=superherodb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.HasIndex(e => e.AuthorId, "IX_Book_AuthorId");

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA7934E4BA63");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("EmpID");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<MyTest>(entity =>
        {
            entity.HasKey(e => e.MyKey).HasName("PK__MyTest__606C418F02AB282E");

            entity.ToTable("MyTest", tb => tb.HasTrigger("MyTestTrigger"));

            entity.Property(e => e.MyKey)
                .ValueGeneratedNever()
                .HasColumnName("myKey");
            entity.Property(e => e.MyValue).HasColumnName("myValue");
            entity.Property(e => e.Rv)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("RV");
        });

        modelBuilder.Entity<MyTest1>(entity =>
        {
            entity.HasKey(e => e.MyKey).HasName("PK__MyTest1__606C418F7B2F677E");

            entity.ToTable("MyTest1", tb => tb.HasTrigger("MyTestTrigger1"));

            entity.Property(e => e.MyKey)
                .ValueGeneratedNever()
                .HasColumnName("myKey");
            entity.Property(e => e.MyValue).HasColumnName("myValue");
            entity.Property(e => e.Rv)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("RV");
        });

        modelBuilder.Entity<MyTest2>(entity =>
        {
            entity.HasKey(e => e.MyKey).HasName("PK__MyTest2__606C418F6196B254");

            entity.ToTable("MyTest2");

            entity.Property(e => e.MyKey)
                .ValueGeneratedNever()
                .HasColumnName("myKey");
            entity.Property(e => e.MyValue).HasColumnName("myValue");
            entity.Property(e => e.Rv)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("RV");
        });

        modelBuilder.Entity<SuperPower>(entity =>
        {
            entity.ToTable("SuperPower");

            entity.HasIndex(e => e.SuperHeroId, "IX_SuperPower_SuperHeroId");

            entity.HasOne(d => d.SuperHero).WithMany(p => p.SuperPowers).HasForeignKey(d => d.SuperHeroId);
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table1");
        });

        modelBuilder.Entity<Table2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.Property(e => e.Role).HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
