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
    public class CargoService : BaseCRUDService<Model.Cargo, Model.Requests.CargoSearchRequest, Database.Cargo, Model.Requests.CargoInsertRequest, Model.Requests.CargoInsertRequest>
    {
        IAuthService _authService;
        public CargoService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override List<Model.Cargo> Get(CargoSearchRequest search)
        {
            var query = _context.Set<Database.Cargo>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            var list = query.Include(x => x.Client).Where(x=>x.IsUsed==false && x.ClientID==authUser.UserID).Select(x => new Model.Cargo
            {
                Description=x.Description,
                Image=x.Image,
                MaxHeight=x.MaxHeight,
                MaxWidth=x.MaxWidth,
                Name=x.Name,
                Weight=x.Weight,
                CargoID=x.CargoID,
                IsUsed=x.IsUsed
            }).ToList();
            return list;
        }
        public override Model.Cargo Delete(int id)
        {
            var cargo = _context.Cargo.Include(x => x.Client).Where(x => x.CargoID == id).FirstOrDefault();
            _context.Remove(cargo);
            _context.SaveChanges();
            return _mapper.Map<Model.Cargo>(cargo);
        }
        public override Model.Cargo Insert(CargoInsertRequest request)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            Database.Cargo cargo = new Database.Cargo()
            {
                ClientID=authUser.UserID,
                Description=request.Description,
                MaxHeight=request.MaxHeight,
                MaxWidth=request.MaxWidth,
                Name=request.Name,
                Weight=request.Weight,
                Image=request.Image
            };
            _context.Cargo.Add(cargo);
            _context.SaveChanges();
            return _mapper.Map<Model.Cargo>(cargo);
        }
        public override Model.Cargo Update(int id, CargoInsertRequest request)
        {
            if(request.isUpdate)
            {
                var old = _context.Cargo.Where(x => x.CargoID == id).FirstOrDefault();
                old.Description = request.Description;
                old.MaxHeight = request.MaxHeight;
                old.MaxWidth = request.MaxWidth;
                old.Name = request.Name;
                old.Weight = request.Weight;
                old.Image = request.Image;
                _context.SaveChanges();
                return _mapper.Map<Model.Cargo>(old);
            }
            else {
                var old = _context.Cargo.Where(x => x.CargoID == id).FirstOrDefault();
                old.IsUsed = request.IsUsed;
                _context.SaveChanges();
                return _mapper.Map<Model.Cargo>(old);
            }
        }
    }
}
