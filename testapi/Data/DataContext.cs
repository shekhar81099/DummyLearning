using Microsoft.EntityFrameworkCore;
using testapi.Models;

namespace testapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)  : base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperVillains> SuperVillains { get; set; }
        public DbSet<User>  Users { get; set; }
    }

}