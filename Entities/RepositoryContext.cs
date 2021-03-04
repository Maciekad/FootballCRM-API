using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
            .HasOne(p => p.TeamNavigation)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Booking>()
            .HasOne(b => b.MatchNavigation)
            .WithMany(m => m.Bookings)
            .HasForeignKey(b => b.MatchId);

            modelBuilder.Entity<Ticket>()
           .HasOne(t => t.BookingNavigation)
           .WithMany(b => b.Tickets)
           .HasForeignKey(t => t.BookingId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        } 
    }
}
