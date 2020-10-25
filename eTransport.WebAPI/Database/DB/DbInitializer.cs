using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database.DB
{
    public class DbInitializer
    {
        public static async Task Seed(eTransportContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (context.Roles.Any())
            {
                return; //Database is initialized
            }
            await roleManager.CreateAsync(new IdentityRole<int> { Name = Model.Helpers.Role.Client, NormalizedName = Model.Helpers.Role.Client.ToUpper() });
            await roleManager.CreateAsync(new IdentityRole<int> { Name = Model.Helpers.Role.Carrier, NormalizedName = Model.Helpers.Role.Carrier.ToUpper() });
            await roleManager.CreateAsync(new IdentityRole<int> { Name = Model.Helpers.Role.Admin, NormalizedName = Model.Helpers.Role.Admin.ToUpper() });

            //create countries
            if (context.Country.Count() == 0)
            {
                var country = new List<Country>
                {
                    new Country { Name="Bosnia and Herzegovina", Acronym = "BH"},
                    new Country { Name="Croatia", Acronym = "CR"},
                    new Country { Name="Serbia", Acronym = "SR"}
                };
                foreach (var item in country)
                {
                    context.Country.Add(item);
                }
                context.SaveChanges();
            }
            //create cities
            if (context.City.Count() == 0)
            {
                var city = new List<City>
                {
                    new City { CountryID=1,Name="Mostar",PostalNumber="88000"},
                    new City { CountryID=1,Name="Sarajevo",PostalNumber="80000"},
                    new City { CountryID=1,Name="Bihac",PostalNumber="70000"},
                    new City { CountryID=1,Name="Velika Kladusa",PostalNumber="77230"},
                    new City { CountryID=2,Name="Zagreb",PostalNumber="10000"},
                    new City { CountryID=2,Name="Karlovac",PostalNumber="20000"},
                    new City { CountryID=2,Name="Split",PostalNumber="13220"},
                    new City { CountryID=3,Name="Beograd",PostalNumber="43220"},
                    new City { CountryID=3,Name="Crnograd",PostalNumber="53220"},
                };
                foreach (var item in city)
                {
                    context.City.Add(item);
                }
                context.SaveChanges();
            }
            //Carrier creation
            await CreateCarrier(userManager, "John.Doe@gmail.com", "JohnCarrier", "John123+-", "JohnBusiness@gmail.com", "11FDDD", "100-200-300", 1, "Ale cisica bb", Model.Helpers.Role.Carrier);
            await CreateCarrier(userManager, "James.Smith@gmail.com", "JamesCarrier", "James123+-", "JamesBusiness@gmail.com", "AD31DF", "100-200-300", 2, "Sarajevska bb", Model.Helpers.Role.Carrier);
            await CreateCarrier(userManager, "Jonathan.Biggs@gmail.com", "JonathanCarrier", "Jonathan123+-", "JonathanBusiness@gmail.com", "GB14FD", "100-200-300", 4, "Barake bb", Model.Helpers.Role.Carrier);
            await CreateCarrier(userManager, "Dzenan.Ordagic@gmail.com", "DzenanCarrier", "Dzenan123+-", "DzenanBusiness@gmail.com", "HJIKLMN", "100-200-300", 5, "Zagrebacka bb", Model.Helpers.Role.Carrier);

            //Client creation
            await CreateClient(userManager, "Adam.mobile@gmail.com", "Adam", "Mobile", DateTime.Now, "Adam123+-", "Male", "12141414141", 1, "Ale cisica bb", Model.Helpers.Role.Client);
            await CreateClient(userManager, "Silvia.mobile@gmail.com", "Silvia", "Mobile", DateTime.Now, "Silvia123+-", "Female", "12141414141", 2, "Sarajevska bb", Model.Helpers.Role.Client);
            await CreateClient(userManager, "Bruce.mobile@gmail.com", "Bruce", "Mobile", DateTime.Now, "Bruce123+-", "Male", "12141414141", 4, "Barake", Model.Helpers.Role.Client);

            //Admin creation
            await CreateAdmin(userManager, "admin@gmail.com", "Admin123+-", Model.Helpers.Role.Admin);

            //Vehicle creation
            var vehicleTypes = new List<VehicleType>
                {
                    new VehicleType {Name="Truck"},
                    new VehicleType {Name="Tractor"}
                };
            foreach (var item in vehicleTypes)
            {
                context.VehicleType.Add(item);
            }
            context.SaveChanges();

            var vehicleModels = new List<VehicleModel>
                {
                    new VehicleModel {Name="Scania"},
                    new VehicleModel {Name="Lamborghini"}
                };
            foreach (var item in vehicleModels)
            {
                context.VehicleModel.Add(item);
            }
            context.SaveChanges();

            var vehicleDetails = new List<VehicleDetails>
                {
                    new VehicleDetails {Description="test_description",MaxHeight=10,MaxLength=30,MaxWeight=2000,MaxWidth=30,Price_per_km=100},
                    new VehicleDetails {Description="test_description2",MaxHeight=20,MaxLength=40,MaxWeight=3000,MaxWidth=30,Price_per_km=200}
                };
            foreach (var item in vehicleDetails)
            {
                context.VehicleDetails.Add(item);
            }
            context.SaveChanges();

            var vehicles = new List<Vehicle>
                {
                    new Vehicle {VehicleModelID=2,VehicleTypeID=2,VehicleDetailsID=1,LicencePlate="DFFAG3",YearOfManufacture=DateTime.Now,TrunkVolume=300,SeatingCapacity=2,CarrierID=2,Image=Properties.Resources.truck},
                    new Vehicle {VehicleModelID=2,VehicleTypeID=2,VehicleDetailsID=1,LicencePlate="AFFAG3",YearOfManufacture=DateTime.Now,TrunkVolume=300,SeatingCapacity=2,CarrierID=1,Image=Properties.Resources.truck2},
                    new Vehicle {VehicleModelID=2,VehicleTypeID=2,VehicleDetailsID=1,LicencePlate="BFFAG3",YearOfManufacture=DateTime.Now,TrunkVolume=300,SeatingCapacity=2,CarrierID=1,Image=Properties.Resources.truck},
                };
            foreach (var item in vehicles)
            {
                context.Vehicle.Add(item);
            }
            context.SaveChanges();

            //Freight creation (for specific carrier reservation)
            var freights = new List<Freight>
                {
                    new Freight {CarrierID=1},
                    new Freight {CarrierID=2,AcceptDate=new DateTime(2020,06,06),TransportDate=new DateTime(2020,06,07),Distance=200,IsRated=true,Price=200,VehicleID=3,Finished=true,IsPayed=true},
                    new Freight {CarrierID=1,AcceptDate=new DateTime(2020,06,06),TransportDate=new DateTime(2020,06,07),Distance=200,IsRated=true,Price=200,VehicleID=1,Finished=true,IsPayed=true},
                    new Freight {CarrierID=1,AcceptDate=new DateTime(2020,08,08),TransportDate=new DateTime(2020,09,09),Distance=200,Price=200,VehicleID=1,Finished=true},
                };
            foreach (var item in freights)
            {
                context.Freight.Add(item);
            }
            context.SaveChanges();

            //Reservation creation
            var cargos = new List<Cargo>
                {
                    new Cargo {Name="Wood transfer",Description="Wood description",MaxHeight=20,MaxWidth=30,Weight=1000,ClientID=5,Image=Properties.Resources.woodCargo,IsUsed=false},
                    new Cargo {Name="test transfer1",Description="test description",MaxHeight=20,MaxWidth=30,Weight=1000,ClientID=5,Image=Properties.Resources.woodCargo,IsUsed=true},
                    new Cargo {Name="test transfer2",Description="test description2",MaxHeight=20,MaxWidth=30,Weight=1000,ClientID=5,Image=Properties.Resources.woodCargo,IsUsed=true},
                    new Cargo {Name="test transfer3",Description="test description3",MaxHeight=20,MaxWidth=30,Weight=1000,ClientID=5,Image=Properties.Resources.woodCargo,IsUsed=true},
                    new Cargo {Name="test transfer4",Description="test description4",MaxHeight=20,MaxWidth=30,Weight=1000,ClientID=5,Image=Properties.Resources.woodCargo,IsUsed=true}
                };
            foreach (var item in cargos)
            {
                context.Cargo.Add(item);
            }
            context.SaveChanges();
            var cargoReservations = new List<CargoReservation>
                {
                    new CargoReservation {StartLocation="Mostar",EndLocation="Sarajevo",StartDateTransport=new DateTime(2020,01,01),EndDateTransport=new DateTime(2020,02,02),CargoID=1,ClientID=6,FreightID=3,Accepted=true},
                    new CargoReservation {StartLocation="Bihac",EndLocation="Zenica",StartDateTransport=new DateTime(2020,05,05),EndDateTransport=new DateTime(2020,06,06),CargoID=2,ClientID=5},
                    new CargoReservation {StartLocation="Velika Kladusa",EndLocation="Cazin",StartDateTransport=new DateTime(2020,03,03),EndDateTransport=new DateTime(2020,04,04),CargoID=3,ClientID=5,FreightID=1,Accepted=true},
                    new CargoReservation {StartLocation="Velika Kladusa",EndLocation="Bihac",StartDateTransport=new DateTime(2020,03,04),EndDateTransport=new DateTime(2020,04,05),CargoID=4,ClientID=5,FreightID=2,Accepted=true}

                };
            foreach (var item in cargoReservations)
            {
                context.CargoReservation.Add(item);
            }
            context.SaveChanges();

            //Comment and rating
            var commentRatings = new List<CommentRating>
                {
                    new CommentRating {Rating=3,Comment="Good",ClientID=5,FreightID=2},
                    new CommentRating {Rating=5,Comment="Excellent",ClientID=6,FreightID=3},
                };
            foreach (var item in commentRatings)
            {
                context.CommentRating.Add(item);
            }
            context.SaveChanges();

            //Rating carrier
            var ratingCarrier = new List<RatingCarrier>
                {
                    new RatingCarrier {Rating=3,ClientID=5,CarrierID=1},
                    new RatingCarrier {Rating=5,ClientID=6,CarrierID=2}
                };
            foreach (var item in ratingCarrier)
            {
                context.RatingCarrier.Add(item);
            }
            context.SaveChanges();
        }
        private static async Task CreateCarrier(UserManager<User> userManager, string Email, string CarrierName, string password, string businessMail, string driverLicence, string businessNumber, int cityID, string addressName, string rola)
        {
            await userManager.CreateAsync(new User
            {
                UserName = Email,
                Email = Email,
                Carrier = new Carrier()
                {
                    CarrierName = CarrierName,
                    CarrierBusinessEmail = businessMail,
                    DriverLicenceNumber = driverLicence,
                    BusinessNumber = businessNumber,
                    Image = Properties.Resources.truck
                },
                Address = new Address()
                {
                    CityID = cityID,
                    Name = addressName
                }
            });

            var korisnik = await userManager.FindByEmailAsync(Email);
            await userManager.AddPasswordAsync(korisnik, password);
            await userManager.AddToRoleAsync(korisnik, rola);
        }
        private static async Task CreateClient(UserManager<User> userManager, string Email, string FirstName, string LastName, DateTime dateOfBirth, string password, string gender, string JMBG, int cityID, string addressName, string rola)
        {
            await userManager.CreateAsync(new User
            {

                UserName = Email,
                Email = Email,
                Client = new Client()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    DateOfBirth = dateOfBirth,
                    Gender = gender,
                    JMBG = JMBG
                },
                Address = new Address()
                {
                    CityID = cityID,
                    Name = addressName
                }
            });

            var korisnik = await userManager.FindByEmailAsync(Email);
            await userManager.AddPasswordAsync(korisnik, password);
            await userManager.AddToRoleAsync(korisnik, rola);
        }
        private static async Task CreateAdmin(UserManager<User> um, string email, string password, string rola)
        {
            await um.CreateAsync(new User
            {

                UserName = email,
                Email = email,
            });

            var korisnik = await um.FindByEmailAsync(email);
            await um.AddPasswordAsync(korisnik, password);
            await um.AddToRoleAsync(korisnik, rola);
        }
    }
}
