using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace OlympicGames.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Countries> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = "in", CategoryName = "Indoor"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = "out", CategoryName = "Outdoor" });

            modelBuilder.Entity<Game>().HasData(new Game { GameID = "wint", GameName = "Winter" });
            modelBuilder.Entity<Game>().HasData(new Game { GameID = "sum", GameName = "Summer" });
            modelBuilder.Entity<Game>().HasData(new Game { GameID = "para", GameName = "Paralympics" });
            modelBuilder.Entity<Game>().HasData(new Game { GameID = "you", GameName = "Youth" });

            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "can", CountryName = "Canada", GameID = "wint", CategoryID = "in", FlagImage = "can.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "swe", CountryName = "Sweden", GameID = "wint", CategoryID = "in", FlagImage = "swe.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "gb", CountryName = "Great Britain", GameID = "wint", CategoryID = "in", FlagImage = "gb.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "jam", CountryName = "Jamaica", GameID = "wint", CategoryID = "in", FlagImage = "jam.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "bra", CountryName = "Brazil", GameID = "sum", CategoryID = "out", FlagImage = "bra.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "net", CountryName = "Netherlands", GameID = "sum", CategoryID = "out", FlagImage = "net.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "usa", CountryName = "USA", GameID = "sum", CategoryID = "out", FlagImage = "usa.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "tha", CountryName = "Thailand", GameID = "para", CategoryID = "in", FlagImage = "tha.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "uru", CountryName = "Uruguay", GameID = "para", CategoryID = "in", FlagImage = "uru.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "ukr", CountryName = "Ukraine", GameID = "para", CategoryID = "in", FlagImage = "ukr.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "fra", CountryName = "France", GameID = "you", CategoryID = "in", FlagImage = "fra.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "rus", CountryName = "Russia", GameID = "you", CategoryID = "in", FlagImage = "rus.png" });
            modelBuilder.Entity<Countries>().HasData(new Countries { CountryID = "por", CountryName = "Portugal", GameID = "you", CategoryID = "out", FlagImage = "por.png" });


        }

    }
}
