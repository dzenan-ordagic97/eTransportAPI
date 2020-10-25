using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services.Auth
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly eTransportContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<Database.User> _userManager;
        private readonly SignInManager<Database.User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public ApplicationUserService(eTransportContext dbContext, IHttpContextAccessor httpContext, UserManager<Database.User> userManager, SignInManager<Database.User> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<Database.User> checkUserLogin(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            var loginTask = await _signInManager.PasswordSignInAsync(user, password, false, true);
            if (loginTask.IsLockedOut)
            {
                throw new UnauthorizedAccessException("Users account is in lockdown!");
            }
            if (!loginTask.Succeeded)
            {
                throw new Exception("Incorrect password!");
            }
            await _signInManager.RefreshSignInAsync(user);
            return user;
        }
        public async Task<Database.User> createUser(ApplicationUserCreateRequest user, string password)
        {
            //await _userManager.CreateAsync(new User()
            //{
            //    UserName = user.Email,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Gender = "M",
            //    DateOfBirth = DateTime.Now,
            //    Client=new Client { 
            //        JMBG = "151651"
            //    }
            //});
            IdentityResult t = null;
            IList<string> roles = new List<string>();
            if (user.Client != null)
            {

                User u = new User()
                {
                    UserName = user.Email,
                    Email = user.Email,
                    Client = new Client()
                    {
                        LastName = user.Client.LastName,
                        FirstName = user.Client.FirstName,
                        JMBG = user.Client.JMBG,
                        Gender = user.Client.Gender,
                        DateOfBirth = user.Client.DateOfBirth
                    },
                    Address = new Address
                    {
                        CityID = user.Address.CityID,
                        Name = user.Address.Name
                    },
                };
                t = await _userManager.CreateAsync(u, password);
                roles = new List<string>() { Model.Helpers.Role.Client };
            }
            if (user.Carrier != null)
            {
                User u = new User()
                {
                    UserName = user.Email,
                    Email = user.Email,
                    NormalizedEmail = user.Email.ToUpper(),
                    NormalizedUserName = user.Email.ToUpper(),
                    Address = new Address
                    {
                        CityID = user.Address.CityID,
                        Name = user.Address.Name
                    },
                    Carrier = new Carrier
                    {
                        BusinessNumber = user.Carrier.BusinessNumber,
                        CarrierBusinessEmail = user.Carrier.CarrierBusinessEmail,
                        CarrierName = user.Carrier.CarrierName,
                        DriverLicenceNumber = user.Carrier.DriverLicenceNumber,
                        Image = user.Carrier.Image
                    }
                };
                try
                {
                    t = await _userManager.CreateAsync(u, password);
                }
                catch (Exception err)
                {
                    throw;
                }
                roles = new List<string>() { Model.Helpers.Role.Carrier };

            }
            if (user.Carrier == null && user.Client == null)
            {
                User u = new User()
                {
                    UserName = user.Email,
                    Email = user.Email,
                    AddressID = user.AddressID,
                };
                t = await _userManager.CreateAsync(u, password);
                roles = new List<string>() { Model.Helpers.Role.Admin };

            }
            var korisnik = await _userManager.FindByEmailAsync(user.Email);
            //var t1 = await _userManager.AddPasswordAsync(korisnik, password);
            if (!t.Succeeded)
            {
                var errors = t.Errors.Select(x => x.Description).ToList();
                var stringError = "";
                foreach (var item in errors)
                {
                    stringError += item + "\n";
                }
                throw new Exception(stringError);
            }

            await _userManager.AddToRolesAsync(korisnik, roles);
            return korisnik;
        }

        public async Task<Database.User> getUserById(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }
        public async Task<IList<string>> getUserRoles(Database.User user)
        {
            return await _userManager.GetRolesAsync(user);
        }
        public async Task<bool> updateIdenityUserRoles(int id, IEnumerable<string> RemoveRole, IEnumerable<string> AddRole)
        {
            var user = await getUserById(id);
            var task1 = await _userManager.RemoveFromRolesAsync(user, RemoveRole);
            var task2 = await _userManager.AddToRolesAsync(user, AddRole);

            if (task1.Succeeded && task2.Succeeded)
            {
                return true;
            }
            await _userManager.RemoveFromRolesAsync(user, AddRole);
            await _userManager.AddToRolesAsync(user, RemoveRole);
            return false;
        }
        public async Task<Database.User> updateIdentityUser(int id, Model.User user)
        {
            try
            {
                Database.User appUser = await getUserById(id);

                var x = await _userManager.UpdateAsync(appUser);
                if (x.Succeeded)
                {
                    return appUser;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
            return null;
        }
    }
}
