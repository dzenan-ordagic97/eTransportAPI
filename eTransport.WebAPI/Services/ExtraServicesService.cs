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
    public class ExtraServicesService : BaseCRUDService<Model.ExtraServices, Model.Requests.ExtraServicesSearchRequest, Database.ExtraServices, Model.Requests.ExtraServicesInsertRequest, Model.Requests.ExtraServicesInsertRequest>
    {
        IAuthService _authService;
        public ExtraServicesService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;

        }
        public override Model.ExtraServices Insert(ExtraServicesInsertRequest request)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            Database.ExtraServices extraServices = new Database.ExtraServices()
            {
                CarrierID = authUser.UserID,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price
            };
            _context.ExtraServices.Add(extraServices);
            _context.SaveChanges();
            return _mapper.Map<Model.ExtraServices>(extraServices);
        }
        public override List<Model.ExtraServices> Get(ExtraServicesSearchRequest search)
        {
            var query = _context.Set<Database.ExtraServices>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            if(search.CarrierID!=0)
            {
                var list = query.Include(x => x.Carrier).Where(x=>x.CarrierID==search.CarrierID).Select(x => new Model.ExtraServices
                {
                    CarrierID=x.CarrierID,
                    Description=x.Description,
                    Name=x.Name,
                    Price=x.Price,
                    ExtraServicesID=x.ExtraServicesID
                }).ToList();
                return list;
            }
            else
            {
                var list = query.Include(x => x.Carrier).Where(c=>c.CarrierID == authUser.UserID).Select(x => new Model.ExtraServices
                {
                    CarrierID = x.CarrierID,
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    ExtraServicesID=x.ExtraServicesID
                }).ToList();
                return list;
            }
        }
        public override Model.ExtraServices Update(int id, ExtraServicesInsertRequest request)
        {
            var old = _context.ExtraServices.Include(x => x.Carrier).Where(x => x.ExtraServicesID == id).FirstOrDefault();
            old.Name = request.Name;
            old.Price = request.Price;
            old.Description = request.Description;
            _context.SaveChanges();
            return _mapper.Map<Model.ExtraServices>(old);
        }
    }
}
