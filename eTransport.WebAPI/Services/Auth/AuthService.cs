using AutoMapper;
using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly eTransportContext _context;
        private readonly AppSettings _appSettings;
        private readonly IApplicationUser _applicationUser;

        public AuthService(IOptions<AppSettings> appSettings, eTransportContext db, IMapper mapper, IApplicationUser applicationUser)
        {
            _mapper = mapper;
            _context = db;
            _appSettings = appSettings.Value;
            _applicationUser = applicationUser;
        }
        public async Task<Model.User> Authenticate(string username, string password)
        {
            var user = await _applicationUser.checkUserLogin(username, password);


            Model.User _korisnik = null;
            if (user != null)
            {
                var roles = await _applicationUser.getUserRoles(user);
                user.Carrier = _context.Carrier.Find(user.Id);
                user.Client = _context.Client.Find(user.Id);
                if (user.Client !=null || user.Carrier !=null)
                {

                    _korisnik = new Model.User()
                {

                    FirstName = user.Carrier != null ? user.Carrier.CarrierName : user.Client.FirstName,
                    LastName = user.Carrier != null ? "" : user.Client.LastName,
                    Email = user.Email
                };
                }
                else
                {
                    //admin
                    _korisnik = new Model.User()
                    {
                        Email = user.Email
                    };
                }
                // authentication successful so generate jwt token
                var jwt = await generateJwt(user, roles);
                _korisnik.Token = jwt;
                return _korisnik;
            }
            return null;
        }
        public UserIdentity GetUserIdentity(ClaimsIdentity claimsIdentity)
        {
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var roles = claimsIdentity.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
            return new Model.UserIdentity(userId, roles);
        }
        public async Task<Model.User> Register(ApplicationUserCreateRequest user)
        {

            var DbUser = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();

            if (DbUser != null)
            {
                throw new Exception("User alredy exist!");
            }

            var createdUser = await _applicationUser.createUser(user, user.Password);

            return await Authenticate(createdUser.Email, user.Password);
        }
        private async Task<string> generateJwt(Database.User user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Thumbprint, user.Carrier != null ? user.Carrier.BusinessNumber : "")
                    
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            foreach (var item in roles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, item));
            }
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
