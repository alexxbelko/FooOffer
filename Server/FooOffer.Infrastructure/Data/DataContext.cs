using System;
using System.Collections.Generic;
using FooOffer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FooOffer.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferItem> OfferItems { get; set; }

        public DataContext(DbContextOptions options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseInMemoryDatabase(nameof(FooOffer));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #region Test data seeding

        public void SeedData()
        {
            SeedCities();

            SeedServices();
            
            Console.WriteLine("Seeding complete.");
        }

        private void SeedServices()
        {
            var services = new List<Alternative>
            {
                //Services for Stockholm
                new Alternative
                {
                    Id = 1,
                    CityId = 1,
                    Name = "Flyttstädning",
                    Unit = "m2",
                    UnitPrice = 65,
                    IncludedByDefault = true
                },
                new Alternative
                {
                    Id = 2,
                    CityId = 1,
                    Name = "Fönsterputs",
                    Unit = "st",
                    UnitPrice = 300
                },
                new Alternative
                {
                    Id = 3,
                    CityId = 1,
                    Name = "Balkongstädning",
                    Unit = "st",
                    UnitPrice = 150
                },
                
                //Services for Uppsala
                new Alternative
                {
                    Id = 4,
                    CityId = 2,
                    Name = "Flyttstädning",
                    Unit = "m2",
                    UnitPrice = 55,
                    IncludedByDefault = true
                },
                new Alternative
                {
                    Id = 5,
                    CityId = 2,
                    Name = "Fönsterputs",
                    Unit = "st",
                    UnitPrice = 300
                },
                new Alternative
                {
                    Id = 6,
                    CityId = 2,
                    Name = "Balkongstädning",
                    Unit = "st",
                    UnitPrice = 150
                },
                new Alternative
                {
                    Id = 7,
                    CityId = 2,
                    Name = "Bortforsling av skräp",
                    Unit = "st",
                    UnitPrice = 400
                }
            };

            Alternatives.AddRange(services);
            SaveChanges();
        }

        private void SeedCities()
        {
            var cities = new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "Stockholm"
                },
                new City
                {
                    Id = 2,
                    Name = "Uppsala"
                }
            };
            
            Cities.AddRange(cities);
            SaveChanges();
        }

        #endregion
    }
}