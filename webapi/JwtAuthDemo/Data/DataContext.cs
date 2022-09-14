
using JwtAuthDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
            .Entity<Client>()
            .Property(e => e.role)
            .HasConversion<string>();
            builder.Entity<Client>()
                .HasIndex(e => e.NumeroCompte)
                .IsUnique();
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<DemandeCarte> DemandeCartes { get; set; }
        public DbSet<DemandeChequier> DemandeChequiers { get; set; }
        public DbSet<Transfert> Transferts { get; set; }
        public DbSet<Virement> Virements { get; set; }
        public DbSet<Solde> Soldes { get; set; }
    }
}
