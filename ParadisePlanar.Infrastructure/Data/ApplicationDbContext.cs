using Microsoft.EntityFrameworkCore;
using ParadisePlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadisePlanner.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Resort> Resorts { get; set; }
        public DbSet<ResortNo> ResortNos { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resort>().HasData(
                new Resort
                {
                    Id = 1,
                    Name = "Solstice Haven",
                    Description = "A tranquil retreat bathed in golden sunlight year-round, surrounded by cascading springs and whispering palms.",
                    Price = 13800000,
                    Sqft = 23000,
                    Occupancy = "9",
                    ImageUrl = "/images/resort1.jpg",
                    CreatedDate = DateTime.Now
                },
                new Resort
                {
                    Id = 2,
                    Name = "Azure Elysium",
                    Description = "An island sanctuary encircled by sapphire lagoons and blooming flora, offering the essence of tropical eternity.",
                    Price = 14900000,
                    Sqft = 25000,
                    Occupancy = "5",
                    ImageUrl = "/images/resort2.jpg",
                    CreatedDate = DateTime.Now
                },
                new Resort
                {
                    Id = 3,
                    Name = "Celestara Peak",
                    Description = "A cloud-piercing summit lodge where glass observatories open to panoramic starfields and northern lights.",
                    Price = 15700000,
                    Sqft = 28000,
                    Occupancy = "5",
                    ImageUrl = "/images/resort3.jpg",
                    CreatedDate = DateTime.Now
                },
                new Resort
                {
                    Id = 4,
                    Name = "Luminar Springs",
                    Description = "Hidden deep within a rainforest, this eco-luxury resort features glowing waterfalls and mineral-rich lagoons.",
                    Price = 12400000,
                    Sqft = 20000,
                    Occupancy = "8",
                    ImageUrl = "/images/resort4.jpg",
                    CreatedDate = DateTime.Now
                },
                new Resort
                {
                    Id = 5,
                    Name = "Seraphine Bay",
                    Description = "A celestial coastal escape where white sand meets diamond-clear water, kissed by heavenly breezes.",
                    Price = 14200000,
                    Sqft = 24000,
                    Occupancy = "9",
                    ImageUrl = "/images/resort5.jpg",
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<ResortNo>().HasData(
             new ResortNo { Id = 1, Resort_No = 101, ResortId = 1 },
             new ResortNo { Id = 2, Resort_No = 102, ResortId = 1 },
             new ResortNo { Id = 3, Resort_No = 103, ResortId = 1 },
             new ResortNo { Id = 4, Resort_No = 104, ResortId = 1 },
             new ResortNo { Id = 5, Resort_No = 201, ResortId = 2 },
             new ResortNo { Id = 6, Resort_No = 202, ResortId = 2 },
             new ResortNo { Id = 7, Resort_No = 203, ResortId = 2 }
   );

            modelBuilder.Entity<Amenity>().HasData(
             new Amenity { Id = 1, Name = "Swimming Pool", Description = "Outdoor pool with temperature control", ResortId = 1 },
             new Amenity { Id = 2, Name = "Gym", Description = "Modern fitness center open 24/7", ResortId = 1 },
             new Amenity { Id = 3, Name = "Spa", Description = "Relaxing massages and sauna", ResortId = 1 },
             new Amenity { Id = 4, Name = "Wi-Fi", Description = "Free high-speed internet", ResortId = 2 },
             new Amenity { Id = 5, Name = "Breakfast", Description = "Complimentary buffet breakfast", ResortId = 2 },
             new Amenity { Id = 6, Name = "Kids Play Area", Description = "Indoor playground for kids", ResortId = 2 },
             new Amenity { Id = 7, Name = "Private Beach", Description = "Exclusive beach access", ResortId = 2 }
);

        }

    }
}
