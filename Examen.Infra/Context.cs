using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infra
{
    public class Context : DbContext
    {
        public DbSet<Locataire> Locataires { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Agent> Agents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=AGS_OnesBenRhaimeOptions;
                                        Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Locataire>()
               .HasDiscriminator<int>("TypeLocataire")
               .HasValue<Locataire>(1)
               .HasValue<Entreprise>(2)
               .HasValue<Personne>(3);

            modelBuilder.Entity<Reservation>()
                .HasKey(r => new { r.LocataireKey, r.VehiculeKey, r.DateReservation });

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Locataire)
                .WithMany(l => l.Reservations)
                .HasForeignKey(r => r.LocataireKey);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Vehicule)
                .WithMany(v => v.Reservations)
                .HasForeignKey(r => r.VehiculeKey);

            modelBuilder.Entity<Vehicule>()
                .HasKey(v => v.VehiculeId);

            modelBuilder.Entity<Locataire>()
                .HasKey(l => l.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

