using Microsoft.EntityFrameworkCore;
using testapi.Migrations;
using testapi.Models;

namespace testapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperPower> SuperPower { get; set; }
        public DbSet<SuperVillains> SuperVillains { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasMany(a => a.Posts).WithOne(b => b.Blog).HasForeignKey(c => c.BlogId).IsRequired(false);

            // modelBuilder.Entity<SuperHero>().HasMany(a=> a.)
            // modelBuilder.Entity<SuperHero>().HasIndex(o => o.Name); // single column index

            // // modelBuilder.Entity<SuperHero>().HasKey(o => o.Name);
            // modelBuilder.Entity<Author>().Property(a => a.Name).IsRequired();
            // modelBuilder.Entity<SuperVillains>().HasIndex(o => new { o.Name, o.FirstName, o.LastName, o.Place }); //composite index 
        }
    }



}