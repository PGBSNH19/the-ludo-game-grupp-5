using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using TheLudoGameEngine;
using System.Linq;

namespace TheLudoGameEngine
{
    internal class LudoContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Token> Tokens { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.dev.json");
            var config = builder.Build();
            var defaultConnectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(defaultConnectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(g => g.GameID);
            modelBuilder.Entity<Player>().HasKey(p => p.PlayerID);
            modelBuilder.Entity<Token>().HasKey(t => t.TokenID);

            modelBuilder.Entity<Game>().HasMany(g => g.Players).WithOne(p => p.Game).IsRequired();
            modelBuilder.Entity<Player>().HasMany(p => p.Tokens).WithOne(t => t.Player).IsRequired();

            modelBuilder.Entity<Game>().Property(d => d.LastSaved).HasColumnType("SMALLDATETIME");

        }
    }
}