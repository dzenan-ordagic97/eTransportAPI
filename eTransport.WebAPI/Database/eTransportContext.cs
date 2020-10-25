using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTransport.WebAPI.Database
{
    public partial class eTransportContext: IdentityDbContext<User,IdentityRole<int>,int>
    {
        public eTransportContext()
        {

        }
        public eTransportContext(DbContextOptions<eTransportContext> options)
             : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }
        public DbSet<ExtraServices> ExtraServices { get; set; }
        public DbSet<CommentRating> CommentRating { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<Freight> Freight { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CargoReservation> CargoReservation { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageHeader> MessageHeader { get; set; }
        public DbSet<RatingCarrier> RatingCarrier { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Address>().HasKey(fs => new { fs.CityID});
            //modelBuilder.Entity<CargoPictures>().HasKey(fs => new { fs.CargoID, fs.PicturesID });
            //modelBuilder.Entity<CargoReservation>().HasKey(fs => new { fs.UserID, fs.FreightID,fs.CargoID });
            //modelBuilder.Entity<CargoType_Cargo>().HasKey(fs => new { fs.CargoID, fs.CargoTypeID });
            modelBuilder.Entity<Carrier>().HasOne(fs => fs.User ).WithOne(i=>i.Carrier);
            modelBuilder.Entity<Client>().HasOne(fs => fs.User).WithOne(i => i.Client);
            //modelBuilder.Entity<User>().HasOne(fs => fs.Client ).WithOne(i=>i.User).HasForeignKey<Client>(x=>x.UserID);
            //modelBuilder.Entity<City>().HasKey(fs => new { fs.CountryID });
            //modelBuilder.Entity<CommentRating>().HasKey(fs => new { fs.UserID, fs.FreightID });
            //modelBuilder.Entity<ExtraServices>().HasKey(fs => new { fs.CarrierID });
            //modelBuilder.Entity<ExtraServices_Cargo>().HasKey(fs => new { fs.ExtraServicesID,fs.CargoReservationID });
            //modelBuilder.Entity<Freight>().HasKey(fs => new { fs.CarrierID, fs.VehicleID });
            //modelBuilder.Entity<Vehicle>().HasKey(fs => new { fs.CarrierID,fs.VehicleModelID,fs.VehicleTypeID,fs.VehicleDetailsID });
            //modelBuilder.Entity<VehicleModel>().HasKey(fs => new { fs.CarrierID });
            //modelBuilder.Entity<VehiclePictures>().HasKey(fs => new { fs.VehicleDetailsID,fs.VehiclePicturesID });
            //modelBuilder.Entity<VehicleType>().HasKey(fs => new { fs.CarrierID });
        }

    }
}
