using LocVoiture.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocVoiture.Context
{
    public class MyContext : IdentityDbContext
    {
        internal IEnumerable<object> marques;

        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Assurance> Assurances { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
