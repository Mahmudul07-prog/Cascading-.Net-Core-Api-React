using Cascading_React.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cascading_React.Server.Data
{
    public class CascadingDbContext:DbContext
    {
        public CascadingDbContext(DbContextOptions<CascadingDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Division>()
                .HasOne(d => d.Country)
                .WithMany(c => c.Divisions)
                .HasForeignKey(d => d.CountryId);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Division)
                .WithMany(d => d.Cities)
                .HasForeignKey(c => c.DivisionId);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Countries
            var usa = new Country { Id = 1, Name = "United States" };
            var canada = new Country { Id = 2, Name = "Canada" };
            var uk = new Country { Id = 3, Name = "United Kingdom" };
            var australia = new Country { Id = 4, Name = "Australia" };
            var japan = new Country { Id = 5, Name = "Japan" };

            modelBuilder.Entity<Country>().HasData(
                usa, canada, uk, australia, japan
            );

            // Divisions (States/Provinces)
            var usDivisions = new[]
            {
                new Division { Id = 1, Name = "California", CountryId = 1 },
                new Division { Id = 2, Name = "Texas", CountryId = 1 },
                new Division { Id = 3, Name = "New York", CountryId = 1 },
                new Division { Id = 4, Name = "Florida", CountryId = 1 }
            };

            var canadaDivisions = new[]
            {
                new Division { Id = 5, Name = "Ontario", CountryId = 2 },
                new Division { Id = 6, Name = "Quebec", CountryId = 2 },
                new Division { Id = 7, Name = "British Columbia", CountryId = 2 }
            };

            var ukDivisions = new[]
            {
                new Division { Id = 8, Name = "England", CountryId = 3 },
                new Division { Id = 9, Name = "Scotland", CountryId = 3 }
            };

            modelBuilder.Entity<Division>().HasData(
                usDivisions[0], usDivisions[1], usDivisions[2], usDivisions[3],
                canadaDivisions[0], canadaDivisions[1], canadaDivisions[2],
                ukDivisions[0], ukDivisions[1]
            );

            // Cities
            modelBuilder.Entity<City>().HasData(
                // California cities
                new City { Id = 1, Name = "Los Angeles", DivisionId = 1 },
                new City { Id = 2, Name = "San Francisco", DivisionId = 1 },
                new City { Id = 3, Name = "San Diego", DivisionId = 1 },

                // Texas cities
                new City { Id = 4, Name = "Houston", DivisionId = 2 },
                new City { Id = 5, Name = "Dallas", DivisionId = 2 },
                new City { Id = 6, Name = "Austin", DivisionId = 2 },

                // New York cities
                new City { Id = 7, Name = "New York City", DivisionId = 3 },
                new City { Id = 8, Name = "Buffalo", DivisionId = 3 },

                // Florida cities
                new City { Id = 9, Name = "Miami", DivisionId = 4 },
                new City { Id = 10, Name = "Orlando", DivisionId = 4 },

                // Ontario cities
                new City { Id = 11, Name = "Toronto", DivisionId = 5 },
                new City { Id = 12, Name = "Ottawa", DivisionId = 5 },

                // Quebec cities
                new City { Id = 13, Name = "Montreal", DivisionId = 6 },
                new City { Id = 14, Name = "Quebec City", DivisionId = 6 },

                // British Columbia cities
                new City { Id = 15, Name = "Vancouver", DivisionId = 7 },

                // England cities
                new City { Id = 16, Name = "London", DivisionId = 8 },
                new City { Id = 17, Name = "Manchester", DivisionId = 8 },

                // Scotland cities
                new City { Id = 18, Name = "Edinburgh", DivisionId = 9 },
                new City { Id = 19, Name = "Glasgow", DivisionId = 9 },

                // Additional city to reach 20
                new City { Id = 20, Name = "Birmingham", DivisionId = 8 }
            );
        }

    }
}
