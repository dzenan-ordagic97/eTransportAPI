using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.ML;
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
    public class FreightService : BaseCRUDService<Model.Freight, Model.Requests.FreightSearchRequest, Database.Freight, Model.Freight, Model.Requests.FreightInsertRequest>
    {
        IAuthService _authService;

        public FreightService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override List<Model.Freight> Get(FreightSearchRequest search)
        {
            var query = _context.Set<Database.Freight>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            query = query.Include(x => x.Carrier).Where(x => x.CarrierID == authUser.UserID);

            if (search.Finished == true)
            {
                var list = query.Include(x => x.Carrier).Include(x => x.Vehicle).Where(x=>x.Finished==true).Select(x => new Model.Freight
                {
                    AcceptDate = x.AcceptDate,
                    VehicleID = x.VehicleID,
                    TransportDate = x.TransportDate,
                    Price = x.Price,
                    Finished = x.Finished,
                    Distance = x.Distance,
                    CarrierID = x.CarrierID,
                    ClientAccepted=x.ClientAccepted,
                    isPayed=x.IsPayed
                }).ToList();
                return list;
            }
            else
            {
                var list = query.Include(x => x.Carrier).Include(x => x.Vehicle).Select(x => new Model.Freight
                {
                    AcceptDate = x.AcceptDate,
                    VehicleID = x.VehicleID,
                    TransportDate = x.TransportDate,
                    Price = x.Price,
                    Finished = x.Finished,
                    Distance = x.Distance,
                    CarrierID = x.CarrierID,
                    ClientAccepted = x.ClientAccepted
                }).ToList();
                return list;
            }
        }
        public override Model.Freight Delete(int id)
        {
            var freight = _context.Freight.Include(x => x.Carrier).Where(x => x.FreightID == id).FirstOrDefault();
            _context.Remove(freight);
            _context.SaveChanges();
            return _mapper.Map<Model.Freight>(freight);
        }
        public override Model.Freight Update(int id, FreightInsertRequest request)
        {
            if (request.isTransaction == true)
            {
                var old = _context.Freight.Where(x => x.FreightID == id).FirstOrDefault();
                old.IsPayed = request.isPayed;
                _context.SaveChanges();
                return _mapper.Map<Model.Freight>(old);
            }else if(request.ClientAccepted==true)
            {
                var old = _context.Freight.Where(x => x.FreightID == id).FirstOrDefault();
                old.ClientAccepted = request.ClientAccepted;
                _context.SaveChanges();
                return _mapper.Map<Model.Freight>(old);
            }else if(request.ClientAccepted==false)
            {
                var old = _context.Freight.Where(x => x.FreightID == id).FirstOrDefault();
                old.AcceptDate = null;
                old.ClientAccepted = null;
                old.Distance = null;
                old.Finished = null;
                old.IsPayed = null;
                old.IsRated = null;
                old.Price = 0;
                old.TransportDate = null;
                old.VehicleID = null;
                _context.SaveChanges();
                return _mapper.Map<Model.Freight>(old);
            }else if(request.isAdding)
            {
                var old = _context.Freight.Where(x => x.FreightID == id).FirstOrDefault();
                old.IsRated = request.isRated;
                old.IsPayed = request.isPayed;
                old.Price = request.Price;
                old.AcceptDate = request.AcceptDate;
                old.CarrierID = request.CarrierID;
                old.Distance = request.Distance;
                old.TransportDate = request.TransportDate;
                old.VehicleID = request.VehicleID;
                _context.SaveChanges();
                return _mapper.Map<Model.Freight>(old);
            }
            else
            {
                var old = _context.Freight.Where(x => x.FreightID == id).FirstOrDefault();
                old.IsRated = request.isRated;
                _context.SaveChanges();
                return _mapper.Map<Model.Freight>(old);
            }
        }
        public override Model.Freight GetById(int id)
        {
            var query = _context.Set<Database.Freight>().AsQueryable();
            var freight = query.Include(x => x.Carrier).Where(x => x.FreightID == id).FirstOrDefault();
            return _mapper.Map<Model.Freight>(freight);
        }
    }
}
