using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class ClientService:BaseCRUDService<Model.Client, Model.Requests.ClientSearchRequest, Database.Client, Model.Client, Model.Requests.ClientInsertRequest>
    {
        IAuthService _authService;
        public ClientService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override List<Model.Client> Get(ClientSearchRequest search)
        {
            var query = _context.Set<Database.Client>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            query = query.Where(x => x.ClientID == authUser.UserID);

            var list = query.Include(x => x.User).Select(x => new Model.Client
            {
                ClientID=x.ClientID,
                DateOfBirth=x.DateOfBirth,
                FirstName=x.FirstName,
                Gender=x.Gender,
                JMBG=x.JMBG,
                LastName=x.LastName
            }).ToList();
            return list;
        }
        public override Model.Client Update(int id, ClientInsertRequest request)
        {
            var old = _context.Client.Where(x => x.ClientID == id).FirstOrDefault();
            old.FirstName = request.FirstName;
            old.LastName = request.LastName;
            old.Gender = request.Gender;
            old.JMBG = request.JMBG;
            old.DateOfBirth = request.DateOfBirth;
            _context.SaveChanges();
            return _mapper.Map<Model.Client>(old);
        }

    }
}
