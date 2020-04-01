using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TheLudoGameEngine
{
    internal class MyContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlServer(@"Data Source=den1.mssql8.gear.host;Initial Catalog=dbtheludogame;User id=dbtheludogame;password=Ip5ych-!9Vb1;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(g => g.GameID);
            modelBuilder.Entity<Player>().HasKey(p => p.PlayerID);
            modelBuilder.Entity<Token>().HasKey(t => t.TokenID);

            modelBuilder.Entity<Game>().HasMany(g => g.Players).WithOne(p => p.Game).IsRequired();
            modelBuilder.Entity<Player>().HasMany(p => p.Tokens).WithOne(t => t.Player).IsRequired();
        }
    }
}