using G3.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.DAL
{
    public class Context : DbContext
    {

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Email = "joebloggs@hotmail.com",
                Password = "hello123",
                Username = "JoeBloggs1"
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 1,
                Vrm = "ABC123",
                Colour = "Blue",
                Make = "Citroen",
                Model = "C5",
                Price = 5000,
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 2,
                Vrm = "YT70IUH",
                Colour = "Black",
                Make = "Fiat",
                Model = "500",
                Price = 9000,
            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 3,
                Vrm = "PL17MTF",
                Colour = "Grey",
                Make = "Ford",
                Model = "Fiesta",
                Price = 6500,
            });
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserVehicleWatch> UserVehicleWatches { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
    }
}
