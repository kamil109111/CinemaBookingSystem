using CinemaBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data
{
    public class ApplicationDbContext: DbContext
    {
        private readonly string _connectionString =
       "Server=(localdb)\\mssqllocaldb;Database=CinemaDb;Trusted_Connection=True;";
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; } 
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(s => s.Seance)
                .WithMany(s => s.Tickets)
                .HasForeignKey(s => s.SeanceId);

            modelBuilder.Entity<Ticket>()
                .HasOne(s => s.Seat)
                .WithMany(s => s.Tickets)
                .HasForeignKey(s => s.SeatId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }    
}
